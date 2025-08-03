<template>
  <div class="flex h-screen bg-gradient-to-br from-purple-950 via-black to-blue-950 text-white overflow-hidden">
    <!-- Background Cyberpunk -->
    <div class="absolute inset-0 z-0 pointer-events-none">
      <!-- Grid Cyberpunk -->
      <svg class="w-full h-full opacity-5" xmlns="http://www.w3.org/2000/svg">
        <defs>
          <pattern id="admin-grid" width="40" height="40" patternUnits="userSpaceOnUse">
            <path d="M 40 0 L 0 0 0 40" fill="none" stroke="cyan" stroke-width="0.5"/>
          </pattern>
        </defs>
        <rect width="100%" height="100%" fill="url(#admin-grid)" />
      </svg>

      <!-- Elementos decorativos -->
      <div class="absolute top-20 right-20 w-32 h-32 bg-cyan-500/5 border border-cyan-500/20 rounded-full blur-3xl animate-pulse" />
      <div class="absolute bottom-40 left-40 w-24 h-24 bg-purple-500/5 border border-purple-500/20 rounded-full blur-3xl animate-spin-slow" />
    </div>

    <!-- Sidebar -->
    <Sidebar :isOpen="sidebarOpen" @toggle="sidebarOpen = !sidebarOpen" />

    <!-- Main Content -->
    <div class="flex-1 flex flex-col relative z-10">
      <!-- Navbar -->
      <Navbar @toggleSidebar="sidebarOpen = !sidebarOpen" />

      <!-- Separador Cyberpunk -->
      <div class="relative">
        <div class="border-b border-purple-500/30"></div>
        <div class="absolute inset-0 bg-gradient-to-r from-transparent via-cyan-500/20 to-transparent h-px"></div>
      </div>

      <div class="flex-1 flex flex-col">
        <PageTitle />

        <!-- Breadcrumb -->
        <Breadcrumb />

        <!-- Conteúdo principal -->
        <div class="max-w-7xl mx-auto px-4 py-4 text-white">
          <router-view />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import Breadcrumb from '@/components/layout/Breadcrumb.vue'
import Navbar from '@/components/layout/Navbar.vue'
import PageTitle from '@/components/layout/PageTitle.vue'
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
