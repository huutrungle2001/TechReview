<template>
	<div class="admin">
		<el-table :data="list" style="width: 100%" stripe height="65vh" @row-click="transferEdit">
			<el-table-column prop="name" label="Name" width="100"></el-table-column>
			<el-table-column prop="type" label="Type" width="100" sortable></el-table-column>
			<el-table-column prop="urlImage" label="URl Image" width="250"></el-table-column>
			<el-table-column prop="shortContent" label="shortContent"></el-table-column>
			<el-table-column prop="content" label="content"></el-table-column>
			<el-table-column prop="outstanding" label="outstanding" width="120"></el-table-column>
		</el-table>
		<el-button type="success" style="margin-top:10px" @click="dialogVisible=true">Create</el-button>
		<el-dialog title="Create item" v-model="dialogVisible" width="50%">
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
				:autosize="{ minRows: 5, maxRows: 10}"
				maxlength="140"
				show-word-limit
			></el-input>
			<el-input
				placeholder="Content"
				v-model="dataDevice.content"
				type="textarea"
				:autosize="{ minRows: 5, maxRows: 10}"
			></el-input>
			<span>Type:</span>
			<el-select v-model="dataDevice.type" placeholder="Select">
				<el-option v-for="item in options" :key="item.value" :label="item.value" :value="item.value"></el-option>
			</el-select>
			<span>Outstanding:</span>
			<el-switch v-model="dataDevice.outstanding"></el-switch>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="dialogVisible = false">Cancel</el-button>
					<el-button type="primary" @click="dialogVisible = false,addDevice()">Confirm</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script lang='ts'>
import { Options, Vue } from "vue-property-decorator";
import { DeviceModule } from "@/store/devicemodule.ts";
import deviceType from "@/entities/devicesType";
import DeviceApi from "@/api/devicesApi.ts";

@Options({
	name: "admin"
})
export default class extends Vue {
	dialogVisible = false;
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
	list: deviceType[] = [];

	async addDevice() {
		const id = await DeviceApi.postDevices(this.dataDevice);
		this.dataDevice.id = id;
		DeviceModule.addDevices(this.dataDevice);
	}

	transferEdit(e: any) {
		this.$router.push("/admin/details");
		DeviceModule.changePosition(DeviceModule.devices.indexOf(e));
	}

	async mounted() {
		await DeviceApi.getDevices();
		this.list = DeviceModule.devices;
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
