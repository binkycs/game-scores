import { getTodaysDateString } from '$lib/helper';
import type { BasketballGame } from './basketball/basketballgame';
import type { FootballGame } from './football/footballgame';
import { dev } from '$app/environment';

const url = dev ? 'http://192.168.1.109:5003' : 'https://scores-node-production.up.railway.app';

export async function fetchNbaGames(): Promise<BasketballGame[]> {
	return fetchGames('nba');
}

export async function fetchNbaGame(id: string): Promise<BasketballGame> {
	return fetchGame('nba', id);
}

export async function fetchNflGames(): Promise<FootballGame[]> {
	return fetchGames('nfl');
}
export async function fetchNflGame(id: string): Promise<FootballGame> {
	return fetchGame('nfl', id);
}

export async function fetchNcaafGames(): Promise<FootballGame[]> {
	return fetchGames('ncaaf');
}

export async function fetchNcaabGames(): Promise<BasketballGame[]> {
	return fetchGames('ncaab');
}

async function fetchGames(sport: string) {
	const date = dev ? '2023-01-15' : getTodaysDateString();
	const response = await fetch(`${url}/games/${sport}/${date}`);
	return response.json();
}

async function fetchGame(sport: string, id: string) {
	const response = await fetch(`${url}/game/${sport}/${id}`);
	return response.json();
}
