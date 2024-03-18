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
import { usePraticaOrdinaria } from '../../services/PraticaOrdinaria';
import { Pratica } from '../../services/PraticaOrdinaria/PraticaOrdinaria.types';
import type { Props } from './PraticheOrdinarie.types';

const PraticheOrdinarie = ({ SideBarId }: Props) => {
  const dispatch = useDispatch();
  const LF = process.env.REACT_APP_LF;
  const LF_API = process.env.REACT_APP_LF_API;
  const ND_SIGN = process.env.REACT_APP_ND_SIGN;

  const PO: any = usePraticaOrdinaria();
  const BID: any = useBeneficiario();

  const CustomSearchColumn = useCustomSearchColumn();

  const [dataSource, setDataSource] = useState([]);

  useEffect(() => {
    getPraticheOrdinarie();
    dispatch(setSideBarId(SideBarId));
  }, []);

  const getPraticheOrdinarie = async () => {
    const praticheOrdinarie = await PO.execute();
    const praticheOrdinariePromises = praticheOrdinarie.data.map(async (pratica: Pratica) => {
      const beneficiario = await BID.execute(`/${pratica.idBeneficiario}`);
      return { ...pratica, beneficiario: beneficiario.data };
    });
    Promise.all(praticheOrdinariePromises).then((praticheOrdinarieResolved: any) => {
      setDataSource(praticheOrdinarieResolved);
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
      align: 'center',
      ...CustomSearchColumn.get(['beneficiario', 'nome']),
      render: (value: string, row: any) => {
        return `${row.beneficiario.nome.substring(0, 1)}. ${row.beneficiario.cognome}`;
      },
    },
    {
      title: 'Data Inserimento',
      dataIndex: 'dataInserimento',
      key: 'dataInserimento',
      align: 'center',
      ...CustomSearchColumn.get(`dataInserimento`),
      render: (value: string) => dayjs(value, LF_API).format(LF),
    },
    {
      title: 'Pagamento',
      dataIndex: ['pagamento', 'descrizione'],
      key: 'pagamento',
      align: 'center',
      ...CustomSearchColumn.get(['pagamento', 'descrizione']),
    },
    {
      title: 'Tipo',
      dataIndex: ['tipo', 'descrizione'],
      key: 'tipo',
      align: 'center',
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

  let isSomethingLoading = PO.isLoading;
  return (
    <>
      <PageTitle level={3}>Lista Pratiche Ordinarie</PageTitle>

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
                      label: 'Pratiche Ordinarie',
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

export default PraticheOrdinarie;
