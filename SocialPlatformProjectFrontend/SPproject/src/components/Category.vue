<template>
    <div>
        <header class="header">
            <nav class="nav">
                <div class="nav-links">
                    <ul class="nav-menu"
                        v-for="categories in getCategories"
                        :key="categories.Id">
                        <router-link
                            class="link"
                            :to="`/${categories.title}/${categories.id}`"
                            >{{ categories.title }}
                        </router-link>
                    </ul>
                </div>
            </nav>
            <div v-show="this.$store.state.isAdmin" class="nav-links">
                <ul class="admin-menu">
                    <article>
                        <h2 class="admin-screen">Welcome Admin</h2>
                    </article>
                    <router-link to="/adminallthreads" class="link">Threads</router-link>
                    <router-link to="/admingroupthreads" class="link">Group-Threads</router-link>
                    <router-link to="/adminallusers" class="link">Users</router-link>
                </ul>
             </div>
            <div class="d-flex justify-content-end mt-1">
                <Modal v-show="isModalVisible" @close="closeModal">
                    <template v-slot:header>
                        <div class="text-uppercase">
                            create post
                            <span><i class="fas fa-comments"></i></span></div
                    ></template>

                    <template v-slot:body>
                        <div id="container">
                            <div class="row pb-5">
                                <nav class="nav-createPost">
                                    <div class="nav-left form-group">
                                        <label for="postType">Post Type</label>

                                        <Dropdown
                                            id="postType"
                                            name="postType"
                                            selected
                                            :options="postType"
                                            @change="
                                                setPostTypeId(
                                                    $event.target.value
                                                )
                                            "
                                        ></Dropdown>
                                    </div>
                                    <div class="nav-right form-group">
                                        <label for="category">Category</label>
                                        <Dropdown
                                            id="category"
                                            name="category"
                                            :options="category"
                                            @change="
                                                setCategoryIdFromDropdown(
                                                    $event.target.value
                                                )
                                            "
                                        ></Dropdown>
                                    </div>
                                </nav>
                            </div>
                            <!-- @change="setPostTitleFromDropdown($event.target.value)" -->
                            <!-- @change="setPostTextFromDropdown($event.target.value)" -->
                            <!-- <form action="#" id="createPost-form"> -->
                            <div class="form-group">
                                <label for="text-title">Title</label>
                                <input
                                    type="text"
                                    name="textTitle"
                                    id="text-title"
                                    v-model="newPostObject.Title"
                                />
                            </div>
                            <div class="form-group">
                                <label for="post-thread">Add content</label>
                                <textarea
                                    placeholder="Remember, be nice!"
                                    cols="78"
                                    rows="4"
                                    id="post-thread"
                                    name="postThread"
                                    v-model="newPostObject.Text"
                                ></textarea>
                            </div>
                            <button
                                @click="this.createPostMethod(newPostObject)"
                                class="btn-all"
                            >
                                <!-- type="submit" -->
                                Create post
                            </button>
                            <div
                                v-for="error in this.errorMessage"
                                :key="error.Id"
                            >
                                <ul>
                                    <li>{{ error }}</li>
                                </ul>
                            </div>
                            <p class="bottom-text"></p>
                            <!-- </form> -->
                        </div>
                    </template>
                </Modal>
            </div>
        </header>
        <div class="create-post" v-if="AuthState.isAuthenticated">
            <!-- <a href=""></a> -->
            <img :src="AuthState.user.picture" alt="" />
            <input
                @click="showModal()"
                class="create-input"
                type="text"
                name="createPost"
                placeholder="Create Post"
            />
        </div>
        <div v-else>
            <div class="body-message">
                <h1>
                    <span>You need to sign in:</span>
                    <div class="message">
                        <div class="word1">So You Can</div>
                        <div class="word2">!</div>
                        <div class="word3">Post With Us!</div>
                    </div>
                </h1>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'
const { initAuth } = useAuth0(AuthState)
initAuth()
</script>

<script>
import Modal from './Modal.vue'
import Dropdown from './Dropdown.vue'
export default {
    components: {
        Modal,
        Dropdown,
    },
    data() {
        return {
            badWords: ['fuck', 'dick', 'wiener', 'whore', 'shit', 'thomas', 'skåne'],
            isModalVisible: false,
            postTypeChosen: null,
            errorMessage: [],
            category: {
                Computer: 1,
                Fishing: 2,
                Studies: 3,
            },
            postType: {
                post: 0,
                GroupPost: 1,
            },
            newPostObject: {
                Title: '',
                Text: '',
                CategoryId: '',
                UserIdSub: '',
                ThreadType: false,
                // ThreadUsers:{
                //     UserIdSub: '',
                // }
            },
        }
    },

    created() {
        this.fetchAllCategories()
        this.checkIfAdmin()
    },
    methods: {
        checkIfAdmin() {
            if (AuthState.isAuthenticated == true) {
                if (
                    AuthState.user['http://localhost:3000/roles'][0] ==
                    'AdminUser'
                ) {
                    this.$store.state.isAdmin = true
                }
            }
        },
        showModal() {
            this.isModalVisible = true
        },
        closeModal() {
            this.errorMessage = []
            // this.newPostObject.Title = ''
            // this.newPostObject.Text = ''
            // this.newPostObject.CategoryId = ''
            this.isModalVisible = false
        },

        setPostTypeId(value) {
            if (value == 0) {
                this.newPostObject.ThreadType = false
            } else {
                this.newPostObject.ThreadType = true
            }
        },
        async fetchAllCategories() {
            this.$store.dispatch('getAllCategories')
        },
        setCategoryIdFromDropdown(value) {
            this.newPostObject.CategoryId = value
        },

        filterWords(array) {
            let filteredWordsArray = array.toLowerCase().split(' ')
            let catchBadWords = filteredWordsArray.filter(item =>
                this.badWords.includes(item)
            )
            return catchBadWords
        },

        createPostMethod(newPostObject) {
            this.newPostObject.UserIdSub = AuthState.user.sub
            //this.newPostObject.ThreadUsers.UserIdSub = AuthState.user.sub;

            let catchBadWords = this.filterWords(this.newPostObject.Text)
            let catchBadWordsTitle = this.filterWords(this.newPostObject.Title)
            this.errorMessage = []

            if (this.newPostObject.chosenType === null) {
                this.errorMessage.push('Please choose post type!')
            }
            if (this.newPostObject.Title == '') {
                this.errorMessage.push('Please enter a title!')
            }
            if (this.newPostObject.Text == '') {
                this.errorMessage.push('Please enter some text!')
            }
            if (this.newPostObject.CategoryId == '') {
                this.errorMessage.push('Please choose category!')
            }
            if (catchBadWords.length > 0) {
                this.errorMessage.push('Remember to be nice!')
            }
            if (catchBadWordsTitle.length > 0) {
                this.errorMessage.push('Remember to be nice Title!')
            }
            if (
                this.newPostObject.Text !== '' &&
                this.newPostObject.Title !== '' &&
                this.newPostObject.CategoryId !== '' &&
                this.newPostObject.chosenType !== null &&
                catchBadWords.length == 0 &&
                catchBadWordsTitle.length == 0
            ) {
                this.errorMessage = []
                this.closeModal()

                // ThreadUser:{
                //     userIdSub: '',
                //     CategoryThreadId: null,
                // }

                
                // this.newPostObject.ThreadUser.CategoryThreadId = this.newPostObject.UserId_Sub;
                this.$store.dispatch('createNewPostMethod', newPostObject )
                 this.newPostObject.Title = ''
                 this.newPostObject.Text = ''
            }
        },
    },
    computed: {
        getCategories() {
            return this.$store.state.Category
        },
    },
}
</script>

<style scoped>
.header {
    background-color: #303030;
    border-top-left-radius: 5px;
    border-top-right-radius: 5px;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

nav {
    display:flex;
    align-content: center;
    justify-content: center;
}

.nav-menu{
    margin:0;
}

.nav-links {
    display: flex;
    align-items: center;
    justify-content: space-around;
    padding: 10px 0;
}

article{
 background: linear-gradient(
    to right, 
    hsl(40 100% 62%), 
    hsl(20 100% 59%)
  );
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  text-align: center;
}

.admin-screen{
    color:#fff;
    text-align: center;
    font-size: 20px;
    padding-left:22px;
}

.admin-menu > a{
    color:#fff;
    line-height: 10px;
    padding: 0 10px;
}

a{
    color: #ffffff;
}

a:hover {
    color: #2576e0;
}

.link {
    text-decoration: none;
    font-size: 25px;
    letter-spacing: 0.5px;
    -webkit-transition: all 0.3s ease 0s;
    -moz-transition: all 0.3s ease 0s;
    -o-transition: all 0.3s ease 0s;
    transition: all 0.3s ease 0s;
}


/*Create Post */
.create-post {
    padding: 14px;
    margin-bottom: 20px;
    background: #505455;
    border-bottom-left-radius: 5px;
    border-bottom-right-radius: 5px;
    display: flex;
    justify-content: space-around;
}

.create-post > img {
    width: 2.5vw;
    margin-right: 15px;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.create-post > input {
    width: 100%;
    border-radius: 5px;
    background-color: rgb(255, 255, 255);
    border: 1px solid rgb(0, 0, 0);
}

#container {
    margin: 30px auto;
    max-width: 600px;
    /* border: 1px solid red; */
}

/* .form-group {
    margin-top: 10px;
} */

.form-group label {
    font-size: 1.1rem;
    display: block;
    color: #666;
}

.form-group input {
    width: 100%;
    padding: 10px;
    border: rgb(233, 227, 227) 1px solid;
    border-radius: 5px;
}

textarea {
    width: 100%;
}

.btn-form {
    background-color: #3975c4;
    display: block;
    width: 100%;
    padding: 10px;
    color: #ffffff;
    cursor: pointer;
}

.btn-form:hover {
    background: #2576e0;
}

.btn-all{
    padding: 10px;
}

/* HOOVER STYLE CATEGORY WHEN CREATE POST*/

/* *,
*::before,
*::after {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
} */

.nav-createPost {
    width: 70vw;
    min-width: 600px;
    display: flex;
    align-items: center;
    justify-content: space-around;
    margin: auto;
}

/* .nav-left {
    width: 35%;
    display: flex;
    align-items: center;
    justify-content: space-around;
} */

.nav-left > a {
    position: relative;
    text-decoration: none;
    font-family: 'Poppins' sans-serif;
    color: rgb(0, 0, 0);
    font-size: 20px;
    letter-spacing: 0.5px;
    padding: 0 10px;
    /* transform: 0.3s; */
}
.nav-left > a::after {
    content: '';
    position: absolute;
    text-decoration: none;
    background-color: #464646;
    height: 3px;
    width: 0;
    left: 0;
    bottom: -10px;
    transition: 0.3s;
}

.nav-left > a:hover {
    color: #333;
    text-decoration: none;
}
.nav-left > a:hover:after {
    width: 100%;
}

textarea {
    resize: none;
}


/*Not signed in text */

.body-message{
  display: flex;
  align-items: center;
  justify-content: center;
  height: 20vh;
  /* width: 100vw; */
}

.body-message > h1{
  color: rgb(255, 255, 255);
  font-family: tahoma;
  font-size: 1.5rem;
  font-weight: 100;
  line-height: 1.5;
  text-transform: uppercase;
  white-space: nowrap;
  overflow: hidden;
  position: relative;
  width: 550px;
}

.message{
  background-color: rgb(23, 156, 209);
  color: #333;
  display: block;
  font-weight: 900;
  overflow: hidden;
  position: absolute;
  padding-left: 0.5rem;
  top: 0.2rem;
  left: 250px;
  animation: openclose 5s ease-in-out infinite;
}

.word1, .word2, .word3{
    font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
}

@keyframes openclose {
  0% {
    top: 0.2rem;
    width: 0;
  }
  5% {
    width: 0;
  }
  15% {
    width: 230px;
  }
  30% {
    top: 0.2rem;
    width: 230px;
  }
  33% {
    top: 0.2rem;
    width: 0;
  }
  35% {
    top: 0.2rem;
    width: 0;
  }
  38% {
    top: -4.5rem;
    
  }
  48% {
    top: -4.5rem;
    width: 190px;
  }
  62% {
    top: -4.5rem;
    width: 190px;
  }
  66% {
    top: -4.5rem;
    width: 0;
    text-indent: 0;
  }
  71% {
    top: -9rem;
    width: 0;
    text-indent: 5px;
  }
  86% {
    top: -9rem;
    width: 285px;
  }
  95% {
    top: -9rem;
    width: 285px;
  }
  98% {
    top: -9rem;
    width: 0;
    text-indent: 5px;
  }
  100% {
    top: 0;
    width: 0;
    text-indent: 0;
  }
}
</style>
