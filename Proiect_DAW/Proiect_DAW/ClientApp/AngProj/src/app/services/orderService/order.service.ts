import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'http://localhost:5000/api/Order'; 

  constructor(private http: HttpClient) { }

  getOrders(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}`);
  }

  addOrder(userId: string, itemId: string, address: string ): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    console.log(itemId);
    console.log(userId);
    console.log(address);
    return this.http.post(`${this.apiUrl}?userId=${userId}&itemId=${itemId}&address=${address}`,null, {headers,responseType: 'text'});
  }

  deleteOrder(userId: string, itemId: string): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.delete(`${this.apiUrl}?userId=${userId}&itemId=${itemId}`, { headers,responseType: 'text' });
  }
}
