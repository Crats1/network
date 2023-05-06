<template>
    <div class="d-flex flex-column gap-3 mt-3">
        <h1>Following</h1>
        <p v-if="posts.length === 0">Nothing posted yet</p>
        <div v-for="post in posts" :key="post.id">
            <PostCard
                @edit-post="handleEditPost"
                :id="post.id"
                :content="post.content"
                :created-at="post.createdAt"
                :updated-at="post.updatedAt"
                :is-created-by-user="post.isCreatedByUser"
                :user-id="post.userId"
                :username="post.username"
                :is-liked-by-user="post.isLikedByUser"
                :likes="post.likes"
            />
        </div>
    </div>
</template>

<script lang="ts" setup>
import PostCard from '@/components/PostCard.vue';
import { Post } from '@/types';
import { ref, watchEffect } from 'vue';
import postsService from '@/services/posts';

const posts = ref<Post[]>([]);

watchEffect(async () => {
    const result = await postsService.getFollowedUsersPosts();
    console.log('get followed posts result', result);
    posts.value = result;
});

function handleEditPost(editedPost: Post) {
    const editedPostIndex = posts.value.findIndex((post) => post.id === editedPost.id);
    posts.value[editedPostIndex] = editedPost;
    console.log('followingPage handleEdit:', { editedPost, posts: posts.value });
}
</script>

<style scoped>
</style>