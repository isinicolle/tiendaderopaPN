gx.evt.autoSkip=!1;gx.define("estado_producto",!1,function(){this.ServerClass="estado_producto";this.PackageName="GeneXus.Programs";this.ServerFullClass="estado_producto.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7IDESTADOPRODUCTO=gx.fn.getIntegerValue("vIDESTADOPRODUCTO",",");this.AV11Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Idestadoproducto=function(){return this.validCliEvt("Valid_Idestadoproducto",0,function(){try{var n=gx.util.balloon.getNew("IDESTADOPRODUCTO");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Descripcionestadoproducto=function(){return this.validCliEvt("Valid_Descripcionestadoproducto",0,function(){try{var n=gx.util.balloon.getNew("DESCRIPCIONESTADOPRODUCTO");if(this.AnyError=0,gx.text.compare("",this.A38DESCRIPCIONESTADOPRODUCTO)==0)try{n.setError("Ingrese la descripcion del estado del producto");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12082_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e130810_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140810_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48];this.GXLastCtrlId=48;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e150810_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e160810_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e170810_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e180810_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e190810_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Idestadoproducto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDESTADOPRODUCTO",gxz:"Z5IDESTADOPRODUCTO",gxold:"O5IDESTADOPRODUCTO",gxvar:"A5IDESTADOPRODUCTO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5IDESTADOPRODUCTO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5IDESTADOPRODUCTO=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("IDESTADOPRODUCTO",gx.O.A5IDESTADOPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5IDESTADOPRODUCTO=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("IDESTADOPRODUCTO",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:255,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:this.Valid_Descripcionestadoproducto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESCRIPCIONESTADOPRODUCTO",gxz:"Z38DESCRIPCIONESTADOPRODUCTO",gxold:"O38DESCRIPCIONESTADOPRODUCTO",gxvar:"A38DESCRIPCIONESTADOPRODUCTO",ucs:[],op:[39],ip:[39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A38DESCRIPCIONESTADOPRODUCTO=n)},v2z:function(n){n!==undefined&&(gx.O.Z38DESCRIPCIONESTADOPRODUCTO=n)},v2c:function(){gx.fn.setControlValue("DESCRIPCIONESTADOPRODUCTO",gx.O.A38DESCRIPCIONESTADOPRODUCTO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A38DESCRIPCIONESTADOPRODUCTO=this.val())},val:function(){return gx.fn.getControlValue("DESCRIPCIONESTADOPRODUCTO")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"BTN_ENTER",grid:0,evt:"e130810_client",std:"ENTER"};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"BTN_CANCEL",grid:0,evt:"e140810_client"};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"BTN_DELETE",grid:0,evt:"e200810_client",std:"DELETE"};this.A5IDESTADOPRODUCTO=0;this.Z5IDESTADOPRODUCTO=0;this.O5IDESTADOPRODUCTO=0;this.A38DESCRIPCIONESTADOPRODUCTO="";this.Z38DESCRIPCIONESTADOPRODUCTO="";this.O38DESCRIPCIONESTADOPRODUCTO="";this.AV11Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7IDESTADOPRODUCTO=0;this.AV10WebSession={};this.A5IDESTADOPRODUCTO=0;this.A38DESCRIPCIONESTADOPRODUCTO="";this.Gx_mode="";this.Events={e12082_client:["AFTER TRN",!0],e130810_client:["ENTER",!0],e140810_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7IDESTADOPRODUCTO",fld:"vIDESTADOPRODUCTO",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7IDESTADOPRODUCTO",fld:"vIDESTADOPRODUCTO",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"A5IDESTADOPRODUCTO",fld:"IDESTADOPRODUCTO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.START=[[{av:"AV11Pgmname",fld:"vPGMNAME",pic:""}],[{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_IDESTADOPRODUCTO=[[],[]];this.EvtParms.VALID_DESCRIPCIONESTADOPRODUCTO=[[{av:"A38DESCRIPCIONESTADOPRODUCTO",fld:"DESCRIPCIONESTADOPRODUCTO",pic:""}],[{av:"A38DESCRIPCIONESTADOPRODUCTO",fld:"DESCRIPCIONESTADOPRODUCTO",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7IDESTADOPRODUCTO","vIDESTADOPRODUCTO",0,"int",12,0);this.setVCMap("AV11Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.estado_producto)})