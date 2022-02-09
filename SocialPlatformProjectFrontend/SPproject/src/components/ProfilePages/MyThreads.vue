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
            <div class="user-threads" v-for="userThreads in this.$store.state.UserThread" :key="userThreads.id">
                <div class="threads">
                    <router-link type="button" :to="`/Post/${userThreads.id}`">
                        <h1 >{{ userThreads.title }}</h1>
                        <p class="thread-text">{{userThreads.text}}</p>
                    </router-link>
                        <button class="btn-close" @click="RemoveThread(userThreads.id)">X</button>
                </div>
            </div>
        </div>
        <!-- <div
            v-for="userThreads in this.$store.state.UserThread"
            :key="userThreads.id">
            <router-link type="button" :to="`/Post/${userThreads.id}`">
                <h1 style="color: white">{{ userThreads.title }}</h1>
            </router-link>
            <div>
                <button @click="RemoveThread(userThreads.id)">Ta bort</button>
            </div>
        </div> -->
    </div>
</template>

<script>
import NotAuthantication from '../../Views/NotAuthorized.vue'

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
        },
    },

    beforeMount() {
        this.fetchAllUserThreads()
    },

    created() {
        this.fetchAllUserThreads()
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

.myThreads{
    border-radius: 4px;
    background-color:#4b4b4b;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.myThreads > h1{
    font-family: 'Roboto', sans-serif;
    font-size: 24px;
    padding: 20px 0;
    margin: 0 20px;
}

.user-threads{
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    background: #1d1d1d;
    padding: 1px 0;
}

.threads{
    border-radius: 2px;
    background:#656a83;
    padding: 20px 10px;
}

.threads > a >h1{
    font-size: 24px;
    font-weight: 600;
}

.thread-text{
    font-size: 16px;
    padding:0;
    margin:0;
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
