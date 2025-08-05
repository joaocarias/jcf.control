<template>
  <nav class="text-sm text-gray-600 mb-4" aria-label="breadcrumb">
    <div class="max-w-7xl mx-auto px-4 py-2 flex items-center space-x-2">
      <!-- Ícone do breadcrumb -->
      <i class="fas fa-angle-right text-cyan-500"></i>

      <!-- Caminho -->
      <ol class="flex items-center flex-wrap">
        <li v-for="(item, index) in breadcrumbList" :key="index" class="flex items-center">
          <span v-if="index !== 0" class="mx-2 text-purple-400">/</span>
          <span
            class="capitalize transition-colors hover:text-cyan-600"
            :class="{ 
              'text-cyan-600 font-semibold': index === breadcrumbList.length - 1,
              'text-gray-600': index !== breadcrumbList.length - 1
            }"
          >
            {{ item }}
          </span>
        </li>
      </ol>
    </div>
  </nav>
</template>

<script setup>
import { useRoute } from 'vue-router'
import { computed } from 'vue'

const route = useRoute()

const routeNameMap = {
  home: 'Home',
  cadastros: 'Cadastros',
  cliente: 'Cliente',
  novo: 'Novo',
  editar: 'Editar',
  produto: 'Produto',
  cor: 'Cor',
  usuarios: 'Usuários',
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
