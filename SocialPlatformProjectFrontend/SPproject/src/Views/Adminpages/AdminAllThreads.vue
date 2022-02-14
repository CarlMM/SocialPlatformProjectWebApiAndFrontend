<template>
<h1 class="categories-h1">Admin Threads</h1>
    <div class="outer-box">
        <div
            v-for="threads in getGroupThreadsAdmin"
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
                                Posted {{setTime(threads.createdDate)}}
                            </p></span
                        >
                        <p>{{ threads.text }}</p>
                    </div>
                    <button class="btn-close" @click="RemoveThread(threads.id)">X</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { useAuth0, AuthState } from '../../auth0/useAuth0.js'
import dateclock from '/src/assets/js/dateclock.js'

export default {
    name: 'AdminAllThreads',
    data() {
        return {
            threadsList: [],
        }
    },
    created() {
        this.$store.dispatch('getAllThreads')
        if (AuthState.isAuthenticated == true || AuthState.isAuthenticated == false) {
            if (
                AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
            ) {
                this.$store.state.isAdmin = true
            } else {
                this.$router.push('/notauthorized')
            }
        }
    },
    computed: {
        getGroupThreadsAdmin() {
            let allThreadsAdmin = this.$store.state.Thread
            return allThreadsAdmin
        },
    },
    methods:{
        RemoveThread(id) {
            let deleteConfirm = 'Are u sure you want to delete thread?'
            if(confirm(deleteConfirm) == true){
                //Removes Id specific to thread
                this.$store.dispatch('delelteSpecificThread', id)
    
                let threadId = id
                //Fetch the list of userThread
                let list = this.$store.state.Thread
                //Goes through the list, filter it and check for what is no longer there
                let updatedList = list.filter(item => {
                    return item.id !== threadId
                })
                this.$store.commit('updateSpecificThreadAfterDelete', updatedList)
            }
            else{
                
            }
        },
        setTime(date){
            return dateclock.DateOfCreation(date)
        }
    }
    // beforeMounted(){

    // }
}
</script>

<style>
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

@media (max-width: 900px) {
    .subforum-icon > img {
        min-width: 60px;
    }
}

.element {
    box-shadow: none;
}

.element:hover,
element:active {
    box-shadow: 0 0 5px #fff, inset 0 0 10px #43a78c;
}

/* btn-close*/

.btn-close {
    position: absolute;
    right: 4vw;
    font-size: 20px;
    margin: -55px 0;
    padding:0;
    cursor: pointer;
    color:#fff;
    font-weight: bold;
    background: transparent;
}
</style>
