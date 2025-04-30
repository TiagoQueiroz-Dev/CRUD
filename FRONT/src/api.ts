// ..\bACK\core\domain\Entities\Pessoa.cs
export interface Pessoa {
    Id: number;
    CriadoDataHora: Date;
    Excluido: boolean;
    Nome: string;
    CPF: string;
    DataNascimento: Date;
    Genero: boolean;
}

// ..\bACK\core\aplication\viewModels\PessoaViewModels\AdicionarPessoaViewModel.cs
export interface AdicionarPessoaViewModel {
    Nome: string;
    CPF: string;
    DataNascimento: Date;
    Genero: boolean;
}
