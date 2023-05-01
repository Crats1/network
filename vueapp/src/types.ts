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
    createdAt: Date;
    updatedAt?: Date;
    username: string;
}
