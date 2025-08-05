import { computed } from 'vue'
import { useRoute } from 'vue-router'

const routeNameMap: Record<string, string> = {
  home: 'Home',
  cadastros: 'Cadastros',
  cliente: 'Cliente',
  novo: 'Novo',
  editar: 'Editar',
  produto: 'Produto',
  cor: 'Cor',
  usuarios: 'Usuários',
  entrada: 'Entrada',
  saida: 'Saída',
}

export function useBreadcrumbList() {
  const route = useRoute()

  const breadcrumbList = computed(() => {
    const parts = route.path
      .split('/')
      .filter(Boolean)
      .map(p => routeNameMap[p.toLowerCase()] || p)

    return parts.length ? parts : ['Home']
  })

  const breadcrumbString = computed(() => breadcrumbList.value.join(' / '))

  return { breadcrumbList, breadcrumbString }
}
