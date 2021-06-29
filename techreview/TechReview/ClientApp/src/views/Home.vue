<template>
	<div class="home">
		<dienThoaiNoiBat />
		<laptopiNoiBat />
		<phuKienNoiBat />
		<donghoNoiBat />
	</div>
</template>

<script>
import { Options, Vue } from "vue-property-decorator";
import dienThoaiNoiBat from "./PopularProducts/Dienthoainoibat.vue";
import laptopiNoiBat from "./PopularProducts/LaptopNoiBat.vue";
import phuKienNoiBat from "./PopularProducts/PhuKienNoiBat.vue";
import donghoNoiBat from "./PopularProducts/DongHoNoiBat.vue";
import DeviceApi from "@/api/devicesApi.ts";
import { DeviceModule } from "@/store/devicemodule.ts";
@Options({
	name: "home",
	components: {
		dienThoaiNoiBat,
		laptopiNoiBat,
		phuKienNoiBat,
		donghoNoiBat
	}
})
export default class extends Vue {
	async mounted() {
		await DeviceApi.getDevices();
	}
}
</script>

<style scoped lang="scss">
</style>
