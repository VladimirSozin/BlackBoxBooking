import { Container, Toolbar } from "@mui/material";
import { Outlet } from "react-router-dom";
import Footer from "../shared/components/Footer";
import Header from "../shared/components/Header/Header";

export default function RootLayout() {
	return (
		<div className="flex flex-col h-screen min-h-screen gap-1">
			<Header />
			<Container maxWidth="lg" className="flex-grow my-2 py-0">
				<Toolbar id="back-to-top-anchor" />
				<Outlet />
			</Container>
			<Footer />
		</div>
	);
}
