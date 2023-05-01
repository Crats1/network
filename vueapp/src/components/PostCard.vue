<template>
    <div class="card">
        <div class="card-body">
            <h3 class="card-title">{{ author }}</h3>
            <button v-if="isEditable" @click="handleEditButton" class="btn btn-primary">Edit</button>
            <p class="card-text">{{ content }}</p>
            <p class="card-subtitle md-2 text-muted">{{ updatedAt }}</p>
            <button @click="handleLike" class="btn btn-primary">Like</button>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { userKey } from '@/keys';
import { computed, inject } from 'vue';

const props = defineProps<{
    author: string,
    content: string,
    updatedAt: Date
    userId: number;
}>();

const userProvider = inject(userKey);

const isEditable = computed(() => {
    console.log('postCard isEditable:', userProvider, props);
    return userProvider?.user.value?.id === props.userId;
});

function handleEditButton() {

}

function handleLike() {

}
</script>

<style scoped>
</style>