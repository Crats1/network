import { PaginatedList, Post, PostSortOrders, UserInfo } from "@/types";
import { getToken } from "./token";
import postsService from './posts';

const URL = `/api/user`;

async function getMe(): Promise<UserInfo> {
    const result = await fetch(`${URL}/me`, {
        headers: {
            "Authorization": getToken(),
        },
    })
    return result.json();
}

async function getUserInfo(userId: number): Promise<UserInfo> {
    const result = await fetch(`${URL}/${userId}`, {
        headers: {
            "Authorization": getToken(),
        },
    });
    return result.json();
}

async function getUserPosts(userId: number, sortOrder?: PostSortOrders, limit?: number, offset?: number): Promise<PaginatedList<Post>> {
    const params = postsService.getParams({ sortOrder, limit, offset });
    const result = await fetch(`${URL}/${userId}/posts${params}`, {
        headers: {
            "Authorization": getToken(),
        },
    });
    return result.json();
}

async function followUser(userId: number): Promise<void> {
    await fetch(`${URL}/${userId}/follow`, {
        method: "POST",
        headers: {
            "Authorization": getToken(),
        },
    });
}

async function unfollowUser(userId: number): Promise<void> {
    await fetch(`${URL}/${userId}/follow`, {
        method: "DELETE",
        headers: {
            "Authorization": getToken(),
        },
    });
}

export default {
    getMe,
    getUserInfo,
    getUserPosts,
    followUser,
    unfollowUser,
};