<template>
  <div class="bg-white/60 dark:bg-gray-900/60 backdrop-blur-sm text-gray-800 dark:text-gray-200 border-b border-purple-300/30 dark:border-gray-700/30">
    <div class="max-w-7xl mx-auto px-4 py-3">
      <div class="flex items-center justify-between">
        <!-- Título da Página -->
        <div>
          <h1 class="text-xl font-bold bg-gradient-to-r from-cyan-600 to-purple-600 dark:from-cyan-400 dark:to-purple-400 bg-clip-text text-transparent">
            {{ pageTitle }}
          </h1>
          <div class="w-20 h-1 bg-gradient-to-r from-cyan-500 to-purple-600 dark:from-cyan-400 dark:to-purple-500 mt-2 rounded-full"></div>
        </div>

        <!-- Breadcrumb -->
        <nav class="text-sm text-gray-600 dark:text-gray-400" aria-label="breadcrumb">
          <div class="flex items-center space-x-2">
            <!-- Ícone do breadcrumb -->
            <i class="fas fa-angle-right text-cyan-500 dark:text-cyan-400"></i>

            <!-- Caminho -->
            <ol class="flex items-center flex-wrap">
              <li v-for="(item, index) in breadcrumbList" :key="index" class="flex items-center">
                <span v-if="index !== 0" class="mx-2 text-purple-400 dark:text-purple-300">/</span>
                <span
                  class="capitalize transition-colors hover:text-cyan-600 dark:hover:text-cyan-400"
                  :class="{ 
                    'text-cyan-600 dark:text-cyan-400 font-semibold': index === breadcrumbList.length - 1,
                    'text-gray-600 dark:text-gray-400': index !== breadcrumbList.length - 1
                  }"
                >
                  {{ item }}
                </span>
              </li>
            </ol>
          </div>
        </nav>
      </div>
    </div>
  </div>
</template>

<script setup>
import { useRoute } from 'vue-router'
import { computed } from 'vue'

const route = useRoute()

const titleMap = {
  home: 'Dashboard',
  'cadastro/usuario/novo': 'Novo Usuário',
  'cadastro/usuario/editar': 'Editar Usuário',
  'cadastro/cliente/novo': 'Novo Cliente',
  'cadastro/cliente/editar': 'Editar Cliente',
  'cadastro/produto': 'Cadastro de Produtos',
  entrada: 'Financeiro - Entrada',
  saida: 'Financeiro - Saída',
}

const pageTitle = computed(() => {
  const cleanPath = route.path.replace(/^\/|\/$/g, '') // remove / do início e fim
  return titleMap[cleanPath] || 'Página'
})

const routeNameMap = {
  home: 'Home',
  cadastro: 'Cadastro',
  cliente: 'Cliente',
  novo: 'Novo',
  editar: 'Editar',
  produto: 'Produto',
  cor: 'Cor',
  usuario: 'Usuário',
  entrada: 'Entrada',
  saida: 'Saída',
}

const breadcrumbList = computed(() => {
  const parts = route.path
    .split('/')
    .filter(Boolean)
    .map(p => routeNameMap[p.toLowerCase()] || p)

  return parts.length ? parts : ['Home']
})
</script>
