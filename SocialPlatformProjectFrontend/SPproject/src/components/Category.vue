<template>
    <div>
        <header class="header">
                <nav class="nav">
                    <div class="nav-links">
                        <ul class="nav-menu" v-for="categories in getCategories" :key="categories.Id">
                            <router-link class="link"
                                :to="`/${categories.title}/${categories.id}`">{{ categories.title }}
                            </router-link>
                        </ul>
                    </div>
                </nav>
                <div class="d-flex justify-content-end mt-1">
                    <Modal v-show="isModalVisible" @close="closeModal">
                        <template v-slot:header>
                            <div class="text-uppercase">
                                create post
                                <span
                                    ><i class="fas fa-comments"></i
                                ></span></div
                        ></template>

                        <template v-slot:body>
                            <div id="container">
                                <div class="row pb-5">
                                   <nav class="nav-createPost">
                                        <div class="nav-left form-group">
                                            <label for="postType"
                                                >Post Type</label
                                            >
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
                                            <label for="category"
                                                >Category</label
                                            >
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
                                            v-model='newPostObject.Title'
                                        />
                                    </div>
                                    <div class="form-group">
                                        <label for="post-thread"
                                            >Add content</label
                                        >
                                        <textarea
                                            placeholder="Remember, be nice!"
                                            cols="78"
                                            rows="4"
                                            id="post-thread"
                                            name="postThread"
                                            v-model='newPostObject.Text'
                                        ></textarea>
                                    </div>
                                    <button @click="this.createPostMethod(newPostObject)" class="btn btn-form">
                                        <!-- type="submit" -->
                                        Create post
                                    </button>
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
        <div v-else >
            <div class="No-CreatePost">
                <h1>Welcome To Group2 Forum</h1>
            </div>
            <div class="No-CreatePost">
                <p>You need to log in before you can create posts!</p>
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
            badWords: ['', '', '', '', ''],
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
                Id: null,
            },
        }
    },
    created() {
        this.fetchAllCategories()
    },
    methods: {
        showModal() {
            this.isModalVisible = true
        },
        closeModal() {
            this.newPostObject.Title = ''
            this.newPostObject.Text = ''
            this.newPostObject.CategoryId = ''
            this.isModalVisible = false
        },
        setPostTypeId(value) {
            console.log('postType Id', value)
            if (value == 0) {
                this.postTypeChosen = 0
                console.log(this.postTypeChosen)
            } else {
                this.postTypeChosen = 1
                console.log(this.postTypeChosen)
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
            let catchBadWords = this.filterWords(this.newPostObject.Text)
            let catchBadWordsTitle = this.filterWords(this.newPostObject.Title)
            this.errorMessage = []
            if (this.postTypeChosen === null || this.postTypeChosen === null) {
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
                this.postTypeChosen !== null &&
                this.postTypeChosen !== null &&
                catchBadWords.length == 0 &&
                catchBadWordsTitle.length == 0
            ) {
                this.errorMessage = []
                this.closeModal()
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
    z-index:99;
}

nav{
    display:flex;
    align-items: center;
}

.nav-links{
    display:flex;
    flex:1;
    align-items:center;
    margin-top:18px;
}

.nav-menu > a{
    color: #ffffff;
}

.nav-menu > a:hover{
    color: #2576e0;
}
.nav-links >  ul{
    display:flex;
    margin-right:22px;
}

.link{
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

@media(max-width: 1300px){
    .link{
       margin-left: 12vw; 
    }
}

@media(max-width: 1000px){
    .link{
       margin-left: 8vw; 
    }
}

@media(max-width: 800px){
    .link{
       margin-left: 3vw; 
    }
}

@media(max-width: 500px){
    .link{
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

.No-CreatePost{
    display:flex;
    align-content: center;
    padding: 20px;
    justify-content: space-around;
}

.No-CreatePost > h1{
    color:rgb(29, 99, 204);
    font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
    font-weight: bolder;
}

.No-CreatePost > p{
    color:#2576e0;
    font-size:18px;
    font-weight: bolder;
    font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
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

textarea{
    width:100%
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

.nav-left {
    width: 35%;
    display: flex;
    align-items: center;
    justify-content: space-around;
}

.nav-left  > a {
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
</style>
