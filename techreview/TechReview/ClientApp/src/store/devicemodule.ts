import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import deviceType from '@/entities/devicesType'

@Module({ dynamic: true, store, name: 'deviceModule' })
class Device extends VuexModule {
  public devices: deviceType[] = [];
  public positionEdit = -1;

  @Mutation
  GET_ALL_DEVICES(dv: deviceType[]) {
    this.devices = dv;

  }

  @Action({ commit: 'GET_ALL_DEVICES' })
  getAllDevices(dv: deviceType[]): deviceType[] {
    return dv;
  }

  //add devices
  @Mutation
  ADD_DEVICES(dv: deviceType) {
    this.devices.push(JSON.parse(JSON.stringify(dv)));

  }

  @Action({ commit: 'ADD_DEVICES' })
  addDevices(dv: deviceType): deviceType {
    return dv;
  }

  //change position
  @Mutation
  CHANGE_POSITION(p: number) {
    this.positionEdit = p;
  }

  @Action({ commit: 'CHANGE_POSITION' })
  changePosition(p: number): number {
    return p;
  }

  //delete device
  @Mutation
  DELETE_DEVICE() {
    this.devices.splice(this.positionEdit, 1);
  }

  @Action({ commit: 'DELETE_DEVICE' })
  deleteDevice() {
    this.DELETE_DEVICE();
  }

  //edit device
  @Mutation
  EDIT_DEVICE(dv: deviceType) {
    this.devices[this.positionEdit] = JSON.parse(JSON.stringify(dv))
  }

  @Action({ commit: 'EDIT_DEVICE' })
  editDevice(dv: deviceType): deviceType {
    return dv;
  }


}
export const DeviceModule = getModule(Device)