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
@import url('https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,300;1,300&display=swap');

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


/*Threads outer glow */

.element {
    box-shadow: none;
}

.element:hover,
element:active {
    box-shadow: 0 0 5px #fff, inset 0 0 10px #43a78c;
}


/*Buttons for threads + posts */
.post-btn {
    padding: 0 15px;
    background: inherit;
    color: #ffff;
    border: none;
    user-select: none;
    white-space: nowrap;
    transition: all 0.05s linear;
    font-family: inherit;
}

.post-btn:active {
    color: #3f99e7;
    box-shadow: 0 0.2rem #3f99e7;
    transform: translateY(0.2rem);
}

.post-btn:disabled {
    cursor: auto;
    color: grey;
}

.icon {
    font-size: 20px;
    margin-right: 10px;
}

/* Style for scrollbar */
body::-webkit-scrollbar {
  width: 15px; 
}

body::-webkit-scrollbar-track {
  background: rgb(58, 58, 58);
  border: 1px solid grey; 
}

body::-webkit-scrollbar-thumb {
  background-color: rgb(255, 255, 255);
  border-radius: 5px;
}

body::-webkit-scrollbar-thumb:hover{
    background:rgb(202, 209, 218);
}

/*Overflow scrollbar */
::-webkit-scrollbar {
    width: 15px;
}

::-webkit-scrollbar-track {
    box-shadow: inset 0 0 3px rgb(170, 170, 170); 
}

::-webkit-scrollbar-thumb {
    background:rgb(255, 255, 255);
    border-radius: 5px;
}

::-webkit-scrollbar-thumb:hover {
    background:rgb(202, 209, 218); 
} 

</style>
