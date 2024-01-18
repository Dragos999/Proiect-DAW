import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class DistributorService {
  private apiUrl = 'http://localhost:5000/api/Distributor'; 

  constructor(private http: HttpClient) {}

  getDistributors(): Observable<any> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<any>(`${this.apiUrl}`,{headers});
  }

  addDistributor(distributor: any): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.post(`${this.apiUrl}`, distributor, { headers,responseType: 'text' });
  }

  deleteDistributor(id: string): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.delete(`${this.apiUrl}?id=${id}`, { headers,responseType: 'text' });
  }

  getDistributorItems(name: string): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get(`${this.apiUrl}/GetDistIt?name=${name}`, { headers,responseType: 'text' });
  }
}
