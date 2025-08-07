export const RouteMeta = {
     HOME: {
        name : 'Home',
        title: "Home",
        requiresAuth: true,
        path: '/login',
        icon: 'fas fa-sign-in-alt',
    },
    LOGIN: {
        name : 'login',
        title: "Login",
        requiresAuth: false,
        path: '/login',
        icon: 'fas fa-sign-in-alt',
    },   
    USERS: {
        name : 'Users',
        title: t('users'),
        requiresAuth: true,
        path: '/registers/users',
        icon: 'fas fa-users',
    },
}