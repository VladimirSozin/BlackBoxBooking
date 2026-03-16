import { Navigate } from "react-router-dom";
import { authSelectors } from "../../modules/auth/authSlice";
import { useAppSelector } from "../redux";
import { Box, CircularProgress, Typography } from "@mui/material";

interface Props {
	children: React.ReactNode;
	requiredRoles?: string[]; // Делаем необязательным
}

export function ProtectedRoute({ children, requiredRoles = [] }: Props) {
	const isLoading = useAppSelector(authSelectors.selectIsLoading);
	const isAuthenticated = useAppSelector(authSelectors.selectIsAuthenticated);
	const userRoles = useAppSelector(authSelectors.selectCurrentUserRoles);

	// Показываем загрузку
	if (isLoading) {
		return (
			<Box sx={{
				display: 'flex',
				justifyContent: 'center',
				alignItems: 'center',
				height: '100vh'
			}}>
				<CircularProgress />
			</Box>
		);
	}

	// Если не авторизован - редирект на логин
	if (!isAuthenticated) {
		return <Navigate to="/login" replace />;
	}

	// Проверяем роли, только если они указаны
	const hasRequiredRoles = requiredRoles.length === 0 ||
		requiredRoles.some(role => userRoles.includes(role));

	// Если нет нужной роли
	if (!hasRequiredRoles) {
		return (
			<Box sx={{
				p: 4,
				textAlign: 'center',
				maxWidth: 400,
				mx: 'auto',
				mt: 8
			}}>
				<Typography variant="h6" color="error" gutterBottom>
					Доступ запрещен
				</Typography>
				<Typography color="text.secondary">
					У вас нет прав для просмотра этой страницы
				</Typography>
			</Box>
		);
	}

	// Всё ок - показываем children
	return <>{children}</>;
}