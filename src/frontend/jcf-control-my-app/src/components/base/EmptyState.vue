<template>
  <div v-if="!loading && isEmpty" class="text-center py-8">
    <i :class="icon" class="text-gray-400 dark:text-gray-500 text-4xl mb-4"></i>
    <p class="text-gray-500 dark:text-gray-400">{{ message }}</p>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  isEmpty: boolean
  loading?: boolean
  message?: string
  icon?: string
}>()
</script>
