import { createRouter, createWebHistory } from 'vue-router'
import Home from '/src/components/Home.vue'
import Post from '/src/PostPages/Post.vue'
import GroupPost from '/src/PostPages/GroupPost.vue'
import Computers from '/src/components/CategoryFolderPages/Computers.vue'
import Fishing from '/src/components/CategoryFolderPages/Fishing.vue'
import Studies from '/src/components/CategoryFolderPages/Studies.vue'
import MyProfile from '/src/components/ProfilePages/MyProfile.vue'
import MyGroups from '/src/components/ProfilePages/Mygroups.vue'
import MyThreads from '/src/components/ProfilePages/MyThreads.vue'
import MyReplies from '/src/components/ProfilePages/MyReplies.vue'
import AdminAllThreads from '../Views/Adminpages/AdminAllThreads.vue'
import AdminAllUsers from '../Views/Adminpages/AdminAllUsers.vue'
import AdminGroupThreads from '../Views/Adminpages/AdminGroupThreads.vue'
import NotAuthantication from '../Views/NotAuthorized.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/notauthorized',
        name: 'NotAuthantication',
        component: NotAuthantication,
    },
    {
        path: '/adminallthreads',
        name: 'AdminAllThreads',
        component: AdminAllThreads,
    },
    {
        path: '/adminallusers',
        name: 'AdminAllUsers',
        component: AdminAllUsers,
    },
    {
        path: '/admingroupthreads',
        name: 'AdminGroupThreads',
        component: AdminGroupThreads,
    },
    {
        path: '/Post/:Id',
        name: 'Post',
        component: Post,
    },
    {
        path: '/GroupPost/:id',
        name: 'GroupPost',
        component: GroupPost,
    },
    {
        path: '/Computer/:id',
        name: 'Computers',
        component: Computers,
        props: { data: null },
    },
    {
        path: '/Fishing/:id',
        name: 'Fishing',
        component: Fishing,
        props: { data: null },
    },
    {
        path: '/Studies/:id',
        name: 'Studies',
        component: Studies,
        props: { data: null },
    },
    {
        //Beh??vs inte /:id f??r denna
        path: '/MyProfile',
        name: 'MyProfile',
        component: MyProfile,
    },
    {
        //Beh??vs troligen ett /:id
        path: '/MyGroups',
        name: 'MyGroups',
        component: MyGroups,
    },
    {
        //Beh??vs troligen ett /:id
        path: '/MyThreads',
        name: 'MyThreads',
        component: MyThreads,
    },
    {
        path: '/MyReplies',
        name: 'MyReplies',
        component: MyReplies,
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router
