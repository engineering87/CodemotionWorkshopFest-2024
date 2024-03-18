/** @format */

import { utils, write } from 'xlsx';
import { saveAs } from './FileSaver.min';

/* JSON 2 EXCEL */
/* dataJson=> {
  "sheet1":[...],
  "sheet2":[...]
} */
interface DataJson {
  ['sheet1']: any;
}

export function downloadAsExcel(dataJson: DataJson, fileName: string) {
  const workbook: any = {
    Sheets: {
      /*  data: worksheet, */
    },
    SheetNames: [] /* ["data"] */,
  };

  Object.entries(dataJson).forEach(([k, v]) => {
    workbook.Sheets[k] = utils.json_to_sheet(v);
    workbook.SheetNames.push(k);
  });

  /* const worksheet = XLSX.utils.json_to_sheet(dataJson); */

  const ExcelBuffer = write(workbook, {
    bookType: 'xlsx',
    type: 'array',
  });

  saveAsExcel(ExcelBuffer, fileName);
}

function saveAsExcel(buffer: any, filename = 'export', ext = '.xlsx') {
  const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
  const data = new Blob([buffer], { type: EXCEL_TYPE });
  saveAs(data, `${filename}${ext}`);
}

export function downloadAsCSV(JSONData: any, fileName = '') {
  Object.entries(JSONData).forEach(([k, v]: any) => {
    let filename = `${fileName}-${k}`;
    if (v.length > 0) {
      let header = Object.keys(v[0]).join(',');
      let body = v.map((row: any) => `${Object.values(row).join(',')}`);
      let csv = [header, ...body].join('\r\n');
      //Download the file as CSV
      saveAsCSV(csv, filename);
    }
  });
}

function saveAsCSV(csv: any, fileName = 'export', ext = '.csv') {
  var downloadLink = document.createElement('a');
  var blob = new Blob(['\ufeff', csv]);
  var url = URL.createObjectURL(blob);
  downloadLink.href = url;
  downloadLink.download = `${fileName}${ext}`; //Name the file here
  document.body.appendChild(downloadLink);
  downloadLink.click();
  document.body.removeChild(downloadLink);
}
