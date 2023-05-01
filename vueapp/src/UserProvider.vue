<template>
    <slot></slot>
</template>

<script lang="ts" setup>
import { provide, ref } from 'vue';
import { userKey } from './keys';
import { User } from './types';

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
</script>