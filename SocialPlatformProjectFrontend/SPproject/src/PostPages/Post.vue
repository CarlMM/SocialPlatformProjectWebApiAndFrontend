<template>
<div class="temp">
    
    <div v-for="thread in getPost" :key="thread.id">
        <h1>{{ thread.title }}</h1>
        <p>{{thread.text}}</p>
        <p>{{thread.id}}</p>
        
    </div>
    <div class="subforum-description subforum-column">
        <h1>Detta är replies</h1>
        <button @click="showModal()">Reply to post</button>
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
            <div v-for="item in this.$store.state.Reply" :key="item.Id">
                {{item.Id}}
                {{ item.categoryThreadId }}
                {{ item.text }}
            </div>
        </div>
    </div>
</template>

<script>
import Modal from '/src/components/Modal.vue'
import {mapActions} from "vuex";


export default {


    data() {
        return {
            tId: this.$route.params.Id,
            isModalVisible: false,
        }
    },
    components:{
        Modal,
    },

    mounted(){
        //this.fetchRepliesForPost();
        //this.fetchReplyForPost();
    },
    created(){
        console.log('id from url', this.tId)
        this.$store.dispatch('GetThreadFromSpecificId', this.tId);
        this.$store.dispatch('GetRepliesForSpecificPost', this.tId);
        
    },

    computed: {
        // getSpecificThread() {
        //     console.log('id from url ', this.tId)
        //     let list = this.$store.state.Thread
        //     console.log(this.tId)

        //     let filteredThread = list.filter(item => {
        //         return item.id == this.tId
        //     })
        //     console.log('filteredThread: ', filteredThread)
        //     return filteredThread
        // },

        getPost(){
            console.log('getPostmetod i Post.vue: ', this.$store.state.SpecificPostThread)
            return this.$store.state.SpecificPostThread
        }
        
    },

    methods:{
        // ...mapActions(["GetRepliesForSpecificPost"]),
        // async fetchRepliesForPost(){
        //     // id = this.tId;
            
        //     this.GetRepliesForSpecificPost(this.tId)

        //     // id = this.tId;
        //     // console.log('Reply', this.$store.state.reply)
        //     // this.$store.dispatch('GetRepliesForSpecificPost', id)
        // },

        // async fetchReplyForPost(){
        //      this.$store.dispatch('GetRepliesForSpecificPost', this.tId)
        // }
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
.temp{
    color:#ffff;
}
</style>