// ..\bACK\core\domain\Entities\Pessoa.cs
export interface Pessoa extends EntidadeBase {
    Nome: string;
    CPF: string;
    DataNascimento: string;
    Genero: number;
}

// ..\bACK\core\application\ViewModels\PessoaViewModels\AdicionarPessoaViewModel.cs
export interface AdicionarPessoaViewModel {
    Nome: string;
    CPF: string;
    DataNascimento: string;
    Genero: number;
}

// ..\bACK\core\domain\Entities\EntidadeBase\EntidadeBase.cs
export interface EntidadeBase {
    Id: number;
    Excluido: boolean;
    CriadoDataHora: string;
}
