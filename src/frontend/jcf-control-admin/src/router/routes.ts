import type { RouteRecordRaw } from 'vue-router';

import { APP_TITLE } from '@/constants/AppTitle';

export const routes: RouteRecordRaw[] = [
  {
    path: '/login',
    name: 'Login',
    component: () => import('@/views/Auth/SignIn.vue'),
    meta: {
      title: `Login | ${APP_TITLE}`
    },    
  },
  {
    path: '/home',
    meta: { requiresAuth: true },
    children: [
      {
        path: '',
        name: 'Home',
        component: () => import('@/views/Admin/Home.vue'),
        meta: {
          title: `Home | ${APP_TITLE}`
        }
      }
    ]
  }
];