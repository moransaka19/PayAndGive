import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';
import {MachinesComponent} from './machines/machines.component';
import {AddMachineComponent} from './machines/add-machine/add-machine.component';
import {MachineDetailsComponent} from './machines/machine-details/machine-details.component';
import {AddContainerComponent} from './add-container/add-container.component';
import {AddEatComponent} from './add-eat/add-eat.component';
import {ReportComponent} from './report/report.component';
import {BackupDatabaseComponent} from "./backup-database/backup-database.component";



const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'login'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'machines',
    component: MachinesComponent
  },
  {
    path: 'machines/add',
    component: AddMachineComponent
  },
  {
    path: 'machines/:id',
    component: MachineDetailsComponent
  },
  {
    path: 'machines/:id/add-container',
    component: AddContainerComponent
  },
  {
    path: 'eat/add',
    component: AddEatComponent
  },
  {
    path: 'backup-database',
    component: BackupDatabaseComponent
  },
  {
    path: 'report',
    component: ReportComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
