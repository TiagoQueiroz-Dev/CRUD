import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectModule } from 'primeng/select';
import { DatePickerModule } from 'primeng/datepicker';
import { InputTextModule } from 'primeng/inputtext';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { RadioButtonModule } from 'primeng/radiobutton';
import { TextareaModule } from 'primeng/textarea';
import { CheckboxModule } from 'primeng/checkbox';
import { campoFormulario } from '../../data/campo_formulario';
import { InputMaskModule } from 'primeng/inputmask';


@Component({
  selector: 'app-formulario',
  imports: [
    CommonModule,
    SelectModule,
    DatePickerModule,
    InputTextModule,
    ReactiveFormsModule,
    InputTextModule,
    SelectModule,
    DatePickerModule,
    PasswordModule,
    RadioButtonModule,
    TextareaModule,
    CheckboxModule,
    InputMaskModule


  ],
  templateUrl: './formulario.component.html'
})
export class FormularioComponent implements OnInit {

  constructor(private fb: FormBuilder){}

  ngOnInit(): void {
     const controls = this.fb.control('', this.configuracao.validators || []);
      this.form.addControl(this.configuracao.nome, controls);
    };


  @Input() configuracao: campoFormulario
  @Input() form: FormGroup;
}
