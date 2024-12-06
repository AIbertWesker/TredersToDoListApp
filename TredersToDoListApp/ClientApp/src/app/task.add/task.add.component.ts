import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Task } from '../task';
import { TaskManagerService } from '../task.manager.service';
import { ApplicationComponent } from '../application/application.component';

@Component({
  selector: 'app-task.add',
  templateUrl: './task.add.component.html',
  styleUrls: ['./task.add.component.css']
})
export class TaskAddComponent {
  taskForm: FormGroup;

  constructor(private fb: FormBuilder, private taskManagerService: TaskManagerService, private applicationComponent: ApplicationComponent) {
    this.taskForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      status: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.taskForm.valid) {
      const task: Task = {
        id: 0,
        name: this.taskForm.value.name,
        description: this.taskForm.value.description || null,
        status: this.taskForm.value.status
      };
  
      this.taskManagerService.addTask(task).subscribe(
        response => {
          this.applicationComponent.displaySuccessMessage();
        },
        error => {
          this.applicationComponent.showError();
        }
      );
    }
  }
}
