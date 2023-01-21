import { fetchNcaabGames } from '$lib/grabber';

export async function load() {
	return {
		gamesPromise: fetchNcaabGames(),
	};
}
