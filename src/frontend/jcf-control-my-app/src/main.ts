import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import i18n from './i18n';
import router from './router'
import '@fortawesome/fontawesome-free/css/all.css'

// Importar o store de tema para garantir inicialização
import './stores/theme'

const app = createApp(App)

app.use(router)
app.use(i18n as any)
app.mount('#app')
