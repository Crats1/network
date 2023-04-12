export interface User {
    username: string;
}

export interface Post {
    author: string;
    content: string;
    postDate: Date;
    likes: number;
}
