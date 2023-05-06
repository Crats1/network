<template>
    <slot></slot>
</template>

<script lang="ts" setup>
import { provide, ref } from 'vue';
import { userKey } from './keys';
import { User } from './types';

const user = ref<User>();

function updateUser(newUser: User | undefined) {
    console.log('UserProvider updateUser called:', user, newUser);
    user.value = newUser;
}

provide(userKey, {
    user,
    updateUser,
});
</script>