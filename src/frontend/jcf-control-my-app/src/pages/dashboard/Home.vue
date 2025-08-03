<template>
  <div class="space-y-6">
    <!-- Cards de Estatísticas -->
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
      <!-- Card Usuários -->
      <div class="bg-white/80 backdrop-blur-lg rounded-xl border border-purple-200/50 p-6 hover:border-cyan-300/70 transition-all duration-300 group shadow-lg">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-gray-600 text-sm">Total de Usuários</p>
            <p class="text-3xl font-bold text-cyan-600">1,234</p>
            <p class="text-green-600 text-xs">+12% este mês</p>
          </div>
          <div class="w-12 h-12 bg-gradient-to-r from-purple-500 to-cyan-500 rounded-lg flex items-center justify-center group-hover:scale-110 transition-transform shadow-lg">
            <i class="fas fa-users text-white text-lg"></i>
          </div>
        </div>
      </div>

      <!-- Card Vendas -->
      <div class="bg-white/80 backdrop-blur-lg rounded-xl border border-purple-200/50 p-6 hover:border-cyan-300/70 transition-all duration-300 group shadow-lg">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-gray-600 text-sm">Vendas do Mês</p>
            <p class="text-3xl font-bold text-cyan-600">R$ 45.6k</p>
            <p class="text-green-600 text-xs">+8% este mês</p>
          </div>
          <div class="w-12 h-12 bg-gradient-to-r from-purple-500 to-cyan-500 rounded-lg flex items-center justify-center group-hover:scale-110 transition-transform shadow-lg">
            <i class="fas fa-chart-line text-white text-lg"></i>
          </div>
        </div>
      </div>

      <!-- Card Produtos -->
      <div class="bg-white/80 backdrop-blur-lg rounded-xl border border-purple-200/50 p-6 hover:border-cyan-300/70 transition-all duration-300 group shadow-lg">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-gray-600 text-sm">Produtos Ativos</p>
            <p class="text-3xl font-bold text-cyan-600">567</p>
            <p class="text-green-600 text-xs">+5% este mês</p>
          </div>
          <div class="w-12 h-12 bg-gradient-to-r from-purple-500 to-cyan-500 rounded-lg flex items-center justify-center group-hover:scale-110 transition-transform shadow-lg">
            <i class="fas fa-box text-white text-lg"></i>
          </div>
        </div>
      </div>

      <!-- Card Clientes -->
      <div class="bg-white/80 backdrop-blur-lg rounded-xl border border-purple-200/50 p-6 hover:border-cyan-300/70 transition-all duration-300 group shadow-lg">
        <div class="flex items-center justify-between">
          <div>
            <p class="text-gray-600 text-sm">Clientes Ativos</p>
            <p class="text-3xl font-bold text-cyan-600">892</p>
            <p class="text-green-600 text-xs">+15% este mês</p>
          </div>
          <div class="w-12 h-12 bg-gradient-to-r from-purple-500 to-cyan-500 rounded-lg flex items-center justify-center group-hover:scale-110 transition-transform shadow-lg">
            <i class="fas fa-user-friends text-white text-lg"></i>
          </div>
        </div>
      </div>
    </div>

    <!-- Seção de Ações Rápidas -->
    <div class="bg-white/80 backdrop-blur-lg rounded-xl border border-purple-200/50 p-6 shadow-lg">
      <h3 class="text-xl font-bold text-cyan-600 mb-4">Ações Rápidas</h3>
      <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
        <button class="flex items-center gap-3 p-4 bg-gradient-to-r from-purple-50/80 to-cyan-50/80 rounded-lg border border-purple-200/50 hover:border-cyan-300/70 transition-all duration-300 group shadow-md">
          <i class="fas fa-plus text-cyan-600 group-hover:scale-110 transition-transform"></i>
          <span class="text-gray-700 group-hover:text-cyan-600 transition-colors">Novo Cliente</span>
        </button>
        
        <button class="flex items-center gap-3 p-4 bg-gradient-to-r from-purple-50/80 to-cyan-50/80 rounded-lg border border-purple-200/50 hover:border-cyan-300/70 transition-all duration-300 group shadow-md">
          <i class="fas fa-box text-cyan-600 group-hover:scale-110 transition-transform"></i>
          <span class="text-gray-700 group-hover:text-cyan-600 transition-colors">Novo Produto</span>
        </button>
        
        <button class="flex items-center gap-3 p-4 bg-gradient-to-r from-purple-50/80 to-cyan-50/80 rounded-lg border border-purple-200/50 hover:border-cyan-300/70 transition-all duration-300 group shadow-md">
          <i class="fas fa-chart-bar text-cyan-600 group-hover:scale-110 transition-transform"></i>
          <span class="text-gray-700 group-hover:text-cyan-600 transition-colors">Ver Relatórios</span>
        </button>
      </div>
    </div>

    <!-- Mensagem de Boas-vindas -->
    <div class="bg-gradient-to-r from-purple-50/80 to-cyan-50/80 backdrop-blur-lg rounded-xl border border-purple-200/50 p-6 shadow-lg">
      <div class="flex items-center gap-4">
        <div class="w-16 h-16 bg-gradient-to-r from-cyan-500 to-purple-600 rounded-full flex items-center justify-center shadow-lg">
          <i class="fas fa-shield-alt text-white text-2xl"></i>
        </div>
        <div>
          <h2 class="text-2xl font-bold bg-gradient-to-r from-cyan-600 to-purple-600 bg-clip-text text-transparent">
            Bem-vindo ao JCF Control
          </h2>
          <p class="text-gray-600 mt-2">
            Sistema de controle moderno e seguro. Monitore suas operações em tempo real.
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
// Componente de dashboard com tema cyberpunk claro
</script>