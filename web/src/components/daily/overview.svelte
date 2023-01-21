<script lang="ts" context="module">

  // let gamesPromise = getPromises(nflGames, nbaGames);

  // async function getPromises(...promises: Promise<any>[]) {
  //   let results = new Array();
  //   for (let i = 0; i < promises.length; i++) {
  //     results.push(sortGames(await promises[i]));
  //   }
  //   return results;
  // }

  // function sortGames(games: FootballGame[]) {
  //   return games.sort((game1, game2) => {
  //     if (game1.status.short == "NS" && game2.status.short != "FT") return 1;
  //     if (game1.timestamp > game2.timestamp) return -1;
  //     if (game1.timestamp < game2.timestamp) return 1;
  //     return 0;
  //   });
  // }
</script>

<!-- {#await gamesPromise then sports}
  {#each sports as games}
    <div class="divider">{games[0].league.name}</div>
    {#each games as game}
      TODO: Sort sport by user preference. Long term todo lol
      <GameOverview {game} />
    {/each}
  {/each}
{/await} -->