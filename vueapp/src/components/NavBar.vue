<template>
    <nav class="navbar navbar-expand-lg bg-light">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/">Network</router-link>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <div class="navbar-nav">
                    <router-link class="nav-link" to="/">All Posts</router-link>
                    <router-link class="nav-link" to="/following">Following</router-link>
                    <router-link class="nav-link" to="/profile">Profile</router-link>
                    <router-link class="nav-link" to="/login">Login</router-link>
                    <router-link class="nav-link" to="/register">Register</router-link>
                    <router-link class="nav-link" to="/logout">Logout</router-link>
                </div>
            </div>
        </div>
    </nav>
</template>

<script lang="ts" setup>
</script>

<style scoped>
</style>