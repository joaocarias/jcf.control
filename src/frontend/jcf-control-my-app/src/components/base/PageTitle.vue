<template>
  <div class="mb-6">
    <h1 class="text-2xl font-bold text-gray-900 dark:text-gray-100">{{ title }}</h1>
    <p class="text-gray-600 dark:text-gray-400">{{ subtitle }}</p>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  title: string
  subtitle?: string
}>()
</script>
