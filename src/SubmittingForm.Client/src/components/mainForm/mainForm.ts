import { reactive, ref } from 'vue';
import type { FormState } from '../../models/types';

export function mainForm(onSubmitSuccess: () => void) {
    const form = reactive<FormState>({
        fullName: '',
        department: '',
        startDate: '',
        workType: 'remote',
        agreed: false
    });

    const errors = reactive<Record<string, string>>({});
    const isSubmitting = ref(false);

    const validate = (): boolean => {
        Object.keys(errors).forEach(key => delete errors[key]);
        
        let isValid = true;
        if (!form.fullName) { errors.fullName = 'Name required'; isValid = false; }
        if (!form.department) { errors.department = 'Select department'; isValid = false; }
        if (!form.startDate) { errors.startDate = 'Date required'; isValid = false; }
        
        return isValid;
    };

    const submit = async () => {
        if (!validate()) return;
        
        isSubmitting.value = true;
        try {
            const res = await fetch('/api/submissions', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(form)
            });

            if (res.ok) {
                form.fullName = '';
                form.department = '';
                form.startDate = '';
                form.agreed = false;
                onSubmitSuccess();
            }
        } catch (e) {
            alert('Network error'); //TODO: Заменить на popup уведомления
        } finally {
            isSubmitting.value = false;
        }
    };

    return { form, errors, submit, isSubmitting };
}