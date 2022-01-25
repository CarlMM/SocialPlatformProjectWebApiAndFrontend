<template>
  <main>
      <Navbar/>
      <div>
        <Category/>
        <div id="Thread-control">
          <Thread/>
        </div>
      </div>
      <Footer/>
  </main>
</template>

<script>
import Navbar from './components/Navbar.vue'
import Category from './components/Category.vue'
import Footer from './components/Footer.vue'
import Thread from './components/Thread.vue'


export default{
  name: "App",
  components: {
    Navbar,
    Category,
    Thread,
    Footer,
  },
}

</script>


<style>

#Thread-control{
}

</style>
