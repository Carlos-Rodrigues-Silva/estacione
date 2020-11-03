import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CestaComprasComponent } from './cesta-compras.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: '', component: CestaComprasComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class CestaComprasRoutingModule { }
