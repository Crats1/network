export interface User {
    username: string;
}

export interface Post {
    id: number;
    content: string;
    createdAt: Date;
    updatedAt?: Date;
    userID: number;
}
