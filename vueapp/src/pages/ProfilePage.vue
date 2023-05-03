<template>
    <h1>Profile</h1>
    <p>Username: {{  "TODO" }}</p>
    <p>Followers: {{ "TODO" }}</p>
    <p>Following: {{ "TODO" }}</p>
    <h3>Your posts</h3>
    <PostCard
        v-for="post in posts"
        :key="post.id"
        @edit-post="handleEditPost"
        :id="post.id"
        :content="post.content"
        :created-at="post.createdAt"
        :updated-at="post.updatedAt"
        :is-created-by-user="post.isCreatedByUser"
        :username="post.username"
    />
    />
</template>

<script lang="ts" setup>
import PostCard from '@/components/PostCard.vue';
import { Post } from '@/types';
import { ref, watchEffect } from 'vue';
import userService from '@/services/user';

const posts = ref<Post[]>([]);

watchEffect(async () => {
    const result = await userService.getUserPosts();
    console.log('get all posts result', result);
    posts.value = result;
});

function handleEditPost() {
    console.log('handleEditPost clicked');
    
}
</script>

<style scoped>
</style>