import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from './router'
import '@fortawesome/fontawesome-free/css/all.css'

// Importar o store de tema para garantir inicialização
import './stores/theme'

const app = createApp(App)
app.use(router)
app.mount('#app')
