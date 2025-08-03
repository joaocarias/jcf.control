<script setup lang="ts">
import { ref } from 'vue'
import { login } from '@/services/authService'
import { useRouter } from 'vue-router'
import { loginStorage } from '@/utils/auth'

const email = ref('')
const password = ref('')
const errorMessage = ref('')
const router = useRouter()

const handleLogin = async () => {
  errorMessage.value = '' // limpa erro anterior
  try {
    const response = await login(email.value, password.value);
   
    if (response.data?.isSuccess) {
      const { token, user } = response.data.result
      loginStorage(token, user) // armazena token e usuário
      router.push('/home')
    } else {
      errorMessage.value = 'Erro desconhecido ao logar.'
    }
  } catch (error: any) {
    if (error.response && error.response.data) {
      const { statusCode, errorMessages } = error.response.data;
      console.log(`statusCode: ${statusCode} | errorMessage: ${errorMessages?.[0] || 'Erro desconhecido'}`)
       errorMessage.value = errorMessages?.[0] || 'Erro ao fazer login.'
    } else {
      errorMessage.value = 'Erro ao conectar com o servidor.'
      console.error('Erro inesperado ao tentar logar:', error)
    }
  }
}
</script>

<template>
  <p v-if="errorMessage" class="text-red-400 bg-red-900/20 border border-red-500 px-4 py-2 rounded text-sm text-center mb-4">
        {{ errorMessage }}
    </p>

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
