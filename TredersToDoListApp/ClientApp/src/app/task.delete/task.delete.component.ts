import { Component } from '@angular/core';
import { Task } from '../task';
import { TaskManagerService } from '../task.manager.service';
import { ApplicationComponent } from '../application/application.component';

@Component({
  selector: 'app-task.delete',
  templateUrl: './task.delete.component.html',
  styleUrls: ['./task.delete.component.css']
})
export class TaskDeleteComponent {
  tasks: Task[] = [];

  constructor(
    private taskManagerService: TaskManagerService,
    private applicationComponent: ApplicationComponent
  ) {}

  ngOnInit(): void {
    this.fetchTasks();
  }

  fetchTasks(): void {
    this.taskManagerService.getTasks().subscribe(
      (response: Task[]) => {
        this.tasks = response;
        localStorage.setItem('tasks', JSON.stringify(response));
      },
      error => {
        this.applicationComponent.showError();
      }
    );
  }

  deleteTask(task: Task): void {
    this.taskManagerService.deleteTask(task.id).subscribe(
      () => {
        this.tasks = this.tasks.filter(t => t.id !== task.id);
        this.applicationComponent.displaySuccessMessage();
      },
      error => {
        this.applicationComponent.showError();
      }
    );
  }
}
