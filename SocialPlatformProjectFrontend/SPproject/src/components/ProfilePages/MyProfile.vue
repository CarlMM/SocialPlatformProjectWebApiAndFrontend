8 lines (32 sloc) 941 Bytes
<template>
    <div>
        <div v-if="AuthState.isAuthenticated">
            <h1>My profile</h1>
            <p>Loopa ut användarens data, så som nickname email osv?</p>

            <form>
                <img :src="AuthState.user.picture" alt="AvatarPic" />
                <br />
                <input type="text" v-model="AuthState.user.nickname" />
                <br />
                <input type="text" v-model="AuthState.user.email" />
            </form>
        </div>
        <div v-else>
            <!-- <h1>UR NOT AUTHONTICATED</h1> -->
            <NotAuthantication />
        </div>
    </div>
</template>

<script>
import NotAuthantication from '../../Views/NotAutherized.vue'

export default {
    components: {
        NotAuthantication,
    },
}
</script>

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'
const { login, logout, initAuth } = useAuth0(AuthState)
initAuth()
</script>

