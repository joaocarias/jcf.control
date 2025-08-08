export const RouteMeta = {
     HOME: {
        name : 'Home',
        title: "Home",
        requiresAuth: true,
        path: '/home',
        breadcrumbkeys: ['Home'],
        icon: 'fas fa-sign-in-alt',
    },
    LOGIN: {
        name : 'login',
        title: "Login",
        requiresAuth: false,
        path: '/login',
        breadcrumbkeys: ['Login'],
        icon: 'fas fa-sign-in-alt',
    },   
    USERS: {
        name : 'Users',
        title: "Users",        
        requiresAuth: true,
        path: '/registers/users',
        breadcrumbkeys: ['Registers', 'Users'],
        icon: 'fas fa-user-plus',
    },
}