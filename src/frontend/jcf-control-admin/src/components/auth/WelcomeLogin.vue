<template>

    <div class="flex items-center justify-center z-1">
        <common-grid-shape />
        <div class="flex flex-col items-center max-w-xs">
            <router-link to="/" class="block mb-4">
                <img width="{231}" height="{48}" src="/images/logo/auth-logo.svg" alt="Logo" />
            </router-link>
            <p class="text-center text-gray-400 dark:text-white/60">
                {{ $t('msgWelcomeViewLogin') }}
            </p>
        </div>
    </div>

</template>

<script setup lang="ts">
import CommonGridShape from '@/components/common/CommonGridShape.vue'
</script>
