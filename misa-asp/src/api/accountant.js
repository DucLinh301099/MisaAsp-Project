// src/api/service.js
import { apiClient } from './base.js';

const API_URL = 'Accountant/list'; // Adjust this endpoint based on your API's address

export const getServices = async () => {
  try {
    const response = await apiClient.get(API_URL);
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
