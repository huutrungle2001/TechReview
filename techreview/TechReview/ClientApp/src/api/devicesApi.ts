import axios from "axios";
import deviceType from "@/entities/devicesType";

export default {

  getDevices: async (): Promise<deviceType[]> => {
    return (await axios.get<deviceType[]>('/api/devices')).data;
  },

  postDevices: async (dv: deviceType) => {
    return (await axios({
      method: 'post',
      url: '/api/devices',
      data: JSON.stringify(dv),
      headers: {
        "Content-Type": "application/json; charset=utf-8"
      }
    })).data
  },

  putDevices: async (dv: deviceType) => {
    await axios.put('/api/devices', JSON.stringify(dv), {
      headers: {
        "Content-Type": "application/json; charset=utf-8"
      }
    })
  },

  deleteDevices: async (id: string) => {
    await axios.delete(`/api/devices${id}`, {
      headers: {
        "Content-Type": "application/json; charset=utf-8"
      }
    })
  }

}