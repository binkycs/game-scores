import { Router } from "express";
import * as mongo from "../lib/db";
import requestIp from 'request-ip';

const routes = Router();

routes.get("/:sport/:date", async (request, response) => {
  console.log(`[GAMES] [${request.params.sport.toUpperCase()}] [${request.params.date}] from: [${requestIp.getClientIp(request)}]`);

  let db = mongo.getDb("scores");
  let collection = db.collection(`${request.params.sport}.scores`);
  let date = new Date(request.params.date + 'T05:00:00.000+00:00');
  let filter = { $or: [ {"Game.Day": date }, {"Score.Day": date}]};
  collection.find(filter).toArray().then((value) => {
    response.json(value);
  }, (error) => {
    throw error;
  });
});

export default routes;
