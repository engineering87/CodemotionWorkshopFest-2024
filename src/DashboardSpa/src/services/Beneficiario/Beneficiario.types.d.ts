/** @format */

export interface Data {}
export interface TransformedData {}
interface Data {
  id: string;
  nome: string;
  cognome: string;
  cellulare: string;
  email: string;
}

interface ApiResponse {
  succeeded: boolean;
  message: null;
  errors: null;
  data: Data;
}
