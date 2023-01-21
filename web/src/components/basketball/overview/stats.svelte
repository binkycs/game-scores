<script lang="ts">
  import type { BasketballGame, PlayerGame } from "$lib/basketball/basketballgame";
  import { getHighestScoringPlayer, getStatLine } from "$lib/basketball/helper";
  import { getAbbreviatedName } from "$lib/helper";

  export let game: BasketballGame;

  export const homeMvp = getHighestScoringPlayer(game.PlayerGames, game.HomeTeam);
  export const awayMvp = getHighestScoringPlayer(game.PlayerGames, game.AwayTeam);
  export const awayMvpName = getAbbreviatedName(awayMvp?.Name);
  export const homeMvpName = getAbbreviatedName(homeMvp?.Name);
</script>


<table class="table p-2 leading-5">
  <thead>
    <th colspan="4" />
  </thead>
  <tbody class="h-[5rem]">
    <tr class="tr-stats">
      <td class="font-semibold">{awayMvpName}</td>
      <td class="text-left" colspan="4">{getStatLine(awayMvp) ?? ''}</td>
    </tr>
    <tr class="tr-stats">
      <td class="font-semibold">{homeMvpName}</td>
      <td class="text-left" colspan="4">{getStatLine(homeMvp) ?? ''}</td>
    </tr>
  </tbody>
</table>

<style>
  table {
    min-width: 24rem;
    max-width: 24rem;
    --tw-bg-opacity: 1;
    background-color: hsl(var(--b1) / var(--tw-bg-opacity));
  }
  .tr-stats td:nth-child(n+2) {
    font-size: x-small;
  }
  td {
    border-style: none;
  }
</style>