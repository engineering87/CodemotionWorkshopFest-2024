(self.webpackChunkmy_app=self.webpackChunkmy_app||[]).push([[912],{2385:(e,t,n)=>{"use strict";n.d(t,{_e:()=>a});n(446),n(9456),n(9175);function a(){let e;try{e=GetPath()}catch(t){e=""}return e}},7652:function(e,t,n){var a="object"==typeof window&&window.window===window?window:"object"==typeof self&&self.self===self?self:"object"==typeof n.g&&n.g.global===n.g?n.g:this;function o(e,t,n){var a=new XMLHttpRequest;a.open("GET",e),a.responseType="blob",a.onload=function(){s(a.response,t,n)},a.onerror=function(){console.error("could not download file")},a.send()}function r(e){var t=new XMLHttpRequest;t.open("HEAD",e,!1);try{t.send()}catch(e){}return t.status>=200&&t.status<=299}function i(e){try{e.dispatchEvent(new MouseEvent("click"))}catch(s){var t=document.createEvent("MouseEvents");t.initMouseEvent("click",!0,!0,window,0,0,0,80,20,!1,!1,!1,!1,0,null),e.dispatchEvent(t)}}var c=/Macintosh/.test(navigator.userAgent)&&/AppleWebKit/.test(navigator.userAgent)&&!/Safari/.test(navigator.userAgent),s=a.saveAs||("object"!=typeof window||window!==a?function(){}:"download"in HTMLAnchorElement.prototype&&!c?function(e,t,n){var c=a.URL||a.webkitURL,s=document.createElement("a");t=t||e.name||"download",s.download=t,s.rel="noopener","string"==typeof e?(s.href=e,s.origin!==location.origin?r(s.href)?o(e,t,n):i(s,s.target="_blank"):i(s)):(s.href=c.createObjectURL(e),setTimeout((function(){c.revokeObjectURL(s.href)}),4e4),setTimeout((function(){i(s)}),0))}:"msSaveOrOpenBlob"in navigator?function(e,t,n){if(t=t||e.name||"download","string"==typeof e)if(r(e))o(e,t,n);else{var a=document.createElement("a");a.href=e,a.target="_blank",setTimeout((function(){i(a)}))}else navigator.msSaveOrOpenBlob(function(e,t){return void 0===t?t={autoBom:!1}:"object"!=typeof t&&(console.warn("Deprecated: Expected third argument to be a object"),t={autoBom:!t}),t.autoBom&&/^\s*(?:text\/\S*|application\/xml|\S*\/\S*\+xml)\s*;.*charset\s*=\s*utf-8/i.test(e.type)?new Blob([String.fromCharCode(65279),e],{type:e.type}):e}(e,n),t)}:function(e,t,n,r){if((r=r||open("","_blank"))&&(r.document.title=r.document.body.innerText="downloading..."),"string"==typeof e)return o(e,t,n);var i="application/octet-stream"===e.type,s=/constructor/i.test(a.HTMLElement)||a.safari,l=/CriOS\/[\d]+/.test(navigator.userAgent);if((l||i&&s||c)&&"undefined"!=typeof FileReader){var d=new FileReader;d.onloadend=function(){var e=d.result;e=l?e:e.replace(/^data:[^;]*;/,"data:attachment/file;"),r?r.location.href=e:location=e,r=null},d.readAsDataURL(e)}else{var u=a.URL||a.webkitURL,p=u.createObjectURL(e);r?r.location=p:location.href=p,r=null,setTimeout((function(){u.revokeObjectURL(p)}),4e4)}});a.saveAs=s.saveAs=s,e.exports=s},3258:(e,t,n)=>{"use strict";n.d(t,{f:()=>i,u:()=>r});var a=n(1238),o=n(7652);function r(e,t){const n={Sheets:{},SheetNames:[]};Object.entries(e).forEach((e=>{let[t,o]=e;n.Sheets[t]=a.Wp.json_to_sheet(o),n.SheetNames.push(t)}));!function(e){let t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:"export",n=arguments.length>2&&void 0!==arguments[2]?arguments[2]:".xlsx";const a=new Blob([e],{type:"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8"});(0,o.saveAs)(a,"".concat(t).concat(n))}((0,a.M9)(n,{bookType:"xlsx",type:"array"}),t)}function i(e){let t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:"";Object.entries(e).forEach((e=>{let[n,a]=e,o="".concat(t,"-").concat(n);if(a.length>0){!function(e){let t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:"export",n=arguments.length>2&&void 0!==arguments[2]?arguments[2]:".csv";var a=document.createElement("a"),o=new Blob(["\ufeff",e]),r=URL.createObjectURL(o);a.href=r,a.download="".concat(t).concat(n),document.body.appendChild(a),a.click(),document.body.removeChild(a)}([Object.keys(a[0]).join(","),...a.map((e=>"".concat(Object.values(e).join(","))))].join("\r\n"),o)}}))}},3575:(e,t,n)=>{"use strict";n.d(t,{f:()=>l,s:()=>d});var a,o,r,i=n(7528),c=n(4968),s=n(1940);const l=s.Ay.div(a||(a=(0,i.A)(["\n  ","\n  min-height: 280px;\n  margin-bottom: 24px;\n"])),(e=>{let{$background:t}=e;if(t)return(0,s.AH)(o||(o=(0,i.A)(["\n        margin-top: 24px;\n        background: white;\n        border-radius: 4px;\n        padding: 24px;\n        box-shadow: 0 1px 2px -2px rgba(0, 0, 0, 0.16), 0 3px 6px 0 rgba(0, 0, 0, 0.12), 0 5px 12px 4px rgba(0, 0, 0, 0.09) !important;\n      "])))})),d=(0,s.Ay)(c.A.Title)(r||(r=(0,i.A)(["\n  /* padding: 0px !important; */\n  /* margin: 0px !important; */\n  margin-bottom: 0px !important;\n"])))},4651:(e,t,n)=>{"use strict";n.d(t,{H:()=>p});var a=n(2058),o=n(8463),r=n(521),i=n(6051),c=n(8223),s=n(5043),l=n(6854),d=n.n(l),u=n(579);const p=()=>{const e="".concat("non disponibile"),t=(0,s.useRef)(),[n,l]=(0,s.useState)(""),[p,f]=(0,s.useState)(),g=(e,t,n)=>{t(),l(e[0]),f(n)},h=(t,n)=>{if("string"===typeof t)return n[t]?n[t]:e;{let a={...n};return t.every((t=>a&&a[t]?(a=a[t],!0):(a=e,!1))),"".concat(a)}};return{get:(0,s.useCallback)(((s,m)=>({filterDropdown:e=>{let{setSelectedKeys:n,selectedKeys:o,confirm:d,clearFilters:p}=e;return(0,u.jsxs)("div",{style:{padding:8},children:[(0,u.jsx)(r.A,{ref:e=>{var n;return(null===(n=t.current)||void 0===n?void 0:n.searchInput)==e},placeholder:m||"Cerca ".concat(s),value:o[0],onChange:e=>n(e.target.value?[e.target.value]:[]),onPressEnter:()=>g(o,d,s),style:{marginBottom:8,display:"block"}}),(0,u.jsxs)(i.A,{children:[(0,u.jsx)(c.Ay,{type:"primary",onClick:()=>g(o,d,s),icon:(0,u.jsx)(a.A,{}),size:"small",style:{width:90},children:"Cerca"}),(0,u.jsx)(c.Ay,{onClick:()=>((e,t)=>{t(),l(""),f(void 0),e()})(d,p),size:"small",style:{width:90},children:"Cancella"})]})]})},filterIcon:e=>e?(0,u.jsx)(o.A,{style:{color:"#1890ff",fontSize:"15px"}}):(0,u.jsx)(a.A,{style:{color:"#1890ff",fontSize:"15px"}}),onFilter:(t,n)=>{const a=h(s,n);return a&&a!==e?((e,t,n)=>{let a=t,o=n.replace("*",".*");return new RegExp(o,"gim").test(a)})(0,a,t):""},onFilterDropdownOpenChange:e=>{e&&setTimeout((()=>{var e;return null===(e=t.current)||void 0===e?void 0:e.searchInput.select()}),100)},render:e=>p===s?(0,u.jsx)(d(),{highlightStyle:{backgroundColor:"#ffc069",padding:0},searchWords:[n],autoEscape:!0,textToHighlight:e?e.toString():""}):e})),[])}}},8515:(e,t,n)=>{"use strict";n.d(t,{a:()=>i});var a=n(7154),o=n(5043),r=n(2385);const i=()=>{const[e,t]=(0,o.useState)(!1),[n,i]=(0,o.useState)(null),[c,s]=(0,o.useState)(null);return{isLoading:e,error:n,data:c,execute:(0,o.useCallback)((async function(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";try{t(!0);const n=await async function(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:(0,r._e)();const n={method:"get",url:"".concat("").concat(t).concat("/api/v1/Beneficiari").concat(e),headers:{}},o=(await(0,a.A)(n)).data;return o||null}(e);return s(n),t(!1),n}catch(n){throw i(n),t(!1),n}}),[]),reset:(0,o.useCallback)((()=>{t(!1),s(null),i(null)}),[])}}},8776:(e,t,n)=>{"use strict";n.d(t,{x:()=>i});var a=n(7154),o=n(5043),r=n(2385);const i=()=>{const[e,t]=(0,o.useState)(!1),[n,i]=(0,o.useState)(null),[c,s]=(0,o.useState)(null);return{isLoading:e,error:n,data:c,execute:(0,o.useCallback)((async function(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";try{t(!0);const n=await async function(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:(0,r._e)();const n={method:"get",url:"".concat("").concat(t).concat("/api/v1/PraticaOrdinaria").concat(e),headers:{}},o=(await(0,a.A)(n)).data;return o||null}(e);return s(n),t(!1),n}catch(n){throw i(n),t(!1),n}}),[]),reset:(0,o.useCallback)((()=>{t(!1),s(null),i(null)}),[])}}},8912:(e,t,n)=>{"use strict";n.r(t),n.d(t,{default:()=>x});var a=n(5217),o=n(9672),r=n(4647),i=n(8223),c=n(8658),s=n(446),l=n.n(s),d=n(5043),u=n(9456),p=n(3258),f=n(3575),g=n(4651),h=n(171),m=n(8515),v=n(8776),b=n(579);const x=e=>{let{SideBarId:t}=e;const n=(0,u.wA)(),s=(0,v.x)(),x=(0,m.a)(),y=(0,g.H)(),[w,j]=(0,d.useState)([]);(0,d.useEffect)((()=>{k(),n((0,h.kT)(t))}),[]);const k=async()=>{const e=(await s.execute()).data.map((async e=>{const t=await x.execute("/".concat(e.idBeneficiario));return{...e,beneficiario:t.data}}));Promise.all(e).then((e=>{j(e)}))},A=[{title:"Numero Pratica",dataIndex:"id",key:"id",...y.get("id")},{title:"Beneficiario",dataIndex:["beneficiario","nome"],key:"keyBeneficiario",align:"center",...y.get(["beneficiario","nome"]),render:(e,t)=>"".concat(t.beneficiario.nome.substring(0,1),". ").concat(t.beneficiario.cognome)},{title:"Data Inserimento",dataIndex:"dataInserimento",key:"dataInserimento",align:"center",...y.get("dataInserimento"),render:e=>l()(e,"YYYY-MM-DD").format("DD/MM/YYYY")},{title:"Pagamento",dataIndex:["pagamento","descrizione"],key:"pagamento",align:"center",...y.get(["pagamento","descrizione"])},{title:"Tipo",dataIndex:["tipo","descrizione"],key:"tipo",align:"center",...y.get(["tipo","descrizione"])}];let S=s.isLoading;return(0,b.jsxs)(b.Fragment,{children:[(0,b.jsx)(f.s,{level:3,children:"Lista Pratiche Ordinarie"}),(0,b.jsx)(f.f,{$background:!0,children:(0,b.jsxs)(o.A,{gutter:[24,24],children:[(0,b.jsx)(r.A,{children:(0,b.jsx)(i.Ay,{size:"large",className:"btn-extra",type:"primary",icon:(0,b.jsx)(a.A,{}),onClick:()=>{((e,t)=>{const n=l()().format("YYYYMMDD_HHmmss"),a="Pratiche_".concat(n);let o={};switch(Object.values(e).forEach((e=>{o[e.label]=e.dataSource.map((e=>({"Numero Pratica":e.id})))})),t){case"XLSX":(0,p.u)(o,a);break;case"CSV":(0,p.f)(o,a)}})([{label:"Pratiche Ordinarie",dataSource:w}],"XLSX")},children:"Esporta"})}),(0,b.jsx)(r.A,{span:24,children:(0,b.jsx)(c.A,{loading:S,dataSource:w,columns:A,bordered:!0})})]})})]})}}}]);
//# sourceMappingURL=912.e7319210.chunk.js.map