import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {
  @Input() source: any;
  @Output() deviceSelect = new EventEmitter<Number>();

  constructor() { }

  iconImageSrc: string = 'assets/special-icons/icons8-exclamation-mark-30.png';

  ngOnInit(): void {
  }

  deviceDetail(item: any) {
    this.deviceSelect.emit(item);
  };

}
