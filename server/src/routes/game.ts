import { Router } from "express";
import * as mongo from "../lib/db";
import requestIp from 'request-ip';

const routes = Router();

routes.get("/:sport/:id", async (request, response) => {
  console.log(`[GAME] [${request.params.sport.toUpperCase()}] [${request.params.id}] from: [${requestIp.getClientIp(request)}]`);

  let db = mongo.getDb("scores");
  let collection = db.collection(`${request.params.sport}.scores`);
  let filter = { $or: [ {"Game.GlobalGameID": Number(request.params.id) }, {"Score.GlobalGameID": Number(request.params.id)}]};
  collection.findOne(filter).then((value) => {
    response.json(value);
  }, (error) => {
    throw error;
  });
});

export default routes;
