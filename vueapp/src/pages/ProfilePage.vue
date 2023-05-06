<template>
    <h1>Profile: {{ userInfo?.userName }}</h1>
    <p>Followers: {{ userInfo?.followerCount }}</p>
    <p>Following: {{ userInfo?.followingCount }}</p>
    <div v-if="!isMe">
        <button
            v-if="userInfo?.isFollowing"
            @click="handleUnfollow"
            class="btn btn-danger"
        >
            Unfollow
        </button>
        <button
            v-else
            @click="handleFollow"
            class="btn btn-primary"
        >
            Follow
        </button>
    </div>
    <h3>{{ isMe ? "Your" : "Their" }} posts</h3>
    <div class="d-flex flex-column gap-3 mt-3">
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
</template>

<script lang="ts" setup>
import PostCard from '@/components/PostCard.vue';
import { Post, UserInfo } from '@/types';
import { computed, inject, ref, watchEffect } from 'vue';
import userService from '@/services/user';
import { userKey } from '@/keys';

const props = defineProps<{
    userId: number;
}>();

const userInfo = ref<UserInfo>();
const posts = ref<Post[]>([]);
const userProvider = inject(userKey);
const isMe = computed(() => userProvider?.user.value.id === props.userId);

watchEffect(async () => {
    const fetchedUserInfo = await userService.getUserInfo(props.userId);
    userInfo.value = fetchedUserInfo;
    console.log('get user info result', fetchedUserInfo);
    const userPosts = await userService.getUserPosts(props.userId);
    console.log('get all posts result', userPosts);
    posts.value = userPosts;
});

function handleEditPost(editedPost: Post) {
    const editedPostIndex = posts.value.findIndex((post) => post.id === editedPost.id);
    posts.value[editedPostIndex] = editedPost;
    console.log('allpostspage handleEdit:', { editedPost, posts: posts.value });
}

async function handleFollow() {
    console.log('handleFollow1:', userInfo.value, userInfo.value?.isFollowing);
    const test = await userService.followUser(props.userId);
    console.log('handleFollow2:', userInfo.value, userInfo.value?.isFollowing, test);
    if (userInfo.value) userInfo.value = { ...userInfo.value, isFollowing: true };
    console.log('handleFollow3:', userInfo.value, userInfo.value?.isFollowing);
}

async function handleUnfollow() {
    console.log('handleUnfollow1:', userInfo.value, userInfo.value?.isFollowing);
    const test = await userService.unfollowUser(props.userId);
    console.log('handleUnfollow2:', userInfo.value, userInfo.value?.isFollowing, test);
    if (userInfo.value) userInfo.value = { ...userInfo.value, isFollowing: false };
    console.log('handleUnfollow3:', userInfo.value, userInfo.value?.isFollowing);
}
</script>

<style scoped>
</style>