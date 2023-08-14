import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ListarComponent } from './aluno/listar/listar.component';
import { CadastrarComponent } from './aluno/cadastrar/cadastrar.component';
import { EditarComponent } from './aluno/editar/editar.component';


const routes: Routes = [
  //{ path: '', loadChildren: () => import('./aluno/aluno.module').then(x => x.AlunoModule), pathMatch:'full' },
   { path: '', component: HomeComponent, pathMatch: 'full' },
  // { path: 'counter', component: CounterComponent },
  // { path: 'fetch-data', component: FetchDataComponent },
  { path: 'aluno', loadChildren: () => import('./aluno/aluno.module').then(x => x.AlunoModule) },
  //{ path: 'listar', component: ListarComponent },
  //{ path: 'cadastrar', component: CadastrarComponent },
  //{ path: 'editar', component: EditarComponent },
];


@NgModule({
  imports: [
    RouterModule.forRoot(routes)],
  exports: [RouterModule],  
})
export class AppRoutingModule { }
