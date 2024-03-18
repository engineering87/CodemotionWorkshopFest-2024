/** @format */

/* import 'antd/dist/antd.variable.min.css'; */
/* REACT */
import React, { useState } from 'react';
/* COMPONENTS */
import { ConfigProvider } from 'antd';
/* EXTRAS */
/* LOCALES */
/* DAYSJS */
import itIT from 'antd/locale/it_IT';
import dayjs from 'dayjs';
import 'dayjs/locale/it';
import customParseFormat from 'dayjs/plugin/customParseFormat';
dayjs.extend(customParseFormat);

dayjs.locale('it');

const defaultData: Partial<any> = {
  borderRadius: 4, //lo stesso che e' definito per tutti gli stili modificicati di antd in antdOverride
  colorPrimary: 'blue',
  colorInfo: 'lightblue',
  colorSuccess: 'green',
  colorError: 'red',
  colorWarning: 'orange',
  fontFamily: 'TitilliumWeb-Regular',
};
export const AntdConfigProvider = ({ children }: any) => {
  const [locale] = useState(itIT);
  const [data, setData] = React.useState<Partial<any>>(defaultData);

  return (
    <ConfigProvider direction='ltr' locale={locale} theme={{ token: defaultData }}>
      {children}
    </ConfigProvider>
  );
};

export default ConfigProvider;
