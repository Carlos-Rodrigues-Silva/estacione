import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrarComponent } from './registrar/registrar.component';
import { LoginComponent } from './login/login.component';
import { ContaRoutingModule } from './conta-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [RegistrarComponent, LoginComponent],
  imports: [
    CommonModule,
    ContaRoutingModule,
    SharedModule
  ]
})
export class ContaModule { }
