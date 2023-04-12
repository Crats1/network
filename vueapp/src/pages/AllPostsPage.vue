<template>
    <h1>All Posts</h1>
</template>

<script lang="ts" setup>
import { defineProps } from 'vue';

defineProps<{
    author: string,
    content: string,
    postDate: string
}>();
</script>

<style scoped>
</style>