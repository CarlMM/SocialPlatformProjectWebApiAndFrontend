<template>
    <div>
        <div v-if="AuthState.isAuthenticated" class="temp">
            <h1>My groupthreads</h1>
            <p>Loopa ut alla trådar som har användarens userId</p>
        </div>
        <div v-else>
            <NotAuthantication />
        </div>
        <div class="myThreads">
            <h1>{{AuthState.user.nickname }}: GroupThreads</h1>
            <div class="user-threads element"  v-for="threads in this.$store.state.UserGroupThread" :key="threads.Id"  >
                <div class="threads">
                    <router-link type="button" :to="`/GroupPost/${threads.id}`">
                        <h1>{{threads.title}}</h1>
                        <p>{{threads.text}}</p>
                    </router-link>
                    <button class="btn-close" @click="RemoveThread(threads.id)">X</button>
                </div>
            </div>
        </div>
    </div>
</template>


<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'

const { initAuth } = useAuth0(AuthState)

initAuth()
</script>

<script>
import NotAuthantication from '../../Views/NotAuthorized.vue'

export default {
    
    components: {
        NotAuthantication,
    },

    data(){
        return{
            getGroupUserThread:[],
        }
    },
    computed:{

    },
    methods:{
        async fetchGroupThreads(){
            this.$store.dispatch('GetGroupThreadsFromUser', this.AuthState.user.sub)
        }
    },
    RemoveThread(id) {
            let deleteConfirm = 'Are u sure you want to delete thread?'
            if(confirm(deleteConfirm) == true){
                //Removes Id specific to thread
                this.$store.dispatch('delelteSpecificThread', id)
    
                let threadId = id
                //Fetch the list of userThread
                let list = this.$store.state.UserThread
                //Goes through the list, filter it and check for what is no longer there
                let updatedList = list.filter(item => {
                    return item.id !== threadId
                })
                this.$store.commit('updateSpecificThreadAfterDelete', updatedList)
            }
            else{
                
            }
        },

    beforeMount(){
        this.fetchGroupThreads()
    },

    created(){
        this.fetchGroupThreads()
    },       
}
</script>

<style scoped>
.temp{
    color:#ffff;
}

.btn-close {
    position: absolute;
    color: rgb(255, 255, 255);
    right:5vw;
    padding: 0;
    margin: 15px 5px;
    font-size: 20px;
    cursor: pointer;
    font-weight: bold;
    background: transparent;
}

</style>