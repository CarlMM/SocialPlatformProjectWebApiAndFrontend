<template>
    <div>
        <h1>My groupthreads</h1>
        <p>Loopa ut alla trådar som har användarens userId</p>
        <div v-for="threads in this.tomArray" :key="threads.Id">
           <h1>{{threads.Title}}</h1>
        </div>
    </div>
</template>


<script>




export default {


    data(){
        return{
            tomArray:[],
        }
    },
     created(){
         this.tomArray = this.$store.state.GroupThreads;
     }
    // methods:{
    //     async fetchGroupThreads(){
    //         this.$store.dispatch('getAllThreadByUser',)
    //     }
    // }
    
}


</script>