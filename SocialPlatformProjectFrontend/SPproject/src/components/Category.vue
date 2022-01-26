<template>
  <header>
    <div class="navbar">
      <nav class="navigation">
        <ul class="nav-menu" v-for="categories in getCategories" :key="categories.Id">
          <li class="nav-item"><router-link :to="`/${categories.Title}/${categories.Id}`">{{ categories.Title }}</router-link></li>
        </ul>
      </nav>
      
        <!-- <nav class="navigation">
            <ul class="nav-menu">
                <li class="nav-item"><router-link to="/Studies/3">Studies</router-link></li>
                <li class="nav-item"><router-link to="/Fishing/2">Fishing</router-link></li>
                <li class="nav-item"><router-link to="/Computers/{{id}}">Computer</router-link></li>
            </ul>
        </nav> -->
        <!-- <div class="Thread-position">
            <Thread/>
        </div> -->
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
   margin-inline: 10px;
}

.navbar {
  margin: 20px;
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
  margin-inline: 30px;
  font-size: 25px;
  padding: 10px;
  color: #fff;
}

.Thread-position{
}


</style>