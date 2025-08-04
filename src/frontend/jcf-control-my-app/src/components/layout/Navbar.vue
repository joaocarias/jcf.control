<template>
  <nav class="bg-white/80 dark:bg-gray-900/80 backdrop-blur-lg text-gray-800 dark:text-gray-200 px-4 py-3 shadow-lg border-b border-purple-300/30 dark:border-gray-700/30">
    <div class="max-w-7xl mx-auto flex items-center justify-between">
      <!-- Esquerda: Botão hambúrguer -->
      <div class="flex items-center">
        <!-- Botão hambúrguer para mobile -->
        <button 
          @click="$emit('toggleSidebar')"
          class="lg:hidden text-cyan-600 dark:text-cyan-400 hover:text-cyan-700 dark:hover:text-cyan-300 transition-colors p-2 rounded-lg hover:bg-purple-100/50 dark:hover:bg-gray-800/50"
        >
          <i class="fas fa-bars text-xl"></i>
        </button>
      </div>

      <!-- Direita: Nome do usuário + Botão tema + Sair -->
      <div class="flex items-center space-x-4">
        <!-- Botão de alternância de tema -->
        <button 
          @click="toggleTheme" 
          class="text-gray-600 dark:text-gray-300 hover:text-cyan-600 dark:hover:text-cyan-400 transition-colors p-2 rounded-lg hover:bg-purple-100/50 dark:hover:bg-gray-800/50"
          :title="isDark ? 'Mudar para modo claro' : 'Mudar para modo escuro'"
        >
          <i :class="isDark ? 'fas fa-sun' : 'fas fa-moon'" class="text-lg"></i>
        </button>
        
        <span class="text-gray-600 dark:text-gray-300">Olá, <span class="text-cyan-600 dark:text-cyan-400 font-semibold">{{ username }}</span></span>
                      
        <button @click="logout" class="text-red-600 dark:text-red-400 hover:text-red-700 dark:hover:text-red-300 text-sm transition-colors bg-red-50 dark:bg-red-900/20 hover:bg-red-100 dark:hover:bg-red-900/30 px-3 py-1 rounded-lg border border-red-200 dark:border-red-800">
          <i class="fas fa-sign-out-alt mr-1"></i> Sair
        </button>
      </div>
    </div>
  </nav>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useThemeStore } from '@/stores/theme'
import { logoutStorage } from '@/utils/auth'

const { isDark, toggleTheme } = useThemeStore()
const username = ref('Usuário')

// Função para obter o primeiro nome do usuário do sessionStorage
const getUserFirstName = () => {
  try {
    const userData = sessionStorage.getItem('jcf_control_app_auth_user')
    if (userData) {
      const user = JSON.parse(userData)
      return user.firstName || 'Usuário'
    }
  } catch (error) {
    console.error('Erro ao obter dados do usuário:', error)
  }
  return 'Usuário'
}

const logout = () => {
  logoutStorage()
  // Aqui você pode adicionar redirecionamento para login se necessário
  alert('Logout executado')
}

onMounted(() => {
  username.value = getUserFirstName()
})

defineEmits(['toggleSidebar'])
</script>

<style scoped>
/* Evita que os dropdowns fiquem cortados */
.relative > ul {
  min-width: 10rem;
}
</style>
