<template>
	<div class="app">
		<el-header>
			<Navbar />
		</el-header>
		<el-container>
			<el-main>
				<router-view />
			</el-main>
			<el-footer>
				<Footer />
			</el-footer>
		</el-container>
	</div>
</template>

<script lang="ts">
import { Vue, Options } from "vue-property-decorator";
import Navbar from "@/components/navBar.vue";
import Footer from "@/components/footer.vue";
import { DeviceModule } from "./store/devicemodule";
import DeviceApi from "@/api/devicesApi.ts";
@Options({
	name: "App",
	components: {
		Navbar,
		Footer
	}
})
export default class extends Vue {
	async mounted() {
		const dv = await DeviceApi.getDevices();
		await DeviceModule.getAllDevices(dv);
	}
}
</script>

<style>
* {
	margin: 0;
	padding: 0;
	box-sizing: border-box;
}
a {
	text-decoration: none;
}
#app {
	font-family: Avenir, Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	text-align: center;
	color: #2c3e50;
}
.el-header {
	padding: 0 !important;
}
.el-footer {
	padding: 0 !important;
}
</style>
