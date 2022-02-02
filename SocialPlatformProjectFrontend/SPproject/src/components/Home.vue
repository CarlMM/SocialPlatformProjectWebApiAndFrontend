<template>
<div>
        <Thread/>
        <!-- :post="thread" v-for="(thread, index) in GetAllThreads" :key="index" -->
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
      const result = this.$store.state.Thread
      console.log('Get All Threads', result)
      return result
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