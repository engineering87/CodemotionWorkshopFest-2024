/** @format */

import { Typography } from 'antd';
import styled, { css } from 'styled-components';

export const PageWrapper = styled.div<{ $background?: boolean }>`
  ${({ $background }) => {
    if ($background)
      return css`
        margin-top: 24px;
        background: white;
        border-radius: 4px;
        padding: 24px;
        box-shadow: 0 1px 2px -2px rgba(0, 0, 0, 0.16), 0 3px 6px 0 rgba(0, 0, 0, 0.12), 0 5px 12px 4px rgba(0, 0, 0, 0.09) !important;
      `;
  }}
  min-height: 280px;
  margin-bottom: 24px;
`;

export const PageTitle = styled(Typography.Title)`
  /* padding: 0px !important; */
  /* margin: 0px !important; */
  margin-bottom: 0px !important;
`;
