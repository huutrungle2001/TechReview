<template>
	<div :class="{'navbar':true, 'navbarExpand':expand}">
		<el-menu
			:default-active="activeIndex2"
			class="el-menu"
			mode="horizontal"
			background-color="#545c64"
			text-color="#fff"
			active-text-color="#ffd04b"
		>
			<div :class="{'expand-button':true, 'expand':expand} " @click="expand=!expand">
				<div class="line1 line"></div>
				<div class="line2 line"></div>
				<div class="line3 line"></div>
			</div>
			<div class="logo">
				<router-link to="/">
					<img src="@/assets/logo.png" alt />
				</router-link>
			</div>
			<router-link to="/Dienthoai">
				<el-menu-item index="Dienthoai" :style="{'color':active('/Dienthoai')}">
					<span class="mdi mdi-cellphone-android"></span>
					Điện thoại
				</el-menu-item>
			</router-link>

			<router-link to="/Laptop">
				<el-menu-item index="Laptop" :style="{'color':active('/Laptop')}">
					<span class="mdi mdi-laptop-chromebook"></span>
					Laptop
				</el-menu-item>
			</router-link>

			<router-link to="/Phukien">
				<el-menu-item index="Phukien" :style="{'color':active('/Phukien')}">
					<span class="mdi mdi-headset"></span>
					Phụ kiện
				</el-menu-item>
			</router-link>

			<router-link to="/Dongho">
				<el-menu-item index="Dongho" :style="{'color':active('/Dongho')}" >
					<span class="mdi mdi-watch-variant"></span>
					Đồng hồ
				</el-menu-item>
			</router-link>
		</el-menu>
	</div>
</template>

<script lang='ts'>
import { Options, Vue } from "vue-property-decorator";
@Options({
	name: "Navbar"
})
export default class extends Vue {
	activeIndex2 = "Dienthoai";
	expand = false;
	active(p: string){
		if(this.$route.path==p) return 'orange'
		else return 'white'
	}
}
</script>

<style scoped lang="scss">
.el-menu-item {
	height: 100% !important;
}
.navbar {
	position: relative;
	position: fixed;
	width: 100%;
	transition: 0.6s ease-in-out;
	z-index: 99999;
	ul {
		display: flex;
		justify-content: center;
		li {
			padding: 0px 30px;
		}
		.expand-button {
			position: absolute;
			display: none;
			top: 15px;
			right: 10px;
			cursor: pointer;
			transition: 0.4s ease-in-out;
			.line {
				width: 30px;
				height: 2px;
				background: white;
				margin: 5px 0;
				transition: 0.4s ease-in-out;
			}
		}
	}
	.logo {
		width: 150px;
		img {
			display: block;
			width: 100%;
		}
	}
}
.navbar {
	height: 80px;
	overflow: hidden;
	.expand {
		.line1 {
			transform-origin: 50%;
			transform: rotate(45deg) translate(0, 10px);
		}
		.line2 {
			opacity: 0;
			overflow: hidden;
		}
		.line3 {
			transform-origin: 50%;
			transform: rotate(-45deg) translate(0, -10px);
		}
	}
}
.navbarExpand {
	height: 100%;
}
@media screen and (max-width: 820px) {
	.navbar {
		.logo {
			margin: 10px auto;
		}

		ul {
			flex-direction: column;
			.expand-button {
				display: block;
			}
			li {
				border: 1px solid gray;
			}
		}
	}
}
</style>
