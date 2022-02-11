<template>
    <div>
        <header class="header">
            <nav class="nav">
                <div class="nav-links">
                    <ul
                        class="nav-menu"
                        v-for="categories in getCategories"
                        :key="categories.Id"
                    >
                        <router-link
                            class="link"
                            :to="`/${categories.title}/${categories.id}`"
                            >{{ categories.title }}
                        </router-link>
                    </ul>
                </div>
                <div v-show="this.$store.state.isAdmin" class="nav-links">
                    <ul class="nav-menu">
                        <router-link to="/adminallthreads" class="link"
                            >Threads</router-link
                        >
                        <router-link to="/admingroupthreads" class="link"
                            >Group Threads</router-link
                        >
                        <router-link to="/adminallusers" class="link"
                            >Users</router-link
                        >
                    </ul>
                </div>
            </nav>
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
                                class="btn btn-form"
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
            badWords: ['fuck', 'kuk', 'snopp', 'whore', 'dick'],
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
                console.log(this.newPostObject.ThreadType, 'INNE I IF SATSEN 1')
            } else {
                this.newPostObject.ThreadType = true
                console.log(this.newPostObject.ThreadType, 'INNE I IF SATSEN 2')
            }
        },
        async fetchAllCategories() {
            this.$store.dispatch('getAllCategories')
        },
        setCategoryIdFromDropdown(value) {
            console.log('Category Id from dropdown ', value)
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
            console.log(this.newPostObject.UserIdSub)

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
                console.log(this.errorMessage)
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
                console.log('Our UserId_Sub', this.newPostObject.UserId_Sub)
                console.log(this.newPostObject, 'THIS IS THE OBJECT WE SENDING')
                return this.$store.dispatch(
                    'createNewPostMethod',
                    newPostObject
                )
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
    margin: 20px;
    background-color: #303030;
    border-radius: 5px;
    z-index: 99;
}

nav {
    display: flex;
    align-items: center;
}

.nav-links {
    display: flex;
    flex: 1;
    align-items: center;
    margin-top: 18px;
}

.nav-menu > a {
    color: #ffffff;
}

.nav-menu > a:hover {
    color: #2576e0;
}
.nav-links > ul {
    display: flex;
    margin-right: 22px;
}

.link {
    text-decoration: none;
    font-family: 'Poppins' sans-serif;
    font-size: 25px;
    margin-left: 15vw;
    letter-spacing: 0.5px;
    -webkit-transition: all 0.3s ease 0s;
    -moz-transition: all 0.3s ease 0s;
    -o-transition: all 0.3s ease 0s;
    transition: all 0.3s ease 0s;
}



@media (max-width: 1300px) {
    .link {
        margin-left: 12vw;
    }
}

@media (max-width: 1000px) {
    .link {
        margin-left: 8vw;
    }
}

@media (max-width: 800px) {
    .link {
        margin-left: 3vw;
    }
}

@media (max-width: 500px) {
    .link {
        margin-left: 4px;
    }
}

/*Create Post */
.create-post {
    padding: 14px;
    margin-bottom: 20px;
    background: #505455;
    border-radius: 5px;
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
  width: 100vw;
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
