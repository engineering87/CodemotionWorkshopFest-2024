/** @format */

import { FileExcelFilled } from '@ant-design/icons';
import { Button, Col, Row, Table } from 'antd';
import dayjs from 'dayjs';
import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { downloadAsCSV, downloadAsExcel } from '../../assets/libs/json2FileFormat';
import { PageTitle, PageWrapper } from '../../assets/styles/global.styles';
import { useCustomSearchColumn } from '../../hooks';
import { setSideBarId } from '../../redux/reducers/Session.reducer';
import { useBeneficiario } from '../../services/Beneficiario';
import { usePraticaStraordinaria } from '../../services/PraticaStraordinaria';
import { Pratica } from '../../services/PraticaStraordinaria/PraticaStraordinaria.types';
import type { Props } from './PraticheStraordinarie.types';

const PraticheStraordinarie = ({ SideBarId }: Props) => {
  const dispatch = useDispatch();
  const LF = process.env.REACT_APP_LF;
  const LF_API = process.env.REACT_APP_LF_API;
  const ND_SIGN = process.env.REACT_APP_ND_SIGN;

  const PS: any = usePraticaStraordinaria();
  const BID: any = useBeneficiario();

  const CustomSearchColumn = useCustomSearchColumn();

  const [dataSource, setDataSource] = useState([]);

  useEffect(() => {
    getPraticheStraordinarie();
    dispatch(setSideBarId(SideBarId));
  }, []);

  const getPraticheStraordinarie = async () => {
    const praticheStraordinarie = await PS.execute();
    const praticheStraordinariePromises = praticheStraordinarie.data.map(async (pratica: Pratica) => {
      const beneficiario = await BID.execute(`/${pratica.idBeneficiario}`);
      return { ...pratica, beneficiario: beneficiario.data };
    });
    Promise.all(praticheStraordinariePromises).then((praticheStraordinarieResolved: any) => {
      setDataSource(praticheStraordinarieResolved);
    });
  };

  const columns: any = [
    {
      title: 'Numero Pratica',
      dataIndex: 'id',
      key: 'id',
      ...CustomSearchColumn.get('id'),
    },
    {
      title: 'Beneficiario',
      dataIndex: ['beneficiario', 'nome'],
      key: 'keyBeneficiario',
      ...CustomSearchColumn.get(['beneficiario', 'nome']),
      render: (value: string, row: any) => {
        return `${row.beneficiario.nome.substring(0, 1)}. ${row.beneficiario.cognome}`;
      },
    },
    {
      title: 'Data Inserimento',
      dataIndex: 'dataInserimento',
      key: 'dataInserimento',
      ...CustomSearchColumn.get('dataInserimento'),
      render: (value: string) => dayjs(value, LF_API).format(LF),
    },
    {
      title: 'Causale',
      dataIndex: ['causale', 'descrizione'],
      key: 'causale',
      ...CustomSearchColumn.get(['causale', 'descrizione']),
    },
    {
      title: 'Tipo',
      dataIndex: ['tipo', 'descrizione'],
      key: 'tipo',
      ...CustomSearchColumn.get(['tipo', 'descrizione']),
    },
  ];

  const ExportData = (TabsConfig: any[], type: 'CSV' | 'XLSX') => {
    /* function called when main button is clicked */
    const timeStamp = dayjs().format('YYYYMMDD_HHmmss');
    const fileName = `Pratiche_${timeStamp}`;
    /* preparing data */
    let formattedData: any = {};
    Object.values(TabsConfig).forEach((tab: any) => {
      formattedData[tab.label] = tab.dataSource.map((row: any) => {
        /* return row; */
        /* Field Filters */
        return {
          'Numero Pratica': row.id,
        };
      });
    });
    switch (type) {
      case 'XLSX':
        downloadAsExcel(formattedData, fileName);
        break;
      case 'CSV':
        downloadAsCSV(formattedData, fileName);
        break;
    }

    /* console.log(dataSourceByTipoPrestazione); */
  };

  let isSomethingLoading = PS.isLoading;
  return (
    <>
      <PageTitle level={3}>Lista Pratiche Straordinarie</PageTitle>
      <PageWrapper $background={true}>
        <Row gutter={[24, 24]}>
          <Col>
            <Button
              size='large'
              className='btn-extra'
              type='primary'
              icon={<FileExcelFilled />}
              onClick={() => {
                ExportData(
                  [
                    {
                      label: 'Pratiche Straordinarie',
                      dataSource: dataSource,
                    },
                  ],
                  'XLSX'
                );
              }}>
              Esporta
            </Button>
          </Col>
          <Col span={24}>
            <Table loading={isSomethingLoading} dataSource={dataSource} columns={columns} bordered />
          </Col>
        </Row>
      </PageWrapper>
    </>
  );
};

export default PraticheStraordinarie;
