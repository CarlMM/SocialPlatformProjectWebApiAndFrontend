<template>
    <div class="outer-box">
        <div
            v-for="threads in list"
            :key="threads.Id"
            class="subforum-description">
            <div class="subforum-row">
                <div class="subforum-icon subforum-column center">
                    <img src="https://hatrabbits.com/wp-content/uploads/2017/01/random.jpg" alt="">
                </div>
                <div class="subforum-description subforum-column">
                    <router-link type="button" :to="`/Post/${threads.id}`">
                        <h1>{{ threads.title }}</h1>
                    </router-link>
                    <span><p>Posted by<a href="">User</a>15 jan 2022</p></span>
                    <p>{{ threads.Text }}</p>
                    <button class="post-btn" @click="showModal(threads.Id)">
                        <i class="far fa-comment icon"></i>
                        <span>Comment</span>
                    </button>
                    <button class="post-btn">
                        <i class="far fa-surprise icon"></i>
                        <span>Surprise</span>
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
            </div>
        </div>
        <div
            v-for="threads in GetThreads"
            :key="threads.Id"
            class="subforum-description">
            <div class="subforum-row">
                <div class="subforum-icon subforum-column center">
                    <img src="https://hatrabbits.com/wp-content/uploads/2017/01/random.jpg" alt="">
                    <!-- <i class="fas fa-laptop"></i> -->
                </div>
                <div class="subforum-description subforum-column">
                    <router-link type="button" :to="`/Post/${threads.id}`">
                        <h1>{{ threads.title }}</h1>
                    </router-link>
                    <span><p>Posted by<a href="">User</a>15 jan 2022</p></span>
                    <p>{{ threads.Text }}</p>
                    <button class="post-btn" @click="showModal(threads.Id)">
                        <i class="far fa-comment icon"></i>
                        <span>Comment</span>
                    </button>
                    <button class="post-btn">
                        <i class="far fa-surprise icon"></i>
                        <span>Surprise</span>
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
                    <div class="subforum-description subforum-column">
                        <h1>{{ this.threadtitle }}</h1>
                        <h1>
                            <small
                                >Posted by <a href="">User</a> 15 Jan
                                2022</small
                            >
                        </h1>
                        <p>{{ this.threadText }}</p>
                    </div>
                    <div id="container">
                        <div class="form-group">
                            <label for="reply-content">Add content</label>
                            <textarea
                                placeholder="Remember, be nice!"
                                cols="78"
                                rows="5"
                                v-model="replyMessage"
                            ></textarea>
                        </div>
                        <button class="btn btn-reply" @click="saveInput()">
                            Reply
                        </button>
                        <div v-for="error in errors" :key="error.id">
                            <ul>
                                <li>{{ error }}</li>
                            </ul>
                        </div>
                    </div>
                </template>
            </Modal>
        </div>
    </div>
    <!-- <div class="subform">
            <div class="subforum-title">
                <h1>General Information</h1>
            </div>
    </div> -->
</template>

<script>
import Modal from './Modal.vue'
// import { mapMutations } from 'vuex'

export default {
    posts: ['thread'],
    props: ["list"],
    components: {
        Modal,
    },
    data() {
        return {
            badWords: ['carl', 'alex', 'samy', 'jony', 'thomas'],
            isModalVisible: false,
            cId: this.$route.params.id,
            catId: this.$route.params.Id,
            threadId: null,
            threadTitle: '',
            threadText: '',
            replyMessage: '',
            errors: [],
        }
    },

    beforeMounted() {
        this.GetThreads()
    },

    computed: {
        GetThreads() {
            let list = this.$store.state.Thread

            let filterlist = list.filter(item => {
                return item.categoryId == this.cId
            })
            console.log(filterlist)
            return filterlist
        },
        GetAllThreads() {
            let list = this.$store.state.Thread
            return list
        },
        GetCategory() {
            let categoryList = this.$store.state.Category

            let filterList = categoryList.filter(item => {
                return item.Id == this.catId
            })
            console.log('this is categorylist')
            console.log(filterList)
            return filterList
        },
    },
    methods: {
        showModal(threadId) {
            this.isModalVisible = true
            this.threadId = threadId
            let threadList = this.$store.state.Thread

            let specificThread = threadList.find(item => {
                return item.Id == this.threadId
            })

            //Destrucure objektet i variabler
            let { Id, Title, Text, CategoryId } = specificThread

            this.threadTitle = Title
            this.threadText = Text
        },

        closeModal() {
            this.errors == []
            this.replyMessage = ''
            this.isModalVisible = false
        },

        filterWords(array) {
            let filteredWordsArray = array.toLowerCase().split(' ')
            let catchBadWords = filteredWordsArray.filter(item =>
                this.badWords.includes(item)
            )
            return catchBadWords
        },

        saveInput() {
            this.errors = []
            let catchBadWords = this.filterWords(this.replyMessage)
            if (this.replyMessage == '' || catchBadWords.length > 0) {
                this.replyMessage == ''
                    ? this.errors.push('Please enter some text!')
                    : this.errors.push('Please be nice!')
            } else if (this.replyMessage != '') {
                this.errors = []
                this.closeModal()
            }
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
.post-btn{
    height: 35px;
    padding: 0 15px;
    background:inherit;
    color:#ffff;
    border: none;
    user-select: none;
    white-space: nowrap;
    transition: all .05s linear;
    font-family: inherit;
}

.post-btn:active{
    color: white;
    box-shadow: 0 0.2rem #dfd9d9;
    transform: translateY(0.2rem);
}

.post-btn:disabled{
    cursor:auto;
    color:grey;
}

.icon{
    font-size:20px;
    margin-right:10px;
}


/* Style inside modal */
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
