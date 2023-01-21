import { MongoClient } from "mongodb";

const mongoUri = process.env.MONGODB_URI;
if (!mongoUri) throw new Error('❌ please add MONGODB_URI to your environment variables');

let client = new MongoClient(mongoUri);
if (!client) throw new Error('❌ failed to connect to mongodb');

const _db = client.db('scores');
if (!_db) throw new Error('❌ failed to connect to database');

console.log('✅ connected to mongodb');

export function getDb(db: string) {
  return client.db(db);
}