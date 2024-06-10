<template>
  <div class="login-page">
    <div class="login-container">
      <div class="logo-section">
        <router-link to="/">
          <img
            src="D:\VueJs\MisaAsp-Project\misa-asp\src\assets\image\logo123.jpg"
            alt="MISA ASP Logo" class="main-logo" />
        </router-link>
      </div>
      <h2>Đăng nhập</h2>
      <form @submit.prevent="login">
        <div class="form-group">
          <input type="text" v-model="emailOrPhoneNumber" placeholder="Số điện thoại/Email" required />
        </div>
        <div class="form-group">
          <input type="password" v-model="password" placeholder="Mật khẩu" required />
        </div>
        <button type="submit" class="login-button">Đăng nhập</button>
      </form>
      <div class="extra-links">
        <p>Bạn chưa có tài khoản? <router-link to="/register">Đăng ký</router-link></p>
        <p><router-link to="/forgot-password">Quên mật khẩu?</router-link></p>
      </div>
    </div>
  </div>
</template>

<script>

import { login } from '../api/account';
import '../assets/css/login.css';



export default {
  name: 'LoginComponent',
  data() {
    return {
      emailOrPhoneNumber: '',
      password: ''
    };
  },
  methods: {
    async login() {
      try {
        console.log('Sending request to login user...');
        const data = await login(this.emailOrPhoneNumber, this.password);
        console.log('User logged in:', data);
        this.$router.push('/admin');  // Chuyển hướng đến trang Admin sau khi đăng nhập thành công
      } catch (error) {
        console.error('There was an error logging in the user:', error);
        alert('Login failed: ' + error);
      }
    }
  }
};
</script>

<style scoped>

</style>
