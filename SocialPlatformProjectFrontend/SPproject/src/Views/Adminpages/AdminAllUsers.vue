<template>
    <div v-for="user in this.$store.state.listOfUsersAdmin" :key="user.id">
        <h3>{{ user.username }}</h3>
        <h3>{{ user.email }}</h3>
    </div>
</template>

<script>
export default {
    name: 'AdminAllUsers.vue',
    computed: {
        getAllUsersAdmin() {
            return this.$store.dispatch('getAllUsersAdmin')
        },
    },
    created() {
        this.$store.dispatch('getAllUsersAdmin')
    },
}
</script>

<style scoped>
h3 {
    color: #fff;
}
</style>
