import './assets/main.css'
// Import Swiper styles
import 'swiper/css'
import 'swiper/css/navigation'
import 'swiper/css/pagination'
import 'jsvectormap/dist/jsvectormap.css'
import 'flatpickr/dist/flatpickr.css'
import FontAwesomeIcon from './plugins/fontawesome'
import FloatingVue from 'floating-vue'
import 'floating-vue/dist/style.css'

import { createApp } from 'vue'
import App from './App.vue'
import type { Plugin } from 'vue';
import router from './router'
import VueApexCharts from 'vue3-apexcharts'

import i18n from './i18n';

const app = createApp(App)

app.component('font-awesome-icon', FontAwesomeIcon)

app.use(router)
app.use(VueApexCharts as unknown as Plugin);
app.use(FloatingVue)
app.use(i18n);

app.mount('#app')
