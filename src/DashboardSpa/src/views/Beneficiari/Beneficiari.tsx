/** @format */

import { useDispatch } from 'react-redux';

import { FileExcelFilled, FileSearchOutlined } from '@ant-design/icons';
import { Badge, Button, Col, Descriptions, Drawer, Row, Space, Spin, Table } from 'antd';
import dayjs from 'dayjs';
import { useEffect, useState } from 'react';
import styled from 'styled-components';
import { downloadAsCSV, downloadAsExcel } from '../../assets/libs/json2FileFormat';
import { PageTitle, PageWrapper } from '../../assets/styles/global.styles';
import { useCustomSearchColumn } from '../../hooks';
import { setSideBarId } from '../../redux/reducers/Session.reducer';
import { useBeneficiari } from '../../services/Beneficiari';
import { Person } from '../../services/Beneficiari/Beneficiari.types';
import { useBeneficiario } from '../../services/Beneficiario';
import type { Props } from './Beneficiari.types';

const SearchIcon = styled(FileSearchOutlined)`
  color: #1890ff;
  font-size: 20px;

  &:hover {
    color: blue;
    cursor: pointer;
  }
`;

const Beneficiari = ({ SideBarId }: Props) => {
  const dispatch = useDispatch();
  const LF = process.env.REACT_APP_LF;
  const LF_API = process.env.REACT_APP_LF_API;
  const ND_SIGN = process.env.REACT_APP_ND_SIGN;

  const B: any = useBeneficiari();
  const BID: any = useBeneficiario();

  const CustomSearchColumn = useCustomSearchColumn();

  const [drawerDettaglioOpen, setDrawerDettaglioOpen] = useState<boolean>(false);
  const [isTourVisible, setIsTourVisible] = useState<boolean>(false);

  useEffect(() => {
    getBeneficiari();
    dispatch(setSideBarId(SideBarId));
  }, []);

  const getBeneficiari = async () => {
    await B.execute();
  };

  const getBeneficiario = async (idBeneficiario: string) => {
    await BID.execute(`/a15e737d-1d57-4dd5-ae69-2f229bec1a47`);
  };

  const columns: any = [
    {
      title: 'Nome',
      dataIndex: 'nome',
      key: 'nome',
      ...CustomSearchColumn.get('nome'),
    },
    {
      title: 'Cognome',
      dataIndex: 'cognome',
      key: 'cognome',
      ...CustomSearchColumn.get('cognome'),
    },
    {
      title: 'Cellulare',
      dataIndex: 'cellulare',
      key: 'cellulare',
      ...CustomSearchColumn.get('cellulare'),
    },
    {
      title: 'Email',
      dataIndex: 'email',
      key: 'email',
      ...CustomSearchColumn.get('email'),
    },
    {
      title: 'Azioni',
      dataIndex: '_',
      key: 'Actions',
      align: 'center',
      fixed: 'right',
      render: (value: string, row: Person) => {
        return (
          <SearchIcon
            onClick={() => {
              setDrawerDettaglioOpen(true);
              getBeneficiario(row.id);
            }}
          />
        );
      },
    },
  ];
  const ExportData = (TabsConfig: any[], type: 'CSV' | 'XLSX') => {
    /* function called when main button is clicked */
    const timeStamp = dayjs().format('YYYYMMDD_HHmmss');
    const fileName = `Beneficari_${timeStamp}`;
    /* preparing data */
    let formattedData: any = {};
    Object.values(TabsConfig).forEach((tab: any) => {
      formattedData[tab.label] = tab.dataSource.map((row: any) => {
        /* return row; */
        /* Field Filters */
        return {
          'Id Beneficiario': row.id,
          Nome: row.nome,
          Cognome: row.cognome,
          Cellulare: row.cellulare,
          Email: row.email,
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

  let isSomethingLoading = B.isLoading;
  return (
    <>
      <PageTitle level={3}>Lista Beneficiari</PageTitle>
      <PageWrapper $background={true}>
        <Row gutter={[24, 24]}>
          <Col span={24}>
            <Space>
              <Button
                size='large'
                className='btn-extra'
                type='primary'
                icon={<FileExcelFilled />}
                onClick={() => {
                  ExportData(
                    [
                      {
                        label: 'Beneficiari',
                        dataSource: B.data ? B.data.data : [],
                      },
                    ],
                    'XLSX'
                  );
                }}>
                Esporta
              </Button>
              {/*  <Button size='large' className='btn-extra' type='primary' icon={<FileExcelFilled />} onClick={() => {}}>
              Demo Tour
            </Button> */}
            </Space>
          </Col>
          <Col span={24}>
            <Table loading={isSomethingLoading} dataSource={B.data ? B.data.data : []} columns={columns} bordered />
          </Col>
        </Row>
      </PageWrapper>
      <Drawer width={900} title='Dettaglio Beneficiario' onClose={() => setDrawerDettaglioOpen(false)} open={drawerDettaglioOpen}>
        <Spin spinning={BID.isLoading}>
          <Descriptions
            title='User Info'
            bordered
            column={1}
            items={[
              {
                key: '6',
                label: 'Id',
                children: <Badge status='processing' text={BID.data?.data.id} />,
                span: 3,
              },
              {
                key: '1',
                label: 'Nome',
                children: BID.data?.data.nome,
              },

              {
                key: '4',
                label: 'Cognome',
                children: BID.data?.data.cognome,
              },
              {
                key: '5',
                label: 'Cellulare',
                children: BID.data?.data.cellulare,
                span: 2,
              },

              {
                key: '7',
                label: 'Email',
                children: BID.data?.data.email,
              },
            ]}
          />
        </Spin>
      </Drawer>
      {/*  <Tour open={isTourVisible} onClose={() => setIsTourVisible(false)} steps={steps} /> */}
    </>
  );
};

export default Beneficiari;
