gx.evt.autoSkip=!1;gx.define("ventas_inventario",!1,function(){var n,t;this.ServerClass="ventas_inventario";this.PackageName="GeneXus.Programs";this.ServerFullClass="ventas_inventario.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7IDVENTA=gx.fn.getIntegerValue("vIDVENTA",",");this.AV13Insert_IDEMPLEADO=gx.fn.getIntegerValue("vINSERT_IDEMPLEADO",",");this.AV11Insert_IDCLIENTE=gx.fn.getIntegerValue("vINSERT_IDCLIENTE",",");this.Gx_date=gx.fn.getDateValue("vTODAY");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.AV16Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Idventa=function(){return this.validSrvEvt("Valid_Idventa",0).then(function(n){return n}.closure(this))};this.Valid_Descripcionventa=function(){return this.validCliEvt("Valid_Descripcionventa",0,function(){try{var n=gx.util.balloon.getNew("DESCRIPCIONVENTA");if(this.AnyError=0,gx.text.compare("",this.A55DESCRIPCIONVENTA)==0)try{n.setError("Ingrese una descripcion sobre la venta");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Idempleado=function(){return this.validSrvEvt("Valid_Idempleado",0).then(function(n){return n}.closure(this))};this.Valid_Idcliente=function(){return this.validSrvEvt("Valid_Idcliente",0).then(function(n){return n}.closure(this))};this.Valid_Impuestoventa=function(){return this.validCliEvt("Valid_Impuestoventa",0,function(){try{var n=gx.util.balloon.getNew("IMPUESTOVENTA");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Descuentoventa=function(){return this.validSrvEvt("Valid_Descuentoventa",0).then(function(n){return n}.closure(this))};this.Valid_Idproducto=function(){var t=gx.fn.currentGridRowImpl(73),n;return gx.fn.currentGridRowImpl(73)===0?!0:(n=gx.util.balloon.getNew("IDPRODUCTO",gx.fn.currentGridRowImpl(73)),gx.fn.gridDuplicateKey(74))?(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Detalle_venta_producto","","","","","","","","")),this.AnyError=gx.num.trunc(1,0),n.show()):this.validSrvEvt("Valid_Idproducto",73).then(function(n){try{this.sMode5=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(5,73);this.standaloneModal035();this.standaloneNotModal035()}finally{this.Gx_mode=this.sMode5}return n}.closure(this))};this.standaloneModal035=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("IDPRODUCTO","Enabled",0):gx.fn.setCtrlProperty("IDPRODUCTO","Enabled",1)}catch(n){}};this.standaloneNotModal035=function(){try{gx.fn.setCtrlProperty("DESCRIPCIONPRODUCTO","Enabled",0)}catch(n){}try{gx.fn.setCtrlProperty("CANTIDADPRODUCTO","Enabled",0)}catch(n){}try{gx.fn.setCtrlProperty("PRECIOVENTAPRODUCTO","Enabled",0)}catch(n){}try{gx.fn.setCtrlProperty("SUBTOTALVENTAPRODUCTO","Enabled",0)}catch(n){}try{gx.fn.setCtrlProperty("IMPUESTOVENTA","Enabled",0)}catch(n){}try{gx.fn.setCtrlProperty("TOTALVENTA","Enabled",0)}catch(n){}try{gx.fn.setCtrlProperty("IMPUESTOVENTA","Enabled",0)}catch(n){}try{gx.fn.setCtrlProperty("TOTALVENTA","Enabled",0)}catch(n){}};this.e12032_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13034_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14034_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105];this.GXLastCtrlId=105;this.Gridventas_inventario_detalle_venta_productoContainer=new gx.grid.grid(this,5,"Detalle_venta_producto",73,"Gridventas_inventario_detalle_venta_producto","Gridventas_inventario_detalle_venta_producto","Gridventas_inventario_detalle_venta_productoContainer",this.CmpContext,this.IsMasterPage,"ventas_inventario",[7],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridventas_inventario_detalle_venta_productoContainer;t.addSingleLineEdit(7,74,"IDPRODUCTO","IDPRODUCTO","","IDPRODUCTO","int",0,"px",12,12,"right",null,[],7,"IDPRODUCTO",!0,0,!1,!1,"Attribute",1,"");t.addBitmap("prompt_7","PROMPT_7",105,0,"",0,"",null,"","","gx-prompt Image","");t.addSingleLineEdit(40,75,"DESCRIPCIONPRODUCTO","DESCRIPCIONPRODUCTO","","DESCRIPCIONPRODUCTO","svchar",0,"px",255,80,"left",null,[],40,"DESCRIPCIONPRODUCTO",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(41,76,"CANTIDADPRODUCTO","CANTIDADPRODUCTO","","CANTIDADPRODUCTO","int",0,"px",12,12,"right",null,[],41,"CANTIDADPRODUCTO",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(43,77,"PRECIOVENTAPRODUCTO","PRECIOVENTAPRODUCTO","","PRECIOVENTAPRODUCTO","decimal",0,"px",12,12,"right",null,[],43,"PRECIOVENTAPRODUCTO",!0,2,!1,!1,"Attribute",1,"");t.addSingleLineEdit(56,78,"SUBTOTALVENTAPRODUCTO","SUBTOTALVENTAPRODUCTO","","SUBTOTALVENTAPRODUCTO","decimal",0,"px",12,12,"right",null,[],56,"SUBTOTALVENTAPRODUCTO",!0,2,!1,!1,"Attribute",1,"");this.Gridventas_inventario_detalle_venta_productoContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15034_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16034_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17034_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18034_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19034_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Idventa,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridventas_inventario_detalle_venta_productoContainer],fld:"IDVENTA",gxz:"Z12IDVENTA",gxold:"O12IDVENTA",gxvar:"A12IDVENTA",ucs:[],op:[83],ip:[83,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12IDVENTA=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12IDVENTA=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("IDVENTA",gx.O.A12IDVENTA,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A12IDVENTA=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("IDVENTA",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHAVENTA",gxz:"Z54FECHAVENTA",gxold:"O54FECHAVENTA",gxvar:"A54FECHAVENTA",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A54FECHAVENTA=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z54FECHAVENTA=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("FECHAVENTA",gx.O.A54FECHAVENTA,0)},c2v:function(){this.val()!==undefined&&(gx.O.A54FECHAVENTA=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("FECHAVENTA")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:this.Valid_Descripcionventa,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCIONVENTA",gxz:"Z55DESCRIPCIONVENTA",gxold:"O55DESCRIPCIONVENTA",gxvar:"A55DESCRIPCIONVENTA",ucs:[],op:[44],ip:[44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A55DESCRIPCIONVENTA=n)},v2z:function(n){n!==undefined&&(gx.O.Z55DESCRIPCIONVENTA=n)},v2c:function(){gx.fn.setControlValue("DESCRIPCIONVENTA",gx.O.A55DESCRIPCIONVENTA,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A55DESCRIPCIONVENTA=this.val())},val:function(){return gx.fn.getControlValue("DESCRIPCIONVENTA")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Idempleado,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDEMPLEADO",gxz:"Z1IDEMPLEADO",gxold:"O1IDEMPLEADO",gxvar:"A1IDEMPLEADO",ucs:[],op:[49,54],ip:[54,49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1IDEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1IDEMPLEADO=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("IDEMPLEADO",gx.O.A1IDEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1IDEMPLEADO=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("IDEMPLEADO",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV13Insert_IDEMPLEADO)}};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOMBRECOMPLETOEMPLEADO",gxz:"Z23NOMBRECOMPLETOEMPLEADO",gxold:"O23NOMBRECOMPLETOEMPLEADO",gxvar:"A23NOMBRECOMPLETOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23NOMBRECOMPLETOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.Z23NOMBRECOMPLETOEMPLEADO=n)},v2c:function(){gx.fn.setControlValue("NOMBRECOMPLETOEMPLEADO",gx.O.A23NOMBRECOMPLETOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A23NOMBRECOMPLETOEMPLEADO=this.val())},val:function(){return gx.fn.getControlValue("NOMBRECOMPLETOEMPLEADO")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Idcliente,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDCLIENTE",gxz:"Z4IDCLIENTE",gxold:"O4IDCLIENTE",gxvar:"A4IDCLIENTE",ucs:[],op:[59,64],ip:[64,59],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4IDCLIENTE=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4IDCLIENTE=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("IDCLIENTE",gx.O.A4IDCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A4IDCLIENTE=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("IDCLIENTE",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV11Insert_IDCLIENTE)}};this.declareDomainHdlr(59,function(){});n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOMBRECOMPLETOCLIENTE",gxz:"Z30NOMBRECOMPLETOCLIENTE",gxold:"O30NOMBRECOMPLETOCLIENTE",gxvar:"A30NOMBRECOMPLETOCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30NOMBRECOMPLETOCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z30NOMBRECOMPLETOCLIENTE=n)},v2c:function(){gx.fn.setControlValue("NOMBRECOMPLETOCLIENTE",gx.O.A30NOMBRECOMPLETOCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A30NOMBRECOMPLETOCLIENTE=this.val())},val:function(){return gx.fn.getControlValue("NOMBRECOMPLETOCLIENTE")},nac:gx.falseFn};this.declareDomainHdlr(64,function(){});n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"DETALLE_VENTA_PRODUCTOTABLE",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"TITLEDETALLE_VENTA_PRODUCTO",format:0,grid:0,ctrltype:"textblock"};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[74]={id:74,lvl:5,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:1,grid:73,gxgrid:this.Gridventas_inventario_detalle_venta_productoContainer,fnc:this.Valid_Idproducto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDPRODUCTO",gxz:"Z7IDPRODUCTO",gxold:"O7IDPRODUCTO",gxvar:"A7IDPRODUCTO",ucs:[],op:[74,78,77,76,75],ip:[78,77,76,75,74],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A7IDPRODUCTO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7IDPRODUCTO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDPRODUCTO",n||gx.fn.currentGridRowImpl(73),gx.O.A7IDPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7IDPRODUCTO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDPRODUCTO",n||gx.fn.currentGridRowImpl(73),",")},nac:gx.falseFn};n[75]={id:75,lvl:5,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:1,grid:73,gxgrid:this.Gridventas_inventario_detalle_venta_productoContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCIONPRODUCTO",gxz:"Z40DESCRIPCIONPRODUCTO",gxold:"O40DESCRIPCIONPRODUCTO",gxvar:"A40DESCRIPCIONPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A40DESCRIPCIONPRODUCTO=n)},v2z:function(n){n!==undefined&&(gx.O.Z40DESCRIPCIONPRODUCTO=n)},v2c:function(n){gx.fn.setGridControlValue("DESCRIPCIONPRODUCTO",n||gx.fn.currentGridRowImpl(73),gx.O.A40DESCRIPCIONPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A40DESCRIPCIONPRODUCTO=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DESCRIPCIONPRODUCTO",n||gx.fn.currentGridRowImpl(73))},nac:gx.falseFn};n[76]={id:76,lvl:5,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:1,grid:73,gxgrid:this.Gridventas_inventario_detalle_venta_productoContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CANTIDADPRODUCTO",gxz:"Z41CANTIDADPRODUCTO",gxold:"O41CANTIDADPRODUCTO",gxvar:"A41CANTIDADPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A41CANTIDADPRODUCTO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z41CANTIDADPRODUCTO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CANTIDADPRODUCTO",n||gx.fn.currentGridRowImpl(73),gx.O.A41CANTIDADPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A41CANTIDADPRODUCTO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CANTIDADPRODUCTO",n||gx.fn.currentGridRowImpl(73),",")},nac:gx.falseFn};n[77]={id:77,lvl:5,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,isacc:1,grid:73,gxgrid:this.Gridventas_inventario_detalle_venta_productoContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOVENTAPRODUCTO",gxz:"Z43PRECIOVENTAPRODUCTO",gxold:"O43PRECIOVENTAPRODUCTO",gxvar:"A43PRECIOVENTAPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A43PRECIOVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z43PRECIOVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRECIOVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(73),gx.O.A43PRECIOVENTAPRODUCTO,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A43PRECIOVENTAPRODUCTO=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRECIOVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(73),",",".")},nac:gx.falseFn};n[78]={id:78,lvl:5,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,isacc:1,grid:73,gxgrid:this.Gridventas_inventario_detalle_venta_productoContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUBTOTALVENTAPRODUCTO",gxz:"Z56SUBTOTALVENTAPRODUCTO",gxold:"O56SUBTOTALVENTAPRODUCTO",gxvar:"A56SUBTOTALVENTAPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A56SUBTOTALVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z56SUBTOTALVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("SUBTOTALVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(73),gx.O.A56SUBTOTALVENTAPRODUCTO,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A56SUBTOTALVENTAPRODUCTO=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("SUBTOTALVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(73),",",".")},nac:gx.falseFn};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,lvl:0,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Impuestoventa,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPUESTOVENTA",gxz:"Z57IMPUESTOVENTA",gxold:"O57IMPUESTOVENTA",gxvar:"A57IMPUESTOVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A57IMPUESTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z57IMPUESTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("IMPUESTOVENTA",gx.O.A57IMPUESTOVENTA,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A57IMPUESTOVENTA=this.val())},val:function(){return gx.fn.getDecimalValue("IMPUESTOVENTA",",",".")},nac:gx.falseFn};this.declareDomainHdlr(83,function(){});n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[88]={id:88,lvl:0,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Descuentoventa,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCUENTOVENTA",gxz:"Z58DESCUENTOVENTA",gxold:"O58DESCUENTOVENTA",gxvar:"A58DESCUENTOVENTA",ucs:[],op:[93],ip:[93,88,83,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A58DESCUENTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z58DESCUENTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("DESCUENTOVENTA",gx.O.A58DESCUENTOVENTA,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A58DESCUENTOVENTA=this.val())},val:function(){return gx.fn.getDecimalValue("DESCUENTOVENTA",",",".")},nac:gx.falseFn};this.declareDomainHdlr(88,function(){});n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,lvl:0,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TOTALVENTA",gxz:"Z59TOTALVENTA",gxold:"O59TOTALVENTA",gxvar:"A59TOTALVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A59TOTALVENTA=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z59TOTALVENTA=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("TOTALVENTA",gx.O.A59TOTALVENTA,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A59TOTALVENTA=this.val())},val:function(){return gx.fn.getDecimalValue("TOTALVENTA",",",".")},nac:gx.falseFn};this.declareDomainHdlr(93,function(){});n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"BTN_ENTER",grid:0,evt:"e13034_client",std:"ENTER"};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"BTN_CANCEL",grid:0,evt:"e14034_client"};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"BTN_DELETE",grid:0,evt:"e20034_client",std:"DELETE"};n[103]={id:103,fld:"PROMPT_1",grid:4};n[104]={id:104,fld:"PROMPT_4",grid:4};n[105]={id:105,fld:"PROMPT_7",grid:5};this.A12IDVENTA=0;this.Z12IDVENTA=0;this.O12IDVENTA=0;this.A54FECHAVENTA=gx.date.nullDate();this.Z54FECHAVENTA=gx.date.nullDate();this.O54FECHAVENTA=gx.date.nullDate();this.A55DESCRIPCIONVENTA="";this.Z55DESCRIPCIONVENTA="";this.O55DESCRIPCIONVENTA="";this.A1IDEMPLEADO=0;this.Z1IDEMPLEADO=0;this.O1IDEMPLEADO=0;this.A23NOMBRECOMPLETOEMPLEADO="";this.Z23NOMBRECOMPLETOEMPLEADO="";this.O23NOMBRECOMPLETOEMPLEADO="";this.A4IDCLIENTE=0;this.Z4IDCLIENTE=0;this.O4IDCLIENTE=0;this.A30NOMBRECOMPLETOCLIENTE="";this.Z30NOMBRECOMPLETOCLIENTE="";this.O30NOMBRECOMPLETOCLIENTE="";this.Z7IDPRODUCTO=0;this.O7IDPRODUCTO=0;this.Z40DESCRIPCIONPRODUCTO="";this.O40DESCRIPCIONPRODUCTO="";this.Z41CANTIDADPRODUCTO=0;this.O41CANTIDADPRODUCTO=0;this.Z43PRECIOVENTAPRODUCTO=0;this.O43PRECIOVENTAPRODUCTO=0;this.Z56SUBTOTALVENTAPRODUCTO=0;this.O56SUBTOTALVENTAPRODUCTO=0;this.A57IMPUESTOVENTA=0;this.Z57IMPUESTOVENTA=0;this.O57IMPUESTOVENTA=0;this.A58DESCUENTOVENTA=0;this.Z58DESCUENTOVENTA=0;this.O58DESCUENTOVENTA=0;this.A59TOTALVENTA=0;this.Z59TOTALVENTA=0;this.O59TOTALVENTA=0;this.A7IDPRODUCTO=0;this.A40DESCRIPCIONPRODUCTO="";this.A41CANTIDADPRODUCTO=0;this.A43PRECIOVENTAPRODUCTO=0;this.A56SUBTOTALVENTAPRODUCTO=0;this.AV16Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV13Insert_IDEMPLEADO=0;this.AV11Insert_IDCLIENTE=0;this.AV17GXV1=0;this.AV12TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7IDVENTA=0;this.AV10WebSession={};this.A12IDVENTA=0;this.A1IDEMPLEADO=0;this.A4IDCLIENTE=0;this.Gx_BScreen=0;this.Gx_date=gx.date.nullDate();this.A59TOTALVENTA=0;this.A54FECHAVENTA=gx.date.nullDate();this.A55DESCRIPCIONVENTA="";this.A23NOMBRECOMPLETOEMPLEADO="";this.A30NOMBRECOMPLETOCLIENTE="";this.A57IMPUESTOVENTA=0;this.A58DESCUENTOVENTA=0;this.Gx_mode="";this.Events={e12032_client:["AFTER TRN",!0],e13034_client:["ENTER",!0],e14034_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"A12IDVENTA",fld:"IDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"A54FECHAVENTA",fld:"FECHAVENTA",pic:""},{av:"A58DESCUENTOVENTA",fld:"DESCUENTOVENTA",pic:"ZZZZZZZZ9.99"}],[]];this.EvtParms.START=[[{av:"AV16Pgmname",fld:"vPGMNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV13Insert_IDEMPLEADO",fld:"vINSERT_IDEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV11Insert_IDCLIENTE",fld:"vINSERT_IDCLIENTE",pic:"ZZZZZZZZZZZ9"},{av:"AV17GXV1",fld:"vGXV1",pic:"99999999"},{av:"AV12TrnContextAtt",fld:"vTRNCONTEXTATT",pic:""}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_IDVENTA=[[{av:"A12IDVENTA",fld:"IDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"A57IMPUESTOVENTA",fld:"IMPUESTOVENTA",pic:"ZZZZZZZZ9.99"}],[{av:"A57IMPUESTOVENTA",fld:"IMPUESTOVENTA",pic:"ZZZZZZZZ9.99"}]];this.EvtParms.VALID_DESCRIPCIONVENTA=[[{av:"A55DESCRIPCIONVENTA",fld:"DESCRIPCIONVENTA",pic:""}],[{av:"A55DESCRIPCIONVENTA",fld:"DESCRIPCIONVENTA",pic:""}]];this.EvtParms.VALID_IDEMPLEADO=[[{av:"A1IDEMPLEADO",fld:"IDEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"A23NOMBRECOMPLETOEMPLEADO",fld:"NOMBRECOMPLETOEMPLEADO",pic:""}],[{av:"A23NOMBRECOMPLETOEMPLEADO",fld:"NOMBRECOMPLETOEMPLEADO",pic:""}]];this.EvtParms.VALID_IDCLIENTE=[[{av:"A4IDCLIENTE",fld:"IDCLIENTE",pic:"ZZZZZZZZZZZ9"},{av:"A30NOMBRECOMPLETOCLIENTE",fld:"NOMBRECOMPLETOCLIENTE",pic:""}],[{av:"A30NOMBRECOMPLETOCLIENTE",fld:"NOMBRECOMPLETOCLIENTE",pic:""}]];this.EvtParms.VALID_IMPUESTOVENTA=[[],[]];this.EvtParms.VALID_DESCUENTOVENTA=[[{av:"A12IDVENTA",fld:"IDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"A57IMPUESTOVENTA",fld:"IMPUESTOVENTA",pic:"ZZZZZZZZ9.99"},{av:"A58DESCUENTOVENTA",fld:"DESCUENTOVENTA",pic:"ZZZZZZZZ9.99"},{av:"A59TOTALVENTA",fld:"TOTALVENTA",pic:"ZZZZZZZZ9.99"}],[{av:"A59TOTALVENTA",fld:"TOTALVENTA",pic:"ZZZZZZZZ9.99"}]];this.EvtParms.VALID_IDPRODUCTO=[[{av:"A7IDPRODUCTO",fld:"IDPRODUCTO",pic:"ZZZZZZZZZZZ9"},{av:"A40DESCRIPCIONPRODUCTO",fld:"DESCRIPCIONPRODUCTO",pic:""},{av:"A41CANTIDADPRODUCTO",fld:"CANTIDADPRODUCTO",pic:"ZZZZZZZZZZZ9"},{av:"A43PRECIOVENTAPRODUCTO",fld:"PRECIOVENTAPRODUCTO",pic:"ZZZZZZZZ9.99"},{av:"A56SUBTOTALVENTAPRODUCTO",fld:"SUBTOTALVENTAPRODUCTO",pic:"ZZZZZZZZ9.99"}],[{av:"A40DESCRIPCIONPRODUCTO",fld:"DESCRIPCIONPRODUCTO",pic:""},{av:"A41CANTIDADPRODUCTO",fld:"CANTIDADPRODUCTO",pic:"ZZZZZZZZZZZ9"},{av:"A43PRECIOVENTAPRODUCTO",fld:"PRECIOVENTAPRODUCTO",pic:"ZZZZZZZZ9.99"},{av:"A56SUBTOTALVENTAPRODUCTO",fld:"SUBTOTALVENTAPRODUCTO",pic:"ZZZZZZZZ9.99"}]];this.setPrompt("PROMPT_1",[49]);this.setPrompt("PROMPT_4",[59]);this.setPrompt("PROMPT_7",[74]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7IDVENTA","vIDVENTA",0,"int",12,0);this.setVCMap("AV13Insert_IDEMPLEADO","vINSERT_IDEMPLEADO",0,"int",12,0);this.setVCMap("AV11Insert_IDCLIENTE","vINSERT_IDCLIENTE",0,"int",12,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV16Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.ventas_inventario)})