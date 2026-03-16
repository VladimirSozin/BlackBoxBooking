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
import { useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../shared/redux";
import { loginThunk } from "../modules/auth/login/loginThunk";
import { authSelectors } from "../modules/auth/authSlice";
import { useState } from "react";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { IconButton, InputAdornment } from "@mui/material";

type LoginFields = {
    email: string;
    password: string;
};

export default function LoginPage() {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<LoginFields>();

    const [showPassword, setShowPassword] = useState(false);
    const navigate = useNavigate();
    const dispatch = useAppDispatch();

    const isLoading = useAppSelector(authSelectors.selectIsLoading);
    const error = useAppSelector(authSelectors.selectError);

    const handleClickShowPassword = () => setShowPassword((show) => !show);

    const onSubmit: SubmitHandler<LoginFields> = async (data, event) => {
        event?.preventDefault(); // ОСТАНАВЛИВАЕМ ПЕРЕЗАГРУЗКУ СТРАНИЦЫ
        try {
            const result = await dispatch(loginThunk(data)).unwrap();
            console.log('Login successful:', result);
            navigate('/');
        } catch (err) {
            console.error('Login failed:', err);
            // Ошибка уже в Redux, ничего не делаем
        }
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
                        >
                            Вход в систему
                        </Typography>

                        {/* ВАЖНО: onSubmit теперь с event параметром */}
                        <Box
                            component="form"
                            onSubmit={handleSubmit(onSubmit)}
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
                                    disabled={isLoading}
                                    {...register("email", {
                                        required: "Это поле обязательно",
                                        pattern: {
                                            value: /\S+@\S+\.\S+/,
                                            message: "Введите корректный email",
                                        },
                                    })}
                                />
                            </FormControl>

                            <FormControl className="mb-4">
                                <FormLabel htmlFor="password">Пароль</FormLabel>
                                <TextField
                                    placeholder="••••••••••••"
                                    type={showPassword ? "text" : "password"}
                                    id="password"
                                    autoComplete="current-password"
                                    required
                                    fullWidth
                                    variant="outlined"
                                    error={!!errors.password}
                                    helperText={errors.password?.message}
                                    disabled={isLoading}
                                    InputProps={{
                                        endAdornment: (
                                            <InputAdornment position="end">
                                                <IconButton
                                                    aria-label="toggle password visibility"
                                                    onClick={handleClickShowPassword}
                                                    edge="end"
                                                >
                                                    {showPassword ? <VisibilityOff /> : <Visibility />}
                                                </IconButton>
                                            </InputAdornment>
                                        ),
                                    }}
                                    {...register("password", {
                                        required: "Это поле обязательно",
                                        minLength: {
                                            value: 6,
                                            message: "Минимум 6 символов",
                                        },
                                    })}
                                />
                            </FormControl>

                            <Button
                                type="submit"
                                fullWidth
                                variant="contained"
                                disabled={isLoading}
                                size="large"
                            >
                                {isLoading ? "Вход..." : "Войти"}
                            </Button>

                            {/* Ошибка отображается, но страница не перезагружается */}
                            {error && (
                                <Alert severity="error" sx={{ mt: 2 }}>
                                    {error}
                                </Alert>
                            )}
                        </Box>

                        <Box className="flex flex-col gap-2 mt-4">
                            <Typography className="text-center">
                                Нет аккаунта?{" "}
                                <Link href="/registration" variant="body2">
                                    Зарегистрироваться
                                </Link>
                            </Typography>
                        </Box>
                    </Card>
                </Stack>
            </Box>
        </Box>
    );
}