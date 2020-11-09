import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContaService } from '../conta.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(private contaService: ContaService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/mapaendereco';
    this.criarLoginForm();
  }

  criarLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      senha: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    // console.log(this.loginForm.value);
    this.contaService.login(this.loginForm.value).subscribe(() => {
      // this.router.navigateByUrl('/mapaendereco');
      this.router.navigateByUrl(this.returnUrl);
      console.log('usuário logado');
    }, error => {
      console.log(error);
    });
  }
}
