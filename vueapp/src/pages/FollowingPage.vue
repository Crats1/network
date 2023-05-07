<template>
    <div class="d-flex flex-column gap-3 mt-3">
        <h1>Following</h1>
        <p v-if="posts.length === 0">Nothing posted yet</p>
        <div v-else class="d-flex flex-column gap-3 mt-3">
            <div>
                <label for="postSortOrder">Sort posts by:</label>
                <select v-model="sortOrder" class="form-select" id="postSortOrder">
                    <option :value="PostSortOrders.DATE_DESC">Date descending</option>
                    <option :value="PostSortOrders.DATE_ASC">Date ascending</option>
                    <option :value="PostSortOrders.LIKES_DESC">Likes descending</option>
                    <option :value="PostSortOrders.LIKES_ASC">Likes ascending</option>
                </select>
            </div>
            <PostCard
                v-for="post in posts"
                :key="post.id"
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
        <div>

        </div>
    </div>
</template>

<script lang="ts" setup>
import PostCard from '@/components/PostCard.vue';
import { Post, PostSortOrders } from '@/types';
import { ref, watchEffect } from 'vue';
import postsService from '@/services/posts';

const posts = ref<Post[]>([]);
const sortOrder = ref<PostSortOrders>(PostSortOrders.DATE_DESC);

watchEffect(async () => {
    const result = await postsService.getFollowedUsersPosts(sortOrder.value);
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