<template>
    <div>
        <div v-if="AuthState.isAuthenticated">
            <h1>My groupthreads</h1>
            <p>Loopa ut alla trådar som har användarens userId</p>
            <div v-for="threads in this.tomArray" :key="threads.Id">
               <h1>{{threads.Title}}</h1>
            </div>
        </div>
        <div v-else>
            <NotAuthantication />
        </div>
    </div>
</template>


<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'

const { login, logout, initAuth } = useAuth0(AuthState)

initAuth()
</script>

<script>

import NotAuthantication from '../../Views/NotAuthorized.vue'


export default {
    
    components: {
        NotAuthantication,
    },

    data(){
        return{
            tomArray:[],
        }
    },
     created(){
         this.tomArray = this.$store.state.GroupThreads;
     }
    // methods:{
    //     async fetchGroupThreads(){
    //         this.$store.dispatch('getAllThreadByUser',)
    //     }
    // }
    
}


</script>