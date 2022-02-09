<template>
    <div
        v-for="threads in getGroupThreadsAdmin"
        :key="threads.Id"
        class="subforum-description"
    >
        <div class="subforum-row element">
            <div class="subforum-icon subforum-column center">
                <img
                    src="https://via.placeholder.com/300.png/ https://placeholder.com/ "
                    alt=""
                />
            </div>
            <div class="subforum-description subforum-column">
                <div class="text">
                    <h1>{{ threads.title }}</h1>
                    <span
                        ><p>
                            Posted by <a href="#"> User </a> 15 jan 2022
                        </p></span
                    >
                    <p>{{ threads.text }}</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { useAuth0, AuthState } from '../../auth0/useAuth0.js'
export default {
    name: 'AdminAllThreads',
    data() {
        return {
            threadsList: [],
        }
    },
    created() {
        this.$store.dispatch('getAllThreads')
        if (AuthState.isAuthenticated == true) {
            if (
                AuthState.user['http://localhost:3000/roles'][0] == 'AdminUser'
            ) {
                this.$store.state.isAdmin = true
            } else {
                this.$router.push('/notauthorized')
            }
        }
    },
    computed: {
        getGroupThreadsAdmin() {
            let allThreadsAdmin = this.$store.state.Thread
            return allThreadsAdmin
        },
    },
    // beforeMounted(){

    // }
}
</script>

<style>
* {
    box-sizing: border-box;
}

li {
    list-style: none;
}

a {
    color: rgb(153, 149, 163);
    font-weight: 300;
    text-decoration: none;
}

.text {
    margin-left: 5px;
    margin-top: 20px;
}

p {
    color: white;
}

.post-link > a {
    color: white;
    padding-right: 10px;
    font-size: 12px;
}

h1 {
    font-size: 18px;
    font-weight: bolder;
    color: white;
}

.outer-box {
    background: #484848;
    border-radius: 5px;
}

.subforum {
    margin-top: 20px;
}

.subforum-row {
    display: grid;
    grid-template-columns: 10% 90%;
}

.subforum-column {
    background-color: rgb(48, 48, 48);
}

.subforum-description {
    padding: 1px;
}

.center {
    display: flex;
    justify-content: center;
    align-items: center;
}

.subforum-icon > img {
    height: 100%;
    min-width: 80px;
    border-radius: 3px;
}

@media (max-width: 900px) {
    .subforum-icon > img {
        min-width: 60px;
    }
}

.element {
    box-shadow: none;
}

.element:hover,
element:active {
    box-shadow: 0 0 5px #fff, inset 0 0 10px #43a78c;
}
</style>
