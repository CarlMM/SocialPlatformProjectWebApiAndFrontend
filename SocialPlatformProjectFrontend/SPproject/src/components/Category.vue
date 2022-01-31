<template>
    <div>
        <header class="header">
            <div class="navbar">
                <nav class="navigation">
                    <ul
                        class="nav-menu"
                        v-for="categories in getCategories"
                        :key="categories.Id"
                    >
                        <li class="nav-item">
                            <router-link
                                :to="`/${categories.Title}/${categories.Id}`"
                                >{{ categories.Title }}
                            </router-link>
                        </li>
                    </ul>
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
                                        <div class="nav-left">
                                            <a href="#Home">Post</a>
                                            <a href="#Home">Group post</a>
                                        </div>
                                        <div class="nav-right form-group">
                                            <label for="category"
                                                >Category</label
                                            >
                                            <Dropdown
                                                id="category"
                                                name="category"
                                                :options="category"
                                                @change="setCategoryIdFromDropdown($event.target.value)"
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
            </div>
        </header>
        <div class="create-post">
            <!-- <a href=""></a> -->
            <img src="/src/assets/Group_2.jpg" alt="" />
            <input
                @click="showModal()"
                class="create-input"
                type="text"
                name="createPost"
                placeholder="Create Post"
            />
        </div>
    </div>
</template>

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
            isModalVisible: false,
            category: {
                Computer: 1,
                Fishing: 2,
                Studies: 3,
            },
            newPostObject:{
                Title: '',
                Text: '',
                CategoryId: '',
                Id: null,
            },
            // postTitle2: '',
            // postTitle2:'',
        }
    },
    methods: {
        showModal() {
            this.isModalVisible = true
        },

        closeModal() {
            this.isModalVisible = false
        },
        setCategoryIdFromDropdown(value){
            console.log('Category Id from dropdown ', value);
            this.newPostObject.CategoryId = value;
        },
        createPostMethod(newPostObject){

            console.log('Category from dropdown: ', this.newPostObject.CategoryId)
            console.log(newPostObject.CategoryId);
            
            console.log('Title from input: ', this.newPostObject.Title)
            console.log(newPostObject.Title);
            
            console.log('Text from "add content" input: ',  this.newPostObject.Text)
            console.log(newPostObject.Text);
            
            this.newPostObject.Id = 20;

            console.log('ThreadId = ', this.newPostObject.Id);
            console.log(newPostObject.Id);


            // const newNewPostObject={
            //      Title: this.newPostObject.Title,
            //      Text: this.newPostObject.Text,
            //      CategoryId: this.newPostObject.CategoryID,
            //      Id: this.newPostObject.Id,
            //  }
        
            console.log('Posten: ', newPostObject);
            // console.log(this.newPostObject.threadId)

            //console.log(newNewPostObject);

            this.closeModal();
            return this.$store.dispatch('createNewPostMethod', newPostObject);
            
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
    display: flex;
    align-items: center;
    background: #33393a;
    border-radius: 5px;
}


.nav-menu a {
    color: #fff;
}

.navigation {
    max-height: 12vh;
    margin-right: 10px;
}

.nav-menu {
    list-style-type: none;
    overflow: hidden;
}

/*Create Post */
.create-post {
    padding: 15px;
    margin: 20px;
    background: #33393a;
    border-radius: 5px;
    display: flex;
    justify-content: space-around;
}

.create-post > img {
    width: 3.5vw;
    margin-right: 15px;
}

.create-post > input {
    width: 100%;
    border-radius: 5px;
    background-color: rgb(160, 160, 160);
}

.input:hover {
    border: 1px solid white;
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
    border: rgb(158, 158, 158) 1px solid;
    border-radius: 5px;
}

.btn-form {
    background-color: #43a78c;
    display: block;
    width: 100%;
    padding: 10px;
    color: #fff;
    cursor: pointer;
}

.btn-form:hover {
    background: #5ab6a6;
}

/* HOOVER STYLE CATEGORY WHEN CREATE POST*/

*,
*::before,
*::after {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

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

a {
    position: relative;
    text-decoration: none;
    font-family: 'Poppins' sans-serif;
    color: #838383;
    font-size: 20px;
    letter-spacing: 0.5px;
    padding: 0 10px;
    /* transform: 0.3s; */
}
a::after {
    content: '';
    position: absolute;
    text-decoration: none;
    background-color: #45b989;
    height: 3px;
    width: 0;
    left: 0;
    bottom: -10px;
    transition: 0.3s;
}

a:hover {
    color: #333;
    text-decoration: none;
}
a:hover:after {
    width: 100%;
}

textarea {
    resize: none;
}
</style>
