import {DateTime} from 'luxon';

export function getTodaysDateString() {
	const now = DateTime.now().setZone('Pacific/Honolulu');
	return now.toISODate();
}

export function getAbbreviatedName(player: string | undefined) {
    if (!player) return '';
    const split = player.split(' ');
    const firstName = split[0][0];
    const lastName = split.slice(1).join(' ');
    return `${firstName}. ${lastName}`;
}