import { NgModule } from '@angular/core';
import { AlunoRoutingModule } from './aluno.routing.module';
import { ListarComponent } from './listar/listar.component';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { EditarComponent } from './editar/editar.component';
import { SharedModule } from '../shared/shared.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDateSelectionModel, MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MAT_DATE_LOCALE } from '@angular/material/core'


@NgModule({
  
  imports: [AlunoRoutingModule, SharedModule, MatFormFieldModule, MatDatepickerModule, MatInputModule, MatDatepickerModule, MatNativeDateModule, MatSelectModule, MatTableModule,
    CommonModule, FormsModule,
    
  ],
  declarations: [ListarComponent, CadastrarComponent, EditarComponent],
  bootstrap:[],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' }
  ]
})
export class AlunoModule { }
