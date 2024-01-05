export class HistoricoFile{
    idUsuario: number;
    file: FormData;

    constructor(){
        this.idUsuario = 0;
        this.file = new FormData();
    }
}