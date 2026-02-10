import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import { Box, Fab, Table, TableContainer, TableHead, TableRow, TableCell, TableBody } from "@mui/material";

import { FunctionComponent } from "react";
import ScrollTop from "../shared/components/ScrollTop";
import Paper from '@mui/material/Paper';

function createData(
	name: string,
	vacationStart: string,
	vacationEnd: string,
	status: string,
) {
	return { name, vacationStart, vacationEnd, status };
}

const rows = [
	createData('Иван Иванов Иванович', "2025-01-01", "2025-01-15", "Ожидает подтверждения"),
	createData('Иван Иванов Иванович', "2025-02-01", "2025-02-15", "Ожидает подтверждения"),
	createData('Иван Иванов Иванович', "2025-03-01", "2025-03-15", "Ожидает подтверждения"),
	createData('Иван Иванов Иванович', "2025-04-01", "2025-04-15", "Ожидает подтверждения"),
	createData('Иван Иванов Иванович', "2025-05-01", "2025-05-15", "Ожидает подтверждения"),
];

const MainPage: FunctionComponent = () => {
	return (
		<Box className="flex">
			<Box className="flex flex-col gap-10 items-center w-full ml-10">
				<Box>
					<TableContainer component={Paper}>
						<Table sx={{ minWidth: 1550 }} aria-label="simple table">
							<TableHead>
								<TableRow>
									<TableCell>Сотрудник</TableCell>
									<TableCell align="right">Дата начала отпуска</TableCell>
									<TableCell align="right">Дата окончания отпуска</TableCell>
									<TableCell align="right">Статус</TableCell>
								</TableRow>
							</TableHead>
							<TableBody>
								{rows.map((row) => (
									<TableRow
										key={row.name}
										sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
									>
										<TableCell component="th" scope="row">
											{row.name}
										</TableCell>
										<TableCell align="right">{row.vacationStart}</TableCell>
										<TableCell align="right">{row.vacationEnd}</TableCell>
										<TableCell align="right">{row.status}</TableCell>
									</TableRow>
								))}
							</TableBody>
						</Table>
					</TableContainer>
				</Box>
				<ScrollTop>
					<Fab
						className="bottom-10 right-5"
						size="small"
						aria-label="scroll back to top"
					>
						<KeyboardArrowUpIcon />
					</Fab>
				</ScrollTop>
			</Box>
		</Box>
	);
};

export default MainPage;
