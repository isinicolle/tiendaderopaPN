gx.evt.autoSkip=!1;gx.define("gx00b0",!1,function(){var n,t;this.ServerClass="gx00b0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00b0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV8pIDCATEGORIAPRODUCTO=gx.fn.getIntegerValue("vPIDCATEGORIAPRODUCTO",",")};this.e121x1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111x1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("IDCATEGORIAPRODUCTOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("IDCATEGORIAPRODUCTOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCIDCATEGORIAPRODUCTO","Visible",!0)):(gx.fn.setCtrlProperty("IDCATEGORIAPRODUCTOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCIDCATEGORIAPRODUCTO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("IDCATEGORIAPRODUCTOFILTERCONTAINER","Class")',ctrl:"IDCATEGORIAPRODUCTOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDCATEGORIAPRODUCTO","Visible")',ctrl:"vCIDCATEGORIAPRODUCTO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151x2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e161x1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,26,27,28,29];this.GXLastCtrlId=29;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",24,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00b0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",25,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(6,26,"IDCATEGORIAPRODUCTO","IDCATEGORIAPRODUCTO","","IDCATEGORIAPRODUCTO","int",0,"px",12,12,"right",null,[],6,"IDCATEGORIAPRODUCTO",!0,0,!1,!1,"Attribute",1,"WWColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"IDCATEGORIAPRODUCTOFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLIDCATEGORIAPRODUCTOFILTER",format:1,grid:0,evt:"e111x1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCIDCATEGORIAPRODUCTO",gxz:"ZV6cIDCATEGORIAPRODUCTO",gxold:"OV6cIDCATEGORIAPRODUCTO",gxvar:"AV6cIDCATEGORIAPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cIDCATEGORIAPRODUCTO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cIDCATEGORIAPRODUCTO=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCIDCATEGORIAPRODUCTO",gx.O.AV6cIDCATEGORIAPRODUCTO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cIDCATEGORIAPRODUCTO=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCIDCATEGORIAPRODUCTO",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDTABLE",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTNTOGGLE",grid:0,evt:"e121x1_client"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[25]={id:25,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(24),gx.O.AV5LinkSelection,gx.O.AV12Linkselection_GXI)},c2v:function(n){gx.O.AV12Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(24))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(24))},gxvar_GXI:"AV12Linkselection_GXI",nac:gx.falseFn};n[26]={id:26,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDCATEGORIAPRODUCTO",gxz:"Z6IDCATEGORIAPRODUCTO",gxold:"O6IDCATEGORIAPRODUCTO",gxvar:"A6IDCATEGORIAPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A6IDCATEGORIAPRODUCTO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z6IDCATEGORIAPRODUCTO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDCATEGORIAPRODUCTO",n||gx.fn.currentGridRowImpl(24),gx.O.A6IDCATEGORIAPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6IDCATEGORIAPRODUCTO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDCATEGORIAPRODUCTO",n||gx.fn.currentGridRowImpl(24),",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_CANCEL",grid:0,evt:"e161x1_client"};this.AV6cIDCATEGORIAPRODUCTO=0;this.ZV6cIDCATEGORIAPRODUCTO=0;this.OV6cIDCATEGORIAPRODUCTO=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z6IDCATEGORIAPRODUCTO=0;this.O6IDCATEGORIAPRODUCTO=0;this.AV6cIDCATEGORIAPRODUCTO=0;this.AV8pIDCATEGORIAPRODUCTO=0;this.AV5LinkSelection="";this.A6IDCATEGORIAPRODUCTO=0;this.Events={e151x2_client:["ENTER",!0],e161x1_client:["CANCEL",!0],e121x1_client:["'TOGGLE'",!1],e111x1_client:["LBLIDCATEGORIAPRODUCTOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDCATEGORIAPRODUCTO",fld:"vCIDCATEGORIAPRODUCTO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLIDCATEGORIAPRODUCTOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("IDCATEGORIAPRODUCTOFILTERCONTAINER","Class")',ctrl:"IDCATEGORIAPRODUCTOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("IDCATEGORIAPRODUCTOFILTERCONTAINER","Class")',ctrl:"IDCATEGORIAPRODUCTOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDCATEGORIAPRODUCTO","Visible")',ctrl:"vCIDCATEGORIAPRODUCTO",prop:"Visible"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A6IDCATEGORIAPRODUCTO",fld:"IDCATEGORIAPRODUCTO",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV8pIDCATEGORIAPRODUCTO",fld:"vPIDCATEGORIAPRODUCTO",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDCATEGORIAPRODUCTO",fld:"vCIDCATEGORIAPRODUCTO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDCATEGORIAPRODUCTO",fld:"vCIDCATEGORIAPRODUCTO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDCATEGORIAPRODUCTO",fld:"vCIDCATEGORIAPRODUCTO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDCATEGORIAPRODUCTO",fld:"vCIDCATEGORIAPRODUCTO",pic:"ZZZZZZZZZZZ9"}],[]];this.setVCMap("AV8pIDCATEGORIAPRODUCTO","vPIDCATEGORIAPRODUCTO",0,"int",12,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[16]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00b0)})