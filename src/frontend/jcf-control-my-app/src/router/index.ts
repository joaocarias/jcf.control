import { createRouter, createWebHistory } from 'vue-router';
import { routes } from './routes';
import { APP_TITLE } from '@/constants/app';
import { isAuthenticated } from '@/utils/auth';
import { RouteName } from '@/router/route-names';

const router = createRouter({
  history: createWebHistory(),
  routes
});

router.afterEach((to) => {
  if (to.meta.title) {
    document.title = to.meta.title as string;
  } else {
    document.title = APP_TITLE;
  }
});

router.beforeEach((to, from, next) => {
  const loggedIn = isAuthenticated();

  if (to.meta.requiresAuth && !loggedIn) {
    next({ name: RouteName.LOGIN });
  } else {
    next();
  }
});

export default router;
