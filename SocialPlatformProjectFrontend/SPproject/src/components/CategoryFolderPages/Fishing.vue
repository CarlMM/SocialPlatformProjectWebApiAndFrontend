<template>
    <div>
        <div>
            <h1 class="categories-h1">Fishing</h1>
            <Thread />
        </div>
    </div>
</template>

<script>
import Thread from '/src/components/Thread.vue'
import { useAuth0, AuthState } from '../../auth0/useAuth0.js'

export default {
    components: {
        Thread,
    },
    created() {
        this.GetThreads
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

</style>