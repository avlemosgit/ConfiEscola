import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { alunoViewModel } from '../viewModels/alunoViewModel';
import { map } from 'rxjs';
import { ApiResponse, ApiResponseSingle } from '../interfaces/interfaces';

@Injectable({ providedIn: 'root' })
export class AlunoService {
  
  constructor(private http: HttpClient) { }

  public create(value: alunoViewModel)
  {    
    return this.http.post('v1/Aluno', value);
  }

  public update(value: alunoViewModel){
    return this.http.put('v1/Aluno', value);
  }
  
  public delete(value: string){
    return this.http.delete(`v1/Aluno/${value}`);
  }

  public getAluno(value: string) {
    return this.http.get<ApiResponse<any>>(`v1/Aluno/GetById/${value}`).pipe(
      map((response: ApiResponse<any>) => ({
        data: response.data,
        success: response.success,
      }))
    );
  }

  public getAlunoList() {
    return this.http.get<ApiResponse<any>>(`v1/Aluno`).pipe(
      map((response: ApiResponse<any>) => ({
        data: response.data,
        success: response.success,
      }))
    );
  }

  public getEscolaridadeList() {
    return this.http.get<ApiResponse<any>>(`v1/Aluno/GetEscolaridade`).pipe(
      map((response: ApiResponse<any>) => ({
        data: response.data,
        success: response.success,
      }))
    );
  }
}
