import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MapaEnderecoComponent } from './mapa-endereco.component';
import { EnderecoComponent } from './endereco/endereco.component';

const routes: Routes = [
  // root component do módulo mapa
  {path: '', component: MapaEnderecoComponent},
  {path: 'endereco', component: EnderecoComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    // forChild - significa que esses routes não estará disponível no AppModule
    // estará somente no módulo MapaEndereco
    RouterModule.forChild(routes)
  ],
  // Exportar RouterModule para ser usado dentro do MapaEnderecoModule
  exports: [RouterModule]
})
export class MapaEnderecoRoutingModule { }
