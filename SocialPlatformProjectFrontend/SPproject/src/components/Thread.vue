<template>
    <div class="outer-box">
        <button class="btn-close" @click="goHome()">X</button>
        <div
            v-for="threads in list"
            :key="threads.Id"
            class="subforum-description">
            <div class="subforum-row element">
                <div class="subforum-icon subforum-column center">
                    <img
                        src="https://via.placeholder.com/300.png/ https://placeholder.com/ " alt=""/>
                </div>
                <div class="subforum-description subforum-column">
                    <div class="text">
                        <router-link type="button" :to="`/Post/${threads.id}`">
                            <h1>{{ threads.title }}</h1>
                        </router-link>
                        <span
                            ><p>
                                Posted by <a href="#"> User </a> 15 jan 2022
                            </p></span>
                        <p>{{ threads.Text }}</p>
                    </div>
                    <button class="post-btn" @click="goPost(threads.id)">
                        <i class="far fa-comment icon"></i>
                        <span>Comment</span>
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
        </div>
        <div
            v-for="threads in GetThreads"
            :key="threads.Id"
            class="subforum-description"
        >
            <div class="subforum-row element">
                <div class="subforum-icon subforum-column center">
                    <img
                        src="https://via.placeholder.com/300.png/ https://placeholder.com/ "
                        alt=""
                    />
                </div>
                <div class="subforum-description subforum-column">
                    <div class="text">
                        <router-link type="button" :to="`/Post/${threads.id}`">
                            <h1>{{ threads.title }}</h1>
                        </router-link>
                        <span
                            ><p>
                                Posted by <a href="#"> User </a> 15 jan 2022
                            </p></span
                        >
                        <p>{{ threads.Text }}</p>
                    </div>
                    <button class="post-btn" @click="goPost(threads.id)">
                        <i class="far fa-comment icon"></i>
                        <span>Comment</span>
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
        </div>
    </div>
</template>

<script>
import Modal from './Modal.vue'
// import { mapMutations } from 'vuex'
import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'


export default {
    posts: ['thread'],
    props: ['list'],
    components: {},
    data() {
        return {
            cId: this.$route.params.id,
            catId: this.$route.params.Id,
        }
    },


    created(){
        this.$store.commit('setToken', AuthState.token)

        this.$store.dispatch('getAllThreads')
    },

    computed: {
        GetThreads() {
            let list = this.$store.state.Thread

            let filterlist = list.filter(item => {
                return item.categoryId == this.cId
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
    methods:{
        goPost(id){
            this.$router.push('/Post/' + id)
            this.$store.state.comingFromThreads = true
        },
        goHome(){
        this.$router.push('/')
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
    font-weight: 300;
    text-decoration: none;
}

.text {
    margin-left: 5px;
    margin-top: 20px;
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
.outer-box {
    background: #484848;
    border-radius: 5px;
    padding-top:60px;
}

.subforum {
    margin-top: 20px;
}

.subforum-row {
    display: grid;
    grid-template-columns: 10% 90%;
}


.subforum-column {
    background-color: rgb(48, 48, 48);
}

.subforum-description {
    padding: 1px;
}

.center {
    display: flex;
    justify-content: center;
    align-items: center;
}

.subforum-icon > img {
    height: 100%;
    min-width: 80px;
    border-radius: 3px;
}

@media(max-width: 900px){
    .subforum-icon > img{
        min-width: 60px;
    }
}


/*Category*/
.category {
    margin-top: 20px;
}

.category-title {
    background-color: rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin-bottom: 20px;
}

/*button changes */

.post-btn{
    padding-top:5.7vh;
}

/*btn-close */
.btn-close{
    padding: 10px 20px;
}

</style>
