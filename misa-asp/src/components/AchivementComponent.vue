<template>
    <section class="archivement">
      <div class="archivement-bg"></div>
      <div class="archivement-group container">
        <div class="archivement-title">Giải thưởng</div>
        <div class="archivement-item-group">
          <div class="archivement-item-side archivement-item-left">
            <a href="/tt/kien-thuc/misa-asp-ghi-danh-sao-khue-2021/" class="archivement-item" target="_blank">
              <div class="archivement-background"></div>
              <div class="left-side">
                <img src="https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Archivement/Sao_khue_2021.png" loading="lazy">
              </div>
              <div class="right-side">
                <div class="arc-title">
                  MISA ASP được vinh danh tại lễ trao giải Sao Khuê 2021
                </div>
                <div class="read-more">Đọc thêm</div>
              </div>
            </a>
            <a href="/tt/kien-thuc/misa-asp-gianh-giai-thuong-chuyen-doi-so-viet-nam-2021/" class="archivement-item" target="_blank">
              <div class="archivement-background"></div>
              <div class="left-side">
                <img src="https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Archivement/Giai_thuong_chuyen_doi_so.png" loading="lazy">
              </div>
              <div class="right-side">
                <div class="arc-title">MISA ASP giành giải thưởng Chuyển đổi số Việt Nam 2021</div>
                <div class="read-more">Đọc thêm</div>
              </div>
            </a>
          </div>
          <div class="archivement-item-side archivement-item-left">
            <a href="/tt/kien-thuc/misa-asp-duoc-vinh-danh-tai-le-trao-giai-sao-khue-2023/" class="archivement-item" target="_blank">
              <div class="archivement-background"></div>
              <div class="left-side">
                <img src="https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Archivement/Sao_khue_2023.png" loading="lazy">
              </div>
              <div class="right-side">
                <div class="arc-title">MISA ASP được vinh danh tại lễ trao giải Sao Khuê 2023</div>
                <div class="read-more">Đọc thêm</div>
              </div>
            </a>
            <a href="/tt/kien-thuc/misa-asp-la-nen-tang-make-in-vietnam-xuat-sac-hang-muc-kinh-te-so/" class="archivement-item" target="_blank">
              <div class="archivement-background"></div>
              <div class="left-side">
                <img src="https://asp.misa.vn/Content/Images/PNG/Home/Home_New/IMAGE/Media_Image/bc_makeinvietnam.png" loading="lazy">
              </div>
              <div class="right-side">
                <div class="arc-title">MISA ASP là nền tảng Make in Vietnam xuất sắc hạng mục Kinh tế số 2023</div>
                <div class="read-more">Đọc thêm</div>
              </div>
            </a>
          </div>
        
        </div>
        <div class="archivement-images-ab">
         <div class="main-image slider" id="slider">
          <div class="wrapper">
            <div class="owl-carousel owl-theme owl-loaded owl-drag">
              <div class="owl-stage-outer">               
                  <div class="owl-item cloned" style="width: 798px;">
                    <img class="slide-image slide image-1" src="https://asp.misa.vn/Content/Images/PNG/Home/bg_GiaiThuong3.png" loading="lazy">
                  </div>             
              </div>
            </div>
            <div class="ic-cup">
              <img src="https://asp.misa.vn/Content/Images/PNG/Home/Home_New/icon/ic_Cup.png" loading="lazy">
            </div>
          </div>
         </div>
        </div>
      </div>
      
    </section>
  </template>
  
  <script>
  export default {
    name: 'AchivementComponent',
  };
  </script>
  
  <style scoped>
  @media (max-width: 1660px) {
    .archivement {
      height: 750px;
    }
    .archivement-bg {
      background: unset;
    }
    .archivement-item-side {
      flex-direction: column;
      row-gap: 15px;
    }
  }
  @media (min-width: 1200px) {
    .container {
      width: 1170px;
    }
  }
  .archivement {
    height: 750px;
    width: 100%;
    background-image: linear-gradient(45.52deg, #00c15b, #011023);
    margin-top: 80px;
    position: relative;
    padding: 0 24px;
  }
  .archivement-bg {
    position: absolute;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    background: url('https://asp.misa.vn/Content/Images/SVG/bg_GiaiThuong.svg') no-repeat;
    opacity: 0.5;
  }
  .archivement .container {
    height: 100%;
  }
  .container {
    max-width: 1170px !important;
    padding-left: 60px;
  }
  .archivement-title {
    height: 53px;
    font-size: 40px;
    font-family: AvertaStdCY, Helvetica, Arial, sans-serif;
    font-style: normal;
    line-height: 53px;
    position: relative;
    top: 65px;
    color: #fff;
  }
  .archivement-item-group {
    max-width: 645px;
    display: flex;
    flex-direction: column;
    row-gap: 15px;
    margin-top: 100px;
    font-family: AvertaStdCY, Helvetica, Arial, sans-serif;
  }
  .archivement-item-side {
    display: flex;
    column-gap: 15px;
  }
  .archivement-item {
    height: 127px;
    width: 315px;
    overflow: hidden;
    padding: 16px;
    position: relative;
    display: flex;
  }
  a, .td-page-content a {
    outline: 0;
    border: 0;
    text-decoration: none;
  }
  a {
    background-color: transparent;
    color: #4db2ec;
  }
  .archivement-background {
    background-color: #000;
    opacity: 0.2;
    height: 100%;
    width: 100%;
    border-radius: 8px;
    position: absolute;
    top: 0;
    left: 0;
    z-index: 0;
  }
  .left-side {
    width: 112px;
  }
  .arc-title {
    line-height: 18px;
    color: #fff;
    z-index: 1;
    position: relative;
    max-width: 179px;
  }
  .read-more {
    z-index: 1;
    line-height: 18px;
    position: relative;
    margin-top: 8px;
    color: #fff;
  }
  
  .archivement-images-ab {
    height: 100%;
    max-width: 798px;
    position: absolute;
    top: 80px;
    width: 100%;
    right: 50px;
}
   .ic-cup {
    position: absolute;
    bottom: 200px;
    left: 0;
  }
  .ic-cup img {
    height: 100px;
  }
  .section {
    display: block;
  }
  * {
    scroll-margin-top: 100px;
    box-sizing: border-box;
  }
  </style>
  