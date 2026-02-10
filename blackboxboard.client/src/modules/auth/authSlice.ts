import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { UserId } from "../users/user";
import { loginCases } from "./login/loginThunk";
import { logOutCases } from "./login/logOutThunk";
import { refreshTokenCases } from "./refreshTokenThunk";

export type Role = "admin" | "participant" | "volunteer";

export type AuthState = {
	accessToken: string | undefined;
	userId: UserId | undefined;
	roles: Role[];
	isAuthenticated: boolean;
	fetchStatus: "idle" | "loading" | "succeeded" | "failed";
	loginError: string | undefined;
	registrationError: string | undefined;
};

const initialAuthState: AuthState = {
	accessToken: undefined,
	roles: [],
	userId: undefined,
	isAuthenticated: false,
	fetchStatus: "idle",
	loginError: undefined,
	registrationError: undefined,
};

export const authSlice = createSlice({
	name: "auth",
	initialState: initialAuthState,
	selectors: {
		selectAccessToken: (state) => state.accessToken,
		selectIsAuthenticated: (state) => state.isAuthenticated,
		selectCurrentUserId: (state) => state.userId,
		selectCurrentUserRoles: (state) => state.roles,
		selectAuthFetchStatus: (state) => state.fetchStatus,
		selectLoginError: (state) => state.loginError,
		selectRegistrationError: (state) => state.registrationError,
	},
	reducers: {
		tokenReceived: (
			state,
			{
				payload,
			}: PayloadAction<{
				accessToken: string;
				userId: UserId;
				roles: Role[];
			}>
		) => {
			state.accessToken = payload.accessToken;
			state.userId = payload.userId;
			state.roles = payload.roles;
			state.isAuthenticated = true;
			state.fetchStatus = "succeeded";
		},
		logOut: (state) => {
			state.accessToken = undefined;
			state.fetchStatus = "idle";
			state.isAuthenticated = false;
			state.userId = undefined;
		},
	},
	extraReducers: (builder) => {
		loginCases(builder);
		logOutCases(builder);
		refreshTokenCases(builder);
	},
});

export const authActions = authSlice.actions;

export const authSelectors = authSlice.selectors;

export default authSlice.reducer;
