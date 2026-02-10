import GitHubIcon from "@mui/icons-material/GitHub";
import TelegramIcon from "@mui/icons-material/Telegram";
import { Button, Link, Typography } from "@mui/material";
import { FunctionComponent } from "react";

function Copyright() {
	return (
		<Typography variant="body2" sx={{ color: "text.secondary", mt: 1 }}>
			{"Copyright © "}
			<Link color="text.secondary" href="https://asdjasjdas.com/">
				Дмтрий Жильцов
			</Link>
			&nbsp;
			{new Date().getFullYear()}
		</Typography>
	);
}

const Footer: FunctionComponent = () => {
	return (
		<div className="flex flex-row justify-between items-center">
			<div>
				<Button href="https://1231213.com">
					<GitHubIcon />
				</Button>
				<Button href="https://1231213.com">
					<TelegramIcon />
				</Button>
			</div>
		</div>
	);
};

export default Footer;
