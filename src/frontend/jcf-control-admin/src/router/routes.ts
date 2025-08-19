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
  },
    {
    path: '/registers/users',
    meta: { requiresAuth: true },
    children: [
      {
        path: '',
        name: 'Users',
        component: () => import('@/views/Admin/Registers/Users/UserList.vue'),
        meta: {
          title: `Usuários | ${APP_TITLE}`
        }
      },
      {
       path: 'create',
        name: 'Users Create',
        component: () => import('@/views/Admin/Registers/Users/UserCreate.vue'),
        meta: {
          title: `Usuários | ${APP_TITLE}`
        }
      },
      {
        path: ':id',
        name: 'Users View',
        component: () => import('@/views/Admin/Registers/Users/UserView.vue'),
        props: true,
        meta: {
          title: `Usuário | ${APP_TITLE}`
        }
      }
    ]
  }
];