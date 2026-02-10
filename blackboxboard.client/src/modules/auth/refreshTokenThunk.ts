import { ActionReducerMapBuilder } from "@reduxjs/toolkit";
import { FetchBaseQueryError } from "@reduxjs/toolkit/query";
import { AppState, createAppAsyncThunk } from "../../shared/redux";
import { getErrorMessage } from "../../shared/utils/getErrorMessage";
import { authApi, LoginResponse } from "./authApi";
import { AuthState } from "./authSlice";

export const refreshTokenThunk = createAppAsyncThunk<
	LoginResponse,
	void,
	{ state: AppState }
>("auth/refresh", async (_, { dispatch, rejectWithValue }) => {
	try {
		const response = await dispatch(
			authApi.endpoints.refreshToken.initiate()
		).unwrap();

		return response;
	} catch (error) {
		const errorMessage = getErrorMessage(
			error as FetchBaseQueryError | undefined
		);
		return rejectWithValue(errorMessage);
	}
});

export const refreshTokenCases = (
	builder: ActionReducerMapBuilder<AuthState>
) => {
	builder
		.addCase(refreshTokenThunk.pending, (state) => {
			state.fetchStatus = "loading";
		})
		.addCase(refreshTokenThunk.fulfilled, (state, { payload }) => {
			state.accessToken = payload.accessToken;
			state.userId = payload.userId;
			state.roles = payload.roles;
			state.isAuthenticated = true;
			state.fetchStatus = "succeeded";
		})
		.addCase(refreshTokenThunk.rejected, (state) => {
			state.accessToken = undefined;
			state.userId = undefined;
			state.isAuthenticated = false;
			state.fetchStatus = "idle";
		});
};
