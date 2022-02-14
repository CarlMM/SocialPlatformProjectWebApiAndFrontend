8 lines (32 sloc) 941 Bytes
<template>
    <div class="outer-box">
        <div class="grid" v-if="AuthState.isAuthenticated">
            <div class="profile">
                <form class="profile-form">
                    <h2 >Profile Page</h2>
                    <h3>LÄHETÄ SÄHKÖPOSTI ASIAKASTUKIIN, JOS HALUAT POISTAA PROFIILIN :)</h3>
                    <img :src="AuthState.user.picture" alt="AvatarPic" />
                    <h2 class="profile-h2">{{AuthState.user.nickname}}</h2>
                     <button class="btn-all btn2"><span>Create New Post</span></button>
                    <div class="input">
                        <label for="nickname">Username</label>
                        <input class="input_field" type="text" v-model="AuthState.user.nickname" />
                    </div>
                    <div class="input">
                        <label for="email">Firstname</label>
                        <input class="input_field" type="text" v-model="AuthState.user.given_name" />
                    </div>
                    <div class="input">
                        <label for="email">Lastname</label>
                        <input class="input_field" type="text" v-model="AuthState.user.family_name" />
                    </div>
                    <div class="input">
                        <label for="email">Email</label>
                        <input class="input_field" type="text" v-model="AuthState.user.email" />
                    </div>
                    <div class="input">
                        <label for="email">Password</label>
                        <input class="input_field" type="password" placeholder="Password" />
                    </div>
                <button @click="consoleLogMyUser()" class="btn-all btn2">
                    <span class="btn-text">Update Profile</span>
                </button>
                </form>
            </div>
            <div class="num-post">
                <div class="amount-text">
                    <h2>Posts: 0</h2>
                    <h2>GroupPosts: 0</h2>
                </div>
                <div class="overflow">
                    <div class="user-threads element" v-for="userThreads in this.$store.state.UserThread" :key="userThreads.id">
                        <div class="threads">
                            <router-link type="button" :to="`/Post/${userThreads.id}`">
                                <h1 >{{ userThreads.title }}</h1>
                                <p class="thread-text">{{userThreads.text}}</p>
                            </router-link>
                    </div>
                </div>
            </div>
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
    data(){
        return{
            userThreadList: [],
        }
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
        fetchAllUserThreads() {
            this.$store.dispatch('GetThreadsFromUser', this.AuthState.user.sub)
        },
    },
    beforeMount() {
        this.fetchAllUserThreads()
    },

    created() {
        this.fetchAllUserThreads()
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

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'
const { login, logout, initAuth } = useAuth0(AuthState)
initAuth()
</script>

<style scoped>

.grid{
    color:#ffff;
    display: grid;
    grid-template-columns: 20% 80%; 
    grid-template-rows: 100%;
    grid-column-gap: 5px;
}
.profile{
    background-color:#303030;
    display:flex;
    border-radius: 4px;
}
.profile-form{
    padding: 10px 30px;
    display:grid;
    position:relative;
}

.profile-form  input{
    padding: 5px 0;
    width: 100%;
}

.profile-form > h2{
    display:flex;
    align-items: center;
    justify-content: space-around;
    font-size: 24px;
}
.profile-form > img{
    border-radius: 20px;
    width: 100%;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.profile-h2{
    padding-top:10px;
}

.num-post{
    
}

.amount-text{
    display:flex;
    align-content: center;
    justify-content: space-around;
}

.amount-text > h2{
    font-size: 24px;
    padding: 20px 0;
}

/*buttons */

.btn-all{
    padding: 10px 20px;
}

.btn2{
    margin-top: 5px;
}

/* Css for threads in profile*/
.overflow{
    overflow:auto;
    max-height:80vh;
    max-width:72.3vw;
}

.user-threads{
    max-width: 72.3vw;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    background: #1d1d1d;
    padding: 1px 0;
}

.threads{
    border-radius: 2px;
    background:#656a83;
    padding: 20px 10px;
}

.threads > a >h1{
    font-size: 24px;
    font-weight: 600;
}

.thread-text{
    font-size: 16px;
    padding:0;
    margin:0;
}

</style>
