import api from './api'
import type { ApiResponse } from '@/interfaces/Responses/ApiResponse'

export class RolesServices {
    static async getRoles(): Promise<string[]> {
        const response = await api.get<ApiResponse<string[]>>('/AppConfig/GetRoles')
        return response.data.result
    }
}
