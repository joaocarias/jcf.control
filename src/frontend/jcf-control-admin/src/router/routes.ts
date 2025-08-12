import type { RouteRecordRaw } from 'vue-router';

import { APP_TITLE } from '@/constants/AppTitle';

export const routes: RouteRecordRaw[] = [
  {
    path: '/',
    redirect: '/login',
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('@/views/Auth/Signin.vue'),
    meta: {
      title: `Login | ${APP_TITLE}`
    }
  }
];