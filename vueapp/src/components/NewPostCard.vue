<template>
    <div class="card">
        <div class="card-body">
            <h3 class="card-title">New Post</h3>
            <form>
                <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                <button @click="handleSubmit" type="submit" class="btn btn-primary">Post</button>
            </form>
        </div>
    </div>
</template>

<script lang="ts" setup>
const emit = defineEmits<{
    (e: 'addNewPost', content: string): void,
}>();

function handleSubmit() {
    console.log('new-post-card submit btn pressed');
    emit('addNewPost', 'test');
    return;
}
</script>

<style scoped>
</style>