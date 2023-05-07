export interface User {
    id: number;
    userName: string;
}

export interface UserInfo extends User {
    followerCount: number;
    followingCount: number;
    isFollowing: boolean;
}

export interface LoginResponse {
    id: number;
    userName: string;
    token: string;
}

export interface UserLikesPosts {
    userId: number;
    postId: number;
    isLiked: boolean;
}

export interface Post {
    id: number;
    content: string;
    createdAt: string;
    updatedAt?: string;
    isCreatedByUser: boolean;
    userId: number;
    username: string;
    isLikedByUser: boolean;
    likes: number;
}

export enum PostSortOrders {
    LIKES_ASC = "likes_asc",
    LIKES_DESC = "likes_desc",
    DATE_ASC = "date_asc",
    DATE_DESC = "date_desc",
}