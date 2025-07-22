<script setup lang="ts">
import LoginForm from './LoginForm.vue'
</script>

<template>
  <div class="relative z-10 w-full max-w-md bg-white/10 backdrop-blur-lg rounded-xl shadow-xl border border-purple-500 p-8">
    <h1 class="text-3xl font-bold text-center text-cyan-400 mb-4">JCF Control App</h1>
    <p class="text-sm text-purple-300 text-center mb-6">Acesso ao Painel de Controle</p>
    <LoginForm />
  </div>
</template>
