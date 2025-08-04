import { ref } from 'vue'

// Estado global do tema
const isDark = ref(false)

// Função para detectar preferência do sistema
const detectSystemTheme = () => {
  if (typeof window !== 'undefined') {
    return window.matchMedia('(prefers-color-scheme: dark)').matches
  }
  return false
}

// Função para obter tema salvo ou detectar do sistema
const getInitialTheme = () => {
  if (typeof window !== 'undefined') {
    const savedTheme = localStorage.getItem('jcf-theme')
    if (savedTheme) {
      return savedTheme === 'dark'
    }
    return detectSystemTheme()
  }
  return false
}

// Aplicar tema ao DOM
const applyTheme = (dark: boolean) => {
  if (typeof document !== 'undefined') {
    const html = document.documentElement
    if (dark) {
      html.classList.add('dark')
    } else {
      html.classList.remove('dark')
    }
  }
}

// Alternar tema
const toggleTheme = () => {
  isDark.value = !isDark.value
  localStorage.setItem('jcf-theme', isDark.value ? 'dark' : 'light')
  applyTheme(isDark.value)
}

// Inicializar tema
const initializeTheme = () => {
  isDark.value = getInitialTheme()
  applyTheme(isDark.value)
}

// Observar mudanças no tema do sistema
const setupSystemThemeListener = () => {
  if (typeof window !== 'undefined') {
    const mediaQuery = window.matchMedia('(prefers-color-scheme: dark)')
    mediaQuery.addEventListener('change', (e) => {
      if (!localStorage.getItem('jcf-theme')) {
        isDark.value = e.matches
        applyTheme(isDark.value)
      }
    })
  }
}

// Inicializar imediatamente
initializeTheme()
setupSystemThemeListener()

export const useThemeStore = () => {
  return {
    isDark,
    toggleTheme,
    applyTheme,
    initializeTheme,
    setupSystemThemeListener
  }
} 