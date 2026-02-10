import { ActionReducerMapBuilder } from "@reduxjs/toolkit";
import { FetchBaseQueryError } from "@reduxjs/toolkit/query";
import { createAppAsyncThunk } from "../../../shared/redux";
import { getErrorMessage } from "../../../shared/utils/getErrorMessage";
import { authApi } from "../authApi";
import { AuthState } from "../authSlice";

export const logOutThunk = createAppAsyncThunk<void, void>(
	"auth/logout",
	async (_, { dispatch, rejectWithValue, extra }) => {
		try {
			await dispatch(authApi.endpoints.logout.initiate()).unwrap();

			extra.router.navigate("/");
		} catch (error) {
			const errorMessage = getErrorMessage(
				error as FetchBaseQueryError | undefined
			);
			return rejectWithValue(errorMessage);
		}
	}
);

export const logOutCases = (builder: ActionReducerMapBuilder<AuthState>) => {
	builder
		.addCase(logOutThunk.pending, (state) => {
			state.fetchStatus = "loading";
			state.loginError = undefined;
		})
		.addCase(logOutThunk.fulfilled, (state) => {
			state.accessToken = undefined;
			state.userId = undefined;
			state.roles = [];
			state.isAuthenticated = false;
			state.fetchStatus = "succeeded";
			state.loginError = undefined;
		})
		.addCase(logOutThunk.rejected, (state, action) => {
			state.fetchStatus = "failed";
			state.loginError = action.payload || "Неизвестная ошибка";
		});
};
