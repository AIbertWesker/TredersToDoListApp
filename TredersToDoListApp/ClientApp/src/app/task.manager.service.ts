import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Task } from './task';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskManagerService {

  private apiUrl = 'http://localhost:6966/api/tasks'

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(`${this.apiUrl}/get`);
  }

  getTaskById(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.apiUrl}/${id}`);
  }

  addTask(task: Task): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/add`, task, { responseType: 'text' as 'json' });
  }

  changeStatus(id: number, newStatus: string): Observable<string> {
    return this.http.put<string>(`${this.apiUrl}/edit?id=${id}&newStatus=${newStatus}`, null, { responseType: 'text' as 'json' });
  }

  deleteTask(id: number): Observable<string> {
    return this.http.delete<string>(`${this.apiUrl}/delete?id=${id}`, { responseType: 'text' as 'json' });
  }
}
