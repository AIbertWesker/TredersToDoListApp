import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationComponent } from './application/application.component';
import { TaskAddComponent } from './task.add/task.add.component';
import { TaskEditComponent } from './task.edit/task.edit.component';
import { TaskDeleteComponent } from './task.delete/task.delete.component';
import { TaskHomeComponent } from './task.home/task.home.component';

const routes: Routes = [
  { path: '', redirectTo: '/application', pathMatch: 'full'},
  { path: 'application', component: ApplicationComponent, children:
    [
      { path : 'home', component: TaskHomeComponent },
      { path: 'add', component: TaskAddComponent },
      { path: 'edit', component: TaskEditComponent },
      { path: 'delete', component: TaskDeleteComponent }
    ]
   },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
