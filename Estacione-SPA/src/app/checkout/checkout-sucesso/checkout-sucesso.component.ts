import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IOrdem } from 'src/app/shared/models/ordem';

@Component({
  selector: 'app-checkout-sucesso',
  templateUrl: './checkout-sucesso.component.html',
  styleUrls: ['./checkout-sucesso.component.scss']
})
export class CheckoutSucessoComponent implements OnInit {
  ordem: IOrdem;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation && navigation.extras && navigation.extras.state;
    if (state) {
      this.ordem = state as IOrdem;
    }
  }

  ngOnInit() {
  }

}
