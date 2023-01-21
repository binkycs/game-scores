<script lang="ts">
  import type { FootballGame } from "$lib/football/footballgame";
  import DefenseStats from "./defense.svelte";
  import KickingStats from "./kicking.svelte";
  import PassingStats from "./passing.svelte";
  import PuntingStats from "./punting.svelte";
  import ReceivingStats from "./receiving.svelte";
  import ReturnStats from "./return.svelte";
  import RushingStats from "./rushing.svelte";

  export let game: FootballGame;
</script>

<PassingStats {game} />
<RushingStats {game} />
<ReceivingStats {game} />
<KickingStats {game} />
<ReturnStats {game} />
<PuntingStats {game} />
<DefenseStats {game} />
<br />
<br />

<style>

</style>