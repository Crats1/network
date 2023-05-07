import { Post, PostSortOrders, UserInfo } from "@/types";
import { getToken } from "./token";

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

async function getUserPosts(userId: number, sortOrder?: PostSortOrders): Promise<Post[]> {
    const params = sortOrder
        ? `?${new URLSearchParams({ sortOrder })}`
        : '';
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