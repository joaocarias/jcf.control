<template>
  <AdminLayout>
    <PageBreadcrumb :pageTitle="currentPageTitle" />

    <div class="space-y-5 sm:space-y-6">
      <ComponentCard :title="$t(componentNameList)">
        <template #actionBtnAdd>
          <ButtonAdd to="/registers/users/create" />
        </template>
        <ListTable />
      </ComponentCard>
    </div>
  </AdminLayout>
</template>

<script setup lang="ts"> 
import { ref } from "vue";
import PageBreadcrumb from "@/components/common/PageBreadcrumb.vue";
import AdminLayout from "@/components/layout/AdminLayout.vue";
import ComponentCard from "@/components/common/ComponentCard.vue";
import ListTable from "@/components/admin/register/user/UserListTable.vue";
import ButtonAdd from "@/components/common/ButtonAdd.vue";

import { useI18n } from 'vue-i18n'
const { t } = useI18n();
const currentPageTitle = ref( t("Usuários"));
const componentNameList = ref('Registereds')
</script>
