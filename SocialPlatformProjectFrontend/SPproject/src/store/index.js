import { createStore } from 'vuex'

const store = createStore({
    state: {
        GroupThreads: [],
        Category: [
            // {
            //         id: 1,
            //         title: 'Computer',
            //         description: 'Bla bla bla Computers',
            //     },
            //     {
            //         id: 2,
            //         title: 'Fishing',
            //         description: 'Bla bla bla Fishing',
            //     },
            //     {
            //         id: 3,
            //         title: 'Studies',
            //         description: 'Bla bla bla Studies',
            // },
        ],

        Thread: [
            // {
            //     id: 1,
            //     title: 'Will computers take over the world?',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 1,
            // },
            // {
            //     id: 2,
            //     title: 'Will computers NOT take over the world?',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 1,
            // },
            // {
            //     id: 3,
            //     title: 'Will Mike ever NOT discuss things?',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 3,
            // },
            // {
            //     id: 4,
            //     title: 'How good is Newton?',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 3,
            // },
            // {
            //     id: 5,
            //     title: 'I swear look at this fish?',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 2,
            // },
            // {
            //     id: 6,
            //     title: 'Do studies make you depressed?',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 3,
            // },
            // {
            //     id: 7,
            //     title: 'STUDIES MAKE YOU RICH INVEST EVERYTHING',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 3,
            // },
            // {
            //     id: 8,
            //     title: 'Super computer 30000',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 1,
            // },
            // {
            //     id: 9,
            //     title: 'BIG FISH THREAD',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 2,
            // },
            // {
            //     id: 10,
            //     title: 'WALLE - E MIKE EDITION',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 1,
            // },
            // {
            //     id: 11,
            //     title: 'MIKES FISH IS AMAZING MICROTRANSISTIONS',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 2,
            // },
            // {
            //     id: 12,
            //     title: 'Study more, earn less',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 3,
            // },
            // {
            //     id: 13,
            //     title: 'Fish Fish Fish',
            //     text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
            //     categoryId: 2,

            // },
        ],

        Reply: [
            
        ],
    },
    mutations: {
       
        setNewPost(state, data) {
            console.log('inne i setNewPostMutatuon: ', data)
            state.Thread.push(data)
            console.log(state.Thread)
        },
        setThreadsFromBack(state, data) {
            state.Thread = data
        },

        setCategoriesFromBackend(state, data) {
            state.Category = data
            console.log(data)
        },
        setRepliesFromBacked(state, data) {
            state.reply = data
            console.log(data)
        },

        setUserFromBack(state, data) {
            state.User = data
            console.log(data)
        },
        setUsersFromBack(state, data) {
            state.Users = data
            console.log(data)
        },
        setThreadUserFromBack(state, data) {
            state.ThreadUser = data
            console.log(data)
        },

        setReplyToSpecificPost(state, data){
            state.Reply = data;
            console.log('Vi är i mutation nu ',  data)
        }
    },
    actions: {
        createNewPostMethod({ commit }, newPostObject) {
            console.log('Inne i createNewPostMethod action: ', newPostObject)

            commit('setNewPost', newPostObject)
        },
        async getAllThreads({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/CategoryThread/GetCategoryThreads'
            )
            let data = await response.json()

            console.log(data)

            commit('setThreadsFromBack', data)
        },

        async getAllCategories({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/Category/GetCategories'
            )
            let data = await response.json()
            console.log(data)
            commit('setCategoriesFromBackend', data)
        },

        async GetRepliesForSpecificPost({ commit }, id){
            let response = await fetch(`https://localhost:44300/api/Reply/GetReply/${id}`)

            let data = await response.json();
            console.log('GetRepliesForSpecificPost Action: ', data)
            commit('setReplyToSpecificPost', data);
        },

        async GetAllReplies({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/Reply/GetReplies'
            )
            let data = await response.json()
            console.log(data)
            commit('setRepliesFromBacked', data)
        },

        async GetUser({ commit }) {
            let response = await fetch('')
            let data = await response.json()
            console.log(data)
            commit('setUserFromBack', data)
        },

        async getAllUsers({ commit }) {
            let response = await fetch('')
            let data = await response.json()
            console.log(data)
            commit('setUsersFromBack', data)
        },

        async getThreadUser({ commit }) {
            let response = await fetch('')
            let data = await response.json()
            console.log(data)
            commit('setThreadUserFromBack', data)
        },

        // async getAllThreadByUser({commit}, userId){
        //     let response = await fetch('https://localhost:44300/api/Threads/GetThreadsByUser' + userId);
        //     let data = await response.json()

        //     console.log(data)
        //     commit('setInMutation' , data)
        // }
    },
})

export default store
