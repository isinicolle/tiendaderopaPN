gx.evt.autoSkip=!1;gx.define("ventas_inventariodetalle_venta_productowc",!0,function(n){var t,i;this.ServerClass="ventas_inventariodetalle_venta_productowc";this.PackageName="GeneXus.Programs";this.ServerFullClass="ventas_inventariodetalle_venta_productowc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6IDVENTA=gx.fn.getIntegerValue("vIDVENTA",",");this.AV6IDVENTA=gx.fn.getIntegerValue("vIDVENTA",",")};this.Valid_Idproducto=function(){var n=gx.fn.currentGridRowImpl(12);return this.validCliEvt("Valid_Idproducto",12,function(){try{if(gx.fn.currentGridRowImpl(12)===0)return!0;var n=gx.util.balloon.getNew("IDPRODUCTO",gx.fn.currentGridRowImpl(12));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e131o2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e141o2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,16,17,18,19,20,21];this.GXLastCtrlId=21;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"ventas_inventariodetalle_venta_productowc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(7,13,"IDPRODUCTO","IDPRODUCTO","","IDPRODUCTO","int",0,"px",12,12,"right",null,[],7,"IDPRODUCTO",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(40,14,"DESCRIPCIONPRODUCTO","DESCRIPCIONPRODUCTO","","DESCRIPCIONPRODUCTO","svchar",0,"px",255,80,"left",null,[],40,"DESCRIPCIONPRODUCTO",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(41,15,"CANTIDADPRODUCTO","CANTIDADPRODUCTO","","CANTIDADPRODUCTO","int",0,"px",12,12,"right",null,[],41,"CANTIDADPRODUCTO",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(43,16,"PRECIOVENTAPRODUCTO","PRECIOVENTAPRODUCTO","","PRECIOVENTAPRODUCTO","decimal",0,"px",12,12,"right",null,[],43,"PRECIOVENTAPRODUCTO",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(56,17,"SUBTOTALVENTAPRODUCTO","SUBTOTALVENTAPRODUCTO","","SUBTOTALVENTAPRODUCTO","decimal",0,"px",12,12,"right",null,[],56,"SUBTOTALVENTAPRODUCTO",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[13]={id:13,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:this.Valid_Idproducto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDPRODUCTO",gxz:"Z7IDPRODUCTO",gxold:"O7IDPRODUCTO",gxvar:"A7IDPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A7IDPRODUCTO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7IDPRODUCTO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDPRODUCTO",n||gx.fn.currentGridRowImpl(12),gx.O.A7IDPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7IDPRODUCTO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDPRODUCTO",n||gx.fn.currentGridRowImpl(12),",")},nac:gx.falseFn};t[14]={id:14,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCIONPRODUCTO",gxz:"Z40DESCRIPCIONPRODUCTO",gxold:"O40DESCRIPCIONPRODUCTO",gxvar:"A40DESCRIPCIONPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A40DESCRIPCIONPRODUCTO=n)},v2z:function(n){n!==undefined&&(gx.O.Z40DESCRIPCIONPRODUCTO=n)},v2c:function(n){gx.fn.setGridControlValue("DESCRIPCIONPRODUCTO",n||gx.fn.currentGridRowImpl(12),gx.O.A40DESCRIPCIONPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A40DESCRIPCIONPRODUCTO=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DESCRIPCIONPRODUCTO",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};t[15]={id:15,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CANTIDADPRODUCTO",gxz:"Z41CANTIDADPRODUCTO",gxold:"O41CANTIDADPRODUCTO",gxvar:"A41CANTIDADPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A41CANTIDADPRODUCTO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z41CANTIDADPRODUCTO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CANTIDADPRODUCTO",n||gx.fn.currentGridRowImpl(12),gx.O.A41CANTIDADPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A41CANTIDADPRODUCTO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CANTIDADPRODUCTO",n||gx.fn.currentGridRowImpl(12),",")},nac:gx.falseFn};t[16]={id:16,lvl:2,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOVENTAPRODUCTO",gxz:"Z43PRECIOVENTAPRODUCTO",gxold:"O43PRECIOVENTAPRODUCTO",gxvar:"A43PRECIOVENTAPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A43PRECIOVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z43PRECIOVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRECIOVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(12),gx.O.A43PRECIOVENTAPRODUCTO,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A43PRECIOVENTAPRODUCTO=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRECIOVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(12),",",".")},nac:gx.falseFn};t[17]={id:17,lvl:2,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUBTOTALVENTAPRODUCTO",gxz:"Z56SUBTOTALVENTAPRODUCTO",gxold:"O56SUBTOTALVENTAPRODUCTO",gxvar:"A56SUBTOTALVENTAPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A56SUBTOTALVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z56SUBTOTALVENTAPRODUCTO=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("SUBTOTALVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(12),gx.O.A56SUBTOTALVENTAPRODUCTO,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A56SUBTOTALVENTAPRODUCTO=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("SUBTOTALVENTAPRODUCTO",n||gx.fn.currentGridRowImpl(12),",",".")},nac:gx.falseFn};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDVENTA",gxz:"Z12IDVENTA",gxold:"O12IDVENTA",gxvar:"A12IDVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12IDVENTA=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12IDVENTA=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("IDVENTA",gx.O.A12IDVENTA,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A12IDVENTA=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("IDVENTA",",")},nac:gx.falseFn};this.declareDomainHdlr(21,function(){});this.Z7IDPRODUCTO=0;this.O7IDPRODUCTO=0;this.Z40DESCRIPCIONPRODUCTO="";this.O40DESCRIPCIONPRODUCTO="";this.Z41CANTIDADPRODUCTO=0;this.O41CANTIDADPRODUCTO=0;this.Z43PRECIOVENTAPRODUCTO=0;this.O43PRECIOVENTAPRODUCTO=0;this.Z56SUBTOTALVENTAPRODUCTO=0;this.O56SUBTOTALVENTAPRODUCTO=0;this.A12IDVENTA=0;this.Z12IDVENTA=0;this.O12IDVENTA=0;this.A12IDVENTA=0;this.AV6IDVENTA=0;this.A7IDPRODUCTO=0;this.A40DESCRIPCIONPRODUCTO="";this.A41CANTIDADPRODUCTO=0;this.A43PRECIOVENTAPRODUCTO=0;this.A56SUBTOTALVENTAPRODUCTO=0;this.Events={e131o2_client:["ENTER",!0],e141o2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.START=[[{av:"AV15Pgmname",fld:"vPGMNAME",pic:""},{av:"AV6IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9"}],[{ctrl:"GRID",prop:"Rows"},{av:'gx.fn.getCtrlProperty("IDVENTA","Visible")',ctrl:"IDVENTA",prop:"Visible"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A7IDPRODUCTO",fld:"IDPRODUCTO",pic:"ZZZZZZZZZZZ9"}],[{av:'gx.fn.getCtrlProperty("DESCRIPCIONPRODUCTO","Link")',ctrl:"DESCRIPCIONPRODUCTO",prop:"Link"}]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDVENTA",fld:"vIDVENTA",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.VALID_IDPRODUCTO=[[],[]];this.setVCMap("AV6IDVENTA","vIDVENTA",0,"int",12,0);this.setVCMap("AV6IDVENTA","vIDVENTA",0,"int",12,0);this.setVCMap("AV6IDVENTA","vIDVENTA",0,"int",12,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6IDVENTA"});i.addRefreshingParm({rfrVar:"AV6IDVENTA"});this.Initialize()})