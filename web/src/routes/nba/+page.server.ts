import { fetchNbaGames } from '$lib/grabber';

export async function load() {
	return {
		gamesPromise: fetchNbaGames(),
	};
}
