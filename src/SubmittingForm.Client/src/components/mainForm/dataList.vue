<script setup lang="ts">
import { dataList } from '../../components/mainForm/dataList';

const { items, search, onSearchInput, fetchItems } = dataList();

defineExpose({ refresh: fetchItems });
</script>

<template>
  <div class="list-card">
    <h3>Data List</h3>
    <input 
      v-model="search" 
      @input="onSearchInput" 
      placeholder="Type to search..." 
      class="search-box"
    />
    
    <div v-if="items.length === 0">No records.</div>
    
    <ul class="list">
      <li v-for="item in items" :key="item.id">
        <div>Full name: {{ item.payload.fullName }}</div>
        <div>Department: {{ item.payload.department }}</div>
        <div>StartDate: {{ item.payload.startDate}}</div>
        <div>WorkType: {{ item.payload.workType }}</div>
        <div>agreed: {{ item.payload.agreed }}</div>
      </li>
    </ul>
  </div>
</template>

<style scoped>
.list-card { padding: 20px; background: #f9f9f9; }
.search-box { width: 100%; padding: 8px; margin-bottom: 15px; }
.list { list-style: none; padding: 0; }
li { background: white; border: 1px solid #eee; margin-bottom: 5px; padding: 10px; }
pre { margin: 0; font-size: 0.8em; color: #555; }
</style>