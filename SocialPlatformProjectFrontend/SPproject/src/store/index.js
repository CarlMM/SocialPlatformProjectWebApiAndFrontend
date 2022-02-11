import { createStore } from 'vuex'

const store = createStore({
    state: {
        // accessToken: '',
        token: '',
        comingFromThreads: false,
        isAdmin: false,
        GroupThreads: [],
        UserThread: [],
        UserGroupThread: [],
        Category: [],
        Thread: [],
        Reply: [],
        AllReplies: [],
        SpecificPostThread: [],
        groupThreadsAdmin: [],
        Users: [],
        listOfUsersAdmin: [],
        Auth0ListUsers: [],
        specificGroupThreadUserList:[]
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

        AllRepliesUser(state, data){
            state.AllReplies = data
            console.log(data)
        },

        deleteSpecificReply(state, data){
            state.AllReplies.sort(data)
            console.log(data)
        },

        updateSpecificReplyAfterDelete(state, data){
            state.AllReplies = data
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

        setGroupUserThreads(state, data){
            state.UserGroupThread = data
        },

        setSpecificPostFromThread(state, data) {
            state.SpecificPostThread = data
        },

        updateSpecificThreadAfterDelete(state, data) {
            state.UserThread = data
            state.groupThreadsAdmin = data
        },
        deleteSpecificThread(state, data) {
            state.UserThread.sort(data)
            state.groupThreadsAdmin.sort(data)
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
        Auth0DeleteFromuserList(state, data) {
            state.Auth0ListUsers.sort(data)
        },
        Auth0SetAllUsers(state, data) {
            state.Auth0ListUsers = data
        },
        setNewUser(state, data) {
            state.Users = data
            console.log(data)
        },
        setSpecificGroupThreadUsers(state, data){
            state.specificGroupThreadUserList = data
        }
    },
    actions: {
        async GetSpecificGroupThreadUsersList( {commit}, groupPostId ){
            let response = await fetch(`https://localhost:44300/api/ThreadUser/GetThreadUsersByCategoryId?categoryThreadId=${groupPostId}`,{
                method: 'get',
            })
            let data = await response.json()
            commit('setSpecificGroupThreadUsers', data) 
        },

        async createNewPostMethod({ commit }, newPostObject) {
            console.log('Inne i createNewPostMethod action: ', newPostObject)
            let response = await fetch(
                `https://localhost:44300/api/CategoryThread/AddCategoryThread/${newPostObject}`,
                {
                    method: 'post',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(newPostObject),
                }
            )
                
                
                console.log(await response.json())
                let data = await response.json()
                console.log('i action', data)
                commit('setNewPost', data)
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
            
        async Auth0DeleteUser({ commit }, userSubId) {
            let response = await fetch(
                `https://dev-dzje4s8y.us.auth0.com/api/v2/users/${userSubId}`,
                {
                    method: 'delete',
                    headers: {
                        Authorization: `Bearer ${'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InNUX3otUzR1SVdlcFA5Q0NtNjNMMSJ9.eyJpc3MiOiJodHRwczovL2Rldi1kemplNHM4eS51cy5hdXRoMC5jb20vIiwic3ViIjoieml2SUVFWDc1ZlNhVUlZM1QxbEFTRkJCZnFXRDFrdGJAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LWR6amU0czh5LnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNjQ0NDk3NDQ2LCJleHAiOjE2NDU3MDcwNDYsImF6cCI6InppdklFRVg3NWZTYVVJWTNUMWxBU0ZCQmZxV0Qxa3RiIiwic2NvcGUiOiJyZWFkOmNsaWVudF9ncmFudHMgY3JlYXRlOmNsaWVudF9ncmFudHMgZGVsZXRlOmNsaWVudF9ncmFudHMgdXBkYXRlOmNsaWVudF9ncmFudHMgcmVhZDp1c2VycyB1cGRhdGU6dXNlcnMgZGVsZXRlOnVzZXJzIGNyZWF0ZTp1c2VycyByZWFkOnVzZXJzX2FwcF9tZXRhZGF0YSB1cGRhdGU6dXNlcnNfYXBwX21ldGFkYXRhIGRlbGV0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgY3JlYXRlOnVzZXJzX2FwcF9tZXRhZGF0YSByZWFkOnVzZXJfY3VzdG9tX2Jsb2NrcyBjcmVhdGU6dXNlcl9jdXN0b21fYmxvY2tzIGRlbGV0ZTp1c2VyX2N1c3RvbV9ibG9ja3MgY3JlYXRlOnVzZXJfdGlja2V0cyByZWFkOmNsaWVudHMgdXBkYXRlOmNsaWVudHMgZGVsZXRlOmNsaWVudHMgY3JlYXRlOmNsaWVudHMgcmVhZDpjbGllbnRfa2V5cyB1cGRhdGU6Y2xpZW50X2tleXMgZGVsZXRlOmNsaWVudF9rZXlzIGNyZWF0ZTpjbGllbnRfa2V5cyByZWFkOmNvbm5lY3Rpb25zIHVwZGF0ZTpjb25uZWN0aW9ucyBkZWxldGU6Y29ubmVjdGlvbnMgY3JlYXRlOmNvbm5lY3Rpb25zIHJlYWQ6cmVzb3VyY2Vfc2VydmVycyB1cGRhdGU6cmVzb3VyY2Vfc2VydmVycyBkZWxldGU6cmVzb3VyY2Vfc2VydmVycyBjcmVhdGU6cmVzb3VyY2Vfc2VydmVycyByZWFkOmRldmljZV9jcmVkZW50aWFscyB1cGRhdGU6ZGV2aWNlX2NyZWRlbnRpYWxzIGRlbGV0ZTpkZXZpY2VfY3JlZGVudGlhbHMgY3JlYXRlOmRldmljZV9jcmVkZW50aWFscyByZWFkOnJ1bGVzIHVwZGF0ZTpydWxlcyBkZWxldGU6cnVsZXMgY3JlYXRlOnJ1bGVzIHJlYWQ6cnVsZXNfY29uZmlncyB1cGRhdGU6cnVsZXNfY29uZmlncyBkZWxldGU6cnVsZXNfY29uZmlncyByZWFkOmhvb2tzIHVwZGF0ZTpob29rcyBkZWxldGU6aG9va3MgY3JlYXRlOmhvb2tzIHJlYWQ6YWN0aW9ucyB1cGRhdGU6YWN0aW9ucyBkZWxldGU6YWN0aW9ucyBjcmVhdGU6YWN0aW9ucyByZWFkOmVtYWlsX3Byb3ZpZGVyIHVwZGF0ZTplbWFpbF9wcm92aWRlciBkZWxldGU6ZW1haWxfcHJvdmlkZXIgY3JlYXRlOmVtYWlsX3Byb3ZpZGVyIGJsYWNrbGlzdDp0b2tlbnMgcmVhZDpzdGF0cyByZWFkOmluc2lnaHRzIHJlYWQ6dGVuYW50X3NldHRpbmdzIHVwZGF0ZTp0ZW5hbnRfc2V0dGluZ3MgcmVhZDpsb2dzIHJlYWQ6bG9nc191c2VycyByZWFkOnNoaWVsZHMgY3JlYXRlOnNoaWVsZHMgdXBkYXRlOnNoaWVsZHMgZGVsZXRlOnNoaWVsZHMgcmVhZDphbm9tYWx5X2Jsb2NrcyBkZWxldGU6YW5vbWFseV9ibG9ja3MgdXBkYXRlOnRyaWdnZXJzIHJlYWQ6dHJpZ2dlcnMgcmVhZDpncmFudHMgZGVsZXRlOmdyYW50cyByZWFkOmd1YXJkaWFuX2ZhY3RvcnMgdXBkYXRlOmd1YXJkaWFuX2ZhY3RvcnMgcmVhZDpndWFyZGlhbl9lbnJvbGxtZW50cyBkZWxldGU6Z3VhcmRpYW5fZW5yb2xsbWVudHMgY3JlYXRlOmd1YXJkaWFuX2Vucm9sbG1lbnRfdGlja2V0cyByZWFkOnVzZXJfaWRwX3Rva2VucyBjcmVhdGU6cGFzc3dvcmRzX2NoZWNraW5nX2pvYiBkZWxldGU6cGFzc3dvcmRzX2NoZWNraW5nX2pvYiByZWFkOmN1c3RvbV9kb21haW5zIGRlbGV0ZTpjdXN0b21fZG9tYWlucyBjcmVhdGU6Y3VzdG9tX2RvbWFpbnMgdXBkYXRlOmN1c3RvbV9kb21haW5zIHJlYWQ6ZW1haWxfdGVtcGxhdGVzIGNyZWF0ZTplbWFpbF90ZW1wbGF0ZXMgdXBkYXRlOmVtYWlsX3RlbXBsYXRlcyByZWFkOm1mYV9wb2xpY2llcyB1cGRhdGU6bWZhX3BvbGljaWVzIHJlYWQ6cm9sZXMgY3JlYXRlOnJvbGVzIGRlbGV0ZTpyb2xlcyB1cGRhdGU6cm9sZXMgcmVhZDpwcm9tcHRzIHVwZGF0ZTpwcm9tcHRzIHJlYWQ6YnJhbmRpbmcgdXBkYXRlOmJyYW5kaW5nIGRlbGV0ZTpicmFuZGluZyByZWFkOmxvZ19zdHJlYW1zIGNyZWF0ZTpsb2dfc3RyZWFtcyBkZWxldGU6bG9nX3N0cmVhbXMgdXBkYXRlOmxvZ19zdHJlYW1zIGNyZWF0ZTpzaWduaW5nX2tleXMgcmVhZDpzaWduaW5nX2tleXMgdXBkYXRlOnNpZ25pbmdfa2V5cyByZWFkOmxpbWl0cyB1cGRhdGU6bGltaXRzIGNyZWF0ZTpyb2xlX21lbWJlcnMgcmVhZDpyb2xlX21lbWJlcnMgZGVsZXRlOnJvbGVfbWVtYmVycyByZWFkOmVudGl0bGVtZW50cyByZWFkOmF0dGFja19wcm90ZWN0aW9uIHVwZGF0ZTphdHRhY2tfcHJvdGVjdGlvbiByZWFkOm9yZ2FuaXphdGlvbnMgdXBkYXRlOm9yZ2FuaXphdGlvbnMgY3JlYXRlOm9yZ2FuaXphdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbnMgY3JlYXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJzIHJlYWQ6b3JnYW5pemF0aW9uX21lbWJlcnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJzIGNyZWF0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgcmVhZDpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgdXBkYXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25fbWVtYmVyX3JvbGVzIHJlYWQ6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyBkZWxldGU6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyBjcmVhdGU6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIHJlYWQ6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25faW52aXRhdGlvbnMiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.km9RUWb0P9yE2qvoeQUl2OYTqsK-SCMrMXzbsPwx0SbJMID8STQOT5IKEHf1ag9rH-diso6C_QIPwVmrTFZPZIM38LiGjSnGh4tz0GIRbOSNt8PX9bt9Dmrwm6pECYhTzjuNjnzI3GO1sRPFCupucbyOMjZIXptUlMF86Tms9D-nDVwS-LwW-2mNWiODgGavwyMh-NVE4HB2sQIwaWhkJomQ7Fp3Ynl4kmPSUcloC5-GemILRjYUQkAI627TVQw5bOdWjYK21EVWBz0B0ErbNUokbwluY18Dji00XFs1bTg5TqdFp5P2kq4Aspd1fe44KkuFzGRs82OEw198jwhAbA'}`,
                        // 'Content-type': 'application/json',
                    },
                }
            )
            let data = await response.json()
            commit('Auth0DeleteFromuserList', data)
        },

        async Auth0GetAllUsers({ commit }) {
            let response = await fetch(
                'https://dev-dzje4s8y.us.auth0.com/api/v2/users',
                {
                    method: 'get',
                    headers: {
                        Authorization: `Bearer ${'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InNUX3otUzR1SVdlcFA5Q0NtNjNMMSJ9.eyJpc3MiOiJodHRwczovL2Rldi1kemplNHM4eS51cy5hdXRoMC5jb20vIiwic3ViIjoieml2SUVFWDc1ZlNhVUlZM1QxbEFTRkJCZnFXRDFrdGJAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vZGV2LWR6amU0czh5LnVzLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNjQ0NDk3NDQ2LCJleHAiOjE2NDU3MDcwNDYsImF6cCI6InppdklFRVg3NWZTYVVJWTNUMWxBU0ZCQmZxV0Qxa3RiIiwic2NvcGUiOiJyZWFkOmNsaWVudF9ncmFudHMgY3JlYXRlOmNsaWVudF9ncmFudHMgZGVsZXRlOmNsaWVudF9ncmFudHMgdXBkYXRlOmNsaWVudF9ncmFudHMgcmVhZDp1c2VycyB1cGRhdGU6dXNlcnMgZGVsZXRlOnVzZXJzIGNyZWF0ZTp1c2VycyByZWFkOnVzZXJzX2FwcF9tZXRhZGF0YSB1cGRhdGU6dXNlcnNfYXBwX21ldGFkYXRhIGRlbGV0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgY3JlYXRlOnVzZXJzX2FwcF9tZXRhZGF0YSByZWFkOnVzZXJfY3VzdG9tX2Jsb2NrcyBjcmVhdGU6dXNlcl9jdXN0b21fYmxvY2tzIGRlbGV0ZTp1c2VyX2N1c3RvbV9ibG9ja3MgY3JlYXRlOnVzZXJfdGlja2V0cyByZWFkOmNsaWVudHMgdXBkYXRlOmNsaWVudHMgZGVsZXRlOmNsaWVudHMgY3JlYXRlOmNsaWVudHMgcmVhZDpjbGllbnRfa2V5cyB1cGRhdGU6Y2xpZW50X2tleXMgZGVsZXRlOmNsaWVudF9rZXlzIGNyZWF0ZTpjbGllbnRfa2V5cyByZWFkOmNvbm5lY3Rpb25zIHVwZGF0ZTpjb25uZWN0aW9ucyBkZWxldGU6Y29ubmVjdGlvbnMgY3JlYXRlOmNvbm5lY3Rpb25zIHJlYWQ6cmVzb3VyY2Vfc2VydmVycyB1cGRhdGU6cmVzb3VyY2Vfc2VydmVycyBkZWxldGU6cmVzb3VyY2Vfc2VydmVycyBjcmVhdGU6cmVzb3VyY2Vfc2VydmVycyByZWFkOmRldmljZV9jcmVkZW50aWFscyB1cGRhdGU6ZGV2aWNlX2NyZWRlbnRpYWxzIGRlbGV0ZTpkZXZpY2VfY3JlZGVudGlhbHMgY3JlYXRlOmRldmljZV9jcmVkZW50aWFscyByZWFkOnJ1bGVzIHVwZGF0ZTpydWxlcyBkZWxldGU6cnVsZXMgY3JlYXRlOnJ1bGVzIHJlYWQ6cnVsZXNfY29uZmlncyB1cGRhdGU6cnVsZXNfY29uZmlncyBkZWxldGU6cnVsZXNfY29uZmlncyByZWFkOmhvb2tzIHVwZGF0ZTpob29rcyBkZWxldGU6aG9va3MgY3JlYXRlOmhvb2tzIHJlYWQ6YWN0aW9ucyB1cGRhdGU6YWN0aW9ucyBkZWxldGU6YWN0aW9ucyBjcmVhdGU6YWN0aW9ucyByZWFkOmVtYWlsX3Byb3ZpZGVyIHVwZGF0ZTplbWFpbF9wcm92aWRlciBkZWxldGU6ZW1haWxfcHJvdmlkZXIgY3JlYXRlOmVtYWlsX3Byb3ZpZGVyIGJsYWNrbGlzdDp0b2tlbnMgcmVhZDpzdGF0cyByZWFkOmluc2lnaHRzIHJlYWQ6dGVuYW50X3NldHRpbmdzIHVwZGF0ZTp0ZW5hbnRfc2V0dGluZ3MgcmVhZDpsb2dzIHJlYWQ6bG9nc191c2VycyByZWFkOnNoaWVsZHMgY3JlYXRlOnNoaWVsZHMgdXBkYXRlOnNoaWVsZHMgZGVsZXRlOnNoaWVsZHMgcmVhZDphbm9tYWx5X2Jsb2NrcyBkZWxldGU6YW5vbWFseV9ibG9ja3MgdXBkYXRlOnRyaWdnZXJzIHJlYWQ6dHJpZ2dlcnMgcmVhZDpncmFudHMgZGVsZXRlOmdyYW50cyByZWFkOmd1YXJkaWFuX2ZhY3RvcnMgdXBkYXRlOmd1YXJkaWFuX2ZhY3RvcnMgcmVhZDpndWFyZGlhbl9lbnJvbGxtZW50cyBkZWxldGU6Z3VhcmRpYW5fZW5yb2xsbWVudHMgY3JlYXRlOmd1YXJkaWFuX2Vucm9sbG1lbnRfdGlja2V0cyByZWFkOnVzZXJfaWRwX3Rva2VucyBjcmVhdGU6cGFzc3dvcmRzX2NoZWNraW5nX2pvYiBkZWxldGU6cGFzc3dvcmRzX2NoZWNraW5nX2pvYiByZWFkOmN1c3RvbV9kb21haW5zIGRlbGV0ZTpjdXN0b21fZG9tYWlucyBjcmVhdGU6Y3VzdG9tX2RvbWFpbnMgdXBkYXRlOmN1c3RvbV9kb21haW5zIHJlYWQ6ZW1haWxfdGVtcGxhdGVzIGNyZWF0ZTplbWFpbF90ZW1wbGF0ZXMgdXBkYXRlOmVtYWlsX3RlbXBsYXRlcyByZWFkOm1mYV9wb2xpY2llcyB1cGRhdGU6bWZhX3BvbGljaWVzIHJlYWQ6cm9sZXMgY3JlYXRlOnJvbGVzIGRlbGV0ZTpyb2xlcyB1cGRhdGU6cm9sZXMgcmVhZDpwcm9tcHRzIHVwZGF0ZTpwcm9tcHRzIHJlYWQ6YnJhbmRpbmcgdXBkYXRlOmJyYW5kaW5nIGRlbGV0ZTpicmFuZGluZyByZWFkOmxvZ19zdHJlYW1zIGNyZWF0ZTpsb2dfc3RyZWFtcyBkZWxldGU6bG9nX3N0cmVhbXMgdXBkYXRlOmxvZ19zdHJlYW1zIGNyZWF0ZTpzaWduaW5nX2tleXMgcmVhZDpzaWduaW5nX2tleXMgdXBkYXRlOnNpZ25pbmdfa2V5cyByZWFkOmxpbWl0cyB1cGRhdGU6bGltaXRzIGNyZWF0ZTpyb2xlX21lbWJlcnMgcmVhZDpyb2xlX21lbWJlcnMgZGVsZXRlOnJvbGVfbWVtYmVycyByZWFkOmVudGl0bGVtZW50cyByZWFkOmF0dGFja19wcm90ZWN0aW9uIHVwZGF0ZTphdHRhY2tfcHJvdGVjdGlvbiByZWFkOm9yZ2FuaXphdGlvbnMgdXBkYXRlOm9yZ2FuaXphdGlvbnMgY3JlYXRlOm9yZ2FuaXphdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbnMgY3JlYXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJzIHJlYWQ6b3JnYW5pemF0aW9uX21lbWJlcnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJzIGNyZWF0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgcmVhZDpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgdXBkYXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25fbWVtYmVyX3JvbGVzIHJlYWQ6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyBkZWxldGU6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyBjcmVhdGU6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIHJlYWQ6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25faW52aXRhdGlvbnMiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.km9RUWb0P9yE2qvoeQUl2OYTqsK-SCMrMXzbsPwx0SbJMID8STQOT5IKEHf1ag9rH-diso6C_QIPwVmrTFZPZIM38LiGjSnGh4tz0GIRbOSNt8PX9bt9Dmrwm6pECYhTzjuNjnzI3GO1sRPFCupucbyOMjZIXptUlMF86Tms9D-nDVwS-LwW-2mNWiODgGavwyMh-NVE4HB2sQIwaWhkJomQ7Fp3Ynl4kmPSUcloC5-GemILRjYUQkAI627TVQw5bOdWjYK21EVWBz0B0ErbNUokbwluY18Dji00XFs1bTg5TqdFp5P2kq4Aspd1fe44KkuFzGRs82OEw198jwhAbA'}`,
                        'Content-type': 'application/json',
                    },
                }
            )
            let data = await response.json()
            commit('Auth0SetAllUsers', data)
        },

        async addUserToGroupThread({ commit }, addThreadUserObject) {
            let response = await fetch(
                `https://localhost:44300/api/ThreadUser/AddThreadUser?categoryThreadId=${addThreadUserObject.id}&userIdSub=${addThreadUserObject.idSub}`,
                {
                    method: 'post',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(this.addThreadUserObject),
                }
            )
            let data = await response.json()
            console.log(data, 'from action')
        },

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


        async GetAllReplies({ commit }) {
            let response = await fetch(
                'https://localhost:44300/api/Reply/GetReplies'
            )
            let data = await response.json()
            console.log(data)
            commit('setRepliesFromBacked', data)
        },

        async DeleteSpecificReply({ commit }, id) {
            let response = await fetch(
                `https://localhost:44300/api/Reply/DeleteReply/${id}`,
                {
                    method: 'delete',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(this.state.AllReplies),
                }
            )
            let data = await response.json()
            commit('deleteSpecificReply', data)
        },

        async GetAllRepliesUser({commit}, userId){
            let response = await fetch(
                `https://localhost:44300/api/Reply/GetReply/${userId}`
            )
            let data = await response.json()
            console.log(data)
            commit('AllRepliesUser', data)
        },

        async GetThreadsFromUser({ commit }, userId) {
            let response = await fetch(
                `https://localhost:44300/api/CategoryThread/GetCategoryThreadByUserId/${userId}`
            )

            let data = await response.json()
            console.log(data)
            commit('setUserThreads', data)
        },

        async GetGroupThreadsFromUser({commit}, idSub){
            let response = await fetch(
                `https://localhost:44300/api/CategoryThread/GetGroupCategoryThreadByUserid?userIdSub=${idSub}`

                )

                let data = await response.json()
                console.log(data)
                commit('setGroupUserThreads', data)
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

        async getThreadUser({commit}, categoryThreadId) {
            //console.log(categoryThreadId, ' i action')
            let response = await fetch(`https://localhost:44300/api/ThreadUser/GetThreadUsersByCategoryId?categoryThreadId=${categoryThreadId}`)
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

    getters: {
        fetchToken: state => {
            return state.token
        },
    },
})

export default store
