import { FetchBaseQueryError } from "@reduxjs/toolkit/query/react";
import { ActionReducerMapBuilder } from "@reduxjs/toolkit/react";
import { createAppAsyncThunk } from "../../../shared/redux";
import { getErrorMessage } from "../../../shared/utils/getErrorMessage";
import { authApi, LoginResponse } from "../authApi";
import { AuthState } from "../authSlice";

export const loginThunk = createAppAsyncThunk<
	LoginResponse,
	{ email: string; password: string }
>("auth/login", async (reqeust, { dispatch, rejectWithValue, extra }) => {
	try {
		const response = await dispatch(
			authApi.endpoints.login.initiate(reqeust)
		).unwrap();

		extra.router.navigate("/profile");

		return response;
	} catch (error) {
		const errorMessage = getErrorMessage(
			error as FetchBaseQueryError | undefined
		);
		return rejectWithValue(errorMessage);
	}
});

export const loginCases = (builder: ActionReducerMapBuilder<AuthState>) => {
	builder
		.addCase(loginThunk.pending, (state) => {
			state.fetchStatus = "loading";
			state.loginError = undefined;
		})
		.addCase(loginThunk.fulfilled, (state, { payload }) => {
			state.accessToken = payload.accessToken;
			state.userId = payload.userId;
			state.roles = payload.roles;
			state.isAuthenticated = true;
			state.fetchStatus = "succeeded";
			state.loginError = undefined;
		})
		.addCase(loginThunk.rejected, (state, action) => {
			state.fetchStatus = "failed";
			state.loginError = action.payload;
		});
};
