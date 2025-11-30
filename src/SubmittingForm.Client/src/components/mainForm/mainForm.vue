<script setup lang="ts">
import { mainForm } from '../../components/mainForm/mainForm';

const props = defineProps<{ onSaved: () => void }>();

const { form, errors, submit, isSubmitting } = mainForm(props.onSaved);
</script>

<template>
  <div class="form-card">
    <h3>New Entry</h3>
    <form @submit.prevent="submit">
      <label>
        Full Name:
        <input v-model="form.fullName" type="text" :class="{invalid: errors.fullName}"/>
        <span class="validate-err">{{ errors.fullName }}</span>
      </label>

      <label>
        Dept:
        <select v-model="form.department">
          <option value="" disabled>Select...</option>
          <option value="IT">IT</option>
          <option value="HR">HR</option>
        </select>
        <span class="validate-err">{{ errors.department }}</span>
      </label>

      <label>
        Start Date:
        <input v-model="form.startDate" type="date" />
        <span class="validate-err">{{ errors.startDate }}</span>
      </label>

      <div class="row">
        Work Type:
        <label><input type="radio" value="remote" v-model="form.workType">Remote</label>
        <label><input type="radio" value="office" v-model="form.workType">Office</label>
      </div>

      <label class="row">
        <input type="checkbox" v-model="form.agreed">
        I agree to terms
      </label>

      <button :disabled="isSubmitting">
        {{ isSubmitting ? 'Sending...' : 'Submit' }}
      </button>
    </form>
  </div>
</template>

<style scoped>
.form-card { padding: 20px; border: 1px solid #ccc; }
label { display: block; margin-bottom: 10px; }
.validate-err { color: red; font-size: 0.8em; display: block; }
.invalid { border-color: red; }
.row { display: flex; gap: 10px; align-items: center; }
</style>