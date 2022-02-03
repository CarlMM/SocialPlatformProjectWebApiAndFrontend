<template>
    <div>
        <div>
            <Thread :list="GetThreads"/>
        </div>
    </div>
</template>


<script>
import Thread from '/src/components/Thread.vue'

export default{
 
  components: {
    Thread,
  },

  data(){
    return{
      idFromUrl: this.$route.params
    }
  },

  created(){
    // console.log(this.idFromUrl)
    // this.$store.dispatch('getThreadsByCategoryId')
  },

  computed:{
    GetThreads() {
      // // console.log(this.$route.params)
      // // console.log(this.idFromUrl)
            let list = this.$store.state.Thread

            let filterlist = list.filter(item => {
                return item.categoryId == this.cId
            })
            console.log(filterlist)
            return filterlist
        },
  }
}

</script>
