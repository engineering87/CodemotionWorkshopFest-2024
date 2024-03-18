/** @format */

import ReactDOM from 'react-dom/client';
import App from './App';
import './index.css';
/* REDUX */

import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import { AntdConfigProvider } from './components';
import store from './redux/store';

const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);

const Index = () => {
  return (
    <BrowserRouter>
      <AntdConfigProvider>
        <App />
      </AntdConfigProvider>
    </BrowserRouter>
  );
};

root.render(<Provider store={store} children={<Index />} />);
