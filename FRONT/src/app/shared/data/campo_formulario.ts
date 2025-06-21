export class campoFormulario {
  nome: string
  tipo: string
  label: string
  mascara?: string;
  maxLength?: number;
  validators: any[];
  placeholder?: string;
  options?: { nome: string, value: number }[];
  required?: boolean;
}
