<template>
  <header>
    <div class="navbar">
        <nav class="navigation">
            <ul class="nav-menu">
                <li class="nav-item"><router-link to="/Computer">Computer</router-link></li>
            <li class="nav-item"><router-link to="/Fishing">Fishing</router-link></li>
                <li class="nav-item"><router-link to="/Studies">Studies</router-link></li>
            </ul>
        </nav>
        <div class="Thread-position">
            <Thread/>
        </div>
    </div>
  </header>
</template>

<script>
import Thread from './Thread.vue'

export default {
    components: {
        Thread,
    },
}
</script>

<style scoped>
/*navbar*/

.header{
   margin-inline: 10px;
}

.navbar {
  margin: 10px;
  display:flex;
  align-items: center;
  background: #33393a;
}

.navigation{
  padding: 10px;
  width: 65%;
  display: inline-block;
  max-height: 12vh;
  margin-right: 10px;
}

.nav-menu{
  list-style-type: none;
  overflow: hidden;
}

.nav-menu a{
  float:right;
  display:block;
  text-align:center;
  margin-inline: 20px;
  font-size: 20px;
  padding: 10px;
  color: #fff;
}

/* Nav Meu Styling */
/* .nav-menu a {
  padding: 0 8px 0px 8px;
  text-decoration: none;
  display: inline-block;
  color: rgb(255, 255, 255);
  font-weight: bolder;
  font-size: 20px;
  text-transform: uppercase;
  outline: none;
} */


/* .nav-menu ul {
  margin: 22px 0 0 0;
  padding: 0;
  box-shadow: 0px 0px 30px rgba(127, 137, 161, 0.25);
  background: rgb(141, 17, 17);
} */

/* .nav-menu > li {
  display: inline-block;
}

.nav-menu > li > a{
    display:block;
    padding: 20px 15px;
    text-align: center;
}

.nav-menu li:hover > a {
  color: #ac5317;
} */


</style>