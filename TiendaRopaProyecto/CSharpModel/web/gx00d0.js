gx.evt.autoSkip=!1;gx.define("gx00d0",!1,function(){var n,t;this.ServerClass="gx00d0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00d0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV10pIDPROVEEDOR=gx.fn.getIntegerValue("vPIDPROVEEDOR",",")};this.e131z1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111z1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("IDPROVEEDORFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("IDPROVEEDORFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCIDPROVEEDOR","Visible",!0)):(gx.fn.setCtrlProperty("IDPROVEEDORFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCIDPROVEEDOR","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("IDPROVEEDORFILTERCONTAINER","Class")',ctrl:"IDPROVEEDORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDPROVEEDOR","Visible")',ctrl:"vCIDPROVEEDOR",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121z1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TELEFONOPROVEEDORFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TELEFONOPROVEEDORFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTELEFONOPROVEEDOR","Visible",!0)):(gx.fn.setCtrlProperty("TELEFONOPROVEEDORFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTELEFONOPROVEEDOR","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TELEFONOPROVEEDORFILTERCONTAINER","Class")',ctrl:"TELEFONOPROVEEDORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTELEFONOPROVEEDOR","Visible")',ctrl:"vCTELEFONOPROVEEDOR",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e161z2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e171z1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40];this.GXLastCtrlId=40;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",34,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00d0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",35,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(10,36,"IDPROVEEDOR","IDPROVEEDOR","","IDPROVEEDOR","int",0,"px",12,12,"right",null,[],10,"IDPROVEEDOR",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(47,37,"TELEFONOPROVEEDOR","TELEFONOPROVEEDOR","","TELEFONOPROVEEDOR","char",0,"px",20,20,"left",null,[],47,"TELEFONOPROVEEDOR",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"IDPROVEEDORFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLIDPROVEEDORFILTER",format:1,grid:0,evt:"e111z1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCIDPROVEEDOR",gxz:"ZV6cIDPROVEEDOR",gxold:"OV6cIDPROVEEDOR",gxvar:"AV6cIDPROVEEDOR",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cIDPROVEEDOR=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cIDPROVEEDOR=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCIDPROVEEDOR",gx.O.AV6cIDPROVEEDOR,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cIDPROVEEDOR=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCIDPROVEEDOR",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TELEFONOPROVEEDORFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLTELEFONOPROVEEDORFILTER",format:1,grid:0,evt:"e121z1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTELEFONOPROVEEDOR",gxz:"ZV8cTELEFONOPROVEEDOR",gxold:"OV8cTELEFONOPROVEEDOR",gxvar:"AV8cTELEFONOPROVEEDOR",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cTELEFONOPROVEEDOR=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8cTELEFONOPROVEEDOR=n)},v2c:function(){gx.fn.setControlValue("vCTELEFONOPROVEEDOR",gx.O.AV8cTELEFONOPROVEEDOR,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cTELEFONOPROVEEDOR=this.val())},val:function(){return gx.fn.getControlValue("vCTELEFONOPROVEEDOR")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GRIDTABLE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTOGGLE",grid:0,evt:"e131z1_client"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(34))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[36]={id:36,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDPROVEEDOR",gxz:"Z10IDPROVEEDOR",gxold:"O10IDPROVEEDOR",gxvar:"A10IDPROVEEDOR",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A10IDPROVEEDOR=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z10IDPROVEEDOR=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDPROVEEDOR",n||gx.fn.currentGridRowImpl(34),gx.O.A10IDPROVEEDOR,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10IDPROVEEDOR=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDPROVEEDOR",n||gx.fn.currentGridRowImpl(34),",")},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TELEFONOPROVEEDOR",gxz:"Z47TELEFONOPROVEEDOR",gxold:"O47TELEFONOPROVEEDOR",gxvar:"A47TELEFONOPROVEEDOR",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A47TELEFONOPROVEEDOR=n)},v2z:function(n){n!==undefined&&(gx.O.Z47TELEFONOPROVEEDOR=n)},v2c:function(n){gx.fn.setGridControlValue("TELEFONOPROVEEDOR",n||gx.fn.currentGridRowImpl(34),gx.O.A47TELEFONOPROVEEDOR,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A47TELEFONOPROVEEDOR=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TELEFONOPROVEEDOR",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"BTN_CANCEL",grid:0,evt:"e171z1_client"};this.AV6cIDPROVEEDOR=0;this.ZV6cIDPROVEEDOR=0;this.OV6cIDPROVEEDOR=0;this.AV8cTELEFONOPROVEEDOR="";this.ZV8cTELEFONOPROVEEDOR="";this.OV8cTELEFONOPROVEEDOR="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z10IDPROVEEDOR=0;this.O10IDPROVEEDOR=0;this.Z47TELEFONOPROVEEDOR="";this.O47TELEFONOPROVEEDOR="";this.AV6cIDPROVEEDOR=0;this.AV8cTELEFONOPROVEEDOR="";this.AV10pIDPROVEEDOR=0;this.AV5LinkSelection="";this.A10IDPROVEEDOR=0;this.A47TELEFONOPROVEEDOR="";this.Events={e161z2_client:["ENTER",!0],e171z1_client:["CANCEL",!0],e131z1_client:["'TOGGLE'",!1],e111z1_client:["LBLIDPROVEEDORFILTER.CLICK",!1],e121z1_client:["LBLTELEFONOPROVEEDORFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDPROVEEDOR",fld:"vCIDPROVEEDOR",pic:"ZZZZZZZZZZZ9"},{av:"AV8cTELEFONOPROVEEDOR",fld:"vCTELEFONOPROVEEDOR",pic:""}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLIDPROVEEDORFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("IDPROVEEDORFILTERCONTAINER","Class")',ctrl:"IDPROVEEDORFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("IDPROVEEDORFILTERCONTAINER","Class")',ctrl:"IDPROVEEDORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDPROVEEDOR","Visible")',ctrl:"vCIDPROVEEDOR",prop:"Visible"}]];this.EvtParms["LBLTELEFONOPROVEEDORFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TELEFONOPROVEEDORFILTERCONTAINER","Class")',ctrl:"TELEFONOPROVEEDORFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TELEFONOPROVEEDORFILTERCONTAINER","Class")',ctrl:"TELEFONOPROVEEDORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTELEFONOPROVEEDOR","Visible")',ctrl:"vCTELEFONOPROVEEDOR",prop:"Visible"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A10IDPROVEEDOR",fld:"IDPROVEEDOR",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV10pIDPROVEEDOR",fld:"vPIDPROVEEDOR",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDPROVEEDOR",fld:"vCIDPROVEEDOR",pic:"ZZZZZZZZZZZ9"},{av:"AV8cTELEFONOPROVEEDOR",fld:"vCTELEFONOPROVEEDOR",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDPROVEEDOR",fld:"vCIDPROVEEDOR",pic:"ZZZZZZZZZZZ9"},{av:"AV8cTELEFONOPROVEEDOR",fld:"vCTELEFONOPROVEEDOR",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDPROVEEDOR",fld:"vCIDPROVEEDOR",pic:"ZZZZZZZZZZZ9"},{av:"AV8cTELEFONOPROVEEDOR",fld:"vCTELEFONOPROVEEDOR",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDPROVEEDOR",fld:"vCIDPROVEEDOR",pic:"ZZZZZZZZZZZ9"},{av:"AV8cTELEFONOPROVEEDOR",fld:"vCTELEFONOPROVEEDOR",pic:""}],[]];this.setVCMap("AV10pIDPROVEEDOR","vPIDPROVEEDOR",0,"int",12,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00d0)})