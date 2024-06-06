<template>
  <div class="admin-page">
    <div class="header">
      <router-link to="/" class="logo">
        <img
          src="C:/Users/vdlinh/source/repos/Vuejs/MisaAsp-Project/misa-asp/src/assets/image/logo123.jpg"
          alt="Logo" />
      </router-link>
      <h1>Quản lý người dùng</h1>
    </div>
    <table class="user-table">
      <thead>
        <tr>
          <!-- <th>Id</th> -->
          <th>Họ Tên</th>
          <th>Email</th>
          <th>Số điện thoại</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in users" :key="user.id">
          <!-- <td>{{ user.id }}</td> -->
          <td>{{ user.firstName }} {{ user.lastName }}</td>
          <td>{{ user.email }}</td>
          <td>{{ user.phoneNumber }}</td>
          <td>
            <button @click="editUser(user)">Edit</button>
            <button @click="deleteUser(user.id)">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- Edit Modal -->
    <div v-if="editingUser" class="modal">
      <div class="modal-content">
        <span class="close" @click="cancelEdit">&times;</span>
        <h2>Edit User</h2>
        <form @submit.prevent="saveUser">
          <div class="form-group">
            <label>First Name</label>
            <input type="text" v-model="editingUser.firstName" required>
          </div>
          <div class="form-group">
            <label>Last Name</label>
            <input type="text" v-model="editingUser.lastName" required>
          </div>
          <div class="form-group">
            <label>Email</label>
            <input type="email" v-model="editingUser.email" required>
          </div>
          <div class="form-group">
            <label>Phone Number</label>
            <input type="text" v-model="editingUser.phoneNumber" required>
          </div>
          <button type="submit">Save</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { updateUser, deleteUserById, fetchProtectedData } from '../api/account';
import '../assets/css/admin.css';

export default {
  name: 'AdminComponent',
  data() {
    return {
      users: [],
      editingUser: null,
    };
  },
  async created() {
    await this.loadUsers();
  },
  methods: {
    async loadUsers() {
      try {
        const response = await fetchProtectedData();
        this.users = response;
      } catch (error) {
        console.error('Error fetching users:', error);
        alert('Failed to fetch user data: ' + (error.response ? error.response.data.message : error.message));
      }
    },
    editUser(user) {
      this.editingUser = { ...user };
    },
    async saveUser() {
      try {
        await updateUser(this.editingUser);
        this.editingUser = null;
        alert('User updated successfully!');
        await this.loadUsers(); // Load lại danh sách người dùng sau khi cập nhật thành công
      } catch (error) {
        console.error('Error saving user:', error);
        alert('Failed to update user: ' + error.message);
      }
    },
    cancelEdit() {
      this.editingUser = null;
    },
    async deleteUser(id) {
      if (confirm('Are you sure you want to delete this user?')) {
        try {
          await deleteUserById(id);
          this.users = this.users.filter(user => user.id !== id);
          alert('User deleted successfully!');
        } catch (error) {
          console.error('Error deleting user:', error);
          alert('Failed to delete user: ' + error.message);
        }
      }
    }
  }
};
</script>

<style scoped>
</style>
