gx.evt.autoSkip=!1;gx.define("wwtipo_empleado",!1,function(){var n,t;this.ServerClass="wwtipo_empleado";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwtipo_empleado.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e110d2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150d2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160d2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,26,27,28,29];this.GXLastCtrlId=29;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",25,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwtipo_empleado",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(2,26,"IDTIPOEMPLEADO","IDTIPOEMPLEADO","","IDTIPOEMPLEADO","int",0,"px",12,12,"right",null,[],2,"IDTIPOEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(21,27,"DESCRIPCIONTIPOEMPLEADO","DESCRIPCIONTIPOEMPLEADO","","DESCRIPCIONTIPOEMPLEADO","svchar",0,"px",255,80,"left",null,[],21,"DESCRIPCIONTIPOEMPLEADO",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit("Update",28,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",29,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110d2_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vDESCRIPCIONTIPOEMPLEADO",gxz:"ZV11DESCRIPCIONTIPOEMPLEADO",gxold:"OV11DESCRIPCIONTIPOEMPLEADO",gxvar:"AV11DESCRIPCIONTIPOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11DESCRIPCIONTIPOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11DESCRIPCIONTIPOEMPLEADO=n)},v2c:function(){gx.fn.setControlValue("vDESCRIPCIONTIPOEMPLEADO",gx.O.AV11DESCRIPCIONTIPOEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11DESCRIPCIONTIPOEMPLEADO=this.val())},val:function(){return gx.fn.getControlValue("vDESCRIPCIONTIPOEMPLEADO")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDCELL",grid:0};n[19]={id:19,fld:"GRIDTABLE",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[26]={id:26,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDTIPOEMPLEADO",gxz:"Z2IDTIPOEMPLEADO",gxold:"O2IDTIPOEMPLEADO",gxvar:"A2IDTIPOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A2IDTIPOEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2IDTIPOEMPLEADO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(25),gx.O.A2IDTIPOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2IDTIPOEMPLEADO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(25),",")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCIONTIPOEMPLEADO",gxz:"Z21DESCRIPCIONTIPOEMPLEADO",gxold:"O21DESCRIPCIONTIPOEMPLEADO",gxvar:"A21DESCRIPCIONTIPOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A21DESCRIPCIONTIPOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.Z21DESCRIPCIONTIPOEMPLEADO=n)},v2c:function(n){gx.fn.setGridControlValue("DESCRIPCIONTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(25),gx.O.A21DESCRIPCIONTIPOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A21DESCRIPCIONTIPOEMPLEADO=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DESCRIPCIONTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};this.AV11DESCRIPCIONTIPOEMPLEADO="";this.ZV11DESCRIPCIONTIPOEMPLEADO="";this.OV11DESCRIPCIONTIPOEMPLEADO="";this.Z2IDTIPOEMPLEADO=0;this.O2IDTIPOEMPLEADO=0;this.Z21DESCRIPCIONTIPOEMPLEADO="";this.O21DESCRIPCIONTIPOEMPLEADO="";this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11DESCRIPCIONTIPOEMPLEADO="";this.A2IDTIPOEMPLEADO=0;this.A21DESCRIPCIONTIPOEMPLEADO="";this.AV12Update="";this.AV13Delete="";this.Events={e110d2_client:["'DOINSERT'",!0],e150d2_client:["ENTER",!0],e160d2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11DESCRIPCIONTIPOEMPLEADO",fld:"vDESCRIPCIONTIPOEMPLEADO",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.START=[[{av:"AV17Pgmname",fld:"vPGMNAME",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A2IDTIPOEMPLEADO",fld:"IDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("DESCRIPCIONTIPOEMPLEADO","Link")',ctrl:"DESCRIPCIONTIPOEMPLEADO",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A2IDTIPOEMPLEADO",fld:"IDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11DESCRIPCIONTIPOEMPLEADO",fld:"vDESCRIPCIONTIPOEMPLEADO",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11DESCRIPCIONTIPOEMPLEADO",fld:"vDESCRIPCIONTIPOEMPLEADO",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11DESCRIPCIONTIPOEMPLEADO",fld:"vDESCRIPCIONTIPOEMPLEADO",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11DESCRIPCIONTIPOEMPLEADO",fld:"vDESCRIPCIONTIPOEMPLEADO",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwtipo_empleado)})