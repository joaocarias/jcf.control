<template>
  <div class="space-y-6">
    <!-- Header da página -->
    <div class="flex items-center justify-between">
      <PageTitle :title="pageTitle" :subtitle="breadcrumbString" />
      
      <!-- Botão Adicionar Usuário -->
      <button 
        @click="addUser"
        class="bg-cyan-600 hover:bg-cyan-700 dark:bg-cyan-500 dark:hover:bg-cyan-600 text-white px-4 py-2 rounded-lg transition-colors flex items-center gap-2"
      >
        <i class="fas fa-plus"></i>
        Adicionar Usuário
      </button>
    </div>

    <!-- Loading -->
    <BaseLoading v-if="loading" message="Carregando usuários..." />

    <!-- Erro -->
    <div v-else-if="error" class="bg-red-50 dark:bg-red-900/20 border border-red-200 dark:border-red-800 rounded-lg p-4">
      <div class="flex items-center">
        <i class="fas fa-exclamation-triangle text-red-600 dark:text-red-400 mr-2"></i>
        <span class="text-red-800 dark:text-red-200">{{ error }}</span>
      </div>
    </div>

    <!-- Tabela de Usuários -->
    <div v-else class="bg-white dark:bg-gray-800 rounded-lg shadow-lg overflow-hidden">
      <div class="overflow-x-auto">
        <table class="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
          <thead class="bg-gray-50 dark:bg-gray-700">
            <tr>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">
                Nome
              </th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">
                E-Mail
              </th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">
                Login
              </th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">
                Perfil
              </th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">
                Status
              </th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">
                Data do Cadastro
              </th>
              <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">
                Ações
              </th>
            </tr>
          </thead>
          <tbody class="bg-white dark:bg-gray-800 divide-y divide-gray-200 dark:divide-gray-700">
            <tr v-for="user in users" :key="user.id" class="hover:bg-gray-50 dark:hover:bg-gray-700">
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm font-medium text-gray-900 dark:text-gray-100">
                  {{ user.name }}
                </div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900 dark:text-gray-100">
                  {{ user.email }}
                </div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900 dark:text-gray-100">
                  {{ user.login }}
                </div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <span 
                  :class="[
                    'inline-flex px-2 py-1 text-xs font-semibold rounded-full',
                    user.role === 'ADMIN' 
                      ? 'bg-purple-100 text-purple-800 dark:bg-purple-900/20 dark:text-purple-300'
                      : 'bg-blue-100 text-blue-800 dark:bg-blue-900/20 dark:text-blue-300'
                  ]"
                >
                  {{ user.role }}
                </span>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <span 
                  :class="[
                    'inline-flex px-2 py-1 text-xs font-semibold rounded-full',
                    user.isActive 
                      ? 'bg-green-100 text-green-800 dark:bg-green-900/20 dark:text-green-300'
                      : 'bg-red-100 text-red-800 dark:bg-red-900/20 dark:text-red-300'
                  ]"
                >
                  {{ user.isActive ? 'Ativo' : 'Inativo' }}
                </span>
              </td>
              <td class="px-6 py-4 whitespace-nowrap">
                <div class="text-sm text-gray-900 dark:text-gray-100">
                  {{ formatDate(user.createAt) }}
                </div>
              </td>
              <td class="px-6 py-4 whitespace-nowrap text-sm font-medium">
                <div class="flex items-center space-x-2">
                  <button 
                    @click="editUser(user)"
                    class="text-cyan-600 dark:text-cyan-400 hover:text-cyan-700 dark:hover:text-cyan-300 transition-colors"
                    title="Editar usuário"
                  >
                    <i class="fas fa-edit"></i>
                  </button>
                  <button 
                    @click="deleteUser(user)"
                    class="text-red-600 dark:text-red-400 hover:text-red-700 dark:hover:text-red-300 transition-colors"
                    title="Excluir usuário"
                  >
                    <i class="fas fa-trash"></i>
                  </button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <EmptyState
        :isEmpty="users.length === 0"
        :loading="loading"
        message="Nenhum usuário encontrado"
        icon="fas fa-users"
      />
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { UserServices } from '@/services/userServices'
import BaseLoading from '@/components/base/BaseLoading.vue'
import PageTitle from '@/components/base/PageTitle.vue'
import { useI18n } from 'vue-i18n';

import { useBreadcrumbList } from '@/composables/useBreadcrumbList'
import { RouteMeta } from '@/router/route-meta.js'

const users = ref([])
const loading = ref(false)
const error = ref('')

const pageTitle = RouteMeta.USERS.name;
const { breadcrumbList, breadcrumbString } = useBreadcrumbList();

// Carregar usuários
const loadUsers = async () => {
  loading.value = true
  error.value = ''
  
  try {
    users.value = await UserServices.getUsers()
  } catch (err) {
    error.value = 'Erro ao carregar usuários. Tente novamente.'
    console.error('Erro ao carregar usuários:', err)
  } finally {
    loading.value = false
  }
}

// Formatar data
const formatDate = (dateString) => {
  try {
    const date = new Date(dateString)
    return date.toLocaleDateString('pt-BR', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    })
  } catch {
    return dateString
  }
}

// Adicionar usuário
const addUser = () => {
  // TODO: Implementar navegação para página de adicionar usuário
  console.log('Adicionar usuário')
}

// Editar usuário
const editUser = (user) => {
  // TODO: Implementar navegação para página de editar usuário
  console.log('Editar usuário:', user)
}

// Deletar usuário
const deleteUser = async (user) => {
  if (confirm(`Tem certeza que deseja excluir o usuário "${user.name}"?`)) {
    try {
      await UserServices.deleteUser(user.id)
      await loadUsers() // Recarregar lista
      alert('Usuário excluído com sucesso!')
    } catch (err) {
      alert('Erro ao excluir usuário. Tente novamente.')
      console.error('Erro ao excluir usuário:', err)
    }
  }
}

// Carregar dados na montagem do componente
onMounted(() => {
  loadUsers()
})

console.log('tile: ', pageTitle)
</script> 