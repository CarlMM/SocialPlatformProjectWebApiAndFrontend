<template>
<div id="test">
    <div class="category">
      <div class="category-title">
        <h1>Category One</h1>
     </div>
        <Thread/>
    </div>
    <!-- <div class="category">
      <div class="category-title">
        <h1>Category Two</h1>
     </div>
    </div>
    <div class="category">
      <div class="category-title">
        <h1>Category Three</h1>
     </div>
    </div> -->
</div>
          
</template>

<script>
  import Thread from '/src/components/Thread.vue'

  export default{
 
  components: {
    Thread,
  },
}
</script>

<style scoped>
/*temporary? for pushing down */
#test{
  height: 100vh;
}

.category{
   margin-top: 20px;
}

.category-title{
    background-color:rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 20px;
    margin-bottom:20px;
    /* text-align: center; */
}
</style>