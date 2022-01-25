<template>
  <main>
      <Navbar/>
      <div>
        <Category/>
      </div>
      <Footer/>
  </main>
</template>

<script>
import Navbar from './components/Navbar.vue'
import Category from './components/Category.vue'
import Footer from './components/Footer.vue'

export default{
  name: "App",
  components: {
    Navbar,
    Category,
    Footer,
  },
}

</script>


<style>


</style>
