<template>
  <nav class="bg-black/40 backdrop-blur-lg text-white px-4 py-3 shadow-lg border-b border-purple-500/20">
    <div class="max-w-7xl mx-auto flex items-center justify-between">
      <!-- Esquerda: Botão hambúrguer + Título -->
      <div class="flex items-center space-x-4">
        <!-- Botão hambúrguer para mobile -->
        <button 
          @click="$emit('toggleSidebar')"
          class="lg:hidden text-cyan-400 hover:text-cyan-300 transition-colors p-2 rounded-lg hover:bg-purple-500/20"
        >
          <i class="fas fa-bars text-xl"></i>
        </button>
        
        
      </div>

      <!-- Direita: Nome do usuário + Sair -->
      <div class="flex items-center space-x-4">
        <span class="text-purple-300">Olá, <span class="text-cyan-400 font-semibold">{{ username }}</span></span>
        <button @click="logout" class="text-red-400 hover:text-red-300 text-sm transition-colors bg-red-900/20 hover:bg-red-900/40 px-3 py-1 rounded-lg border border-red-500/30">
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
