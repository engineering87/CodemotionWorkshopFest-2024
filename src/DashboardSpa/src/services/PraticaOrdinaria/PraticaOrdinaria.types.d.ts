/** @format */

export interface Data {}
export interface TransformedData {}
interface Tipo {
  id: number;
  descrizione: string;
}

interface Pagamento {
  id: number;
  descrizione: string;
}

export interface Pratica {
  pagamento: Pagamento;
  id: string;
  protocollo: string;
  idBeneficiario: string;
  dataInserimento: string;
  tipo: Tipo;
}

export interface ApiResponse {
  pageNumber: number;
  pageSize: number;
  succeeded: boolean;
  message: null;
  errors: null;
  data: Pratica[];
}
