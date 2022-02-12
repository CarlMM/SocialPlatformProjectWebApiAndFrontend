<template>
    <div class="outer-box">
        <div class="post-andReply grid">
            <div class="post-tex">
                <div class="main-post">
                    <div class="main-text" v-for="thread in getPost" :key="thread.id">
                        <h1 class="post-h1">{{ thread.title }}</h1>
                        <span class="post-user">Posted Temp</span>
                        <p>{{ thread.text }}</p>
                    </div>
                    <button class="post-btn" @click="toggleModal()">
                        <i class="far fa-comment icon"></i>
                    <span>Reply to post</span>
                    </button>
                    <button class="post-btn">
                        <i class="far fa-surprise icon"></i>
                        <span>Surprise</span>
                    </button>
                    <button class="post-btn">
                        <i class="far fa-share-square icon"></i>
                        <span>Share</span>
                    </button>
                    <button class="post-btn">
                        <i class="far fa-flag icon"></i>
                        <span>Report</span>
                    </button>
                </div>
                <div class="post-andReply subforum-column">
                    <div class="replies" v-for="item in getReplies" :key="item.id">
                            <span class="post-user">Replied temp</span>
                            <p class="reply-text">{{item.text}}</p>
                            <button class="post-btn">
                                <i class="far fa-comment icon"></i>
                                <span>Reply to comment</span>
                            </button>
                            <button class="post-btn">
                                <i class="far fa-surprise icon"></i>
                                <span>Surprise</span>
                            </button>
                            <button class="post-btn">
                                <i class="far fa-share-square icon"></i>
                                <span>Share</span>
                            </button>
                            <button class="post-btn">
                                <i class="far fa-flag icon"></i>
                                <span>Report</span>
                            </button>
                    </div>
                </div>
                    <div class="d-flex justify-content-end mt-1">
            <Modal v-show="isModalVisible" @close="closeModal">
                                <template v-slot:header>
                                    <div class="text-uppercase">
                                        reply
                                        <span><i class="fas fa-comments"></i></span></div
                                ></template>
                                <template v-slot:body>
                                    <div class="subforum-description subforum-column">
                                        <h1>
                                            <small
                                                >Posted by <a href="">User</a> 15 Jan
                                                2022</small
                                            >
                                        </h1>
                                        <h1>{{ this.threadTitle }}</h1>
                                        <p>{{ this.threadText }}</p>
                                    </div>
                                    <div id="container">
                                        <div class="form-group">
                                            <label for="reply-content">Add content</label>
                                            <textarea
                                                placeholder="Remember, be nice!"
                                                cols="78"
                                                rows="5"
                                                v-model="newReplyPost.Text"
                                            ></textarea>
                                        </div>
                                        <button class="btn btn-reply" v-on:click="this.reply(newReplyPost)">
                                            Reply
                                        </button>
                                        <div v-for="error in errorMessage" :key="error.id">
                                            <ul>
                                                <li style="color: #333">{{ error }}</li>
                                            </ul>
                                        </div>
                                    </div>
                                </template>
            </Modal>
        </div>
            </div>
                    <div class="userInListDiv">
                        <h2 for="#">GroupThread Members</h2>
                        <div class="diplayUsersInListDiv">
                            <!-- Exempel hur userlistan kan se ut -->
                            <p
                                id="userNamesInThread" v-for="user in GetThreadUsers" :key="user.Id">
                                {{ user.userIdSubNavigation.username }}
                                <!-- {{ user }} -->
                                <!-- Lägg till userId i removeMetoden -->
                                 <button class="btn-close" >X</button>
                            </p>
                        </div>
                        <input type="text" v-model="searchedUser" placeholder="Search for user"/>
                        <button @click="addUserButton(this.searchedUser)">Add user to Thread</button>
                        <button @click="kollaAnvändareKnapp()">Kolla alla användare</button>
                        <div>
                            <ul v-for="error in errors" :key="error">
                                <li>{{ error }}</li>
                            </ul>
                        </div> 
                    </div>
        </div>
    </div>

    <!-- <div class="bodyDiv">
        <div class="forumDiv" v-for="thread in getPost" :key="thread.id">
            <h1>{{ thread.title }}</h1>
            <p>{{ thread.text }}</p>
            <div v-for="item in getReplies" :key="item.id">
                {{ item.id }}
                <p>{{ item.text }}</p>
            </div>
        </div>
        <div class="userInListDiv">
            <div class="diplayUsersInListDiv">
                <p
                    id="userNamesInThread"
                    v-for="user in GetThreadUsers"
                    :key="user.Id">
                    {{ user.username }}
                </p>
            </div>
            <input type="text" v-model="searchedUser" placeholder="Search for user"/>
            <button @click="addUserButton()">Add user to Thread</button>
            <div>
                <ul v-for="error in errors" :key="error">
                    <li>{{ error }}</li>
                </ul>
            </div> 
            <h2 for="#">members of this groupthread</h2>
        </div>
    </div> -->
</template>


<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'
const { initAuth } = useAuth0(AuthState)
initAuth()
</script>

<script>
export default {


    data() {
        return {
            pId: this.$route.params.id,
            // tId: this.$route.params.Id,
            searchedUser: '',
            errors: [],
            memberListUsername: [],
            ThreadUserobj: {
                categoryThreadId: null,
                userIdSub: '',
            },
            CurrentAddingUserObj:{
                categoryThreadId: null,
                userIdSub: '',
            },
            sendObj:{
                prop1: null,
                prop2: null
            },
            userNameToId:'',
        }
    },

    created() {
        this.$store.dispatch('getAllUsersAdmin')
        this.$store.dispatch('GetThreadFromSpecificId', this.pId)
        this.$store.dispatch('GetRepliesForSpecificPost', this.pId)
        this.fetchAllUsers()
    },
    beforeMount() {
        this.fetchAllUsers()
    },

    methods: {
        // toggleModal() {
        //     if (AuthState.isAuthenticated) {
        //         this.showModal()
        //     }
        // },
        
        fetchAllUsers() {
            this.$store.dispatch('getThreadUser', this.pId)
            
        },

        kollaAnvändareKnapp(){
            console.log(this.$store.state.listOfUsersAdmin)
        },
        addUserButton() {
            
            for(let i = 0; i < this.$store.state.listOfUsersAdmin.length; ++i){
                //console.log(this.$store.state.listOfUsersAdmin[i])
                if(this.searchedUser == this.$store.state.listOfUsersAdmin[i].username){
                    this.userNameToId = this.$store.state.listOfUsersAdmin[i].idSub
                }
                

            }

            //console.log(this.userNameToId)

             this.CurrentAddingUserObj.categoryThreadId = this.pId;
             this.CurrentAddingUserObj.userIdSub = AuthState.user.sub;

             this.ThreadUserobj.categoryThreadId = this.pId
             this.ThreadUserobj.userIdSub = this.userNameToId;

             this.sendObj = {
                 prop1: this.CurrentAddingUserObj,
                 prop2: this.ThreadUserobj
             }

             return this.$store.dispatch('addUserToGroupThread', this.sendObj)






            //console.log(this.$store.state.listOfUsersAdmin, "Alla users");
            // alert('Tjofräs')
            // // if (this.searchedUser == '') {
            // //     this.errors.push('User dont exist')
            // // } else {
                // this.errors = []
                // this.ThreadUserobj.id = null
                // this.ThreadUserobj.idSub = ''
                // let userList = this.$store.state.listOfUsersAdmin

                // let filteredUser = userList.filter(item => {
                //     return item.username == this.searchedUser
                // })

                // //Destruct object
                // let {
                //     0: {
                //         id,
                //         idSub,
                //         username,
                //         picture,
                //         email,
                //         emailVerified,
                //         threadUsers,
                //         createDate,
                //     },
                // } = filteredUser




            //}
        },
        removeUserFromThreadButton() {
            alert('Tjoflöjt')
        },
    },
    computed: {
        // GetUsersFromDataBase(){
        //     return this.$store.state.listOfUsersAdmin
        // },
        GetThreadUsers(){
            return this.$store.state.ThreadUser

        },
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

.grid{
    display: grid;
    grid-template-columns: 77% 23%; 
    grid-template-rows: 100%;
    grid-column-gap: 5px;
}


.subforum-column {
    margin-top:1px;
    padding-bottom: 0.1px;
    background-color: #6f7281;
    /* #816f6f */
}

#container {
    margin: 40px auto;
    max-width: 600px;
    /* border: 1px solid red; */
}
.form-group label {
    font-size: 1.1rem;
    display: block;
    color: #666;
}

.form-group input {
    width: 100%;
    padding: 10px;
    border: rgb(158, 158, 158) 1px solid;
    border-radius: 5px;
}

.btn-reply {
    background-color: #43a78c;
    display: block;
    width: 100%;
    padding: 10px;
    color: #fff;
    cursor: pointer;
}

.btn-reply:hover {
    background: #5ab6a6;
}

textarea {
    resize: none;
}

/*User in group */

.bodyDiv {
    display: flex;
    color: #ffff;
}
.forumDiv {
    float: left;
    text-align: center;
}

.diplayUsersInListDiv {
    border-style: solid;
    border-width: thin;
    text-align: left;
    overflow: auto;
    height: 200px;
}

.diplayUsersInListDiv > p{
    padding:0;
    margin:0;
}

#userNamesInThread {
    font-weight: bold;
}


/*btn-close */

.btn-close {
    position: absolute;
    color: rgb(255, 255, 255);
    padding: 0;
    margin: 2px 2px;
    font-size: 14px;
    cursor: pointer;
    font-weight: bold;
    background: transparent;
} 
</style>
