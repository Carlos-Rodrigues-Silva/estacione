import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CestaComprasService } from '../cesta-compras/cesta-compras.service';
import { Observable } from 'rxjs';
import { ICestaTotal } from '../shared/models/CestaCliente';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  totalCesta$: Observable<ICestaTotal>;

  constructor(private fb: FormBuilder, private cestaComprasService: CestaComprasService) { }

  ngOnInit() {
    this.criarFormCheckout();
    this.totalCesta$ = this.cestaComprasService.total$;
  }

  criarFormCheckout() {
    this.checkoutForm = this.fb.group({
      // reviewForm: this.fb.group({

      // }),
      pagamentoForm: this.fb.group({
        nomeNoCartao: [null, Validators.required]
      })
    });
  }
}
