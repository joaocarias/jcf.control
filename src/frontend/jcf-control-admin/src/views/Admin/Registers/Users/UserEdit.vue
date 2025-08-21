<template>

    <AdminLayout>
        <PageBreadcrumb :pageTitle="currentPageTitle" />
        <div class="grid grid-cols-1 gap-6 ">
            <div class="space-y-6">

                <ComponentCard :title="$t(titlePage)">
                    <div v-if="loading">
                        <p class="text-gray-500 text-theme-sm dark:text-gray-400">{{ $t('Loading...') }}</p>
                    </div>
                    <div v-else-if="user">

                        <UserForm v-model="formData" />
                        <ButtonSave :apiCall="saveUser" :label="$t('Save')" @success="router.push(to)" />

                    </div>
                    <div v-else>
                        <error-message />
                    </div>

                </ComponentCard>

            </div>

        </div>
    </AdminLayout>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import PageBreadcrumb from '@/components/common/PageBreadcrumb.vue'
import AdminLayout from '@/components/layout/AdminLayout.vue'
import { useRouter, useRoute } from 'vue-router'
import { UserServices } from '@/services/userServices'

import ComponentCard from '@/components/common/ComponentCard.vue'
import UserForm from '@/components/admin/register/user/UserForm.vue'

import { useI18n } from 'vue-i18n'
import ButtonSave from '@/components/common/ButtonSave.vue'
import type { User } from '@/interfaces/Models/User'
import ErrorMessage from '@/components/common/ErrorMessage.vue'

const { t } = useI18n();
const router = useRouter()
const route = useRoute()

const loading = ref(false)
const user = ref<User>();
let to = ``;

const titlePage = t('Edit')
const currentPageTitle = ref(t("Users"));

const formData = ref({ id: '', name: '', email: '' })
let _id = ''

const saveUser = async () => {
    const user = await UserServices.updateUser(_id, formData.value)
    return user
}

const loadUser = async (id: string) => {
    try {
        user.value = await UserServices.getUserById(id)
        to = `/registers/users/${user.value.id}/edit`;
        formData.value = {
            id: user.value.id,
            name: user.value.name,
            email: user.value.email
        }
    } catch (err) {
        console.error('Erro ao carregar usuário:', err)
    } finally {
        loading.value = false
    }
}

onMounted(() => {
    loading.value = true
    const id = route.params.id as string
    _id = id
    loadUser(id)
})

</script>