<!-- components/base/BaseButton.vue -->
<script setup lang="ts">
defineProps<{
  type?: string
}>()
</script>

<template>
  <button
    :type="type || 'button'"
    class="w-full bg-gradient-to-r from-blue-400 to-blue-600 text-white font-bold py-2 rounded-md hover:from-blue-500 hover:to-blue-700 transition"
  >
    <slot />
  </button>
</template>
