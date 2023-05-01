<template>
    <nav class="navbar navbar-expand-lg bg-light">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/">Network</router-link>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <div class="navbar-nav" v-if="isLoggedIn">
                    <router-link class="nav-link" to="/">All Posts</router-link>
                    <router-link class="nav-link" to="/following">Following</router-link>
                    <router-link class="nav-link" to="/profile">Profile</router-link>
                    <router-link @click="logout" class="nav-link" to="/">Logout</router-link>
                </div>
                <div class="navbar-nav" v-else>
                    <router-link class="nav-link" to="/login">Login</router-link>
                    <router-link class="nav-link" to="/register">Register</router-link>
                </div>
            </div>
        </div>
    </nav>
</template>

<script lang="ts" setup>
import { userKey } from '@/keys';
import { isAuthenticated, removeToken } from '@/services/token';
import { computed, inject } from 'vue';

const userProvider = inject(userKey);

function logout() {
    removeToken();
    userProvider?.clearUser();
}

const isLoggedIn = computed(() => {
    return isAuthenticated();
});

console.log('NavBar updated');
</script>

<style scoped>
</style>