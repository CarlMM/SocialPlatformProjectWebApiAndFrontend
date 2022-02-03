<template>
        <Navbar />
     <div class="test">
        <Category />
        <router-view />
    </div>
        <Footer />
</template>

<script>
import Navbar from './components/Navbar.vue'
import Category from './components/Category.vue'
import Footer from './components/Footer.vue'
import Thread from './components/Thread.vue'

export default {
    name: 'App',
    components: {
        Navbar,
        Category,
        Thread,
        Footer,
    },
    
}
</script>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

.app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.test{
  padding: 20px 60px;
}

html > body{
    background-color: rgb(36, 36, 36);
}


</style>
