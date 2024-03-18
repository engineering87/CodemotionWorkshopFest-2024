/** @format */

import { FilterOutlined, SearchOutlined } from '@ant-design/icons';
import { Button, Input, Space } from 'antd';
import { useCallback, useRef, useState } from 'react';
import Highlighter from 'react-highlight-words';

export const useCustomSearchColumn = () => {
  const ND_SIGN = `${process.env.REACT_APP_ND_SIGN}`;
  const ref: any = useRef();
  const [searchText, setSearchText] = useState('');
  const [searchedColumn, setSearchedColumn] = useState();

  const filterRecord = (record: any, recordsComparisonValue: string, searchedValue: string) => {
    let r_value = recordsComparisonValue;
    let RegexConstructor = searchedValue.replace('*', '.*');
    let regex = new RegExp(RegexConstructor, 'gim');
    return regex.test(r_value);
  };

  const handleSearch = (selectedKeys: any, confirm: any, dataIndex: any) => {
    confirm();
    setSearchText(selectedKeys[0]);
    setSearchedColumn(dataIndex);
  };

  const handleReset = (confirm: any, clearFilters: any) => {
    clearFilters();
    setSearchText('');
    setSearchedColumn(undefined);
    confirm();
  };

  const getColumnSearchProps = (dataIndex: string | string[], placeholder?: string) => ({
    filterDropdown: ({ setSelectedKeys, selectedKeys, confirm, clearFilters }: any) => (
      <div style={{ padding: 8 }}>
        <Input
          ref={(node) => {
            return ref.current?.searchInput == node;
          }}
          placeholder={placeholder ? placeholder : `Cerca ${dataIndex}`}
          value={selectedKeys[0]}
          onChange={(e) => setSelectedKeys(e.target.value ? [e.target.value] : [])}
          onPressEnter={() => handleSearch(selectedKeys, confirm, dataIndex)}
          style={{ marginBottom: 8, display: 'block' }}
        />
        <Space>
          <Button type='primary' onClick={() => handleSearch(selectedKeys, confirm, dataIndex)} icon={<SearchOutlined />} size='small' style={{ width: 90 }}>
            Cerca
          </Button>
          <Button onClick={() => handleReset(confirm, clearFilters)} size='small' style={{ width: 90 }}>
            Cancella
          </Button>
        </Space>
      </div>
    ),
    filterIcon: (filtered: any) => {
      if (filtered) return <FilterOutlined style={{ color: filtered ? '#1890ff' : '#1890ff', fontSize: '15px' }} />;
      return <SearchOutlined style={{ color: filtered ? '#1890ff' : '#1890ff', fontSize: '15px' }} />;
    },
    onFilter: (searchedValue: any, record: any) => {
      /* searchedValue => value is user typing/searching */
      /* recordsComparisonValue => value of comparison for searchedValue */
      const recordsComparisonValue = getChildrenValue(dataIndex, record);
      if (recordsComparisonValue && recordsComparisonValue !== ND_SIGN) {
        return filterRecord(record, recordsComparisonValue, searchedValue);
      }
      return '';
    },
    onFilterDropdownOpenChange: (visible: any) => {
      if (visible) {
        setTimeout(() => ref.current?.searchInput.select(), 100);
      }
    },
    render: (text: any) =>
      searchedColumn === dataIndex ? (
        <Highlighter highlightStyle={{ backgroundColor: '#ffc069', padding: 0 }} searchWords={[searchText]} autoEscape textToHighlight={text ? text.toString() : ''} />
      ) : (
        text
      ),
  });

  const getChildrenValue = (dataIndex: string | string[], record: any) => {
    if (typeof dataIndex === 'string') {
      return record[dataIndex] ? record[dataIndex] : ND_SIGN;
    } else {
      let currValue = { ...record };
      dataIndex.every((dataIndexKey: string) => {
        if (currValue && currValue[dataIndexKey]) {
          currValue = currValue[dataIndexKey];
          return true;
        } else {
          currValue = ND_SIGN;
          /* break out of cycle */
          return false;
        }
      });
      return `${currValue}`;
    }
  };

  return {
    get: useCallback(getColumnSearchProps, []), // to avoid infinite calls when inside a `useEffect`
  };
};
