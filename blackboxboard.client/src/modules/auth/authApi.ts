import { baseApi } from "../../shared/api/baseApi";
import { Envelope } from "../../shared/models/Envelope";
import { Role } from "./authSlice";

export type LoginResponse = {
	accessToken: string;
	userId: string;
	roles: Role[];
};

export const authApi = baseApi.injectEndpoints({
	endpoints: (builder) => ({
		login: builder.mutation<LoginResponse, { email: string; password: string }>(
			{
				query: ({ email, password }) => ({
					url: "/accounts/login",
					body: { email, password },
					method: "post",
				}),
				transformResponse: (res: Envelope<LoginResponse>) => {
					return res.result!;
				},
			}
		),
		refreshToken: builder.mutation<LoginResponse, void>({
			query: () => ({
				url: "/accounts/refresh",
				method: "POST",
			}),
			transformResponse: (res: Envelope<LoginResponse>) => res.result!,
		}),
		logout: builder.mutation<void, void>({
			query: () => ({ url: "/accounts/logout", method: "POST" }),
		}),
	}),
});

export const { useLoginMutation, useRefreshTokenMutation } = authApi;
