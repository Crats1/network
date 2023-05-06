<template>
  <NavBar />
  <div class="container">
    <router-view/>
  </div>
</template>

<script lang="ts" setup>
import NavBar from '@/components/NavBar.vue';
import { User } from './types';
import { onBeforeMount, onMounted, provide, ref } from 'vue';
import { userKey } from './keys';
import { isAuthenticated } from './services/token';
import userService from './services/user';

const user = ref<User>();

onBeforeMount(async () => {
    if (isAuthenticated()) {
        const userInfo = await userService.getMe();
        console.log('app onMounted user:', { user });
        user.value = {
            id: userInfo.id,
            userName: userInfo.userName
        };
        console.log('app onMounted user:', { user, userInfo });
    }
});

function updateUser(newUser: User | undefined) {
    console.log('UserProvider updateUser called:', user, newUser);
    user.value = newUser;
}

provide(userKey, {
    user,
    updateUser,
});

onMounted(() => {

});

console.log('App rerendered');
</script>

<style>
nav a.router-link-exact-active {
    /* color: #42b983; */
}
</style>
