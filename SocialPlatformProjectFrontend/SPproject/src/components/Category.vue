<template>
<div>
  <header class="header">
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
  <div class="create-post">
     <!-- <a href=""></a> -->
     <img src="/src/assets/Group_2.jpg" alt="">
     <input class="create-input" type="text" name="createPost" placeholder="Create Post">
  </div>
</div>
</template>

<script>

export default{
  computed:{
    getCategories(){
      return this.$store.state.Category
    }
  }
}

</script>

<style scoped>


.header{
  margin: 20px;
  display:flex;
  align-items: center;
  background: #33393a;
  border-radius: 5px;
}
.navbar {
 
}

.nav-menu a{
  color: #fff;
} 

.navigation{
  max-height: 12vh;
  margin-right: 10px;
}

.nav-menu{
  list-style-type: none;
  overflow: hidden;
}
/* 
.btn{
  display:inline-block;
  background: rgb(129, 129, 129);
  color: white;
} */

/*Create Post */
.create-post{
  padding: 15px;
  margin: 20px;
  background:#33393a;
  border-radius: 5px;
  display:flex;
  justify-content: space-around;
}

.create-post > img{
  width: 3.5vw;
  margin-right:15px;
}

.create-post > input{
  width: 100%;
  border-radius: 5px;
  background-color:rgb(160, 160, 160);
}

.input:hover{
  border: 1px solid white;
}


</style>