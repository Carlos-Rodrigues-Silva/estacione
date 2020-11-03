import { Component, OnInit, Input, AfterViewInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CestaComprasService } from 'src/app/cesta-compras/cesta-compras.service';
import { CheckoutService } from '../checkout.service';
// import { ToastrService } from 'ngx-toastr';
import { ICestaCliente } from 'src/app/shared/models/CestaCliente';
import { IOrdem } from 'src/app/shared/models/ordem';
import { Router, NavigationExtras } from '@angular/router';
import { Observable } from 'rxjs';
import { CdkStepper } from '@angular/cdk/stepper';

declare var Stripe;


@Component({
  selector: 'app-checkout-pagamento',
  templateUrl: './checkout-pagamento.component.html',
  styleUrls: ['./checkout-pagamento.component.scss']
})
export class CheckoutPagamentoComponent implements AfterViewInit, OnDestroy {
  @Input() checkoutForm: FormGroup;
  @ViewChild('cardNumber', {static: true}) cardNumberElemento: ElementRef;
  @ViewChild('cardExpiry', {static: true}) cardExpiryElemento: ElementRef;
  @ViewChild('cardCvc', {static: true}) cardCvcElemento: ElementRef;

  //usar any pois stripe não é typescript e sim javascript
  stripe: any;
  cardNumber: any;
  cardExpiry: any;
  cardCvc: any;
  cardErrors: any;
  cardHandler = this.onChange.bind(this);


  // cesta$: Observable<ICestaCliente>;

  constructor(private cestaService: CestaComprasService,
              private checkoutService: CheckoutService,
              /*private toastr: ToastrService*/
              private router: Router) { }

  ngAfterViewInit(): void {
    this.stripe = Stripe('pk_test_51Gz99yFiPxM3T220S4cGxwZqfFSg6cbWudX8FlnMo2IukejclCezVP1pc9LN0BEvucf1v6IrZQZXHniWmM3bLDJB00GEPupS3C');
    const elements = this.stripe.elements();

    this.cardNumber = elements.create('cardNumber');
    this.cardNumber.mount(this.cardNumberElemento.nativeElement);
    this.cardNumber.addEventListener('change', this.cardHandler);

    this.cardExpiry = elements.create('cardExpiry');
    this.cardExpiry.mount(this.cardExpiryElemento.nativeElement);
    this.cardExpiry.addEventListener('change', this.cardHandler);

    this.cardCvc = elements.create('cardCvc');
    this.cardCvc.mount(this.cardCvcElemento.nativeElement);
    this.cardCvc.addEventListener('change', this.cardHandler);
  }

  ngOnDestroy() {
    this.cardNumber.destroy();
    this.cardExpiry.destroy();
    this.cardCvc.destroy();
  }

  onChange({error}) {
    if (error) {
      this.cardErrors = error.message;
    } else {
      this.cardErrors = null;
    }
  }

  // ngOnInit() {
  //   // this.cesta$ = this.cestaService.cesta$;
  //   // const cestaAtual = this.cestaService.getCurrentBasketValue();
  //   // console.log(cestaAtual.id + " Cesta atual de teste cara");
  // }

  submitOrdem() {
    const cesta = this.cestaService.getCurrentBasketValue();
    const ordemParaSerCriada = this.obterOrdemParaSerCriada(cesta);
    this.checkoutService.CriarOrdem(ordemParaSerCriada).subscribe((ordem: IOrdem) => {
      this.stripe.confirmCardPayment(cesta.clientSecret, {
        payment_method: {
          card: this.cardNumber,
          billing_details: {
            name: this.checkoutForm.get('pagamentoForm').get('nomeNoCartao').value
          }
        }
      }).then(result => {
        if (result.paymentIntent) {
          // this.toastr.success('Ordem criada com sucesso');
          this.cestaService.removerCestaLocal(cesta.id);
          const navigationExtras: NavigationExtras = {state: ordem};
          this.router.navigate(['checkout/sucesso'], navigationExtras);
        } else {
          console.log('Payment error');
        }
      });
    }, error => {
      // this.toastr.error(error.message);
      console.log(error);
    });
  }

  private obterOrdemParaSerCriada(cesta: ICestaCliente) {
    return {
      cestaId: cesta.id,
      email: 'carlos-rodrigues-silva@gmail.com'
    };
  }



}
