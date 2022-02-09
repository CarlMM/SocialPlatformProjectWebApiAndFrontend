<template>
  <div class="bodyDiv">
      
        <div class="forumDiv">
            <h1>ThreadTitle</h1>
                <p>
                    ThreadText Lorem ipsum dolor sit amet consectetur adipisicing elit. Quibusdam beatae
                    inventore natus eius, ipsum culpa praesentium quam libero at debitis
                    dolores, repudiandae molestiae dicta nulla a, assumenda fugit
                    necessitatibus! Sint?
                </p>
                <div>
                    Här ska vi loopa ut diverse replies tänker jag
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

        }
    },

    created(){
        this.$store.dispatch('getAllThreads')
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
        }
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