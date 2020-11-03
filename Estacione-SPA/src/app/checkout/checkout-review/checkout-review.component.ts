import { Component, OnInit, Input } from '@angular/core';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';
import { Cesta, ICestaCliente } from 'src/app/shared/models/CestaCliente';
import { Observable } from 'rxjs';
import { CheckoutService } from '../checkout.service';
import { CdkStepper } from '@angular/cdk/stepper';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent implements OnInit {
  @Input() appStepper: CdkStepper;
  cesta$: Observable <ICestaCliente>;

  constructor(private cestaComprasService: CestaComprasService, private checkoutService: CheckoutService) { }

  ngOnInit() {
    this.cesta$ = this.cestaComprasService.cesta$;
  }

  criarIntencaoPagamento() {
    return this.cestaComprasService.criarIntencaoPagamento().subscribe((response: any) => {
      this.appStepper.next();
    });
  }
}
