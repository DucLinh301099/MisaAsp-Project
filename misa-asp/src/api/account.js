import axios from 'axios';
// import base from '../api/base';

const apiClient = axios.create({
  baseURL: 'https://localhost:7173/api/',
  headers: {
    'Content-Type': 'application/json'
  }
});
// Hàm để lấy token từ localStorage và gắn vào headers của axios
const setAuthHeader = () => {
  const token = localStorage.getItem('token');
  if (token) {
    apiClient.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    console.log('Token set in header:', token);
  } else {
    console.log('No token found in localStorage');
  }
};
setAuthHeader();
// API call để đăng nhập
export const login = async (emailOrPhoneNumber, password) => {
  try {
    console.log('Attempting to log in user...');
    const response = await apiClient.post('Account/login', {
      EmailOrPhoneNumber: emailOrPhoneNumber,
      Password: password
    });
    // Lưu token vào localStorage
    localStorage.setItem('token', response.data.token);
    console.log('User logged in successfully. Token received:', response.data.token);
    // Gắn token vào header
    setAuthHeader();
    return response.data;
  } catch (error) {
    console.error('Error logging in:', error.response ? error.response.data : error.message);
    throw error.response ? error.response.data : error.message;
  }
};

// API call để đăng ký
export const register = async (firstName, lastName, email, phoneNumber, password) => {
  try {
    console.log('Attempting to register user...');
    const response = await apiClient.post('Account/register', {
      FirstName: firstName,
      LastName: lastName,
      Email: email,
      PhoneNumber: phoneNumber,
      Password: password
    });
    console.log('User registered successfully:', response.data);
    return response.data;
  } catch (error) {
    console.error('Error registering user:', error.response ? error.response.data : error.message);
    throw error.response ? error.response.data : error.message;
  }
};

// API call để quên mật khẩu
export const forgotPassword = async (email) => {
  try {
    console.log('Attempting to send forgot password request...');
    const response = await apiClient.post('Account/forgot-password', { Email: email });
    console.log('Forgot password request successful:', response.data);
    return response.data;
  } catch (error) {
    console.error('Error sending forgot password request:', error.response ? error.response.data : error.message);
    throw error.response ? error.response.data : error.message;
  }
};


