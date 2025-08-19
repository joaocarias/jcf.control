<template>

    <div v-if="routesEnables.includes('View')">
        <RouterLink :to="`${urlBase}/${id}`">
            <font-awesome-icon icon="file-lines" class="cursor-pointer hover:text-blue-500 ml-3"
                v-tooltip="$t('View')" />
        </RouterLink>
    </div>

    <div v-if="routesEnables.includes('Edit')">
        <RouterLink :to="`${urlBase}/edit/${id}`">
            <font-awesome-icon icon="file-pen" class="cursor-pointer hover:text-green-500 ml-3"
                v-tooltip="$t('Edit')" />
        </RouterLink>
    </div>

    <div v-if="routesEnables.includes('Delete')">
        <!-- Excluir -->
        <RouterLink :to="`${urlBase}/remove/${id}`">
            <font-awesome-icon icon="trash-can" class="cursor-pointer hover:text-red-500 ml-3"
                v-tooltip="$t('Delete')" />
        </RouterLink>
    </div>

</template>

<script setup lang="ts">

defineProps<{
    id: string,
    urlBase: string
    routesEnables: string[]
}>()

</script>