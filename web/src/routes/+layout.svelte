<script lang="ts">
  import { goto } from '$app/navigation';
	import '../app.css';
	async function redirec(url: string) {
		await goto('/sports/' + url);
	}
</script>

	<main>
		<div class="navbar bg-base-100 pb-3">
			<div class="dropdown">
				<!-- svelte-ignore a11y-label-has-associated-control -->
				<!-- svelte-ignore a11y-no-noninteractive-tabindex -->
				<label tabindex="0" class="btn btn-ghost btn-circle">
					<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="inline-block w-5 h-5 stroke-current"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16"></path></svg>
				</label>
				<!-- svelte-ignore a11y-positive-tabindex -->
				<!-- svelte-ignore a11y-no-noninteractive-tabindex -->
				<ul tabindex="1" class="menu menu-compact dropdown-content mt-3 p-2 shadow bg-base-100 rounded-box w-52">
					<li><a href='/nfl'>NFL</a></li>
					<li><a href='/ncaaf'>NCAAF</a></li>
					<li><a href='/nba'>NBA</a></li>
				</ul>
			</div>
			<div class="flex-1 justify-center">
				<a class="btn btn-ghost normal-case text-xl" href="/">ScoresNow</a>
			</div>
			<div>
				<button class="btn btn-square btn-ghost">
					<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="inline-block w-5 h-5 stroke-current"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h.01M12 12h.01M19 12h.01M6 12a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0z"></path></svg>
				</button>
			</div>
		</div>
		<slot />
	</main><style>

	main {
		display: flex;
		flex-direction: column;
		font-family: 'Montserrat';
		font-size: 1rem;
		font-weight: 500;
	}
</style>
