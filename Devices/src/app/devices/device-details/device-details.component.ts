import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { DeviceDataService } from 'src/app/service/device-data-service.service';

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.css']
})
export class DeviceDetailsComponent implements OnInit {

  parseDevice = (data:any) => {
  let status = '';
    status = data.status ? "Available" : "Not Available";
      return {
        deviceName: data.deviceName,
        deviceId: data.deviceId,
        status: status,
        usageDescription: data.usageDescription,
        image: data.image,
        temperature: data.temperature
      };
  };

  IsListVisible: boolean = false;
  DevicesList: any = [];
  Device: any = [];
  DeviceName: string = "";
  DeviceStatus: string = "";
  queryParam: string = '';
  sub: Subscription | undefined;
  noRelatedDeviceLabel: string = 'No Related Devices are Found';
  listOfDevices: string = 'List of Related Devices';

  constructor(private actRoute: ActivatedRoute,
    private service: DeviceDataService) {
    }

  ngOnInit() {
    this.sub = this.actRoute.
      queryParams.subscribe(params => {
        let id = Number(params["id"]);
        this.service.getRelatedDeviceList(id).subscribe((data: any) => {
          var list = data;
          this.DevicesList = list.relatedDevices.map((x: any) => this.parseDevice(x));
              this.DevicesList.length > 0 ? this.IsListVisible = true : this.IsListVisible = false;
              this.Device = this.parseDevice(list)
        });

    });
  }

}
