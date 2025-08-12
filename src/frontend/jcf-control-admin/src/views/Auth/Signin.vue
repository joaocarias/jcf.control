<template>
  <FullScreenLayout>
    <div class="relative p-6 bg-white z-1 dark:bg-gray-900 sm:p-0">
      <div
        class="relative flex flex-col justify-center w-full h-screen lg:flex-row dark:bg-gray-900"
      >
        <div class="flex flex-col flex-1 w-full lg:w-1/2">
          
          <div class="flex flex-col justify-center flex-1 w-full max-w-md mx-auto">
            <FormLogin />
          </div>
        </div>
        
        <FormShape />
        
      </div>
    </div>
  </FullScreenLayout>
</template>

<script setup lang="ts">

import FullScreenLayout from '@/components/layout/FullScreenLayout.vue'
import FormLogin from '@/components/auth/FormLogin.vue'
import FormShape from '@/components/auth/FormShape.vue'


</script>
