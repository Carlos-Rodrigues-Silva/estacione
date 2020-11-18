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

  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCX_AvtVNCQdY8I_6Gxe6-YgqEo1vMEAqc'
    }),
    CoreModule,
    HomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
