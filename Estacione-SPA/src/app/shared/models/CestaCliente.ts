import {v4 as uuid4} from 'uuid';

export interface ICestaCliente {
    id: string;
    itensCestaCliente: IItemCesta[];
    clientSecret?: string;
    paymentIntentId?: string;
}

export interface IItemCesta {
    id: number;
    nomeEstacionamento: string;
    preco: number;
    quantidade: number;
}

export class Cesta implements ICestaCliente {
    id = uuid4();
    itensCestaCliente: IItemCesta[] = [];
}

export interface ICestaTotal {
    total: number;
}
