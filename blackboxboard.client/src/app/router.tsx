import { createBrowserRouter } from "react-router-dom";
import MainPage from "../pages/MainPage";
import RegistrationPage from "../pages/RegistrationPage";
import RootLayout from "./RootLayout";
import LoginPage from "../pages/LoginPage";

export const router = createBrowserRouter([
	{
		path: "/",
		element: <RootLayout />,
		children: [
			{
				path: "/",
				element: <MainPage />,
			},
			{
				path: "/login",
				element: <LoginPage />,
			},
			{
				path: "/registration",
				element: <RegistrationPage />,
			}
		],
	},
]);
