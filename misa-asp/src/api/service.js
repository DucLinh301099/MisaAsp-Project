// src/api/service.js
import axios from 'axios';

const API_URL = 'https://localhost:7173/api/Services'; // Adjust this URL based on your API's address

export const getServices = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error('Failed to fetch services:', error);
    throw error;
  }
};

export const filterServices = (services, searchQuery) => {
  return services.filter(service => 
    service.name.toLowerCase().includes(searchQuery.toLowerCase())
  );
};

export const prevPage = (currentPage) => {
  return currentPage > 1 ? currentPage - 1 : currentPage;
};

export const nextPage = (currentPage, totalPages) => {
  return currentPage < totalPages ? currentPage + 1 : currentPage;
};
