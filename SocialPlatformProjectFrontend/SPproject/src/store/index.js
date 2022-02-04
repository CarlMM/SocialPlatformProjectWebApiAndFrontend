import { createStore } from 'vuex'

const store = createStore({
    state: {
        comingFromThreads: false,
        isAdmin: false,
        GroupThreads: [],
        UserThread:[],
        Category: [],
        Thread: [],
        Reply: [],
        SpecificPostThread:[], 
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
        },
        setUserThreads(state, data){
            state.UserThread = data;
            console.log('userThreads: ', data)
        },
        setSpecificPostFromThread(state, data){
            state.SpecificPostThread = data;
            console.log('SpecificPostThreadMutation: ', data)
        },
        deleteSpecificThread(state, data){
            state.UserThread = data;
            state.UserThread.push(data)
            console.log(data);
        }
    },
    actions: {
        createNewPostMethod({ commit }, newPostObject) {
            console.log('Inne i createNewPostMethod action: ', newPostObject)

            commit('setNewPost', newPostObject)
        },


        async getAllThreads({ commit })
        {
            let response = await fetch('https://localhost:44300/api/CategoryThread/GetCategoryThreads')
                let data = await response.json()
                
                console.log(data)
                commit('setThreadsFromBack', data)
        },
            

        async GetThreadFromSpecificId({commit}, id)
        {
                let response = await fetch(`https://localhost:44300/api/CategoryThread/GetCategoryThreadById/${id}`)
                    let data = await response.json()
                    
                    console.log('GetThreadFromSpecificId Action: ', data)
                    commit('setSpecificPostFromThread', data)
        },

        async delelteSpecificThread({commit}, id){
                    let response = await fetch(`https://localhost:44300/api/CategoryThread/DeleteCategoryThread/${id}`,{
                        method:'delete',
                        headers:{'Content-type': 'application/json'},
                        body: JSON.stringify(this.state.UserThread)
                    })
                    let data = await response.json()
                    console.log(data, 'I action')
        
                    commit('deleteSpecificThread', data)
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
            let response = await fetch(`https://localhost:44300/api/Reply/GetReplyByCategoryThreadId/${id}`)

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

        async GetThreadsFromUser({commit}, userId){
            let response = await fetch(`https://localhost:44300/api/CategoryThread/GetCategoryThreadByUserId/${userId}`)
            
            let data = await response.json();
            console.log(data)
            commit('setUserThreads', data)
        },

        async GetUser({ commit }) {
            let response = await fetch('')
            let data = await response.json()
            console.log(data)
            commit('setUserFromBack', data)
        },

        async getAllUsers({ commit }) {
            let response = await fetch('https://localhost:44300/api/User/GetUsers')
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
