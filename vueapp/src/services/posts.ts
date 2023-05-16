import { PaginatedList, Post, UserLikesPosts } from "@/types";
import { getToken } from "./token";

const URL = `/api/post`;

function getParams(args: Record<string, string | number | undefined>): string {
    const definedArgkeys = Object.keys(args).filter((key) => args[key] !== undefined);
    const definedArgs = definedArgkeys.reduce((acc, key) => ({ ...acc, [key]: args[key] as string }), {});
    return args
        ? `?${new URLSearchParams(definedArgs)}`
        : '';
}

async function getAllPosts(sortOrder?: string, limit?: number, offset?: number): Promise<PaginatedList<Post>> {
    const result = await fetch(`${URL}${getParams({ sortOrder, limit, offset })}`, {
        headers: {
            "Authorization": getToken(),
        },
    });
    return result.json();
}

async function getFollowedUsersPosts(sortOrder?: string, limit?: number, offset?: number): Promise<PaginatedList<Post>> {
    const result = await fetch(`${URL}/followed${getParams({ sortOrder, limit, offset })}`, {
        headers: {
            "Authorization": getToken(),
        },
    });
    return result.json();
}

async function createPost(content: string): Promise<Post> {
    const result = await fetch(URL, {
        method: "POST",
        headers: {
            "Authorization": getToken(),
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ content, userId: 1 }),
    });
    console.log('createPost result:', result);
    return result.json();
}

async function updatePost(postId: number, content: string): Promise<Post> {
    const result = await fetch(`${URL}/${postId}`, {
        method: 'PUT',
        headers: {
            "Authorization": getToken(),
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ content })
    });
    console.log('updatePost result:', result);
    return result.json();
}

async function getPostLikes(postId: number): Promise<UserLikesPosts[]> {
    const result = await fetch(`${URL}/${postId}/likes`, {
        method: 'GET',
        headers: {
            "Authorization": getToken(),
        },
    });
    console.log('getPostLIkes result:', result);
    return result.json();
}

async function likePost(postId: number): Promise<number> {
    const result = await fetch(`${URL}/${postId}/likes`, {
        method: 'POST',
        headers: {
            "Authorization": getToken(),
        },
    });
    console.log('likePost result:', result);
    return result.json();
}

async function unlikePost(postId: number): Promise<number> {
    const result = await fetch(`${URL}/${postId}/likes`, {
        method: 'DELETE',
        headers: {
            "Authorization": getToken(),
        },
    });
    console.log('deletePost result:', result);
    return result.json();
}


export default {
    getParams,
    getAllPosts,
    getFollowedUsersPosts,
    createPost,
    updatePost,
    getPostLikes,
    likePost,
    unlikePost,
};