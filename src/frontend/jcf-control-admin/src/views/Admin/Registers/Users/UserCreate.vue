<template>
  <AdminLayout>
    <PageBreadcrumb :pageTitle="currentPageTitle" />
    <div class="grid grid-cols-1 gap-6 ">
      <div class="space-y-6">

        <ComponentCard :title="$t(titlePage)">
          <UserForm v-model="formData" />
          <ButtonSave :apiCall="saveUser" :label="$t('Save')"
            @success="(user) => router.push(`/registers/users/${user.id}`)" />
        </ComponentCard>

      </div>

    </div>
  </AdminLayout>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import PageBreadcrumb from '@/components/common/PageBreadcrumb.vue'
import AdminLayout from '@/components/layout/AdminLayout.vue'
import { useRouter } from 'vue-router'
import { UserServices } from '@/services/userServices'

import ComponentCard from '@/components/common/ComponentCard.vue'
import UserForm from '@/components/admin/register/user/UserForm.vue'

import { useI18n } from 'vue-i18n'
import ButtonSave from '@/components/common/ButtonSave.vue'
import type { User } from '@/interfaces/Models/User'

const { t } = useI18n();
const router = useRouter()

const titlePage = t('Add')
const currentPageTitle = ref(t("Usuários"));

const formData = ref({ name: '', email: '' })

const saveUser = async (): Promise<User> => {
  const user = await UserServices.createUser(formData.value)
  return user
}

</script>
