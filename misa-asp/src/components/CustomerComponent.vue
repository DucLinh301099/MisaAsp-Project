<template>
  <div class="customer-component">
    <h2 class="title">Đánh giá của khách hàng, đối tác</h2>
    <div class="testimonial-carousel">
      <button @click="prevTestimonial" class="carousel-button prev-button">‹</button>
      <div class="testimonials-container" ref="testimonialsContainer">
        <div class="testimonial" v-for="(testimonial, index) in testimonials" :key="index">
          <img :src="testimonial.image" alt="Customer photo" class="testimonial-image">
          <p class="text">{{ testimonial.text }}</p>
          <div class="separate-line"></div>
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
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/9_Luu_Van_Tuan.png',
          text: 'Sau khi đánh giá tổng quát, tôi khẳng định MISA ASP vượt trội hơn hẳn vì mọi tính năng được đầu tư chỉn chu, đi sâu vào thực tiễn, phù hợp với kế toán dịch vụ. Sử dụng Misa Asp giúp việc lưu trữ...',
          author: 'Ông Lưu Văn Tuấn',
          position: 'Giám đốc Công ty TNHH dịch vụ kế toán thuế và cung cấp lao động Quang Huy',
        },
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/10_Nguyen_Thi_Thu.png',
          text: 'Biết ơn MISA vì cho ra đời MISA ASP, chi phí sử dụng quá nhỏ so với giá trị mà MISA ASP đưa đến cho doanh nghiệp. Nhờ công cụ tốt, năng suất, chất lượng tăng gấp đôi thậm chí gấp nhiều lần nên doanh thu cũng tăng. ',
          author: 'Bà  Nguyễn Thị Thu',
          position: 'Giám đốc công ty TNHH Tư vấn Bắc Ninh',
        },
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/11_Mai_Trong_Hieu.png',
          text: 'Sử dụng MISA ASP, doanh nghiệp bảo mật được thông tin và làm chủ dữ liệu mà không phụ thuộc kế toán dịch vụ với chi phí cực kỳ thấp. Trong khi đó, kế toán dịch vụ có thể làm việc online mà năng suất vẫn tăng gấp nhiều lần.',
          author: 'Ông Mai Trọng Hiếu',
          position: 'Chủ tịch hội đồng quản trị Công ty Cổ phần Tư vấn và Đào tạo Kỹ năng kế toán',
        },
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/12_Nguyen_Thi_Loan.png',
          text: 'MISA luôn lắng nghe ý kiến khách hàng và cho ra mắt tính năng cực kỳ nhanh theo sát từng nhu cầu của KTDV. Đặc biệt, khâu chăm sóc cực kỳ chu đáo, mỗi đối tác có 3-4 nhân viên hỗ trợ trực tiếp.',
          author: 'Bà Nguyễn Thị Loan',
          position: 'Giám đóc công ty cổ phần dịch vụ kế toán và đại lý thuế Nam Thái Nguyên',
        },
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/14_Nguyen_Van_Kha.png',
          text: 'Nhờ có MISA ASP Kế toán sử dụng song song trong quá trình làm việc, tôi dễ dàng phát hiện thao tác nhầm của kế toán dịch vụ. Hay trong trường hợp kế toán chậm trễ, tôi cũng có thể nắm bắt.',
          author: 'Ông Nguyễn Văn Kha',
          position: 'Giám đốc Công ty TNHH xuất nhập khẩu 355 DECOR',
        },
        {
          image: 'https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Customer_rate/15_Dang_Nhat_Minh.png',
          text: 'Nhờ có MISA ASP Kế toán sử dụng song song trong quá trình làm việc, tôi dễ dàng phát hiện thao tác nhầm của kế toán dịch vụ. Hay trong trường hợp kế toán chậm trễ, tôi cũng có thể nắm bắt.',
          author: 'Ông Đặng Nhật Minh',
          position: 'Giám đốc Công ty TNHH Thương mại và tư vấn Minh Anh',
        },
      ],
      currentIndex: 0,
    };
  },
  methods: {
    prevTestimonial() {
      if (this.currentIndex > 0) {
        this.currentIndex--;
      } else {
        this.currentIndex = this.testimonials.length - 1;
      }
      this.updateCarousel();
    },
    nextTestimonial() {
      if (this.currentIndex < this.testimonials.length - 1) {
        this.currentIndex++;
      } else {
        this.currentIndex = 0;
      }
      this.updateCarousel();
    },
    updateCarousel() {
      const container = this.$refs.testimonialsContainer;
      const testimonialWidth = container.clientWidth / 3; // Display 3 testimonials at a time
      container.style.transform = `translateX(-${this.currentIndex * testimonialWidth}px)`;
    },
  },
  mounted() {
    window.addEventListener('resize', this.updateCarousel);
  },
  beforeDestroy() {
    window.removeEventListener('resize', this.updateCarousel);
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

.title {
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

.text {
  max-width: 310px;
  font-size: 15px;
  color: #2a2a2a;
  line-height: 18px;
  margin: 0 auto;
  text-align: justify;
}

.testimonials-container {
  display: flex;
  transition: transform 0.5s ease-in-out;
  width: 100%;
}

.testimonial {
  flex: 0 0 22.05%; /* Display 3 testimonials at a time */
  max-width: 33.33%; /* Ensure each testimonial takes 1/3 of the container */
  height: 396px;
  margin: 1px 20px;
  padding: 20px 50px;
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
  
    color: #757575;
    margin: 0 auto;
    line-height: 17px;
    font-size: 14px;

}
.separate-line {
    background-color: #349b2a;
    width: 46px;
    height: 2px;
    margin: 20.5px auto;
}
.separate-line {
    background-color: #56aa33 !important;
    height: 1px !important;
    width: 46px !important;
}

.carousel-button {
  background: none;
  border: none;
  font-size: 2rem;
  cursor: pointer;
  z-index: 1;
}
/* button{
  
    position: relative;
    max-width: 1372px;
    position: relative;
    top: -255px;
    display: flex;
    justify-content: space-between;
    width: 100%;
    align-items: center;
    margin: 0 auto;
} */
.prev-button {
  position: absolute;
  left: 0;
}

.next-button {
  position: absolute;
  right: 0;
}
</style>
