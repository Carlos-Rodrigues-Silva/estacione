import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MapaEnderecoComponent } from './mapa-endereco.component';
import { EnderecoComponent } from './endereco/endereco.component';

const routes: Routes = [
  {path: '', component: MapaEnderecoComponent},
  {path: 'endereco', component: EnderecoComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class MapaEnderecoRoutingModule { }
