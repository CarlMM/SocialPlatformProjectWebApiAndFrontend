<template>
    <div class="outer-box">
        <div class="post-andReply">
            <div class="post-text">
                <div class="main-post">
                    <div class="main-text"  v-for="thread in getPost" :key="thread.id">
                        <h1 class="post-h1">{{ thread.title }}</h1>
                        <span class="post-user">Posted {{setTime(thread.createdDate)}}</span>
                        <p>{{ thread.text }}</p>
                    </div>
                <button class="post-btn" @click="toggleModal()">
                    <i class="far fa-comment icon"></i>
                    <span>comment</span>
                </button>
                <button class="post-btn">
                        <i class="fa-regular fa-pen-to-square icon"></i>
                        <span>Edit</span>
                    </button>
                    <button class="post-btn">
                        <i class="far fa-share-square icon"></i>
                        <span>Share</span>
                    </button>
                    <button class="post-btn">
                        <i class="far fa-flag icon"></i>
                        <span>Report</span>
                    </button>
                </div>
                <div class="post-andReply subforum-column">
                        <div class="replies" v-for="item in getReplies" :key="item.id">
                        <span class="post-user">Replied {{setTime(item.createdDate)}}</span>
                                <p class="reply-text">{{ item.text}}</p>
                            <button class="post-btn">
                                <i class="far fa-comment icon"></i>
                                <span>Reply</span>
                            </button>
                            <button class="post-btn">
                                <i class="fa-regular fa-pen-to-square icon"></i>
                                <span>Edit</span>
                            </button>
                            <button class="post-btn">
                                <i class="far fa-share-square icon"></i>
                                <span>Share</span>
                            </button>
                            <button class="post-btn">
                                <i class="far fa-flag icon"></i>
                                <span>Report</span>
                            </button>
                            <button class="post-btn">
                                <i class="fa-solid fa-trash icon"></i>
                                <span>Delete</span>
                            </button>
                        </div>
                </div>
            </div>
        </div>
        <div class="d-flex justify-content-end mt-1">
            <Modal v-show="isModalVisible" @close="closeModal">
                                <template v-slot:header>
                                    <div class="text-uppercase">
                                        reply
                                        <span><i class="fas fa-comments"></i></span></div
                                ></template>
                                <template v-slot:body>
                                    <div class="main-post m2">
                                        <h1>{{ this.threadTitle }}</h1>
                                        <p>Posted {{this.threadDate}}</p>
                                        <!-- <p>{{setTime(threadDate)}}</p> -->
                                        <p>{{ this.threadText }}</p>
                                    </div>
                                    <div id="container">
                                        <div class="form-group">
                                            <label for="reply-content">Add content</label>
                                            <textarea class="textareas"
                                                placeholder="Remember, be nice!"
                                                cols="78"
                                                rows="5"
                                                v-model="newReplyPost.Text"
                                            ></textarea>
                                        </div>
                                        <button class="btn-all" v-on:click="this.reply(newReplyPost)">
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
    </div>
</template>

<script>
import { AuthState } from '../auth0/useAuth0'
import Modal from '/src/components/Modal.vue'
import { mapActions } from 'vuex'
import dateclock from '/src/assets/js/dateclock.js'

export default {
    data() {
        return {
            badWords: ['fuck', 'dick', 'wiener', 'whore', 'shit', 'thomas', 'skåne'],
            tId: this.$route.params.Id,
            isModalVisible: false,
            replyMessage: '',
            threadId: null,
            threadTitle: '',
            threadText: '',
            threadDate: '',
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
        
        this.$store.commit('setToken', AuthState.token)
        this.$store.dispatch('GetThreadFromSpecificId', this.tId)
        this.$store.dispatch('GetRepliesForSpecificPost', this.tId)

        // if (AuthState.isAuthenticated == true) {
        //     if (
        //         AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
        //     ) {
        //         this.$store.state.isAdmin = true
        //     }
        // }
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
        toggleModal() {
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
            this.threadDate = createdDate.slice(0, 10)
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
                this.$store.dispatch('GetRepliesForSpecificPost', this.tId)
                this.closeModal()
                location.reload()
                this.newReplyPost.Text = ''
            }
            //return this.$store.dispatch('PostReplyToSpecificPost', newReplyPost)
        },
        setTime(date){
            return dateclock.DateOfCreation(date)
        },
    },
}
</script>

<style scoped>

.textareas{
    width:100%
}

.m2{
    border-radius: 4px;
}

.subforum-column {
    margin-top:1px;
    padding-bottom: 0.1px;
    background-color: #525d92;
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

.btn-all{
    display:block;
    width: 100%;
    padding:10px;
    cursor: pointer;
}

.btn-reply:hover {
    background: #5ab6a6;
}

textarea {
    resize: none;
}

</style>
