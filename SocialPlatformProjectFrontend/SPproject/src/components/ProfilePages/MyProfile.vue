8 lines (32 sloc) 941 Bytes
<template>
    <div class="outer-box">
        <div class="grid" v-if="AuthState.isAuthenticated">
            <div class="profile">
                <h1>My profile</h1>
                <p>Loopa ut användarens data, så som nickname email osv?</p>
                <form>
                    <img :src="AuthState.user.picture" alt="AvatarPic" />
                    <div class="input">
                        <label for="nickname">Nickname</label>
                        <input type="text" v-model="AuthState.user.nickname" />
                    </div>
                    <div class="input">
                        <label for="email">firstname</label>
                        <input type="text" v-model="AuthState.user.given_name" />
                    </div>
                    <div class="input">
                        <label for="email">lastname</label>
                        <input type="text" v-model="AuthState.user.family_name" />
                    </div>
                    <div class="input">
                        <label for="email">Email</label>
                        <input type="text" v-model="AuthState.user.email" />
                    </div>
                    <div class="input">
                        <label for="email">password</label>
                        <input type="password" placeholder="Password" />
                    </div>
                </form>
                <button @click="consoleLogMyUser()" class="btn-update">Update Profile</button>
            </div>
            <div class="num-post">
                <h2>i has this many posts</h2>
                <h2>group posts</h2>
            </div>
        </div>
            <div v-else>
                <!-- <h1>UR NOT AUTHONTICATED add v-else later</h1> -->
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
    methods:{
        consoleLogMyUser(){
            //var accessTokenObj = localStorage.getItem('access_token');
            
            console.log('accesstoken: ', localStorage.getItem('access_token'));

            //__raw = token?
            // console.log(AuthState.claims.__raw)
            // this.$store.commit('setToken', AuthState.claims.__raw)
            // console.log(AuthState.user)
            // console.log('statetoken: ', this.$store.state.token)
            //commit('setToken')
        }
    }
}
</script>

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'
const { login, logout, initAuth } = useAuth0(AuthState)
initAuth()
</script>

<style scoped>

.outer-box{
    background: #484848;
    box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
}

.grid{
    color:#ffff;
    display: grid;
    grid-template-columns: 60% 40%; 
    grid-template-rows: 100%;
    grid-column-gap: 5px;
}

.profile{
    background-color:#303030;
}

.input {
    margin: 16px 0;
    width: 100%;
    border: none;
    padding: 8px;
    height: 50px;
}

.input > label{
    font-size: 14px;
    display: block;
    padding-bottom: 6px;
}

.num-post{

}

.btn-update{
    padding: 6px;
}

</style>