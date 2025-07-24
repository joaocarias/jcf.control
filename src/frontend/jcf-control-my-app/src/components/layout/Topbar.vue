<script setup lang="ts">
import { ref } from 'vue'
import { APP_TITLE } from '@/constants/app'

const showMenu = ref(false)
</script>

<template>
  <header class="w-full h-16 bg-black/60 text-white flex justify-between items-center px-6 shadow-md fixed top-0 left-64 z-10">
    <!-- Nome do sistema -->
    <h1 class="text-xl font-semibold">{{ APP_TITLE }}</h1>

    <!-- Ações -->
    <div class="flex items-center gap-6">
      <!-- Notificação -->
      <button class="hover:text-cyan-400">
        <i class="fas fa-bell"></i>
      </button>

      <!-- Perfil -->
      <div class="relative">
        <button @click="showMenu = !showMenu" class="hover:text-cyan-400 focus:outline-none">
          <i class="fas fa-user-circle text-xl"></i>
        </button>
        <div v-if="showMenu" class="absolute right-0 mt-2 w-40 bg-white text-black rounded shadow-lg z-50">
          <a href="#" class="block px-4 py-2 hover:bg-gray-100">Perfil</a>
          <a href="#" class="block px-4 py-2 hover:bg-gray-100">Sair</a>
        </div>
      </div>
    </div>
  </header>
</template>
