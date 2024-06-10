import axios from 'axios';

// Cấu hình axios instance
export const apiClient = axios.create({
  baseURL: 'https://localhost:7173/api/',
  headers: {
    'Content-Type': 'application/json'
  }
});

// Hàm để lấy token từ localStorage và gắn vào headers của axios
export const setAuthHeader = () => {
  const token = localStorage.getItem('token');
  if (token) {
    apiClient.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    console.log('Token set in header:', token);
  } else {
    console.log('No token found in localStorage');
  }
};

setAuthHeader();
