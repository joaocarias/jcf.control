<template>
  <router-link
    :to="to"
    class="inline-flex items-center px-4 py-2 text-white bg-blue-600 hover:bg-blue-700 rounded-lg shadow text-sm font-medium transition-colors duration-200"
  >
    <svg
      xmlns="http://www.w3.org/2000/svg"
      class="h-4 w-4 mr-2"
      fill="none"
      viewBox="0 0 24 24"
      stroke="currentColor"
    >
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
    </svg>
    {{ $t('Add') }}
  </router-link>
</template>

<script setup lang="ts">
defineProps<{
  to: string
}>()
</script>
