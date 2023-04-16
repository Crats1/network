import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import AllPostsPage from '@/pages/AllPostsPage.vue';
import LoginPage from '@/pages/LoginPage.vue';
import RegisterPage from '@/pages/RegisterPage.vue';
import FollowingPage from '@/pages/FollowingPage.vue';
import ProfilePage from '@/pages/ProfilePage.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: AllPostsPage
  },
  {
    path: '/login',
    name: 'login',
    component: LoginPage,
  },
  {
    path: '/register',
    name: 'register',
    component: RegisterPage,
  },
  {
    path: '/following',
    name: 'following',
    component: FollowingPage,
  },
  {
    path: '/profile',
    name: 'profile',
    component: ProfilePage,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;
