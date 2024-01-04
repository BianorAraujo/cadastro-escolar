import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Usuario } from '../../models/Usuario';
import { NivelEscolar } from '../../models/NivelEscolar';
import { EscolaridadeService } from '../../services/escolaridade.service';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.component.html',
  styleUrls: ['./usuario-form.component.css']
})
export class UsuarioFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Usuario>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosUsuario: Usuario | null = null;
  
  niveisEscolares?: NivelEscolar[];
  usuarioForm!: FormGroup;
  maxDate!: Date;
  selected!: number; 

  constructor(private escolaridadeService: EscolaridadeService) {}

  ngOnInit(): void {

    const currentYear = new Date().getFullYear();
    this.maxDate = new Date(currentYear - 15, 1, 1);

    this.escolaridadeService.GetEscolaridades().subscribe((data) => {
      this.niveisEscolares = data;
    })

    this.selected = this.dadosUsuario ? this.dadosUsuario.idEscolaridade : 0;

    this.usuarioForm = new FormGroup({
      idUsuario: new FormControl(this.dadosUsuario ? this.dadosUsuario.idUsuario : 0),
      nome: new FormControl(this.dadosUsuario ? this.dadosUsuario.nome : '', [Validators.required]),
      sobrenome : new FormControl(this.dadosUsuario ? this.dadosUsuario.sobrenome : '', [Validators.required]),
      email: new FormControl(this.dadosUsuario ? this.dadosUsuario.email : '', [Validators.required]),
      dataNascimento : new FormControl(this.dadosUsuario ? this.dadosUsuario.dataNascimento : '', [Validators.required]),
      idEscolaridade: new FormControl(this.selected)
    })
  }

  submit(){
    this.usuarioForm.value.idEscolaridade = this.selected;

    this.onSubmit.emit(this.usuarioForm.value);
  }



}
