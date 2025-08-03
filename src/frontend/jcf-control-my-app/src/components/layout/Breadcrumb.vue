<template>
  <nav class="text-sm text-purple-300 mb-4" aria-label="breadcrumb">
    <div class="max-w-7xl mx-auto px-4 py-2 flex items-center space-x-2">
      <!-- Ícone do breadcrumb -->
      <i class="fas fa-angle-right text-cyan-400"></i>

      <!-- Caminho -->
      <ol class="flex items-center flex-wrap">
        <li v-for="(item, index) in breadcrumbList" :key="index" class="flex items-center">
          <span v-if="index !== 0" class="mx-2 text-purple-500">/</span>
          <span
            class="capitalize transition-colors hover:text-cyan-400"
            :class="{ 
              'text-cyan-400 font-semibold': index === breadcrumbList.length - 1,
              'text-purple-300': index !== breadcrumbList.length - 1
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
