import { createContext, useEffect } from "react";
import { authSelectors } from "../../modules/auth/authSlice";
import { refreshTokenThunk } from "../../modules/auth/refreshTokenThunk";
import { useAppDispatch, useAppSelector } from "../redux";

export const AuthContext = createContext<
	{ accessToken: string | undefined } | undefined
>(undefined);

type Props = { children: React.ReactNode };

export const AuthProvider = ({ children }: Props) => {
	const token = useAppSelector(authSelectors.selectAccessToken);
	const dispatch = useAppDispatch();

	useEffect(() => {
		if (!token) dispatch(refreshTokenThunk());
	});

	return (
		<AuthContext.Provider value={{ accessToken: token }}>
			{children}
		</AuthContext.Provider>
	);
};
