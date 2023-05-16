<template>
    <p v-if="posts.length === 0">{{ noPostsMessage ?? "Nothing posted yet" }}</p>
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
        <nav v-if="pages > 1">
            <ul class="pagination justify-content-center">
                <li
                    class="page-item"
                    :class="{ disabled: selectedPage === 1 }"
                    @click="offset = Math.max(offset - LIMIT, 0)"
                >
                    <a class="page-link" href="#">
                        <span aria-hidden="true">&laquo;</span>
                    </a>
                </li>
                <li
                    v-for="page in pages"
                    :key="page"
                    class="page-item"
                    :class="{ active: page === selectedPage }"
                    @click="offset = (page - 1) * LIMIT"
                >
                    <a class="page-link" href="#">{{ page }}</a>
                </li>
                <li
                    class="page-item"
                    :class="{ disabled: selectedPage === pages }"
                    @click="offset = Math.min(offset + LIMIT, LIMIT * (pages - 1))"
                >
                    <a class="page-link" href="#">
                        <span aria-hidden="true">&raquo;</span>
                    </a>
                </li>
            </ul>
        </nav>
    </div>
</template>

<script lang="ts" setup>
import PostCard from '@/components/PostCard.vue';
import { PaginatedList, Post, PostSortOrders } from '@/types';
import { computed, ref, watchEffect } from 'vue';

const props = defineProps<{
    getPosts: (sortOrder?: PostSortOrders, limit?: number, offset?: number) => Promise<PaginatedList<Post>>;
    noPostsMessage?: string;
}>();

const LIMIT = 10;
const offset = ref(0);
const totalItems = ref(0);
const posts = ref<Post[]>([]);
const sortOrder = ref<PostSortOrders>(PostSortOrders.DATE_DESC);
const pages = computed(() => Math.ceil(totalItems.value / LIMIT));
const selectedPage = computed(() => Math.floor(offset.value / LIMIT) + 1);

watchEffect(async () => {
    try {
        const result = await props.getPosts(sortOrder.value, LIMIT, offset.value);
        console.log('get all posts result', { result, posts: posts.value });
        posts.value = result.items;
        offset.value = result.offset;
        totalItems.value = result.totalItems;
    } catch (e) {
        console.error(e);
    }
});

function handleEditPost(editedPost: Post) {
    const editedPostIndex = posts.value.findIndex((post) => post.id === editedPost.id);
    posts.value[editedPostIndex] = editedPost;
    console.log('allpostspage handleEdit:', { editedPost, posts: posts.value });
}
</script>

<style scoped>
</style>