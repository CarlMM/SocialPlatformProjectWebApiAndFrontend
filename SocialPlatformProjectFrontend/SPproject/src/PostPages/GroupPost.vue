<template>
    <div class="bodyDiv">
        <div class="forumDiv" v-for="thread in getPost" :key="thread.id">
            <h1>{{ thread.title }}</h1>

            <p>{{ thread.text }}</p>
            <p>{{ thread.id }}</p>

            <div v-for="item in getReplies" :key="item.id">
                {{ item.id }}
                <!-- {{ item.categoryThreadId }} -->
                <p>{{ item.text }}</p>
            </div>
        </div>

        <div class="userInListDiv">
            <div class="diplayUsersInListDiv">
                <!-- Exempel hur userlistan kan se ut -->
                <p
                    id="userNamesInThread"
                    v-for="user in memberListUsername"
                    :key="user.Id"
                >
                    {{ user.username }}

                    <!-- Lägg till userId i removeMetoden -->
                </p>
                
            </div>
            <input
                type="text"
                v-model="searchedUser"
                placeholder="Search for user"
            />
            <button @click="addUserButton()">Add user to Thread</button>
            <div>
                <ul v-for="error in errors" :key="error">
                    <li>{{ error }}</li>
                </ul>
            </div> 
            <h2 for="#">members of this groupthread</h2>
            
        </div>
      
    </div>
</template>

<script>
export default {
    data() {
        return {
            pId: this.$route.params.id,
            searchedUser: '',
            errors: [],
            memberListUsername: [],
            ThreadUserobj: {
                id: null,
                idSub: '',
            },
        }
    },

    created() {
        console.log(this.pId, "this pId")
        this.$store.dispatch('GetThreadFromSpecificId', this.pId)
        this.$store.dispatch('GetSpecificGroupThreadUsersList', this.pId)
        this.memberListUsername = this.getUserNameFilterMethod()
        this.fetchAllUsers()
        //this.$store.dispatch('GetRepliesForSpecificPost', this.pId)
        //this.$store.dispatch('getAllThreads')
    },
    beforeMount() {
      this.memberListUsername = this.getUserNameFilterMethod()
        this.fetchAllUsers()
    },

    methods: {
      
        getUserNameFilterMethod(){
            let result = this.$store.state.listOfUsersAdmin.filter(x1 => this.$store.state.specificGroupThreadUserList.some(x2 => x1.idSub === x2.userIdSub))
            console.log(result, "result");
            return result
            
        },
        fetchAllUsers() {
            this.$store.dispatch('getAllUsersAdmin')
            this.$store.dispatch('GetSpecificGroupThreadUsersList', this.pId)
            // this.$store.dispatch('Auth0GetAllUsers')
        },
        addUserButton() {
            console.log(this.$store.state.listOfUsersAdmin, "Alla users");
            // alert('Tjofräs')
            if (this.searchedUser == '') {
                this.errors.push('User dont exist')
            } else {
                this.errors = []
                this.ThreadUserobj.id = null
                this.ThreadUserobj.idSub = ''
                let userList = this.$store.state.listOfUsersAdmin

                let filteredUser = userList.filter(item => {
                    return item.username == this.searchedUser
                })

                //Destruct object
                let {
                    0: {
                        id,
                        idSub,
                        username,
                        picture,
                        email,
                        emailVerified,
                        threadUsers,
                        createDate,
                    },
                } = filteredUser

                this.ThreadUserobj.id = this.pId
                this.ThreadUserobj.idSub = idSub

                this.$store.dispatch('addUserToGroupThread', this.ThreadUserobj)
            }
        },
        removeUserFromThreadButton() {
            alert('Tjoflöjt')
        },
    },
    computed: {
        GetThreads() {
            return this.$store.state.Thread
        },
        getPost() {
            console.log(
                'getPostmetod i Post.vue: ',
                this.$store.state.SpecificPostThread
            )

            return this.$store.state.SpecificPostThread
        },
        getReplies() {
            return this.$store.state.Reply
        },

    },
}
</script>

<style scoped>
.bodyDiv {
    display: flex;
    color: #ffff;
}
.forumDiv {
    float: left;
    text-align: center;
}
/* .userInListDiv{
    
} */

.diplayUsersInListDiv {
    border-style: solid;
    border-width: thin;
    text-align: left;
    overflow: auto;
    width: 400px;
    height: 200px;
}

#userNamesInThread {
    font-weight: bold;
}
</style>
