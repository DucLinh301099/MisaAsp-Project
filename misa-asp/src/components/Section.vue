<template>
  <div>
    <!-- Stats Section -->
     <div class="stats-container">
      <div class="search-bar">
       <div class="search-div">
        <div class="pre-icon service-icon-search"></div>
        <input type="text" placeholder="Dịch vụ cần tìm" v-model="searchQuery" class="search-input" />
       </div>
      
       <div class="location-select-wrapper">
        <div class="pre-icon location-icon"></div>
         <select v-model="selectedLocation" class="location-select ">
          <option  value="">Tỉnh/Thành phố</option>
          <option v-for="city in cities" :key="city" :value="city">{{ city }}</option>
        </select>
       </div>
       <button @click="search">Tìm kế toán</button>
      </div>
    <div class="stats">
      <div class="stat">
        <h3>20.592</h3>
        <p>Doanh nghiệp được kết nối</p>
      </div>
      <div class="stat">
        <h3>1.836</h3>
        <p>Hộ kinh doanh được kết nối</p>
      </div>
      <div class="stat">
        <h3>1.677</h3>
        <p>Đại lý thuế, kế toán dịch vụ</p>
      </div>
      <div class="stat">
        <h3>55.571</h3>
        <p>Người dùng</p>
      </div>
    </div>
  </div>
    <!-- Video Section -->
    <div class="video-section">
      <div class="video-container">
        <img src="https://asp.misa.vn/Content/Images/PNG/Home/Home_New/icon/bg_video.png" alt="Video Thumbnail" class="video-thumbnail" />
        <!-- <div class="play-button">
          <svg width="50" height="50" viewBox="0 0 24 24"><path fill="currentColor" d="M8 5v14l11-7z"/></svg>
        </div> -->
      </div>
      <div class="cta">
        <h2>Nền Tảng kế Toán Dịch Vụ</h2>
        <p>MISA ASP là nền tảng kết nối dịch vụ giúp kết nối doanh nghiệp, hộ kinh doanh, cá nhân kinh doanh có nhu cầu thuê dịch vụ kế toán với tổ chức cung ứng dịch vụ kế toán, thuế uy tín, chất lượng, chuyên nghiệp trên toàn quốc.</p>
        <button>Nhận tư vấn miễn phí</button>
      </div>
    </div>
  </div>
</template>

<script>
import '../assets/css/section.css';
export default {
  name: 'Section',
  data() {
    return {
      searchQuery: '',
    };
  },
  data() {
    return {
      selectedLocation: '',
      cities: [
        'Hà Nội',
        'Hồ Chí Minh',
        'Đà Nẵng',
        'Hải Phòng',
        'Cần Thơ',
        // Thêm các thành phố khác vào đây
      ]
    }
  },

  methods: {
    search() {
      // Handle the search functionality
      console.log(`Searching for: ${this.searchQuery} in ${this.selectedLocation}`);
    }
  }
}
</script>

<style scoped>

</style>
