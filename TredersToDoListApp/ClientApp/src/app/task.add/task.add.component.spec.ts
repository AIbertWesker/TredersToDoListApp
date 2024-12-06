import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskAddComponent } from './task.add.component';

describe('TaskAddComponent', () => {
  let component: TaskAddComponent;
  let fixture: ComponentFixture<TaskAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TaskAddComponent]
    });
    fixture = TestBed.createComponent(TaskAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
