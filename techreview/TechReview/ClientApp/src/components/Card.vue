<template>
	<div class="card" @click="dialogVisible=true">
		<div class="img">
			<img :src="info.urlImage" />
		</div>
		<div class="name">{{info.name}}</div>
		<div class="shortContent">{{info.shortContent}}</div>
		<el-dialog :title="info.name" v-model="dialogVisible">
			<span v-html="info.content"></span>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="dialogVisible = false">OK</el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script lang='ts'>
import { Options, Vue, Prop } from "vue-property-decorator";
import deviceType from "@/entities/devicesType.ts";
@Options({
	name: "card"
})
export default class extends Vue {
	@Prop({ required: true }) private readonly info!: deviceType;
	dialogVisible = false;
}
</script>

<style scoped lang="scss">
.card {
	background: white;
	box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
	padding: 20px 10px;
	max-height: 500px;
	max-width: 350px;
	border-radius: 10px;
	cursor: pointer;
	transition: 0.3s;
	margin: 10px;
	&:hover {
		box-shadow: rgba(0, 0, 0, 0.35) 5px 5px 15px;
	}
	.name {
		margin: 20px 0 0 0;
		font-weight: bold;
		font-size: 25px;
	}
	.img {
		img {
			display: block;
			width: 100%;
		}
	}
	.shortContent {
		margin-top: 10px;
	}
}
</style>
