import api from './api'

const AUTHENTICATION_BASE_URL = '/Authentication/Login';

export async function login(email: string, password: string) {
  return api.post(AUTHENTICATION_BASE_URL, { email, password })
}
