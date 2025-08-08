import { computed } from 'vue';
import { useI18n } from 'vue-i18n';
import { RouteMeta } from '@/router/route-meta';

export function usePageTitleFor(name) {
  const { t } = useI18n();
  const title = computed(() => t(RouteMeta[name].name));
  return { title };
}
