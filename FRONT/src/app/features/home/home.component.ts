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
import { MessageService } from 'primeng/api';

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
providers: [MessageService],
  templateUrl: './home.component.html'
})
export class HomeComponent {

  constructor(
    private _pessoaService: PessoaService
    , private fb: FormBuilder
    , private messageService: MessageService
  ){}

  formulario: FormGroup;
  Resultado: AdicionarPessoaViewModel;
  campos: campoFormulario[];
  erro: string;




  ngOnInit() {
    this.configurarCampos();
    this.formulario = this.fb.group({});
  }

  mapearFormulario(){
    this.Resultado = {
      Nome: this.formulario.value.nome,
      CPF: this.formulario.value.cpf,
      DataNascimento: new Date(this.formulario.value.idade).toISOString(),
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
          { nome: 'Masculino', value: 1 },
          { nome: 'Feminino', value: 2 }
        ],
        validators: [Validators.required]
      }
    ];
  }

  async enviar() {
    this.mapearFormulario();
    try {
      const retornoApi = await this._pessoaService.AdicionarPessoa(this.Resultado);

        this.messageService.add(
        {
          severity: 'success'
          , summary: 'Sucesso'
          , detail: 'Pessoa Adicionada com sucesso! ID: ' + retornoApi
          , life: 2000
        });
    } catch (error) {

      const erro = error.error?.detail || error.message;
      this.messageService.add(
        {
          severity: 'error'
          , summary: 'Erro'
          , detail: 'Não foi possivel Adicionar a pessoa: ' + erro
          , life: 2000
        });
    }
  }

}
