/** @format */

export interface Data {}
export interface TransformedData {}
interface Causale {
  id: number;
  descrizione: string;
}

interface Tipo {
  id: number;
  descrizione: string;
}

export interface Pratica {
  causale: Causale;
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
