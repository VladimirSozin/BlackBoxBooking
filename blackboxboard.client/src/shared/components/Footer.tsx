import GitHubIcon from "@mui/icons-material/GitHub";
import TelegramIcon from "@mui/icons-material/Telegram";
import { Box, Container, IconButton, Typography, Link, alpha } from "@mui/material";
import { FunctionComponent } from "react";

const Footer: FunctionComponent = () => {
	return (
		<Box
			component="footer"
			sx={{
				py: 3,
				mt: 'auto',
				borderTop: '1px solid',
				borderColor: alpha('#000', 0.08),
				bgcolor: 'background.paper',
			}}
		>
			<Container maxWidth="xl">
				<Box sx={{
					display: 'flex',
					flexDirection: { xs: 'column', sm: 'row' },
					justifyContent: 'space-between',
					alignItems: 'center',
					gap: 2,
				}}>
					<Box sx={{ display: 'flex', gap: 1 }}>
						<IconButton
							href="https://github.com"
							target="_blank"
							size="small"
							sx={{
								color: 'text.secondary',
								'&:hover': {
									color: 'text.primary',
									bgcolor: alpha('#000', 0.04),
								}
							}}
						>
							<GitHubIcon fontSize="small" />
						</IconButton>
						<IconButton
							href="https://t.me"
							target="_blank"
							size="small"
							sx={{
								color: 'text.secondary',
								'&:hover': {
									color: 'text.primary',
									bgcolor: alpha('#000', 0.04),
								}
							}}
						>
							<TelegramIcon fontSize="small" />
						</IconButton>
					</Box>

					<Typography variant="body2" color="text.secondary">
						© {new Date().getFullYear()}{' '}
						<Link
							href="https://example.com"
							color="inherit"
							sx={{
								textDecoration: 'none',
								'&:hover': {
									textDecoration: 'underline',
								}
							}}
						>
							Дмитрий Жильцов
						</Link>
					</Typography>
				</Box>
			</Container>
		</Box>
	);
};

export default Footer;