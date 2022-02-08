import createAuth0Client from '@auth0/auth0-spa-js'
import { reactive } from 'vue'

export const AuthState = reactive({
    user: null,
    loading: false,
    isAuthenticated: false,
    auth0: null,
    token:'',
})

const config = {
    //import.meta.env.VITE_AUTH0_DOMAIN
    domain: 'dev-dzje4s8y.us.auth0.com',
    //import.meta.env.VITE_AUTH0_CLIENT_ID
    client_id: 'MEG1azoqm6vMU81lYKu54cBo8mzBKSQ0',
    audience: 'https://auth0sucks/api'
}

export const useAuth0 = state => {
    const handleStateChange = async () => {
        state.isAuthenticated = !!(await state.auth0.isAuthenticated())
        state.user = await state.auth0.getUser()
        state.loading = false
        state.token =  await state.auth0.getTokenSilently();
        state.claims.aud = config.audience
    }

    const initAuth = () => {
        state.loading = true
        createAuth0Client({
            domain: config.domain,
            client_id: config.client_id,
            audience: config.audience,
            cacheLocation: 'localstorage',
            redirect_uri: window.location.origin,
        }).then(async auth => {
            state.auth0 = auth
            await handleStateChange()
        })
    }

    const login = async () => {
        await state.auth0.loginWithPopup()
        location.reload()
        await handleStateChange()
        //console.log(respone.data)
        console.log('ge mig user: ', state.user)
        console.log(state.user.app_metadata)
    }

    const logout = async () => {
        state.auth0.logout({
            returnTo: window.location.origin,
        })
    }


  

    return {
        login,
        logout,
        initAuth
        
    }
}
