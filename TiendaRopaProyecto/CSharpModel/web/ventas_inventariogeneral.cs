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
   public class ventas_inventariogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public ventas_inventariogeneral( )
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

      public ventas_inventariogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_IDVENTA )
      {
         this.A12IDVENTA = aP0_IDVENTA;
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
               gxfirstwebparm = GetFirstPar( "IDVENTA");
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
                  A12IDVENTA = (long)(NumberUtil.Val( GetPar( "IDVENTA"), "."));
                  AssignAttri(sPrefix, false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A12IDVENTA});
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
                  gxfirstwebparm = GetFirstPar( "IDVENTA");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "IDVENTA");
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
            PA1N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "Ventas_inventarioGeneral";
               context.Gx_err = 0;
               /* Using cursor H001N8 */
               pr_default.execute(0, new Object[] {A12IDVENTA});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A59TOTALVENTA = H001N8_A59TOTALVENTA[0];
                  n59TOTALVENTA = H001N8_n59TOTALVENTA[0];
                  AssignAttri(sPrefix, false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
               }
               else
               {
                  A59TOTALVENTA = 0;
                  n59TOTALVENTA = false;
                  AssignAttri(sPrefix, false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
               }
               pr_default.close(0);
               /* Using cursor H001N12 */
               pr_default.execute(1, new Object[] {A12IDVENTA});
               if ( (pr_default.getStatus(1) != 101) )
               {
                  A57IMPUESTOVENTA = H001N12_A57IMPUESTOVENTA[0];
                  n57IMPUESTOVENTA = H001N12_n57IMPUESTOVENTA[0];
                  AssignAttri(sPrefix, false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
               }
               else
               {
                  A57IMPUESTOVENTA = 0;
                  n57IMPUESTOVENTA = false;
                  AssignAttri(sPrefix, false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
               }
               pr_default.close(1);
               WS1N2( ) ;
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
            context.SendWebValue( "Ventas_inventario General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021112620512575", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas_inventariogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A12IDVENTA,12,0))}, new string[] {"IDVENTA"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Ventas_inventarioGeneral");
         forbiddenHiddens.Add("IDCLIENTE", context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("IDEMPLEADO", context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ventas_inventariogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA12IDVENTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA12IDVENTA), 12, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1N2( )
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
         return "Ventas_inventarioGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ventas_inventario General" ;
      }

      protected void WB1N0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "ventas_inventariogeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e111n1_client"+"'", TempTags, "", 2, "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e121n1_client"+"'", TempTags, "", 2, "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDVENTA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDVENTA_Internalname, "IDVENTA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")), ((edtIDVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDVENTA_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDVENTA_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHAVENTA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFECHAVENTA_Internalname, "FECHAVENTA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtFECHAVENTA_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFECHAVENTA_Internalname, context.localUtil.Format(A54FECHAVENTA, "99/99/99"), context.localUtil.Format( A54FECHAVENTA, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHAVENTA_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFECHAVENTA_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_bitmap( context, edtFECHAVENTA_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHAVENTA_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas_inventarioGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONVENTA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONVENTA_Internalname, "DESCRIPCIONVENTA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONVENTA_Internalname, A55DESCRIPCIONVENTA, "", "", 0, 1, edtDESCRIPCIONVENTA_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_single_line_edit( context, edtIDCLIENTE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")), ((edtIDCLIENTE_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCLIENTE_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDCLIENTE_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Ventas_inventarioGeneral.htm");
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
            GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOCLIENTE_Internalname, A30NOMBRECOMPLETOCLIENTE, edtNOMBRECOMPLETOCLIENTE_Link, "", 0, 1, edtNOMBRECOMPLETOCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIMPUESTOVENTA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIMPUESTOVENTA_Internalname, "IMPUESTOVENTA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIMPUESTOVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( A57IMPUESTOVENTA, 12, 2, ".", "")), ((edtIMPUESTOVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A57IMPUESTOVENTA, "ZZZZZZZZ9.99")) : context.localUtil.Format( A57IMPUESTOVENTA, "ZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIMPUESTOVENTA_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIMPUESTOVENTA_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCUENTOVENTA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCUENTOVENTA_Internalname, "DESCUENTOVENTA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDESCUENTOVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( A58DESCUENTOVENTA, 12, 2, ".", "")), ((edtDESCUENTOVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99")) : context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDESCUENTOVENTA_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtDESCUENTOVENTA_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTOTALVENTA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTOTALVENTA_Internalname, "TOTALVENTA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTOTALVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( A59TOTALVENTA, 12, 2, ".", "")), ((edtTOTALVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A59TOTALVENTA, "ZZZZZZZZ9.99")) : context.localUtil.Format( A59TOTALVENTA, "ZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTOTALVENTA_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTOTALVENTA_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_single_line_edit( context, edtIDEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")), ((edtIDEMPLEADO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDEMPLEADO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Ventas_inventarioGeneral.htm");
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
            GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, A23NOMBRECOMPLETOEMPLEADO, edtNOMBRECOMPLETOEMPLEADO_Link, "", 0, 1, edtNOMBRECOMPLETOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Ventas_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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

      protected void START1N2( )
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
               Form.Meta.addItem("description", "Ventas_inventario General", 0) ;
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
               STRUP1N0( ) ;
            }
         }
      }

      protected void WS1N2( )
      {
         START1N2( ) ;
         EVT1N2( ) ;
      }

      protected void EVT1N2( )
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
                                 STRUP1N0( ) ;
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
                                 STRUP1N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E131N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E141N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1N0( ) ;
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
                                 STRUP1N0( ) ;
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

      protected void WE1N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1N2( ) ;
            }
         }
      }

      protected void PA1N2( )
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
         RF1N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "Ventas_inventarioGeneral";
         context.Gx_err = 0;
      }

      protected void RF1N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H001N22 */
            pr_default.execute(2, new Object[] {A12IDVENTA});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A23NOMBRECOMPLETOEMPLEADO = H001N22_A23NOMBRECOMPLETOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
               A1IDEMPLEADO = H001N22_A1IDEMPLEADO[0];
               AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               A58DESCUENTOVENTA = H001N22_A58DESCUENTOVENTA[0];
               AssignAttri(sPrefix, false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
               A30NOMBRECOMPLETOCLIENTE = H001N22_A30NOMBRECOMPLETOCLIENTE[0];
               AssignAttri(sPrefix, false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
               A4IDCLIENTE = H001N22_A4IDCLIENTE[0];
               AssignAttri(sPrefix, false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
               A55DESCRIPCIONVENTA = H001N22_A55DESCRIPCIONVENTA[0];
               AssignAttri(sPrefix, false, "A55DESCRIPCIONVENTA", A55DESCRIPCIONVENTA);
               A54FECHAVENTA = H001N22_A54FECHAVENTA[0];
               AssignAttri(sPrefix, false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
               A59TOTALVENTA = H001N22_A59TOTALVENTA[0];
               n59TOTALVENTA = H001N22_n59TOTALVENTA[0];
               AssignAttri(sPrefix, false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
               A57IMPUESTOVENTA = H001N22_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = H001N22_n57IMPUESTOVENTA[0];
               AssignAttri(sPrefix, false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
               A23NOMBRECOMPLETOEMPLEADO = H001N22_A23NOMBRECOMPLETOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
               A30NOMBRECOMPLETOCLIENTE = H001N22_A30NOMBRECOMPLETOCLIENTE[0];
               AssignAttri(sPrefix, false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
               A59TOTALVENTA = H001N22_A59TOTALVENTA[0];
               n59TOTALVENTA = H001N22_n59TOTALVENTA[0];
               AssignAttri(sPrefix, false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
               A57IMPUESTOVENTA = H001N22_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = H001N22_n57IMPUESTOVENTA[0];
               AssignAttri(sPrefix, false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
               /* Execute user event: Load */
               E141N2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            WB1N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1N2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "Ventas_inventarioGeneral";
         context.Gx_err = 0;
         /* Using cursor H001N29 */
         pr_default.execute(3, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A59TOTALVENTA = H001N29_A59TOTALVENTA[0];
            n59TOTALVENTA = H001N29_n59TOTALVENTA[0];
            AssignAttri(sPrefix, false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri(sPrefix, false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         pr_default.close(3);
         /* Using cursor H001N33 */
         pr_default.execute(4, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A57IMPUESTOVENTA = H001N33_A57IMPUESTOVENTA[0];
            n57IMPUESTOVENTA = H001N33_n57IMPUESTOVENTA[0];
            AssignAttri(sPrefix, false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         else
         {
            A57IMPUESTOVENTA = 0;
            n57IMPUESTOVENTA = false;
            AssignAttri(sPrefix, false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         pr_default.close(4);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E131N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA12IDVENTA = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12IDVENTA"), ".", ","));
            /* Read variables values. */
            A54FECHAVENTA = context.localUtil.CToD( cgiGet( edtFECHAVENTA_Internalname), 1);
            AssignAttri(sPrefix, false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
            A55DESCRIPCIONVENTA = cgiGet( edtDESCRIPCIONVENTA_Internalname);
            AssignAttri(sPrefix, false, "A55DESCRIPCIONVENTA", A55DESCRIPCIONVENTA);
            A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
            A30NOMBRECOMPLETOCLIENTE = cgiGet( edtNOMBRECOMPLETOCLIENTE_Internalname);
            AssignAttri(sPrefix, false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
            A57IMPUESTOVENTA = context.localUtil.CToN( cgiGet( edtIMPUESTOVENTA_Internalname), ".", ",");
            n57IMPUESTOVENTA = false;
            AssignAttri(sPrefix, false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
            A58DESCUENTOVENTA = context.localUtil.CToN( cgiGet( edtDESCUENTOVENTA_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
            A59TOTALVENTA = context.localUtil.CToN( cgiGet( edtTOTALVENTA_Internalname), ".", ",");
            n59TOTALVENTA = false;
            AssignAttri(sPrefix, false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
            A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            A23NOMBRECOMPLETOEMPLEADO = cgiGet( edtNOMBRECOMPLETOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Ventas_inventarioGeneral");
            A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
            forbiddenHiddens.Add("IDCLIENTE", context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"));
            A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            forbiddenHiddens.Add("IDEMPLEADO", context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("ventas_inventariogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E131N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E131N2( )
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

      protected void E141N2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtNOMBRECOMPLETOCLIENTE_Link = formatLink("viewclientes.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A4IDCLIENTE,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDCLIENTE","TabCode"}) ;
         AssignProp(sPrefix, false, edtNOMBRECOMPLETOCLIENTE_Internalname, "Link", edtNOMBRECOMPLETOCLIENTE_Link, true);
         edtNOMBRECOMPLETOEMPLEADO_Link = formatLink("viewempleados.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1IDEMPLEADO,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDEMPLEADO","TabCode"}) ;
         AssignProp(sPrefix, false, edtNOMBRECOMPLETOEMPLEADO_Internalname, "Link", edtNOMBRECOMPLETOEMPLEADO_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Ventas_inventario";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "IDVENTA";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6IDVENTA), 12, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "TiendaRopaProyecto"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A12IDVENTA = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
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
         PA1N2( ) ;
         WS1N2( ) ;
         WE1N2( ) ;
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
         sCtrlA12IDVENTA = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "ventas_inventariogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A12IDVENTA = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
         }
         wcpOA12IDVENTA = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA12IDVENTA"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A12IDVENTA != wcpOA12IDVENTA ) ) )
         {
            setjustcreated();
         }
         wcpOA12IDVENTA = A12IDVENTA;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA12IDVENTA = cgiGet( sPrefix+"A12IDVENTA_CTRL");
         if ( StringUtil.Len( sCtrlA12IDVENTA) > 0 )
         {
            A12IDVENTA = (long)(context.localUtil.CToN( cgiGet( sCtrlA12IDVENTA), ".", ","));
            AssignAttri(sPrefix, false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
         }
         else
         {
            A12IDVENTA = (long)(context.localUtil.CToN( cgiGet( sPrefix+"A12IDVENTA_PARM"), ".", ","));
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
         PA1N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1N2( ) ;
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
         WS1N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A12IDVENTA_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA12IDVENTA)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A12IDVENTA_CTRL", StringUtil.RTrim( sCtrlA12IDVENTA));
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
         WE1N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021112620512624", true, true);
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
         context.AddJavascriptSource("ventas_inventariogeneral.js", "?2021112620512624", false, true);
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
         edtIDVENTA_Internalname = sPrefix+"IDVENTA";
         edtFECHAVENTA_Internalname = sPrefix+"FECHAVENTA";
         edtDESCRIPCIONVENTA_Internalname = sPrefix+"DESCRIPCIONVENTA";
         edtIDCLIENTE_Internalname = sPrefix+"IDCLIENTE";
         edtNOMBRECOMPLETOCLIENTE_Internalname = sPrefix+"NOMBRECOMPLETOCLIENTE";
         edtIMPUESTOVENTA_Internalname = sPrefix+"IMPUESTOVENTA";
         edtDESCUENTOVENTA_Internalname = sPrefix+"DESCUENTOVENTA";
         edtTOTALVENTA_Internalname = sPrefix+"TOTALVENTA";
         edtIDEMPLEADO_Internalname = sPrefix+"IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = sPrefix+"NOMBRECOMPLETOEMPLEADO";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
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
         edtNOMBRECOMPLETOEMPLEADO_Link = "";
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         edtIDEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Enabled = 0;
         edtTOTALVENTA_Jsonclick = "";
         edtTOTALVENTA_Enabled = 0;
         edtDESCUENTOVENTA_Jsonclick = "";
         edtDESCUENTOVENTA_Enabled = 0;
         edtIMPUESTOVENTA_Jsonclick = "";
         edtIMPUESTOVENTA_Enabled = 0;
         edtNOMBRECOMPLETOCLIENTE_Link = "";
         edtNOMBRECOMPLETOCLIENTE_Enabled = 0;
         edtIDCLIENTE_Jsonclick = "";
         edtIDCLIENTE_Enabled = 0;
         edtDESCRIPCIONVENTA_Enabled = 0;
         edtFECHAVENTA_Jsonclick = "";
         edtFECHAVENTA_Enabled = 0;
         edtIDVENTA_Jsonclick = "";
         edtIDVENTA_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9'},{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E111N1',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E121N1',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_IDVENTA","{handler:'Valid_Idventa',iparms:[]");
         setEventMetadata("VALID_IDVENTA",",oparms:[]}");
         setEventMetadata("VALID_IDCLIENTE","{handler:'Valid_Idcliente',iparms:[]");
         setEventMetadata("VALID_IDCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_IDEMPLEADO","{handler:'Valid_Idempleado',iparms:[]");
         setEventMetadata("VALID_IDEMPLEADO",",oparms:[]}");
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
         scmdbuf = "";
         H001N8_A59TOTALVENTA = new decimal[1] ;
         H001N8_n59TOTALVENTA = new bool[] {false} ;
         H001N12_A57IMPUESTOVENTA = new decimal[1] ;
         H001N12_n57IMPUESTOVENTA = new bool[] {false} ;
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
         A54FECHAVENTA = DateTime.MinValue;
         A55DESCRIPCIONVENTA = "";
         A30NOMBRECOMPLETOCLIENTE = "";
         A23NOMBRECOMPLETOEMPLEADO = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H001N22_A12IDVENTA = new long[1] ;
         H001N22_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         H001N22_A1IDEMPLEADO = new long[1] ;
         H001N22_A58DESCUENTOVENTA = new decimal[1] ;
         H001N22_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         H001N22_A4IDCLIENTE = new long[1] ;
         H001N22_A55DESCRIPCIONVENTA = new string[] {""} ;
         H001N22_A54FECHAVENTA = new DateTime[] {DateTime.MinValue} ;
         H001N22_A59TOTALVENTA = new decimal[1] ;
         H001N22_n59TOTALVENTA = new bool[] {false} ;
         H001N22_A57IMPUESTOVENTA = new decimal[1] ;
         H001N22_n57IMPUESTOVENTA = new bool[] {false} ;
         H001N29_A59TOTALVENTA = new decimal[1] ;
         H001N29_n59TOTALVENTA = new bool[] {false} ;
         H001N33_A57IMPUESTOVENTA = new decimal[1] ;
         H001N33_n57IMPUESTOVENTA = new bool[] {false} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA12IDVENTA = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas_inventariogeneral__default(),
            new Object[][] {
                new Object[] {
               H001N8_A59TOTALVENTA, H001N8_n59TOTALVENTA
               }
               , new Object[] {
               H001N12_A57IMPUESTOVENTA, H001N12_n57IMPUESTOVENTA
               }
               , new Object[] {
               H001N22_A12IDVENTA, H001N22_A23NOMBRECOMPLETOEMPLEADO, H001N22_A1IDEMPLEADO, H001N22_A58DESCUENTOVENTA, H001N22_A30NOMBRECOMPLETOCLIENTE, H001N22_A4IDCLIENTE, H001N22_A55DESCRIPCIONVENTA, H001N22_A54FECHAVENTA, H001N22_A59TOTALVENTA, H001N22_n59TOTALVENTA,
               H001N22_A57IMPUESTOVENTA, H001N22_n57IMPUESTOVENTA
               }
               , new Object[] {
               H001N29_A59TOTALVENTA, H001N29_n59TOTALVENTA
               }
               , new Object[] {
               H001N33_A57IMPUESTOVENTA, H001N33_n57IMPUESTOVENTA
               }
            }
         );
         AV13Pgmname = "Ventas_inventarioGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "Ventas_inventarioGeneral";
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
      private int edtIDVENTA_Enabled ;
      private int edtFECHAVENTA_Enabled ;
      private int edtDESCRIPCIONVENTA_Enabled ;
      private int edtIDCLIENTE_Enabled ;
      private int edtNOMBRECOMPLETOCLIENTE_Enabled ;
      private int edtIMPUESTOVENTA_Enabled ;
      private int edtDESCUENTOVENTA_Enabled ;
      private int edtTOTALVENTA_Enabled ;
      private int edtIDEMPLEADO_Enabled ;
      private int edtNOMBRECOMPLETOEMPLEADO_Enabled ;
      private int idxLst ;
      private long A12IDVENTA ;
      private long wcpOA12IDVENTA ;
      private long A4IDCLIENTE ;
      private long A1IDEMPLEADO ;
      private long AV6IDVENTA ;
      private decimal A59TOTALVENTA ;
      private decimal A57IMPUESTOVENTA ;
      private decimal A58DESCUENTOVENTA ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string scmdbuf ;
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
      private string edtIDVENTA_Internalname ;
      private string edtIDVENTA_Jsonclick ;
      private string edtFECHAVENTA_Internalname ;
      private string edtFECHAVENTA_Jsonclick ;
      private string edtDESCRIPCIONVENTA_Internalname ;
      private string edtIDCLIENTE_Internalname ;
      private string edtIDCLIENTE_Jsonclick ;
      private string edtNOMBRECOMPLETOCLIENTE_Internalname ;
      private string edtNOMBRECOMPLETOCLIENTE_Link ;
      private string edtIMPUESTOVENTA_Internalname ;
      private string edtIMPUESTOVENTA_Jsonclick ;
      private string edtDESCUENTOVENTA_Internalname ;
      private string edtDESCUENTOVENTA_Jsonclick ;
      private string edtTOTALVENTA_Internalname ;
      private string edtTOTALVENTA_Jsonclick ;
      private string edtIDEMPLEADO_Internalname ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string edtNOMBRECOMPLETOEMPLEADO_Internalname ;
      private string edtNOMBRECOMPLETOEMPLEADO_Link ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA12IDVENTA ;
      private DateTime A54FECHAVENTA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n59TOTALVENTA ;
      private bool n57IMPUESTOVENTA ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A55DESCRIPCIONVENTA ;
      private string A30NOMBRECOMPLETOCLIENTE ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H001N8_A59TOTALVENTA ;
      private bool[] H001N8_n59TOTALVENTA ;
      private decimal[] H001N12_A57IMPUESTOVENTA ;
      private bool[] H001N12_n57IMPUESTOVENTA ;
      private long[] H001N22_A12IDVENTA ;
      private string[] H001N22_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] H001N22_A1IDEMPLEADO ;
      private decimal[] H001N22_A58DESCUENTOVENTA ;
      private string[] H001N22_A30NOMBRECOMPLETOCLIENTE ;
      private long[] H001N22_A4IDCLIENTE ;
      private string[] H001N22_A55DESCRIPCIONVENTA ;
      private DateTime[] H001N22_A54FECHAVENTA ;
      private decimal[] H001N22_A59TOTALVENTA ;
      private bool[] H001N22_n59TOTALVENTA ;
      private decimal[] H001N22_A57IMPUESTOVENTA ;
      private bool[] H001N22_n57IMPUESTOVENTA ;
      private decimal[] H001N29_A59TOTALVENTA ;
      private bool[] H001N29_n59TOTALVENTA ;
      private decimal[] H001N33_A57IMPUESTOVENTA ;
      private bool[] H001N33_n57IMPUESTOVENTA ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class ventas_inventariogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001N8;
          prmH001N8 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmH001N12;
          prmH001N12 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmH001N22;
          prmH001N22 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          string cmdBufferH001N22;
          cmdBufferH001N22=" SELECT T1.[IDVENTA], T2.[NOMBRECOMPLETOEMPLEADO], T1.[IDEMPLEADO], T1.[DESCUENTOVENTA], T3.[NOMBRECOMPLETOCLIENTE], T1.[IDCLIENTE], T1.[DESCRIPCIONVENTA], T1.[FECHAVENTA], COALESCE( T4.[TOTALVENTA], 0) AS TOTALVENTA, COALESCE( T5.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA FROM (((([Ventas_inventario] T1 INNER JOIN [Empleados] T2 ON T2.[IDEMPLEADO] = T1.[IDEMPLEADO]) INNER JOIN [Clientes] T3 ON T3.[IDCLIENTE] = T1.[IDCLIENTE]) INNER JOIN (SELECT COALESCE( T8.[GXC3], 0) + COALESCE( T7.[IMPUESTOVENTA], 0) - T6.[DESCUENTOVENTA] AS TOTALVENTA, T6.[IDVENTA] FROM (([Ventas_inventario] T6 LEFT JOIN (SELECT COALESCE( T10.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T9.[IDVENTA] FROM ([Ventas_inventario] T9 LEFT JOIN (SELECT SUM(COALESCE( T12.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T11.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T11 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T12 ON T12.[IDPRODUCTO] = T11.[IDPRODUCTO]) GROUP BY T11.[IDVENTA] ) T10 ON T10.[IDVENTA] = T9.[IDVENTA]) ) T7 ON T7.[IDVENTA] = T6.[IDVENTA]) LEFT JOIN (SELECT SUM(COALESCE( T10.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T9.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T9 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T10 ON T10.[IDPRODUCTO] = T9.[IDPRODUCTO]) GROUP BY T9.[IDVENTA] ) T8 ON T8.[IDVENTA] = T6.[IDVENTA]) ) T4 ON T4.[IDVENTA] = T1.[IDVENTA]) LEFT JOIN (SELECT COALESCE( T7.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T6.[IDVENTA] FROM ([Ventas_inventario] T6 LEFT JOIN (SELECT SUM(COALESCE( T9.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T8.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T8 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM "
          + " [Inventario] ) T9 ON T9.[IDPRODUCTO] = T8.[IDPRODUCTO]) GROUP BY T8.[IDVENTA] ) T7 ON T7.[IDVENTA] = T6.[IDVENTA]) ) T5 ON T5.[IDVENTA] = T1.[IDVENTA]) WHERE T1.[IDVENTA] = @IDVENTA ORDER BY T1.[IDVENTA]" ;
          Object[] prmH001N29;
          prmH001N29 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmH001N33;
          prmH001N33 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001N8", "SELECT COALESCE( T1.[TOTALVENTA], 0) AS TOTALVENTA FROM (SELECT COALESCE( T4.[GXC3], 0) + COALESCE( T3.[IMPUESTOVENTA], 0) - T2.[DESCUENTOVENTA] AS TOTALVENTA, T2.[IDVENTA] FROM (([Ventas_inventario] T2 LEFT JOIN (SELECT COALESCE( T6.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T5.[IDVENTA] FROM ([Ventas_inventario] T5 LEFT JOIN (SELECT SUM(COALESCE( T8.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T7.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T7 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T8 ON T8.[IDPRODUCTO] = T7.[IDPRODUCTO]) GROUP BY T7.[IDVENTA] ) T6 ON T6.[IDVENTA] = T5.[IDVENTA]) ) T3 ON T3.[IDVENTA] = T2.[IDVENTA]) LEFT JOIN (SELECT SUM(COALESCE( T6.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T5.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T5 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T6 ON T6.[IDPRODUCTO] = T5.[IDPRODUCTO]) GROUP BY T5.[IDVENTA] ) T4 ON T4.[IDVENTA] = T2.[IDVENTA]) ) T1 WHERE T1.[IDVENTA] = @IDVENTA ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001N12", "SELECT COALESCE( T1.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA FROM (SELECT COALESCE( T3.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T2.[IDVENTA] FROM ([Ventas_inventario] T2 LEFT JOIN (SELECT SUM(COALESCE( T5.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T4.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T4 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T5 ON T5.[IDPRODUCTO] = T4.[IDPRODUCTO]) GROUP BY T4.[IDVENTA] ) T3 ON T3.[IDVENTA] = T2.[IDVENTA]) ) T1 WHERE T1.[IDVENTA] = @IDVENTA ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001N22", cmdBufferH001N22,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001N29", "SELECT COALESCE( T1.[TOTALVENTA], 0) AS TOTALVENTA FROM (SELECT COALESCE( T4.[GXC3], 0) + COALESCE( T3.[IMPUESTOVENTA], 0) - T2.[DESCUENTOVENTA] AS TOTALVENTA, T2.[IDVENTA] FROM (([Ventas_inventario] T2 LEFT JOIN (SELECT COALESCE( T6.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T5.[IDVENTA] FROM ([Ventas_inventario] T5 LEFT JOIN (SELECT SUM(COALESCE( T8.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T7.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T7 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T8 ON T8.[IDPRODUCTO] = T7.[IDPRODUCTO]) GROUP BY T7.[IDVENTA] ) T6 ON T6.[IDVENTA] = T5.[IDVENTA]) ) T3 ON T3.[IDVENTA] = T2.[IDVENTA]) LEFT JOIN (SELECT SUM(COALESCE( T6.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T5.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T5 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T6 ON T6.[IDPRODUCTO] = T5.[IDPRODUCTO]) GROUP BY T5.[IDVENTA] ) T4 ON T4.[IDVENTA] = T2.[IDVENTA]) ) T1 WHERE T1.[IDVENTA] = @IDVENTA ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001N33", "SELECT COALESCE( T1.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA FROM (SELECT COALESCE( T3.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T2.[IDVENTA] FROM ([Ventas_inventario] T2 LEFT JOIN (SELECT SUM(COALESCE( T5.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T4.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T4 INNER JOIN (SELECT COALESCE( [GXC5], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T5 ON T5.[IDPRODUCTO] = T4.[IDPRODUCTO]) GROUP BY T4.[IDVENTA] ) T3 ON T3.[IDVENTA] = T2.[IDVENTA]) ) T1 WHERE T1.[IDVENTA] = @IDVENTA ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001N33,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
