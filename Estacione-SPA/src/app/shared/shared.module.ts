import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TotalOrdemComponent } from './componentes/ordem-total/total-ordem.component';
import {CdkStepperModule} from '@angular/cdk/stepper';
import { StepperComponent } from './componentes/stepper/stepper.component';
import { CestaSumarioComponent } from './componentes/cesta-sumario/cesta-sumario.component';
import { RouterModule } from '@angular/router';
import { TextInputComponent } from './componentes/text-input/text-input.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';



@NgModule({
  declarations: [TotalOrdemComponent, StepperComponent, CestaSumarioComponent, TextInputComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CdkStepperModule,
    RouterModule,
    BsDropdownModule.forRoot()
  ],
  exports: [
    ReactiveFormsModule,
    TotalOrdemComponent,
    CdkStepperModule,
    StepperComponent,
    CestaSumarioComponent,
    TextInputComponent,
    BsDropdownModule
  ]
})
export class SharedModule { }
