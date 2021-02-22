import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DeviceType } from '../_models/deviceType';

@Injectable({
  providedIn: 'root'
})
export class DeviceTypeService {
baseUrl=environment.apiUrl;

constructor(private httpClient: HttpClient) { }

getDeviceTypes() {
  return this.httpClient.get(this.baseUrl+'devicetypes');
}

getDeviceType(id: number) {
  return this.httpClient.get(this.baseUrl+'devicetypes/'+ id);
}

createDeviceType(deviceType: DeviceType) {
  return this.httpClient.post(this.baseUrl+'devicetypes', deviceType);
}

updateDeviceType(id: number, deviceType: DeviceType) {
  return this.httpClient.put(this.baseUrl+'devicetypes/'+ id, deviceType);
}

deleteDeviceType(id: number) {
  return this.httpClient.delete(this.baseUrl+'devicetypes/'+ id);
}
}
