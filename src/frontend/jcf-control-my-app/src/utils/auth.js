const jcf_control_app_auth_token = "jcf_control_app_auth_token";
const jcf_control_app_auth_user = "jcf_control_app_auth_user";
const jcf_control_app_isAuthenticated = 'jcf_control_app_isAuthenticated';

export function isAuthenticated() {
    return sessionStorage.getItem(jcf_control_app_isAuthenticated) === 'true'
}

export function loginStorage(token, user) {
    sessionStorage.setItem(jcf_control_app_isAuthenticated, 'true')
    sessionStorage.setItem(jcf_control_app_auth_token, token)
    sessionStorage.setItem(jcf_control_app_auth_user, JSON.stringify(user))
}

export function logoutStorage() {
    sessionStorage.removeItem(jcf_control_app_isAuthenticated);
    sessionStorage.removeItem(jcf_control_app_auth_token); 
    sessionStorage.removeItem(jcf_control_app_auth_user); 
}
