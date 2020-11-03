import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { CheckoutRoutingModule } from './checkout-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CheckoutReviewComponent } from './checkout-review/checkout-review.component';
import { CheckoutPagamentoComponent } from './checkout-pagamento/checkout-pagamento.component';
import { CheckoutSucessoComponent } from './checkout-sucesso/checkout-sucesso.component';



@NgModule({
  declarations: [CheckoutComponent, CheckoutReviewComponent, CheckoutPagamentoComponent, CheckoutSucessoComponent],
  imports: [
    CommonModule,
    CheckoutRoutingModule,
    SharedModule
  ]
  // exports: [CheckoutModule]
})
export class CheckoutModule { }
