import { InjectionKey } from "vue";
import { User } from "./types";
import type { Ref } from "vue";

export interface UserProvider {
    user: Ref<User>;
    updateUser: (newUser: User | undefined) => void;
}

export const userKey = Symbol("user") as InjectionKey<UserProvider>;
