import { DateTime } from "luxon";
import type { Passing, Rushing, Score, Receiving } from "./footballgame";

export function getQuarterOrTime(game: Score) {
	if (!game.HasStarted)
		return DateTime.fromISO(game.DateTime).toFormat('t');
	if (game.IsOver)
		return 'Final';

	switch (game.Quarter) {
		case '1':	return '1st';
		case '2':	return '2nd';
		case '3':	return '3rd';
		case '4':	return '4th';
		case 'OT': return 'OT';
		case 'F': return 'Final';
	}
	return 'N/A'
}

export function getPassingName(passing: Passing[]) {
	const rusher = getLeadingPasser(passing);
	if (!rusher) return '-';
	const split = rusher.Name.split(' ');
	const firstName = split[0][0];
	const lastName = split.slice(1).join(' ');
	return `${firstName}. ${lastName}`;
}

export function getPassingStats(passing: Passing[]) {
	let passer = getLeadingPasser(passing);
	if (!passer) return '\n';
	return `${passer.PassingYards} YDs, ${passer.PassingTouchdowns} TDs`;
}

function getLeadingPasser(passing: Passing[]) {
	if (passing.length === 0) return undefined;
	let leadingPasser = passing.sort((a, b) => {
		if (a.PassingYards > b.PassingYards) return -1;
		else return 1;
	})[0];
	return leadingPasser;
}

export function getRushingName(rushing: Rushing[]) {
	const rusher = getLeadingRusher(rushing);
	if (!rusher) return '-';
	const split = rusher.Name.split(' ');
	const firstName = split[0][0];
	const lastName = split.slice(1).join(' ');
	return `${firstName}. ${lastName}`;
}

export function getRushingStats(rushing: Rushing[]) {
	let rusher = getLeadingRusher(rushing);
	if (!rusher) return '\n';
	let statLine = `${rusher.RushingAttempts} ATTs, ${rusher.RushingYards} YDs`;
	if (rusher.RushingTouchdowns > 0) {
		statLine += `, ${rusher.RushingTouchdowns} TDs`;
	}
	return statLine;
}

function getLeadingRusher(rushing: Rushing[]) {
	if (rushing.length === 0) return undefined;
	return rushing.sort((a, b) => {
		if (a.RushingYards > b.RushingYards) return -1;
		else return 1;
	})[0];
}

export function getReceivingName(receiving: Receiving[]) {
	const rusher = getLeadingReceiver(receiving);
	if (!rusher) return '-';
	const split = rusher.Name.split(' ');
	const firstName = split[0][0];
	const lastName = split.slice(1).join(' ');
	return `${firstName}. ${lastName}`;
}

export function getReceivingStats(receiving: Receiving[]) {
	let receiver = getLeadingReceiver(receiving);
	if (!receiver) return '\n\n\n';
	let statLine = `${receiver.Receptions} RECs, ${receiver.ReceivingYards} YDs`;
	if (receiver.ReceivingTouchdowns > 0) {
		statLine += `, ${receiver.ReceivingTouchdowns} TDs`;
	}
	return statLine;
}

function getLeadingReceiver(receiver: Receiving[]) {
	if (receiver.length === 0) return undefined;
	return receiver.sort((a, b) => {
		if (a.ReceivingYards > b.ReceivingYards) return -1;
		else return 1;
	})[0];
}