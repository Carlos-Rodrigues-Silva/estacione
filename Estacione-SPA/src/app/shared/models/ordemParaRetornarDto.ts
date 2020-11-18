export interface IOrdemParaRetornarDto {

    id: number;
    emailComprador: string;
    dataOrdem: Date;
    total: number;
    statusOrdem: string;
    paymentIntentId: string;
    quantidade: number;
    preco: number;
    nomeEstacionamento: string;
    nomeLogradouro: string;
    numero: string;
    cep: string;
    bairro: string;
    cidade: string;
    estado: string;
}
