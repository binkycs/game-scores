<script lang="ts">
  import type { BasketballGame } from "$lib/basketball/basketballgame";
  import { getQuarterOrTime } from "$lib/basketball/helper";

  export let game: BasketballGame;

  export const awayScore = game.Game.AwayTeamScore ?? `${game.Game.PointSpread > 0 ? `+${game.Game.PointSpread}` : game.Game.PointSpread ?? '-'}`;
  export const homeScore = game.Game.HomeTeamScore ?? `${game.Game.OverUnder ? 'o' + game.Game.OverUnder : '-'}`;
</script>

<table class="table p-2 leading-5">
  <thead>
    <th class="text-base">{getQuarterOrTime(game.Game)}</th>
    <th colspan="4"/>
    <th class="text-base" align="right">{game.Game.Channel}</th>
  </thead>
  <tbody>
    <tr class="tr-quarters">
      <td />
      <td align="center">1</td>
      <td align="center">2</td>
      <td align="center">3</td>
      <td align="center">4</td>
      <td />
    </tr>
    <tr class="tr-quarters-points">
      <td>
        <img src="{game.AwayTeam.WikipediaLogoUrl}" alt="Away logo" />
        {`${game.AwayTeam.Key}`}
      </td>
      <td>{game.Quarters.length > 0 ? game.Quarters[0].AwayScore : '-'}</td>
      <td>{game.Quarters.length > 1 ? game.Quarters[1].AwayScore : '-'}</td>
      <td>{game.Quarters.length > 2 ? game.Quarters[2].AwayScore : '-'}</td>
      <td>{game.Quarters.length > 3 ? game.Quarters[3].AwayScore : '-'}</td>
      <td>{awayScore}</td>
    </tr>
    <tr class="tr-quarters-points -translate-y-[0.1rem]">
      <td>
        <img src="{game.HomeTeam.WikipediaLogoUrl}" alt="Home logo" />
        {`${game.HomeTeam.Key}`}
      </td>
      <td>{game.Quarters.length > 0 ? game.Quarters[0].HomeScore : '-'}</td>
      <td>{game.Quarters.length > 1 ? game.Quarters[1].HomeScore : '-'}</td>
      <td>{game.Quarters.length > 2 ? game.Quarters[2].HomeScore : '-'}</td>
      <td>{game.Quarters.length > 3 ? game.Quarters[3].HomeScore : '-'}</td>
      <td>{homeScore}</td>
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
    font-size: larger;
    font-weight: bolder;
  }
  .tr-quarters-points td:nth-child(n):where(:last-child) {
    font-size: larger;
    font-weight: bolder;
    text-align: end;
  }
</style>