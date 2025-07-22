<script setup lang="ts">
import LoginBackground from '@/components/auth/LoginBackground.vue'
import LoginPanel from '@/components/auth/LoginPanel.vue'
</script>

<template>
  <section class="relative min-h-screen flex items-center justify-center bg-gradient-to-br from-purple-950 via-black to-blue-950 text-white overflow-hidden">
    <LoginBackground />
    <LoginPanel />
  </section>
</template>
