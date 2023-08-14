import { Component, OnInit } from '@angular/core';
import { AlunoService } from 'src/app/services/aluno.service';
import {MatTableModule} from '@angular/material/table';

import { NgFor } from '@angular/common';
import { FormBuilder,FormsModule, FormGroup, Validators } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { alunoViewModel } from 'src/app/viewModels/alunoViewModel';
import { historicoEscolarViewModel } from 'src/app/viewModels/historicoEscolarViewModel';
import { take } from 'rxjs';
import { Router } from '@angular/router';


@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css']
})
export class ListarComponent implements OnInit{
  rowData: any[] = [];
  displayedColumns: string[] = ['nome', 'sobrenome', 'email', 'escolaridade', 'dataNascimento','action'];
  dataSource = this.rowData;


  constructor(private alunoService: AlunoService, private router: Router,){}

  ngOnInit(): void {
    this.carregarListaAluno();    
  }

  carregarListaAluno()
  {
    this.alunoService.getAlunoList()
    .subscribe(res => {
      if(res.success == true) {
        this.rowData = res.data;
      }     
    });  
  }

  openDownload(element): void{
    const byteArray =new Uint8Array( atob(element.historicoEscolar.arquivo).split('').map((char)=>char.charCodeAt(0)));
    var typeFile = 'application/pdf';
    if(element.historicoEscolar.formato.toUpperCase() != 'PDF')
      typeFile = 'application/vnd.openxmlformats-officedocument.wordprocessingml.document';

    const file = new Blob([byteArray], {type: typeFile});
    const fileUrl= URL.createObjectURL(file);
    let fileName = element.historicoEscolar.nome;
    let link = document.createElement('a');
    link.download = fileName;
    link.target = '_blank';
    link.href = fileUrl;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }

  openDialog(element): void {
    element = element;
    var idAluno = element.id;
    console.log(idAluno);
    let originaldata=this.dataSource;
    this.router.navigate([`aluno/editar`], { queryParams: { id: idAluno } });
  }

  openDelete(element): void {
    element = element;
    var idAluno = element.id;
    console.log(idAluno);
    
    this.alunoService.delete(idAluno).toPromise()
    .then((res: any) => {
        if (res.success) {
          console.log('certo');
          this.carregarListaAluno(); 
            //this.onClickAcompanharDenuncia();

            //Swal.fire({
            //    title: 'SUCESSO!',
            //    type: 'success',
            //    html: '<p>A denúncia foi incluída com sucesso.</p><p> O protocolo é: <strong style="font-size: 21px; font-weight: bold;">' + res.data + '</strong></p>'
            //})
        }
        else {
            const message = res.errors.reduce((accumulator, current, index) => {
                if (index != res.errors.length - 1) {
                    return accumulator + `\n${current}`
                }
                return accumulator + "";

            })//const message = (res.errors.length > 0 ? res.errors[res.errors.length - 1] : "Não foi possível realizar a operação!");
            console.log(message);
            //this.toastr.warning(message);
        }
    }, (res) => {
        const message = (res.error.length > 0 ? res.error[res.error.length - 1] : res.message);
        console.log(message);
        //this.toastr.warning(message);
    });
  }

  insert() {
    this.router.navigate(['aluno/cadastrar']);
}
}
