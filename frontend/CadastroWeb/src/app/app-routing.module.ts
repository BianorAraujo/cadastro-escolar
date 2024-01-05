import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { CadastrarComponent } from './pages/cadastrar/cadastrar.component';
import { EditarComponent } from './pages/editar/editar.component';
import { DetalhesComponent } from './pages/detalhes/detalhes.component';
import { HistoricoComponent } from './pages/historico/historico.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'cadastrar', component: CadastrarComponent},
  {path: 'editar/:id', component: EditarComponent},
  {path: 'detalhes/:id', component: DetalhesComponent},
  {path: 'historico/:id', component: HistoricoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
