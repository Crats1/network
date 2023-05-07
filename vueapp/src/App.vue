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
import { removeToken } from './services/token';
import userService from './services/user';
import { useRouter } from 'vue-router';

const user = ref<User>();
const router = useRouter();

onBeforeMount(async () => {
    try {
        const userInfo = await userService.getMe();
        console.log('app onMounted user:', { user, userInfo });
        user.value = {
            id: userInfo.id,
            userName: userInfo.userName
        };
        console.log('app onMounted user:', { user, userInfo });
    } catch (error) {
        user.value = undefined;
        removeToken();
        router.push('/login');
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
