<template>
  <div class="customer-component">
    <h2 class="title">Đánh giá của khách hàng, đối tác</h2>
    <div class="testimonial-carousel">
      <button @click="prevTestimonial" class="carousel-button prev-button">‹</button>
      <div class="testimonials-container">
        <div class="testimonial" v-for="(testimonial, index) in testimonials" :key="index">
          <img :src="testimonial.image" alt="Customer photo" class="testimonial-image">
          <p class="text">{{ testimonial.text }}</p>
          <p class="author">{{ testimonial.author }}</p>
          <p class="position">{{ testimonial.position }}</p>
        </div>
      </div>
      <button @click="nextTestimonial" class="carousel-button next-button">›</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CustomerComponent',
  data() {
    return {
      testimonials: [
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/12_Nguyen_Thi_Loan.png',
          text: 'MISA luôn lắng nghe ý kiến khách hàng và cho ra mắt tính năng cực kỳ nhanh theo sát từng nhu cầu của KTĐV. Đặc biệt, khâu chăm sóc cực kỳ chu đáo, mỗi đối tác có 3-4 nhân viên hỗ trợ trực tiếp.',
          author: 'Bà Nguyễn Thị Loan',
          position: 'Giám đốc Công ty cổ phần dịch vụ kế toán và đại lý thuế Nam Thái Nguyên',
        },
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/14_Nguyen_Van_Kha.png',
          text: 'Nhờ có MISA ASP Kế toán sử dụng song song trong quá trình làm việc, tôi dễ dàng phát hiện thao tác nhầm của kế toán dịch vụ. Hay trong trường hợp kế toán chậm trễ, tôi cũng có thể nắm bắt.',
          author: 'Ông Nguyễn Văn Kha',
          position: 'Giám đốc Công ty TNHH xuất nhập khẩu 355 DECOR',
        },
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/15_Dang_Nhat_Minh.png',
          text: 'Đến khi chuyển đổi số lên MISA ASP, tôi hoàn toàn hài lòng. MISA ASP giúp tôi chủ động hơn khi hợp tác với các đơn vị kế toán dịch vụ. Không còn ở thế bị động, ngay trên nền tảng, tôi có thể nắm bắt.',
          author: 'Ông Đặng Nhật Minh',
          position: 'Giám đốc công ty TNHH Thương mại và Tư vấn Minh Anh',
        },
      ],
    };
  },
  methods: {
    prevTestimonial() {
      // Add functionality for previous button if needed
    },
    nextTestimonial() {
      // Add functionality for next button if needed
    },
  },
};
</script>

<style scoped>
.customer-component {
  text-align: center;
  padding: 20px;
  padding-top: 40px;
  padding-bottom: 40px;
}
.title{
    margin-bottom: 20px;
    font-size: 30px;
    color: #333;
    font-family: AvertaStdCY, Helvetica, Arial, sans-serif;
}
.testimonial-carousel {
  display: flex;
  align-items: center;
  justify-content: center;
  position: relative;
  max-width: 1200px;
  margin: 0 auto;
  overflow: hidden;
}
.text{
  max-width: 310px;
    font-size: 15px;
    color: #2a2a2a;
    line-height: 18px;
    margin: 0 auto;
    text-align: justify;
}
.testimonials-container {
  display: flex;
  justify-content: center;
  width: 100%;
  
}

.testimonial {
  flex: 1;
  height: 396px;
  max-width: 400px;
  margin: 1px 20px 1px 20px;
  padding: 20px 50px 0 50px;
  box-shadow: 0 3px 20px rgba(0, 0, 0, .12);
  border-radius: 7px;
  background: #fff;
  font-family: AvertaStdCY, Helvetica, Arial, sans-serif;
}

.testimonial-image {
  border-radius: 50%;
  width: 100px;
  height: 100px;
  object-fit: cover;
  margin-bottom: 10px;
}

.author {
  font-weight: bold;
  color: green;
}

.position {
  font-style: italic;
}

.carousel-button {
  background: none;
  border: none;
  font-size: 2rem;
  cursor: pointer;
  z-index: 1;
}

.prev-button {
  position: absolute;
  left: 0;
}

.next-button {
  position: absolute;
  right: 0;
}
</style>
