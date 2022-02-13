<template>
    <div>
        <div v-if="AuthState.isAuthenticated" class="temp">
            <h1>My Replies</h1>
            <p>
                Loops out all replies that the user creates
            </p>
        </div>
        <div v-else>
            <NotAuthantication />
        </div>
        <div class="myThreads">
            <h1>{{AuthState.user.nickname }}: Replies</h1>
            <div class="user-threads element" v-for="userReplies in this.$store.state.AllReplies" :key="userReplies.id">
                <div class="threads">
                        <span><p> Replied {{setTime(userReplies.createdDate)}}</p></span>
                        <p class="thread-text">{{userReplies.text}}</p>
                        <button class="btn-close" @click="RemoveReplies(userReplies.id)">X</button>
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
            
        }
    },
    methods: {
        fetchAllRepliesUser() {
            this.$store.dispatch('GetAllRepliesUser', this.AuthState.user.sub)
        },
        RemoveReplies(id) {
            let deleteConfirm = 'are u sure you want to delete reply?'
            if(confirm(deleteConfirm) == true){
                //Removes Id specific to thread
                this.$store.dispatch('DeleteSpecificReply', id)
    
                let ReplyId = id
                //Fetch the list of userThread
                let list = this.$store.state.AllReplies
                //Goes through the list, filter it and check for what is no longer there
                let updatedList = list.filter(item => {
                    return item.id !== ReplyId
                })
                this.$store.commit('updateSpecificReplyAfterDelete', updatedList)
            }
            else{
                
            }
        },
        setTime(date){
            return dateclock.DateOfCreation(date)
        },
    },

    beforeMount() {
        this.fetchAllRepliesUser()
    },

    created() {
        this.fetchAllRepliesUser()
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
    margin: -25px 0;
    font-size: 20px;
    cursor: pointer;
    font-weight: bold;
    background: transparent;
}

</style>
