<template>
	<div class="adminDetail">
		<div class="title" style="font-size=20px;margin:20px 0">Edit Item</div>
		<el-input placeholder="Please input" v-model="dataDevice.name">
			<template #prepend>Name</template>
		</el-input>
		<el-input placeholder="Please input" v-model="dataDevice.urlImage">
			<template #prepend>Url Image</template>
		</el-input>
		<el-input
			placeholder="Short Content"
			v-model="dataDevice.shortContent"
			type="textarea"
			:autosize="{ minRows: 5, maxRows: 20}"
			maxlength="140"
			show-word-limit
		></el-input>
		<el-input
			placeholder="Content"
			v-model="dataDevice.content"
			type="textarea"
			:autosize="{ minRows: 7, maxRows: 20}"
		></el-input>
		<span>Type:</span>
		<el-select v-model="dataDevice.type" placeholder="Select">
			<el-option v-for="item in options" :key="item.value" :label="item.value" :value="item.value"></el-option>
		</el-select>
		<span>Outstanding:</span>
		<el-switch v-model="dataDevice.outstanding"></el-switch>
		<div class="dialog-footer">
			<el-button @click="dialogVisible = false">Cancel</el-button>
			<el-button type="danger" @click="dialogVisible = false,deleteItem()">Delete</el-button>
			<el-button type="primary" @click="dialogVisible = false,editItem()">Confirm</el-button>
		</div>
	</div>
</template>

<script lang='ts'>
import { Options, Vue } from "vue-property-decorator";
import { DeviceModule } from "@/store/devicemodule.ts";
import deviceType from "@/entities/devicesType";
import DeviceApi from "@/api/devicesApi.ts";
@Options({
	name: "adminDetail"
})
export default class extends Vue {
	options = [
		{ value: "DienThoai" },
		{ value: "Laptop" },
		{ value: "PhuKien" },
		{ value: "DongHo" }
	];
	dataDevice: deviceType = {
		name: "",
		type: "DienThoai",
		id: "00000000-0000-0000-0000-000000000000",
		urlImage: "",
		shortContent: "",
		content: "",
		outstanding: true
	} as deviceType;

	deleteItem() {
		DeviceApi.deleteDevices(this.dataDevice.id);
		DeviceModule.deleteDevice();
		this.$router.push("/admin");
	}

	editItem() {
		DeviceApi.putDevices(this.dataDevice);
		DeviceModule.editDevice(this.dataDevice);
		this.$router.push("/admin");
	}
	mounted() {
		if (DeviceModule.positionEdit == -1) {
			this.$router.push("/admin");
		} else {
			this.dataDevice = JSON.parse(
				JSON.stringify(DeviceModule.devices[DeviceModule.positionEdit])
			);
		}
	}
}
</script>

<style scoped lang="scss">
.el-input {
	margin: 10px 0;
}
.el-select {
	margin: 10px 20px;
}
.el-textarea {
	margin: 10px 0;
}
</style>
