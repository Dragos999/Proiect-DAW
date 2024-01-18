import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  private apiUrl= 'http://localhost:5000/api/Item';

  constructor(private http: HttpClient) { }

  getItems(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}`);
  }

  addItem(item: any): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.post(`${this.apiUrl}`, item, {headers, responseType: 'text' });
  }

  deleteItem(id: string): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.delete(`${this.apiUrl}?id=${id}`, {headers, responseType: 'text' });
  }
}
