<script setup lang="ts">
import { ref } from 'vue';
import MyForm from './components/mainForm/mainForm.vue';
import MyList from './components/mainForm/dataList.vue';

// Ссылка на компонент списка для обновления (не знаю нормальный ли это подход)
const listRef = ref<InstanceType<typeof MyList> | null>(null);

const onFormSaved = () => {
  listRef.value?.refresh();
};
</script>

<template>
  <div class="app-layout">
    <MyForm :onSaved="onFormSaved" />
    <MyList ref="listRef" />
  </div>
</template>

<style>
.app-layout { display: grid; grid-template-columns: 1fr 1fr; gap: 20px; max-width: 1000px; margin: 0 auto; padding: 20px; }
</style>