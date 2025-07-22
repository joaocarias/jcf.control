<script setup lang="ts">
import Sidebar from '@/components/layout/Sidebar.vue'
import Topbar from '@/components/layout/Topbar.vue'
</script>

<template>
  <div class="flex">
    <Sidebar />
    <div class="flex-1 ml-64">
      <Topbar />
      <main class="mt-16 p-6 bg-gradient-to-br from-gray-900 to-black min-h-screen text-white">
        <slot />
      </main>
    </div>
  </div>
</template>
