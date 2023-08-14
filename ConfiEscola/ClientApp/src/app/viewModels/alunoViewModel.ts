import { historicoEscolarViewModel } from "./historicoEscolarViewModel";

export class alunoViewModel{
    id: number;
    nome: string;
    sobrenome: string;
    email: string;
    dataNascimento:string;
    escolaridadeId:number;
    historicoEscolar: historicoEscolarViewModel

    constructor(data: alunoViewModel)
    {   
      this.id=data.id;   
      this.dataNascimento=data.dataNascimento;
      this.email=data.email;
      this.escolaridadeId = data.escolaridadeId;
      this.historicoEscolar=data.historicoEscolar;
      this.nome=data.nome;
      this.sobrenome=data.sobrenome;
    }
}
