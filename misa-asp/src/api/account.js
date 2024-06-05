
import { apiClient, setAuthHeader } from './base';

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
