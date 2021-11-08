import { ComponentFixture, TestBed, fakeAsync } from '@angular/core/testing';
import { RouterTestingModule } from "@angular/router/testing";
import { HttpClientTestingModule } from '@angular/common/http/testing'

import { DevicesComponent } from './devices.component';
import { DeviceDataService } from 'src/app/service/device-data-service.service';
import { observable } from 'rxjs';

describe('DevicesComponent', () => {
  let component: DevicesComponent;
  let fixture: ComponentFixture<DevicesComponent>;


  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DevicesComponent],
      imports: [RouterTestingModule, HttpClientTestingModule],
      providers: [{ provide: DeviceDataService } ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should have title as "List of Devices"', () => {
    const fixture = TestBed.createComponent(DevicesComponent)
    const app = fixture.componentInstance;
    expect(app.title).toEqual("List of Devices")
  });

  it('should have same list of devices', fakeAsync(() => {
    const fixture = TestBed.createComponent(DevicesComponent)
    const app = fixture.componentInstance;
    let myService = TestBed.get(DeviceDataService);
    let devices: { deviceId: number, deviceName: string, image: string, relatedDevices: any, status: boolean, temperature: Number, usageDescription: string }[] = [
      { "deviceId": 1, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" },
      { "deviceId": 2, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" }
      //{ "deviceId": 0, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" },
      //{ "deviceId": 0, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" },
      //{ "deviceId": 0, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" },
      //{ "deviceId": 0, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" },
      //{ "deviceId": 0, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" },
      //{ "deviceId": 0, "deviceName": "Computer", "image": "icons8-computer-30.png", "temperature": 10, "relatedDevices": null, "status": true, "usageDescription": "To do daily task" }
    ];
    const mySpy = spyOn(myService, 'getDeviceList').and.callFake(() => {
      return devices;
    });

   
    expect(mySpy.call).toEqual(devices)
  }));
});
