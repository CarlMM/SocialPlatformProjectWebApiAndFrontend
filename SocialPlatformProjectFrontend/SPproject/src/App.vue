<template>
  <main>
      <Navbar/>
      <div>
       <Body/>
      </div>
    
  </main>
</template>

<script>
import Navbar from './components/Navbar.vue'
import Body from './components/Body.vue'

export default{
  name: "App",
  components: {
    Navbar,
    Body,
  },
}

</script>


<style>

</style>
