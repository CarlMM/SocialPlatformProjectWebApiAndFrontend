<template>
    <div class="container">
        <div
            v-for="threads in GetThreads"
            :key="threads.Id"
            class="subforum-description">
            <div class="subforum-row">
                <div class="subforum-icon subforum-column center">
                    <i class="fas fa-laptop"></i>
                </div>
                <div class="subforum-description subforum-column">
                    <router-link type="button" :to="`/Post/${threads.id}`">
                    <!-- :to="{ name: 'Post'} -->
                        <h1>{{ threads.title }}</h1>
                    </router-link>
                    <h1>
                        <small>Posted by <a href="">User</a> 15 Jan 2022</small>
                    </h1>
                    <p>{{ threads.Text }}</p>
                    <button class="post-btn" @click="showModal(threads.Id)">Reply</button>
                    <button class="post-btn">Save</button>
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
                <div class="subforum-description subforum-column">
                    <h1>{{ this.threadTitle }}</h1>
                    <h1>
                        <small>Posted by <a href="">User</a> 15 Jan 2022</small>
                    </h1>
                    <p>{{ this.threadText }}</p>
                </div>
                <div id="container">
                    <div class="form-group">
                        <label for="reply-content">Add content</label>
                        <textarea
                            placeholder="Remember, be nice!"
                            cols="78"
                            rows="5"
                            v-model="replyMessage"
                        ></textarea>
                    </div>
                    <button class="btn btn-reply" @click="saveInput()">
                        Reply
                    </button>
                    <div v-for="error in errors" :key="error.id">
                        <ul>
                            <li>{{ error }}</li>
                        </ul>
                    </div>
                </div>
            </template>
        </Modal>
        </div>
    </div>
    <!-- <div class="container" >
    <div class="subform">
            <div class="subforum-title">
                <h1>General Information</h1>
            </div>
          </div>
          <div class="subforum-row">
                <div class="subforum-icon subforum-column center" > 
                    <i class="fas fa-laptop"></i>
                </div>
                <div class="subforum-description subforum-column">
                    <h1>Descriptiption Title <small>Posted by <a href="">User</a> 15 Jan 2022</small></h1>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lectus sit amet est placerat. Lacus viverra vitae congue eu consequat ac felis donec et. 
                      Tempus quam pellentesque nec nam aliquam sem et tortor. Mi proin sed libero enim. Purus non enim praesent elementum facilisis. Amet nisl purus in mollis nunc sed.</p>
                    <a class="post-link" href=""><router-link to="/Post">Reply</router-link></a>
                    <a class="post-link" href=""><router-link to="/">Save</router-link></a>
                </div>
          </div>
  </div> -->
</template>

<script>
import Modal from './Modal.vue'
// import { mapMutations } from 'vuex'

export default {
    posts:["thread"],
    components: {
        Modal,
    },
    data() {
        return {
            isModalVisible: false,
            cId: this.$route.params.id,
            catId: this.$route.params.Id,
            threadId: null,
            threadTitle: '',
            threadText: '',
            replyMessage: '',
            errors: [],
        }
    },

    beforeMounted(){
        this.GetThreads();
    },

    computed: {
        GetThreads() {
            let list = this.$store.state.Thread

            let filterlist = list.filter(item => {
                return item.CategoryId == this.cId
            })
            console.log(filterlist)
            return filterlist
        },
        GetCategory() {
            let categoryList = this.$store.state.Category

            let filterList = categoryList.filter(item => {
                return item.Id == this.catId
            })
            console.log('this is categorylist')
            console.log(filterList)
            return filterList
        },
    },
    methods: {
        showModal(threadId) {
            this.isModalVisible = true
            this.threadId = threadId
            let threadList = this.$store.state.Thread

            let specificThread = threadList.find(item => {
                return item.Id == this.threadId
            })

            //Destrucure objektet i variabler
            let { Id, Title, Text, CategoryId } = specificThread

            this.threadTitle = Title
            this.threadText = Text
        },

        closeModal() {
            this.errors == []
            this.replyMessage == '', (this.isModalVisible = false)
        },
        // ...mapMutations(['setReply']),
        saveInput() {
            // this.setReply(this.replyMessage)
            //Comment ---> create data spara message och date i ett objekt skicka till backend ingen aning vi ser.
            if (this.replyMessage == '') {
                this.errors = []
                this.errors.push('Please enter some text!')
            } else if (this.replyMessage != '') {
                this.errors = []
                this.closeModal()
            }
        },
    },
}
</script>

<style scoped>
* {
    box-sizing: border-box;
}

li {
    list-style: none;
}

a {
    color: rgb(153, 149, 163);
    font-weight: bolder;
}

p {
    color: white;
}

.post-link > a {
    color: white;
    padding-right: 10px;
    font-size: 12px;
}

h1 {
    font-size: 18px;
    font-weight: bolder;
    color: white;
}

/*Body*/
.container {
    width: 500vh;
    padding: 20px;
    background: rgb(173, 173, 173);
    border-radius: 5px;
    margin-bottom: 20px;
}

.subforum {
    margin-top: 20px;
}

.subforum-title {
    background-color: rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
}

.subforum-row {
    display: grid;
    grid-template-columns: 7% 93%;
}

.subforum-column {
    border-radius: 5px;
    margin: 4px;
    background-color: rgb(48, 48, 48);
}

.subforum-description {
    padding: 10px;
}

.center {
    display: flex;
    justify-content: center;
    align-items: center;
}

.subforum-icon {
    font-size: 30px;
}

/*Category*/
.category {
    margin-top: 20px;
}

.category-title {
    background-color: rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
    margin-bottom: 20px;
}

/* Style inside modal */
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
</style>
