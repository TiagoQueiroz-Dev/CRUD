import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { PessoaService } from './home.service';
import { AdicionarPessoaViewModel } from '../../../api';

@Component({
  selector: 'app-home',
  imports: [
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    CheckboxModule,
    CommonModule,
    InputNumberModule,
    InputTextModule,
    SelectModule,
    DatePickerModule
  ],
  templateUrl: './home.component.html'
})
export class HomeComponent {

  constructor(private _pessoaService: PessoaService){}

  formulario!: FormGroup;
  Resultado!: AdicionarPessoaViewModel;

  campo = [
    {
      nome: 'cpf',
      tipo: 'text',
      label: 'CPF',
      mascara: '999.999.999-99',
      maxLength: 14,
      validators: [Validators.required]
    },
    {
      nome: 'nome',
      tipo: 'text',
      label: 'Nome completo',
      placeholder: 'Digite seu nome',
      maxLength: 50,
      validators: [Validators.required]
    },
    {
      nome: 'idade',
      tipo: 'date',
      label: 'Data Nascimento',
      validators: [Validators.required]
    },
    {
      nome: 'sexo',
      tipo: 'select',
      label: 'Sexo',
      options: [
        { nome: 'Masculino', value: true },
        { nome: 'Feminino', value: false }
      ],
      validators: [Validators.required]
    }
  ];


  ngOnInit() {
    const group: any = {};
    this.campo.forEach(campos => {
      group[campos.nome] = new FormControl('', campos.validators);
    });
    this.formulario = new FormGroup(group);
  }

  mapearFormulario(){
    this.Resultado = {
      Nome: this.formulario.value.nome,
      CPF: this.formulario.value.cpf,
      DataNascimento: new Date(this.formulario.value.idade),
      Genero: this.formulario.value.sexo.value
    }
  }

  enviar() {
    this.mapearFormulario();
    console.log(this.Resultado);
    this._pessoaService.AdicionarPessoa(this.Resultado);
  }

}
