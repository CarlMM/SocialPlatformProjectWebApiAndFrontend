<template>
    <div>
        <h1>POST YO</h1>
    </div>
    <div v-for="thread in getSpecificThread" :key="thread.Id">
        {{thread.Title}}
    </div>
</template>

<script>


export default{
 
  data(){
      return{
          tId: this.$route.params.Id
      }
  },


  computed:{
      getSpecificThread(){
          let list = this.$store.state.Thread;
          console.log(this.tId)

          let filteredThread = list.filter(
              (item)=>{
                  return item.Id == this.tId;
              }
          );
          console.log(filteredThread)
          return filteredThread;
      }
  }

}
</script>


