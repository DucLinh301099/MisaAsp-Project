import axios from 'axios';

// Cấu hình axios instance
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

// Hàm để kiểm tra token và gọi một API yêu cầu xác thực
export const fetchProtectedData = async () => {
  try {
    console.log('Fetching protected data...');
    // Gắn token vào header trước khi thực hiện request
    setAuthHeader();
    const response = await apiClient.get('Account/users');
    console.log('Protected data fetched successfully:', response.data);
    return response.data;
  } catch (error) {
    console.error('Error fetching protected data:', error.response ? error.response.data : error.message);
    throw error.response ? error.response.data : error.message;
  }
};
