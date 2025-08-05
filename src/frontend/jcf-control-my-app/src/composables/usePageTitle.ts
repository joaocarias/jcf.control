import { computed } from 'vue'
import { useRoute } from 'vue-router'

const titleMap: Record<string, string> = {
  home: 'Dashboard',
  'cadastros/usuarios': 'Usuários',
  'cadastros/usuarios/novo': 'Novo Usuário',
  'cadastro/usuario/editar': 'Editar Usuário',

  'cadastro/cliente/novo': 'Novo Cliente',
  'cadastro/cliente/editar': 'Editar Cliente',
  'cadastro/produto': 'Cadastro de Produtos',

  entrada: 'Financeiro - Entrada',
  saida: 'Financeiro - Saída',
}

export function usePageTitle() {
  const route = useRoute()

  const pageTitle = computed(() => {
    const cleanPath = route.path.replace(/^\/|\/$/g, '')
    return titleMap[cleanPath] || 'Página'
  })

  return { pageTitle }
}
