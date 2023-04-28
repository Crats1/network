import { Post } from "@/types";

const URL = `/api/post/`;

async function getAllPosts(): Promise<Post[]> {
    return await (await fetch(URL)).json()
}

async function createPost(content: string): Promise<Post> {
    const result = await fetch(URL, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ content, userId: 1 }),
    });
    console.log('createPost result:', result);
    return result.json();
}

async function updatePost(newContent: string): Promise<unknown> {
    const result = await fetch(URL, {
        method: 'PUT',
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ newContent })
    });
    console.log('updatePost result:', result);
    return result.json();
}

async function likePost(postId: number): Promise<unknown> {
    const result = await fetch(`URL${postId}`, {
        method: 'PUT',
    });
    console.log('likePost result:', result);
    return result.json();
}

export default {
    getAllPosts,
    createPost,
    updatePost,
    likePost,
};