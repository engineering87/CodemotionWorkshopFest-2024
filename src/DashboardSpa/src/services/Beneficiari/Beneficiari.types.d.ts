/** @format */

export interface Data {}
export interface TransformedData {}
interface Person {
  id: string;
  nome: string;
  cognome: string;
  cellulare: string;
  email: string;
}

interface ApiResponse {
  pageNumber: number;
  pageSize: number;
  succeeded: boolean;
  message: null;
  errors: null;
  data: Person[];
}
