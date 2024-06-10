<template>
  <div class="contact-component">
    <div class="contact-info">
      <h2>Đăng ký nhận tư vấn miễn phí từ MISA ASP</h2>
      <p>
        MISA ASP là Nền tảng kết nối dịch vụ giúp kết nối Doanh nghiệp, Hộ kinh doanh, Cá nhân kinh doanh với các Tổ chức cung ứng dịch vụ kế toán uy tín, chất lượng, chuyên nghiệp trên toàn quốc.
      </p>
    </div>
    <div class="contact-form">
      <h3>Đăng Ký Nhận Tư Vấn Miễn Phí Từ Misa Asp</h3>
      <form @submit.prevent="submitForm">
        <div class="form-group">
          <label for="name">Họ và tên *</label>
          <input class="form-control" type="text" id="name" v-model="form.name" required />
        </div>
        <div class="form-group">
          <label for="phone">Số điện thoại *</label>
          <input class="form-control" type="tel" id="phone" v-model="form.phone" required />
        </div>
        <div class="form-group">
          <label for="email">Email</label>
          <input class="form-control" type="email" id="email" v-model="form.email" />
        </div>
        <div class="form-group">
          <label>Bạn là ai?</label>
          <div class="radio-group">
            <input type="radio" id="service" value="Kế toán dịch vụ" v-model="form.role" />
            <label for="service">Kế toán dịch vụ</label>
            <input type="radio" id="organization" value="Đơn vị thuê KTDV" v-model="form.role" />
            <label for="organization">Đơn vị thuê KTDV</label>
          </div>
        </div>
        <div class="form-group">
          <label for="message">Nội dung cần tư vấn</label>
          <textarea class="form-control" id="message" v-model="form.message" placeholder="Vui lòng nhập nội dung bạn cần tư vấn tại đây"></textarea>
        </div>
        <p class="disclaimer">
          Bằng cách bấm vào nút Nhận tư vấn miễn phí, bạn đã đồng ý với <a href="#">Chính sách quyền riêng tư</a> của MISA.
        </p>
        <div class="form-footer">
          <button type="submit" class="primary">Nhận tư vấn miễn phí</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import '../assets/css/contact.css';

export default {
  name: 'ContactComponent',
  data() {
    return {
      form: {
        name: '',
        phone: '',
        email: '',
        role: 'Kế toán dịch vụ',
        message: ''
      }
    };
  },
  methods: {
    submitForm() {
      // Handle form submission
      console.log('Form submitted:', this.form);
    }
  }
};
</script>

<style scoped>

</style>
