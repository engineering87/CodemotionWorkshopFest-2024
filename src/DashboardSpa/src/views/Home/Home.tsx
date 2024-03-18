/** @format */

import { PercentageOutlined } from '@ant-design/icons';
import { Chart } from '@antv/g2';
import { Card, Col, Row, Spin, Statistic } from 'antd';
import { useEffect, useState } from 'react';
import CountUp from 'react-countup';
import { useDispatch } from 'react-redux';
import styled from 'styled-components';
import { PageTitle, PageWrapper } from '../../assets/styles/global.styles';
import { setSideBarId } from '../../redux/reducers/Session.reducer';
import { useBeneficiari } from '../../services/Beneficiari';
import { usePraticaOrdinaria } from '../../services/PraticaOrdinaria';
import { usePraticaStraordinaria } from '../../services/PraticaStraordinaria';
import { Props } from './Home.types';

const ChartContainer = styled.div`
  width: 100%;
  height: 550px;
`;

const DashboardCard = styled(Card)<{ $minHeight?: string }>`
  box-shadow: 0 1px 2px -2px rgba(0, 0, 0, 0.16), 0 3px 6px 0 rgba(0, 0, 0, 0.12), 0 5px 12px 4px rgba(0, 0, 0, 0.09) !important;
`;

const Home = ({ SideBarId }: Props) => {
  const dispatch = useDispatch();
  const LF = process.env.REACT_APP_LF;
  const LF_API = process.env.REACT_APP_LF_API;
  const ND_SIGN = process.env.REACT_APP_ND_SIGN;

  const B: any = useBeneficiari();
  const PO: any = usePraticaOrdinaria();
  const PS: any = usePraticaStraordinaria();

  const [percentages, setPercentages] = useState({
    PO_percentage: 0,
    PS_percentage: 0,
  });

  useEffect(() => {
    dispatch(setSideBarId(SideBarId));
    getBeneficiari();
    getPraticheOrdinarie();
    getPraticheStraordinarie();
  }, []);

  useEffect(() => {
    if (PO.data && PS.data && B.data) {
      const PO_percentage = calculatePercentage(PO.data.data.length, PO.data.data.length + PS.data.data.length);
      const PS_percentage = calculatePercentage(PS.data.data.length, PO.data.data.length + PS.data.data.length);
      setPercentages({ PO_percentage, PS_percentage });
      RenderBarChartTotals();
    }
  }, [PO.data, PS.data, B.data]);

  const getPraticheStraordinarie = async () => {
    await PS.execute();
  };

  const getPraticheOrdinarie = async () => {
    await PO.execute();
  };

  const getBeneficiari = async () => {
    await B.execute();
  };

  const RenderBarChartTotals = () => {
    const chart = new Chart({
      container: 'RenderBarChartTotals',
      autoFit: true,
    });

    chart
      .interval()
      .data([
        { Tipologia: 'Pratiche ordinarie', 'Totale:': PO.data.data.length, washaway: 0.21014492753623193 },
        { Tipologia: 'Pratiche straordinarie', 'Totale:': PS.data.data.length, washaway: 0.5596330275229358 },
        { Tipologia: 'Beneficiari', 'Totale:': B.data.data.length, washaway: 0 },
      ])
      .encode('x', 'Tipologia')
      .encode('y', 'Totale:')
      .encode('color', 'Tipologia')
      .encode('size', 40)
      .legend('color', {
        /** Keep the legend centered horizontally and vertically*/
        layout: {
          justifyContent: 'flex-end',
          alignItems: 'flex-end',
          flexDirection: 'column',
        },
        itemMarker: 'circle',
        itemLabelFontSize: 16,
      })
      .style('radiusTopLeft', 10)
      .style('radiusTopRight', 10)
      .style('radiusBottomRight', 10)
      .style('radiusBottomLeft', 10);

    chart.render();
  };

  const formatter: any = (value: number) => <CountUp end={value} separator=',' />;

  const calculatePercentage = (number: number, totalItems: number): number => {
    let percentage: number = (number / totalItems) * 100;
    return percentage;
  };

  const isSomethingLoading = B.isLoading || PS.isLoading || PO.isLoading;

  return (
    <PageWrapper $background={false}>
      <Row gutter={[24, 24]}>
        <Col span={24}>
          <PageTitle level={3}>Analytics</PageTitle>
        </Col>
        <Col xs={24} sm={24} md={16} lg={16} xl={16}>
          <Row gutter={16}>
            <Col span={12}>
              <Spin spinning={isSomethingLoading} tip={'Caricamento...'}>
                <DashboardCard bordered={false} hoverable>
                  <Statistic
                    title='Pratiche ordinarie'
                    value={percentages.PO_percentage}
                    precision={2}
                    valueStyle={{ color: '#3f8600' }}
                    prefix={<PercentageOutlined />} /* suffix='%' */
                  />
                </DashboardCard>
              </Spin>
            </Col>
            <Col span={12}>
              <Spin spinning={isSomethingLoading} tip={'Caricamento...'}>
                <DashboardCard bordered={false} hoverable>
                  <Statistic
                    title='Pratiche straordinarie'
                    value={percentages.PS_percentage}
                    precision={2}
                    valueStyle={{ color: '#cf1322' }}
                    prefix={<PercentageOutlined />}
                    /* suffix='%' */
                  />
                </DashboardCard>
              </Spin>
            </Col>
          </Row>
        </Col>
        <Col xs={24} sm={24} md={8} lg={8} xl={8}>
          <Spin spinning={isSomethingLoading} tip={'Caricamento...'}>
            <DashboardCard bordered={false} hoverable>
              {/* <ChartContainer id='NumeroBeneficiari' /> */}
              <Statistic title='Numero dei beneficiari' value={B.data ? B.data.data.length : 0} formatter={formatter} />
            </DashboardCard>
          </Spin>
        </Col>

        <Col span={24}>
          <Spin spinning={isSomethingLoading} tip={'Caricamento...'}>
            <DashboardCard bordered={false} hoverable>
              <ChartContainer id='RenderBarChartTotals' />
            </DashboardCard>
          </Spin>
        </Col>
      </Row>
    </PageWrapper>
  );
};

export default Home;
