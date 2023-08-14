import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarComponent } from './listar/listar.component';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EditarComponent } from './editar/editar.component';

const routes: Routes = [ 
  { path: 'listar', component: ListarComponent },
  { path: 'cadastrar', component: CadastrarComponent},
  { path: 'editar', component: EditarComponent}          
];
//{ path: '', redirectTo: 'listar' },

@NgModule({
  imports: [
    RouterModule.forChild(routes), SharedModule,],
  exports: [RouterModule]
})
export class AlunoRoutingModule { }
