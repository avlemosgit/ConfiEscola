export interface ApiResponse<T> {
  data: T[];
  success: boolean;
  errors?: any;
}

export interface ApiResponseSingle<T> {
  data: T;
  success: boolean;
}

export interface ILogin {
  authenticated: boolean;
  accessToken: string;
  backgroundImage: string;
  created: Date;
  expiration: Date;
  message: string;
}

export interface IEnderecoPesquisaResponse{
  cep: string
  idLogradouro: number
  logradouro: string
  idBairro: number
  bairro: string
  nomeMunicipio: string
  idMunicipio: number
  latitude: number
  longitude: number
  idDelegacia?: number
  idBatalhao?: number
  uf: string
}
