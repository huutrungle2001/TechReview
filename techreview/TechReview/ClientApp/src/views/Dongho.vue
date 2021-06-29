<template>
  <div class="dienThoaiNoiBat">
    <div class="title">Đồng hồ Nội Bật</div>
    <div class="listCard">
      <card v-for="(item, index) in listDongHo" :key="index" :info="item" />
    </div>
  </div>
</template>

<script lang='ts'>
import { Options, Vue } from "vue-property-decorator";
import Card from "@/components/Card.vue";
import { DeviceModule } from "@/store/devicemodule.ts";
@Options({
  name: "donghoNoiBat",
  components: {
    Card,
  },
})
export default class extends Vue {
  get listDongHo() {
    var list = [];
    for (let i = 0; i < DeviceModule.devices.length; i++) {
      if (DeviceModule.devices[i].type == "DongHo") {
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
