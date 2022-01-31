<template>
<div id="test">
    <div class="category">
      <div class="category-title" >
        <Thread/>
     </div >
     <div v-for="threads in fetchAllThreads" :key="threads.id">
       <h1>{{threads.title}}</h1>
     </div>
    </div>
</div>
          
</template>

<script>
  import Thread from '/src/components/Thread.vue'

  export default{
 
  components: {
    Thread,
  },

    created(){
    this.fetchThreads();
  },

   methods:{
     async fetchThreads(){
       this.$store.dispatch('getAllThreads')
     }
    
  },


  computed:{
    GetAllThreads(){
      return this.$store.state.Thread
    },
    GetAllCategories(){
      return this.$store.state.Category
    },
    fetchAllThreads(){
      return this.$store.state.Thread
    }
  }

}
</script>

<style scoped>
/*temporary? for pushing down */
#test{
  height: 200vh;
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