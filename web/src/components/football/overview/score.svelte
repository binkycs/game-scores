<script lang="ts">
  import type { FootballGame } from "$lib/football/footballgame";
  import { getQuarterOrTime } from "$lib/football/helper";

  export let game: FootballGame;

  export const awayScore = game.Score.AwayScore ?? `${Number(game.Game?.PointSpread) > 0 ? `+${game.Score.PointSpread}` : game.Game?.PointSpread ?? '-'}`;
  export const homeScore = game.Score.HomeScore ?? `${game.Score.OverUnder ? 'o' + game.Score.OverUnder : '-'}`;
</script>

<table class="table p-2 leading-5">
  <thead>
    <th class="text-base">{getQuarterOrTime(game.Score)}</th>
    <th colspan="4"/>
    <th class="text-base" align="right">{game.Score.Channel}</th>
  </thead>
  <tbody>
    <tr class="tr-quarters">
      <td></td>
      <td>1</td>
      <td>2</td>
      <td>3</td>
      <td>4</td>
      <td></td>
    </tr>
    <tr class="tr-quarters-points">
      <td>
        <img src="{game.AwayTeam.WikipediaLogoUrl}" alt="Away logo" />
        {game.AwayTeam.Key}
      </td>
      <td>{game.Score.AwayScoreQuarter1 ?? '-'}</td>
      <td>{game.Score.AwayScoreQuarter2 ?? '-'}</td>
      <td>{game.Score.AwayScoreQuarter3 ?? '-'}</td>
      <td>{game.Score.HomeScoreQuarter4 ?? '-'}</td>
      <td class="text-right font-semibold">{awayScore}</td>
    </tr>
    <tr class="tr-quarters-points -translate-y-[0.1rem]">
      <td>
        <img src="{game.HomeTeam.WikipediaLogoUrl}" alt="Home logo" />
        {game.HomeTeam.Key}
      </td>
      <td>{game.Score.HomeScoreQuarter1 ?? '-'}</td>
      <td>{game.Score.HomeScoreQuarter2 ?? '-'}</td>
      <td>{game.Score.HomeScoreQuarter3 ?? '-'}</td>
      <td>{game.Score.HomeScoreQuarter4 ?? '-'}</td>
      <td class="text-right font-semibold">{homeScore}</td>
    </tr>
  </tbody>
</table>

<style>
  table {
    min-width: 24rem;
    background-color: hsl(var(--b1) / 1);
    border-style: none;
  }
  th {
    --tw-bg-opacity: 1;
    line-height: 1rem;
  }
  td {
    --tw-bg-opacity: 1;
    border-style: none;
  }
  img {
    width: 24px;
    height: 24px;
    object-fit: fill;
    float: left;
    transform: translateX(-0.35rem);
  }
  .tr-quarters td:nth-child(n) {
    padding-top: 0.8rem;
    padding-bottom: 0;
    font-size: 0.65rem;
    line-height: 0;
    text-align: center;
  }
  .tr-quarters-points td:nth-child(n):where(:not(:first-child)):where(:not(:last-child)) {
    text-align: center;
  }
  .tr-quarters-points td:nth-child(n):where(:first-child) {
    font-weight: bolder;
    font-size: larger;
  }
  .tr-quarters-points td:nth-child(n):where(:last-child) {
    font-size: larger;
    font-weight: bolder;
    text-align: end;
  }
</style>