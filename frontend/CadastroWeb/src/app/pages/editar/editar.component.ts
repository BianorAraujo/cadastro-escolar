import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../models/Usuario';
import { UsuarioService } from '../../services/usuario.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {

  btnAcao = "Editar";
  btnTitulo = "Editar Usuário";
  usuario?: Usuario;

  constructor(private usuarioService: UsuarioService, private route: ActivatedRoute, private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.usuarioService.GetUsuario(id).subscribe((data) => {
      this.usuario = data;
    })
  }

  editarUsuario(usuario: Usuario){
    this.usuarioService.EditarUsuario(usuario).subscribe((data) => {
      this.router.navigate(['/']);
      this.snackBar.open("Usuário editado com sucesso!", "Ok");
    });
  }

}
