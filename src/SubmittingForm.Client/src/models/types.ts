export interface FormState {
    fullName: string;
    department: string;
    startDate: string;
    workType: 'remote' | 'office';
    agreed: boolean;
}

export interface Submission {
    id: string;
    createdAt: string;
    payload: any;
}