8 lines (32 sloc) 941 Bytes
<template>
    <div>
        <div v-if="AuthState.isAuthenticated" class="temp">
            <h1>My profile</h1>
            <p>Loopa ut användarens data, så som nickname email osv?</p>
            <form>
                <img :src="AuthState.user.picture" alt="AvatarPic" />
                <br />
                <input type="text" v-model="AuthState.user.nickname" />
                <br />
                <input type="text" v-model="AuthState.user.email" />
            </form>
            <!-- <button @click="consoleLogMyUser()">ConsoleLogUser</button> -->
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
    methods: {
        consoleLogMyUser() {
            //var accessTokenObj = localStorage.getItem('access_token');

            //console.log('accesstoken: ', localStorage.getItem('access_token'));

            //__raw = token?
            // console.log(AuthState.claims.__raw)
            // this.$store.commit('setToken', AuthState.claims.__raw)
            console.log(AuthState.user)
            // console.log('statetoken: ', this.$store.state.token)
            //commit('setToken')
        },
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
</style>
