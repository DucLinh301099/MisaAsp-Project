<template>
    <div class="forgot-password-page">
        <div class="forgot-password-container">
            <div class="logo-section">
                <router-link to="/">
                    <img src="https://asp.misa.vn/Content/Images/SVG/Logo.svg"
                        alt="MISA ASP Logo" class="main-logo" />
                </router-link>
            </div>
            <h2>Quên Mật Khẩu</h2>
            <form @submit.prevent="forgotPassword">
                <div class="form-group">
                    <input type="email" v-model="email" placeholder="Email" required />
                </div>
                <button type="submit" class="forgot-password-button">Gửi Yêu Cầu</button>
            </form>
        </div>
    </div>
</template>

<script>
import { forgotPassword } from '../api/account';
import '../assets/css/account.css';
export default {
    name: 'ForgotPasswordComponent',
    data() {
        return {
            email: ''
        };
    },
    methods: {
        async forgotPassword() {
            try {
                console.log('Sending forgot password request...');
                const data = await forgotPassword(this.email);
                console.log('Forgot password request successful:', data);
                alert('Password reset link has been sent to your email.');
            } catch (error) {
                console.error('There was an error processing the forgot password request:', error);
                alert('Email Not Found: ' + error);
            }
        }
    }
};
</script>

<style scoped>

</style>
