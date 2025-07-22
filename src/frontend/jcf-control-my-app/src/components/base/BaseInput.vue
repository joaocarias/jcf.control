<!-- components/base/BaseInput.vue -->
<script setup lang="ts">
defineProps<{
  modelValue: string
  type?: string
  label?: string
  placeholder?: string
}>()

defineEmits(['update:modelValue'])
</script>

<template>
  <div>
    <label v-if="label" class="block text-sm font-semibold text-gray-700 mb-1">{{ label }}</label>
    <input
      :type="type || 'text'"
      :placeholder="placeholder"
      :value="modelValue"
      @input="$emit('update:modelValue', $event.target.value)"
      class="w-full border border-gray-300 rounded-md px-4 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
    />
  </div>
</template>
