import { createStore } from 'vuex'

const store = createStore({
    state: {
        GroupThreads: [],
        Category: [
            {
                    id: 1,
                    title: 'Computer',
                    description: 'Bla bla bla Computers',
                },
                {
                    id: 2,
                    title: 'Fishing',
                    description: 'Bla bla bla Fishing',
                },
                {
                    id: 3,
                    Title: 'Studies',
                    description: 'Bla bla bla Studies',
            },
        ],

        Thread: [
            {

                id: 1,
                title: 'Will computers take over the world?',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 1,
            },
            {
                id: 2,
                title: 'Will computers NOT take over the world?',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 1,
            },
            {
                id: 3,
                title: 'Will Mike ever NOT discuss things?',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 3,
            },
            {
                id: 4,
                title: 'How good is Newton?',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 3,
            },
            {
                id: 5,
                title: 'I swear look at this fish?',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 2,
            },
            {
                id: 6,
                title: 'Do studies make you depressed?',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 3,
            },
            {
                id: 7,
                title: 'STUDIES MAKE YOU RICH INVEST EVERYTHING',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 3,
            },
            {
                id: 8,
                title: 'Super computer 30000',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 1,
            },
            {
                id: 9,
                title: 'BIG FISH THREAD',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 2,
            },
            {
                id: 10,
                title: 'WALLE - E MIKE EDITION',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 1,
            },
            {
                id: 11,
                title: 'MIKES FISH IS AMAZING MICROTRANSISTIONS',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 2,
            },
            {
                id: 12,
                title: 'Study more, earn less',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 3,
            },
            {
                id: 13,
                title: 'Fish Fish Fish',
                text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                categoryId: 2,
=======
                Id: 1,
                Title: 'Will computers take over the world?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 2,
                Title: 'Will computers NOT take over the world?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 3,
                Title: 'Will Mike ever NOT discuss things?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 4,
                Title: 'How good is Newton?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 5,
                Title: 'I swear look at this fish?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
            {
                Id: 6,
                Title: 'Do studies make you depressed?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 7,
                Title: 'STUDIES MAKE YOU RICH INVEST EVERYTHING',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 8,
                Title: 'Super computer 30000',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 9,
                Title: 'BIG FISH THREAD',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
            {
                Id: 10,
                Title: 'WALLE - E MIKE EDITION',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 11,
                Title: 'MIKES FISH IS AMAZING MICROTRANSISTIONS',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
            {
                Id: 12,
                Title: 'Study more, earn less',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 13,
                Title: 'Fish Fish Fish',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
        ],

        reply: [
            {
                id: 1,
                text: 'reply to thread id 2',
                createdDate: '2022-01-01',
                userId: 22,
                threadId: 2,
            },
            {
                id: 2,
                text: 'reply to thread id 1',
                createdDate: '2022-01-01',
                userId: 22,
                threadId: 1,
            },
            {
                id: 1,
                text: 'reply to thread id 3',
                createdDate: '2022-01-01',
                userId: 22,
                threadId: 3,
            },
            // {
            //     Id: 1,
            //     Text: 'reply to thread id 4',
            //     CreatedDate: '2022-01-01',
            //     UserId: 22,
            //     ThreadId: 4,
            // },
            // {
            //     Id: 1,
            //     Text: 'reply to thread id 5',
            //     CreatedDate: '2022-01-01',
            //     UserId: 22,
            //     ThreadId: 5,
            // },
            // {
            //     Id: 1,
            //     Text: 'reply to thread id 6',
            //     CreatedDate: '2022-01-01',
            //     UserId: 22,
            //     ThreadId: 6,
            // },
            // {
            //     Id: 1,
            //     Text: 'reply to thread id 7',
            //     CreatedDate: '2022-01-01',
            //     UserId: 22,
            //     ThreadId: 7,
            // },
            // {
            //     Id: 1,
            //     Text: 'reply to thread id 8',
            //     CreatedDate: '2022-01-01',
            //     UserId: 22,
            //     ThreadId: 8,
            // },
            // {
            //     Id: 1,
            //     Text: 'reply to thread id 9',
            //     CreatedDate: '2022-01-01',
            //     UserId: 22,
            //     ThreadId: 9,
            // },
            // {
            //     Id: 1,
            //     Text: 'reply to thread id 10',
            //     CreatedDate: '2022-01-01',
            //     UserId: 22,
            //     ThreadId: 10,
            // },
        ],
    },
    mutations: {
        setReply(state, value) {
            state.reply = value
        },
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
    },
    actions: {
        createNewPostMethod({ commit }, newPostObject) {
            console.log('Inne i createNewPostMethod action: ', newPostObject)

            commit('setNewPost', newPostObject)
        },
        async getAllThreads({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/Thread/GetThreads'
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

        async GetAllReplies({ commit }) {
            let response = await fetch(
                'https://localhost:44300/Reply/GetReplies'
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
