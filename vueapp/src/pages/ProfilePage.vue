<template>
    <h1>Profile</h1>
    <p>Username: {{  testUser.username }}</p>
    <p>Followers: {{ testUser.followers }}</p>
    <p>Following: {{ testUser.following }}</p>
    <h3>Your posts</h3>
    <PostCard
        v-for="post in testPosts"
        :key="post.id"
        :author="post.author"
        :content="post.content"
        :post-date="post.postDate"
    />
</template>

<script lang="ts" setup>
import PostCard from '@/components/PostCard.vue';
import { ref } from 'vue';

const testUser = {
    username: 'test username',
    followers: 5,
    following: 10,
}

const testPosts = ref(Array.from({ length: 5 }).map((_, i) => ({
    id: i,
    author: `author${i}`,
    content: `content${i}`,
    postDate: `postDate${i}`,
})));
</script>

<style scoped>
</style>