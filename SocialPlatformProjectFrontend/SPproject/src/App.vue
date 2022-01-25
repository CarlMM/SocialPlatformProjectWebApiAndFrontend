<template>
    <div>
        <createPost />
        <router-view />
    </div>
</template>

<script>
import createPost from './components/CreatePost.vue'
export default {
    components: {
        createPost,
    },
}
</script>

<style></style>
