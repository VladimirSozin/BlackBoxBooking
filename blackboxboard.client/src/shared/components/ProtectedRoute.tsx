import { PropsWithChildren } from "react";
import { authSelectors, Role } from "../../modules/auth/authSlice";
import { useAppSelector } from "../redux";

type Props = {
	roles: Role[];
} & PropsWithChildren;

export function ProtectedRoute({ children, roles }: Props) {
	const authStatus = useAppSelector(authSelectors.selectAuthFetchStatus);
	const isAuthenticated = useAppSelector(authSelectors.selectIsAuthenticated);
	const userRoles = useAppSelector(authSelectors.selectCurrentUserRoles);

	if (authStatus === "loading") {
		return <div>Загрузка...</div>;
	}

	const hasAccess =
		isAuthenticated && roles.some((role) => userRoles.includes(role));

	if (!hasAccess) {
		return <div>Доступ запрещен</div>;
	}

	return children;
}
