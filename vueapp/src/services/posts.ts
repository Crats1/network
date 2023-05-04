import { Post, UserLikesPosts } from "@/types";
import { getToken } from "./token";

const URL = `/api/post`;

async function getAllPosts(): Promise<Post[]> {
    return await (await fetch(URL, {
        headers: {
            "Authorization": getToken(),
        },
    })).json()
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
    getAllPosts,
    createPost,
    updatePost,
    getPostLikes,
    likePost,
    unlikePost,
};