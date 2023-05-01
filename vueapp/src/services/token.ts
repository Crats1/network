const TOKEN_NAME = "access_token";

export function addToken(token: string): void {
   localStorage.setItem(TOKEN_NAME, `Bearer ${token}`);
}

export function getToken(): string {
    return localStorage.getItem(TOKEN_NAME) ?? "";
}

export function isAuthenticated(): boolean {
    return localStorage.getItem(TOKEN_NAME) !== null;
}

export function removeToken(): void {
    localStorage.removeItem(TOKEN_NAME);
}
