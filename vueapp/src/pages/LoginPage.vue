<template>
    <h1>Login</h1>
    <form @submit.prevent="onSubmit">
        <div class="mb-3">
            <label for="username" class="form-label">Username</label>
            <input v-model="username" type="text" class="form-control" />
        </div>
        <div class="mb-3">
            <label for="password" class="form-label">Password</label>
            <input v-model="password" type="password" class="form-control" />
        </div>
        <button type="submit" class="btn btn-primary">Login</button>
    </form>
</template>

<script lang="ts" setup>
import { inject, ref } from 'vue';
import authService from '@/services/auth';
import { addToken } from '@/services/token';
import { useRouter } from 'vue-router'
import { userKey } from '@/keys';

const username = ref('');
const password = ref('');
const router = useRouter();
const userProvider = inject(userKey);

async function onSubmit(event: Event) {
    event.preventDefault();
    const result = await authService.Login(username.value, password.value);
    console.log('login page result:', result);
    if (result.token) {
        addToken(result.token);
        userProvider?.updateUser({
            id: result.id,
            username: result.username,
        });
        router.push({ path: '/' });
    }
}
</script>

<style scoped>
</style>