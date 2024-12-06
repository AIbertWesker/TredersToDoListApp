import { Component } from '@angular/core';
import { Task } from '../task';
import { TaskManagerService } from '../task.manager.service';
import { ApplicationComponent } from '../application/application.component';

@Component({
  selector: 'app-task.edit',
  templateUrl: './task.edit.component.html',
  styleUrls: ['./task.edit.component.css']
})
export class TaskEditComponent {
  tasks: Task[] = [];

  constructor(private taskManagerService: TaskManagerService, private applicationComponent: ApplicationComponent) {}

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

  changeStatus(task: Task, newStatus: string): void {
    this.taskManagerService.getTaskById(task.id).subscribe(
      (fetchedTask: Task) => {
        this.taskManagerService.changeStatus(fetchedTask.id, newStatus).subscribe(
          (response: string) => {
            task.status = response;
            this.applicationComponent.displaySuccessMessage();
          },
          error => {
            this.applicationComponent.showError();
          }
        );
      },
      error => {
        this.applicationComponent.showError();
      }
    );
  }
}
