import { Validators } from "@angular/forms";
import { campoFormulario } from "../../shared/data/campo_formulario";

export class homeCampos {


  obterCampos(): campoFormulario[]{
    const campos: campoFormulario[] = [
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



    return campos;
  }

}
