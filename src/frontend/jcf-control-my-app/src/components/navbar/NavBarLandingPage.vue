<script setup lang="ts">
import { ref, onMounted } from 'vue'

// Refs para os elementos DOM
const menuButton = ref<HTMLButtonElement | null>(null)
const mobileMenu = ref<HTMLElement | null>(null)

onMounted(() => {
  if (menuButton.value && mobileMenu.value) {
    menuButton.value.addEventListener('click', () => {
      mobileMenu.value?.classList.toggle('hidden')
    })
  }
})
</script>

<template>
  <!-- Navbar -->
  <nav class="bg-white shadow-md">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <div class="flex justify-between h-16 items-center">

        <!-- Direita: Nome do site -->
        <div class="flex-shrink-0">
          <span class="text-lg font-bold text-blue-gray">JCF Control App</span>
        </div>

        <!-- Centro: Menu -->
        <div class="hidden md:flex space-x-8">
          <a href="#" class="text-blue-gray hover:text-blue-gray font-medium">Home</a>
          <a href="#" class="text-blue-gray hover:text-blue-gray font-medium">Sobre</a>
          <a href="#" class="text-blue-gray hover:text-blue-gray font-medium">Contrato</a>
        </div>

        <!-- Esquerda: Login -->
        <div class="flex-shrink-0">
          <a href="#" class="text-blue-gray font-medium hover:text-blue-gray">Login</a>
        </div>


        <!-- Menu mobile (hamburguer) -->
        <div class="md:hidden">
          <button ref="menuButton" class="text-gray-700 focus:outline-none">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" stroke-width="2"
                 viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round"
                    d="M4 6h16M4 12h16M4 18h16"></path>
            </svg>
          </button>
        </div>
      </div>
    </div>

    <!-- Menu dropdown (mobile) -->
    <div ref="mobileMenu" class="md:hidden hidden px-4 pb-4 space-y-2">
      <a href="#" class="block text-gray-700 hover:text-blue-600 font-medium">Home</a>
      <a href="#" class="block text-gray-700 hover:text-blue-600 font-medium">Sobre</a>
      <a href="#" class="block text-gray-700 hover:text-blue-600 font-medium">Contrato</a>
    </div>
  </nav>
</template>

<style scoped>
</style>
