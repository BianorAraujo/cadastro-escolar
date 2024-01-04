import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { ActivatedRoute } from '@angular/router';
import { Usuario } from '../../models/Usuario';
import { EscolaridadeService } from '../../services/escolaridade.service';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesComponent implements OnInit {

  usuario?: Usuario;
  id!: number;
  nivelEscolar?: string;

  constructor(
    private usuarioService: UsuarioService, 
    private escolaridadeService: EscolaridadeService, 
    private route: ActivatedRoute) {}


  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    
    this.usuarioService.GetUsuario(this.id).subscribe((data) => {
      
      const dados = data;
      dados.dataNascimento = new Date(dados.dataNascimento).toLocaleDateString('pt-BR');

      this.usuario = data;

      this.escolaridadeService.GetEscolaridades().subscribe((nivel) => {
        var result = nivel.find((obj) => obj.idEscolaridade == this.usuario?.idEscolaridade);
        this.nivelEscolar = result?.escolaridade;
      });

    });
  }


}
