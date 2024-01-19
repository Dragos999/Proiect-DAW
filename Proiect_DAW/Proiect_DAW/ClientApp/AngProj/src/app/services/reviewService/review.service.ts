import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ReviewService {
  private apiUrl = 'http://localhost:5000/api/Review'; 

  constructor(private http: HttpClient) {}

  getReviews(): Observable<any> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<any>(`${this.apiUrl}`,{headers});
  }

  addReview(review: any): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.post(`${this.apiUrl}`, review,{headers,responseType:'text'});
  }

  getReviewByUserName(username:string):Observable<any>{
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.get<any>(`${this.apiUrl}/GetByUsername?name=${username}`,{headers})
  }

  deleteReview(id: string): Observable<string> {
    const authToken = localStorage.getItem('token');
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + authToken);
    return this.http.delete(`${this.apiUrl}?id=${id}`,{headers,responseType:'text'});
  }
}
