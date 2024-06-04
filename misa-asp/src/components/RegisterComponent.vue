<template>
  <div class="register-page">
    <div class="register-container">
      <div class="logo-section">
        <router-link to="/">
          <img
            src="C:\Users\vdlinh\source\repos\Vuejs\Day5\MisaAsp-Project\29-05-2024\misa-asp\src\assets\image\logo123.jpg"
            alt="MISA ASP Logo" class="main-logo" />
        </router-link>
      </div>
      <h2>Đăng ký</h2>
      <form @submit.prevent="register">
        <div class="form-group">
          <input type="text" v-model="firstName" placeholder="Họ" required />
        </div>
        <div class="form-group">
          <input type="text" v-model="lastName" placeholder="Tên" required />
        </div>
        <div class="form-group">
          <input type="text" v-model="email" placeholder="Email" required />
          <div v-if="errors.Email" class="error">{{ errors.Email }}</div>
        </div>
        <div class="form-group">
          <input type="text" v-model="phoneNumber" placeholder="Số điện thoại" required />
          <div v-if="errors.PhoneNumber" class="error">{{ errors.PhoneNumber }}</div>
        </div>
        <div class="form-group">
          <input type="password" v-model="password" placeholder="Mật khẩu" required />
        </div>
        <button type="submit" class="register-button">Đăng ký</button>
        <div v-if="generalError" class="error">{{ generalError }}</div>
      </form>
    </div>
  </div>
</template>

<script>
import { register } from '../api/account';

export default {
  name: 'RegisterComponent',
  data() {
    return {
      firstName: '',
      lastName: '',
      email: '',
      phoneNumber: '',
      password: '',
      errors: {},
      generalError: ''
    };
  },
  methods: {
    async register() {
      try {
        console.log('Sending request to register user...');
        const data = await register(this.firstName, this.lastName, this.email, this.phoneNumber, this.password);
        console.log('User registered:', data);
        alert('Registration successful!');
        this.$router.push('/login');
      } catch (error) {
        console.error('There was an error registering the user:', error);
        this.errors = {};
        this.generalError = '';

        // Handle specific validation errors
        if (error.message.includes('Email error')) {
          this.errors.Email = error.message.split(', ').find(msg => msg.includes('Email error'));
        }
        if (error.message.includes('Phone number error')) {
          this.errors.PhoneNumber = error.message.split(', ').find(msg => msg.includes('Phone number error'));
        }

        // Handle general error
        if (!this.errors.Email && !this.errors.PhoneNumber) {
          this.generalError = error.message;
        }
      }
    }
  }
};
</script>

<style scoped>
.register-page {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #0A2540;
}

.register-container {
  background-color: #fff;
  padding: 40px;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
  width: 400px;
}

.logo-section {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
}

.main-logo {
  height: 60px;
}

.misa-logo {
  height: 24px;
}

h2 {
  margin-bottom: 20px;
  font-size: 24px;
  color: #333;
}

.form-group {
  margin-bottom: 20px;
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.form-group input {
  flex: 1;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.form-group input[type="email"],
.form-group input[type="text"],
.form-group input[type="password"] {
  width: 100%;
  margin: 0;
}

.error {
  color: red;
  font-size: 0.875rem;
  margin-top: 5px;
}

.register-button {
  width: 100%;
  padding: 10px;
  border: none;
  border-radius: 4px;
  background-color: #4CAF50;
  color: white;
  cursor: pointer;
  font-size: 16px;
}

.extra-links {
  margin-top: 20px;
}

.extra-links p {
  margin: 5px 0;
}

.extra-links a {
  color: #1E90FF;
  text-decoration: none;
}

.extra-links a:hover {
  text-decoration: underline;
}
</style>
