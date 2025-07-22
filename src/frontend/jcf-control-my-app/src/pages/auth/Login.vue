<script setup lang="ts">
import { ref } from 'vue'
import BaseInput from '@/components/base/BaseInput.vue'
import BaseButton from '@/components/base/BaseButton.vue'
import BaseToggle from '@/components/base/BaseToggle.vue'
import { APP_TITLE } from '@/constants/app'

const email = ref('')
const password = ref('')
const rememberMe = ref(false)

const handleLogin = () => {
  console.log({ email: email.value, password: password.value, rememberMe: rememberMe.value })
}

</script>

<template>
  <section class="min-h-screen flex items-center justify-center bg-white">
    <div class="grid grid-cols-1 lg:grid-cols-2 w-full max-w-6xl shadow-md rounded-lg overflow-hidden">

      <!-- Formulário -->
      <div class="p-10">
        <h2 class="text-3xl font-bold text-blue-700 mb-2">{{ APP_TITLE }}</h2>
        <p class="text-gray-500 mb-8">Informe seu email e senha para acessar</p>

        <form @submit.prevent="handleLogin" class="space-y-6">
          <BaseInput v-model="email" type="email" label="Email" placeholder="Email" />
          <BaseInput v-model="password" type="password" label="Senha" placeholder="Senha" />

          <div class="flex items-center gap-2">
            <BaseToggle v-model="rememberMe" />
            <label class="text-sm text-gray-700">Lembre-me</label>
          </div>

          <BaseButton type="submit">Entrar</BaseButton>
          
        </form>
      </div>

      <!-- Imagem -->
      <div class="hidden lg:block relative">
        <div class="w-full h-full overflow-hidden">
          <img
            src="@/assets/images/login-bg-cyberpunk.png"
            alt="Login Background"
            class="w-full h-auto rounded-xl object-cover"
          />
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>

</style>
