import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import Laptop from '../views/Laptop.vue'
import Dienthoai from '../views/Phone.vue'
import Dongho from '../views/Dongho.vue'
import Phukien from '../views/Phukien.vue'
import Home from '../views/Home.vue'
import Admin from '../views/Admin.vue'
import AdminDetails from '../views/AdminDetail.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/admin',
    component: Admin,
  },
  {
    path: '/admin/details',
    component: AdminDetails
  },
  {
    path: '/',
    component: Home
  },
  {
    path: '/Laptop',
    component: Laptop
  },
  {
    path: '/Dienthoai',
    component: Dienthoai
  },
  {
    path: '/Phukien',
    component: Phukien
  },
  {
    path: '/Dongho',
    component: Dongho
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
