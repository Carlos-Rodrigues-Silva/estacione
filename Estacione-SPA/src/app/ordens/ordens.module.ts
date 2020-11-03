import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdensRoutingModule } from './ordens-routing.module';
import { OrdensComponent } from './ordens.component';
import { OrdemDetalheComponent } from './ordem-detalhe/ordem-detalhe.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [OrdensComponent, OrdemDetalheComponent],
  imports: [
    CommonModule,
    OrdensRoutingModule,
    SharedModule
  ]
})
export class OrdensModule { }
