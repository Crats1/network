<template>
    <h3>All Posts</h3>
    <NewPostCard @add-new-post="addNewPost" />
    <p v-if="testPosts.length === 0">Nothing posted yet</p>
    <div v-for="post in testPosts" :key="post.id">
        <PostCard :author="post.author" :content="post.content" :post-date="post.postDate" />
    </div>
</template>

<script lang="ts" setup>
import NewPostCard from '@/components/NewPostCard.vue';
import PostCard from '@/components/PostCard.vue';
import { ref } from 'vue';

const testPosts = ref(Array.from({ length: 5 }).map((_, i) => ({
    id: i,
    author: `author${i}`,
    content: `content${i}`,
    postDate: `postDate${i}`,
})));

defineProps<{
    author: string,
    content: string,
    postDate: string
}>();

function addNewPost(content: string) {
    console.log('all posts page addNewPost', content);
}
</script>

<style scoped>
</style>