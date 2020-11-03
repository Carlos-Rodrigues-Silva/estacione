import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdensComponent } from './ordens.component';
import { Routes, RouterModule } from '@angular/router';
import { OrdemDetalheComponent } from './ordem-detalhe/ordem-detalhe.component';

const routes: Routes = [
  {path: '', component: OrdensComponent},
  {path: ':id', component: OrdemDetalheComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdensRoutingModule { }
