<template>
    <h1>Register</h1>
    <form @submit.prevent="onSubmit">
        <div class="mb-3">
            <label for="username" class="form-label">Username</label>
            <input v-model="username" type="text" class="form-control" />
        </div>
        <div class="mb-3">
            <label for="password" class="form-label">Password</label>
            <input v-model="password" type="password" class="form-control" />
        </div>
        <button type="submit" class="btn btn-primary">Register</button>
    </form>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import authService from '@/services/auth';

const username = ref('');
const password = ref('');

async function onSubmit() {
    const result = await authService.Register(username.value, password.value);
    console.log('register page result:', result);
}
</script>

<style scoped>
</style>