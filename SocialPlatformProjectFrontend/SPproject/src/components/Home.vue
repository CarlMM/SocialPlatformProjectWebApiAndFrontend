<template>
    <div class="side-by-side">
        <Thread :list="GetAllThreads" />
        <!-- :post="thread" v-for="(thread, index) in GetAllThreads" :key="index" -->
    </div>
    <!-- <div class="side-by-side">
        <h2>random text</h2>
    </div> -->
</template>

<script>
import Thread from '/src/components/Thread.vue'
import { useAuth0, AuthState } from '../auth0/useAuth0.js'

const { initAuth } = useAuth0(AuthState)

export default {
    components: {
        Thread,
    },
    data() {
        return {
            userToSend: {
                idSub: '',
                username: '',
                email: '',
            },
        }
    },

    mounted() {
        if (AuthState.isAuthenticated == true) {
            if (
                AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
            ) {
                this.$store.state.isAdmin = true
            }
        }
    },
    created() {
        if (AuthState.isAuthenticated == true) {
            this.userToSend.idSub = AuthState.user.sub
            this.userToSend.username = AuthState.user.nickname
            this.userToSend.email = AuthState.user.email
            console.log('Inne i created', this.userToSend)
            this.$store.dispatch('CreateUserToDatabase', this.userToSend)
        }
    },

    computed: {
        GetAllThreads() {
            const result = this.$store.state.Thread
            console.log('Get All Threads', result)
            return result
        },
    },
}
</script>

<style scoped>
h2 {
    color: white;
}

/* .category{
   margin-top: 20px;
}

.category-title{
    background-color:rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 20px;
    margin-bottom:20px;
    text-align: center; 
} */

/* .test {
        display: grid;
        grid-template-columns: 80% 20%; 
        grid-template-rows: 99%;
        grid-column-gap: 5px;
      }
      
      .side-by-side {
      background: #ce8888;
 
       
      } */
</style>
