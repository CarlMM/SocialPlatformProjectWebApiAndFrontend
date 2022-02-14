<template>
    <div>
        <div>
            <h1 class="categories-h1">Computer</h1>
            <Thread :list="GetThreads" />
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

    data() {
        return {
            idFromUrl: this.$route.params,
        }
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

    // created(){
    // console.log(this.idFromUrl)
    // this.$store.dispatch('getThreadsByCategoryId')
    // },

    computed: {
        GetThreads() {
            let list = this.$store.state.Thread

            let filterlist = list.filter(item => {
                return item.categoryId == this.cId
            })
            console.log(filterlist)
            return filterlist
        },
    },
}
</script>



<style scoped>

</style>
