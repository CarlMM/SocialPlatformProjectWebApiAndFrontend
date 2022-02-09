<template>
    <div v-for="user in this.$store.state.listOfUsersAdmin" :key="user.id">
        <h3>{{ user.username }}</h3>
        <h3>{{ user.email }}</h3>
        <button @click="deleteUser(user.idSub)" type="button">
            Delete user
        </button>
    </div>
    <!-- <div v-for="user in this.$store.state.Auth0ListUsers" :key="user.user_id">
        <h3>{{ user.user_id }}</h3>
        <h3>{{ user.email }}</h3>
        <h3>{{ user.username }}</h3>
    </div> -->
</template>

<script>
export default {
    name: 'AdminAllUsers.vue',
    beforeMount() {
        this.fetchAllUsers()
    },

    created() {
        this.fetchAllUsers()
    },
    methods: {
        fetchAllUsers() {
            this.$store.dispatch('getAllUsersAdmin')
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
h3 {
    color: #fff;
}
</style>
