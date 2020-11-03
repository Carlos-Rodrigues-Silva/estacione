// Informações para criar uma ordem de compra
export interface IOrdemParaSerCriada {
    cestaId: string;
    email: string;
}

export interface IOrdem {
    emailComprador: string;
    dataOrdem: Date;
    vagasOrdenadas: IVagasOrdenadas[];
    total: number;
    statusOrdem: string;
    id: number;
}

export interface IVagasOrdenadas {
    nomeEstacionamento: string;
    preco: number;
    quantidade: number;
    nomeLogradouro: string;
    numero: string;
    cep: string;
    bairro: string;
    cidade: string;
    estado: string;
    id: number;
}

