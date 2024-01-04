import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from '../../models/Usuario';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesComponent implements OnInit {

  usuario?: Usuario;
  id!: number;

  constructor(private usuarioService: UsuarioService, private route: ActivatedRoute, private router: Router) {}


  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    
    this.usuarioService.GetUsuario(this.id).subscribe((data) => {

      const dados = data.dados;
      dados.dataNascimento = new Date(dados.dataNascimento).toLocaleDateString('pt-BR');

      this.usuario = data.dados;
    });
  }


}
