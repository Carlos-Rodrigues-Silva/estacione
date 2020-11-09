import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapaEnderecoComponent } from './mapa-endereco/mapa-endereco.component';
import { HomeComponent } from './home/home.component';
import { CestaComprasComponent } from './cesta-compras/cesta-compras.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutSucessoComponent } from './checkout/checkout-sucesso/checkout-sucesso.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  // {path: 'mapaendereco', component: MapaEnderecoComponent},
  {path: 'mapaendereco', loadChildren: () => import('./mapa-endereco/mapa-endereco.module').then(mod => mod.MapaEnderecoModule)},
  // {path: 'cesta', component: CestaComprasComponent},
  {path: 'cesta', loadChildren: () => import('./cesta-compras/cesta-compras.module').then(mod => mod.CestaComprasModule)},
  // {path: 'checkout', component: CheckoutComponent},
  {path: 'checkout', canActivate: [AuthGuard], loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule)},
  // {path: 'checkout/sucesso', component: CheckoutSucessoComponent},
  // {path: 'checkout/sucesso', loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule)},
  {path: 'ordens', loadChildren: () => import('./ordens/ordens.module').then(mod => mod.OrdensModule)},
  {path: 'conta', loadChildren: () => import('./conta/conta.module').then(mod => mod.ContaModule)},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
