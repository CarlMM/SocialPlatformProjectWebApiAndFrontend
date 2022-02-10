<template>
    <div
        v-for="threads in this.$store.state.groupThreadsAdmin"
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
                    <router-link type="button" :to="`/GroupPost/${threads.id}`">
                        <h1>{{ threads.title }}</h1>
                    </router-link>
                    <span
                        ><p>
                            Posted by <a href="#"> User </a> 15 jan 2022
                        </p></span
                    >
                    <p>{{ threads.text }}</p>
                </div>
                <button class="btn-close" @click="RemoveThread(threads.id)">X</button>
            </div>
            
        </div>
    </div>
</template>

<script>
import { useAuth0, AuthState } from '../../auth0/useAuth0.js'
export default {
    name: 'AdminGroupThreads.vue',



    data(){
        return{
            confirm: true,
            notConfirm: false,
        }
    },
    created() {
        this.$store.dispatch('getAllGroupThreadsAdmin')

        if (AuthState.isAuthenticated == true) {
            if (
                AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
            ) {
                this.$store.state.isAdmin = true
            } else {
                this.$router.push('/notauthorized')
            }
        }
    },
    methods:{
        
        fetchAllGroupThreads(){
            return this.$store.dispatch('getAllGroupThreadsAdmin')
        },
        RemoveThread(idToRemove){
            let deleteConfirm = 'are u sure you want to delete thread?'
            if(confirm(deleteConfirm) == true){
                
                //Removes Id specific to thread
                this.$store.dispatch('delelteSpecificThread', idToRemove)
    
                let threadId = idToRemove
                //Fetch the list of userThread
                let list = this.$store.state.groupThreadsAdmin
                //Goes through the list, filter it and check for what is no longer there
                let updatedList = list.filter(item => {
                    return item.id !== threadId
                })
                this.$store.commit('updateSpecificThreadAfterDelete', updatedList)
            }
            else{
               
            }
        }
    },

    computed: {
        getGroupThreadsAdmin() {
            // let groupThreadsAdmin = this.$store.dispatch(
            //     'getAllGroupThreadsAdmin'
            // )
            // console.log(groupThreadsAdmin, 'grupptrådar adminpage')
            return this.$store.dispatch('getAllGroupThreadsAdmin')
        },
    },
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

.outer-box {
    background: #484848;
    border-radius: 5px;
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


/*close button */
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
