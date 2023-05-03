<template>
    <div class="card">
        <div class="card-body">
            <h3 class="card-title">New Post</h3>
            <form>
                <textarea
                    v-model="newContent"
                    class="form-control mb-1"
                    rows="3"
                >
                </textarea>
                <button @click="handleSubmit" type="submit" class="btn btn-primary">Post</button>
            </form>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import postsService from '@/services/posts';
import { Post } from '@/types';

const emit = defineEmits<{
    (e: 'addNewPost', newPost: Post): void,
}>();

const newContent = ref("");

async function handleSubmit(event: Event) {
    event.preventDefault();
    const newPost = await postsService.createPost(newContent.value);
    console.log('new-post-card result:', newPost);
    newContent.value = "";
    emit('addNewPost', newPost);
    return;
}
</script>

<style scoped>
</style>