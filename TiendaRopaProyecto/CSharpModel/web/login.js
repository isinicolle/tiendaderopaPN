gx.evt.autoSkip=!1;gx.define("login",!1,function(){this.ServerClass="login";this.PackageName="GeneXus.Programs";this.ServerFullClass="login.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A24USUARIOEMPLEADO=gx.fn.getControlValue("USUARIOEMPLEADO");this.A25CONTRASENAEMPLEADO=gx.fn.getControlValue("CONTRASENAEMPLEADO");this.A25CONTRASENAEMPLEADO=gx.fn.getControlValue("CONTRASENAEMPLEADO");this.A24USUARIOEMPLEADO=gx.fn.getControlValue("USUARIOEMPLEADO")};this.e12221_client=function(){return this.clearMessages(),gx.text.compare(this.A24USUARIOEMPLEADO,this.AV5USUARIOEMPLEADO)==0&&gx.text.compare(this.A25CONTRASENAEMPLEADO,this.AV6CONTRASENAEMPLEADO)==0?this.call("home.aspx",[],null,[]):this.addMessage("El Usuario o Contraseña son incorrectos"),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13222_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14222_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,7,11,15,19];this.GXLastCtrlId=19;n[2]={id:2,fld:"TABLE1",grid:0};n[7]={id:7,fld:"TABLE2",grid:0};n[11]={id:11,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSUARIOEMPLEADO",gxz:"ZV5USUARIOEMPLEADO",gxold:"OV5USUARIOEMPLEADO",gxvar:"AV5USUARIOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5USUARIOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5USUARIOEMPLEADO=n)},v2c:function(){gx.fn.setControlValue("vUSUARIOEMPLEADO",gx.O.AV5USUARIOEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5USUARIOEMPLEADO=this.val())},val:function(){return gx.fn.getControlValue("vUSUARIOEMPLEADO")},nac:gx.falseFn};n[15]={id:15,lvl:0,type:"svchar",len:255,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCONTRASENAEMPLEADO",gxz:"ZV6CONTRASENAEMPLEADO",gxold:"OV6CONTRASENAEMPLEADO",gxvar:"AV6CONTRASENAEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6CONTRASENAEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6CONTRASENAEMPLEADO=n)},v2c:function(){gx.fn.setControlValue("vCONTRASENAEMPLEADO",gx.O.AV6CONTRASENAEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6CONTRASENAEMPLEADO=this.val())},val:function(){return gx.fn.getControlValue("vCONTRASENAEMPLEADO")},nac:gx.falseFn};n[19]={id:19,fld:"BUTTON",grid:0,evt:"e12221_client"};this.AV5USUARIOEMPLEADO="";this.ZV5USUARIOEMPLEADO="";this.OV5USUARIOEMPLEADO="";this.AV6CONTRASENAEMPLEADO="";this.ZV6CONTRASENAEMPLEADO="";this.OV6CONTRASENAEMPLEADO="";this.AV5USUARIOEMPLEADO="";this.AV6CONTRASENAEMPLEADO="";this.A25CONTRASENAEMPLEADO="";this.A24USUARIOEMPLEADO="";this.Events={e13222_client:["ENTER",!0],e14222_client:["CANCEL",!0],e12221_client:["'INGRESAR'",!1]};this.EvtParms.REFRESH=[[{av:"A24USUARIOEMPLEADO",fld:"USUARIOEMPLEADO",pic:"",hsh:!0},{av:"A25CONTRASENAEMPLEADO",fld:"CONTRASENAEMPLEADO",pic:"",hsh:!0}],[]];this.EvtParms["'INGRESAR'"]=[[{av:"A24USUARIOEMPLEADO",fld:"USUARIOEMPLEADO",pic:"",hsh:!0},{av:"AV5USUARIOEMPLEADO",fld:"vUSUARIOEMPLEADO",pic:""},{av:"A25CONTRASENAEMPLEADO",fld:"CONTRASENAEMPLEADO",pic:"",hsh:!0},{av:"AV6CONTRASENAEMPLEADO",fld:"vCONTRASENAEMPLEADO",pic:""}],[]];this.setVCMap("A24USUARIOEMPLEADO","USUARIOEMPLEADO",0,"svchar",255,0);this.setVCMap("A25CONTRASENAEMPLEADO","CONTRASENAEMPLEADO",0,"svchar",255,0);this.setVCMap("A25CONTRASENAEMPLEADO","CONTRASENAEMPLEADO",0,"svchar",255,0);this.setVCMap("A24USUARIOEMPLEADO","USUARIOEMPLEADO",0,"svchar",255,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.login)})