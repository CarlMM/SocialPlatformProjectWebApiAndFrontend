<template>
  <main>
      <Navbar/>
      <div>
        <Category/>
        <!-- <div id="Thread-control">
          <Thread/>
        </div> -->
         <!-- <createPost /> -->
         <router-view />
      </div>
      <Footer/>
  </main>
</template>

<script>
import Navbar from './components/Navbar.vue'
import Category from './components/Category.vue'
import Footer from './components/Footer.vue'
import Thread from './components/Thread.vue'
import createPost from './components/CreatePost.vue'


export default{
  name: "App",
  components: {
  createPost,
    Navbar,
    Category,
    Thread,
    Footer,
  },
}

</script>


<style>


</style>