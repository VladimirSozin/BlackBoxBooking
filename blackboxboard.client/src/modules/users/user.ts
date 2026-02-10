import { Role } from "../auth/authSlice";

export type UserId = string;

export type User = {
	id: UserId;
	email: string;
	roles: Role[];
};
