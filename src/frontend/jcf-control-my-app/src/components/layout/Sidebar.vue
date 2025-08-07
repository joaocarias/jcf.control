<template>
  <!-- Overlay para mobile (fora do sidebar) -->
  <div 
    v-if="isOpen" 
    class="fixed inset-0 bg-black/20 lg:hidden z-40"
    @click="$emit('toggle')"
  ></div>

  <aside 
    :class="[
      'fixed lg:static inset-y-0 left-0 z-50 w-64 bg-white/90 dark:bg-gray-900/90 backdrop-blur-lg border-r border-purple-300/50 dark:border-gray-700/50 transform transition-transform duration-300 ease-in-out shadow-xl',
      isOpen ? 'translate-x-0' : '-translate-x-full lg:translate-x-0'
    ]"
  >
    <div class="flex flex-col h-full relative z-50">
      <!-- Header do Sidebar -->
      <div class="p-4">
        <div class="flex items-center justify-center">
          <h2 class="text-xl font-bold bg-gradient-to-r from-cyan-800 to-purple-800 dark:from-cyan-400 dark:to-purple-400 bg-clip-text text-transparent">
            {{ title }}
          </h2>
        </div>
      </div>

      <!-- Menu de Navegação -->
      <nav class="flex-1 p-4 space-y-2">
        <!-- Dashboard -->
        <router-link 
         :to="{ name: RouteName.HOME }"
          class="flex items-center gap-3 px-4 py-3 rounded-lg text-gray-600 dark:text-gray-300 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/80 dark:hover:bg-gray-800/80 transition-all duration-200 group"
          active-class="bg-gradient-to-r from-purple-100/80 to-cyan-100/80 dark:from-purple-900/80 dark:to-cyan-900/80 text-cyan-600 dark:text-cyan-400 border-l-4 border-cyan-500 dark:border-cyan-400"
        >
          <i class="fas fa-tachometer-alt text-lg group-hover:scale-110 transition-transform"></i>
          <span>Dashboard</span>
        </router-link>

        <!-- Cadastros (Menu Expansível) -->
        <div class="space-y-1">
          <button 
            @click="toggleCadastro"
            class="w-full flex items-center justify-between gap-3 px-4 py-3 rounded-lg text-gray-600 dark:text-gray-300 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/80 dark:hover:bg-gray-800/80 transition-all duration-200 group"
          >
            <div class="flex items-center gap-3">
              <i class="fas fa-database text-lg group-hover:scale-110 transition-transform"></i>
              <span>{{ $t('registers') }} </span>
            </div>
            <i 
              :class="[
                'fas transition-transform duration-200',
                isCadastroOpen ? 'fa-chevron-up' : 'fa-chevron-down'
              ]"
            ></i>
          </button>
          
          <!-- Subitens do Cadastro -->
          <div 
            v-show="isCadastroOpen"
            class="ml-6 space-y-1 transition-all duration-200"
          >
            <!-- Produtos -->
            <router-link 
              to="/cadastros/produtos"
              class="flex items-center gap-3 px-4 py-2 rounded-lg text-gray-500 dark:text-gray-400 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/60 dark:hover:bg-gray-800/60 transition-all duration-200 group text-sm"
              active-class="bg-gradient-to-r from-purple-100/60 to-cyan-100/60 dark:from-purple-900/60 dark:to-cyan-900/60 text-cyan-600 dark:text-cyan-400 border-l-2 border-cyan-400 dark:border-cyan-300"
            >
              <i class="fas fa-box text-sm group-hover:scale-110 transition-transform"></i>
              <span>Produtos</span>
            </router-link>

            <!-- Cores -->
            <router-link 
              to="/cadastros/cores"
              class="flex items-center gap-3 px-4 py-2 rounded-lg text-gray-500 dark:text-gray-400 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/60 dark:hover:bg-gray-800/60 transition-all duration-200 group text-sm"
              active-class="bg-gradient-to-r from-purple-100/60 to-cyan-100/60 dark:from-purple-900/60 dark:to-cyan-900/60 text-cyan-600 dark:text-cyan-400 border-l-2 border-cyan-400 dark:border-cyan-300"
            >
              <i class="fas fa-palette text-sm group-hover:scale-110 transition-transform"></i>
              <span>Cores</span>
            </router-link>

            <!-- Tamanhos -->
            <router-link 
              to="/cadastros/tamanhos"
              class="flex items-center gap-3 px-4 py-2 rounded-lg text-gray-500 dark:text-gray-400 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/60 dark:hover:bg-gray-800/60 transition-all duration-200 group text-sm"
              active-class="bg-gradient-to-r from-purple-100/60 to-cyan-100/60 dark:from-purple-900/60 dark:to-cyan-900/60 text-cyan-600 dark:text-cyan-400 border-l-2 border-cyan-400 dark:border-cyan-300"
            >
              <i class="fas fa-ruler text-sm group-hover:scale-110 transition-transform"></i>
              <span>Tamanhos</span>
            </router-link>

            <!-- Usuários -->
            <router-link 
              :to="{ name: RouteName.USERS }"
              class="flex items-center gap-3 px-4 py-2 rounded-lg text-gray-500 dark:text-gray-400 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/60 dark:hover:bg-gray-800/60 transition-all duration-200 group text-sm"
              active-class="bg-gradient-to-r from-purple-100/60 to-cyan-100/60 dark:from-purple-900/60 dark:to-cyan-900/60 text-cyan-600 dark:text-cyan-400 border-l-2 border-cyan-400 dark:border-cyan-300"
            >
              <i class="fas fa-user-plus text-sm group-hover:scale-110 transition-transform"></i>
              <span>{{ $t('users') }}</span>
            </router-link>
          </div>
        </div>

        <!-- Usuários -->
        <router-link 
          to="/users"
          class="flex items-center gap-3 px-4 py-3 rounded-lg text-gray-600 dark:text-gray-300 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/80 dark:hover:bg-gray-800/80 transition-all duration-200 group"
          active-class="bg-gradient-to-r from-purple-100/80 to-cyan-100/80 dark:from-purple-900/80 dark:to-cyan-900/80 text-cyan-600 dark:text-cyan-400 border-l-4 border-cyan-500 dark:border-cyan-400"
        >
          <i class="fas fa-users text-lg group-hover:scale-110 transition-transform"></i>
          <span>Usuários</span>
        </router-link>

        <!-- Configurações -->
        <router-link 
          to="/settings"
          class="flex items-center gap-3 px-4 py-3 rounded-lg text-gray-600 dark:text-gray-300 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/80 dark:hover:bg-gray-800/80 transition-all duration-200 group"
          active-class="bg-gradient-to-r from-purple-100/80 to-cyan-100/80 dark:from-purple-900/80 dark:to-cyan-900/80 text-cyan-600 dark:text-cyan-400 border-l-4 border-cyan-500 dark:border-cyan-400"
        >
          <i class="fas fa-cog text-lg group-hover:scale-110 transition-transform"></i>
          <span>Configurações</span>
        </router-link>

        <!-- Relatórios -->
        <router-link 
          to="/reports"
          class="flex items-center gap-3 px-4 py-3 rounded-lg text-gray-600 dark:text-gray-300 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/80 dark:hover:bg-gray-800/80 transition-all duration-200 group"
          active-class="bg-gradient-to-r from-purple-100/80 to-cyan-100/80 dark:from-purple-900/80 dark:to-cyan-900/80 text-cyan-600 dark:text-cyan-400 border-l-4 border-cyan-500 dark:border-cyan-400"
        >
          <i class="fas fa-chart-bar text-lg group-hover:scale-110 transition-transform"></i>
          <span>Relatórios</span>
        </router-link>

        <!-- Sistema -->
        <router-link 
          to="/system"
          class="flex items-center gap-3 px-4 py-3 rounded-lg text-gray-600 dark:text-gray-300 hover:text-cyan-600 dark:hover:text-cyan-400 hover:bg-purple-50/80 dark:hover:bg-gray-800/80 transition-all duration-200 group"
          active-class="bg-gradient-to-r from-purple-100/80 to-cyan-100/80 dark:from-purple-900/80 dark:to-cyan-900/80 text-cyan-600 dark:text-cyan-400 border-l-4 border-cyan-500 dark:border-cyan-400"
        >
          <i class="fas fa-server text-lg group-hover:scale-110 transition-transform"></i>
          <span>Sistema</span>
        </router-link>
      </nav>

      <!-- Footer do Sidebar -->
      <div class="p-4 border-t border-purple-300/50 dark:border-gray-700/50">
        <div class="text-center">
          <div class="w-12 h-12 mx-auto mb-3 bg-gradient-to-r from-cyan-500 to-purple-600 dark:from-cyan-400 dark:to-purple-500 rounded-full flex items-center justify-center shadow-lg">
            <i class="fas fa-shield-alt text-white text-lg"></i>
          </div>
          <p class="text-xs text-gray-500 dark:text-gray-400">Sistema Seguro</p>
          <p class="text-xs text-cyan-600 dark:text-cyan-400 font-mono">v1.0.0</p>
        </div>
      </div>
    </div>
  </aside>
</template>

<script setup>
import { ref } from 'vue'
import { APP_TITLE } from '@/constants/app.js'
import { RouteName } from '@/router/route-names.js'

const title = APP_TITLE
const isCadastroOpen = ref(false)

const toggleCadastro = () => {
  isCadastroOpen.value = !isCadastroOpen.value
}

defineProps({
  isOpen: {
    type: Boolean,
    default: false
  }
})

defineEmits(['toggle'])
</script>

<style scoped>
/* Efeito de brilho nos itens ativos */
.router-link-active {
  position: relative;
  overflow: hidden;
}

.router-link-active::before {
  content: '';
  position: absolute;
  top: 0;
  left: -100%;
  width: 100%;
  height: 100%;
  background: linear-gradient(90deg, transparent, rgba(6, 182, 212, 0.1), transparent);
  animation: shimmer 2s infinite;
}

@keyframes shimmer {
  0% {
    left: -100%;
  }
  100% {
    left: 100%;
  }
}
</style> 