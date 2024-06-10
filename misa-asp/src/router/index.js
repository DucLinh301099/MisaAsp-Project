import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import LoginComponent from '../components/LoginComponent.vue';
import RegisterComponent from '../components/RegisterComponent.vue';
import ForgotPasswordComponent from '../components/ForgotPasswordComponent.vue';
import AdminComponent from '../components/AdminComponent.vue'; // Import AdminComponent

const routes = [
  { path: '/', component: Home },
  { path: '/login', component: LoginComponent },
  
  { path: '/register', component: RegisterComponent },
  { path: '/admin', component: AdminComponent , meta: { requiresAuth: true }},  // Add route for AdminComponent
   { path: '/forgot-password', component: ForgotPasswordComponent }
];


const router = createRouter({
  history: createWebHistory(),
  routes
});

// Middleware để kiểm tra xác thực
router.beforeEach((to, from, next) => {
  const publicPages = ['/login', '/register'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('token');

  if (authRequired && !loggedIn) {
    return next('/login');
  }

  next();
});

export default router;
