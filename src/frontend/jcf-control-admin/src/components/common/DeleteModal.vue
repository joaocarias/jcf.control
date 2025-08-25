<script setup lang="ts">
import { defineProps, defineEmits } from "vue"

interface Props {
  modelValue: boolean // controla se o modal está aberto ou não
  title?: string
  message?: string
  entityName?: string // nome da entidade (Usuário, Cliente, Cor, etc.)
  confirmText?: string
  cancelText?: string
}

const props = defineProps<Props>()

const emit = defineEmits<{
  (e: "update:modelValue", value: boolean): void
  (e: "confirm"): void
  (e: "cancel"): void
}>()

const handleConfirm = () => {
  emit("confirm")
  emit("update:modelValue", false)
}

const handleCancel = () => {
  emit("cancel")
  emit("update:modelValue", false)
}
</script>

<template>
  <div
    v-if="modelValue"
    class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-50"
  >
    <div class="bg-white dark:bg-gray-800 p-6 rounded-xl shadow-xl w-full max-w-md">
      <h2 class="text-xl font-bold text-gray-900 dark:text-gray-100 mb-2">
        {{ title || "Confirmar Exclusão" }}
      </h2>
      <p class="text-gray-700 dark:text-gray-300 mb-4">
        {{ message || `Tem certeza que deseja excluir este ${entityName || 'item'}?` }}
      </p>

      <div class="flex justify-end gap-3">
        <button
          class="px-4 py-2 rounded-lg bg-gray-300 hover:bg-gray-400 text-gray-800"
          @click="handleCancel"
        >
          {{ cancelText || "Cancelar" }}
        </button>
        <button
          class="px-4 py-2 rounded-lg bg-red-600 hover:bg-red-700 text-white"
          @click="handleConfirm"
        >
          {{ confirmText || "Excluir" }}
        </button>
      </div>
    </div>
  </div>
</template>
