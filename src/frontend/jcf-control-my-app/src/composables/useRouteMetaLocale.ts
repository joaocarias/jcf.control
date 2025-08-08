import { useI18n } from 'vue-i18n';
import { RouteMeta } from '@/router/route-meta';

export function useRouteMetaLocale() {
  const { t } = useI18n();

  function getTitle(routeKey: keyof typeof RouteMeta) {
    return t(RouteMeta[routeKey].title);
  }

  function getBreadcrumb(routeKey: keyof typeof RouteMeta) {
    return RouteMeta[routeKey].breadcrumbkeys
      .map(key => t(key))
      .join(' / ');
  }

  return { getTitle, getBreadcrumb };
}
