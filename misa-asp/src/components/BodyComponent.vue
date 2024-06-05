<template>
  <div class="body-component">
    <h2>Kế toán dịch vụ tiêu biểu</h2>
    <div class="filters">
      <input type="text" v-model="searchQuery" placeholder="Tìm kiếm dịch vụ" class="search-input" />
      <div class="filter-buttons">
        <button v-for="filter in filters" :key="filter" :class="{ active: selectedFilter === filter }" @click="selectedFilter = filter">
          {{ filter }}
        </button>
      </div>
    </div>
    <div class="service-list">
      <div class="service-card" v-for="service in filteredServices" :key="service.id">
        <img :src="service.logo" alt="Service Logo" class="service-logo" />
        <div class="service-details">
          <h3>{{ service.name }}</h3>
          <div class="rating" v-if="service.rating > 0">
            <span v-for="star in 5" :key="star" class="star" :class="{ filled: star <= service.rating }">&#9733;</span>
            <span>{{ service.reviews }} Đánh giá</span>
          </div>
          <div v-else>Chưa có đánh giá</div>
          <div class="info">
            <span>{{ service.customers }} khách hàng</span>
            <span>{{ service.location }}</span>
          </div>
          <div class="price">Từ {{ service.price }}</div>
        </div>
      </div>
    </div>
    <div class="pagination">
      <button @click="onPrevPage" :disabled="currentPage === 1">Trước</button>
      <button @click="onNextPage" :disabled="currentPage === totalPages">Sau</button>
    </div>
    <div class="view-all">
      <a href="#">Xem tất cả</a>
    </div>
  </div>
</template>

<script>
import { getServices, filterServices, prevPage, nextPage } from '../api/accountant';
import '../assets/css/body.css';
export default {
  name: 'BodyComponent',
  data() {
    return {
      searchQuery: '',
      selectedFilter: 'Tiêu biểu',
      filters: ['Tiêu biểu', 'Có ưu đãi', 'Mới nhất', 'Tổ chức', 'Cá nhân'],
      services: [],
      currentPage: 1,
      totalPages: 1,
    };
  },
  computed: {
    filteredServices() {
      return filterServices(this.services, this.searchQuery);
    }
  },
  methods: {
    async fetchServices() {
      try {
        const services = await getServices();
        this.services = services;
      } catch (error) {
        console.error('Failed to fetch services:', error);
      }
    },
    onPrevPage() {
      this.currentPage = prevPage(this.currentPage);
    },
    onNextPage() {
      this.currentPage = nextPage(this.currentPage, this.totalPages);
    }
  },
  created() {
    this.fetchServices();
  }
};
</script>

<style scoped>

</style>
