import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DeviceDataService } from 'src/app/service/device-data-service.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: DeviceDataService) { }

  DevicesList: any = [];
  OriginalDevicesList: any = [];
  IsListVisible: boolean = false;
  searchText: string = '';
  title: string = 'List of Devices';
  noDeviceFoundLabel: string = 'No Device Found';

  ngOnInit() {
    this.refreshDeviceList();
  }

  parseDevice = (data: any) => {
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

  refreshDeviceList() {
    this.service.getDeviceList().subscribe((data: any) => {
      this.DevicesList = data.map((x: any) => this.parseDevice(x));
      this.OriginalDevicesList = this.DevicesList;
      this.DevicesList.length > 0 ? this.IsListVisible = true : this.IsListVisible = false;
    });
  }

  deviceDetail(item: any) {
    this.router.navigate(['deviceDetail'], { queryParams: { id: item.deviceId } });
  }

  onChange(text: any) {
    this.DevicesList = this.OriginalDevicesList;

    if (text && text.trim()!=='') {
        this.DevicesList = this.DevicesList
        .filter((row: any) => {
          return row.deviceName.toUpperCase().includes(text.toUpperCase());
        });
    }

    this.DevicesList.length > 0 ? this.IsListVisible = true : this.IsListVisible = false;
  }
}
