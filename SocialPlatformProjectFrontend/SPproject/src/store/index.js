import { createStore } from 'vuex'

const store = createStore({
    state: {
        token: '',
        comingFromThreads: false,
        isAdmin: false,
        GroupThreads: [],
        UserThread: [],
        Category: [],
        Thread: [],
        Reply: [],
        SpecificPostThread: [],
        groupThreadsAdmin: [],
        Users: [],
        listOfUsersAdmin: [],
        // Auth0ListUsers: [],
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

        fetchReplyToSpecificPost(state, data) {
            state.Reply = data
            console.log('Vi är i mutation nu ', data)
        },

        setGroupThreadsAdmin(state, data) {
            state.groupThreadsAdmin = data
        },

        setNewReplyToPost(state, data) {
            state.Reply.push(data)
            //state.Reply = data;
        },

        setUserThreads(state, data) {
            state.UserThread = data
        },
        setSpecificPostFromThread(state, data) {
            state.SpecificPostThread = data
        },

        updateSpecificThreadAfterDelete(state, data) {
            state.UserThread = data
        },
        deleteSpecificThread(state, data) {
            state.UserThread.sort(data)
        },

        setAllUsersAdmin(state, data) {
            state.listOfUsersAdmin = data
        },

        updateUserListAfterDelete(state, data) {
            state.listOfUsersAdmin = data
        },

        AsAdminDeleteUser(state, data) {
            state.listOfUsersAdmin.sort(data)
        },

        setToken(state, data) {
            state.token = data
            console.log(data)
        },
        // Auth0SetAllUsers(state, data) {
        //     state.Auth0ListUsers = data
        // },
        setNewUser(state, data) {
            state.Users = data
            console.log(data)
        },
    },
    actions: {
        async createNewPostMethod({ commit }, newPostObject) {
            //console.log('Inne i createNewPostMethod action: ', newPostObject)

            let response = await fetch(
                `https://localhost:44300/api/CategoryThread/AddCategoryThread/${newPostObject}`,
                {
                    method: 'post',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(newPostObject),
                }
            )

            let data = await response.json()
            console.log(data)
            commit('setNewPost', data)
        },

        // async Auth0GetAllUsers({ commit }) {
        //     let response = await fetch(
        //         'https://dev-dzje4s8y.us.auth0.com/api/v2/users',
        //         {
        //             method: 'get',
        //             headers: {
        //                 Authorization: `Bearer ${'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InNUX3otUzR1SVdlcFA5Q0NtNjNMMSJ9.eyJodHRwOi8vbG9jYWxob3N0OjMwMDAvcm9sZXMiOlsiQWRtaW5Vc2VyIl0sImlzcyI6Imh0dHBzOi8vZGV2LWR6amU0czh5LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHw2MWY3YzYxMDQ1MzdmMjAwNmU3YjJjMTciLCJhdWQiOlsiaHR0cHM6Ly9hdXRoMHN1Y2tzL2FwaSIsImh0dHBzOi8vZGV2LWR6amU0czh5LnVzLmF1dGgwLmNvbS91c2VyaW5mbyJdLCJpYXQiOjE2NDQzOTcxOTAsImV4cCI6MTY0NDQ4MzU5MCwiYXpwIjoiTUVHMWF6b3FtNnZNVTgxbFlLdTU0Y0JvOG16QktTUTAiLCJzY29wZSI6Im9wZW5pZCBwcm9maWxlIGVtYWlsIiwicGVybWlzc2lvbnMiOlsiZGVsZXRlOnVzZXIiLCJyZWFkOnNwZWNpZmljQ2F0ZWdvcnlUaHJlYWRzIl19.WYcY5zdmOif2ragKFqNxUkArTmBRdwERBMfkBUks0LJu2IhHn98LDXsTd2EorByCEohyrLOmGP9GcPxNqM2sO_C-UB7rnBerAWtgrcHpgWamjtbkCe0YGv9tWLuo3PweWYZ4v_fFq665vH82-4GvaaTCWljZqt2JQB7sedR6PdF14Bl-e6j9_1Zkc7sDzTxzAcQOOz0gudWnaIKw8BuNnkLiP9-WTbKGpCuOfJRyk2sJLAZBCTizvqWmhFRt-OfOcZeVQSyKf2fWWb5-qlQ8lZSYAuQT6v6WDg02xF7d5K-7v2a-9cPhsfw9BTNlkVd1BDcbpI2YwoUNkubVqZjA-A'}`,
        //                 'Content-type': 'application/json',
        //             },
        //         }
        //     )
        //     let data = await response.json()
        //     console.log('i Action Auth0 get all users', data)
        //     console.log(this.state.token, 'this state token')
        //     commit('Auth0SetAllUsers', data)
        // },

        async getAllUsersAdmin({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/User/GetUsers',
                {
                    method: 'get',
                }
            )
            let data = await response.json()
            commit('setAllUsersAdmin', data)
        },

        async deleteUserAsAdmin({ commit }, userIdSub) {
            let response = await fetch(
                `https://localhost:44300/api/User/DeleteUserByIdSub/${userIdSub}`,
                {
                    method: 'delete',
                    headers: { 'Content-type': 'application/json' },
                }
            )
            let data = await response.json()
            commit('AsAdminDeleteUser', data)
        },

        async getAllGroupThreadsAdmin({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/CategoryThread/GetCategoryThreadByThreadType/true',
                {
                    method: 'get',
                    // headers: {
                    //     Authorization: 'Bearer ' + this.state.token,
                    //     'Content-type': 'application/json',
                    // },
                    //body: JSON.stringify(this.state.token)
                }
            )
            let data = await response.json()

            console.log(data)
            commit('setGroupThreadsAdmin', data)
        },

        async getAllThreads({ commit }) {
            //console.log(this.state.token)
            let response = await fetch(
                'https://localhost:44300/api/CategoryThread/GetCategoryThreadByThreadType/false',
                {
                    method: 'get',
                    headers: {
                        Authorization: 'Bearer ' + this.state.token,
                        'Content-type': 'application/json',
                    },
                    //body: JSON.stringify(this.state.token)
                }
            )
            let data = await response.json()

            console.log(data)
            commit('setThreadsFromBack', data)
        },

        async GetThreadFromSpecificId({ commit }, id) {
            let response = await fetch(
                `https://localhost:44300/api/CategoryThread/GetCategoryThreadById/${id}`
            )
            let data = await response.json()

            console.log('GetThreadFromSpecificId Action: ', data)
            commit('setSpecificPostFromThread', data)
        },

        async delelteSpecificThread({ commit }, id) {
            let response = await fetch(
                `https://localhost:44300/api/CategoryThread/DeleteCategoryThread/${id}`,
                {
                    method: 'delete',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(this.state.UserThread),
                }
            )
            let data = await response.json()
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

        async GetRepliesForSpecificPost({ commit }, id) {
            let response = await fetch(
                `https://localhost:44300/api/Reply/GetReplyByCategoryThreadId/${id}`
            )

            let data = await response.json()
            console.log('GetRepliesForSpecificPost Action: ', data)
            commit('fetchReplyToSpecificPost', data)
        },

        async PostReplyToSpecificPost({ commit }, replyObject) {
            let response = await fetch(
                `https://localhost:44300/api/Reply/AddReply/${replyObject}`,
                {
                    method: 'post',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(replyObject),
                }
            )

            let data = await response.json()
            console.log(data)
            commit('setNewReplyToPost', data)
        },

        async GetAllReplies({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/Reply/GetReplies'
            )
            let data = await response.json()
            console.log(data)
            commit('setRepliesFromBacked', data)
        },

        async GetThreadsFromUser({ commit }, userId) {
            let response = await fetch(
                `https://localhost:44300/api/CategoryThread/GetCategoryThreadByUserId/${userId}`
            )

            let data = await response.json()
            console.log(data)
            commit('setUserThreads', data)
        },

        async CreateUserToDatabase({ commit }, createUserObject) {
            console.log(createUserObject, 'inne i action')
            let response = await fetch(
                `https://localhost:44300/api/User/AddUser?Id_sub=${createUserObject.idSub}&userName=${createUserObject.username}&email=${createUserObject.email}`,
                {
                    method: 'post',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(createUserObject),
                }
            )
            let data = await response.json()
            console.log('from action', data)
            commit('setNewUser', data)
        },
        // async GetUser({ commit }) {
        //     let response = await fetch('')
        //     let data = await response.json()
        //     console.log(data)
        //     commit('setUserFromBack', data)
        // },

        async getAllUsers({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/User/GetUsers'
            )
            let data = await response.json()
            console.log(data)
            commit('setUsersFromBack', data)
        },

        // async getThreadUser({ commit }) {
        //     let response = await fetch('')
        //     let data = await response.json()
        //     console.log(data)
        //     commit('setThreadUserFromBack', data)
        // },

        // async getAllThreadByUser({commit}, userId){
        //     let response = await fetch('https://localhost:44300/api/Threads/GetThreadsByUser' + userId);
        //     let data = await response.json()

        //     console.log(data)
        //     commit('setInMutation' , data)
        // }
    },

    getters: {
        fetchToken: state => {
            return state.token
        },
    },
})

export default store
