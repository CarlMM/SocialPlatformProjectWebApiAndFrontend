import { createRouter, createWebHistory } from 'vue-router'
import Home from '/src/components/Home.vue'
import Post from '/src/components/Post.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/Post',
        name: 'Post',
        component: Post,
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router
