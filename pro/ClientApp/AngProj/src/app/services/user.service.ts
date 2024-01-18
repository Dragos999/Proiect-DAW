import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl= 'http://localhost:5000/api/User';

  constructor(private http:HttpClient) { }

  getUsers(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  loginUser(loginDto: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, loginDto);
  }

  addUser(registerDTO: any): Observable<string> {
    return this.http.post(`${this.apiUrl}/add-user`, registerDTO, { responseType: 'text' });
  }

  addAdmin(registerDTO: any): Observable<string> {
    return this.http.post(`${this.apiUrl}/add-admin`, registerDTO, { responseType: 'text' });
  }

  deleteUser(userId: string): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.delete(`${this.apiUrl}/${userId}`,{headers, responseType: 'text' });
  }

  getUserOrders(name: string): Observable<string[]> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<string[]>(`${this.apiUrl}/UsrOrders?name=${name}`,{headers});
  }

  updateUserReview(id: string, nrOfStars: number, description: string): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.put(`${this.apiUrl}/?id=${id}&nrOfStars=${nrOfStars}&description=${description}`,null,  {headers, responseType: 'text' });
  }
}
