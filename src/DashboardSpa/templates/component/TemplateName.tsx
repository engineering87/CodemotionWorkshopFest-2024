/** @format */

import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import styles from './TemplateName.module.scss';
import type { Props, State } from './TemplateName.types';

const TemplateName = ({}: Props) => {
  const dispatch = useDispatch();
  const LF = process.env.REACT_APP_LF;
  const LF_API = process.env.REACT_APP_LF_API;
  const ND_SIGN = process.env.REACT_APP_ND_SIGN;

  const [state, setState] = useState<State>({});
  const ReduxReducers: any = useSelector((state: any) => state);

  return <div className={styles.wrapper}>TemplateName Component</div>;
};

export default TemplateName;
