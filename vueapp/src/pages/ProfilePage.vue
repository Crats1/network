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
    <PostList
        :get-posts="getUserPosts"
        no-posts-message="You haven't made any posts yet"
    />
</template>

<script lang="ts" setup>
import { PaginatedList, Post, PostSortOrders, UserInfo } from '@/types';
import { computed, inject, ref, watchEffect } from 'vue';
import userService from '@/services/user';
import { userKey } from '@/keys';
import PostList from '@/components/PostList.vue';

const props = defineProps<{
    userId: number;
}>();

const userInfo = ref<UserInfo>();
const userProvider = inject(userKey);
const isMe = computed(() => userProvider?.user.value.id === props.userId);

function getUserPosts(sortOrder?: PostSortOrders, limit?: number, offset?: number): Promise<PaginatedList<Post>> {
    const result = userService.getUserPosts(props.userId, sortOrder, limit, offset);
    console.log("FollowingPage getFollowedPosts called", { sortOrder, limit, offset, result });
    return result;
}

watchEffect(async () => {
    const fetchedUserInfo = await userService.getUserInfo(props.userId);
    userInfo.value = fetchedUserInfo;
    console.log('get user info result', fetchedUserInfo);
});

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