using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class empleadosgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public empleadosgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public empleadosgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_IDEMPLEADO )
      {
         this.A1IDEMPLEADO = aP0_IDEMPLEADO;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "IDEMPLEADO");
               gxfirstwebparm_bkp = gxfirstwebparm;
               gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  dyncall( GetNextPar( )) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A1IDEMPLEADO = (long)(NumberUtil.Val( GetPar( "IDEMPLEADO"), "."));
                  AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A1IDEMPLEADO});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "IDEMPLEADO");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "IDEMPLEADO");
               }
               else
               {
                  if ( ! IsValidAjaxCall( false) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = gxfirstwebparm_bkp;
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "EmpleadosGeneral";
               context.Gx_err = 0;
               WS0Y2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Empleados General") ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1152180), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202111280104369", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1152180), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("empleadosgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1IDEMPLEADO,12,0))}, new string[] {"IDEMPLEADO"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EmpleadosGeneral");
         forbiddenHiddens.Add("IDTIPOEMPLEADO", context.localUtil.Format( (decimal)(A2IDTIPOEMPLEADO), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("IDESTADOEMPLEADO", context.localUtil.Format( (decimal)(A3IDESTADOEMPLEADO), "ZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("empleadosgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA1IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA1IDEMPLEADO), 12, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0Y2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "EmpleadosGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empleados General" ;
      }

      protected void WB0Y0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "empleadosgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewActionsCell", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WWViewActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110y1_client"+"'", TempTags, "", 2, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120y1_client"+"'", TempTags, "", 2, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDEMPLEADO_Internalname, "IDEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")), ((edtIDEMPLEADO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDEMPLEADO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNOMBRECOMPLETOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, "NOMBRECOMPLETOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, A23NOMBRECOMPLETOEMPLEADO, "", "", 0, 1, edtNOMBRECOMPLETOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUSUARIOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUSUARIOEMPLEADO_Internalname, "USUARIOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtUSUARIOEMPLEADO_Internalname, A24USUARIOEMPLEADO, "", "", 0, 1, edtUSUARIOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCONTRASENAEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCONTRASENAEMPLEADO_Internalname, "CONTRASENAEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtCONTRASENAEMPLEADO_Internalname, A25CONTRASENAEMPLEADO, "", "", 0, 1, edtCONTRASENAEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTELEFONOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTELEFONOEMPLEADO_Internalname, "TELEFONOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A26TELEFONOEMPLEADO);
            }
            GxWebStd.gx_single_line_edit( context, edtTELEFONOEMPLEADO_Internalname, StringUtil.RTrim( A26TELEFONOEMPLEADO), StringUtil.RTrim( context.localUtil.Format( A26TELEFONOEMPLEADO, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtTELEFONOEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTELEFONOEMPLEADO_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHACONTRATACIONEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFECHACONTRATACIONEMPLEADO_Internalname, "FECHACONTRATACIONEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtFECHACONTRATACIONEMPLEADO_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFECHACONTRATACIONEMPLEADO_Internalname, context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"), context.localUtil.Format( A29FECHACONTRATACIONEMPLEADO, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHACONTRATACIONEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFECHACONTRATACIONEMPLEADO_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_bitmap( context, edtFECHACONTRATACIONEMPLEADO_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHACONTRATACIONEMPLEADO_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_EmpleadosGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCORREOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCORREOEMPLEADO_Internalname, "CORREOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCORREOEMPLEADO_Internalname, A27CORREOEMPLEADO, StringUtil.RTrim( context.localUtil.Format( A27CORREOEMPLEADO, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A27CORREOEMPLEADO, "", "", "", edtCORREOEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCORREOEMPLEADO_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDIRECCIONEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDIRECCIONEMPLEADO_Internalname, "DIRECCIONEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDIRECCIONEMPLEADO_Internalname, A28DIRECCIONEMPLEADO, "", "", 0, 1, edtDIRECCIONEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDTIPOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDTIPOEMPLEADO_Internalname, "IDTIPOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDTIPOEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2IDTIPOEMPLEADO), 12, 0, ".", "")), ((edtIDTIPOEMPLEADO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A2IDTIPOEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A2IDTIPOEMPLEADO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDTIPOEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDTIPOEMPLEADO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONTIPOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONTIPOEMPLEADO_Internalname, "DESCRIPCIONTIPOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONTIPOEMPLEADO_Internalname, A21DESCRIPCIONTIPOEMPLEADO, edtDESCRIPCIONTIPOEMPLEADO_Link, "", 0, 1, edtDESCRIPCIONTIPOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDESTADOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDESTADOEMPLEADO_Internalname, "IDESTADOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDESTADOEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3IDESTADOEMPLEADO), 12, 0, ".", "")), ((edtIDESTADOEMPLEADO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A3IDESTADOEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A3IDESTADOEMPLEADO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDESTADOEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDESTADOEMPLEADO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONESTADOEMPLEADO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONESTADOEMPLEADO_Internalname, "DESCRIPCIONESTADOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONESTADOEMPLEADO_Internalname, A22DESCRIPCIONESTADOEMPLEADO, edtDESCRIPCIONESTADOEMPLEADO_Link, "", 0, 1, edtDESCRIPCIONESTADOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "FOTOEMPLEADO", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A52FOTOEMPLEADO_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FOTOEMPLEADO_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.PathToRelativeUrl( A52FOTOEMPLEADO));
            GxWebStd.gx_bitmap( context, imgFOTOEMPLEADO_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A52FOTOEMPLEADO_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_EmpleadosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0Y2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 17_0_5-152925", 0) ;
               }
               Form.Meta.addItem("description", "Empleados General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0Y0( ) ;
            }
         }
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0Y2( ) ;
            }
         }
      }

      protected void PA0Y2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "EmpleadosGeneral";
         context.Gx_err = 0;
      }

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000Y2 */
            pr_default.execute(0, new Object[] {A1IDEMPLEADO});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40000FOTOEMPLEADO_GXI = H000Y2_A40000FOTOEMPLEADO_GXI[0];
               AssignProp(sPrefix, false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
               AssignProp(sPrefix, false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
               A22DESCRIPCIONESTADOEMPLEADO = H000Y2_A22DESCRIPCIONESTADOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
               A3IDESTADOEMPLEADO = H000Y2_A3IDESTADOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
               A21DESCRIPCIONTIPOEMPLEADO = H000Y2_A21DESCRIPCIONTIPOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
               A2IDTIPOEMPLEADO = H000Y2_A2IDTIPOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
               A28DIRECCIONEMPLEADO = H000Y2_A28DIRECCIONEMPLEADO[0];
               AssignAttri(sPrefix, false, "A28DIRECCIONEMPLEADO", A28DIRECCIONEMPLEADO);
               A27CORREOEMPLEADO = H000Y2_A27CORREOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A27CORREOEMPLEADO", A27CORREOEMPLEADO);
               A29FECHACONTRATACIONEMPLEADO = H000Y2_A29FECHACONTRATACIONEMPLEADO[0];
               AssignAttri(sPrefix, false, "A29FECHACONTRATACIONEMPLEADO", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
               A26TELEFONOEMPLEADO = H000Y2_A26TELEFONOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A26TELEFONOEMPLEADO", A26TELEFONOEMPLEADO);
               A25CONTRASENAEMPLEADO = H000Y2_A25CONTRASENAEMPLEADO[0];
               AssignAttri(sPrefix, false, "A25CONTRASENAEMPLEADO", A25CONTRASENAEMPLEADO);
               A24USUARIOEMPLEADO = H000Y2_A24USUARIOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A24USUARIOEMPLEADO", A24USUARIOEMPLEADO);
               A23NOMBRECOMPLETOEMPLEADO = H000Y2_A23NOMBRECOMPLETOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
               A52FOTOEMPLEADO = H000Y2_A52FOTOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A52FOTOEMPLEADO", A52FOTOEMPLEADO);
               AssignProp(sPrefix, false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
               AssignProp(sPrefix, false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
               A22DESCRIPCIONESTADOEMPLEADO = H000Y2_A22DESCRIPCIONESTADOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
               A21DESCRIPCIONTIPOEMPLEADO = H000Y2_A21DESCRIPCIONTIPOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
               /* Execute user event: Load */
               E140Y2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "EmpleadosGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1IDEMPLEADO"), ".", ","));
            /* Read variables values. */
            A23NOMBRECOMPLETOEMPLEADO = cgiGet( edtNOMBRECOMPLETOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            A24USUARIOEMPLEADO = cgiGet( edtUSUARIOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A24USUARIOEMPLEADO", A24USUARIOEMPLEADO);
            A25CONTRASENAEMPLEADO = cgiGet( edtCONTRASENAEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A25CONTRASENAEMPLEADO", A25CONTRASENAEMPLEADO);
            A26TELEFONOEMPLEADO = cgiGet( edtTELEFONOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A26TELEFONOEMPLEADO", A26TELEFONOEMPLEADO);
            A29FECHACONTRATACIONEMPLEADO = context.localUtil.CToD( cgiGet( edtFECHACONTRATACIONEMPLEADO_Internalname), 1);
            AssignAttri(sPrefix, false, "A29FECHACONTRATACIONEMPLEADO", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
            A27CORREOEMPLEADO = cgiGet( edtCORREOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A27CORREOEMPLEADO", A27CORREOEMPLEADO);
            A28DIRECCIONEMPLEADO = cgiGet( edtDIRECCIONEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A28DIRECCIONEMPLEADO", A28DIRECCIONEMPLEADO);
            A2IDTIPOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDTIPOEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
            A21DESCRIPCIONTIPOEMPLEADO = cgiGet( edtDESCRIPCIONTIPOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
            A3IDESTADOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDESTADOEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
            A22DESCRIPCIONESTADOEMPLEADO = cgiGet( edtDESCRIPCIONESTADOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
            A52FOTOEMPLEADO = cgiGet( imgFOTOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A52FOTOEMPLEADO", A52FOTOEMPLEADO);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EmpleadosGeneral");
            A2IDTIPOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDTIPOEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
            forbiddenHiddens.Add("IDTIPOEMPLEADO", context.localUtil.Format( (decimal)(A2IDTIPOEMPLEADO), "ZZZZZZZZZZZ9"));
            A3IDESTADOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDESTADOEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
            forbiddenHiddens.Add("IDESTADOEMPLEADO", context.localUtil.Format( (decimal)(A3IDESTADOEMPLEADO), "ZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("empleadosgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E130Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140Y2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtDESCRIPCIONTIPOEMPLEADO_Link = formatLink("viewtipo_empleado.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A2IDTIPOEMPLEADO,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDTIPOEMPLEADO","TabCode"}) ;
         AssignProp(sPrefix, false, edtDESCRIPCIONTIPOEMPLEADO_Internalname, "Link", edtDESCRIPCIONTIPOEMPLEADO_Link, true);
         edtDESCRIPCIONESTADOEMPLEADO_Link = formatLink("viewestado_empleado.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A3IDESTADOEMPLEADO,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDESTADOEMPLEADO","TabCode"}) ;
         AssignProp(sPrefix, false, edtDESCRIPCIONESTADOEMPLEADO_Internalname, "Link", edtDESCRIPCIONESTADOEMPLEADO_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Empleados";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "IDEMPLEADO";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6IDEMPLEADO), 12, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "TiendaRopaProyecto"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A1IDEMPLEADO = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA1IDEMPLEADO = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "empleadosgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A1IDEMPLEADO = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         }
         wcpOA1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1IDEMPLEADO"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A1IDEMPLEADO != wcpOA1IDEMPLEADO ) ) )
         {
            setjustcreated();
         }
         wcpOA1IDEMPLEADO = A1IDEMPLEADO;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA1IDEMPLEADO = cgiGet( sPrefix+"A1IDEMPLEADO_CTRL");
         if ( StringUtil.Len( sCtrlA1IDEMPLEADO) > 0 )
         {
            A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( sCtrlA1IDEMPLEADO), ".", ","));
            AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         }
         else
         {
            A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"A1IDEMPLEADO_PARM"), ".", ","));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A1IDEMPLEADO_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA1IDEMPLEADO)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A1IDEMPLEADO_CTRL", StringUtil.RTrim( sCtrlA1IDEMPLEADO));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202111280104412", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("empleadosgeneral.js", "?202111280104412", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtIDEMPLEADO_Internalname = sPrefix+"IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = sPrefix+"NOMBRECOMPLETOEMPLEADO";
         edtUSUARIOEMPLEADO_Internalname = sPrefix+"USUARIOEMPLEADO";
         edtCONTRASENAEMPLEADO_Internalname = sPrefix+"CONTRASENAEMPLEADO";
         edtTELEFONOEMPLEADO_Internalname = sPrefix+"TELEFONOEMPLEADO";
         edtFECHACONTRATACIONEMPLEADO_Internalname = sPrefix+"FECHACONTRATACIONEMPLEADO";
         edtCORREOEMPLEADO_Internalname = sPrefix+"CORREOEMPLEADO";
         edtDIRECCIONEMPLEADO_Internalname = sPrefix+"DIRECCIONEMPLEADO";
         edtIDTIPOEMPLEADO_Internalname = sPrefix+"IDTIPOEMPLEADO";
         edtDESCRIPCIONTIPOEMPLEADO_Internalname = sPrefix+"DESCRIPCIONTIPOEMPLEADO";
         edtIDESTADOEMPLEADO_Internalname = sPrefix+"IDESTADOEMPLEADO";
         edtDESCRIPCIONESTADOEMPLEADO_Internalname = sPrefix+"DESCRIPCIONESTADOEMPLEADO";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgFOTOEMPLEADO_Internalname = sPrefix+"FOTOEMPLEADO";
         divImagestable_Internalname = sPrefix+"IMAGESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtDESCRIPCIONESTADOEMPLEADO_Link = "";
         edtDESCRIPCIONESTADOEMPLEADO_Enabled = 0;
         edtIDESTADOEMPLEADO_Jsonclick = "";
         edtIDESTADOEMPLEADO_Enabled = 0;
         edtDESCRIPCIONTIPOEMPLEADO_Link = "";
         edtDESCRIPCIONTIPOEMPLEADO_Enabled = 0;
         edtIDTIPOEMPLEADO_Jsonclick = "";
         edtIDTIPOEMPLEADO_Enabled = 0;
         edtDIRECCIONEMPLEADO_Enabled = 0;
         edtCORREOEMPLEADO_Jsonclick = "";
         edtCORREOEMPLEADO_Enabled = 0;
         edtFECHACONTRATACIONEMPLEADO_Jsonclick = "";
         edtFECHACONTRATACIONEMPLEADO_Enabled = 0;
         edtTELEFONOEMPLEADO_Jsonclick = "";
         edtTELEFONOEMPLEADO_Enabled = 0;
         edtCONTRASENAEMPLEADO_Enabled = 0;
         edtUSUARIOEMPLEADO_Enabled = 0;
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         edtIDEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A2IDTIPOEMPLEADO',fld:'IDTIPOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A3IDESTADOEMPLEADO',fld:'IDESTADOEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110Y1',iparms:[{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120Y1',iparms:[{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_IDEMPLEADO","{handler:'Valid_Idempleado',iparms:[]");
         setEventMetadata("VALID_IDEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_IDTIPOEMPLEADO","{handler:'Valid_Idtipoempleado',iparms:[]");
         setEventMetadata("VALID_IDTIPOEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_IDESTADOEMPLEADO","{handler:'Valid_Idestadoempleado',iparms:[]");
         setEventMetadata("VALID_IDESTADOEMPLEADO",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A23NOMBRECOMPLETOEMPLEADO = "";
         A24USUARIOEMPLEADO = "";
         A25CONTRASENAEMPLEADO = "";
         gxphoneLink = "";
         A26TELEFONOEMPLEADO = "";
         A29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         A27CORREOEMPLEADO = "";
         A28DIRECCIONEMPLEADO = "";
         A21DESCRIPCIONTIPOEMPLEADO = "";
         A22DESCRIPCIONESTADOEMPLEADO = "";
         A52FOTOEMPLEADO = "";
         A40000FOTOEMPLEADO_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000Y2_A1IDEMPLEADO = new long[1] ;
         H000Y2_A40000FOTOEMPLEADO_GXI = new string[] {""} ;
         H000Y2_A22DESCRIPCIONESTADOEMPLEADO = new string[] {""} ;
         H000Y2_A3IDESTADOEMPLEADO = new long[1] ;
         H000Y2_A21DESCRIPCIONTIPOEMPLEADO = new string[] {""} ;
         H000Y2_A2IDTIPOEMPLEADO = new long[1] ;
         H000Y2_A28DIRECCIONEMPLEADO = new string[] {""} ;
         H000Y2_A27CORREOEMPLEADO = new string[] {""} ;
         H000Y2_A29FECHACONTRATACIONEMPLEADO = new DateTime[] {DateTime.MinValue} ;
         H000Y2_A26TELEFONOEMPLEADO = new string[] {""} ;
         H000Y2_A25CONTRASENAEMPLEADO = new string[] {""} ;
         H000Y2_A24USUARIOEMPLEADO = new string[] {""} ;
         H000Y2_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         H000Y2_A52FOTOEMPLEADO = new string[] {""} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA1IDEMPLEADO = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empleadosgeneral__default(),
            new Object[][] {
                new Object[] {
               H000Y2_A1IDEMPLEADO, H000Y2_A40000FOTOEMPLEADO_GXI, H000Y2_A22DESCRIPCIONESTADOEMPLEADO, H000Y2_A3IDESTADOEMPLEADO, H000Y2_A21DESCRIPCIONTIPOEMPLEADO, H000Y2_A2IDTIPOEMPLEADO, H000Y2_A28DIRECCIONEMPLEADO, H000Y2_A27CORREOEMPLEADO, H000Y2_A29FECHACONTRATACIONEMPLEADO, H000Y2_A26TELEFONOEMPLEADO,
               H000Y2_A25CONTRASENAEMPLEADO, H000Y2_A24USUARIOEMPLEADO, H000Y2_A23NOMBRECOMPLETOEMPLEADO, H000Y2_A52FOTOEMPLEADO
               }
            }
         );
         AV13Pgmname = "EmpleadosGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "EmpleadosGeneral";
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtIDEMPLEADO_Enabled ;
      private int edtNOMBRECOMPLETOEMPLEADO_Enabled ;
      private int edtUSUARIOEMPLEADO_Enabled ;
      private int edtCONTRASENAEMPLEADO_Enabled ;
      private int edtTELEFONOEMPLEADO_Enabled ;
      private int edtFECHACONTRATACIONEMPLEADO_Enabled ;
      private int edtCORREOEMPLEADO_Enabled ;
      private int edtDIRECCIONEMPLEADO_Enabled ;
      private int edtIDTIPOEMPLEADO_Enabled ;
      private int edtDESCRIPCIONTIPOEMPLEADO_Enabled ;
      private int edtIDESTADOEMPLEADO_Enabled ;
      private int edtDESCRIPCIONESTADOEMPLEADO_Enabled ;
      private int idxLst ;
      private long A1IDEMPLEADO ;
      private long wcpOA1IDEMPLEADO ;
      private long A2IDTIPOEMPLEADO ;
      private long A3IDESTADOEMPLEADO ;
      private long AV6IDEMPLEADO ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtIDEMPLEADO_Internalname ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string edtNOMBRECOMPLETOEMPLEADO_Internalname ;
      private string edtUSUARIOEMPLEADO_Internalname ;
      private string edtCONTRASENAEMPLEADO_Internalname ;
      private string edtTELEFONOEMPLEADO_Internalname ;
      private string gxphoneLink ;
      private string A26TELEFONOEMPLEADO ;
      private string edtTELEFONOEMPLEADO_Jsonclick ;
      private string edtFECHACONTRATACIONEMPLEADO_Internalname ;
      private string edtFECHACONTRATACIONEMPLEADO_Jsonclick ;
      private string edtCORREOEMPLEADO_Internalname ;
      private string edtCORREOEMPLEADO_Jsonclick ;
      private string edtDIRECCIONEMPLEADO_Internalname ;
      private string edtIDTIPOEMPLEADO_Internalname ;
      private string edtIDTIPOEMPLEADO_Jsonclick ;
      private string edtDESCRIPCIONTIPOEMPLEADO_Internalname ;
      private string edtDESCRIPCIONTIPOEMPLEADO_Link ;
      private string edtIDESTADOEMPLEADO_Internalname ;
      private string edtIDESTADOEMPLEADO_Jsonclick ;
      private string edtDESCRIPCIONESTADOEMPLEADO_Internalname ;
      private string edtDESCRIPCIONESTADOEMPLEADO_Link ;
      private string divImagestable_Internalname ;
      private string sImgUrl ;
      private string imgFOTOEMPLEADO_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA1IDEMPLEADO ;
      private DateTime A29FECHACONTRATACIONEMPLEADO ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A52FOTOEMPLEADO_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private string A24USUARIOEMPLEADO ;
      private string A25CONTRASENAEMPLEADO ;
      private string A27CORREOEMPLEADO ;
      private string A28DIRECCIONEMPLEADO ;
      private string A21DESCRIPCIONTIPOEMPLEADO ;
      private string A22DESCRIPCIONESTADOEMPLEADO ;
      private string A40000FOTOEMPLEADO_GXI ;
      private string A52FOTOEMPLEADO ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H000Y2_A1IDEMPLEADO ;
      private string[] H000Y2_A40000FOTOEMPLEADO_GXI ;
      private string[] H000Y2_A22DESCRIPCIONESTADOEMPLEADO ;
      private long[] H000Y2_A3IDESTADOEMPLEADO ;
      private string[] H000Y2_A21DESCRIPCIONTIPOEMPLEADO ;
      private long[] H000Y2_A2IDTIPOEMPLEADO ;
      private string[] H000Y2_A28DIRECCIONEMPLEADO ;
      private string[] H000Y2_A27CORREOEMPLEADO ;
      private DateTime[] H000Y2_A29FECHACONTRATACIONEMPLEADO ;
      private string[] H000Y2_A26TELEFONOEMPLEADO ;
      private string[] H000Y2_A25CONTRASENAEMPLEADO ;
      private string[] H000Y2_A24USUARIOEMPLEADO ;
      private string[] H000Y2_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] H000Y2_A52FOTOEMPLEADO ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class empleadosgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000Y2;
          prmH000Y2 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Y2", "SELECT T1.[IDEMPLEADO], T1.[FOTOEMPLEADO_GXI], T2.[DESCRIPCIONESTADOEMPLEADO], T1.[IDESTADOEMPLEADO], T3.[DESCRIPCIONTIPOEMPLEADO], T1.[IDTIPOEMPLEADO], T1.[DIRECCIONEMPLEADO], T1.[CORREOEMPLEADO], T1.[FECHACONTRATACIONEMPLEADO], T1.[TELEFONOEMPLEADO], T1.[CONTRASENAEMPLEADO], T1.[USUARIOEMPLEADO], T1.[NOMBRECOMPLETOEMPLEADO], T1.[FOTOEMPLEADO] FROM (([Empleados] T1 INNER JOIN [Estado_empleado] T2 ON T2.[IDESTADOEMPLEADO] = T1.[IDESTADOEMPLEADO]) INNER JOIN [Tipo_empleado] T3 ON T3.[IDTIPOEMPLEADO] = T1.[IDTIPOEMPLEADO]) WHERE T1.[IDEMPLEADO] = @IDEMPLEADO ORDER BY T1.[IDEMPLEADO] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y2,1, GxCacheFrequency.OFF ,true,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(2));
                return;
       }
    }

 }

}
