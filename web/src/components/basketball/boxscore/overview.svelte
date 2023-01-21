<script lang="ts">
  import type { BasketballGame, PlayerGame } from "$lib/basketball/basketballgame";
  import PlayerStats from "./stats.svelte";

  export let game: BasketballGame;
  export const awayStarters = game.PlayerGames
    .filter(pg => pg.TeamID === game.AwayTeam.TeamID && pg.Started)
    .sort((a, b) => Number(b.Points) - Number(a.Points));

  export const homeStarters = game.PlayerGames
    .filter(pg => pg.TeamID === game.HomeTeam.TeamID && pg.Started)
    .sort((a, b) => Number(b.Points) - Number(a.Points));

  export const awayBench = game.PlayerGames
    .filter(pg => pg.TeamID === game.AwayTeam.TeamID && !pg.Started)
    .sort((a, b) => Number(b.Points) - Number(a.Points));

  export const homeBench = game.PlayerGames
    .filter(pg => pg.TeamID === game.HomeTeam.TeamID && !pg.Started)
    .sort((a, b) => Number(b.Points) - Number(a.Points));
</script>

<div class="container">
  <div>
    <PlayerStats players={awayStarters} title={game.AwayTeam.Key + " STARTERS"} />
    <PlayerStats players={awayBench} title={game.AwayTeam.Key + " BENCH"} />
  </div>
  <div>
    <PlayerStats players={homeStarters} title={game.HomeTeam.Key + " STARTERS"} />
    <PlayerStats players={homeBench} title={game.HomeTeam.Key + " BENCH"} />
  </div>
</div>

<style>
  .container {
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    grid-template-rows: repeat(1, 1fr);
    justify-items: center;
    column-gap: 0.2rem;
    row-gap: 0.2rem;
  }
  .container :nth-child(n) {
    font-size: 0.75rem;
  }
  @media (max-width: 1360px) {
    .container {
      display: flex;
      flex-direction: column;
      align-items: center;
      grid-template-columns: 1fr;
      grid-template-rows: repeat(2, 1fr);
    }
  }
  @media (max-width: 690px) {
    .container {
      align-items: flex-start;
      /* overflow-x: scroll; */
    }
  }
</style>