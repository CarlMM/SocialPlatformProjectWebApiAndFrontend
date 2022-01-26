<template>
  <header>
    <div class="navbar">
        <nav class="navigation">
            <ul class="nav-menu" v-for="categories in getCategories" :key="categories.Id">
              <li class="nav-item"><router-link :to="`/${categories.Title}/${categories.Id}`">{{ categories.Title }}</router-link></li>
                <!-- <li class="nav-item"><router-link to="/Studies/3">Studies</router-link></li>
                <li class="nav-item"><router-link to="/Fishing/2">Fishing</router-link></li>
                <li class="nav-item"><router-link to="/Computers/{{id}}">Computer</router-link></li> -->
            </ul>
        </nav>
    </div>
  </header>
</template>

<script>

export default{
  computed:{
    getCategories(){
      return this.$store.state.Category
    }
  }
}


// import Thread from './Thread.vue'

// export default {
//     components: {
//         Thread,
//     },
// }
</script>

<style scoped>
/*navbar*/

.header{
}

.navbar {
  margin: 20px;
  display:flex;
  align-items: center;
  background: #33393a;
}

.navigation{
  max-height: 12vh;
  margin-right: 10px;
}

.nav-menu{
  list-style-type: none;
  overflow: hidden;
}

ul{
  /* background: aquamarine; */
  width: 400px; 
	margin-left: auto; 
	margin-right: auto; 
}

li{
  
}

.nav-menu a{
  color: #fff;
} 

</style>