import { HistoricoEscolar } from "./HistoricoEscolar";

export interface Usuario{
    idUsuario?: number;
    nome: string;
    sobrenome: string;
    email: string;
    dataNascimento: string;
    idEscolaridade: number;
    historicos: HistoricoEscolar[];
}