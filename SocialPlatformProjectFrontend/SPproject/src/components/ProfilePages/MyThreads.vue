<template>
    <div>
        <div v-if="AuthState.isAuthenticated" class="temp">
            <h1>My Threads</h1>
            <p>
                Loopa ut alla trådar med användarens userId aka som användaren
                har skapat
            </p>
        </div>
        <div v-else>
            <NotAuthantication />
        </div>
        <div class="myThreads">
            <h1>{{AuthState.user.nickname }}: Threads</h1>
            <div class="user-threads element" v-for="userThreads in this.$store.state.UserThread" :key="userThreads.id">
                <div class="threads">
                    <router-link type="button" :to="`/Post/${userThreads.id}`">
                        <h1 >{{ userThreads.title }}</h1>
                        <span><p> Posted {{setTime(userThreads.createdDate)}}</p></span>
                        <p class="thread-text">{{userThreads.text}}</p>
                    </router-link>
                        <button class="btn-close" @click="RemoveThread(userThreads.id)">X</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import NotAuthantication from '../../Views/NotAuthorized.vue'
import dateclock from '/src/assets/js/dateclock.js'

export default {
    components: {
        NotAuthantication,
    },
    data() {
        return {
            userThreadList: [],
        }
    },
    methods: {
        fetchAllUserThreads() {
            this.$store.dispatch('GetThreadsFromUser', this.AuthState.user.sub)
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

    beforeMount() {
        this.fetchAllUserThreads()
    },

    created() {
        this.$store.commit('setToken', AuthState.token)
        this.fetchAllUserThreads()
        // if (AuthState.isAuthenticated == true || AuthState.isAuthenticated == false) {
        //     if (
        //         AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
        //     ) {
        //         this.$store.state.isAdmin = true
        //     }
        // }
    },
}
</script>

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'

const { login, logout, initAuth } = useAuth0(AuthState)

initAuth()
</script>

<style scoped>

.temp {
    color: #ffff;
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
