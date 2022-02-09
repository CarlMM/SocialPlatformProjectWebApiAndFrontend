<template>
    <div class="outer-box">
        <div v-if="AuthState.isAuthenticated">
            <div class="user">
                <h2>{{AuthState.user.nickname}}: Threads</h2>
            </div>
                <div class="post-main" v-for="userThreads in this.$store.state.UserThread" :key="userThreads.id">
                        <div class="post-text">
                            <div class="main-post">
                                <div class="text" >
                                <button type="button" class="btn-close" @click="RemoveThread(Thread.id)">x</button>
                                    <router-link type="button" :to="`/Post/${userThreads.id}`">
                                        <h1>{{userThreads.title}}</h1>
                                    </router-link>
                                    <span><p>Posted by <a href="#"> User </a> 15 jan 2022</p></span>
                                        <p>{{ userThreads.text}}</p>
                                </div>
                                <button class="post-btn" @click="goPost(userThreads.id)">
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
                                    <i class="far fa-edit"></i>
                                    <span>Edit post</span>
                                </button>
                            </div>  
                        </div>
                </div>
        </div>
        <div v-else>
            <NotAuthantication />
        </div>
        
    </div>
</template>


<script>
import NotAuthantication from '../../Views/NotAuthorized.vue'

export default {
    components: {
        NotAuthantication,
    },
    methods:{
        fetchAllUserThreads(){
            this.$store.dispatch('GetThreadsFromUser', this.AuthState.user.sub)
        },
        RemoveThread(id){
            //Removes Id specific to thread
            this.$store.dispatch('delelteSpecificThread', id)

            let threadId = id;
            //Fetch the list of userThread
            let list = this.$store.state.UserThread
            //Goes through the list, filter it and check for what is no longer there
            let updatedList = list.filter(item => {
                return item.id !== threadId;
            })
            this.$store.commit('deleteSpecificThread', updatedList)
        },
        goPost(id){
            this.$router.push('/Post/' + id)
            this.$store.state.comingFromThreads = true
        }
    },
    mounted(){
        this.fetchAllUserThreads();
        this.$store.state.UserThread;
        console.log('Bajs created(): ', this.$store.state.UserThread)
    },
    // created(){
    //     this.$store.state.UserThread;
    //     console.log('Bajs created(): ', this.$store.state.UserThread)
    // },
    // beforeCreate(){
    //     this.$store.state.UserThread;
    //     console.log('beforeCreate ', this.$store.state.UserThread)
    // }
}
</script>

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'

const { login, logout, initAuth } = useAuth0(AuthState)

initAuth()
</script>

<style scoped>


a {
    text-decoration: none;
}

.outer-box {
    background: #484848;
    color:white;
    border-radius: 3px;
}

.user{
    display:flex;
    align-content: flex-start;
    justify-content: flex-start;
    padding: 5px 10px;
}

.post-main {
    display:flex;
    background-color:#303030;
    padding-top: 1px;
    padding-right: 5px;
    color:#fff;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);

}


.main-post {
    padding: 8px 10px;
}


.text {
    margin-top: 20px;
}

.text > a > h1{
    color: #fff;
    font-size: 24px;
}


.btn-close{
    position: absolute;
    display:flex;
    color:#fff;
    top: 46vh;
    right:4.5vw;
    padding:0;
    margin: 0;
    font-size:20px;
    cursor: pointer;
    font-weight: bold;
    background: transparent;
}


</style>