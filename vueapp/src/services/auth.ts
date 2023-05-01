import { LoginResponse } from "@/types";

const URL = `/auth`;

async function Login(username: string, password: string): Promise<LoginResponse> {
    const result = await fetch(`${URL}/login`, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
    });
    console.log('login result:', result);
    return result.json();
}

async function Register(username: string, password: string): Promise<unknown> {
    const result = await fetch(`${URL}/register`, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
    });
    console.log('login result:', result);
    return result.json();
}

export default {
    Login,
    Register,
};
