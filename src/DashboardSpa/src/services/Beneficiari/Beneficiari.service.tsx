/** @format */
import axios, { type AxiosRequestConfig } from 'axios';
import { useCallback, useState } from 'react';
import { get_preFix } from '../../assets/extra/extra';
import { ApiResponse } from './Beneficiari.types';

export const call_Beneficiari = async (urlExtension: string = '', urlPrefix = get_preFix()) => {
  const config: AxiosRequestConfig = {
    method: 'get',
    url: `${process.env.REACT_APP_API_HOSTNAME}${urlPrefix}${process.env.REACT_APP_PRATICA_BENEFICIARI}${urlExtension}`,
    maxBodyLength: Infinity,
    headers: {},
  };
  const response = await axios(config);
  const responseData = response.data;

  // add transformers here if needed
  const transformedData: ApiResponse = responseData ? responseData : null;

  return transformedData;
};

const useBeneficiari = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<any>(null);
  const [data, setData] = useState<ApiResponse | null>(null);

  const execute = async (urlExtension: string = '') => {
    try {
      setIsLoading(true);
      const responseData = await call_Beneficiari(urlExtension);
      setData(responseData);
      setIsLoading(false);
      return responseData;
    } catch (e: any) {
      setError(e);
      setIsLoading(false);
      throw e;
    }
  };

  const reset = () => {
    setIsLoading(false);
    setData(null);
    setError(null);
  };

  return {
    isLoading,
    error,
    data,
    execute: useCallback(execute, []), // to avoid infinite calls when inside a `useEffect`
    reset: useCallback(reset, []), // to avoid infinite calls when inside a `useEffect`
  };
};

export default useBeneficiari;
