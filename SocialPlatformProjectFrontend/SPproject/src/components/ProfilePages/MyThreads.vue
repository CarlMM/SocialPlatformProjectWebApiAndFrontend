<template>
    <div>
        <div v-if="AuthState.isAuthenticated" class="temp">
            <h1>My Threads</h1>
            <p>Loopa ut alla trådar med användarens userId aka som användaren har skapat</p>
        </div>
        <div v-else>
            <NotAuthantication />
        </div>
        <div v-for="userThreads in this.$store.state.UserThread" :key="userThreads.id">
            <h1 style="color:white">{{userThreads.title}}</h1>
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
        }
    },
    mounted(){
        this.fetchAllUserThreads();
    }
}
</script>

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'

const { login, logout, initAuth } = useAuth0(AuthState)

initAuth()
</script>

<style scoped>
.temp{
    color: #ffff;
}
</style>