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
            <button @click="handleLike" class="btn btn-primary">Like</button>
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

function handleLike() {
    console.log('Like btn clicked');
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