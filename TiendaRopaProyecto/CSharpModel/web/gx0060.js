gx.evt.autoSkip=!1;gx.define("gx0060",!1,function(){var n,t;this.ServerClass="gx0060";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0060.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV8pIDTIPOEMPLEADO=gx.fn.getIntegerValue("vPIDTIPOEMPLEADO",",")};this.e121p1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111p1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCIDTIPOEMPLEADO","Visible",!0)):(gx.fn.setCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCIDTIPOEMPLEADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDTIPOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDTIPOEMPLEADO","Visible")',ctrl:"vCIDTIPOEMPLEADO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151p2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e161p1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,26,27,28,29];this.GXLastCtrlId=29;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",24,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0060",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",25,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(2,26,"IDTIPOEMPLEADO","IDTIPOEMPLEADO","","IDTIPOEMPLEADO","int",0,"px",12,12,"right",null,[],2,"IDTIPOEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"IDTIPOEMPLEADOFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLIDTIPOEMPLEADOFILTER",format:1,grid:0,evt:"e111p1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCIDTIPOEMPLEADO",gxz:"ZV6cIDTIPOEMPLEADO",gxold:"OV6cIDTIPOEMPLEADO",gxvar:"AV6cIDTIPOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cIDTIPOEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cIDTIPOEMPLEADO=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCIDTIPOEMPLEADO",gx.O.AV6cIDTIPOEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cIDTIPOEMPLEADO=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCIDTIPOEMPLEADO",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDTABLE",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTNTOGGLE",grid:0,evt:"e121p1_client"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[25]={id:25,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(24),gx.O.AV5LinkSelection,gx.O.AV12Linkselection_GXI)},c2v:function(n){gx.O.AV12Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(24))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(24))},gxvar_GXI:"AV12Linkselection_GXI",nac:gx.falseFn};n[26]={id:26,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDTIPOEMPLEADO",gxz:"Z2IDTIPOEMPLEADO",gxold:"O2IDTIPOEMPLEADO",gxvar:"A2IDTIPOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A2IDTIPOEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2IDTIPOEMPLEADO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(24),gx.O.A2IDTIPOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2IDTIPOEMPLEADO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(24),",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_CANCEL",grid:0,evt:"e161p1_client"};this.AV6cIDTIPOEMPLEADO=0;this.ZV6cIDTIPOEMPLEADO=0;this.OV6cIDTIPOEMPLEADO=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z2IDTIPOEMPLEADO=0;this.O2IDTIPOEMPLEADO=0;this.AV6cIDTIPOEMPLEADO=0;this.AV8pIDTIPOEMPLEADO=0;this.AV5LinkSelection="";this.A2IDTIPOEMPLEADO=0;this.Events={e151p2_client:["ENTER",!0],e161p1_client:["CANCEL",!0],e121p1_client:["'TOGGLE'",!1],e111p1_client:["LBLIDTIPOEMPLEADOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLIDTIPOEMPLEADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDTIPOEMPLEADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDTIPOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDTIPOEMPLEADO","Visible")',ctrl:"vCIDTIPOEMPLEADO",prop:"Visible"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A2IDTIPOEMPLEADO",fld:"IDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV8pIDTIPOEMPLEADO",fld:"vPIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.setVCMap("AV8pIDTIPOEMPLEADO","vPIDTIPOEMPLEADO",0,"int",12,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[16]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0060)})