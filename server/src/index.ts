import * as dotenv from 'dotenv';
dotenv.config();

import "./lib/db";
import express from "express";
import gamesRoutes from "./routes/games";
import gameRoutes from "./routes/game";


const app = express();
const port =  process.env.PORT || 5003;
app.use(express.json());
app.use(express.text({ type: "text/html" }));
app.use("/games", gamesRoutes);
app.use('/game', gameRoutes);

app.listen(port, () => console.log('Server is running on port ' + port));