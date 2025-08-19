<template>
  <AdminLayout>
    <PageBreadcrumb :pageTitle="currentPageTitle" />
    <div class="grid grid-cols-1 gap-6 ">
      <div class="space-y-6">
       
        <ComponentCard :title="$t(titlePage)">
          <UserDetails></UserDetails>
        </ComponentCard>
       
      </div>
     
    </div>
  </AdminLayout>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import PageBreadcrumb from '@/components/common/PageBreadcrumb.vue'
import AdminLayout from '@/components/layout/AdminLayout.vue'

//import { UserServices }  from '@/services/userServices'

import ComponentCard from '@/components/common/ComponentCard.vue'
import UserDetails from '@/components/admin/register/user/UserDetails.vue'
import { useI18n } from 'vue-i18n'

const { t } = useI18n();

const titlePage = t('Detail');
const currentPageTitle = ref(t("User"));

</script>