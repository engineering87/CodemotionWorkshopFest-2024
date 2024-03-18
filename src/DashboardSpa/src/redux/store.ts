/** @format */

import { configureStore } from '@reduxjs/toolkit';
import logger from 'redux-logger';
import { loadFromSessionStorage, saveToSessionStorage } from '../assets/libs/extras';
import type { IS as IS_Session } from './reducers/Session.reducer';
import SessionReducer from './reducers/Session.reducer';

const preloadedState: any = loadFromSessionStorage();

const store = configureStore({
  reducer: {
    Session: SessionReducer,
  },
  middleware: (getDefaultMiddleware: any) => {
    return process.env.REACT_APP_ENVIRONMENT === 'DEV' ? getDefaultMiddleware().concat(logger) : getDefaultMiddleware();
  },
  devTools: process.env.REACT_APP_ENVIRONMENT === 'DEV',
  preloadedState,
} as any);

store.subscribe(() => {
  saveToSessionStorage(store.getState());
});

export default store;

export interface RootState {
  Session: IS_Session;
}
