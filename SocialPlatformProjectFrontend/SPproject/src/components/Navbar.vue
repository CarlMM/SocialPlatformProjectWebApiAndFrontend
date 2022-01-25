<template>
      <header id="header">
            <div class="header-top">
					    <div class="container">
			  		    <div class="row align-items-center">
			  			    <div class="col-lg-6 col-sm-6 col-6 header-top-left">
                    <div id="logo">
                        <router-link to="/"><img src="/src/assets/Group_2.jpg" alt="" title="" ></router-link>
                    </div>
			  			    </div>
			  			      <div class="col-lg-6 col-sm-6 col- header-top-right">
							        <div class="nav-menu">
                        <div v-if="!loggedIn">
                            <a href="#"><router-link to="/registration">Register</router-link></a>
                            <a href=""><router-link to="/login">Log in</router-link></a>
                        </div>
                        <div v-if="loggedIn">
                          <a  href="" @click="logout()">Log out</a>
                          <a  href=""><router-link to="/Profile">Profile</router-link></a>
                        </div>
						          	</div>
                        <div id="user" v-if="loggedIn">
                          <ul>
                              <li ><a>{{user.email}}</a></li>
                         </ul>
                    </div>
			  			</div>
			  		</div>			  					
					</div>
				</div>
      </header>
</template>

<script>
// import { defineComponent } from '@vue/composition-api'

// export default defineComponent({
//     setup() {
        
//     },
// })
</script>



<style scoped>

img {
    height: 100px;
}

#user{
  color:rgb(204, 133, 52);
  padding-right:25px;
}

nav#nav-menu-container{
  display:inline-block;
  padding-top:10px;
}

ol, ul {
  margin: 0;
  padding: 0;
  list-style: none;
}

select {
  display: block;
}

figure {
  margin: 0;
}

a {
  -webkit-transition: all 0.3s ease 0s;
  -moz-transition: all 0.3s ease 0s;
  -o-transition: all 0.3s ease 0s;
  transition: all 0.3s ease 0s;
}

/*Header*/

.header-top {
  font-size: 12px;
  padding: 6px 0px;
  background-color: rgb(71, 71, 71);
}

.header-top a {
  color: rgb(255, 255, 255);
  -webkit-transition: all 0.3s ease 0s;
  -moz-transition: all 0.3s ease 0s;
  -o-transition: all 0.3s ease 0s;
  transition: all 0.3s ease 0s;
}

.header-top a:hover {
  color: #b16b2b;
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
  color: #b16b2b;
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


.nav-menu li:hover > a {
  color: #aa4821;
}

.nav-menu > li {
  margin-left: 4px;
}

.nav-menu ul {
  margin: 22px 0 0 0;
  padding: 10px;
  box-shadow: 0px 0px 30px rgba(127, 137, 161, 0.25);
  background: #fff;
}

.nav-menu ul li {
  transition: 0.3s;
}

.nav-menu ul li a {
  padding: 5px 10px;
  color: #333;
  transition: 0.3s;
  display: block;
  font-size: 12px;
  text-transform: none;
}

.nav-menu ul li:hover > a {
  color: #b16b2b;
}

.nav-menu ul ul {
  margin-right: 10px;
  margin-top: 0;
}

</style>