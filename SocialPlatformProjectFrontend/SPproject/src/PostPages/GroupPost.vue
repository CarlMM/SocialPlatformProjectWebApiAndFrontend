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
            <div class="diplayUsersInListDiv">
                Username, Username, Username, Username, Username, Username, Username,
                Username, Username, Username, Username, Username, Username, Username,
                Username
                <!-- Lägg till removeknapp bredvid varje user när vi loopar ut -->
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

    methods:{
        addUserButton(){
            alert('Tjofräs')
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
.userInListDiv{
    
}

.diplayUsersInListDiv{
    border-style: solid;
    border-width: thin;
    text-align: left;
}
</style>