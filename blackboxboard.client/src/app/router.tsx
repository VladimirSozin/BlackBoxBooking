import { createBrowserRouter } from "react-router-dom";
import Login from "../pages/LoginPage";
import MainPage from "../pages/MainPage";
import RegistrationPage from "../pages/RegistrationPage";
import RootLayout from "./RootLayout";

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
				element: <Login />,
			},
			{
				path: "/registraion",
				element: <RegistrationPage />,
			}
		],
	},
]);
