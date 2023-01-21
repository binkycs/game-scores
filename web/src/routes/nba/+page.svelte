<script lang="ts">
  import GameOverview from '$components/basketball/overview/game.svelte';
  export let data;
  let gamesPromise = data.gamesPromise;
</script>

<div class="main">
  {#await gamesPromise then games}
    {#each games as game}
      <GameOverview {game} />
    {/each}
  {/await}
</div>

<style>
  .main {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(24rem, max-content));
    justify-content: center;
    column-gap: 10rem;
    row-gap: 2.5rem;
    margin-left: 5%;
    margin-right: 5%;
  }
  @media (max-width: 400px) {
    .main {
      row-gap: 1rem;
    }
  }
</style>