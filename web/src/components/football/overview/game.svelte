<script lang="ts">
  import type { FootballGame } from "$lib/football/footballgame";
  import OverviewScore from "./score.svelte";
  import OverviewStats from "./stats.svelte";

  export let game: FootballGame;
</script>
<div class="shadow-lg">
  <a href="./nfl/boxscore/{game.Score.GlobalGameID}">
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
