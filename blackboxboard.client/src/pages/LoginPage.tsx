import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import { Alert, Card, Stack } from "@mui/material";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";
import Link from "@mui/material/Link";
import TextField from "@mui/material/TextField";
import Typography from "@mui/material/Typography";
import { SubmitHandler, useForm } from "react-hook-form";
import { authSelectors } from "../modules/auth/authSlice";
import { loginThunk } from "../modules/auth/login/loginThunk";
import { useAppDispatch, useAppSelector } from "../shared/redux";

type LoginFields = {
	email: string;
	password: string;
};

export default function Login() {
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm<LoginFields>();

	const dispatch = useAppDispatch();

	// const fetchStatus = useAppSelector(authSelectors.selectAuthFetchStatus);
	const error = useAppSelector(authSelectors.selectLoginError);

	const onSubmit: SubmitHandler<LoginFields> = async (data) => {
		await dispatch(loginThunk(data));
	};

	return (
		<Box className="flex flex-col gap-y-16">
			<Box>
				<Link href="/" className="flex flex-row items-center gap-2">
					<ArrowBackIcon />
					<Typography>Вернуться на главную</Typography>
				</Link>
			</Box>
			<Box>
				<CssBaseline enableColorScheme />
				<Stack direction="column" justifyContent="space-between">
					<Card
						className="flex flex-col w-full p-10 gap-5 m-auto max-w-lg h-full"
						variant="outlined"
					>
						<Typography
							component="h1"
							className="text-center"
							variant="h4"
							sx={{ width: "100%", fontSize: "clamp(2rem, 10vw, 2.15rem)" }}
						>
							Вход
						</Typography>
						<Box
							onSubmit={handleSubmit(onSubmit)}
							component="form"
							noValidate
							className="flex flex-col w-full gap-2"
						>
							<FormControl>
								<FormLabel htmlFor="email">Email</FormLabel>
								<TextField
									error={!!errors.email}
									helperText={errors.email?.message}
									id="email"
									type="email"
									placeholder="your@email.com"
									autoComplete="email"
									autoFocus
									required
									fullWidth
									variant="outlined"
									{...register("email", {
										required: "Это поле обязательно для заполнения",
										validate: (value) => {
											if (!value || !/\S+@\S+\.\S+/.test(value)) {
												return "Введите корректный email";
											}
										},
									})}
								/>
							</FormControl>
							<FormControl className="mb-4">
								<FormLabel htmlFor="password">Пароль</FormLabel>
								<TextField
									placeholder="••••••••••••"
									type="password"
									id="password"
									autoComplete="current-password"
									autoFocus
									required
									fullWidth
									variant="outlined"
									error={!!errors.password}
									helperText={errors.password?.message}
									{...register("password", {
										required: "Это поле обязательно для заполнения",
										validate: (value) => {
											if (!value || value.length < 6) {
												return "Пароль должен содержать не менее 6 символов";
											}
										},
									})}
								/>
							</FormControl>
							<Button type="submit" fullWidth variant="contained">
								Войти
							</Button>

							{error && (
								<Alert
									sx={{
										width: "100%",
										maxWidth: "400px",
										wordWrap: "break-word",
										whiteSpace: "pre-line",
										alignSelf: "center",
									}}
									variant="outlined"
									severity="error"
								>
									{error}
								</Alert>
							)}
						</Box>
						<Box className="flex flex-col gap-2">
							<Typography className="text-center">
								Ещё не зарегистрированы?{" "}
								<Link href="/registraion" variant="body2" className="text-center">
									Регистрация
								</Link>
							</Typography>
						</Box>
					</Card>
				</Stack>
			</Box>
		</Box>
	);
}
