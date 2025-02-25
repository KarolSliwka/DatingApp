export interface User {
    username: string;
    token: string;
}
// to make them optional '?' at the end of property name
// export type User = { username: string; token: string; }
// interfaces doesn't have to have I in the begining like in C#