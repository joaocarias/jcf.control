<template>
    <div class="space-y-6">
        <div v-if="user">
            <p>{{ user.name }}</p>
        </div>
        <div v-else>
            <p>Falha ao Carregar Usuário</p>
        </div>        
    </div>
</template>

<script setup lang="ts">

import { ref, onMounted } from 'vue'
import { UserServices } from '@/services/userServices'
import type { User } from '@/interfaces/Models/User'
import { useRoute } from 'vue-router'

const route = useRoute()

const user = ref<User>();

const loading = ref(false)
const error = ref('')
//const _urlBase = '/registers/users';

const loadUser = async (id: string) => {
  loading.value = true
  error.value = ''

  try {
    user.value = await UserServices.getUserById(id)
  } catch (err) {
    error.value = 'Erro ao carregar usuário. Tente novamente.'
    console.error('Erro ao carregar usuário:', err)
  } finally {
    loading.value = false
  }
}

onMounted(() => {
    const id = route.params.id as string
    loadUser(id)
})

</script>