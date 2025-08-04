<template>
  <div class="flex justify-center items-center py-8">
    <div class="animate-spin rounded-full h-8 w-8 border-b-2 border-cyan-600"></div>
    <span class="ml-2 text-gray-600 dark:text-gray-400">{{ message }}</span>
  </div>
</template>

<script setup>
defineProps({
  message: {
    type: String,
    default: 'Carregando...'
  }
})
</script> 