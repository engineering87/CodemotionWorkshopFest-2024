/** @format */

import { useDispatch, useSelector } from 'react-redux';

import { Layout } from 'antd';
import { RouteObject, useNavigate, useRoutes } from 'react-router-dom';
import './App.css';
import { Header } from './components';
import { RouteMenuItems } from './components/Header/Header';
import { HistoryObject, addToHistory } from './redux/reducers/Session.reducer';
import { RootState } from './redux/store';
import { Beneficiari, Home, PraticheOrdinarie, PraticheStraordinarie } from './views';

const { Content, Footer } = Layout;

const App = () => {
  const dispatch = useDispatch();
  //const { username, role, idNumber }: any = useSelector((state: any) => state.Session.user);
  const history: HistoryObject[] = useSelector((state: any) => state.Session.history);
  let navigate = useNavigate();
  const { SessionToken } = useSelector((state: RootState) => state.Session);

  const NavigateTo = (destination: HistoryObject) => {
    dispatch(addToHistory(destination));
    navigate(`${destination.key}` /* { replace: true } */);
    window.history.pushState({}, '', `${destination.key}`);
  };

  const NavigateBack = () => {
    dispatch(addToHistory(history[history.length - 1]));
    navigate(-1);
    window.history.pushState({}, '', `${history[history.length - 1]}`);
  };

  /* index property indicates what component should be picked if the father did not receive any suppaths, eg <<<" /courses/ ">>> */
  const routes: RouteObject[] = [
    {
      path: `/`,
      children: [
        {
          index: true,
          element: <Home NavigateTo={NavigateTo} NavigateBack={NavigateBack} SideBarId={`/`} />,
        },
        {
          path: `/pratiche-ordinarie`,
          children: [
            {
              index: true,
              element: <PraticheOrdinarie NavigateTo={NavigateTo} NavigateBack={NavigateBack} SideBarId={`/pratiche-ordinarie`} />,
            },
          ],
        },
        {
          path: `/pratiche-straordinarie`,
          children: [
            {
              index: true,
              element: <PraticheStraordinarie NavigateTo={NavigateTo} NavigateBack={NavigateBack} SideBarId={`/pratiche-straordinarie`} />,
            },
          ],
        },
        {
          path: `/gestione-beneficiari`,
          children: [
            {
              index: true,
              element: <Beneficiari NavigateTo={NavigateTo} NavigateBack={NavigateBack} SideBarId={`/gestione-beneficiari`} />,
            },
          ],
        },
        {
          path: '*',
          element: <Home NavigateTo={NavigateTo} NavigateBack={NavigateBack} SideBarId={`/`} />,
        },
      ],
    },
  ];

  /* element that will render your entire route hierarchy */
  let element = useRoutes(routes);
  let currentBreadCrumbRoute: any = RouteMenuItems.find((route: any) => {
    if (route.key === '/') return false;
    return route.key === history[history.length - 1]?.key;
  });
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Header NavigateTo={NavigateTo} />
      <Content style={{ padding: '0 48px' }}>
        {/*  <Breadcrumb style={{ margin: '16px 0' }}>
          <Breadcrumb.Item href='#' onClick={() => NavigateTo({ key: '/', keyPath: ['/'] })}>
            Home
          </Breadcrumb.Item>
          <Breadcrumb.Item>{currentBreadCrumbRoute?.label}</Breadcrumb.Item>
        </Breadcrumb> */}

        {element}
      </Content>
      <Footer style={{ textAlign: 'center' }}> ©{new Date().getFullYear()}</Footer>
    </Layout>
  );
};

export default App;
