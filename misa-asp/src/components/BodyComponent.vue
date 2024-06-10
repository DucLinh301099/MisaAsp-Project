<template>
  <div class="body-component">
   <div class="title"> 
    <h1>Kế Toán Dịch Vụ Tiêu Biểu</h1>
   </div>
    
    <div class="filters">
      <div>
        <input type="text" v-model="searchQuery" placeholder="Tìm kiếm dịch vụ" class="search-input" />
      </div>
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
          <div class="rating">
            <div v-if="service.rating > 0">
              <span v-for="star in 5" :key="star" class="star" :class="{ filled: star <= service.rating }">&#9733;</span>
              <span>{{ service.reviews }} Đánh giá</span>
            </div>
            <div v-else>Chưa có đánh giá</div>
          </div>
          <div class="group-accounting">
                 <div class="accounting-total-customer flex-row">
                      <div class="icon-customer"></div>
                      <div class="accounting-total-customer-label">{{ service.customers }}khách hàng</div>
                </div>
                        
                <div class="accounting-address flex-row">
                 <div class="icon-address"></div>
                 <div class="accounting-address-label">{{ service.location }}</div>
               </div>
            </div>
          <!-- <div class="info">
            <span>{{ service.customers }} khách hàng</span>
            <span>{{ service.location }}</span>
          </div> -->
          <div class="price">Từ {{ service.price }}</div>
        </div>
      </div>
    </div>
    <div class="pagination">
      <!-- <button @click="onPrevPage" :disabled="currentPage === 1">Trước</button>
      <button @click="onNextPage" :disabled="currentPage === totalPages">Sau</button> -->
    </div>
  </div>
</template>

<script>
import { getServices, filterServices, prevPage, nextPage } from '../api/accountant';


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
.group-accounting {
    display: flex;
    column-gap: 7px;
    line-height: 15px;
    font-size: 13px;
    color: #707070;
    column-gap: 7px;
    row-gap: 15px;
    padding-bottom: 5px;
}
.accounting-total-customer {
    width: 117px;
}
.flex-row {
    display: flex;
    flex-direction: row;
    position: relative;
    flex-wrap: wrap;
}
.icon-customer {
    background: transparent url(https://asp.misa.vn/Content/Images/SVG/ic_user.svg) no-repeat;
    background-position: center center;
    width: 16px;
    height: 16px;
}
.icon-address {
    background: transparent url(https://asp.misa.vn/Content/Images/SVG/ic_address.svg) no-repeat;
    background-position: center center;
    width: 16px;
    height: 16px;
}
.body-component {
  padding: 20px;
  background-color: #f5f5f5;
  font-family: AvertaStdCY, Helvetica, Arial, sans-serif;
}


.title{
  text-align: left;
 margin-left: 200px;
  
}

.filters {
    display: flex;  
    margin-top: 25px;
    margin-bottom: 9px;
    justify-content: space-between;
   margin-left: 200px;
   margin-right: 200px;
}

.search-input {
  padding: 10px;
  border: 0;
  border-radius: 4px;
  margin-right: 20px;
  width: 300px;
}

.filter-buttons {
  display: flex;
}

.filter-buttons button {
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  background-color: #e0e0e0;
  margin: 0 5px;
  cursor: pointer;
}

.filter-buttons button.active,
.filter-buttons button:hover {
  background-color: #4CAF50;
  color: white;
}

.service-list {
  margin-left: 200px;
  margin-right: 200px;
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(4, auto);
  gap: 20px;
  justify-content: center;
}

.service-card {
  background-color: white;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 20px;
  display: flex;
  align-items: center;
  box-shadow: 0 2px 5px rgba(0,0,0,0.1);
}

.service-logo {
  padding: 10px;
  border: 1px solid #d2d7e1;
  width: 50px;
  height: 50px;
  margin-right: 20px;
  border-radius: 8px;
}

.service-details {
  flex: 1;
}

.service-details h3 {
  margin: 0 0 10px;
  font-size: 14px;
  color: #333;
}

.rating {
  font-size: 12px;
  display: flex;
  align-items: center;
  margin-bottom: 10px;
  color: #666;
}

.star {
  color: #ccc;
}

.star.filled {
  color: #FFD700;
}

.info {
  display: flex;
  justify-content: space-between;
  margin-bottom: 10px;
  color: #666;
}

.price {
  font-weight: 600;
  color: #707070;
  font-size: 13px;
  line-height: 13px;
}

.pagination {
  text-align: center;
  margin-top: 20px;
}

.pagination button {
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  background-color: #4CAF50;
  color: white;
  cursor: pointer;
  margin: 0 5px;
}

.pagination button:disabled {
  background-color: #e0e0e0;
  cursor: not-allowed;
}
</style>
