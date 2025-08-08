import type { RouteRecordRaw } from 'vue-router';

import { APP_TITLE } from '@/constants/app';
import { RouteMeta } from '@/router/route-meta';

import AdminLayout from '@/layouts/AdminLayout.vue';

import Login from '@/pages/auth/Login.vue';
import Home from '@/pages/dashboard/Home.vue';
import UsersList from '@/pages/registers/users/UserList.vue';

export const routes: RouteRecordRaw[] = [
  {
    path: '/',
    redirect: RouteMeta.LOGIN.path
  },
  {
    path: RouteMeta.LOGIN.path,
    name: RouteMeta.LOGIN.name,
    component: Login,
    meta: {
      title: `Login | ${APP_TITLE}`
    }
  },
  {
    path: RouteMeta.HOME.path,
    component: AdminLayout,
    meta: { requiresAuth: RouteMeta.HOME.requiresAuth },
    children: [
      {
        path: '',
        name: RouteMeta.HOME.name,
        component: Home,
        meta: {
          title: `Home | ${APP_TITLE}`
        }
      }
    ]
  },
  {
    path: RouteMeta.USERS.path,
    component: AdminLayout,
    meta: { requiresAuth: RouteMeta.USERS.requiresAuth },
    children: [
      {
        path: '',
        name: RouteMeta.USERS.name,
        component: UsersList,
        meta: {
          title: `Usuários | ${APP_TITLE}`
        }
      }
    ]
  }
];
