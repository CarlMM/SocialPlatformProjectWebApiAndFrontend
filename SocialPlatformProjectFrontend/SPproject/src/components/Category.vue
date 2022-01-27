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
                                >{{ categories.Title }}</router-link
                            >
                        </li>
                        <!-- <li class="nav-item"><router-link to="/Studies/3">Studies</router-link></li>
                <li class="nav-item"><router-link to="/Fishing/2">Fishing</router-link></li>
                <li class="nav-item"><router-link to="/Computers/{{id}}">Computer</router-link></li> -->
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
                                            ></Dropdown>
                                        </div>
                                    </nav>
                                </div>
                                <form action="#" id="createPost-form">
                                    <div class="form-group">
                                        <label for="text-title">Title</label>
                                        <input
                                            type="text"
                                            name="textTitle"
                                            id="text-title"
                                        />
                                    </div>
                                    <div class="form-group">
                                        <label for="post-content"
                                            >Add content</label
                                        >
                                        <input
                                            type="text"
                                            name="postContent"
                                            id="post-content"
                                        />
                                    </div>
                                    <button type="submit" class="btn btn-form">
                                        Create post
                                    </button>
                                    <p class="bottom-text"></p>
                                </form>
                                <textarea name="comment" form="createPost-form">
                                Enter text here...</textarea
                                >
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
                groups: 'Computer',
                Drugs: 'Fishing',
                Computers: 'Studies',
            },
        }
    },
    methods: {
        showModal() {
            this.isModalVisible = true
        },

        closeModal() {
            this.isModalVisible = false
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
/* .navbar {
 
} */

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
/* 
.btn{
  display:inline-block;
  background: rgb(129, 129, 129);
  color: white;
} */

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
</style>
