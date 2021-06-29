<template>
	<div class="footer">
		<div class="logo">
			<img src="@/assets/logo.png" alt />
		</div>
		<h3 style="margin:20px 0">TechReview là một trang web chuyên review các sản phẩm công nghệ hot nhất hiện nay</h3>
		<h4>Liên hệ: 023581321</h4>
	</div>
</template>

<script>
import { Options, Vue } from "vue-property-decorator";
@Options({
	name: "footer"
})
export default class extends Vue {}
</script>

<style scoped lang="scss">
.footer {
	background-color: rgb(84, 92, 100);
	padding: 20px 0;
	color: white;
	.logo {
		width: 250px;
		margin: 20px auto;
		img {
			display: block;
			width: 100%;
		}
	}
}
</style>
