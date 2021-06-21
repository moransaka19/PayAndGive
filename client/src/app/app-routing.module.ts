import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddContainerComponent } from './add-container/add-container.component';
import { AddEatComponent } from './add-eat/add-eat.component';
import { LoginComponent } from './login/login.component';
import { AddMachineComponent } from './machines/add-machine/add-machine.component';
import { MachineDetailsComponent } from './machines/machine-details/machine-details.component';
import { MachinesComponent } from './machines/machines.component';
import { RegisterComponent } from './register/register.component';
import {BackupComponent} from "./backup/backup.component";


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
    path: 'backup/backup',
    component: BackupComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
