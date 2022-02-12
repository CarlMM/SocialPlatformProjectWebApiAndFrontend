<template>
    <header id="header">
        <div class="header-top">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-6 col-sm-6 col-6 header-top-left">
                        <div id="logo">
                            <router-link to="/">
                                <p id="companyLogo">FOR-SCIENCE Forum</p>
                            </router-link>
                        </div>
                    </div>
                    <div class="col-lg-6 col-sm-6 col- header-top-right">
                        <div class="nav-menu">
                            <div class="authDiv">
                                <div v-if="!AuthState.loading">
                                    <div v-if="!AuthState.isAuthenticated">
                                        <a href="#" @click.prevent="login()"
                                            >Log in - Register</a>
                                    </div>
                                    <div v-else>
                                        <div class="logged-in">
                                            <p>
                                                User:
                                                {{ AuthState.user.nickname }}
                                                <!-- authstate.user.sub = user token (id) -->
                                                <img
                                                    :src="
                                                        AuthState.user.picture
                                                    "
                                                    alt="AvatarPic"
                                                />
                                                <select
                                                    class="dropdown-nav"
                                                    @change="
                                                        changeRoute($event)
                                                    "
                                                >
                                                    <option selected value="">
                                                        Home
                                                    </option>
                                                    <option value="MyProfile">
                                                        Profile
                                                    </option>
                                                    <option value="MyGroups">
                                                        My Groups
                                                    </option>
                                                    <option value="MyThreads">
                                                        My Threads
                                                    </option>
                                                    <option value="MyReplies">
                                                        My Replies
                                                    </option>
                                                </select>

                                                <a
                                                    href="#"
                                                    @click.prevent="logout()"
                                                    >Logout</a
                                                >
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div v-else>Loading ...</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>
</template>
<script>
import Dropdown from './Dropdown.vue'

export default {
    data() {
        return {
            userToSend: {
                idSub: '',
                username: '',
                email: '',
            },
        }
    },
    methods: {
        changeRoute(e) {
            this.$router.push('/' + e.target.value)
        },
    },
}
</script>

<script setup>
import { useAuth0, AuthState } from '../auth0/useAuth0.js'

const { login, logout, initAuth } = useAuth0(AuthState)

initAuth()
</script>

<style scoped>
.logged-in > p > img {
    height: 100%;
    width: 80px;
    margin: 20px;
    border-radius: 20%;
}
img {
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
#user {
    color: #2576e0;
    padding-right: 25px;
}
#nav-menu-container {
    display: inline-block;
    padding-top: 10px;
}

#companyLogo{
    display:flex;
    font-size:40px;
    padding-top: 15px;
    z-index:99;
}

a {
    -webkit-transition: all 0.3s ease 0s;
    -moz-transition: all 0.3s ease 0s;
    -o-transition: all 0.3s ease 0s;
    transition: all 0.3s ease 0s;
}

p {
    font-size: 18px;
    font-weight: 600;
    color: #fff;
}

i {
    font-size: 18px;
    font-weight: bolder;
    color: #fff;
}
/*Header*/
#header{
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.header-top {
    font-size: 12px;
    background-color: #33393a;
}
.header-top a {
    color: rgb(255, 255, 255);
    -webkit-transition: all 0.3s ease 0s;
    -moz-transition: all 0.3s ease 0s;
    -o-transition: all 0.3s ease 0s;
    transition: all 0.3s ease 0s;
}
.header-top a:hover {
    color: #2576e0;
}
.header-top .header-top-left a {
    margin-right: 8px;
}
.header-top .header-top-right {
    text-align: right;
}
.header-top .header-top-right .header-social a {
    color: #fff;
    margin-left: 15px;
    -webkit-transition: all 0.3s ease 0s;
    -moz-transition: all 0.3s ease 0s;
    -o-transition: all 0.3s ease 0s;
    transition: all 0.3s ease 0s;
}
.header-top .header-top-right .header-social a:hover {
    color: #1a4e92;
}
.main-menu {
    padding-top: 10px;
    background: #33393a;
    padding-left: 15px;
    padding-right: 15px;
    border-bottom: solid 2px;
    border-color: black;
}
/*--------------------------------------------------------------
# Navigation Menu
--------------------------------------------------------------*/
/* Nav Menu Essentials */
.nav-menu,
.nav-menu * {
    margin: 0;
    padding: 0;
    list-style: none;
}
/* Nav Meu Styling */
.nav-menu a {
    padding: 0 8px 0px 8px;
    text-decoration: none;
    display: inline-block;
    color: #fff;
    font-weight: 500;
    font-size: 12px;
    text-transform: uppercase;
    outline: none;
}
</style>
