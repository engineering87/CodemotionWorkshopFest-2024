/** @format */
import axios, { type AxiosRequestConfig } from 'axios';
import { useCallback, useState } from 'react';
import { ReqStatusManger } from '../../services.helpers';
import type { TransformedData } from './TemplateName.types';

export const call_TemplateName = async (urlExtension: string = '', urlPrefix = get_preFix()) => {
  const config: AxiosRequestConfig = {
    method: 'get',
    url: `${process.env.REACT_APP_API_HOSTNAME}${urlPrefix}${process.env.REACT_APP_API_DELETE_EVENTO_METEO}${urlExtension}`,
    headers: {},
  };
  const response = await ReqStatusManger(axios(config));
  const responseData = response.data;

  // add transformers here if needed
  const transformedData: TransformedData = responseData ? responseData : [];

  return transformedData;
};

const useTemplateName = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<any>(null);
  const [data, setData] = useState<TransformedData | null>(null);

  const execute = async (urlExtension: string = '') => {
    try {
      setIsLoading(true);
      const responseData = await call_TemplateName(urlExtension);
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

export default useTemplateName;
