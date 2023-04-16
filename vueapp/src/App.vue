<template>
  <NavBar />
  <div class="container">
    <router-view/>
  </div>
</template>

<script lang="ts" setup>
import NavBar from '@/components/NavBar.vue';
</script>

<style>
nav a.router-link-exact-active {
    /* color: #42b983; */
}
</style>
