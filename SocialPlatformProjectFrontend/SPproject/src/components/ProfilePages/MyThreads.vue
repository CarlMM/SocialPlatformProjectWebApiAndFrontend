<template>
    <div>
        <div v-if="AuthState.isAuthenticated">
            <h1>My Threads</h1>
            <p>Loopa ut alla trådar med användarens userId aka som användaren har skapat</p>
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
}
</script>

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'

const { login, logout, initAuth } = useAuth0(AuthState)

initAuth()
</script>