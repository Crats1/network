<template>
    <div>
        <h1>Following</h1>
        <PostList
            :get-posts="getFollowedPosts"
            no-posts-message="You are not following anyone yet"
        />
    </div>
</template>

<script lang="ts" setup>
import { PaginatedList, Post, PostSortOrders } from '@/types';
import postsService from '@/services/posts';
import PostList from '@/components/PostList.vue';

function getFollowedPosts(sortOrder?: PostSortOrders, limit?: number, offset?: number): Promise<PaginatedList<Post>> {
    const result = postsService.getFollowedUsersPosts(sortOrder, limit, offset);
    console.log("FollowingPage getFollowedPosts called", { sortOrder, limit, offset, result });
    return result;
}
</script>

<style scoped>
</style>