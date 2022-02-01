<template>
    <div>
        <h1>My profile</h1>
        <p>Loopa ut användarens data, så som nickname email osv?</p>
        <div v-if="AuthState.isAuthenticated">
            <form>
                <img :src="AuthState.user.picture" alt="AvatarPic">
                <br>
                <input type="text" v-model="AuthState.user.nickname">
                <br>
                <input type="text" v-model="AuthState.user.email">
                
            </form>
        </div>
    </div>
</template>


<script>





export default {
    
}
</script>

<script setup>
import { useAuth0, AuthState } from "/src/auth0/useAuth0.js";

const { login, logout, initAuth } = useAuth0(AuthState);

initAuth();


</script>