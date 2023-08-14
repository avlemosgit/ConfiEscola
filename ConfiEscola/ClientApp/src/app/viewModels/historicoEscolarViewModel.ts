export class historicoEscolarViewModel{
    id:number
    formato: string
    nome: string
    arquivo: any

    constructor(id: number, formato: string, nome: string)
    {   
        this.id=id;
        this.formato=formato;
        this.nome=nome;
    }

    public setArquivo(arquivo:any)
    {
        this.arquivo=arquivo;
    }
}