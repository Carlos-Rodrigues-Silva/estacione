import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapaEnderecoComponent } from './mapa-endereco.component';
import { EnderecoComponent } from './endereco/endereco.component';
import { MapaEnderecoRoutingModule } from './mapa-endereco-routing.module';
import { AgmCoreModule } from '@agm/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [MapaEnderecoComponent, EnderecoComponent],
  imports: [
    CommonModule,
    MapaEnderecoRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCX_AvtVNCQdY8I_6Gxe6-YgqEo1vMEAqc'
    }),
    ReactiveFormsModule
  ]
})
export class MapaEnderecoModule { }
