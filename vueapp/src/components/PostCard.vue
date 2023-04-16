<template>
    <div class="card">
        <div class="card-body">
            <h3 class="card-title">{{ author }}</h3>
            <p class="card-text">{{ content }}</p>
            <p class="card-subtitle md-2 text-muted">{{ postDate }}</p>
        </div>
    </div>
</template>

<script lang="ts" setup>
defineProps<{
    author: string,
    content: string,
    postDate: string
}>();
</script>

<style scoped>
</style>