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
            <h1>{{AuthState.user.nickname }}: Made Groups</h1>
            <div class="user-threads element"  v-for="threads in this.$store.state.UserGroupThread" :key="threads.Id"  >
                        <div class="threads">
                            <router-link class="routerPosts" :to="`/GroupPost/${threads.id}`">
                                <h1>{{threads.title}}</h1>
                                <span><p>Posted {{setTime(threads.createdDate)}}</p></span>
                                <!-- <span><p>Posted {{threads.createdDate}}</p></span> -->
                                <p class="p-text">{{threads.text}}</p>
                            </router-link>
                        </div>
                <button class="btn-close" @click="RemoveThread(threads.id)">X</button>
            </div>
            
        </div>
        <div class="myThreads">
            <h1>{{AuthState.user.nickname }}: Joined Groups</h1>
            <div class="user-threads element" v-for="groups in GetUserGroups" :key="groups.id" >
                <div class="threads">
                    <router-link class="routerPosts" :to="`/GroupPost/${groups.id}`">
                        <h1>{{groups.title}}</h1>
                        <span><p>Posted {{setTime(groups.createdDate)}}</p></span>
                        <!-- <span><p>Posted {{groups.createdDate}}</p></span> -->
                        <p class="p-text">{{groups.text}}</p>
                    </router-link>
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
import dateclock from '/src/assets/js/dateclock.js'

export default {
    
    components: {
        NotAuthantication,
    },

    data(){
        return{
            getGroupUserThread:[],
            groupWithMyIdInIt:[],
        }
    },
    computed:{
       GetUserGroups(){
           let result = this.$store.state.userRelatedGroup
             .filter(x1 => this.$store.state.groupThreadsAdmin.some(x2 => x1.categoryThreadId === x2.id))
             console.log(result, "result");
             this.groupWithMyIdInIt = result;

            
            console.log('lilla Listan: ', this.groupWithMyIdInIt)
            

            let groups = this.$store.state.groupThreadsAdmin

            
            console.log('stora listan: ', groups)

            
            let filtered = groups.filter(o1 => this.groupWithMyIdInIt
            .some(o2 => o1.id === o2.categoryThreadId))

            console.log('filtrerad stora lista: ', filtered)

            return filtered;
            

       }
    },
    methods:{
        async fetchGroupThreads(){
            this.$store.dispatch('GetGroupThreadsFromUser', this.AuthState.user.sub)
        },
        async getUserGroups(){
            this.$store.dispatch('getUserGroups', this.AuthState.user.sub)
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
        setTime(date){
            return dateclock.DateOfCreation(date)
        },
    },

    beforeMount(){
        this.fetchGroupThreads()
    },

    created(){
        this.$store.commit('setToken', AuthState.token)
        this.$store.dispatch('getAllGroupThreadsAdmin')
        this.fetchGroupThreads()
        this.getUserGroups()
        if (AuthState.isAuthenticated == true) {
            if (
                AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
            ) {
                this.$store.state.isAdmin = true
            }
        }
    },       
}
</script>

<style scoped>
.temp{
    color:#ffff;
}

/* .routerPosts{
    width: 100%;
    padding:0;
    margin: 0;
}

.threads{
    z-index:0;
} */

.p-text{
    font-size: 18px;
}

.btn-close {
    position: absolute;
    color: rgb(255, 255, 255);
    right:5vw;
    padding: 0;
    margin: -10vh 0;
    font-size: 20px;
    cursor: pointer;
    font-weight: bold;
    background: transparent;
}

</style>