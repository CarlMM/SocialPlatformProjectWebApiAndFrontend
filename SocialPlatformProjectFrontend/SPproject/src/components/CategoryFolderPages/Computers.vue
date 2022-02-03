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

  computed:{
    GetThreads() {
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
