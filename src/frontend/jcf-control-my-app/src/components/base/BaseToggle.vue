<!-- components/base/BaseToggle.vue -->
<script setup lang="ts">
defineProps<{
  modelValue: boolean
}>()

defineEmits(['update:modelValue'])
</script>

<template>
  <button
    type="button"
    @click="$emit('update:modelValue', !modelValue)"
    :class="[
      'w-10 h-6 flex items-center rounded-full p-1 duration-300',
      modelValue ? 'bg-blue-700 justify-end' : 'bg-gray-300 justify-start'
    ]"
  >
    <span class="w-4 h-4 bg-white rounded-full shadow"></span>
  </button>
</template>
