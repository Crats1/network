<template>
    <div class="card">
        <div class="card-body">
            <h3 class="card-title">{{ author }}</h3>
            <button @click="handleEditButton" class="btn btn-primary">Edit</button>
            <p class="card-text">{{ content }}</p>
            <p class="card-subtitle md-2 text-muted">{{ updatedAt }}</p>
            <button @click="handleLike" class="btn btn-primary">Like</button>
        </div>
    </div>
</template>

<script lang="ts" setup>
defineProps<{
    author: string,
    content: string,
    updatedAt: Date
}>();

function handleEditButton() {

}

function handleLike() {

}
</script>

<style scoped>
</style>