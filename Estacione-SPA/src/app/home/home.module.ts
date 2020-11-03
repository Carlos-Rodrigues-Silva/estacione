import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';



@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule
  ],
  // Exportar o HomeComponent
  exports: [HomeComponent]
})
export class HomeModule { }
