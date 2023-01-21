import { fetchNflGames } from '$lib/grabber';

export async function load() {
	return {
		gamesPromise: fetchNflGames(),
	};
}
