<script lang="ts" setup>
import { defineProps } from 'vue';

const props = defineProps<{
    msg: string
}>();
console.log('HelloWorld.vue props:', { props });
</script>

<template>
  <div class="hello">
    <h1>{{ msg || 'No message' }}</h1>
    <h1>Test</h1>
  </div>
</template>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
