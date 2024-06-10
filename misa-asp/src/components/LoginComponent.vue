<template>
  <div class="login-page">
    <div class="login-container">
      <div class="logo-section-login">
        <router-link to="/">
          <img
            src="https://asp.misa.vn/Content/Images/SVG/Logo.svg"
            alt="MISA ASP Logo" class="main-logo1" />
        </router-link>
      </div>
      <div class="main-title mt-3">
             <div class="row">
                 <div class="col-6-1">
                     <span class="bold">Đăng nhập</span>
                   </div>
                    <div class="col-6-2">
                   <img src="https://asp.misa.vn/App/Content/images/Logo2.png" class="float-right">
                    </div>
               </div>
         </div>
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
        this.$router.push('/admin'); // Chuyển hướng đến trang Admin sau khi đăng nhập thành công
      } catch (error) {
        console.error('There was an error logging in the user:', error);
        let errorMessage;
        if (error.response && error.response.data && error.response.data.message) {
          errorMessage = error.response.data.message; // Lấy thông báo lỗi từ server
        } else {
          errorMessage = 'Tài khoản hoặc mật khẩu sai. Vui lòng thử lại.'; // Thông báo lỗi chung
        }
        alert(errorMessage); // Hiển thị thông báo lỗi bằng alert
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
