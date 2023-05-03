<template>
  <NavBar />
  <div class="container">
    <router-view/>
  </div>
</template>

<script lang="ts" setup>
import NavBar from '@/components/NavBar.vue';
import { User } from './types';
import { provide, ref } from 'vue';
import { userKey } from './keys';

const user = ref<User | null>(null);

function updateUser(newUser: User) {
    console.log('UserProvider updateUser called:', user, newUser);
    user.value = newUser;
}

function clearUser() {
    console.log('UserProvider clearUser called:', user);
    user.value = null;
}

provide(userKey, {
    user,
    updateUser,
    clearUser,
});

console.log('App rerendered');
</script>

<style>
nav a.router-link-exact-active {
    /* color: #42b983; */
}
</style>
