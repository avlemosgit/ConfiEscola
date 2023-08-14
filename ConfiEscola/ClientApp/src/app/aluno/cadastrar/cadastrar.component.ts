import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NgFor } from '@angular/common';
import { FormBuilder,FormsModule, ReactiveFormsModule, FormArray, FormGroup, Validators } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { alunoViewModel } from 'src/app/viewModels/alunoViewModel';
import { AlunoService } from 'src/app/services/aluno.service';
import { historicoEscolarViewModel } from 'src/app/viewModels/historicoEscolarViewModel';
import { take } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html',
  styleUrls: ['./cadastrar.component.css'],
})
export class CadastrarComponent implements OnInit{
  formAluno!: FormGroup;
  base64:any;
  alunoViewModel!: alunoViewModel;
  historicoEscolar!: historicoEscolarViewModel;
  @ViewChild('inputFile') public inputFile!: ElementRef;
  comboEscolaridade: any[] = [];
  maxDate: Date = new Date();

  constructor(
    private fb: FormBuilder,
    private alunoService: AlunoService,
    private router:Router,
  
  ) { 
    //this.maxDate = new Date();   
    
    
  }
  
  get email() { return this.formAluno.get('email'); };

  ngOnInit()
  {
    console.log(this.maxDate);
    this.getEscolaridadeOptions();
    
    this.formAluno = this.fb.group({
      id: [0],
      nome: [null, [Validators.required]],
      sobrenome: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]],
      dataNascimento: [null, [Validators.required]],
      escolaridadeId: [null, [Validators.required]],
    });
  }


  getEscolaridadeOptions() {
    this.alunoService
      .getEscolaridadeList()      
      .pipe(take(1))
      .subscribe({
        next: (res) => {
          if (res.success) {
            if (res.data.length > 0) {
              console.log(res.data);
              this.comboEscolaridade = res.data;
            }
          }
        },
        error: (e) => console.error(e?.message),
      });
  }

  onSubmit(){  
    this.alunoViewModel = this.formAluno.value;
    if(this.historicoEscolar.formato.toUpperCase()=='PDF')
      this.base64= this.base64.replace('data:application/pdf;base64,','');
    else
      this.base64= this.base64.replace('data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,','');
    
    this.historicoEscolar.setArquivo(this.base64);
    this.alunoViewModel.historicoEscolar = this.historicoEscolar;
    this.alunoService.create(this.alunoViewModel).toPromise()
    .then((res: any) => {
        if (res.success) {
          console.log('certo');
          this.router.navigate(['aluno/listar']); 

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

  onCancel()
  {
    this.router.navigate(['aluno/listar']); 
  }

  openBrowseFile() {
    this.inputFile.nativeElement.click();
  }

  onSelectFile(event) {
    // var rowDataResult: AnexosViewModel[] = [];
    // if (this.rowDataAnexos.length > 0) {
    //     this.rowDataAnexos.map((item) => {
    //         rowDataResult.push(item);
    //     });
    // }
    if (event.target.files && event.target.files[0]) {
        var filesAmount = event.target.files.length;
        for (let i = 0; i < filesAmount; i++) {
            var reader = new FileReader();
            var fullFileName: string = event.target.files[i].name;
            var mimeType: string = event.target.files[i].type;
            var indexExtension = fullFileName.lastIndexOf('.');
            var fileExtension = this.validarExtensao(indexExtension, fullFileName);
            //var fileSize = this.validarTamanhoArquivo(rowDataResult, event.target.files[i].size, fileExtension, fullFileName);
            //var isValidFileName = this.validarNomeArquivo(rowDataResult, fullFileName);
             if (fileExtension != null) {                   
              //var item = new historicoEscolarViewModel(fileExtension, fullFileName);
            //     rowDataResult.push(item);
            //     var form = new AnexosViewModel(null, fullFileName, fileExtension, fileSize, null, EnumTipoAnexo.Denuncia, mimeType);
            //     this.objDenuncia.denunciaAnexo.push(form);
                  
            
            reader.onload = (e) => {
              this.base64 = reader.result;
              console.log('the res', this.base64);
            };
            reader.readAsDataURL(event.target.files[i]);
            
            this.historicoEscolar = new historicoEscolarViewModel(0, fileExtension, fullFileName);
            
                  
                  // reader.onload = (event: any) => {
                  //    var fileByteArray = [];
                          // const byteArray = new Uint8Array(atob())
                          // var fileByteArray = [];
                          // reader.onload = (event: any) => {
                          //   const bytes = event.target.result.split('base64,')[1];    
                          //   this.historicoEscolar.setArquivo(bytes);

                      //for (var i = 0; i < array.length; i++) {
                        
                        //  fileByteArray.push(array[i]);
                      //}
                  //};
                  //    var array = new Uint8Array(event.target.result);
                  //    for (var i = 0; i < array.length; i++) {
                  //        fileByteArray.push(array[i]);
                  //    }                     
                                          

            //         this.currentUploadItems--;
            //         if (this.currentUploadItems == 0)
            //             this.spinner.hide();
            //     };

            //     if (this.currentUploadItems == 0)
            //         this.spinner.show();
            //     this.currentUploadItems++;

            //     reader.readAsArrayBuffer(event.target.files[i]);
             } else {

             }
        }
        this.inputFile.nativeElement.value = "";
    }
    //this.rowDataAnexos = rowDataResult;
}

validarExtensao(indexExtension: number, fullFileName: string): string {
  
  var result: string='';
  var validExtensions = ['pdf', 'doc','docx'];

  if (indexExtension > 0) {
      var extension = fullFileName.substr(indexExtension + 1).toLowerCase();
      if (validExtensions.includes(extension))
          result = extension.toUpperCase();
      else
          this.mensagemTipoArquivoInvalido(extension, fullFileName);//this.toastr.warning(`O documento ${fullFileName} não foi anexado, pois o tipo de arquivo ${extension} é inválido para esta operação.`, 'Falha ao anexar');
  }
  //else
      //this.toastr.warning(`O documento ${fullFileName} não foi anexado, pois não foi possível identificar o tipo do arquivo.`, 'Falha ao anexar');

  return result;
}

mensagemTipoArquivoInvalido(tipo: string, fullFileName: string){
  let knowTypes = [
      ["PPT", "PPTX", "PPS", "PowerPoint"],
      ["XLS","XLSX","Excel"],
      ["MSG","PST", "OST","Outlook"],
      ["AACCDB","ACCDE","Access"]
  ]
  let mensagem = "Não foi possível anexar o documento";

  // if(!isNullOrUndefinedOrEmpty(tipo)){
  //     let filtro = knowTypes.filter(value => value.includes(tipo.toUpperCase()));
  //     if(filtro.length > 0){
  //         mensagem = `Não é permitido anexar arquivo em ${filtro[0][filtro[0].length - 1]}`
  //     }else
  //         mensagem = `Não é permitido anexar o arquivo \"${fullFileName}\", a extensão \"${tipo}\" é inválida`;
  // }
  // this.toastr.warning(mensagem, "Falha ao Anexar");
}

}
