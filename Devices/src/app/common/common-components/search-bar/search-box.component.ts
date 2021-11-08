import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.css']
})
export class SearchBoxComponent implements OnInit {

  constructor() { }
  search: string = '';
  cancelLabel: string = 'Cancel';

  @Output() changeText = new EventEmitter<string>();
  ngOnInit(): void {
  }

  onChange(value: any) {
    debugger;
    this.search = value;
    this.changeText.emit(value);
  };

  clickCancel() {
    debugger;
    this.search = ' ';
    this.onChange(' ');
  };

}
