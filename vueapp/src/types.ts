export interface User {
    id: number;
    username: string;
}

export interface LoginResponse {
    id: number;
    username: string;
    token: string;
}

export interface Post {
    id: number;
    content: string;
    createdAt: string;
    updatedAt?: string;
    isCreatedByUser: boolean;
    username: string;
}
