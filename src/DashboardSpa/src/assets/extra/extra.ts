/** @format */

import { notification } from 'antd';
import dayjs from 'dayjs';
import { useSelector } from 'react-redux';
import store from '../../redux/store';

const LF = process.env.REACT_APP_LF;
const LF_API = process.env.REACT_APP_LF_API;
const ND_SIGN = process.env.REACT_APP_ND_SIGN;

declare global {
  interface Window {
    _Feedback: any;
  }
}

export function UUID() {
  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
    var r = (Math.random() * 16) | 0;
    // eslint-disable-next-line eqeqeq
    var v = c == 'x' ? r : (r & 0x3) | 0x8;
    return v.toString(16);
  });
}

export function downloadFileByUrl(url: string, filename?: string, ext?: string) {
  var element = document.createElement('a');
  element.setAttribute('href', url);
  if (filename) element.setAttribute('download', `${filename}${ext}`);
  element.target = '_blank';

  element.style.display = 'none';
  document.body.appendChild(element);

  element.click();

  document.body.removeChild(element);
}

export function get_preFix() {
  let prefix;
  try {
    // @ts-ignore
    prefix = GetPath();
  } catch (error) {
    prefix = '';
  }
  return prefix;
}

export function get_sessionTokenFrom_MVC() {
  let sessionToken;
  try {
    // @ts-ignore
    sessionToken = _GetSessionToken_();
  } catch (error) {
    if (process.env.REACT_APP_ENVIRONMENT === 'DEV') sessionToken = 'SessionTokenTest';
  }
  return sessionToken;
}

export function ObjToUrlEncoded(param: Object) {
  return Object.entries(param)
    .map(([k, v]) => `${k}=${v}`)
    .join('&');
}

type NotificationType = 'success' | 'info' | 'warning' | 'error';
type Config = {
  message: string;
  descriptions?: string;
};
export function openNotificationWithIcon(type: NotificationType, config: Config) {
  notification[type]({
    message: config.message ? config.message : '-',
    description: config.descriptions ? config.descriptions : '',
  });
}
/* 
export function debounce(func: Function, wait: number, immediate?: boolean) {
  var timeout: any;

  return function executedFunction(this: any) {
    var context = this;
    var args = arguments;

    var later = function () {
      timeout = null;
      if (!immediate) func.apply(context, args);
    };

    var callNow = immediate && !timeout;

    clearTimeout(timeout);

    timeout = setTimeout(later, wait);

    if (callNow) func.apply(context, args);
  };
} */

export function percentageOf(num: number, total: number): number {
  return (num / total) * 100;
}

/* export function Round(num: number) {
  return Math.round((num + Number.EPSILON) * 100) / 100;
} */

export function round(number: number, precision: number = 0): number {
  const factor: number = Math.pow(10, precision);
  return Math.round(number * factor) / factor;
}

type DebouncedFunction<T extends (...args: any[]) => any> = ((...args: Parameters<T>) => void) & { cancel: () => void };

export function _debounce<T extends (...args: any[]) => any>(func: T, wait: number, options?: { leading?: boolean; trailing?: boolean }): DebouncedFunction<T> {
  let timeoutId: ReturnType<typeof setTimeout> | null;

  const debouncedFunc = function (this: any, ...args: Parameters<T>) {
    const context = this;
    const callFunc = function () {
      func.apply(context, args);
    };
    if (options?.leading && !timeoutId) {
      callFunc();
    }
    if (timeoutId) {
      clearTimeout(timeoutId);
    }
    timeoutId = setTimeout(() => {
      if (!options?.leading) {
        callFunc();
      }
      timeoutId = null;
    }, wait);
  };

  debouncedFunc.cancel = function () {
    if (timeoutId) {
      clearTimeout(timeoutId);
      timeoutId = null;
    }
  };

  return debouncedFunc as DebouncedFunction<T>;
}

export const formatFileSize = (size: number, toFixed: number = 2): string => {
  if (size < 1024) {
    return size + ' bytes';
  } else if (size < 1024 * 1024) {
    return (size / 1024).toFixed(toFixed) + ' KB';
  } else {
    return (size / (1024 * 1024)).toFixed(toFixed) + ' MB';
  }
};

export const ShowFeedbackInps = () => {
  try {
    window._Feedback.configure();
    window._Feedback.show();
  } catch (err) {
    console.log(err);
  }
};

export const CountFormatter = ({ count, maxLength }: any) => {
  return `${count}/${maxLength} caratteri`;
};

export const IsCausaleEventoMeteo = (idTipoCausale: string | number) => `${idTipoCausale}` === `1` || `${idTipoCausale}` === `2` || `${idTipoCausale}` === `170`;

export const getCurrentReducer = (TipoPrestazione: string | number) => {
  const FlowDomandaCIGO: any = useSelector((state: any) => state.FlowDomandaCIGO.FlowDomanda);
  const FlowDomandaFONDI: any = useSelector((state: any) => state.FlowDomandaFONDI.FlowDomanda);
  const FlowDomandaISU: any = useSelector((state: any) => state.FlowDomandaISU.FlowDomanda);
  switch (TipoPrestazione) {
    case 1 /* CIGO */:
      return FlowDomandaCIGO;
    case 2 /* FONDI */:
      return FlowDomandaFONDI;
    case 3 /* FIS */:
      return FlowDomandaFONDI;
    case 4 /* ISU */:
      return FlowDomandaISU;
  }
};

/* controlla che l'utente abbiamo un id 66 e la carica del rappresentante legale */
export const IsRappLegale = (RappLegale: boolean): boolean => {
  const { user } = store.getState().Session;
  /*   const { ModuloDomanda } = store.getState();
  const { RappLegale } = getCurrentReducer(ModuloDomanda.TipoPrestazione);
  const { RappLegale } = getCurrentReducer(ModuloDomanda.TipoPrestazione); */

  return `${user.tipoUtente}` === '66' && RappLegale === true;
};

// Function to check for date range overlap
export const doArraysOverlap = (array1: [string, string], array2: [string, string], format = LF) => {
  const startDate1 = dayjs(array1[0], format);
  const endDate1 = dayjs(array1[1], format);
  const startDate2 = dayjs(array2[0], format);
  const endDate2 = dayjs(array2[1], format);

  // Check for overlap
  return startDate1.isBefore(endDate2) || (startDate1.isSame(endDate2) && endDate1.isAfter(startDate2)) || endDate1.isSame(startDate2);
};

export const debounce = (callback: any, wait: number = 750) => {
  let timeoutId: any = null;
  return (...args: any) => {
    window.clearTimeout(timeoutId);
    timeoutId = window.setTimeout(() => {
      callback.apply(null, args);
    }, wait);
  };
};

export const rimuoviDuplicati = (array1: any, array2: any, parametroConfronto: string) => {
  // Unisce i due array senza duplicati utilizzando un set e un parametro di confronto dinamico
  const arrayUnici = array1.concat(array2.filter((item2: any) => !array1.some((item1: any) => item1[parametroConfronto] === item2[parametroConfronto])));
  return arrayUnici;
};

export const scrollToPartialId = (partialId: string = 'InfoSection-') => {
  const element = document.querySelector(`[id*="${partialId}"]`);
  if (element) {
    element.scrollIntoView({ block: 'center', behavior: 'smooth' });
  }
};
