import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7173/api/',
  headers: {
    'Content-Type': 'application/json'
  }
});

// Function to get token from localStorage and attach it to axios headers
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

// API call to login
export const login = async (emailOrPhoneNumber, password) => {
  try {
    console.log('Attempting to log in user...');
    const response = await apiClient.post('Account/login', {
      EmailOrPhoneNumber: emailOrPhoneNumber,
      Password: password
    });
    // Save token to localStorage
    localStorage.setItem('token', response.data.token);
    console.log('User logged in successfully. Token received:', response.data.token);
    // Attach token to header
    setAuthHeader();
    return response.data;
  } catch (error) {
    console.error('Error logging in:', error.response ? error.response.data : error.message);
    throw error.response ? error.response.data : error.message;
  }
};

// API call to register
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
    if (error.response) {
      console.error('Error registering user:', error.response.data);
      if (error.response.status === 400) {
        // Handle validation errors
        const validationErrors = error.response.data.errors;
        let errorMessages = [];
        if (validationErrors.Email) {
          errorMessages.push(`Email error: ${validationErrors.Email[0]}`);
        }
        if (validationErrors.PhoneNumber) {
          errorMessages.push(`Phone number error: ${validationErrors.PhoneNumber[0]}`);
        }
        throw new Error(errorMessages.join(', '));
      }
    } else {
      console.error('Error registering user:', error.message);
      throw new Error('Registration failed: ' + error.message);
    }
  }
};

// API call to forgot password
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
