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
   public class clientesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public clientesgeneral( )
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

      public clientesgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_IDCLIENTE )
      {
         this.A4IDCLIENTE = aP0_IDCLIENTE;
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
               gxfirstwebparm = GetFirstPar( "IDCLIENTE");
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
                  A4IDCLIENTE = (long)(NumberUtil.Val( GetPar( "IDCLIENTE"), "."));
                  AssignAttri(sPrefix, false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A4IDCLIENTE});
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
                  gxfirstwebparm = GetFirstPar( "IDCLIENTE");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "IDCLIENTE");
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
            PA152( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ClientesGeneral";
               context.Gx_err = 0;
               WS152( ) ;
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
            context.SendWebValue( "Clientes General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021113012305584", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientesgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A4IDCLIENTE,12,0))}, new string[] {"IDCLIENTE"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA4IDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA4IDCLIENTE), 12, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm152( )
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
         return "ClientesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Clientes General" ;
      }

      protected void WB150( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "clientesgeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11151_client"+"'", TempTags, "", 2, "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12151_client"+"'", TempTags, "", 2, "HLP_ClientesGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDCLIENTE_Internalname, "IDCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDCLIENTE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")), ((edtIDCLIENTE_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCLIENTE_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDCLIENTE_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNOMBRECOMPLETOCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNOMBRECOMPLETOCLIENTE_Internalname, "NOMBRECOMPLETOCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOCLIENTE_Internalname, A30NOMBRECOMPLETOCLIENTE, "", "", 0, 1, edtNOMBRECOMPLETOCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUSUARIOCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUSUARIOCLIENTE_Internalname, "USUARIOCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtUSUARIOCLIENTE_Internalname, A31USUARIOCLIENTE, "", "", 0, 1, edtUSUARIOCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCONTRASENACLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCONTRASENACLIENTE_Internalname, "CONTRASENACLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtCONTRASENACLIENTE_Internalname, A32CONTRASENACLIENTE, "", "", 0, 1, edtCONTRASENACLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTELEFONOCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTELEFONOCLIENTE_Internalname, "TELEFONOCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A33TELEFONOCLIENTE);
            }
            GxWebStd.gx_single_line_edit( context, edtTELEFONOCLIENTE_Internalname, StringUtil.RTrim( A33TELEFONOCLIENTE), StringUtil.RTrim( context.localUtil.Format( A33TELEFONOCLIENTE, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtTELEFONOCLIENTE_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTELEFONOCLIENTE_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCORREOCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCORREOCLIENTE_Internalname, "CORREOCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCORREOCLIENTE_Internalname, A34CORREOCLIENTE, StringUtil.RTrim( context.localUtil.Format( A34CORREOCLIENTE, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A34CORREOCLIENTE, "", "", "", edtCORREOCLIENTE_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCORREOCLIENTE_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHANACIMIENTOCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFECHANACIMIENTOCLIENTE_Internalname, "FECHANACIMIENTOCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtFECHANACIMIENTOCLIENTE_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFECHANACIMIENTOCLIENTE_Internalname, context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"), context.localUtil.Format( A35FECHANACIMIENTOCLIENTE, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHANACIMIENTOCLIENTE_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFECHANACIMIENTOCLIENTE_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtFECHANACIMIENTOCLIENTE_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHANACIMIENTOCLIENTE_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ClientesGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDIRECCIONCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDIRECCIONCLIENTE_Internalname, "DIRECCIONCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDIRECCIONCLIENTE_Internalname, A36DIRECCIONCLIENTE, "", "", 0, 1, edtDIRECCIONCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Direccion", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ClientesGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHAREGISTROCLIENTE_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFECHAREGISTROCLIENTE_Internalname, "FECHAREGISTROCLIENTE", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtFECHAREGISTROCLIENTE_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFECHAREGISTROCLIENTE_Internalname, context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"), context.localUtil.Format( A37FECHAREGISTROCLIENTE, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHAREGISTROCLIENTE_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFECHAREGISTROCLIENTE_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ClientesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtFECHAREGISTROCLIENTE_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHAREGISTROCLIENTE_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ClientesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_label_element( context, "", "FOTOCLIENTE", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A53FOTOCLIENTE_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FOTOCLIENTE_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.PathToRelativeUrl( A53FOTOCLIENTE));
            GxWebStd.gx_bitmap( context, imgFOTOCLIENTE_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A53FOTOCLIENTE_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ClientesGeneral.htm");
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

      protected void START152( )
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
               Form.Meta.addItem("description", "Clientes General", 0) ;
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
               STRUP150( ) ;
            }
         }
      }

      protected void WS152( )
      {
         START152( ) ;
         EVT152( ) ;
      }

      protected void EVT152( )
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
                                 STRUP150( ) ;
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
                                 STRUP150( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13152 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP150( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14152 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP150( ) ;
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
                                 STRUP150( ) ;
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

      protected void WE152( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm152( ) ;
            }
         }
      }

      protected void PA152( )
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
         RF152( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ClientesGeneral";
         context.Gx_err = 0;
      }

      protected void RF152( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00152 */
            pr_default.execute(0, new Object[] {A4IDCLIENTE});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40000FOTOCLIENTE_GXI = H00152_A40000FOTOCLIENTE_GXI[0];
               AssignProp(sPrefix, false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
               AssignProp(sPrefix, false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
               A37FECHAREGISTROCLIENTE = H00152_A37FECHAREGISTROCLIENTE[0];
               AssignAttri(sPrefix, false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
               A36DIRECCIONCLIENTE = H00152_A36DIRECCIONCLIENTE[0];
               AssignAttri(sPrefix, false, "A36DIRECCIONCLIENTE", A36DIRECCIONCLIENTE);
               A35FECHANACIMIENTOCLIENTE = H00152_A35FECHANACIMIENTOCLIENTE[0];
               AssignAttri(sPrefix, false, "A35FECHANACIMIENTOCLIENTE", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
               A34CORREOCLIENTE = H00152_A34CORREOCLIENTE[0];
               AssignAttri(sPrefix, false, "A34CORREOCLIENTE", A34CORREOCLIENTE);
               A33TELEFONOCLIENTE = H00152_A33TELEFONOCLIENTE[0];
               AssignAttri(sPrefix, false, "A33TELEFONOCLIENTE", A33TELEFONOCLIENTE);
               A32CONTRASENACLIENTE = H00152_A32CONTRASENACLIENTE[0];
               AssignAttri(sPrefix, false, "A32CONTRASENACLIENTE", A32CONTRASENACLIENTE);
               A31USUARIOCLIENTE = H00152_A31USUARIOCLIENTE[0];
               AssignAttri(sPrefix, false, "A31USUARIOCLIENTE", A31USUARIOCLIENTE);
               A30NOMBRECOMPLETOCLIENTE = H00152_A30NOMBRECOMPLETOCLIENTE[0];
               AssignAttri(sPrefix, false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
               A53FOTOCLIENTE = H00152_A53FOTOCLIENTE[0];
               AssignAttri(sPrefix, false, "A53FOTOCLIENTE", A53FOTOCLIENTE);
               AssignProp(sPrefix, false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
               AssignProp(sPrefix, false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
               /* Execute user event: Load */
               E14152 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB150( ) ;
         }
      }

      protected void send_integrity_lvl_hashes152( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ClientesGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP150( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13152 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA4IDCLIENTE"), ".", ","));
            /* Read variables values. */
            A30NOMBRECOMPLETOCLIENTE = cgiGet( edtNOMBRECOMPLETOCLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
            A31USUARIOCLIENTE = cgiGet( edtUSUARIOCLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A31USUARIOCLIENTE", A31USUARIOCLIENTE);
            A32CONTRASENACLIENTE = cgiGet( edtCONTRASENACLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A32CONTRASENACLIENTE", A32CONTRASENACLIENTE);
            A33TELEFONOCLIENTE = cgiGet( edtTELEFONOCLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A33TELEFONOCLIENTE", A33TELEFONOCLIENTE);
            A34CORREOCLIENTE = cgiGet( edtCORREOCLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A34CORREOCLIENTE", A34CORREOCLIENTE);
            A35FECHANACIMIENTOCLIENTE = context.localUtil.CToD( cgiGet( edtFECHANACIMIENTOCLIENTE_Internalname), 1);
            AssignAttri(sPrefix, false, "A35FECHANACIMIENTOCLIENTE", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
            A36DIRECCIONCLIENTE = cgiGet( edtDIRECCIONCLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A36DIRECCIONCLIENTE", A36DIRECCIONCLIENTE);
            A37FECHAREGISTROCLIENTE = context.localUtil.CToD( cgiGet( edtFECHAREGISTROCLIENTE_Internalname), 1);
            AssignAttri(sPrefix, false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
            A53FOTOCLIENTE = cgiGet( imgFOTOCLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A53FOTOCLIENTE", A53FOTOCLIENTE);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13152( )
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

      protected void E14152( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Clientes";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "IDCLIENTE";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6IDCLIENTE), 12, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "TiendaRopaProyecto"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A4IDCLIENTE = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
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
         PA152( ) ;
         WS152( ) ;
         WE152( ) ;
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
         sCtrlA4IDCLIENTE = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA152( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "clientesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA152( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A4IDCLIENTE = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
         }
         wcpOA4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA4IDCLIENTE"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A4IDCLIENTE != wcpOA4IDCLIENTE ) ) )
         {
            setjustcreated();
         }
         wcpOA4IDCLIENTE = A4IDCLIENTE;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA4IDCLIENTE = cgiGet( sPrefix+"A4IDCLIENTE_CTRL");
         if ( StringUtil.Len( sCtrlA4IDCLIENTE) > 0 )
         {
            A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( sCtrlA4IDCLIENTE), ".", ","));
            AssignAttri(sPrefix, false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
         }
         else
         {
            A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( sPrefix+"A4IDCLIENTE_PARM"), ".", ","));
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
         PA152( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS152( ) ;
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
         WS152( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A4IDCLIENTE_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA4IDCLIENTE)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A4IDCLIENTE_CTRL", StringUtil.RTrim( sCtrlA4IDCLIENTE));
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
         WE152( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113012305618", true, true);
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
         context.AddJavascriptSource("clientesgeneral.js", "?2021113012305619", false, true);
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
         edtIDCLIENTE_Internalname = sPrefix+"IDCLIENTE";
         edtNOMBRECOMPLETOCLIENTE_Internalname = sPrefix+"NOMBRECOMPLETOCLIENTE";
         edtUSUARIOCLIENTE_Internalname = sPrefix+"USUARIOCLIENTE";
         edtCONTRASENACLIENTE_Internalname = sPrefix+"CONTRASENACLIENTE";
         edtTELEFONOCLIENTE_Internalname = sPrefix+"TELEFONOCLIENTE";
         edtCORREOCLIENTE_Internalname = sPrefix+"CORREOCLIENTE";
         edtFECHANACIMIENTOCLIENTE_Internalname = sPrefix+"FECHANACIMIENTOCLIENTE";
         edtDIRECCIONCLIENTE_Internalname = sPrefix+"DIRECCIONCLIENTE";
         edtFECHAREGISTROCLIENTE_Internalname = sPrefix+"FECHAREGISTROCLIENTE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgFOTOCLIENTE_Internalname = sPrefix+"FOTOCLIENTE";
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
         edtFECHAREGISTROCLIENTE_Jsonclick = "";
         edtFECHAREGISTROCLIENTE_Enabled = 0;
         edtDIRECCIONCLIENTE_Enabled = 0;
         edtFECHANACIMIENTOCLIENTE_Jsonclick = "";
         edtFECHANACIMIENTOCLIENTE_Enabled = 0;
         edtCORREOCLIENTE_Jsonclick = "";
         edtCORREOCLIENTE_Enabled = 0;
         edtTELEFONOCLIENTE_Jsonclick = "";
         edtTELEFONOCLIENTE_Enabled = 0;
         edtCONTRASENACLIENTE_Enabled = 0;
         edtUSUARIOCLIENTE_Enabled = 0;
         edtNOMBRECOMPLETOCLIENTE_Enabled = 0;
         edtIDCLIENTE_Jsonclick = "";
         edtIDCLIENTE_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E11151',iparms:[{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E12151',iparms:[{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_IDCLIENTE","{handler:'Valid_Idcliente',iparms:[]");
         setEventMetadata("VALID_IDCLIENTE",",oparms:[]}");
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
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A30NOMBRECOMPLETOCLIENTE = "";
         A31USUARIOCLIENTE = "";
         A32CONTRASENACLIENTE = "";
         gxphoneLink = "";
         A33TELEFONOCLIENTE = "";
         A34CORREOCLIENTE = "";
         A35FECHANACIMIENTOCLIENTE = DateTime.MinValue;
         A36DIRECCIONCLIENTE = "";
         A37FECHAREGISTROCLIENTE = DateTime.MinValue;
         A53FOTOCLIENTE = "";
         A40000FOTOCLIENTE_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00152_A4IDCLIENTE = new long[1] ;
         H00152_A40000FOTOCLIENTE_GXI = new string[] {""} ;
         H00152_A37FECHAREGISTROCLIENTE = new DateTime[] {DateTime.MinValue} ;
         H00152_A36DIRECCIONCLIENTE = new string[] {""} ;
         H00152_A35FECHANACIMIENTOCLIENTE = new DateTime[] {DateTime.MinValue} ;
         H00152_A34CORREOCLIENTE = new string[] {""} ;
         H00152_A33TELEFONOCLIENTE = new string[] {""} ;
         H00152_A32CONTRASENACLIENTE = new string[] {""} ;
         H00152_A31USUARIOCLIENTE = new string[] {""} ;
         H00152_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         H00152_A53FOTOCLIENTE = new string[] {""} ;
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA4IDCLIENTE = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientesgeneral__default(),
            new Object[][] {
                new Object[] {
               H00152_A4IDCLIENTE, H00152_A40000FOTOCLIENTE_GXI, H00152_A37FECHAREGISTROCLIENTE, H00152_A36DIRECCIONCLIENTE, H00152_A35FECHANACIMIENTOCLIENTE, H00152_A34CORREOCLIENTE, H00152_A33TELEFONOCLIENTE, H00152_A32CONTRASENACLIENTE, H00152_A31USUARIOCLIENTE, H00152_A30NOMBRECOMPLETOCLIENTE,
               H00152_A53FOTOCLIENTE
               }
            }
         );
         AV13Pgmname = "ClientesGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ClientesGeneral";
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
      private int edtIDCLIENTE_Enabled ;
      private int edtNOMBRECOMPLETOCLIENTE_Enabled ;
      private int edtUSUARIOCLIENTE_Enabled ;
      private int edtCONTRASENACLIENTE_Enabled ;
      private int edtTELEFONOCLIENTE_Enabled ;
      private int edtCORREOCLIENTE_Enabled ;
      private int edtFECHANACIMIENTOCLIENTE_Enabled ;
      private int edtDIRECCIONCLIENTE_Enabled ;
      private int edtFECHAREGISTROCLIENTE_Enabled ;
      private int idxLst ;
      private long A4IDCLIENTE ;
      private long wcpOA4IDCLIENTE ;
      private long AV6IDCLIENTE ;
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
      private string edtIDCLIENTE_Internalname ;
      private string edtIDCLIENTE_Jsonclick ;
      private string edtNOMBRECOMPLETOCLIENTE_Internalname ;
      private string edtUSUARIOCLIENTE_Internalname ;
      private string edtCONTRASENACLIENTE_Internalname ;
      private string edtTELEFONOCLIENTE_Internalname ;
      private string gxphoneLink ;
      private string A33TELEFONOCLIENTE ;
      private string edtTELEFONOCLIENTE_Jsonclick ;
      private string edtCORREOCLIENTE_Internalname ;
      private string edtCORREOCLIENTE_Jsonclick ;
      private string edtFECHANACIMIENTOCLIENTE_Internalname ;
      private string edtFECHANACIMIENTOCLIENTE_Jsonclick ;
      private string edtDIRECCIONCLIENTE_Internalname ;
      private string edtFECHAREGISTROCLIENTE_Internalname ;
      private string edtFECHAREGISTROCLIENTE_Jsonclick ;
      private string divImagestable_Internalname ;
      private string sImgUrl ;
      private string imgFOTOCLIENTE_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string sCtrlA4IDCLIENTE ;
      private DateTime A35FECHANACIMIENTOCLIENTE ;
      private DateTime A37FECHAREGISTROCLIENTE ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A53FOTOCLIENTE_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A30NOMBRECOMPLETOCLIENTE ;
      private string A31USUARIOCLIENTE ;
      private string A32CONTRASENACLIENTE ;
      private string A34CORREOCLIENTE ;
      private string A36DIRECCIONCLIENTE ;
      private string A40000FOTOCLIENTE_GXI ;
      private string A53FOTOCLIENTE ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H00152_A4IDCLIENTE ;
      private string[] H00152_A40000FOTOCLIENTE_GXI ;
      private DateTime[] H00152_A37FECHAREGISTROCLIENTE ;
      private string[] H00152_A36DIRECCIONCLIENTE ;
      private DateTime[] H00152_A35FECHANACIMIENTOCLIENTE ;
      private string[] H00152_A34CORREOCLIENTE ;
      private string[] H00152_A33TELEFONOCLIENTE ;
      private string[] H00152_A32CONTRASENACLIENTE ;
      private string[] H00152_A31USUARIOCLIENTE ;
      private string[] H00152_A30NOMBRECOMPLETOCLIENTE ;
      private string[] H00152_A53FOTOCLIENTE ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class clientesgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00152;
          prmH00152 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00152", "SELECT [IDCLIENTE], [FOTOCLIENTE_GXI], [FECHAREGISTROCLIENTE], [DIRECCIONCLIENTE], [FECHANACIMIENTOCLIENTE], [CORREOCLIENTE], [TELEFONOCLIENTE], [CONTRASENACLIENTE], [USUARIOCLIENTE], [NOMBRECOMPLETOCLIENTE], [FOTOCLIENTE] FROM [Clientes] WHERE [IDCLIENTE] = @IDCLIENTE ORDER BY [IDCLIENTE] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00152,1, GxCacheFrequency.OFF ,true,true )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(2));
                return;
       }
    }

 }

}
