import api from './api'
import type { User } from '@/interfaces/Models/User'
import type { ApiResponse } from '@/interfaces/Responses/ApiResponse'
import { getAuthToken } from '@/utils/auth'

// Função para obter headers com autenticação
const getAuthHeaders = () => {
  const token = getAuthToken()
  return {
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  }
}

export class UserServices {
  // Listar todos os usuários
  static async getUsers(): Promise<User[]> {
    try {
      const response = await api.get<ApiResponse<User[]>>('/User', {
        headers: getAuthHeaders()
      })
      
      if (response.data.isSuccess) {
        return response.data.result
      } else {
        throw new Error('Erro ao buscar usuários')
      }
    } catch (error) {
      console.error('Erro ao buscar usuários:', error)
      throw error
    }
  }

  // Buscar usuário por ID
  static async getUserById(id: string): Promise<User> {
    try {
      const response = await api.get<ApiResponse<User>>(`/User/${id}`, {
        headers: getAuthHeaders()
      })
      
      if (response.data.isSuccess) {
        return response.data.result
      } else {
        throw new Error('Erro ao buscar usuário')
      }
    } catch (error) {
      console.error('Erro ao buscar usuário:', error)
      throw error
    }
  }

  // Criar novo usuário
  static async createUser(userData: Partial<User>): Promise<User> {
    try {
      const response = await api.post<ApiResponse<User>>('/User', userData, {
        headers: getAuthHeaders()
      })
      
      if (response.data.isSuccess) {
        return response.data.result
      } else {
        throw new Error('Erro ao criar usuário')
      }
    } catch (error) {
      console.error('Erro ao criar usuário:', error)
      throw error
    }
  }

  // Atualizar usuário
  static async updateUser(id: string, userData: Partial<User>): Promise<User> {
    try {
      const response = await api.put<ApiResponse<User>>(`/User/${id}`, userData, {
        headers: getAuthHeaders()
      })
      
      if (response.data.isSuccess) {
        return response.data.result
      } else {
        throw new Error('Erro ao atualizar usuário')
      }
    } catch (error) {
      console.error('Erro ao atualizar usuário:', error)
      throw error
    }
  }

  // Deletar usuário
  static async deleteUser(id: string): Promise<void> {
    try {
      const response = await api.delete<ApiResponse<void>>(`/User/${id}`, {
        headers: getAuthHeaders()
      })
      
      if (!response.data.isSuccess) {
        throw new Error('Erro ao deletar usuário')
      }
    } catch (error) {
      console.error('Erro ao deletar usuário:', error)
      throw error
    }
  }
} 