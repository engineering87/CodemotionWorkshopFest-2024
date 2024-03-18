/** @format */

import { createAction, createReducer } from '@reduxjs/toolkit';

const initialState: IS = {
  SessionToken: '',
  sideBarId: null,
  impostazioni: {
    initialzationState: 'loading',
    PaginaCortesia: null,
  },
  session: null,
  user: null,
  history: [],
};

export const updateSessionToken = createAction<any>('updateSessionToken');
export const addToHistory = createAction<any>('addToHistory');
export const updateImpostazioni = createAction<any>('updateImpostazioni');
export const updateUser = createAction<any>('updateUser');
export const setSideBarId = createAction<any>('setSideBarId');

const reducer = createReducer(initialState, (builder) => {
  builder
    .addCase(updateSessionToken, (state, action) => {
      state.SessionToken = action.payload;
    })
    .addCase(addToHistory, (state, action) => {
      // action is inferred correctly here
      state.history = [...state.history, action.payload];
    })
    .addCase(updateImpostazioni, (state, action) => {
      state.impostazioni = { ...state.impostazioni, ...action.payload };
    })
    .addCase(updateUser, (state, action) => {
      state.user = { ...state.user, ...action.payload };
    })
    .addCase(setSideBarId, (state, action) => {
      // action is inferred correctly here
      state.sideBarId = action.payload;
    });
});

export default reducer;

export interface IS {
  SessionToken: string;
  sideBarId: null | string;
  impostazioni: {
    /* se true può creare le domande, se è false non le può creare */
    CHECK_ENABLE_OMNIA?: boolean;

    initialzationState: 'loading' | 'failed' | 'succeed';
    PaginaCortesia: any;
  };

  session: any;
  user: any;
  history: any;
}

export interface HistoryObject {
  key: string;
  keyPath: string[];
}

export interface User {
  username: any;
  role: string;
  idNumber: string;
}
