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
        <div
            v-for="userThreads in this.$store.state.UserThread"
            :key="userThreads.id"
        >
            <router-link type="button" :to="`/Post/${userThreads.id}`">
                <h1 style="color: white">{{ userThreads.title }}</h1>
            </router-link>
            <div>
                <button @click="RemoveThread(userThreads.id)">Ta bort</button>
            </div>
        </div>
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
li {
    list-style: none;
}
</style>
