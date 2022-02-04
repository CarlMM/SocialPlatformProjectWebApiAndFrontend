<template>
    <div class="outer-box">
        <div
            v-for="threads in list"
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
                    <button class="post-btn">
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
                    <button class="post-btn">
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

    created() {
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
    margin-bottom: 20px;
}

.subforum {
    margin-top: 20px;
}

/* .subforum-title {
    background-color: rgb(119, 119, 119);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
} */

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
    height: 95%;
    width: 95%;
    border-radius: 3px;
}

.element {
    box-shadow: none;
}

.element:hover,
element:active {
    box-shadow: 0 0 5px #fff, inset 0 0 10px #43a78c;
}

/*Buttons in thread */
.post-btn {
    height: 35px;
    padding: 0 15px;
    background: inherit;
    color: #ffff;
    border: none;
    user-select: none;
    white-space: nowrap;
    transition: all 0.05s linear;
    font-family: inherit;
}

.post-btn:active {
    color: #3f99e7;
    box-shadow: 0 0.2rem #3f99e7;
    transform: translateY(0.2rem);
}

.post-btn:disabled {
    cursor: auto;
    color: grey;
}

.icon {
    font-size: 20px;
    margin-right: 10px;
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
</style>
