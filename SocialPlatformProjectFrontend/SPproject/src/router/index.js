import { createRouter, createWebHistory } from 'vue-router'
import Home from '/src/components/Home.vue'
import Post from '/src/components/Post.vue'
import Computers from '/src/components/CategoryFolderPages/Computers.vue'
import Fishing from '/src/components/CategoryFolderPages/Fishing.vue'
import Studies from '/src/components/CategoryFolderPages/Studies.vue'

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
    {
        path: '/Fishing/:id',
        name: 'Fishing',
        component: Fishing,
    },
    {
        path: '/Computers/:id',
        name: 'Computers',
        component: Computers,
    },
    {
        path: '/Studies/:id',
        name: 'Studies',
        component: Studies,
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router
