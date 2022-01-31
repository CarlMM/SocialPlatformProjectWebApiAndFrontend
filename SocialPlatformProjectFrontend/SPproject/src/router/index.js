import { createRouter, createWebHistory } from 'vue-router'
import Home from '/src/components/Home.vue'
import Post from '/src/components/Post.vue'
import Computers from '/src/components/CategoryFolderPages/Computers.vue'
import Fishing from '/src/components/CategoryFolderPages/Fishing.vue'
import Studies from '/src/components/CategoryFolderPages/Studies.vue'
import MyProfile from '/src/components/ProfilePages/MyProfile.vue'
import MyGroups from '/src/components/ProfilePages/MyGroups.vue'
import MyThreads from '/src/components/ProfilePages/MyThreads.vue'


const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/Post/:Id',
        name: 'Post',
        component: Post,
    },
    {
        path: '/Computer/:id',
        name: 'Computers',
        component: Computers,
    },
    {
        path: '/Fishing/:id',
        name: 'Fishing',
        component: Fishing,
    },
    {
        path: '/Studies/:id',
        name: 'Studies',
        component: Studies,
    },
    {
        path: '/MyProfile',
        name: 'MyProfile',
        component: MyProfile,
    },
    {
        path: '/MyGroups',
        name: 'MyGroups',
        component: MyGroups,
    },
    {
        path: '/MyThreads',
        name: 'MyThreads',
        component: MyThreads,
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router
