import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'
import Login from '@/pages/auth/Login.vue'
import Home from '@/pages/dashboard/Home.vue'
import UsersList from '@/pages/users/UsersList.vue'
import { APP_TITLE } from '@/constants/app'
import AdminLayout from '@/layouts/AdminLayout.vue'
import { isAuthenticated } from '@/utils/auth'

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    redirect: '/login'
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
    meta: {
      title: `Login | ${APP_TITLE}`
    }
  },
  {
    path: '/home',
    component: AdminLayout,   
    meta: { requiresAuth: true },
    children: [
      {
        path: '', // rota padrão de /admin
        name: 'Home',
        component: Home,
        meta: {
          title: `Home | ${APP_TITLE}`
        }
      }
    ]
  },
  {
    path: '/users',
    component: AdminLayout,
    meta: { requiresAuth: true },
    children: [
      {
        path: '',
        name: 'Users',
        component: UsersList,
        meta: {
          title: `Usuários | ${APP_TITLE}`
        }
      }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

// Atualiza o <title> com base na rota
router.afterEach((to) => {
  if (to.meta.title) {
    document.title = to.meta.title as string
  } else {
    document.title = APP_TITLE
  }
})

router.beforeEach((to, from, next) => {
  const loggedIn = isAuthenticated()

  if (to.meta.requiresAuth && !loggedIn) {
    next({ name: 'Login' })
  } else {
    next()
  }
})

export default router
