<template>
    <div class="temp">
        <div v-for="thread in getPost" :key="thread.id">
            <h1>{{ thread.title }}</h1>
            <p>{{ thread.text }}</p>
            <p>{{ thread.id }}</p>
        </div>
        <div class="subforum-description subforum-column">
            <h1>Detta är replies</h1>
            <div>
                <button @click="toogleModal()">Reply to post</button>
            </div>

            <div class="d-flex justify-content-end mt-1">
                <Modal v-show="isModalVisible" @close="closeModal">
                    <template v-slot:header>
                        <div class="text-uppercase">
                            reply
                            <span><i class="fas fa-comments"></i></span></div
                    ></template>
                    <template v-slot:body>
                        <div class="subforum-description subforum-column">
                            <h1>
                                <small
                                    >Posted by <a href="">User</a> 15 Jan
                                    2022</small
                                >
                            </h1>
                            <h1>{{ this.threadTitle }}</h1>
                            <p>{{ this.threadText }}</p>
                        </div>
                        <div id="container">
                            <div class="form-group">
                                <label for="reply-content">Add content</label>
                                <textarea
                                    placeholder="Remember, be nice!"
                                    cols="78"
                                    rows="5"
                                    v-model="newReplyPost.Text"
                                ></textarea>
                            </div>
                            <button
                                class="btn btn-reply"
                                v-on:click="this.reply(newReplyPost)"
                            >
                                Reply
                            </button>
                            <div v-for="error in errorMessage" :key="error.id">
                                <ul>
                                    <li style="color: #333">{{ error }}</li>
                                </ul>
                            </div>
                        </div>
                    </template>
                </Modal>
            </div>
            <div v-for="item in getReplies" :key="item.id">
                {{ item.id }}
                <!-- {{ item.categoryThreadId }} -->
                <p>{{ item.text }}</p>
            </div>
        </div>
    </div>
</template>

<script>
import { AuthState } from '../auth0/useAuth0'
import Modal from '/src/components/Modal.vue'
import { mapActions } from 'vuex'

export default {
    data() {
        return {
            badWords: ['fuck', 'kuk', 'snopp', 'whore', 'dick'],
            tId: this.$route.params.Id,
            isModalVisible: false,
            replyMessage: '',
            threadId: null,
            threadTitle: '',
            threadText: '',
            errorMessage: [],
            missingTextMessage: '',
            newReplyPost: {
                Text: '',
                UserIdSub: '',
                CategoryThreadId: null,
            },
        }
    },
    components: {
        Modal,
    },

    mounted() {
        //this.fetchRepliesForPost();
        //this.fetchReplyForPost();
    },
    created() {
        console.log('id from url', this.tId)

        this.$store.dispatch('GetThreadFromSpecificId', this.tId)
        this.$store
            .dispatch('GetRepliesForSpecificPost', this.tId)
            .then(() => console.log('for science'))
    },

    computed: {
        getPost() {
            console.log(
                'getPostmetod i Post.vue: ',
                this.$store.state.SpecificPostThread
            )
            return this.$store.state.SpecificPostThread
        },
        getReplies() {
            return this.$store.state.Reply
        },
        checkIfAuth() {
            if (AuthState.isAuthenticated == true) {
                return true
            }
        },
    },

    mounted() {
        if (this.$store.state.comingFromThreads == true) {
            this.showModal()
            this.$store.state.comingFromThreads = false
        }
    },

    methods: {
        toogleModal() {
            if (AuthState.isAuthenticated) {
                this.showModal()
            }
        },
        showModal() {
            this.isModalVisible = true
            let threadList = this.$store.state.SpecificPostThread

            //Destrucure objektet i variabler
            let {
                0: {
                    id,
                    title,
                    text,
                    categoryId,
                    category,
                    createdDate,
                    replies,
                    threadType,
                    threadUsers,
                    userIdSub,
                },
            } = threadList

            this.threadTitle = title
            this.threadText = text
        },

        closeModal() {
            this.errorsMessage = []
            this.replyMessage = ''
            this.isModalVisible = false
        },

        filterWords(message) {
            let filteredWordsArray = message.toLowerCase().split(' ')
            let catchBadWords = filteredWordsArray.filter(item =>
                this.badWords.includes(item)
            )
            return catchBadWords
        },

        ...mapActions(['PostReplyToSpecificPost']),
        reply(newReplyPost) {
            this.errorMessage = []
            let catchBadWords = this.filterWords(this.newReplyPost.Text)
            console.log(this.newReplyPost, 'REPLY MESSAGE')
            if (this.newReplyPost.Text == '') {
                this.errorMessage.push('Please enter some text!')
            }
            if (catchBadWords.length > 0) {
                this.errorMessage.push('Remember to be nice!')
            } else if (
                this.newReplyPost.Text != '' &&
                catchBadWords.length == 0
            ) {
                this.errors = []
                this.newReplyPost.UserIdSub = AuthState.user.sub
                this.newReplyPost.CategoryThreadId = this.tId
                console.log('ReplyMethod: ', newReplyPost)
                console.log(
                    'Log in ReplyMethod, this is reply store: ',
                    this.$store.state.Reply
                )
                this.PostReplyToSpecificPost(newReplyPost)
                this.closeModal()
                this.newReplyPost.Text = ''
            }
            //return this.$store.dispatch('PostReplyToSpecificPost', newReplyPost)
        },
    },
}
</script>

<style scoped>
* {
    box-sizing: border-box;
}

li {
    list-style: none;
}

a {
    color: rgb(153, 149, 163);
    font-weight: bolder;
}

p {
    color: white;
}

.post-link > a {
    color: white;
    padding-right: 10px;
    font-size: 12px;
}

h1 {
    font-size: 18px;
    font-weight: bolder;
    color: white;
}

/*Body*/
.outer-box {
    background: #484848;
    border-radius: 5px;
    margin-bottom: 20px;
}

.subforum {
    margin-top: 20px;
}

.subforum-title {
    background-color: rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
}

.subforum-row {
    display: grid;
    grid-template-columns: 7% 93%;
}

.subforum-column {
    border-radius: 5px;
    margin: 1px;
    background-color: rgb(48, 48, 48);
}

.subforum-description {
    padding: 2px;
}

.center {
    display: flex;
    justify-content: center;
    align-items: center;
}

.subforum-icon > img {
    height: 95%;
    width: 95%;
    border-radius: 3px;
}

/*Category*/
.category {
    margin-top: 20px;
}

.category-title {
    background-color: rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin-bottom: 20px;
}

/*Buttons in thread */
.post-btn {
    height: 35px;
    padding: 0 15px;
    background: inherit;
    color: #ffff;
    border: none;
    user-select: none;
    white-space: nowrap;
    transition: all 0.05s linear;
    font-family: inherit;
}

.post-btn:active {
    color: white;
    box-shadow: 0 0.2rem #dfd9d9;
    transform: translateY(0.2rem);
}

.post-btn:disabled {
    cursor: auto;
    color: grey;
}

.icon {
    font-size: 20px;
    margin-right: 10px;
}
.temp {
    color: #ffff;
}
#container {
    margin: 40px auto;
    max-width: 600px;
    /* border: 1px solid red; */
}
.form-group label {
    font-size: 1.1rem;
    display: block;
    color: #666;
}

.form-group input {
    width: 100%;
    padding: 10px;
    border: rgb(158, 158, 158) 1px solid;
    border-radius: 5px;
}

.btn-reply {
    background-color: #43a78c;
    display: block;
    width: 100%;
    padding: 10px;
    color: #fff;
    cursor: pointer;
}

.btn-reply:hover {
    background: #5ab6a6;
}

textarea {
    resize: none;
}
</style>
