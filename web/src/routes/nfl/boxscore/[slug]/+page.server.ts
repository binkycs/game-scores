import { fetchNflGame } from '$lib/grabber';
import type { PageServerLoad } from './$types';

export const load = (async ({params}) => {
    return {
        game: await fetchNflGame(params.slug)
    };
}) satisfies PageServerLoad;