<template>
  <div class="bodyDiv">
      
        <div class="forumDiv" v-for="thread in getPost" :key="thread.id">
            <h1>{{thread.title}}</h1>
                
                    <p>{{ thread.text }}</p>
                    <p>{{ thread.id }}</p>
                
                <div v-for="item in getReplies" :key="item.id">
                    {{ item.id }}
                    <!-- {{ item.categoryThreadId }} -->
                    <p>{{ item.text }}</p>
                </div>
        </div>
        
        <div class="userInListDiv">
            <div class="diplayUsersInListDiv" >
                <!-- Exempel hur userlistan kan se ut -->
                <p id="userNamesInThread" v-for="threads in GetThreads" :key="threads.Id">
                    {{threads.title}}

                    <!-- Lägg till userId i removeMetoden -->
                    <button @click="removeUserFromThreadButton()">Ta bort</button>
                </p>

            </div>
            <button @click="addUserButton()">Add user to Thread</button>
        </div>

      
  </div>
</template>


<script>
export default {
    data(){
        return{
            pId: this.$route.params.id,
        }
    },

    created(){
        console.log(this.pId);
        this.$store.dispatch('GetThreadFromSpecificId', this.pId);
        //this.$store.dispatch('GetRepliesForSpecificPost', this.pId)
        //this.$store.dispatch('getAllThreads')
    },

    methods:{
        addUserButton(){
            alert('Tjofräs')
        },
        removeUserFromThreadButton(){
            alert('Tjoflöjt')
        }

    },
    computed:{
        GetThreads(){
            return this.$store.state.Thread
        },
        getPost(){
            console.log('getPostmetod i Post.vue: ', this.$store.state.SpecificPostThread)

            return this.$store.state.SpecificPostThread;
        },
        getReplies() {
            return this.$store.state.Reply
        },
    }
}
</script>

<style scoped>

.bodyDiv{
    display: flex;
    color:#ffff;
}
.forumDiv{
    float:left;
    text-align: center;
}
/* .userInListDiv{
    
} */

.diplayUsersInListDiv{
    border-style: solid;
    border-width: thin;
    text-align: left;
    overflow: auto;
    width: 400px;
    height: 200px;
}


#userNamesInThread{
    font-weight: bold;
}
</style>