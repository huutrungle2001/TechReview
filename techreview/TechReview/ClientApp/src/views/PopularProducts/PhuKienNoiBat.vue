<template>
	<div class="phukienNoiBat">
		<div class="title">Phụ Kiện Nổi Bật</div>
		<div class="listCard">
			<card v-for="(item,index) in listPhuKien" :key="index" :info="item" />
		</div>
	</div>
</template>

<script lang='ts'>
import { Options, Vue, Prop } from "vue-property-decorator";
import Card from "@/components/Card.vue";
import deviceType from "@/entities/devicesType";
import { DeviceModule } from "@/store/devicemodule";
@Options({
	name: "dienThoaiNoiBat",
	components: {
		Card
	}
})
export default class extends Vue {
	get listPhuKien() {
    var list = [];
    for (let i = 0; i < DeviceModule.devices.length; i++) {
      if (
        DeviceModule.devices[i].type == "PhuKien" &&
        DeviceModule.devices[i].outstanding
      ) {
        list.push(DeviceModule.devices[i]);
      }
    }
    return list;
  }
}
</script>

<style scoped lang="scss">
.title {
	text-align: left;
	padding: 10px;
	background: #fed100;
	margin: 10px 0;
	font-weight: bold;
}
.listCard {
	display: flex;
	flex-wrap: wrap;
	justify-content: center;
}
</style>
