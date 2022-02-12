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

/* Mythreads, MyReplies */
.myThreads{
    border-radius: 4px;
    background-color:#4b4b4b;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.myThreads > h1{
    font-family: 'Roboto', sans-serif;
    font-size: 24px;
    padding: 20px 0;
    margin: 0 20px;
}

.user-threads{
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    background: #1d1d1d;
    padding: 1px 0;
}

.threads{
    border-radius: 2px;
    background:#656a83;
    padding: 20px 10px;
}

.threads > a >h1{
    font-size: 24px;
    font-weight: 600;
}

.thread-text{
    font-size: 16px;
    padding:0;
    margin:0;
}

/* Posts + adminposts*/

.post-h1 {
    padding-top:10px;
    font-size: 18px;
    font-weight: bolder;
    color: white;
}
.post-text {
    margin-left: 5px;
    margin-top: 20px;
}
/*Body*/
.outer-box {
    border-radius: 5px;
    padding: 10px 10px;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}
.main-post {
    padding: 10px 10px;
    background-color:#1d1d1d;
    border-top-left-radius: 4px;
    border-top-right-radius: 4px;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.main-text{
    margin: -5px 10px;
    padding-bottom: 30px;
}

.post-user{
    font-size: 14px;
}


.post-andReply {
    padding-top: 1px;
    padding-right: 5px;
    color:#fff;
}
.replies{
   margin: 10px 10px;
   padding: 6px 10px;
   border-bottom: 1px rgb(65, 75, 109) solid;
}

.reply-text{
    padding-top:10px;
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
