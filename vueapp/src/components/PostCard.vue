<template>
    <div class="card">
        <div class="card-body">
            <h4 class="card-title">{{ username }}</h4>
            <a v-if="isCreatedByUser && !isEditing" @click="toggleEdit" href="#" class="edit-btn">Edit</a>
            <p v-if="!isEditing" class="card-text content">{{ content }}</p>
            <div v-else class="mb-3">
                <textarea
                    v-model="editedPost"
                    class="form-control mb-1"
                    rows="3"
                >
                </textarea>
                <button @click="handleSaveEdit" class="btn btn-success me-1">Save</button>
                <button @click="toggleEdit" class="btn btn-outline-danger">Cancel</button>
            </div>
            <p class="card-subtitle md-2 text-muted">{{ postDate }}</p>
            <div class="d-flex align-items-baseline gap-1">
                <a
                    v-if="isLikedByUser"
                    @click="handleLike(false)"
                    class="link-danger"
                    title="Unlike post"
                >
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart-fill" viewBox="0 0 16 16">
                        <path fill-rule="evenodd" d="M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z"/>
                    </svg>
                </a>
                <a
                    v-else
                    @click="handleLike(true)"
                    class="link-danger"
                    title="Like post"
                >
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16">
                        <path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"/>
                    </svg>
                </a>
                <p class="card-subtitle text-muted">{{ likes }}</p>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { computed, ref } from 'vue';
import postsService from '@/services/posts';
import { Post } from '@/types';

const props = defineProps<{
    id: number;
    content: string;
    createdAt: string;
    updatedAt?: string;
    isCreatedByUser: boolean;
    username: string;
    isLikedByUser: boolean;
    likes: number;
}>();

const emit = defineEmits<{
    (e: 'editPost', editedPost: Post): void;
}>();

const postDate = computed(() => {
    const postDateObj = new Date(Date.parse(props.updatedAt ?? props.createdAt));
    const text = props.updatedAt ? 'Updated at' : 'Created at';
    return `${text} ${postDateObj.toDateString()}, ${postDateObj.toLocaleTimeString()}`;
});

const editedPost = ref(props.content);
const isEditing = ref(false);

function toggleEdit(event?: Event) {
    event?.preventDefault();
    isEditing.value = !isEditing.value!;
    console.log('Edit toggled');
}

async function handleSaveEdit() {
    const post = await postsService.updatePost(props.id, editedPost.value);
    console.log('handleSaveEdit result:', post);
    emit('editPost', post);
    toggleEdit();
}

async function handleLike(isLikedByUser: boolean) {
    const result = isLikedByUser
        ? await postsService.likePost(props.id)
        : await postsService.unlikePost(props.id);
    console.log('handleLike clicked result:', result);
    emit('editPost', {
        ...props,
        isLikedByUser,
        likes: result,
    });
}
</script>

<style scoped>
.edit-btn {
    text-decoration: none;
}

.content {
    white-space: pre-line;
}
</style>