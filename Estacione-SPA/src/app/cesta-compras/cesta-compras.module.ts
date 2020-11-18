import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CestaComprasComponent } from './cesta-compras.component';
import { CestaComprasRoutingModule } from './cesta-compras-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [CestaComprasComponent],
  imports: [
    CommonModule,
    CestaComprasRoutingModule,
    SharedModule
  ],
})
export class CestaComprasModule { }
