import type { Game, PlayerGame, Team } from "./basketballgame";
import { DateTime } from 'luxon';

export function getQuarterOrTime(game: Game) {
	if (game.Status == "Scheduled")
		return DateTime.fromISO(game.DateTime).toFormat('t');
	if (game.IsClosed)
		return 'Final';

	switch (game.Quarter) {
		case '1':	return '1st';
		case '2':	return '2nd';
		case 'Half': return 'Half';
		case '3':	return '3rd';
		case '4':	return '4th';
		case 'OT': return 'OT';
		case 'F': return 'Final';
	}
	return 'N/A'
}

function pad2(num: number) {
	return (num < 10 ? '0' : '') + num;
}

export function getTimeRemaining(game: Game) {
	if (game.TimeRemainingMinutes && game.TimeRemainingSeconds) {
		return `${pad2(game.TimeRemainingMinutes)}:${pad2(game.TimeRemainingSeconds)}`;
	}
}

export function getHighestScoringPlayer(playerGames: PlayerGame[], team: Team) {
	const teamName = team.Key;
	let highestPlayer;
	for (const player of playerGames) {
		if (!highestPlayer && player.Team == teamName) {
			highestPlayer = player;
		}
		else if (highestPlayer && player.Team === teamName && Number(highestPlayer.Points) < Number(player.Points)) {
			highestPlayer = player;
		}
	}
	return highestPlayer;
}

export function getStatLine(player: PlayerGame | undefined) {
	if (!player) return;
	const stats = [
		player.Points,
		player.Rebounds,
		player.Assists,
		player.Steals,
		player.BlockedShots
	];
	const statsNames = [
		'PTS',
		'REB',
		'AST',
		'STL',
		'BLK'
	];

	let indices = findIndicesOfMax(stats, 3);
	let statLine = '';

	for (const index of indices)
		if (stats[index] > 0)
			statLine += `${stats[index]} ${statsNames[index]}, `;

	return statLine.substring(0, statLine.length - 2);
}

function findIndicesOfMax(input: number[], count: number) {
	let result = [];
	for (let i = 0; i < input.length; i++) {
		result.push(i); // add index to output array
		if (result.length > count) {
				result.sort(function(a, b) { return input[b] - input[a]; }); // descending sort the output array
				result.pop(); // remove the last index (index of smallest element in output array)
		}
	}
	return result;
}