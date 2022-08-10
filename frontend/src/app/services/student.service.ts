import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  baseUrl = `${environment.baseUrl}/student`;

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Student[]> {
    return this.httpClient.get<Student[]>(`${this.baseUrl}`);
  }

  getById(id: Number): Observable<Student> {
    return this.httpClient.get<Student>(`${this.baseUrl}/${id}`);
  }

  post(student: Student): Observable<Student> {
    return this.httpClient.post<Student>(`${this.baseUrl}`, student);
  }

  put(student: Student): Observable<Student> {
    return this.httpClient.put<Student>(`${this.baseUrl}/${student.id}`, student);
  }

  delete(id: Number): Observable<String> {
    return this.httpClient.delete<String>(`${this.baseUrl}/${id}`);
  }
}