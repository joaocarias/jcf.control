<template>
  <div class="absolute inset-0 z-0 pointer-events-none">
    <!-- Grid -->
    <svg class="w-full h-full opacity-10" xmlns="http://www.w3.org/2000/svg">
      <defs>
        <pattern id="grid" width="40" height="40" patternUnits="userSpaceOnUse">
          <path d="M 40 0 L 0 0 0 40" fill="none" stroke="cyan" stroke-width="0.5"/>
        </pattern>
      </defs>
      <rect width="100%" height="100%" fill="url(#grid)" />
    </svg>

    <!-- Círculos tech -->
    <div class="absolute top-10 left-10 w-40 h-40 bg-cyan-500/10 border-2 border-cyan-500 rounded-full blur-2xl animate-pulse" />
    <div class="absolute bottom-20 right-16 w-32 h-32 bg-purple-500/10 border-2 border-purple-500 rounded-full blur-2xl animate-spin-slow" />
  </div>
</template>

<style scoped>
@keyframes spin-slow {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
.animate-spin-slow {
  animation: spin-slow 30s linear infinite;
}
</style>
