import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './core/nav-bar/nav-bar.component';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from './core/core.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AgmCoreModule } from '@agm/core';
import { HomeModule } from './home/home.module';
import { HomeComponent } from './home/home.component';
import { MapaEnderecoComponent } from './mapa-endereco/mapa-endereco.component';
import { EnderecoComponent } from './mapa-endereco/endereco/endereco.component';
import { CestaComprasComponent } from './cesta-compras/cesta-compras.component';
import { SharedModule } from './shared/shared.module';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutReviewComponent } from './checkout/checkout-review/checkout-review.component';
import { CheckoutPagamentoComponent } from './checkout/checkout-pagamento/checkout-pagamento.component';
import { CheckoutSucessoComponent } from './checkout/checkout-sucesso/checkout-sucesso.component';
import { MapaEnderecoModule } from './mapa-endereco/mapa-endereco.module';
import { CestaComprasModule } from './cesta-compras/cesta-compras.module';
import { CheckoutModule } from './checkout/checkout.module';


@NgModule({
  // Propriedade responsável por fornecer para todo o app uma lista de componentes e diretivas
  // Componetes, diretivas, pipes que pertencem a esse módulo
  declarations: [
    AppComponent,
    // HomeComponent,
    // MapaEnderecoComponent,
    // EnderecoComponent,
    // CestaComprasComponent,
    // CheckoutComponent,
    // CheckoutReviewComponent,
    // CheckoutPagamentoComponent,
    // CheckoutSucessoComponent
  ],
  // Lista de outros módulos no qual esse módulo é dependente
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    // ReactiveFormsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCX_AvtVNCQdY8I_6Gxe6-YgqEo1vMEAqc'
    }),
    // FormsModule,
    CoreModule,
    HomeModule,
    // MapaEnderecoModule,
    // CestaComprasModule,
    // CheckoutModule

  ],
  // providers: [] todos os Services criados devem ser listados aqui
  
  // Services criados podem ser listados aqui para serem acessados por todo o app. Mas o
  // melhor é usar depedency injection e adicionar o services no construtor dos componentes
  providers: [],
  // Lista qual componente deve ser iniciado ao rodar a aplicação
  bootstrap: [AppComponent]
})
export class AppModule { }
