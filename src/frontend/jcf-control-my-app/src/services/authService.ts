import api from './api'

export async function login(email: string, password: string) {
  return api.post('/Authentication/Login', { email, password })
}
