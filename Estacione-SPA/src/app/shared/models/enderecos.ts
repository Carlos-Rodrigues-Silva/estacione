export interface IEstacionamento {
    id: number;
    nomeEstacionamento: string;
    descricao: string;
    precoHora: number;
    avaliacao: number;
    numeroVagas: number;
    numeroVagasDisponiveis: number;
    endereco: IEndereco;
}

export interface IEndereco {
    nomeLogradouro: string;
    numero: string;
    cep: string;
    bairro: string;
    cidade: string;
    estado: string;
    estacionamentoId: number;
    logradouro: ILogradouro;
    id: number;
}

export interface ILogradouro {
    tipoLogradouro: string;
    enderecoId: number;
    id: number;
}
