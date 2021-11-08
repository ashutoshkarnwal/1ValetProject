import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeviceDataService {

  readonly APIUrl = "http://localhost:54119/api";
  readonly header = new HttpHeaders()
    .set('Authorization', `Basic ${btoa('ashutosh' + ':' + 'karnwal')}`);

  constructor(private http: HttpClient) { }

  
  getDeviceList(): Observable<any> {
    return this.http.get<any>(this.APIUrl + '/Device/GetDevices', {
      headers: this.header
    })
  };

  getRelatedDeviceList(id: any): Observable<any> {
    let params = new HttpParams();
    params = params.append("id", id);
    return this.http.get<any>(this.APIUrl + '/Device/GetRelatedDevices', { headers: this.header , params: params });
  };


}
  
