import { ref, onMounted } from 'vue';
import type { Submission } from '../../models/types';

export function dataList() {
    const items = ref<Submission[]>([]);
    const search = ref('');
    const isLoading = ref(false);

    const fetchItems = async () => {
        isLoading.value = true;
        try {
            const query = search.value ? `?search=${encodeURIComponent(search.value)}` : '';
            const res = await fetch(`/api/submissions${query}`);
            items.value = await res.json();
        } catch (e) {
            console.error(e);
        } finally {
            isLoading.value = false;
        }
    };

    const onSearchInput = () => {
        fetchItems();
    };

    onMounted(() => fetchItems());

    return { items, search, fetchItems, onSearchInput, isLoading };
}