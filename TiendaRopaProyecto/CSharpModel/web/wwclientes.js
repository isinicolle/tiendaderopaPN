gx.evt.autoSkip=!1;gx.define("wwclientes",!1,function(){var n,t;this.ServerClass="wwclientes";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwclientes.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e110f2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160f2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,26,27,28,29,30,31,32,33,34,35,36,37];this.GXLastCtrlId=37;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",25,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwclientes",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(4,26,"IDCLIENTE","IDCLIENTE","","IDCLIENTE","int",0,"px",12,12,"right",null,[],4,"IDCLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(30,27,"NOMBRECOMPLETOCLIENTE","NOMBRECOMPLETOCLIENTE","","NOMBRECOMPLETOCLIENTE","svchar",0,"px",255,80,"left",null,[],30,"NOMBRECOMPLETOCLIENTE",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(31,28,"USUARIOCLIENTE","USUARIOCLIENTE","","USUARIOCLIENTE","svchar",0,"px",255,80,"left",null,[],31,"USUARIOCLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(32,29,"CONTRASENACLIENTE","CONTRASENACLIENTE","","CONTRASENACLIENTE","svchar",0,"px",255,80,"left",null,[],32,"CONTRASENACLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(33,30,"TELEFONOCLIENTE","TELEFONOCLIENTE","","TELEFONOCLIENTE","char",0,"px",20,20,"left",null,[],33,"TELEFONOCLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(34,31,"CORREOCLIENTE","CORREOCLIENTE","","CORREOCLIENTE","svchar",0,"px",100,80,"left",null,[],34,"CORREOCLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(35,32,"FECHANACIMIENTOCLIENTE","FECHANACIMIENTOCLIENTE","","FECHANACIMIENTOCLIENTE","date",0,"px",8,8,"right",null,[],35,"FECHANACIMIENTOCLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(36,33,"DIRECCIONCLIENTE","DIRECCIONCLIENTE","","DIRECCIONCLIENTE","svchar",0,"px",255,80,"left",null,[],36,"DIRECCIONCLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(37,34,"FECHAREGISTROCLIENTE","FECHAREGISTROCLIENTE","","FECHAREGISTROCLIENTE","date",0,"px",8,8,"right",null,[],37,"FECHAREGISTROCLIENTE",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addBitmap(53,"FOTOCLIENTE",35,0,"px",17,"px",null,"","FOTOCLIENTE","ImageAttribute","WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",36,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",37,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110f2_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vNOMBRECOMPLETOCLIENTE",gxz:"ZV11NOMBRECOMPLETOCLIENTE",gxold:"OV11NOMBRECOMPLETOCLIENTE",gxvar:"AV11NOMBRECOMPLETOCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11NOMBRECOMPLETOCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11NOMBRECOMPLETOCLIENTE=n)},v2c:function(){gx.fn.setControlValue("vNOMBRECOMPLETOCLIENTE",gx.O.AV11NOMBRECOMPLETOCLIENTE,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11NOMBRECOMPLETOCLIENTE=this.val())},val:function(){return gx.fn.getControlValue("vNOMBRECOMPLETOCLIENTE")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDCELL",grid:0};n[19]={id:19,fld:"GRIDTABLE",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[26]={id:26,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDCLIENTE",gxz:"Z4IDCLIENTE",gxold:"O4IDCLIENTE",gxvar:"A4IDCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A4IDCLIENTE=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4IDCLIENTE=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A4IDCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4IDCLIENTE=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDCLIENTE",n||gx.fn.currentGridRowImpl(25),",")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOMBRECOMPLETOCLIENTE",gxz:"Z30NOMBRECOMPLETOCLIENTE",gxold:"O30NOMBRECOMPLETOCLIENTE",gxvar:"A30NOMBRECOMPLETOCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A30NOMBRECOMPLETOCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z30NOMBRECOMPLETOCLIENTE=n)},v2c:function(n){gx.fn.setGridControlValue("NOMBRECOMPLETOCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A30NOMBRECOMPLETOCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30NOMBRECOMPLETOCLIENTE=this.val(n))},val:function(n){return gx.fn.getGridControlValue("NOMBRECOMPLETOCLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOCLIENTE",gxz:"Z31USUARIOCLIENTE",gxold:"O31USUARIOCLIENTE",gxvar:"A31USUARIOCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A31USUARIOCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z31USUARIOCLIENTE=n)},v2c:function(n){gx.fn.setGridControlValue("USUARIOCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A31USUARIOCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A31USUARIOCLIENTE=this.val(n))},val:function(n){return gx.fn.getGridControlValue("USUARIOCLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CONTRASENACLIENTE",gxz:"Z32CONTRASENACLIENTE",gxold:"O32CONTRASENACLIENTE",gxvar:"A32CONTRASENACLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A32CONTRASENACLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z32CONTRASENACLIENTE=n)},v2c:function(n){gx.fn.setGridControlValue("CONTRASENACLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A32CONTRASENACLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A32CONTRASENACLIENTE=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CONTRASENACLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TELEFONOCLIENTE",gxz:"Z33TELEFONOCLIENTE",gxold:"O33TELEFONOCLIENTE",gxvar:"A33TELEFONOCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A33TELEFONOCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z33TELEFONOCLIENTE=n)},v2c:function(n){gx.fn.setGridControlValue("TELEFONOCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A33TELEFONOCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A33TELEFONOCLIENTE=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TELEFONOCLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CORREOCLIENTE",gxz:"Z34CORREOCLIENTE",gxold:"O34CORREOCLIENTE",gxvar:"A34CORREOCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"email",v2v:function(n){n!==undefined&&(gx.O.A34CORREOCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z34CORREOCLIENTE=n)},v2c:function(n){gx.fn.setGridControlValue("CORREOCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A34CORREOCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A34CORREOCLIENTE=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CORREOCLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHANACIMIENTOCLIENTE",gxz:"Z35FECHANACIMIENTOCLIENTE",gxold:"O35FECHANACIMIENTOCLIENTE",gxvar:"A35FECHANACIMIENTOCLIENTE",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A35FECHANACIMIENTOCLIENTE=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z35FECHANACIMIENTOCLIENTE=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("FECHANACIMIENTOCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A35FECHANACIMIENTOCLIENTE,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A35FECHANACIMIENTOCLIENTE=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("FECHANACIMIENTOCLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"svchar",len:255,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DIRECCIONCLIENTE",gxz:"Z36DIRECCIONCLIENTE",gxold:"O36DIRECCIONCLIENTE",gxvar:"A36DIRECCIONCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A36DIRECCIONCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z36DIRECCIONCLIENTE=n)},v2c:function(n){gx.fn.setGridControlValue("DIRECCIONCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A36DIRECCIONCLIENTE,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A36DIRECCIONCLIENTE=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DIRECCIONCLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHAREGISTROCLIENTE",gxz:"Z37FECHAREGISTROCLIENTE",gxold:"O37FECHAREGISTROCLIENTE",gxvar:"A37FECHAREGISTROCLIENTE",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A37FECHAREGISTROCLIENTE=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z37FECHAREGISTROCLIENTE=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("FECHAREGISTROCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A37FECHAREGISTROCLIENTE,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A37FECHAREGISTROCLIENTE=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("FECHAREGISTROCLIENTE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FOTOCLIENTE",gxz:"Z53FOTOCLIENTE",gxold:"O53FOTOCLIENTE",gxvar:"A53FOTOCLIENTE",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A53FOTOCLIENTE=n)},v2z:function(n){n!==undefined&&(gx.O.Z53FOTOCLIENTE=n)},v2c:function(n){gx.fn.setGridMultimediaValue("FOTOCLIENTE",n||gx.fn.currentGridRowImpl(25),gx.O.A53FOTOCLIENTE,gx.O.A40000FOTOCLIENTE_GXI)},c2v:function(n){gx.O.A40000FOTOCLIENTE_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A53FOTOCLIENTE=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FOTOCLIENTE",n||gx.fn.currentGridRowImpl(25))},val_GXI:function(n){return gx.fn.getGridControlValue("FOTOCLIENTE_GXI",n||gx.fn.currentGridRowImpl(25))},gxvar_GXI:"A40000FOTOCLIENTE_GXI",nac:gx.falseFn};n[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};this.AV11NOMBRECOMPLETOCLIENTE="";this.ZV11NOMBRECOMPLETOCLIENTE="";this.OV11NOMBRECOMPLETOCLIENTE="";this.Z4IDCLIENTE=0;this.O4IDCLIENTE=0;this.Z30NOMBRECOMPLETOCLIENTE="";this.O30NOMBRECOMPLETOCLIENTE="";this.Z31USUARIOCLIENTE="";this.O31USUARIOCLIENTE="";this.Z32CONTRASENACLIENTE="";this.O32CONTRASENACLIENTE="";this.Z33TELEFONOCLIENTE="";this.O33TELEFONOCLIENTE="";this.Z34CORREOCLIENTE="";this.O34CORREOCLIENTE="";this.Z35FECHANACIMIENTOCLIENTE=gx.date.nullDate();this.O35FECHANACIMIENTOCLIENTE=gx.date.nullDate();this.Z36DIRECCIONCLIENTE="";this.O36DIRECCIONCLIENTE="";this.Z37FECHAREGISTROCLIENTE=gx.date.nullDate();this.O37FECHAREGISTROCLIENTE=gx.date.nullDate();this.Z53FOTOCLIENTE="";this.O53FOTOCLIENTE="";this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11NOMBRECOMPLETOCLIENTE="";this.A40000FOTOCLIENTE_GXI="";this.A4IDCLIENTE=0;this.A30NOMBRECOMPLETOCLIENTE="";this.A31USUARIOCLIENTE="";this.A32CONTRASENACLIENTE="";this.A33TELEFONOCLIENTE="";this.A34CORREOCLIENTE="";this.A35FECHANACIMIENTOCLIENTE=gx.date.nullDate();this.A36DIRECCIONCLIENTE="";this.A37FECHAREGISTROCLIENTE=gx.date.nullDate();this.A53FOTOCLIENTE="";this.AV12Update="";this.AV13Delete="";this.Events={e110f2_client:["'DOINSERT'",!0],e150f2_client:["ENTER",!0],e160f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11NOMBRECOMPLETOCLIENTE",fld:"vNOMBRECOMPLETOCLIENTE",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.START=[[{av:"AV17Pgmname",fld:"vPGMNAME",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A4IDCLIENTE",fld:"IDCLIENTE",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("NOMBRECOMPLETOCLIENTE","Link")',ctrl:"NOMBRECOMPLETOCLIENTE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A4IDCLIENTE",fld:"IDCLIENTE",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11NOMBRECOMPLETOCLIENTE",fld:"vNOMBRECOMPLETOCLIENTE",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11NOMBRECOMPLETOCLIENTE",fld:"vNOMBRECOMPLETOCLIENTE",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11NOMBRECOMPLETOCLIENTE",fld:"vNOMBRECOMPLETOCLIENTE",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11NOMBRECOMPLETOCLIENTE",fld:"vNOMBRECOMPLETOCLIENTE",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwclientes)})