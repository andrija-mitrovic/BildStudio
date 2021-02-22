import { Component, OnInit } from '@angular/core';
import { DeviceService } from 'src/app/_services/device.service';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.scss']
})
export class DeviceComponent implements OnInit {

  constructor(private deviceService: DeviceService) { }

  ngOnInit() {
  }

}
