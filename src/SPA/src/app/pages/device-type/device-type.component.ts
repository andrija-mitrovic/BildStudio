import { Component, OnInit } from '@angular/core';
import { DeviceTypeService } from 'src/app/_services/deviceType.service';

@Component({
  selector: 'app-device-type',
  templateUrl: './device-type.component.html',
  styleUrls: ['./device-type.component.scss']
})
export class DeviceTypeComponent implements OnInit {

  constructor(private deviceTypeService: DeviceTypeService) { }

  ngOnInit() {
  }

}
