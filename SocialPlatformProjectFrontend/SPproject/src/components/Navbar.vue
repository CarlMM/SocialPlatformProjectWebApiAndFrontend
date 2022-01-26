<template>

<header id="header">
  <div class="header-top">
      <div class="container">
          <div class="row align-items-center">
              <div class="col-lg-6 col-sm-6 col-6 header-top-left"> 
                  <div id="logo">
                        <router-link to="/">
                          <img src="/src/assets/Group_2.jpg" alt="" title="" height="110" />
                        </router-link>
                      </div>
              </div>
              <div class="col-lg-6 col-sm-6 col- header-top-right">
                <div class="nav-menu">
                      <div class="authDiv">
                          <div v-if="!AuthState.loading">
                              <div v-if="!AuthState.isAuthenticated">
                                  <a href="" @click="Login()">Logged in</a>
                              </div>
                              <div v-else>
                                  <div>
                                      <p>{{AuthState.user.nickname}}
                                        <img :src="AuthState.user.picture" alt="AvatarPic">
                                        <a href="" @click="Logout()" >Logout</a>
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
  <!-- <header id="header">
    <div class="header-top">
      <div class="container">
        <div class="row align-items-center">
          <div>

          </div>
          <div id="logo">
            <router-link to="/">
            <p>
              <img src="/src/assets/Group_2.jpg" alt="" title="" height="110" />
              Group 2 Inc
            </p>
            </router-link>
          </div>
            <div class="authDiv">
              <div v-if="!AuthState.loading">
                <div v-if="!AuthState.isAuthenticated">
                  <button @click="login()" class="btn btn-primary">Login</button>
                </div>

                <div v-else>
                  <div>
                    <div>
                      <p>
                      Hello <strong>{{AuthState.user.nickname}}!</strong>
                      <img :src="AuthState.user.picture" id="avatarPic">
                      </p>
                    </div>
                    <div>
                    <button @click="logout()" class="btn btn-secondary">Logout</button>
                    </div>
                  </div>
                </div>
              </div>

              <div v-else>Loading ...</div>
            </div>
        </div>
        </div>
      </div>
  </header> -->
</template>



<script>
export default {
   data() {
     return {
       listOne: false,
     };
  },
};
</script>

<script setup>
import { useAuth0, AuthState } from "../auth0/useAuth0.js";

const { login, logout, initAuth } = useAuth0(AuthState);

initAuth();


</script>



<style scoped>
 #user{
  color:rgb(255, 153, 0);
  padding-right:25px;
}

#nav-menu-container{
  display:inline-block;
  padding-top:10px;
}

a {
  -webkit-transition: all 0.3s ease 0s;
  -moz-transition: all 0.3s ease 0s;
  -o-transition: all 0.3s ease 0s;
  transition: all 0.3s ease 0s;
}

p{
  font-size: 18px;
  font-weight: bolder;
  color:#fff;
}

i {
  font-size: 18px;
  font-weight: bolder;
  color:#fff;
}


/*Header*/
.header-top {
  font-size: 12px;
  padding: 6px 0px;
  background-color:#33393a;
}

.header-top a {
  color: rgb(255, 255, 255);
  -webkit-transition: all 0.3s ease 0s;
  -moz-transition: all 0.3s ease 0s;
  -o-transition: all 0.3s ease 0s;
  transition: all 0.3s ease 0s;
}

.header-top a:hover {
  color: #ff9900;
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
  color: #ff7b00;
}

.main-menu {
  padding-top: 10px;
  background: #33393a;
  padding-left: 15px;
  padding-right: 15px;
  border-bottom:solid 2px;
  border-color:black;
}

/*--------------------------------------------------------------
# Navigation Menu
--------------------------------------------------------------*/
/* Nav Menu Essentials */
.nav-menu, .nav-menu * {
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