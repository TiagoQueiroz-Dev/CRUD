import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { lastValueFrom } from "rxjs";
import { environment } from "../../../environments/environment";
import { AdicionarPessoaViewModel } from "../../../api";

@Injectable({
  providedIn: 'root'
})
export class PessoaService{

  private urlAPI = environment.apiUrl;

  constructor( private _httpClient: HttpClient){}

  async AdicionarPessoa(Pessoa: AdicionarPessoaViewModel){

    return await lastValueFrom(this._httpClient.post(`${this.urlAPI}/AdicionarPessoa`, Pessoa));

  }

}
