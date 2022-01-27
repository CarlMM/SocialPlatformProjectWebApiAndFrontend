<template>
    <header>
        <div class="navbar">
            <nav class="navigation">
                <ul class="nav-menu">
                    <li class="nav-item">
                        <router-link to="/Studies">Studies</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/Fishing">Fishing</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/Computers">Computer</router-link>
                    </li>
                </ul>
            </nav>
            <div class="d-flex justify-content-end mt-1">
                <button
                    style="color: blue"
                    type="button"
                    class="btn"
                    @click="showModal()"
                >
                    Create Post
                </button>
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
                                    <div class="nav-left">
                                        <a href="#Home">Post</a>
                                        <a href="#Home">Group post</a>
                                    </div>
                                    <div class="nav-right form-group">
                                        <label for="category">Category</label>
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

                        <!-- <CreatePost /> -->
                    </template>
                </Modal>
            </div>
            <!-- <div class="Thread-position">
            <Thread/>
        </div> -->
        </div>
    </header>
</template>

<script>
import Modal from './Modal.vue'
import CreatePost from './CreatePost.vue'
import Dropdown from './Dropdown.vue'
// import Thread from './Thread.vue'

// export default {
//     components: {
//         Thread,
//     },
// }
export default {
    components: {
        Modal,
        CreatePost,
        Dropdown,
    },
    data() {
        return {
            isModalVisible: false,
            category: {
                groups: 'groups',
                Drugs: 'Drugs',
                Computers: 'Computers',
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
}
</script>

<style scoped>
/*navbar*/

.header {
    margin-inline: 10px;
}

.navbar {
    margin: 20px;
    display: flex;
    align-items: center;
    background: #33393a;
}

.navigation {
    padding: 10px;
    width: 65%;
    display: inline-block;
    max-height: 12vh;
    margin-right: 10px;
}

.nav-menu {
    list-style-type: none;
    overflow: hidden;
}

.nav-menu a {
    float: right;
    display: block;
    text-align: center;
    margin-inline: 20px;
    font-size: 20px;
    padding: 10px;
    color: #fff;
}

/* FORM STYLE INSIDE MODAL */

#container {
    margin: 30px auto;
    max-width: 600px;
    /* border: 1px solid red; */
}

.form-group {
    /* margin-top: 10px; */
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

/* .Thread-position{
} */
</style>
