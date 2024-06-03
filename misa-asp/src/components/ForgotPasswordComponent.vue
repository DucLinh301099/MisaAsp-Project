<template>
    <div class="forgot-password-page">
        <div class="forgot-password-container">
            <div class="logo-section">
                <router-link to="/">
                    <img src="C:\Users\vdlinh\source\repos\Vuejs\Day5\MisaAsp-Project\29-05-2024\misa-asp\src\assets\image\logo123.jpg"
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
                alert('Failed to process request: ' + error);
            }
        }
    }
};
</script>

<style scoped>
.logo-section {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
}

.main-logo {
    height: 60px;
}

.forgot-password-page {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #0A2540;
}

.forgot-password-container {
    background-color: #fff;
    padding: 40px;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    width: 400px;
}

h2 {
    margin-bottom: 20px;
    font-size: 24px;
    color: #333;
}

.form-group {
    margin-bottom: 20px;
}

.form-group input {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
}

.forgot-password-button {
    width: 100%;
    padding: 10px;
    border: none;
    border-radius: 4px;
    background-color: #4CAF50;
    color: white;
    cursor: pointer;
    font-size: 16px;
}
</style>
