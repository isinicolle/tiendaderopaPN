gx.evt.autoSkip=!1;gx.define("clientesventas_inventariowc",!0,function(n){var t,i;this.ServerClass="clientesventas_inventariowc";this.PackageName="GeneXus.Programs";this.ServerFullClass="clientesventas_inventariowc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6IDCLIENTE=gx.fn.getIntegerValue("vIDCLIENTE",",");this.AV6IDCLIENTE=gx.fn.getIntegerValue("vIDCLIENTE",",")};this.Valid_Idventa=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Idventa",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("IDVENTA",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Idempleado=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Idempleado",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("IDEMPLEADO",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e112z2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e142z2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e152z2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29,30,31,32,33,34];this.GXLastCtrlId=34;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"clientesventas_inventariowc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(12,21,"IDVENTA","IDVENTA","","IDVENTA","int",0,"px",12,12,"right",null,[],12,"IDVENTA",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(54,22,"FECHAVENTA","FECHAVENTA","","FECHAVENTA","date",0,"px",8,8,"right",null,[],54,"FECHAVENTA",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");i.addSingleLineEdit(55,23,"DESCRIPCIONVENTA","DESCRIPCIONVENTA","","DESCRIPCIONVENTA","svchar",0,"px",255,80,"left",null,[],55,"DESCRIPCIONVENTA",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(1,24,"IDEMPLEADO","IDEMPLEADO","","IDEMPLEADO","int",0,"px",12,12,"right",null,[],1,"IDEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(23,25,"NOMBRECOMPLETOEMPLEADO","NOMBRECOMPLETOEMPLEADO","","NOMBRECOMPLETOEMPLEADO","svchar",0,"px",255,80,"left",null,[],23,"NOMBRECOMPLETOEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(57,26,"IMPUESTOVENTA","IMPUESTOVENTA","","IMPUESTOVENTA","decimal",0,"px",12,12,"right",null,[],57,"IMPUESTOVENTA",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(58,27,"DESCUENTOVENTA","DESCUENTOVENTA","","DESCUENTOVENTA","decimal",0,"px",12,12,"right",null,[],58,"DESCUENTOVENTA",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(59,28,"TOTALVENTA","TOTALVENTA","","TOTALVENTA","decimal",0,"px",12,12,"right",null,[],59,"TOTALVENTA",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit("Update",29,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");i.addSingleLineEdit("Delete",30,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLETOP",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"BTNINSERT",grid:0,evt:"e112z2_client"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GRIDCELL",grid:0};t[14]={id:14,fld:"GRIDTABLE",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Idventa,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDVENTA",gxz:"Z12IDVENTA",gxold:"O12IDVENTA",gxvar:"A12IDVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A12IDVENTA=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12IDVENTA=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDVENTA",n||gx.fn.currentGridRowImpl(20),gx.O.A12IDVENTA,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12IDVENTA=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDVENTA",n||gx.fn.currentGridRowImpl(20),",")},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHAVENTA",gxz:"Z54FECHAVENTA",gxold:"O54FECHAVENTA",gxvar:"A54FECHAVENTA",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A54FECHAVENTA=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z54FECHAVENTA=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("FECHAVENTA",n||gx.fn.currentGridRowImpl(20),gx.O.A54FECHAVENTA,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A54FECHAVENTA=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("FECHAVENTA",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCIONVENTA",gxz:"Z55DESCRIPCIONVENTA",gxold:"O55DESCRIPCIONVENTA",gxvar:"A55DESCRIPCIONVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A55DESCRIPCIONVENTA=n)},v2z:function(n){n!==undefined&&(gx.O.Z55DESCRIPCIONVENTA=n)},v2c:function(n){gx.fn.setGridControlValue("DESCRIPCIONVENTA",n||gx.fn.currentGridRowImpl(20),gx.O.A55DESCRIPCIONVENTA,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A55DESCRIPCIONVENTA=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DESCRIPCIONVENTA",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Idempleado,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDEMPLEADO",gxz:"Z1IDEMPLEADO",gxold:"O1IDEMPLEADO",gxvar:"A1IDEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A1IDEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1IDEMPLEADO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDEMPLEADO",n||gx.fn.currentGridRowImpl(20),gx.O.A1IDEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1IDEMPLEADO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDEMPLEADO",n||gx.fn.currentGridRowImpl(20),",")},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOMBRECOMPLETOEMPLEADO",gxz:"Z23NOMBRECOMPLETOEMPLEADO",gxold:"O23NOMBRECOMPLETOEMPLEADO",gxvar:"A23NOMBRECOMPLETOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A23NOMBRECOMPLETOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.Z23NOMBRECOMPLETOEMPLEADO=n)},v2c:function(n){gx.fn.setGridControlValue("NOMBRECOMPLETOEMPLEADO",n||gx.fn.currentGridRowImpl(20),gx.O.A23NOMBRECOMPLETOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A23NOMBRECOMPLETOEMPLEADO=this.val(n))},val:function(n){return gx.fn.getGridControlValue("NOMBRECOMPLETOEMPLEADO",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IMPUESTOVENTA",gxz:"Z57IMPUESTOVENTA",gxold:"O57IMPUESTOVENTA",gxvar:"A57IMPUESTOVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A57IMPUESTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z57IMPUESTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("IMPUESTOVENTA",n||gx.fn.currentGridRowImpl(20),gx.O.A57IMPUESTOVENTA,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A57IMPUESTOVENTA=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("IMPUESTOVENTA",n||gx.fn.currentGridRowImpl(20),",",".")},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCUENTOVENTA",gxz:"Z58DESCUENTOVENTA",gxold:"O58DESCUENTOVENTA",gxvar:"A58DESCUENTOVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A58DESCUENTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z58DESCUENTOVENTA=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("DESCUENTOVENTA",n||gx.fn.currentGridRowImpl(20),gx.O.A58DESCUENTOVENTA,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A58DESCUENTOVENTA=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("DESCUENTOVENTA",n||gx.fn.currentGridRowImpl(20),",",".")},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"decimal",len:12,dec:2,sign:!1,pic:"ZZZZZZZZ9.99",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TOTALVENTA",gxz:"Z59TOTALVENTA",gxold:"O59TOTALVENTA",gxvar:"A59TOTALVENTA",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A59TOTALVENTA=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z59TOTALVENTA=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("TOTALVENTA",n||gx.fn.currentGridRowImpl(20),gx.O.A59TOTALVENTA,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A59TOTALVENTA=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("TOTALVENTA",n||gx.fn.currentGridRowImpl(20),",",".")},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[30]={id:30,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDCLIENTE",gxz:"Z4IDCLIENTE",gxold:"O4IDCLIENTE",gxvar:"A4IDCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4IDCLIENTE=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4IDCLIENTE=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("IDCLIENTE",gx.O.A4IDCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A4IDCLIENTE=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("IDCLIENTE",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});this.Z12IDVENTA=0;this.O12IDVENTA=0;this.Z54FECHAVENTA=gx.date.nullDate();this.O54FECHAVENTA=gx.date.nullDate();this.Z55DESCRIPCIONVENTA="";this.O55DESCRIPCIONVENTA="";this.Z1IDEMPLEADO=0;this.O1IDEMPLEADO=0;this.Z23NOMBRECOMPLETOEMPLEADO="";this.O23NOMBRECOMPLETOEMPLEADO="";this.Z57IMPUESTOVENTA=0;this.O57IMPUESTOVENTA=0;this.Z58DESCUENTOVENTA=0;this.O58DESCUENTOVENTA=0;this.Z59TOTALVENTA=0;this.O59TOTALVENTA=0;this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.A4IDCLIENTE=0;this.Z4IDCLIENTE=0;this.O4IDCLIENTE=0;this.A4IDCLIENTE=0;this.AV6IDCLIENTE=0;this.A12IDVENTA=0;this.A54FECHAVENTA=gx.date.nullDate();this.A55DESCRIPCIONVENTA="";this.A1IDEMPLEADO=0;this.A23NOMBRECOMPLETOEMPLEADO="";this.A57IMPUESTOVENTA=0;this.A58DESCUENTOVENTA=0;this.A59TOTALVENTA=0;this.AV12Update="";this.AV13Delete="";this.Events={e112z2_client:["'DOINSERT'",!0],e142z2_client:["ENTER",!0],e152z2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDCLIENTE",fld:"vIDCLIENTE",pic:"ZZZZZZZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.START=[[{av:"AV17Pgmname",fld:"vPGMNAME",pic:""},{av:"AV6IDCLIENTE",fld:"vIDCLIENTE",pic:"ZZZZZZZZZZZ9"}],[{ctrl:"GRID",prop:"Rows"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("IDCLIENTE","Visible")',ctrl:"IDCLIENTE",prop:"Visible"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A12IDVENTA",fld:"IDVENTA",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"A1IDEMPLEADO",fld:"IDEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("FECHAVENTA","Link")',ctrl:"FECHAVENTA",prop:"Link"},{av:'gx.fn.getCtrlProperty("NOMBRECOMPLETOEMPLEADO","Link")',ctrl:"NOMBRECOMPLETOEMPLEADO",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A12IDVENTA",fld:"IDVENTA",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDCLIENTE",fld:"vIDCLIENTE",pic:"ZZZZZZZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDCLIENTE",fld:"vIDCLIENTE",pic:"ZZZZZZZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDCLIENTE",fld:"vIDCLIENTE",pic:"ZZZZZZZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6IDCLIENTE",fld:"vIDCLIENTE",pic:"ZZZZZZZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.VALID_IDVENTA=[[],[]];this.EvtParms.VALID_IDEMPLEADO=[[],[]];this.setVCMap("AV6IDCLIENTE","vIDCLIENTE",0,"int",12,0);this.setVCMap("AV6IDCLIENTE","vIDCLIENTE",0,"int",12,0);this.setVCMap("AV6IDCLIENTE","vIDCLIENTE",0,"int",12,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6IDCLIENTE"});i.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6IDCLIENTE"});i.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})