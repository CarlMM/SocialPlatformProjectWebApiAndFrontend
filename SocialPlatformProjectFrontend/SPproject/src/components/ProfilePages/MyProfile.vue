8 lines (32 sloc) 941 Bytes
<template>

    <div class="outer-box">
        <div class="grid" v-if="AuthState.isAuthenticated">
            <div class="profile">
                <form class="profile-form">
                    <h2>Profile Page</h2>
                    <img :src="AuthState.user.picture" alt="AvatarPic" />
                    <h2>{{AuthState.user.nickname}}</h2>
                     <button class="btn-update"><span>Create New Post</span></button>
                    <!-- <div class="input">
                        <label for="nickname">Nickname</label>
                        <input type="text" v-model="AuthState.user.nickname" />
                    </div> -->
                    <div class="input">
                        <label for="email">Firstname</label>
                        <input type="text" v-model="AuthState.user.given_name" />
                    </div>
                    <div class="input">
                        <label for="email">Lastname</label>
                        <input type="text" v-model="AuthState.user.family_name" />
                    </div>
                    <div class="input">
                        <label for="email">Email</label>
                        <input type="text" v-model="AuthState.user.email" />
                    </div>
                    <div class="input">
                        <label for="email">Password</label>
                        <input type="password" placeholder="Password" />
                    </div>
                <button @click="consoleLogMyUser()" class="btn-update btn2">
                    <span class="text">Update Profile</span>
                </button>
                </form>
            </div>
            <div class="num-post">
                <h2>i has this many posts</h2>
                <h2>group posts</h2>
            </div>
            <div class="my-thread">

            </div>
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

.outer-box{
    background: #484848;
    box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
}

.grid{
    color:#ffff;
    display: grid;
    grid-template-columns: 30% 70%; 
    grid-template-rows: 100%;
    grid-column-gap: 5px;
}

.profile{
    background-color:#303030;
    display:flex;
}

.profile > form{
    padding: 10px 20px;
}

.profile > form > h2{
    display:flex;
    align-items: center;
    justify-content: space-around;
}

.profile > form > img{
    padding: 10px 10px;
    border-radius: 20%;
    height:30%;
    width: 100%;

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
    align-items: center;
    background-image: linear-gradient(144deg,#f1b306, #e73a0f 50%,#f38c06);
    border: 0;
    border-radius: 8px;
    /* box-shadow: rgba(250, 85, 8, 0.2) 0 15px 30px -5px; */
    box-sizing: border-box;
    color: #FFFFFF;
    display: flex;
    font-size: 14px;
    justify-content: center;
    line-height: 10px;
    max-width: 100%;
    min-width: 140px;
    padding: 3px;
    margin: 0 20px;
    text-decoration: none;
    user-select: none;
    -webkit-user-select: none;
    touch-action: manipulation;
    white-space: nowrap;
    cursor:pointer;
}

.btn-update:active,
.btn-update:hover{
    outline: 0;
}

.btn-update > span{
  background-color: rgb(5, 6, 45);
  padding: 16px 24px;
  border-radius: 6px;
  width: 100%;
  height: 100%;
  transition: 300ms;
}

.btn-update:hover span{
    background: none;
}

.btn2{
    margin-top: 25px;

}
</style>
