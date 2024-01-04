import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../../models/Usuario';
import { ExcluirComponent } from '../../componentes/excluir/excluir.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  usuarios: Usuario[] = [];
  usuariosGeral: Usuario[] = [];

  colunas = ['Nome', 'Sobrenome', 'Email', 'DataNascimento', 'Escolaridade', 'Acoes'];

  constructor(private usuarioService: UsuarioService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.usuarioService.GetUsuarios().subscribe(data => {
      const dados = data;

      dados.map((item) => {
        item.dataNascimento = new Date(item.dataNascimento!).toLocaleDateString('pt-BR');
      })

      this.usuarios = data;
      this.usuariosGeral = data;

      console.log(this.usuarios);
    });
  }

  search(event : Event) {
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.usuarios = this.usuariosGeral.filter(usuario => {
      return usuario.nome.toLowerCase().includes(value);
    })
  }

  openDialog(id: number){
    this.dialog.open(ExcluirComponent, {
      width: '320px',
      height: '300px',
      data: {
        id: id
      }
    });
  }

}
