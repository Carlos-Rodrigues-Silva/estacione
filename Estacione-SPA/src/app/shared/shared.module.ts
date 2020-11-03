import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TotalOrdemComponent } from './componentes/ordem-total/total-ordem.component';
import {CdkStepperModule} from '@angular/cdk/stepper';
import { StepperComponent } from './componentes/stepper/stepper.component';
import { CestaSumarioComponent } from './componentes/cesta-sumario/cesta-sumario.component';
import { RouterModule } from '@angular/router';
import { TextInputComponent } from './componentes/text-input/text-input.component';



@NgModule({
  declarations: [TotalOrdemComponent, StepperComponent, CestaSumarioComponent, TextInputComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CdkStepperModule,
    RouterModule
  ],
  exports: [
    ReactiveFormsModule,
    TotalOrdemComponent,
    CdkStepperModule,
    StepperComponent,
    CestaSumarioComponent,
    TextInputComponent
  ]
})
export class SharedModule { }
