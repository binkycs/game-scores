<script lang="ts">
    import type { PageData } from './$types';
    import Overview from '$components/basketball/boxscore/overview.svelte'

    export let data: PageData;
    export let game = data.game;
</script>

<div class="main">
<Overview {game} />
</div>

<style>
  .main {
    display: grid;
    align-items: center;
    justify-items: center;
    column-gap: 10px;
    margin-left: 5%;
    margin-right: 5%;
  }
</style>