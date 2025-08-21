<template>
  <div v-if="loading">
    <p class="text-gray-500 text-theme-sm dark:text-gray-400">{{ $t('Loading...') }}</p>
  </div>
  <div v-else-if="user">

    <div class="p-5 mb-6 border border-gray-200 rounded-2xl dark:border-gray-800 lg:p-6">
      <div class="flex flex-col gap-6 lg:flex-row lg:items-start lg:justify-between">
        <div>
          <h4 class="text-lg font-semibold text-gray-800 dark:text-white/90 lg:mb-6">
            {{ $t('BasicInformation') }}
          </h4>

          <div class="grid grid-cols-1 gap-4 lg:grid-cols-2 lg:gap-7 2xl:gap-x-32">
            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">{{ $t('FirstName') }}</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">{{ user?.firstName }}</p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">{{ $t('CompleteName') }}</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90"> {{ user?.name }}</p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">
                {{ $t('Email') }}
              </p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">
                {{ user?.email }}
              </p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">{{ $t('Profile') }}</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">{{ $t(user?.role) }}</p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">
                {{ $t('Status') }}
              </p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">
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
              </p>
            </div>

            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">{{ $t('CreateAt') }}</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">{{ formatDate(user.createAt) }}</p>
            </div>
          </div>
        </div>

        <button-edit :to="to" />
      </div>
    </div>

    <div class="p-5 mb-6 border border-gray-200 rounded-2xl dark:border-gray-800 lg:p-6">
      <div class="flex flex-col gap-6 lg:flex-row lg:items-start lg:justify-between">
        <div>
          <h4 class="text-lg font-semibold text-gray-800 dark:text-white/90 lg:mb-6">
            {{ $t('Access') }}
          </h4>

          <div class="grid grid-cols-1 gap-4 lg:grid-cols-2 lg:gap-7 2xl:gap-x-32">
            <div>
              <p class="mb-2 text-xs leading-normal text-gray-500 dark:text-gray-400">{{ $t('Login') }}</p>
              <p class="text-sm font-medium text-gray-800 dark:text-white/90">{{ user?.login }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div v-else>
    <error-message />
  </div>
</template>

<script setup lang="ts">

import { ref, onMounted } from 'vue'
import { UserServices } from '@/services/userServices'
import type { User } from '@/interfaces/Models/User'
import { useRoute } from 'vue-router'
import { formatDate } from '@/utils/dateFormatter';
import ErrorMessage from '@/components/common/ErrorMessage.vue';
import ButtonEdit from '@/components/common/ButtonEdit.vue';

const route = useRoute()

const user = ref<User>();

const loading = ref(false)
const error = ref('')
let to = `/registers/users/${user.value?.id}/edit`;

const loadUser = async (id: string) => {
  loading.value = true
  error.value = ''

  try {
    user.value = await UserServices.getUserById(id)
    to = `/registers/users/${user.value.id}/edit`;
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