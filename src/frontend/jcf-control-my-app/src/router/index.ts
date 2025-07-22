import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'
import Login from '@/pages/auth/Login.vue'
import { APP_TITLE } from '@/constants/app'

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

export default router
