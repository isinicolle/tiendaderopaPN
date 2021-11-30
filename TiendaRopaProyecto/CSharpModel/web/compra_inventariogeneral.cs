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
   public class compra_inventariogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public compra_inventariogeneral( )
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

      public compra_inventariogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_IDCOMPRA )
      {
         this.A11IDCOMPRA = aP0_IDCOMPRA;
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
               gxfirstwebparm = GetFirstPar( "IDCOMPRA");
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
                  A11IDCOMPRA = (long)(NumberUtil.Val( GetPar( "IDCOMPRA"), "."));
                  AssignAttri(sPrefix, false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A11IDCOMPRA});
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
                  gxfirstwebparm = GetFirstPar( "IDCOMPRA");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "IDCOMPRA");
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
            PA2O2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "Compra_inventarioGeneral";
               context.Gx_err = 0;
               /* Using cursor H002O5 */
               pr_default.execute(0, new Object[] {A11IDCOMPRA});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A61TOTALCOMPRAPRODUCTO = H002O5_A61TOTALCOMPRAPRODUCTO[0];
                  n61TOTALCOMPRAPRODUCTO = H002O5_n61TOTALCOMPRAPRODUCTO[0];
                  AssignAttri(sPrefix, false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               }
               else
               {
                  A61TOTALCOMPRAPRODUCTO = 0;
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri(sPrefix, false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               }
               pr_default.close(0);
               WS2O2( ) ;
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
            context.SendWebValue( "Compra_inventario General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021113013582524", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("compra_inventariogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A11IDCOMPRA,12,0))}, new string[] {"IDCOMPRA"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Compra_inventarioGeneral");
         forbiddenHiddens.Add("IDPROVEEDOR", context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("IDEMPLEADO", context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("compra_inventariogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA11IDCOMPRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA11IDCOMPRA), 12, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2O2( )
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
         return "Compra_inventarioGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Compra_inventario General" ;
      }

      protected void WB2O0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "compra_inventariogeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e112o1_client"+"'", TempTags, "", 2, "HLP_Compra_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e122o1_client"+"'", TempTags, "", 2, "HLP_Compra_inventarioGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDCOMPRA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDCOMPRA_Internalname, "IDCOMPRA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDCOMPRA_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")), ((edtIDCOMPRA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCOMPRA_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDCOMPRA_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Compra_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHACOMPRA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFECHACOMPRA_Internalname, "FECHACOMPRA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtFECHACOMPRA_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFECHACOMPRA_Internalname, context.localUtil.Format(A50FECHACOMPRA, "99/99/99"), context.localUtil.Format( A50FECHACOMPRA, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHACOMPRA_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFECHACOMPRA_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Compra_inventarioGeneral.htm");
            GxWebStd.gx_bitmap( context, edtFECHACOMPRA_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHACOMPRA_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Compra_inventarioGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONCOMPRA_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONCOMPRA_Internalname, "DESCRIPCIONCOMPRA", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONCOMPRA_Internalname, A51DESCRIPCIONCOMPRA, "", "", 0, 1, edtDESCRIPCIONCOMPRA_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Compra_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDPROVEEDOR_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDPROVEEDOR_Internalname, "IDPROVEEDOR", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDPROVEEDOR_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10IDPROVEEDOR), 12, 0, ".", "")), ((edtIDPROVEEDOR_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDPROVEEDOR_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDPROVEEDOR_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Compra_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNOMBREPROVEEDOR_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNOMBREPROVEEDOR_Internalname, "NOMBREPROVEEDOR", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtNOMBREPROVEEDOR_Internalname, A46NOMBREPROVEEDOR, edtNOMBREPROVEEDOR_Link, "", 0, 1, edtNOMBREPROVEEDOR_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Compra_inventarioGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtIDEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")), ((edtIDEMPLEADO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDEMPLEADO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDEMPLEADO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Compra_inventarioGeneral.htm");
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
            GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, A23NOMBRECOMPLETOEMPLEADO, edtNOMBRECOMPLETOEMPLEADO_Link, "", 0, 1, edtNOMBRECOMPLETOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Compra_inventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTOTALCOMPRAPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTOTALCOMPRAPRODUCTO_Internalname, "TOTALCOMPRAPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTOTALCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A61TOTALCOMPRAPRODUCTO, 12, 2, ".", "")), ((edtTOTALCOMPRAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A61TOTALCOMPRAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A61TOTALCOMPRAPRODUCTO, "ZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTOTALCOMPRAPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtTOTALCOMPRAPRODUCTO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Compra_inventarioGeneral.htm");
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

      protected void START2O2( )
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
               Form.Meta.addItem("description", "Compra_inventario General", 0) ;
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
               STRUP2O0( ) ;
            }
         }
      }

      protected void WS2O2( )
      {
         START2O2( ) ;
         EVT2O2( ) ;
      }

      protected void EVT2O2( )
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
                                 STRUP2O0( ) ;
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
                                 STRUP2O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E132O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2O0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E142O2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2O0( ) ;
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
                                 STRUP2O0( ) ;
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

      protected void WE2O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2O2( ) ;
            }
         }
      }

      protected void PA2O2( )
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
         RF2O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "Compra_inventarioGeneral";
         context.Gx_err = 0;
      }

      protected void RF2O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H002O9 */
            pr_default.execute(1, new Object[] {A11IDCOMPRA});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A23NOMBRECOMPLETOEMPLEADO = H002O9_A23NOMBRECOMPLETOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
               A1IDEMPLEADO = H002O9_A1IDEMPLEADO[0];
               AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               A46NOMBREPROVEEDOR = H002O9_A46NOMBREPROVEEDOR[0];
               AssignAttri(sPrefix, false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
               A10IDPROVEEDOR = H002O9_A10IDPROVEEDOR[0];
               AssignAttri(sPrefix, false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
               A51DESCRIPCIONCOMPRA = H002O9_A51DESCRIPCIONCOMPRA[0];
               AssignAttri(sPrefix, false, "A51DESCRIPCIONCOMPRA", A51DESCRIPCIONCOMPRA);
               A50FECHACOMPRA = H002O9_A50FECHACOMPRA[0];
               AssignAttri(sPrefix, false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
               A61TOTALCOMPRAPRODUCTO = H002O9_A61TOTALCOMPRAPRODUCTO[0];
               n61TOTALCOMPRAPRODUCTO = H002O9_n61TOTALCOMPRAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               A23NOMBRECOMPLETOEMPLEADO = H002O9_A23NOMBRECOMPLETOEMPLEADO[0];
               AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
               A46NOMBREPROVEEDOR = H002O9_A46NOMBREPROVEEDOR[0];
               AssignAttri(sPrefix, false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
               A61TOTALCOMPRAPRODUCTO = H002O9_A61TOTALCOMPRAPRODUCTO[0];
               n61TOTALCOMPRAPRODUCTO = H002O9_n61TOTALCOMPRAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               /* Execute user event: Load */
               E142O2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB2O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2O2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "Compra_inventarioGeneral";
         context.Gx_err = 0;
         /* Using cursor H002O13 */
         pr_default.execute(2, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A61TOTALCOMPRAPRODUCTO = H002O13_A61TOTALCOMPRAPRODUCTO[0];
            n61TOTALCOMPRAPRODUCTO = H002O13_n61TOTALCOMPRAPRODUCTO[0];
            AssignAttri(sPrefix, false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         else
         {
            A61TOTALCOMPRAPRODUCTO = 0;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri(sPrefix, false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         pr_default.close(2);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E132O2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA11IDCOMPRA"), ".", ","));
            /* Read variables values. */
            A50FECHACOMPRA = context.localUtil.CToD( cgiGet( edtFECHACOMPRA_Internalname), 1);
            AssignAttri(sPrefix, false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
            A51DESCRIPCIONCOMPRA = cgiGet( edtDESCRIPCIONCOMPRA_Internalname);
            AssignAttri(sPrefix, false, "A51DESCRIPCIONCOMPRA", A51DESCRIPCIONCOMPRA);
            A10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
            A46NOMBREPROVEEDOR = cgiGet( edtNOMBREPROVEEDOR_Internalname);
            AssignAttri(sPrefix, false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
            A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            A23NOMBRECOMPLETOEMPLEADO = cgiGet( edtNOMBRECOMPLETOEMPLEADO_Internalname);
            AssignAttri(sPrefix, false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            A61TOTALCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtTOTALCOMPRAPRODUCTO_Internalname), ".", ",");
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri(sPrefix, false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Compra_inventarioGeneral");
            A10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
            forbiddenHiddens.Add("IDPROVEEDOR", context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9"));
            A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            forbiddenHiddens.Add("IDEMPLEADO", context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("compra_inventariogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E132O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E132O2( )
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

      protected void E142O2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtNOMBREPROVEEDOR_Link = formatLink("viewproveedores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A10IDPROVEEDOR,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDPROVEEDOR","TabCode"}) ;
         AssignProp(sPrefix, false, edtNOMBREPROVEEDOR_Internalname, "Link", edtNOMBREPROVEEDOR_Link, true);
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
         AV7TrnContext.gxTpr_Transactionname = "Compra_inventario";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "IDCOMPRA";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6IDCOMPRA), 12, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "TiendaRopaProyecto"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A11IDCOMPRA = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
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
         PA2O2( ) ;
         WS2O2( ) ;
         WE2O2( ) ;
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
         sCtrlA11IDCOMPRA = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2O2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "compra_inventariogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2O2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A11IDCOMPRA = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
         }
         wcpOA11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA11IDCOMPRA"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A11IDCOMPRA != wcpOA11IDCOMPRA ) ) )
         {
            setjustcreated();
         }
         wcpOA11IDCOMPRA = A11IDCOMPRA;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA11IDCOMPRA = cgiGet( sPrefix+"A11IDCOMPRA_CTRL");
         if ( StringUtil.Len( sCtrlA11IDCOMPRA) > 0 )
         {
            A11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( sCtrlA11IDCOMPRA), ".", ","));
            AssignAttri(sPrefix, false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
         }
         else
         {
            A11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( sPrefix+"A11IDCOMPRA_PARM"), ".", ","));
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
         PA2O2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2O2( ) ;
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
         WS2O2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A11IDCOMPRA_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA11IDCOMPRA)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A11IDCOMPRA_CTRL", StringUtil.RTrim( sCtrlA11IDCOMPRA));
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
         WE2O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113013582563", true, true);
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
         context.AddJavascriptSource("compra_inventariogeneral.js", "?2021113013582563", false, true);
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
         edtIDCOMPRA_Internalname = sPrefix+"IDCOMPRA";
         edtFECHACOMPRA_Internalname = sPrefix+"FECHACOMPRA";
         edtDESCRIPCIONCOMPRA_Internalname = sPrefix+"DESCRIPCIONCOMPRA";
         edtIDPROVEEDOR_Internalname = sPrefix+"IDPROVEEDOR";
         edtNOMBREPROVEEDOR_Internalname = sPrefix+"NOMBREPROVEEDOR";
         edtIDEMPLEADO_Internalname = sPrefix+"IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = sPrefix+"NOMBRECOMPLETOEMPLEADO";
         edtTOTALCOMPRAPRODUCTO_Internalname = sPrefix+"TOTALCOMPRAPRODUCTO";
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
         edtTOTALCOMPRAPRODUCTO_Jsonclick = "";
         edtTOTALCOMPRAPRODUCTO_Enabled = 0;
         edtNOMBRECOMPLETOEMPLEADO_Link = "";
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         edtIDEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Enabled = 0;
         edtNOMBREPROVEEDOR_Link = "";
         edtNOMBREPROVEEDOR_Enabled = 0;
         edtIDPROVEEDOR_Jsonclick = "";
         edtIDPROVEEDOR_Enabled = 0;
         edtDESCRIPCIONCOMPRA_Enabled = 0;
         edtFECHACOMPRA_Jsonclick = "";
         edtFECHACOMPRA_Enabled = 0;
         edtIDCOMPRA_Jsonclick = "";
         edtIDCOMPRA_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A11IDCOMPRA',fld:'IDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'A10IDPROVEEDOR',fld:'IDPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E112O1',iparms:[{av:'A11IDCOMPRA',fld:'IDCOMPRA',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E122O1',iparms:[{av:'A11IDCOMPRA',fld:'IDCOMPRA',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_IDCOMPRA","{handler:'Valid_Idcompra',iparms:[]");
         setEventMetadata("VALID_IDCOMPRA",",oparms:[]}");
         setEventMetadata("VALID_IDPROVEEDOR","{handler:'Valid_Idproveedor',iparms:[]");
         setEventMetadata("VALID_IDPROVEEDOR",",oparms:[]}");
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
         H002O5_A61TOTALCOMPRAPRODUCTO = new decimal[1] ;
         H002O5_n61TOTALCOMPRAPRODUCTO = new bool[] {false} ;
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
         A50FECHACOMPRA = DateTime.MinValue;
         A51DESCRIPCIONCOMPRA = "";
         A46NOMBREPROVEEDOR = "";
         A23NOMBRECOMPLETOEMPLEADO = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H002O9_A11IDCOMPRA = new long[1] ;
         H002O9_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         H002O9_A1IDEMPLEADO = new long[1] ;
         H002O9_A46NOMBREPROVEEDOR = new string[] {""} ;
         H002O9_A10IDPROVEEDOR = new long[1] ;
         H002O9_A51DESCRIPCIONCOMPRA = new string[] {""} ;
         H002O9_A50FECHACOMPRA = new DateTime[] {DateTime.MinValue} ;
         H002O9_A61TOTALCOMPRAPRODUCTO = new decimal[1] ;
         H002O9_n61TOTALCOMPRAPRODUCTO = new bool[] {false} ;
         H002O13_A61TOTALCOMPRAPRODUCTO = new decimal[1] ;
         H002O13_n61TOTALCOMPRAPRODUCTO = new bool[] {false} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA11IDCOMPRA = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compra_inventariogeneral__default(),
            new Object[][] {
                new Object[] {
               H002O5_A61TOTALCOMPRAPRODUCTO, H002O5_n61TOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               H002O9_A11IDCOMPRA, H002O9_A23NOMBRECOMPLETOEMPLEADO, H002O9_A1IDEMPLEADO, H002O9_A46NOMBREPROVEEDOR, H002O9_A10IDPROVEEDOR, H002O9_A51DESCRIPCIONCOMPRA, H002O9_A50FECHACOMPRA, H002O9_A61TOTALCOMPRAPRODUCTO, H002O9_n61TOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               H002O13_A61TOTALCOMPRAPRODUCTO, H002O13_n61TOTALCOMPRAPRODUCTO
               }
            }
         );
         AV13Pgmname = "Compra_inventarioGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "Compra_inventarioGeneral";
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
      private int edtIDCOMPRA_Enabled ;
      private int edtFECHACOMPRA_Enabled ;
      private int edtDESCRIPCIONCOMPRA_Enabled ;
      private int edtIDPROVEEDOR_Enabled ;
      private int edtNOMBREPROVEEDOR_Enabled ;
      private int edtIDEMPLEADO_Enabled ;
      private int edtNOMBRECOMPLETOEMPLEADO_Enabled ;
      private int edtTOTALCOMPRAPRODUCTO_Enabled ;
      private int idxLst ;
      private long A11IDCOMPRA ;
      private long wcpOA11IDCOMPRA ;
      private long A10IDPROVEEDOR ;
      private long A1IDEMPLEADO ;
      private long AV6IDCOMPRA ;
      private decimal A61TOTALCOMPRAPRODUCTO ;
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
      private string edtIDCOMPRA_Internalname ;
      private string edtIDCOMPRA_Jsonclick ;
      private string edtFECHACOMPRA_Internalname ;
      private string edtFECHACOMPRA_Jsonclick ;
      private string edtDESCRIPCIONCOMPRA_Internalname ;
      private string edtIDPROVEEDOR_Internalname ;
      private string edtIDPROVEEDOR_Jsonclick ;
      private string edtNOMBREPROVEEDOR_Internalname ;
      private string edtNOMBREPROVEEDOR_Link ;
      private string edtIDEMPLEADO_Internalname ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string edtNOMBRECOMPLETOEMPLEADO_Internalname ;
      private string edtNOMBRECOMPLETOEMPLEADO_Link ;
      private string edtTOTALCOMPRAPRODUCTO_Internalname ;
      private string edtTOTALCOMPRAPRODUCTO_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA11IDCOMPRA ;
      private DateTime A50FECHACOMPRA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n61TOTALCOMPRAPRODUCTO ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A51DESCRIPCIONCOMPRA ;
      private string A46NOMBREPROVEEDOR ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H002O5_A61TOTALCOMPRAPRODUCTO ;
      private bool[] H002O5_n61TOTALCOMPRAPRODUCTO ;
      private long[] H002O9_A11IDCOMPRA ;
      private string[] H002O9_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] H002O9_A1IDEMPLEADO ;
      private string[] H002O9_A46NOMBREPROVEEDOR ;
      private long[] H002O9_A10IDPROVEEDOR ;
      private string[] H002O9_A51DESCRIPCIONCOMPRA ;
      private DateTime[] H002O9_A50FECHACOMPRA ;
      private decimal[] H002O9_A61TOTALCOMPRAPRODUCTO ;
      private bool[] H002O9_n61TOTALCOMPRAPRODUCTO ;
      private decimal[] H002O13_A61TOTALCOMPRAPRODUCTO ;
      private bool[] H002O13_n61TOTALCOMPRAPRODUCTO ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class compra_inventariogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002O5;
          prmH002O5 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmH002O9;
          prmH002O9 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmH002O13;
          prmH002O13 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002O5", "SELECT COALESCE( T1.[TOTALCOMPRAPRODUCTO], 0) AS TOTALCOMPRAPRODUCTO FROM (SELECT SUM(COALESCE( T3.[SUBTOTALCOMPRAPRODUCTO], 0)) AS TOTALCOMPRAPRODUCTO, T2.[IDCOMPRA] FROM ([Compra_inventarioDetalle_compr] T2 LEFT JOIN (SELECT COALESCE( T5.[GXC2], 0) AS SUBTOTALCOMPRAPRODUCTO, T4.[IDCOMPRA], T4.[IDETALLECOMPRAPRODUCTO] FROM ([Compra_inventarioDetalle_compr] T4 LEFT JOIN (SELECT SUM(T7.[CANTIDADPRODUCTO] * CAST(T7.[PRECIOCOMPRAPRODUCTO] AS decimal( 22, 10))) AS GXC2, T6.[IDCOMPRA], T6.[IDETALLECOMPRAPRODUCTO] FROM ([Compra_inventarioDetalle_compr] T6 INNER JOIN [Inventario] T7 ON T7.[IDPRODUCTO] = T6.[IDPRODUCTO]) GROUP BY T6.[IDCOMPRA], T6.[IDETALLECOMPRAPRODUCTO] ) T5 ON T5.[IDCOMPRA] = T4.[IDCOMPRA] AND T5.[IDETALLECOMPRAPRODUCTO] = T4.[IDETALLECOMPRAPRODUCTO]) ) T3 ON T3.[IDCOMPRA] = T2.[IDCOMPRA] AND T3.[IDETALLECOMPRAPRODUCTO] = T2.[IDETALLECOMPRAPRODUCTO]) GROUP BY T2.[IDCOMPRA] ) T1 WHERE T1.[IDCOMPRA] = @IDCOMPRA ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002O5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002O9", "SELECT T1.[IDCOMPRA], T2.[NOMBRECOMPLETOEMPLEADO], T1.[IDEMPLEADO], T3.[NOMBREPROVEEDOR], T1.[IDPROVEEDOR], T1.[DESCRIPCIONCOMPRA], T1.[FECHACOMPRA], COALESCE( T4.[TOTALCOMPRAPRODUCTO], 0) AS TOTALCOMPRAPRODUCTO FROM ((([Compra_inventario] T1 INNER JOIN [Empleados] T2 ON T2.[IDEMPLEADO] = T1.[IDEMPLEADO]) INNER JOIN [Proveedores] T3 ON T3.[IDPROVEEDOR] = T1.[IDPROVEEDOR]) LEFT JOIN (SELECT SUM(COALESCE( T6.[SUBTOTALCOMPRAPRODUCTO], 0)) AS TOTALCOMPRAPRODUCTO, T5.[IDCOMPRA] FROM ([Compra_inventarioDetalle_compr] T5 LEFT JOIN (SELECT COALESCE( T8.[GXC2], 0) AS SUBTOTALCOMPRAPRODUCTO, T7.[IDCOMPRA], T7.[IDETALLECOMPRAPRODUCTO] FROM ([Compra_inventarioDetalle_compr] T7 LEFT JOIN (SELECT SUM(T10.[CANTIDADPRODUCTO] * CAST(T10.[PRECIOCOMPRAPRODUCTO] AS decimal( 22, 10))) AS GXC2, T9.[IDCOMPRA], T9.[IDETALLECOMPRAPRODUCTO] FROM ([Compra_inventarioDetalle_compr] T9 INNER JOIN [Inventario] T10 ON T10.[IDPRODUCTO] = T9.[IDPRODUCTO]) GROUP BY T9.[IDCOMPRA], T9.[IDETALLECOMPRAPRODUCTO] ) T8 ON T8.[IDCOMPRA] = T7.[IDCOMPRA] AND T8.[IDETALLECOMPRAPRODUCTO] = T7.[IDETALLECOMPRAPRODUCTO]) ) T6 ON T6.[IDCOMPRA] = T5.[IDCOMPRA] AND T6.[IDETALLECOMPRAPRODUCTO] = T5.[IDETALLECOMPRAPRODUCTO]) GROUP BY T5.[IDCOMPRA] ) T4 ON T4.[IDCOMPRA] = T1.[IDCOMPRA]) WHERE T1.[IDCOMPRA] = @IDCOMPRA ORDER BY T1.[IDCOMPRA] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002O9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002O13", "SELECT COALESCE( T1.[TOTALCOMPRAPRODUCTO], 0) AS TOTALCOMPRAPRODUCTO FROM (SELECT SUM(COALESCE( T3.[SUBTOTALCOMPRAPRODUCTO], 0)) AS TOTALCOMPRAPRODUCTO, T2.[IDCOMPRA] FROM ([Compra_inventarioDetalle_compr] T2 LEFT JOIN (SELECT COALESCE( T5.[GXC2], 0) AS SUBTOTALCOMPRAPRODUCTO, T4.[IDCOMPRA], T4.[IDETALLECOMPRAPRODUCTO] FROM ([Compra_inventarioDetalle_compr] T4 LEFT JOIN (SELECT SUM(T7.[CANTIDADPRODUCTO] * CAST(T7.[PRECIOCOMPRAPRODUCTO] AS decimal( 22, 10))) AS GXC2, T6.[IDCOMPRA], T6.[IDETALLECOMPRAPRODUCTO] FROM ([Compra_inventarioDetalle_compr] T6 INNER JOIN [Inventario] T7 ON T7.[IDPRODUCTO] = T6.[IDPRODUCTO]) GROUP BY T6.[IDCOMPRA], T6.[IDETALLECOMPRAPRODUCTO] ) T5 ON T5.[IDCOMPRA] = T4.[IDCOMPRA] AND T5.[IDETALLECOMPRAPRODUCTO] = T4.[IDETALLECOMPRAPRODUCTO]) ) T3 ON T3.[IDCOMPRA] = T2.[IDCOMPRA] AND T3.[IDETALLECOMPRAPRODUCTO] = T2.[IDETALLECOMPRAPRODUCTO]) GROUP BY T2.[IDCOMPRA] ) T1 WHERE T1.[IDCOMPRA] = @IDCOMPRA ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002O13,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
