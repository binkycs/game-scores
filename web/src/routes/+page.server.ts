import { fetchNflGames, fetchNbaGames, fetchNcaafGames, fetchNcaabGames } from '$lib/grabber';

export async function load() {
	return {
		nflPromise: fetchNflGames(),
		nbaPromise: fetchNbaGames(),
		ncaafPromise: fetchNcaafGames(),
		ncaabPromise: fetchNcaabGames(),
	};
}
