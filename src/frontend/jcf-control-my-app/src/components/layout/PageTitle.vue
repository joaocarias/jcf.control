<template>
  <div class="bg-black/20 backdrop-blur-sm text-white border-b border-purple-500/20">
    <div class="max-w-7xl mx-auto px-4 py-3">
      <h1 class="text-xl font-bold bg-gradient-to-r from-cyan-400 to-purple-400 bg-clip-text text-transparent">
        {{ pageTitle }}
      </h1>
      <div class="w-20 h-1 bg-gradient-to-r from-cyan-500 to-purple-600 mt-2 rounded-full"></div>
    </div>
  </div>
</template>

<script setup>
import { useRoute } from 'vue-router'
import { computed } from 'vue'

const route = useRoute()

const titleMap = {
  home: 'Dashboard Principal',
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
</script>
