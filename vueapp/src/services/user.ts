import { Post } from "@/types";
import { getToken } from "./token";

const URL = `/api/user`;

async function getUserPosts(): Promise<Post[]> {
    return await (await fetch(URL, {
        headers: {
            "Authorization": getToken(),
        },
    })).json()
}

export default {
    getUserPosts,
};