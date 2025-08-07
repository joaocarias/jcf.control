<template>
  <div class="flex h-screen bg-gradient-to-br from-blue-50 via-white to-purple-50 dark:from-gray-900 dark:via-gray-800 dark:to-gray-900 text-gray-800 dark:text-gray-200 overflow-hidden">
    <!-- Background Cyberpunk Claro/Dark -->
    <div class="absolute inset-0 z-0 pointer-events-none">
      <!-- Grid Cyberpunk Claro -->
      <svg class="w-full h-full opacity-10 dark:opacity-5" xmlns="http://www.w3.org/2000/svg">
        <defs>
          <pattern id="admin-grid-light" width="40" height="40" patternUnits="userSpaceOnUse">
            <path d="M 40 0 L 0 0 0 40" fill="none" stroke="#0891b2" stroke-width="0.5"/>
          </pattern>
          <pattern id="admin-grid-dark" width="40" height="40" patternUnits="userSpaceOnUse">
            <path d="M 40 0 L 0 0 0 40" fill="none" stroke="#06b6d4" stroke-width="0.5"/>
          </pattern>
        </defs>
        <rect width="100%" height="100%" fill="url(#admin-grid-light)" class="dark:hidden" />
        <rect width="100%" height="100%" fill="url(#admin-grid-dark)" class="hidden dark:block" />
      </svg>

      <!-- Elementos decorativos claros -->
      <div class="absolute top-20 right-20 w-32 h-32 bg-cyan-400/20 dark:bg-cyan-400/10 border border-cyan-400/30 dark:border-cyan-400/20 rounded-full blur-3xl animate-pulse" />
      <div class="absolute bottom-40 left-40 w-24 h-24 bg-purple-400/20 dark:bg-purple-400/10 border border-purple-400/30 dark:border-purple-400/20 rounded-full blur-3xl animate-spin-slow" />
    </div>

    <!-- Sidebar -->
    <Sidebar :isOpen="sidebarOpen" @toggle="sidebarOpen = !sidebarOpen" />

    <!-- Main Content -->
    <div class="flex-1 flex flex-col relative z-10">
      <!-- Navbar -->
      <Navbar @toggleSidebar="sidebarOpen = !sidebarOpen" />

      <!-- Separador Cyberpunk Claro/Dark -->
      <div class="relative">
        <div class="border-b border-purple-300/50 dark:border-gray-700/50"></div>
        <div class="absolute inset-0 bg-gradient-to-r from-transparent via-cyan-400/30 dark:via-cyan-400/20 to-transparent h-px"></div>
      </div>

      <div class="flex-1 flex flex-col">
        <!-- <PageTitle /> -->

        <!-- Conteúdo principal -->
        <div class="max-w-7xl mx-auto px-4 py-4 text-gray-800 dark:text-gray-200">
          <router-view />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import Navbar from '@/components/layout/Navbar.vue'
import Sidebar from '@/components/layout/Sidebar.vue'

const sidebarOpen = ref(false)
</script>

<style scoped>
@keyframes spin-slow {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
.animate-spin-slow {
  animation: spin-slow 30s linear infinite;
}
</style>
