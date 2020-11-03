import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CheckoutComponent } from './checkout.component';
import { CheckoutSucessoComponent } from './checkout-sucesso/checkout-sucesso.component';

const routes: Routes = [
  {path: '', component: CheckoutComponent},
  {path: 'sucesso', component: CheckoutSucessoComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class CheckoutRoutingModule { }
