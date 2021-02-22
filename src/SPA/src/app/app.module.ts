import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DeviceComponent } from './pages/device/device.component';
import { DeviceTypeComponent } from './pages/device-type/device-type.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeviceService } from './_services/device.service';
import { DeviceTypeService } from './_services/deviceType.service';

@NgModule({
  declarations: [		
    AppComponent,
      DeviceComponent,
      DeviceTypeComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    DeviceService,
    DeviceTypeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
