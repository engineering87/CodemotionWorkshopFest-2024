"use strict";(self.webpackChunkmy_app=self.webpackChunkmy_app||[]).push([[344],{2385:(a,t,e)=>{e.d(t,{_e:()=>n});e(446),e(9456),e(9175);function n(){let a;try{a=GetPath()}catch(t){a=""}return a}},3575:(a,t,e)=>{e.d(t,{f:()=>d,s:()=>s});var n,r,i,l=e(7528),o=e(4968),c=e(1940);const d=c.Ay.div(n||(n=(0,l.A)(["\n  ","\n  min-height: 280px;\n  margin-bottom: 24px;\n"])),(a=>{let{$background:t}=a;if(t)return(0,c.AH)(r||(r=(0,l.A)(["\n        margin-top: 24px;\n        background: white;\n        border-radius: 4px;\n        padding: 24px;\n        box-shadow: 0 1px 2px -2px rgba(0, 0, 0, 0.16), 0 3px 6px 0 rgba(0, 0, 0, 0.12), 0 5px 12px 4px rgba(0, 0, 0, 0.09) !important;\n      "])))})),s=(0,c.Ay)(o.A.Title)(i||(i=(0,l.A)(["\n  /* padding: 0px !important; */\n  /* margin: 0px !important; */\n  margin-bottom: 0px !important;\n"])))},1983:(a,t,e)=>{e.d(t,{F:()=>l});var n=e(7154),r=e(5043),i=e(2385);const l=()=>{const[a,t]=(0,r.useState)(!1),[e,l]=(0,r.useState)(null),[o,c]=(0,r.useState)(null);return{isLoading:a,error:e,data:o,execute:(0,r.useCallback)((async function(){let a=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";try{t(!0);const e=await async function(){let a=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:(0,i._e)();const e={method:"get",url:"".concat("").concat(t).concat("/api/v1/Beneficiari").concat(a),maxBodyLength:1/0,headers:{}},r=(await(0,n.A)(e)).data;return r||null}(a);return c(e),t(!1),e}catch(e){throw l(e),t(!1),e}}),[]),reset:(0,r.useCallback)((()=>{t(!1),c(null),l(null)}),[])}}},8776:(a,t,e)=>{e.d(t,{x:()=>l});var n=e(7154),r=e(5043),i=e(2385);const l=()=>{const[a,t]=(0,r.useState)(!1),[e,l]=(0,r.useState)(null),[o,c]=(0,r.useState)(null);return{isLoading:a,error:e,data:o,execute:(0,r.useCallback)((async function(){let a=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";try{t(!0);const e=await async function(){let a=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:(0,i._e)();const e={method:"get",url:"".concat("").concat(t).concat("/api/v1/PraticaOrdinaria").concat(a),headers:{}},r=(await(0,n.A)(e)).data;return r||null}(a);return c(e),t(!1),e}catch(e){throw l(e),t(!1),e}}),[]),reset:(0,r.useCallback)((()=>{t(!1),c(null),l(null)}),[])}}},7171:(a,t,e)=>{e.d(t,{Z:()=>l});var n=e(7154),r=e(5043),i=e(2385);const l=()=>{const[a,t]=(0,r.useState)(!1),[e,l]=(0,r.useState)(null),[o,c]=(0,r.useState)(null);return{isLoading:a,error:e,data:o,execute:(0,r.useCallback)((async function(){let a=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";try{t(!0);const e=await async function(){let a=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"",t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:(0,i._e)();const e={method:"get",url:"".concat("").concat(t).concat("/api/v1/PraticaStraordinaria").concat(a),headers:{}},r=(await(0,n.A)(e)).data;return r||null}(a);return c(e),t(!1),e}catch(e){throw l(e),t(!1),e}}),[]),reset:(0,r.useCallback)((()=>{t(!1),c(null),l(null)}),[])}}},5344:(a,t,e)=>{e.r(t),e.d(t,{default:()=>k});var n,r,i=e(7528),l=e(2177),o=e(9211),c=e(5397),d=e(9672),s=e(4647),u=e(9029),h=e(2968),p=e(5043),x=e(7946),g=e(9456),A=e(1940),m=e(3575),y=e(171),b=e(1983),f=e(8776),v=e(7171),j=e(579);const w=A.Ay.div(n||(n=(0,i.A)(["\n  width: 100%;\n  height: 550px;\n"]))),S=(0,A.Ay)(c.A)(r||(r=(0,i.A)(["\n  box-shadow: 0 1px 2px -2px rgba(0, 0, 0, 0.16), 0 3px 6px 0 rgba(0, 0, 0, 0.12), 0 5px 12px 4px rgba(0, 0, 0, 0.09) !important;\n"]))),k=a=>{let{SideBarId:t}=a;const e=(0,g.wA)(),n=(0,b.F)(),r=(0,f.x)(),i=(0,v.Z)(),[c,A]=(0,p.useState)({PO_percentage:0,PS_percentage:0});(0,p.useEffect)((()=>{e((0,y.kT)(t)),T(),C(),k()}),[]),(0,p.useEffect)((()=>{if(r.data&&i.data&&n.data){const a=_(r.data.data.length,r.data.data.length+i.data.data.length),t=_(i.data.data.length,r.data.data.length+i.data.data.length);A({PO_percentage:a,PS_percentage:t}),P()}}),[r.data,i.data,n.data]);const k=async()=>{await i.execute()},C=async()=>{await r.execute()},T=async()=>{await n.execute()},P=()=>{const a=new o.t1({container:"RenderBarChartTotals",autoFit:!0});a.interval().data([{Tipologia:"Pratiche ordinarie","Totale:":r.data.data.length,washaway:.21014492753623193},{Tipologia:"Pratiche straordinarie","Totale:":i.data.data.length,washaway:.5596330275229358},{Tipologia:"Beneficiari","Totale:":n.data.data.length,washaway:0}]).encode("x","Tipologia").encode("y","Totale:").encode("color","Tipologia").encode("size",40).legend("color",{layout:{justifyContent:"flex-end",alignItems:"flex-end",flexDirection:"column"},itemMarker:"circle",itemLabelFontSize:16}).style("radiusTopLeft",10).style("radiusTopRight",10).style("radiusBottomRight",10).style("radiusBottomLeft",10),a.render()},_=(a,t)=>a/t*100,L=n.isLoading||i.isLoading||r.isLoading;return(0,j.jsx)(m.f,{$background:!1,children:(0,j.jsxs)(d.A,{gutter:[24,24],children:[(0,j.jsx)(s.A,{span:24,children:(0,j.jsx)(m.s,{level:3,children:"Analytics"})}),(0,j.jsx)(s.A,{xs:24,sm:24,md:16,lg:16,xl:16,children:(0,j.jsxs)(d.A,{gutter:16,children:[(0,j.jsx)(s.A,{span:12,children:(0,j.jsx)(u.A,{spinning:L,tip:"Caricamento...",children:(0,j.jsx)(S,{bordered:!1,hoverable:!0,children:(0,j.jsx)(h.A,{title:"Pratiche ordinarie",value:c.PO_percentage,precision:2,valueStyle:{color:"#3f8600"},prefix:(0,j.jsx)(l.A,{})})})})}),(0,j.jsx)(s.A,{span:12,children:(0,j.jsx)(u.A,{spinning:L,tip:"Caricamento...",children:(0,j.jsx)(S,{bordered:!1,hoverable:!0,children:(0,j.jsx)(h.A,{title:"Pratiche straordinarie",value:c.PS_percentage,precision:2,valueStyle:{color:"#cf1322"},prefix:(0,j.jsx)(l.A,{})})})})})]})}),(0,j.jsx)(s.A,{xs:24,sm:24,md:8,lg:8,xl:8,children:(0,j.jsx)(u.A,{spinning:L,tip:"Caricamento...",children:(0,j.jsx)(S,{bordered:!1,hoverable:!0,children:(0,j.jsx)(h.A,{title:"Numero dei beneficiari",value:n.data?n.data.data.length:0,formatter:a=>(0,j.jsx)(x.A,{end:a,separator:","})})})})}),(0,j.jsx)(s.A,{span:24,children:(0,j.jsx)(u.A,{spinning:L,tip:"Caricamento...",children:(0,j.jsx)(S,{bordered:!1,hoverable:!0,children:(0,j.jsx)(w,{id:"RenderBarChartTotals"})})})})]})})}}}]);
//# sourceMappingURL=344.e0dd6cd0.chunk.js.map