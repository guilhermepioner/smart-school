import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Professor } from '../models/professor.model';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  baseUrl = `${environment.baseUrl}/professor`;

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Professor[]> {
    return this.httpClient.get<Professor[]>(`${this.baseUrl}`);
  }

  getById(id: Number): Observable<Professor> {
    return this.httpClient.get<Professor>(`${this.baseUrl}/${id}`);
  }

  post(professor: Professor): Observable<Professor>{
    return this.httpClient.post<Professor>(`${this.baseUrl}`, professor);
  }

  put(professor: Professor): Observable<Professor> {
    return this.httpClient.put<Professor>(`${this.baseUrl}/${professor.id}`, professor);
  }

  delete(id: Number) {
    return this.httpClient.delete(`${this.baseUrl}/${id}`);
  }
}