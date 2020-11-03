// sempre que criarmos uma instância da cesta
// ela terá um identificador único e array vazio de itens
import {v4 as uuid4} from 'uuid';

export interface ICestaCliente {
    id: string;
    itens: IItemCesta[];
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
    itens: IItemCesta[] = [];
}


export interface ICestaTotal {
    frete: number;
    subtotal: number;
    // Total é a combinaação de frete e subtotal
    total: number;
}
