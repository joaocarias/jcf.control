<template>
  <nav class="bg-white/80 backdrop-blur-lg text-gray-800 px-4 py-3 shadow-lg border-b border-purple-300/30">
    <div class="max-w-7xl mx-auto flex items-center justify-between">
      <!-- Esquerda: Botão hambúrguer -->
      <div class="flex items-center">
        <!-- Botão hambúrguer para mobile -->
        <button 
          @click="$emit('toggleSidebar')"
          class="lg:hidden text-cyan-600 hover:text-cyan-700 transition-colors p-2 rounded-lg hover:bg-purple-100/50"
        >
          <i class="fas fa-bars text-xl"></i>
        </button>
      </div>

      <!-- Direita: Nome do usuário + Sair -->
      <div class="flex items-center space-x-4">
        <span class="text-gray-600">Olá, <span class="text-cyan-600 font-semibold">{{ username }}</span></span>
        <button @click="logout" class="text-red-600 hover:text-red-700 text-sm transition-colors bg-red-50 hover:bg-red-100 px-3 py-1 rounded-lg border border-red-200">
          <i class="fas fa-sign-out-alt mr-1"></i> Sair
        </button>
      </div>
    </div>
  </nav>
</template>

<script setup>
import { ref } from 'vue'

const username = 'João Carias' // ou use store/autenticação

const logout = () => {
  alert('Logout executado')
}

defineEmits(['toggleSidebar'])
</script>

<style scoped>
/* Evita que os dropdowns fiquem cortados */
.relative > ul {
  min-width: 10rem;
}
</style>
