import { createApp } from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store'
import ElementPlus from "element-plus";
import "element-plus/lib/theme-chalk/index.css";
import "@mdi/font/css/materialdesignicons.min.css";

const app = createApp(App)
app.use(ElementPlus)
app.use(store).use(router).mount('#app')