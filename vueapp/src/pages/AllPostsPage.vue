<template>
    <div class="d-flex flex-column gap-3 mt-3">
        <h1>All Posts</h1>
        <NewPostCard @add-new-post="addNewPost" />
        <p v-if="posts.length === 0">Nothing posted yet</p>
        <div v-for="post in posts" :key="post.id">
            <PostCard
                :author="`Author ${post.userID}`"
                :content="post.content"
                :updated-at="post.updatedAt ?? post.createdAt"
                :user-id="post.userID"
            />
        </div>
    </div>
</template>

<script lang="ts" setup>
import NewPostCard from '@/components/NewPostCard.vue';
import PostCard from '@/components/PostCard.vue';
import { Post } from '@/types';
import { ref, watchEffect } from 'vue';
import postsServices from '@/services/posts';

const posts = ref<Post[]>([]);

watchEffect(async () => {
    const result = await postsServices.getAllPosts();
    console.log('get all posts result', result);
    posts.value = result;
});

function addNewPost(newPost: Post) {
    console.log('all posts page addNewPost', newPost);
    posts.value.push(newPost);
}
</script>

<style scoped>
</style>