<script lang="ts">
  import type { BasketballGame } from "$lib/basketball/basketballgame";
  import OverviewScore from "./score.svelte";
  import OverviewStats from "./stats.svelte";

  export let game: BasketballGame;
</script>

<div class="shadow-lg">
  <a href="./nba/boxscore/{game.Game.GlobalGameID}">
    <OverviewScore {game} />
    <OverviewStats {game} />
  </a>
</div>

<style>
  div {
    margin-bottom: 1rem;
  }
  div:hover {
    box-shadow: 0 0 11px hsl(var(--nc) / 1);
  }
</style>
