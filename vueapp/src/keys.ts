import { InjectionKey } from "vue";
import { User } from "./types";
import type { Ref } from "vue";

export interface UserProvider {
    user: Ref<User | null>;
    updateUser: (newUser: User) => void;
    clearUser: () => void;
}

export const userKey = Symbol("user") as InjectionKey<UserProvider>;
