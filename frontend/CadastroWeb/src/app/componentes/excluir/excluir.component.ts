import { Component, Inject, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Usuario } from '../../models/Usuario';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css']
})
export class ExcluirComponent implements OnInit {

  inputData: any;
  usuario!: Usuario;

  constructor(
    private usuarioService: UsuarioService, 
    private router: Router, 
    @Inject(MAT_DIALOG_DATA) public data: any, 
    private ref: MatDialogRef<ExcluirComponent>
    ){}

  ngOnInit(): void {

    this.inputData = this.data;

    this.usuarioService.GetUsuario(this.inputData.id).subscribe((data) => {
      this.usuario = data.dados;
    });
  }

  excluir(){
    this.usuarioService.ExcluirUsuario(this.inputData.id).subscribe((data) => {
      this.ref.close();
      window.location.reload();
    })
  }

  cancelar(){
    this.ref.close();
  }
}
