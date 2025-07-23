<script setup lang="ts">
import { ref } from 'vue'
import { login } from '@/services/authService'

const email = ref('')
const password = ref('')

async function handleLogin() {
  try {
    const response = await login(email.value, password.value)
    console.log('Login OK:', response.data)
    // redirecionar, armazenar token, etc.
  } catch (err) {
    console.error('Erro ao fazer login', err)
  }
}
</script>

<template>
  <form @submit.prevent="handleLogin" class="space-y-5">
    <div>
      <label for="email" class="block text-sm text-purple-300 mb-1">Email</label>
      <input
        v-model="email"
        type="email"
        id="email"
        placeholder="seu@email.com"
        class="w-full px-4 py-2 rounded bg-black/40 border border-purple-500
               text-white placeholder-purple-500 focus:outline-none
               focus:ring-2 focus:ring-cyan-400"
      />
    </div>

    <div>
      <label for="password" class="block text-sm text-purple-300 mb-1">Senha</label>
      <input
        v-model="password"
        type="password"
        id="password"
        placeholder="••••••••"
        class="w-full px-4 py-2 rounded bg-black/40 border border-purple-500
               text-white placeholder-purple-500 focus:outline-none
               focus:ring-2 focus:ring-cyan-400"
      />
    </div>

    <div class="flex justify-between items-center text-sm text-purple-300">
      <label class="flex items-center gap-2">
        <input type="checkbox" class="accent-cyan-400" />
        Lembrar login
      </label>
      <a href="#" class="hover:text-cyan-300 underline">Esqueci a senha</a>
    </div>

    <button
      type="submit"
      class="w-full bg-gradient-to-r from-cyan-500 to-purple-600
             hover:from-cyan-600 hover:to-purple-700 text-white font-bold
             py-2 rounded transition duration-300 shadow-lg
             shadow-purple-700/40"
    >
      ENTRAR
    </button>
  </form>
</template>
