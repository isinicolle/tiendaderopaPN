gx.evt.autoSkip=!1;gx.define("gx0010",!1,function(){var n,t;this.ServerClass="gx0010";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0010.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV13pIDEMPLEADO=gx.fn.getIntegerValue("vPIDEMPLEADO",",")};this.Validv_Cfechacontratacionempleado=function(){return this.validCliEvt("Validv_Cfechacontratacionempleado",0,function(){try{var n=gx.util.balloon.getNew("vCFECHACONTRATACIONEMPLEADO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11cFECHACONTRATACIONEMPLEADO)===0||new gx.date.gxdate(this.AV11cFECHACONTRATACIONEMPLEADO).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field FECHACONTRATACIONEMPLEADO is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ccorreoempleado=function(){return this.validCliEvt("Validv_Ccorreoempleado",0,function(){try{var n=gx.util.balloon.getNew("vCCORREOEMPLEADO");if(this.AnyError=0,!(gx.util.regExp.isMatch(this.AV12cCORREOEMPLEADO,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$")||gx.text.compare("",this.AV12cCORREOEMPLEADO)===0))try{n.setError("Field CORREOEMPLEADO does not match the specified pattern");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e171r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("IDEMPLEADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("IDEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCIDEMPLEADO","Visible",!0)):(gx.fn.setCtrlProperty("IDEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCIDEMPLEADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("IDEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDEMPLEADO","Visible")',ctrl:"vCIDEMPLEADO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TELEFONOEMPLEADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TELEFONOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTELEFONOEMPLEADO","Visible",!0)):(gx.fn.setCtrlProperty("TELEFONOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTELEFONOEMPLEADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TELEFONOEMPLEADOFILTERCONTAINER","Class")',ctrl:"TELEFONOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTELEFONOEMPLEADO","Visible")',ctrl:"vCTELEFONOEMPLEADO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e131r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FECHACONTRATACIONEMPLEADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("FECHACONTRATACIONEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("FECHACONTRATACIONEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FECHACONTRATACIONEMPLEADOFILTERCONTAINER","Class")',ctrl:"FECHACONTRATACIONEMPLEADOFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e141r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("CORREOEMPLEADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("CORREOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCORREOEMPLEADO","Visible",!0)):(gx.fn.setCtrlProperty("CORREOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCORREOEMPLEADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CORREOEMPLEADOFILTERCONTAINER","Class")',ctrl:"CORREOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCORREOEMPLEADO","Visible")',ctrl:"vCCORREOEMPLEADO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCIDTIPOEMPLEADO","Visible",!0)):(gx.fn.setCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCIDTIPOEMPLEADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDTIPOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDTIPOEMPLEADO","Visible")',ctrl:"vCIDTIPOEMPLEADO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e161r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("IDESTADOEMPLEADOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("IDESTADOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCIDESTADOEMPLEADO","Visible",!0)):(gx.fn.setCtrlProperty("IDESTADOEMPLEADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCIDESTADOEMPLEADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("IDESTADOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDESTADOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDESTADOEMPLEADO","Visible")',ctrl:"vCIDESTADOEMPLEADO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e201r2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e211r1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,75,76,77,78,79,80,81,82,83,84];this.GXLastCtrlId=84;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",74,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0010",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",75,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(1,76,"IDEMPLEADO","IDEMPLEADO","","IDEMPLEADO","int",0,"px",12,12,"right",null,[],1,"IDEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(26,77,"TELEFONOEMPLEADO","TELEFONOEMPLEADO","","TELEFONOEMPLEADO","char",0,"px",20,20,"left",null,[],26,"TELEFONOEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(29,78,"FECHACONTRATACIONEMPLEADO","FECHACONTRATACIONEMPLEADO","","FECHACONTRATACIONEMPLEADO","date",0,"px",8,8,"right",null,[],29,"FECHACONTRATACIONEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addBitmap(52,"FOTOEMPLEADO",79,0,"px",17,"px",null,"","FOTOEMPLEADO","ImageAttribute","WWColumn OptionalColumn");t.addSingleLineEdit(2,80,"IDTIPOEMPLEADO","IDTIPOEMPLEADO","","IDTIPOEMPLEADO","int",0,"px",12,12,"right",null,[],2,"IDTIPOEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(3,81,"IDESTADOEMPLEADO","IDESTADOEMPLEADO","","IDESTADOEMPLEADO","int",0,"px",12,12,"right",null,[],3,"IDESTADOEMPLEADO",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"IDEMPLEADOFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLIDEMPLEADOFILTER",format:1,grid:0,evt:"e111r1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCIDEMPLEADO",gxz:"ZV6cIDEMPLEADO",gxold:"OV6cIDEMPLEADO",gxvar:"AV6cIDEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cIDEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cIDEMPLEADO=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCIDEMPLEADO",gx.O.AV6cIDEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cIDEMPLEADO=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCIDEMPLEADO",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TELEFONOEMPLEADOFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLTELEFONOEMPLEADOFILTER",format:1,grid:0,evt:"e121r1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTELEFONOEMPLEADO",gxz:"ZV10cTELEFONOEMPLEADO",gxold:"OV10cTELEFONOEMPLEADO",gxvar:"AV10cTELEFONOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cTELEFONOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10cTELEFONOEMPLEADO=n)},v2c:function(){gx.fn.setControlValue("vCTELEFONOEMPLEADO",gx.O.AV10cTELEFONOEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cTELEFONOEMPLEADO=this.val())},val:function(){return gx.fn.getControlValue("vCTELEFONOEMPLEADO")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"FECHACONTRATACIONEMPLEADOFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLFECHACONTRATACIONEMPLEADOFILTER",format:1,grid:0,evt:"e131r1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cfechacontratacionempleado,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCFECHACONTRATACIONEMPLEADO",gxz:"ZV11cFECHACONTRATACIONEMPLEADO",gxold:"OV11cFECHACONTRATACIONEMPLEADO",gxvar:"AV11cFECHACONTRATACIONEMPLEADO",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cFECHACONTRATACIONEMPLEADO=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11cFECHACONTRATACIONEMPLEADO=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCFECHACONTRATACIONEMPLEADO",gx.O.AV11cFECHACONTRATACIONEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cFECHACONTRATACIONEMPLEADO=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCFECHACONTRATACIONEMPLEADO")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"CORREOEMPLEADOFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLCORREOEMPLEADOFILTER",format:1,grid:0,evt:"e141r1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ccorreoempleado,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCORREOEMPLEADO",gxz:"ZV12cCORREOEMPLEADO",gxold:"OV12cCORREOEMPLEADO",gxvar:"AV12cCORREOEMPLEADO",ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12cCORREOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12cCORREOEMPLEADO=n)},v2c:function(){gx.fn.setControlValue("vCCORREOEMPLEADO",gx.O.AV12cCORREOEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12cCORREOEMPLEADO=this.val())},val:function(){return gx.fn.getControlValue("vCCORREOEMPLEADO")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"IDTIPOEMPLEADOFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLIDTIPOEMPLEADOFILTER",format:1,grid:0,evt:"e151r1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCIDTIPOEMPLEADO",gxz:"ZV15cIDTIPOEMPLEADO",gxold:"OV15cIDTIPOEMPLEADO",gxvar:"AV15cIDTIPOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15cIDTIPOEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15cIDTIPOEMPLEADO=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCIDTIPOEMPLEADO",gx.O.AV15cIDTIPOEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15cIDTIPOEMPLEADO=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCIDTIPOEMPLEADO",",")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"IDESTADOEMPLEADOFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLIDESTADOEMPLEADOFILTER",format:1,grid:0,evt:"e161r1_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCIDESTADOEMPLEADO",gxz:"ZV16cIDESTADOEMPLEADO",gxold:"OV16cIDESTADOEMPLEADO",gxvar:"AV16cIDESTADOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16cIDESTADOEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16cIDESTADOEMPLEADO=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCIDESTADOEMPLEADO",gx.O.AV16cIDESTADOEMPLEADO,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16cIDESTADOEMPLEADO=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCIDESTADOEMPLEADO",",")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"GRIDTABLE",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTNTOGGLE",grid:0,evt:"e171r1_client"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[75]={id:75,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(74),gx.O.AV5LinkSelection,gx.O.AV19Linkselection_GXI)},c2v:function(n){gx.O.AV19Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(74))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(74))},gxvar_GXI:"AV19Linkselection_GXI",nac:gx.falseFn};n[76]={id:76,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDEMPLEADO",gxz:"Z1IDEMPLEADO",gxold:"O1IDEMPLEADO",gxvar:"A1IDEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A1IDEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1IDEMPLEADO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDEMPLEADO",n||gx.fn.currentGridRowImpl(74),gx.O.A1IDEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1IDEMPLEADO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDEMPLEADO",n||gx.fn.currentGridRowImpl(74),",")},nac:gx.falseFn};n[77]={id:77,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TELEFONOEMPLEADO",gxz:"Z26TELEFONOEMPLEADO",gxold:"O26TELEFONOEMPLEADO",gxvar:"A26TELEFONOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A26TELEFONOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.Z26TELEFONOEMPLEADO=n)},v2c:function(n){gx.fn.setGridControlValue("TELEFONOEMPLEADO",n||gx.fn.currentGridRowImpl(74),gx.O.A26TELEFONOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A26TELEFONOEMPLEADO=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TELEFONOEMPLEADO",n||gx.fn.currentGridRowImpl(74))},nac:gx.falseFn};n[78]={id:78,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHACONTRATACIONEMPLEADO",gxz:"Z29FECHACONTRATACIONEMPLEADO",gxold:"O29FECHACONTRATACIONEMPLEADO",gxvar:"A29FECHACONTRATACIONEMPLEADO",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A29FECHACONTRATACIONEMPLEADO=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z29FECHACONTRATACIONEMPLEADO=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("FECHACONTRATACIONEMPLEADO",n||gx.fn.currentGridRowImpl(74),gx.O.A29FECHACONTRATACIONEMPLEADO,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A29FECHACONTRATACIONEMPLEADO=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("FECHACONTRATACIONEMPLEADO",n||gx.fn.currentGridRowImpl(74))},nac:gx.falseFn};n[79]={id:79,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FOTOEMPLEADO",gxz:"Z52FOTOEMPLEADO",gxold:"O52FOTOEMPLEADO",gxvar:"A52FOTOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A52FOTOEMPLEADO=n)},v2z:function(n){n!==undefined&&(gx.O.Z52FOTOEMPLEADO=n)},v2c:function(n){gx.fn.setGridMultimediaValue("FOTOEMPLEADO",n||gx.fn.currentGridRowImpl(74),gx.O.A52FOTOEMPLEADO,gx.O.A40000FOTOEMPLEADO_GXI)},c2v:function(n){gx.O.A40000FOTOEMPLEADO_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A52FOTOEMPLEADO=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FOTOEMPLEADO",n||gx.fn.currentGridRowImpl(74))},val_GXI:function(n){return gx.fn.getGridControlValue("FOTOEMPLEADO_GXI",n||gx.fn.currentGridRowImpl(74))},gxvar_GXI:"A40000FOTOEMPLEADO_GXI",nac:gx.falseFn};n[80]={id:80,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDTIPOEMPLEADO",gxz:"Z2IDTIPOEMPLEADO",gxold:"O2IDTIPOEMPLEADO",gxvar:"A2IDTIPOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A2IDTIPOEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2IDTIPOEMPLEADO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(74),gx.O.A2IDTIPOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2IDTIPOEMPLEADO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDTIPOEMPLEADO",n||gx.fn.currentGridRowImpl(74),",")},nac:gx.falseFn};n[81]={id:81,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:74,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"IDESTADOEMPLEADO",gxz:"Z3IDESTADOEMPLEADO",gxold:"O3IDESTADOEMPLEADO",gxvar:"A3IDESTADOEMPLEADO",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A3IDESTADOEMPLEADO=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3IDESTADOEMPLEADO=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("IDESTADOEMPLEADO",n||gx.fn.currentGridRowImpl(74),gx.O.A3IDESTADOEMPLEADO,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3IDESTADOEMPLEADO=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("IDESTADOEMPLEADO",n||gx.fn.currentGridRowImpl(74),",")},nac:gx.falseFn};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"BTN_CANCEL",grid:0,evt:"e211r1_client"};this.AV6cIDEMPLEADO=0;this.ZV6cIDEMPLEADO=0;this.OV6cIDEMPLEADO=0;this.AV10cTELEFONOEMPLEADO="";this.ZV10cTELEFONOEMPLEADO="";this.OV10cTELEFONOEMPLEADO="";this.AV11cFECHACONTRATACIONEMPLEADO=gx.date.nullDate();this.ZV11cFECHACONTRATACIONEMPLEADO=gx.date.nullDate();this.OV11cFECHACONTRATACIONEMPLEADO=gx.date.nullDate();this.AV12cCORREOEMPLEADO="";this.ZV12cCORREOEMPLEADO="";this.OV12cCORREOEMPLEADO="";this.AV15cIDTIPOEMPLEADO=0;this.ZV15cIDTIPOEMPLEADO=0;this.OV15cIDTIPOEMPLEADO=0;this.AV16cIDESTADOEMPLEADO=0;this.ZV16cIDESTADOEMPLEADO=0;this.OV16cIDESTADOEMPLEADO=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z1IDEMPLEADO=0;this.O1IDEMPLEADO=0;this.Z26TELEFONOEMPLEADO="";this.O26TELEFONOEMPLEADO="";this.Z29FECHACONTRATACIONEMPLEADO=gx.date.nullDate();this.O29FECHACONTRATACIONEMPLEADO=gx.date.nullDate();this.Z52FOTOEMPLEADO="";this.O52FOTOEMPLEADO="";this.Z2IDTIPOEMPLEADO=0;this.O2IDTIPOEMPLEADO=0;this.Z3IDESTADOEMPLEADO=0;this.O3IDESTADOEMPLEADO=0;this.AV6cIDEMPLEADO=0;this.AV10cTELEFONOEMPLEADO="";this.AV11cFECHACONTRATACIONEMPLEADO=gx.date.nullDate();this.AV12cCORREOEMPLEADO="";this.AV15cIDTIPOEMPLEADO=0;this.AV16cIDESTADOEMPLEADO=0;this.A40000FOTOEMPLEADO_GXI="";this.AV13pIDEMPLEADO=0;this.A27CORREOEMPLEADO="";this.AV5LinkSelection="";this.A1IDEMPLEADO=0;this.A26TELEFONOEMPLEADO="";this.A29FECHACONTRATACIONEMPLEADO=gx.date.nullDate();this.A52FOTOEMPLEADO="";this.A2IDTIPOEMPLEADO=0;this.A3IDESTADOEMPLEADO=0;this.Events={e201r2_client:["ENTER",!0],e211r1_client:["CANCEL",!0],e171r1_client:["'TOGGLE'",!1],e111r1_client:["LBLIDEMPLEADOFILTER.CLICK",!1],e121r1_client:["LBLTELEFONOEMPLEADOFILTER.CLICK",!1],e131r1_client:["LBLFECHACONTRATACIONEMPLEADOFILTER.CLICK",!1],e141r1_client:["LBLCORREOEMPLEADOFILTER.CLICK",!1],e151r1_client:["LBLIDTIPOEMPLEADOFILTER.CLICK",!1],e161r1_client:["LBLIDESTADOEMPLEADOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDEMPLEADO",fld:"vCIDEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV10cTELEFONOEMPLEADO",fld:"vCTELEFONOEMPLEADO",pic:""},{av:"AV11cFECHACONTRATACIONEMPLEADO",fld:"vCFECHACONTRATACIONEMPLEADO",pic:""},{av:"AV12cCORREOEMPLEADO",fld:"vCCORREOEMPLEADO",pic:""},{av:"AV15cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV16cIDESTADOEMPLEADO",fld:"vCIDESTADOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLIDEMPLEADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("IDEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDEMPLEADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("IDEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDEMPLEADO","Visible")',ctrl:"vCIDEMPLEADO",prop:"Visible"}]];this.EvtParms["LBLTELEFONOEMPLEADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TELEFONOEMPLEADOFILTERCONTAINER","Class")',ctrl:"TELEFONOEMPLEADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TELEFONOEMPLEADOFILTERCONTAINER","Class")',ctrl:"TELEFONOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTELEFONOEMPLEADO","Visible")',ctrl:"vCTELEFONOEMPLEADO",prop:"Visible"}]];this.EvtParms["LBLFECHACONTRATACIONEMPLEADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FECHACONTRATACIONEMPLEADOFILTERCONTAINER","Class")',ctrl:"FECHACONTRATACIONEMPLEADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FECHACONTRATACIONEMPLEADOFILTERCONTAINER","Class")',ctrl:"FECHACONTRATACIONEMPLEADOFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLCORREOEMPLEADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("CORREOEMPLEADOFILTERCONTAINER","Class")',ctrl:"CORREOEMPLEADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("CORREOEMPLEADOFILTERCONTAINER","Class")',ctrl:"CORREOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCORREOEMPLEADO","Visible")',ctrl:"vCCORREOEMPLEADO",prop:"Visible"}]];this.EvtParms["LBLIDTIPOEMPLEADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDTIPOEMPLEADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("IDTIPOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDTIPOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDTIPOEMPLEADO","Visible")',ctrl:"vCIDTIPOEMPLEADO",prop:"Visible"}]];this.EvtParms["LBLIDESTADOEMPLEADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("IDESTADOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDESTADOEMPLEADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("IDESTADOEMPLEADOFILTERCONTAINER","Class")',ctrl:"IDESTADOEMPLEADOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCIDESTADOEMPLEADO","Visible")',ctrl:"vCIDESTADOEMPLEADO",prop:"Visible"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A1IDEMPLEADO",fld:"IDEMPLEADO",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"AV13pIDEMPLEADO",fld:"vPIDEMPLEADO",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDEMPLEADO",fld:"vCIDEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV10cTELEFONOEMPLEADO",fld:"vCTELEFONOEMPLEADO",pic:""},{av:"AV11cFECHACONTRATACIONEMPLEADO",fld:"vCFECHACONTRATACIONEMPLEADO",pic:""},{av:"AV12cCORREOEMPLEADO",fld:"vCCORREOEMPLEADO",pic:""},{av:"AV15cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV16cIDESTADOEMPLEADO",fld:"vCIDESTADOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDEMPLEADO",fld:"vCIDEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV10cTELEFONOEMPLEADO",fld:"vCTELEFONOEMPLEADO",pic:""},{av:"AV11cFECHACONTRATACIONEMPLEADO",fld:"vCFECHACONTRATACIONEMPLEADO",pic:""},{av:"AV12cCORREOEMPLEADO",fld:"vCCORREOEMPLEADO",pic:""},{av:"AV15cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV16cIDESTADOEMPLEADO",fld:"vCIDESTADOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDEMPLEADO",fld:"vCIDEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV10cTELEFONOEMPLEADO",fld:"vCTELEFONOEMPLEADO",pic:""},{av:"AV11cFECHACONTRATACIONEMPLEADO",fld:"vCFECHACONTRATACIONEMPLEADO",pic:""},{av:"AV12cCORREOEMPLEADO",fld:"vCCORREOEMPLEADO",pic:""},{av:"AV15cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV16cIDESTADOEMPLEADO",fld:"vCIDESTADOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cIDEMPLEADO",fld:"vCIDEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV10cTELEFONOEMPLEADO",fld:"vCTELEFONOEMPLEADO",pic:""},{av:"AV11cFECHACONTRATACIONEMPLEADO",fld:"vCFECHACONTRATACIONEMPLEADO",pic:""},{av:"AV12cCORREOEMPLEADO",fld:"vCCORREOEMPLEADO",pic:""},{av:"AV15cIDTIPOEMPLEADO",fld:"vCIDTIPOEMPLEADO",pic:"ZZZZZZZZZZZ9"},{av:"AV16cIDESTADOEMPLEADO",fld:"vCIDESTADOEMPLEADO",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.VALIDV_CFECHACONTRATACIONEMPLEADO=[[],[]];this.EvtParms.VALIDV_CCORREOEMPLEADO=[[],[]];this.setVCMap("AV13pIDEMPLEADO","vPIDEMPLEADO",0,"int",12,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0010)})