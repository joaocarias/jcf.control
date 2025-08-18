<template>
  <div class="overflow-hidden rounded-xl border border-gray-200 bg-white dark:border-gray-800 dark:bg-white/[0.03]">
    <div class="max-w-full overflow-x-auto custom-scrollbar">
      <table class="min-w-full">
        <thead>
          <tr class="border-b border-gray-200 dark:border-gray-700">
            <th class="px-5 py-3 text-left w-3/11 sm:px-6">
              <p class="font-medium text-gray-500 text-theme-xs dark:text-gray-400">{{ $t('Name') }}</p>
            </th>
            <th class="px-5 py-3 text-left w-2/11 sm:px-6">
              <p class="font-medium text-gray-500 text-theme-xs dark:text-gray-400">{{ $t('Login') }}</p>
            </th>
            <th class="px-5 py-3 text-left w-2/11 sm:px-6">
              <p class="font-medium text-gray-500 text-theme-xs dark:text-gray-400">{{ $t('Profile') }}</p>
            </th>
            <th class="px-5 py-3 text-left w-2/11 sm:px-6">
              <p class="font-medium text-gray-500 text-theme-xs dark:text-gray-400">{{ $t('Status') }}</p>
            </th>
            <th class="px-5 py-3 text-left w-2/11 sm:px-6">
              <p class="font-medium text-gray-500 text-theme-xs dark:text-gray-400">{{ $t('CreateAt') }}</p>
            </th>
            <th class="px-5 py-3 text-left w-2/11 sm:px-6">
              <p class="font-medium text-gray-500 text-theme-xs dark:text-gray-400"><span></span></p>
            </th>
          </tr>
        </thead>
        <tbody class="divide-y divide-gray-200 dark:divide-gray-700">
          <tr v-for="(user, index) in users" :key="index" class="border-t border-gray-100 dark:border-gray-800">
            <td class="px-5 py-4 sm:px-6">
              <div class="flex items-center gap-3">
                <div>
                  <span class="block font-medium text-gray-800 text-theme-sm dark:text-white/90">
                    {{ user.name }}
                  </span>
                  <span class="block text-gray-500 text-theme-xs dark:text-gray-400">
                    {{ user.email }}
                  </span>
                </div>
              </div>
            </td>
            <td class="px-5 py-4 sm:px-6">
              <p class="text-gray-500 text-theme-sm dark:text-gray-400">{{ user.login }}</p>
            </td>
            <td class="px-5 py-4 sm:px-6">
              <p class="text-gray-500 text-theme-sm dark:text-gray-400">{{ $t(user.role) }}</p>
            </td>
            <td class="px-5 py-4 sm:px-6">
              <span :class="[
                'rounded-full px-2 py-0.5 text-theme-xs font-medium',
                {
                  'bg-success-50 text-success-700 dark:bg-success-500/15 dark:text-success-500':
                    user.isActive === true,
                  'bg-warning-50 text-warning-700 dark:bg-warning-500/15 dark:text-warning-400':
                    user.isActive === false
                },
              ]">
                {{ user.isActive ? $t('Active') : $t('Inactive') }}
              </span>
            </td>
            <td class="px-5 py-4 sm:px-6">
              <p class="text-gray-500 text-theme-sm dark:text-gray-400">{{ formatDate(user.createAt) }}</p>
            </td>
            <td class="px-5 py-4 sm:px-6 space-x-3">
              <RouterLink :to="`/registers/users/${user.id}`" :title="$t('View')">
                <font-awesome-icon icon="file-lines" class="cursor-pointer hover:text-blue-500" />
              </RouterLink>

              <!-- Editar -->
              <RouterLink :to="`/registers/users/edit/${user.id}`" :title="$t('Edit')">
                <font-awesome-icon icon="file-pen" class="cursor-pointer hover:text-green-500" />
              </RouterLink>

              <!-- Excluir -->
              <RouterLink :to="`/registers/users/remove/${user.id}`" :title="$t('Delete')">
                <font-awesome-icon icon="trash-can" class="cursor-pointer hover:text-red-500" />
              </RouterLink>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { UserServices } from '@/services/userServices'
import type { User } from '@/interfaces/Models/User'
import { formatDate } from '@/utils/dateFormatter';

const users = ref<User[]>([])
const loading = ref(false)
const error = ref('')

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

// Carregar dados na montagem do componente
onMounted(() => {
  loadUsers()
})


</script>
