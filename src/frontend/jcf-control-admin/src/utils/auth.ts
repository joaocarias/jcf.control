import type { User } from "@/interfaces/Models/User";

const jcf_control_app_auth_token = "jcf_control_admin_auth_token";
const jcf_control_app_auth_user = "jcf_control_admin_auth_user";
const jcf_control_app_isAuthenticated = 'jcf_control_admin_isAuthenticated';

export function isAuthenticated(): boolean {
    return sessionStorage.getItem(jcf_control_app_isAuthenticated) === 'true'
}

export function getAuthToken(): string | null {
    return sessionStorage.getItem(jcf_control_app_auth_token)
}

export function loginStorage(token: string, user: User): void {
    sessionStorage.setItem(jcf_control_app_isAuthenticated, 'true')
    sessionStorage.setItem(jcf_control_app_auth_token, token)
    sessionStorage.setItem(jcf_control_app_auth_user, JSON.stringify(user))
}

export function logoutStorage(): void {
    sessionStorage.removeItem(jcf_control_app_isAuthenticated);
    sessionStorage.removeItem(jcf_control_app_auth_token); 
    sessionStorage.removeItem(jcf_control_app_auth_user); 
} 