import { apiClient, setAuthHeader } from './base';

export const login = async (emailOrPhoneNumber, password) => {
  try {
    console.log('Attempting to log in user...');
    const response = await apiClient.post('Account/login', {
      EmailOrPhoneNumber: emailOrPhoneNumber,
      Password: password
    });

    if (response.status === 200) { // Đảm bảo rằng đăng nhập thành công
      // Lưu token vào localStorage
      localStorage.setItem('token', response.data.data.token);
      console.log('User logged in successfully. Token received:', response.data.data.token);
      // Gắn token vào header
      setAuthHeader();
      return response.data;
    } else {
      console.error('Login failed:', response.data);
      throw new Error('Login failed');
    }
  } catch (error) {
    console.error('Error logging in:', error.response ? error.response.data : error.message);
    throw error.response ? error.response.data : error.message;
  }
};

export const fetchProtectedData = async () => {
  try {
    console.log('Fetching protected data...');
    // Gắn token vào header trước khi thực hiện request
    setAuthHeader();
    const response = await apiClient.get('Account/users');
    console.log('Protected data fetched successfully:', response.data);
    return response.data.data; // Đảm bảo trả về đúng data
  } catch (error) {
    console.error('Error fetching protected data:', error.response ? error.response.data : error.message);
    throw error.response ? error.response.data : error.message;
  }
};

// API call to register
export const register = async (firstName, lastName, email, phoneNumber, password) => {
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
};

// API call to forgot password
export const forgotPassword = async (email) => {
  console.log('Attempting to send forgot password request...');
  const response = await apiClient.post('Account/forgot-password', { Email: email });
  console.log('Forgot password request successful:', response.data);
  return response.data;
};

// API call to update user
export const updateUser = async (user) => {
  console.log('Attempting to update user...');
  const response = await apiClient.put(`Account/users/${user.id}`, user, {
    headers: {
      'Content-Type': 'application/json'
    }
  });
  console.log('User updated successfully:', response.data);
  return response.data;
};

// API call to delete a user
export const deleteUserById = async (id) => {
  const response = await apiClient.delete(`Account/users/${id}`);
  return response.data;
};
