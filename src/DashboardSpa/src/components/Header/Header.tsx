/** @format */

import { useDispatch, useSelector } from 'react-redux';

import { Menu } from 'antd';
import { Header } from 'antd/es/layout/layout';
import styled from 'styled-components';
import type { Props } from './Header.types';

const Logo = styled.div`
  height: 30px;
  margin-right: 12px;
  width: 128px;
  border-radius: 5px;
  background-color: white;
  background-size: contain; /* Ensure the background image fits within the container */
  background-position: center; /* Center the background image */
  background-repeat: no-repeat; /* Prevent the background image from repeating */
  overflow: hidden; /* This ensures the image doesn't overflow the container */
  display: flex; /* Use flexbox for centering */
  justify-content: center; /* Center horizontally */
  align-items: center; /* Center vertically */
`;
const SlimMenu = styled(Menu)`
  height: 48px;
  .ant-menu-item {
    color: white !important;
    border-radius: 4px !important;
    line-height: 3;
    &::after {
      border-bottom-width: 0px !important;
    }
  }
  .ant-menu-item-selected {
    background-color: #1677ff !important;
  }
  flex: 1;
  min-width: 0;
  background: #001529;

  font-size: 16px;
`;

export const RouteMenuItems = [
  { key: '/', label: `Home` },
  { key: `/pratiche-ordinarie`, label: `Pratica ordinaria` },
  { key: `/pratiche-straordinarie`, label: `Pratica straordinaria` },
  { key: `/gestione-beneficiari`, label: `Beneficiari` },
];

const Header_ = ({ NavigateTo }: Props) => {
  const dispatch = useDispatch();
  const LF = process.env.REACT_APP_LF;
  const LF_API = process.env.REACT_APP_LF_API;
  const ND_SIGN = process.env.REACT_APP_ND_SIGN;

  const { sideBarId } = useSelector((state: any) => state.Session);

  return (
    <Header style={{ display: 'flex', alignItems: 'center', height: '48px' }}>
      <SlimMenu
        theme='dark'
        mode='horizontal'
        items={RouteMenuItems}
        style={{}}
        selectedKeys={sideBarId ? sideBarId : []}
        onSelect={({ item, key, keyPath, domEvent }) => NavigateTo({ key: key, keyPath: [key] })}
      />
    </Header>
  );
};

export default Header_;
