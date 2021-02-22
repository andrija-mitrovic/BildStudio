import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Device } from '../_models/device';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {
baseUrl=environment.apiUrl;

constructor(private httpClient: HttpClient) { }

getDevices() {
  return this.httpClient.get(this.baseUrl+'devices');
}

getDevice(id: number) {
  return this.httpClient.get(this.baseUrl+'devices/'+ id);
}

createDevice(device: Device) {
  return this.httpClient.post(this.baseUrl+'devices', device);
}

updateDevice(id: number, device: Device) {
  return this.httpClient.put(this.baseUrl+'devices/'+ id, device);
}

deleteDevice(id: number) {
  return this.httpClient.delete(this.baseUrl+'devices/'+ id);
}
}
