<template>
    <div class="outer-box">
        <div class="post-andReply grid">
            <div class="post-tex">
                <div class="main-post">
                    <div class="main-text" v-for="thread in getPost" :key="thread.id">
                        <h1 class="post-h1">{{ thread.title }}</h1>
                        <span class="post-user">Posted {{setTime(thread.createdDate)}}</span>
                        <p>{{ thread.text }}</p>
                    </div>
                    <button class="post-btn" @click="showModal()">
                        <i class="far fa-comment icon"></i>
                        <span>Comment</span>
                    </button>
                    <button class="post-btn">
                        <i class="fa-regular fa-pen-to-square icon"></i>
                        <span>Edit</span>
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
                            <span class="post-user">Replied {{setTime(item.createdDate)}}</span>
                            <p class="reply-text">{{item.text}}</p>
                            <button class="post-btn">
                                <i class="far fa-comment icon"></i>
                                <span>Reply</span>
                            </button>
                            <button class="post-btn">
                                <i class="fa-regular fa-pen-to-square icon"></i>
                                <span>Edit</span>
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
            </div>
                    <div class="userInListDiv">
                        <h2>GroupThread Members</h2>
                        <div class="diplayUsersInListDiv">
                            <!-- Exempel hur userlistan kan se ut -->
                            <p
                                id="userNamesInThread" v-for="user in GetThreadUsers" :key="user.Id">
                                {{ user.userIdSubNavigation.username }}
                                
                                <!-- {{ user }} -->
                                <!-- Lägg till userId i removeMetoden -->
                                 <button class="btn-close" @click="removeUserButton(user.userIdSub)" >X</button>
                            </p>
                        </div>
                        <div class="functions">
                            <input class="input_field" type="text" v-model="searchedUser" placeholder="Search for user"/>
                            <button class="btn-all all2" @click="addUserButton(this.searchedUser)">Add User</button>
                            <!-- <button @click="kollaAnvändareKnapp()">Kolla alla användare</button> -->
                            <div>
                                <ul v-for="error in errors" :key="error">
                                    <li>{{ error }}</li>
                                </ul>
                            </div> 
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
                                    <div class="main-post m2">
                                        <h1>{{ this.threadTitle }}</h1>
                                        <h1>Posted {{ this.threadDate}}</h1>
                                        <!-- <p>{{setTime(threadDate)}}</p> -->
                                        <p>{{ this.threadText }}</p>
                                    </div>
                                    <div id="container">
                                        <div class="form-group">
                                            <label for="reply-content">Add content</label>
                                            <textarea class="textareas"
                                                placeholder="Remember, be nice!"
                                                cols="78"
                                                rows="5"
                                                v-model="newReplyPost.Text"
                                            ></textarea>
                                        </div>
                                        <button class="btn-all" v-on:click="this.reply(newReplyPost)">
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
import { mapActions } from 'vuex'
import Modal from '../components/Modal.vue'
import dateclock from '/src/assets/js/dateclock.js'

export default {
    components:{
        Modal,
    },

    data() {
        return {
            badWords: ['fuck', 'dick', 'wiener', 'whore', 'shit', 'thomas', 'skåne'],
            errorMessage: [],
            pId: this.$route.params.id,
            searchedUser: '',
            threadTitle: '',
            threadText: '',
            threadDate: Date,
            errors: [],
            memberListUsername: [],
            isModalVisible: false,
            ThreadUserobj: {
                categoryThreadId: null,
                userIdSub: '',
            },
            CurrentUserObj:{
                categoryThreadId: null,
                userIdSub: '',
            },
            sendObj:{
                prop1: null,
                prop2: null
            },
            RemoveUserFromGroupObj:{
                categoryThreadId: null,
                userIdSub: '',
            },
            userNameToId:'',
            newReplyPost: {
                Text: '',
                UserIdSub: '',
                CategoryThreadId: null,
            },
        }
    },

    created() {
        this.$store.commit('setToken', AuthState.token)
        this.$store.dispatch('getAllUsersAdmin')
        this.$store.dispatch('GetThreadFromSpecificId', this.pId)
        this.$store.dispatch('GetRepliesForSpecificPost', this.pId)
        this.fetchAllUsers()

        if (AuthState.isAuthenticated != true || !AuthState.isAuthenticated != false) {
            // if (
            //     AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
            // ) {
            //     this.$store.state.isAdmin = true
            // } 
            //else {
                this.$router.push('/notauthorized')
            //}
        }
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

        showModal(){
            this.isModalVisible = true
            let threadList = this.$store.state.SpecificPostThread

            let {
                0: {
                    id,
                    title,
                    text,
                    categoryId,
                    category,
                    createdDate,
                    replies,
                    threadType,
                    threadUsers,
                    userIdSub,
                },
            } = threadList

            this.threadTitle = title
            this.threadText = text
            this.threadDate = createdDate.slice(0, 10)
        },
        closeModal(){
            this.isModalVisible = false
        },

         filterWords(message) {
            let filteredWordsArray = message.toLowerCase().split(' ')
            let catchBadWords = filteredWordsArray.filter(item =>
                this.badWords.includes(item)
            )
            return catchBadWords
        },

        ...mapActions(['PostReplyToSpecificPost']),
        reply(newReplyPost) {
            this.errorMessage = []
            let catchBadWords = this.filterWords(this.newReplyPost.Text)
            console.log(this.newReplyPost, 'REPLY MESSAGE')
            if (this.newReplyPost.Text == '') {
                this.errorMessage.push('Please enter some text!')
            }
            if (catchBadWords.length > 0) {
                this.errorMessage.push('Remember to be nice!')
            } else if (
                this.newReplyPost.Text != '' &&
                catchBadWords.length == 0
            ) {
                this.errors = []
                this.newReplyPost.UserIdSub = AuthState.user.sub
                console.log(this.pId, "PID!!!!!!");
                this.newReplyPost.CategoryThreadId = this.pId
                console.log(this.newReplyPost.CategoryThreadId , "PID");
                console.log('ReplyMethod: ', newReplyPost)
                console.log(this.newReplyPost, "this.newReplyPost!!!!!!!!");

                this.PostReplyToSpecificPost(newReplyPost)
                this.$store.dispatch('GetRepliesForSpecificPost', this.pId)
                this.closeModal()
                location.reload()
                this.newReplyPost.Text = ''
            }
            //return this.$store.dispatch('PostReplyToSpecificPost', newReplyPost)
        },

        removeUserButton(userSubId){
            let deleteConfirm = 'are u sure you want to remove user from group?'
            if(confirm(deleteConfirm) == true){

            this.CurrentUserObj.categoryThreadId = this.pId;
            this.CurrentUserObj.userIdSub = AuthState.user.sub;


            this.RemoveUserFromGroupObj.categoryThreadId = this.pId
            this.RemoveUserFromGroupObj.userIdSub = userSubId;

            this.sendObj = {
                 prop1: this.CurrentUserObj,
                 prop2: this.RemoveUserFromGroupObj
             }
            this.$store.dispatch('deleteUserFromGroup', this.sendObj)

                let groupMemberId = userSubId
                //Fetch the list of userThread
                let list = this.$store.state.ThreadUser
                //Goes through the list, filter it and check for what is no longer there
                let updatedList = list.filter(item => {
                    return item.userIdSub !== groupMemberId
                })
                this.$store.commit('updateThreadUser', updatedList)
            }
            else{
                
            }


            
           

        },
        addUserButton() {
            
            for(let i = 0; i < this.$store.state.listOfUsersAdmin.length; ++i){
                //console.log(this.$store.state.listOfUsersAdmin[i])
                if(this.searchedUser == this.$store.state.listOfUsersAdmin[i].username){
                    this.userNameToId = this.$store.state.listOfUsersAdmin[i].idSub
                }
                
            }

             this.CurrentUserObj.categoryThreadId = this.pId;
             this.CurrentUserObj.userIdSub = AuthState.user.sub;

             this.ThreadUserobj.categoryThreadId = this.pId
             this.ThreadUserobj.userIdSub = this.userNameToId;

            
             console.log(this.CurrentUserObj)

             this.sendObj = {
                 prop1: this.CurrentUserObj,
                 prop2: this.ThreadUserobj
             }


            //  console.log(this.sendObj.prop1.userIdSub)
            //  console.log('person att lägga till', this.sendObj.prop2.userIdSub)

             this.$store.dispatch('addUserToGroupThread', this.sendObj)
             location.reload();



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
        setTime(date){
            return dateclock.DateOfCreation(date)
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

.textareas{
    width:100%;
}

.m2{
    border-radius: 4px;
}

.grid{
    display: grid;
    grid-template-columns: 77% 23%; 
    grid-template-rows: 100%;
    grid-column-gap: 5px;
}


.subforum-column {
    margin-top:1px;
    padding-bottom: 0.1px;
    background-color: #525d92;
    /* #816f6f */
}

/*modal*/
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
    border: 2px solid #6f7281;
    overflow: auto;
    border-radius: 4px;
    height:280px;
    max-height: 280px;
}

.userInListDiv > h2{
    padding: 5px 20px;
}

.diplayUsersInListDiv > p{
    padding:0;
    margin:0;
}

#userNamesInThread {
    font-weight: bold;
}

.functions{
    display:flex;
    align-content: flex-end;
    justify-content: flex-end;
    padding: 5px 5px;
}

.functions > input{
    width: 100%;
}

/*btn-all*/

.btn-all{
    display:block;
    padding:10px;
    cursor: pointer;
}

.all2{
    padding: 5px 5px;
    margin: 0 5px;
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
