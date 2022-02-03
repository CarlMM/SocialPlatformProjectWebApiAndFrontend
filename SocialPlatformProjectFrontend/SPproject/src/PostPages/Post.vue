<template>
<div class="temp">
    
    <div v-for="thread in getPost" :key="thread.id">
        <h1>{{ thread.title }}</h1>
        <p>{{thread.text}}</p>
        <p>{{thread.id}}</p>
        
    </div>
    <!-- <div class="subforum-description subforum-column">
        <h1>Detta är replies</h1>
            <div v-for="item in this.$store.state.Reply" :key="item.id">
                {{reply.id}}
                {{ item.categoryThreadId }}
                {{ item.text }}
            </div>
        </div> -->
    </div>
</template>

<script>

import {mapActions} from "vuex";


export default {


    data() {
        return {
            tId: this.$route.params.Id,
        }
    },

    mounted(){
        //this.fetchRepliesForPost();
        //this.fetchReplyForPost();
    },
    created(){
        console.log('id from url', this.tId)
        this.$store.dispatch('GetThreadFromSpecificId', this.tId);
        //this.$store.dispatch('GetRepliesForSpecificPost', this.tId);
        
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
    },

    
}
</script>


<style scoped>
.temp{
    color:#ffff;
}
</style>