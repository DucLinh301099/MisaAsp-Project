<template>
  <div class="register-page">
    <div class="register-container">
      <div class="logo-section-register">
        <router-link to="/">
          <img
            src="https://asp.misa.vn/Content/Images/SVG/Logo.svg"
            alt="MISA ASP Logo" class="main-logo2" />
        </router-link>
      </div>
      <div class="main-title mt-3">
             <div class="row">
                 <div class="col-6-1">
                     <span class="bold">Đăng Ký</span>
                   </div>
                    <div class="col-6-2">
                   <img src="https://asp.misa.vn/App/Content/images/Logo2.png" class="float-right">
                    </div>
               </div>
         </div>
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
        <div v-if="generalError" class="error">{{ generalError }}
        </div>
        <div class="extra-links">
        <p>Bạn đã có tài khoản? <router-link to="/login">Đăng Nhập</router-link></p>
        <p><router-link to="/href">Trợ giúp</router-link></p>
      </div>
      </form>
    </div>
  </div>
</template>

<script>
import { register } from '../api/account';
import '../assets/css/register.css';

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
.bold{
  font-weight: 550;
}
  .main-title {
    font-family: AvertaStdCY_Semibold, Helvetica, Arial, sans-serif;
    font-size: 20px !important;
}
.mt-3, .my-3 {
    margin-top: 1rem !important;
}
.row {
    display: -ms-flexbox;
    display: flex;
    -ms-flex-wrap: wrap;
    flex-wrap: wrap;
    padding-bottom: 15px;
    
}
.col-6-1 {
    -ms-flex: 0 0 50%;
    flex: 0 0 50%;
    max-width: 50%;
    text-align: left;
}
.col-6-2 {
    -ms-flex: 0 0 50%;
    flex: 0 0 50%;
    max-width: 50%;
    
}
.float-right {
    float: right !important;
}
img {
    vertical-align: middle;
    border-style: none;
}
</style>
