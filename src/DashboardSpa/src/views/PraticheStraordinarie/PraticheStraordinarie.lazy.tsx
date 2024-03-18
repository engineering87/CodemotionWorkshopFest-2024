/** @format */
import { Spin } from 'antd';
import React, { lazy, Suspense } from 'react';

const LazyBox = lazy(() => import('./PraticheStraordinarie'));

const LazyWrappedComponent = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode } & any) => (
  <Suspense
    fallback={
      <div
        style={{
          height: '100px',

          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        }}>
        <Spin size='large' style={{ display: 'inline-block' }} tip={'Caricamento...'} />
      </div>
    }>
    <LazyBox {...props} />
  </Suspense>
);

export default LazyWrappedComponent;
