import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
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
import { FormularioComponent } from "../../shared/components/formulario/formulario.component";
import { campoFormulario } from '../../shared/data/campo_formulario';

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
    DatePickerModule,
    FormularioComponent
],
  templateUrl: './home.component.html'
})
export class HomeComponent {

  constructor(
    private _pessoaService: PessoaService
    , private fb: FormBuilder
  ){}

  formulario: FormGroup;
  Resultado: AdicionarPessoaViewModel;
  campos: campoFormulario[];




  ngOnInit() {
    this.configurarCampos();
    this.formulario = this.fb.group({});
  }

  mapearFormulario(){
    this.Resultado = {
      Nome: this.formulario.value.nome,
      CPF: this.formulario.value.cpf,
      DataNascimento: new Date(this.formulario.value.idade),
      Genero: this.formulario.value.sexo.value
    }
  }

  configurarCampos(){
    this.campos = [
      {
        nome: 'cpf',
        tipo: 'text',
        label: 'CPF',
        mascara: '999.999.999-99',
        required: true,
        maxLength: 14,
        validators: [Validators.required]
      },
      {
        nome: 'nome',
        tipo: 'text',
        label: 'Nome completo',
        required: true,
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
  }

  enviar() {
    this.mapearFormulario();
    this._pessoaService.AdicionarPessoa(this.Resultado);
  }

}
