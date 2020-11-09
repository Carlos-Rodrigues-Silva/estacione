import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContaService } from '../conta.service';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.scss']
})
export class RegistrarComponent implements OnInit {
  registrarForm: FormGroup;

  constructor(private fb: FormBuilder, private contaService: ContaService, private router: Router) { }

  ngOnInit() {
    this.criarRegistrarForm();
  }

  criarRegistrarForm() {
    this.registrarForm = this.fb.group({
      displayName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      senha: [null, [Validators.required]]
    });
  }

  onSubmit() {
    this.contaService.registrar(this.registrarForm.value).subscribe(response => {
      this.router.navigateByUrl('/mapaendereco');
    }, error => {
      console.log(error);
    });
  }
}
