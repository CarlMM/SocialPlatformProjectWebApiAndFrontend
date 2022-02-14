<template>
    <div class="userTemplate">
        <h1 class="highlight">Users from database</h1>
        <div class="users database" v-for="user in this.$store.state.listOfUsersAdmin" :key="user.id">
            <div class="user">
                <h2>Username: {{ user.username }}</h2>
                <h2>Email: {{ user.email }}</h2>
                <button class="btn-close"  @click="deleteUser(user.idSub)" type="button">
                    X
                </button>
            </div>
        </div>
        <h1 class="highlight" >User from Autho</h1>
        <div class="users" v-for="user in this.$store.state.Auth0ListUsers" :key="user.user_id">
            <div class="user">
                <h2>{{ user.user_id }}</h2>
                <h2>{{ user.email }}</h2>
                <h2>{{ user.username }}</h2>
                <button class="btn-close"  @click="removeUserFromAuth0(user.user_id)" type="button">
                    X
                </button>
            </div>
        </div>
    </div>
    <!-- <div v-for="user in this.$store.state.listOfUsersAdmin" :key="user.id">
        <h3>{{ user.username }} USER FROM DATABASE</h3>
        <h3>{{ user.email }}</h3>
        <button @click="deleteUser(user.idSub)" type="button">
            Delete user
        </button>
    </div>
    <div v-for="user in this.$store.state.Auth0ListUsers" :key="user.user_id">
        <h3>{{ user.user_id }}</h3>
        <h3>{{ user.email }}</h3>
        <h3>{{ user.username }}</h3>
        <button @click="removeUserFromAuth0(user.user_id)" type="button">
            Radera användare
        </button>
    </div> -->
</template>

<script setup>
 import { useAuth0, AuthState } from '/src/auth0/useAuth0.js'

const { initAuth } = useAuth0(AuthState)

initAuth()
</script>  

<script>
export default {
    name: 'AdminAllUsers.vue',
    beforeMount() {
        this.fetchAllUsers()
    },

    created() {
        this.$store.commit('setToken', AuthState.token)
        if (AuthState.isAuthenticated == true || AuthState.isAuthenticated == false) {
            if (
                AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
            ) {
                this.$store.state.isAdmin = true
                this.fetchAllUsers()
            } else {
                this.$router.push('/notauthorized')
            }
        }
    },
    methods: {
        fetchAllUsers() {
            this.$store.dispatch('getAllUsersAdmin')
            this.$store.dispatch('Auth0GetAllUsers')
        },
        removeUserFromAuth0(userSubId) {
            console.log('we are in the method')
            console.log(userSubId, 'usersubId i metodem')
            this.$store.dispatch('Auth0DeleteUser', userSubId)
        },
        deleteUser(userId) {
            //Removes Id specific to thread
            this.$store.dispatch('deleteUserAsAdmin', userId)

            let userSubId = userId
            //Fetch the list of userThread
            let list = this.$store.state.listOfUsersAdmin
            //Goes through the list, filter it and check for what is no longer there
            let updatedList = list.filter(item => {
                return item.idSub !== userSubId
            })
            this.$store.commit('updateUserListAfterDelete', updatedList)
        },
    },
}
</script>

<style scoped>

.userTemplate{
    position:relative;
    overflow:auto;
    max-height: 75vh;
    background-color:#303030;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    border-radius: 4px;
    color:white;
}

.highlight{
    font-size: 32px;
    padding: 10px 20px;
    background-color:#777777;
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}

.users{
    display:flex;
    align-content: flex-start;
    padding: 10px 20px;
}

.user{
    border-bottom:1px solid #fff;
}


.database{
    background:#656a83;
}

.user > h2{
    font-size: 24px;
    padding:0;
    margin:0;
}

/* close button */
.btn-close {
    position: absolute;
    right: 1vw;
    font-size: 20px;
    margin: -70px 0;
    cursor: pointer;
    color:#fff;
    font-weight: bold;
    background: transparent;
}
</style>
