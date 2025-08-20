<template>
    <div class="flex items-center gap-2">
        <div v-if="routesEnables.includes('View')">
            <RouterLink :to="`${urlBase}/${id}`">
                <font-awesome-icon icon="file-lines"
                    class="cursor-pointer text-gray-600 hover:text-blue-500 ml-1 dark:text-gray-300 dark:hover:text-blue-400"
                    v-tooltip="$t('View')" />
            </RouterLink>
        </div>

        <div v-if="routesEnables.includes('Edit')">
            <RouterLink :to="`${urlBase}/${id}/edit`">
                <font-awesome-icon icon="file-pen"
                    class="cursor-pointer text-gray-600 hover:text-green-500 ml-1 dark:text-gray-300 dark:hover:text-green-400"
                    v-tooltip="$t('Edit')" />
            </RouterLink>
        </div>

        <div v-if="routesEnables.includes('Delete')">
            <!-- Excluir -->
            <RouterLink :to="`${urlBase}/${id}/delete`">
                <font-awesome-icon icon="trash-can"
                    class="cursor-pointer text-gray-600 hover:text-red-500 ml-1 dark:text-gray-300 dark:hover:text-red-400"
                    v-tooltip="$t('Delete')" />
            </RouterLink>
        </div>
    </div>

</template>

<script setup lang="ts">

defineProps<{
    id: string,
    urlBase: string
    routesEnables: string[]
}>()

</script>