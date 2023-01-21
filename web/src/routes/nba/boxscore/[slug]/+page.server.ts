import { fetchNbaGame } from '$lib/grabber';
import type { PageServerLoad } from './$types';

export const load = (async ({params}) => {
    return {
        game: await fetchNbaGame(params.slug)
    };
}) satisfies PageServerLoad;