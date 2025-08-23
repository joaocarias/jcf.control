<template>
  <button type="button" :disabled="loading" @click="handleSave"
    class="flex items-center justify-center px-4 py-2 text-white rounded-lg bg-brand-500 hover:bg-brand-600 disabled:opacity-50 disabled:cursor-not-allowed">
    <span v-if="!loading">
      <font-awesome-icon icon="save" />
      {{ label }}
    </span>
    <span v-else>
      {{ $t('Saving') }}...
    </span>
  </button>
</template>

<script setup lang="ts"  generic="T">
import { ref } from 'vue'

const { apiCall } = defineProps<{
  apiCall: () => Promise<T>
  label?: string
}>()

const emit = defineEmits<{
  success: [T]
  error: [unknown]
}>()

const loading = ref(false)

const handleSave = async () => {
  loading.value = true
  try {
    const result = await apiCall()
    alert('✅ Registro salvo com sucesso!')
    onSuccess:
    emit('success', result)
  } catch (err) {
    console.error(err)
    alert('❌ Ocorreu um erro ao salvar.')
    emit('error', err)
  } finally {
    loading.value = false
  }
}
</script>
