import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import LogoutIcon from "@mui/icons-material/Logout";
import {
	AppBar,
	Box,
	Collapse,
	Container,
	Skeleton,
	Toolbar,
	Typography,
	useScrollTrigger,
} from "@mui/material";
import React from "react";
import { NavLink } from "react-router-dom";
import { authSelectors } from "../../../modules/auth/authSlice";
import { useAppSelector } from "../../redux";
import MainNavigationTabs from "./MainNavigationTabs";

interface Props {
	children?: React.ReactElement<unknown>;
}

function CollapseOnScroll(props: Props) {
	const { children } = props;
	const trigger = useScrollTrigger();

	return <Collapse in={!trigger}>{children ?? <div />}</Collapse>;
}

export default function Header() {
	const isAuthenticated = useAppSelector(authSelectors.selectIsAuthenticated);
	const fetchStatus = useAppSelector(authSelectors.selectAuthFetchStatus);

	return (
		<Box sx={{ flexGrow: 1 }}>
			<AppBar position="fixed">
				<CollapseOnScroll>
					<Toolbar className="m-4">
						<Container className="flex flex-row justify-between items-center">
							<Typography variant="h4" component="div">
								Заявки на отпуск
							</Typography>
							<Box className="flex flex-row justify-between items-center gap-4">
								{fetchStatus === "loading" ? (
									<Skeleton variant="circular" width={40} height={40} />
								) : isAuthenticated ? (
									<Box className="flex flex-row justify-between items-center gap-4">
										<NavLink to="/profile">
											<AccountCircleIcon
												className="hover:text-blue-100"
												sx={{ fontSize: 30 }}
											/>
										</NavLink>
										<NavLink to="/logout">
											<LogoutIcon
												className="hover:text-blue-100"
												sx={{ fontSize: 30 }}
											/>
										</NavLink>
									</Box>
								) : (
									<NavLink to="/login">
										<ExitToAppIcon
											className="hover:text-blue-100"
											sx={{ fontSize: 30 }}
										/>
									</NavLink>
								)}
							</Box>
						</Container>
					</Toolbar>
				</CollapseOnScroll>
				<Toolbar className="bg-white">
					<Container>
						<MainNavigationTabs />
					</Container>
				</Toolbar>
			</AppBar>
			<Toolbar />
			<Toolbar />
		</Box>
	);
}
