import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../../models/Usuario';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  usuarios: Usuario[] = [];


  constructor(private usuarioService: UsuarioService) {}

  ngOnInit(): void {
    this.usuarioService.GetUsuarios().subscribe(data => {
      console.log(data);
    });    
  }


}
