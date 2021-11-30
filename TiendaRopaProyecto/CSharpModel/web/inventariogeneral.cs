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
   public class inventariogeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public inventariogeneral( )
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

      public inventariogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_IDPRODUCTO )
      {
         this.A7IDPRODUCTO = aP0_IDPRODUCTO;
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
               gxfirstwebparm = GetFirstPar( "IDPRODUCTO");
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
                  A7IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
                  AssignAttri(sPrefix, false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A7IDPRODUCTO});
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
                  gxfirstwebparm = GetFirstPar( "IDPRODUCTO");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "IDPRODUCTO");
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
            PA172( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "InventarioGeneral";
               context.Gx_err = 0;
               WS172( ) ;
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
            context.SendWebValue( "Inventario General") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021113012305644", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("inventariogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A7IDPRODUCTO,12,0))}, new string[] {"IDPRODUCTO"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"InventarioGeneral");
         forbiddenHiddens.Add("IDESTADOPRODUCTO", context.localUtil.Format( (decimal)(A5IDESTADOPRODUCTO), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("IDCATEGORIAPRODUCTO", context.localUtil.Format( (decimal)(A6IDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("IDMARCAPRODUCTO", context.localUtil.Format( (decimal)(A8IDMARCAPRODUCTO), "ZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("inventariogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA7IDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA7IDPRODUCTO), 12, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm172( )
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
         return "InventarioGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inventario General" ;
      }

      protected void WB170( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "inventariogeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11171_client"+"'", TempTags, "", 2, "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e12171_client"+"'", TempTags, "", 2, "HLP_InventarioGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDPRODUCTO_Internalname, "IDPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")), ((edtIDPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONPRODUCTO_Internalname, "DESCRIPCIONPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONPRODUCTO_Internalname, A40DESCRIPCIONPRODUCTO, "", "", 0, 1, edtDESCRIPCIONPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCANTIDADPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCANTIDADPRODUCTO_Internalname, "CANTIDADPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCANTIDADPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")), ((edtCANTIDADPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCANTIDADPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCANTIDADPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Cantidad", "right", false, "", "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECIOCOMPRAPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPRECIOCOMPRAPRODUCTO_Internalname, "PRECIOCOMPRAPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPRECIOCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")), ((edtPRECIOCOMPRAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECIOCOMPRAPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPRECIOCOMPRAPRODUCTO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECIOVENTAPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPRECIOVENTAPRODUCTO_Internalname, "PRECIOVENTAPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPRECIOVENTAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")), ((edtPRECIOVENTAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECIOVENTAPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPRECIOVENTAPRODUCTO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDESTADOPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDESTADOPRODUCTO_Internalname, "IDESTADOPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDESTADOPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5IDESTADOPRODUCTO), 12, 0, ".", "")), ((edtIDESTADOPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A5IDESTADOPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A5IDESTADOPRODUCTO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDESTADOPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDESTADOPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONESTADOPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONESTADOPRODUCTO_Internalname, "DESCRIPCIONESTADOPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONESTADOPRODUCTO_Internalname, A38DESCRIPCIONESTADOPRODUCTO, edtDESCRIPCIONESTADOPRODUCTO_Link, "", 0, 1, edtDESCRIPCIONESTADOPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDCATEGORIAPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDCATEGORIAPRODUCTO_Internalname, "IDCATEGORIAPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDCATEGORIAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0, ".", "")), ((edtIDCATEGORIAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A6IDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A6IDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCATEGORIAPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDCATEGORIAPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname, "DESCRIPCIONCATEGORIAPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname, A39DESCRIPCIONCATEGORIAPRODUCTO, edtDESCRIPCIONCATEGORIAPRODUCTO_Link, "", 0, 1, edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDMARCAPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDMARCAPRODUCTO_Internalname, "IDMARCAPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDMARCAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8IDMARCAPRODUCTO), 12, 0, ".", "")), ((edtIDMARCAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A8IDMARCAPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A8IDMARCAPRODUCTO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDMARCAPRODUCTO_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtIDMARCAPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_InventarioGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONMARCAPRODUCTO_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDESCRIPCIONMARCAPRODUCTO_Internalname, "DESCRIPCIONMARCAPRODUCTO", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtDESCRIPCIONMARCAPRODUCTO_Internalname, A44DESCRIPCIONMARCAPRODUCTO, edtDESCRIPCIONMARCAPRODUCTO_Link, "", 0, 1, edtDESCRIPCIONMARCAPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_InventarioGeneral.htm");
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

      protected void START172( )
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
               Form.Meta.addItem("description", "Inventario General", 0) ;
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
               STRUP170( ) ;
            }
         }
      }

      protected void WS172( )
      {
         START172( ) ;
         EVT172( ) ;
      }

      protected void EVT172( )
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
                                 STRUP170( ) ;
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
                                 STRUP170( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13172 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP170( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14172 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP170( ) ;
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
                                 STRUP170( ) ;
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

      protected void WE172( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm172( ) ;
            }
         }
      }

      protected void PA172( )
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
         RF172( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "InventarioGeneral";
         context.Gx_err = 0;
      }

      protected void RF172( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00172 */
            pr_default.execute(0, new Object[] {A7IDPRODUCTO});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A44DESCRIPCIONMARCAPRODUCTO = H00172_A44DESCRIPCIONMARCAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
               A8IDMARCAPRODUCTO = H00172_A8IDMARCAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
               A39DESCRIPCIONCATEGORIAPRODUCTO = H00172_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
               A6IDCATEGORIAPRODUCTO = H00172_A6IDCATEGORIAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
               A38DESCRIPCIONESTADOPRODUCTO = H00172_A38DESCRIPCIONESTADOPRODUCTO[0];
               AssignAttri(sPrefix, false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
               A5IDESTADOPRODUCTO = H00172_A5IDESTADOPRODUCTO[0];
               AssignAttri(sPrefix, false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
               A43PRECIOVENTAPRODUCTO = H00172_A43PRECIOVENTAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrimStr( A43PRECIOVENTAPRODUCTO, 12, 2));
               A42PRECIOCOMPRAPRODUCTO = H00172_A42PRECIOCOMPRAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( A42PRECIOCOMPRAPRODUCTO, 12, 2));
               A41CANTIDADPRODUCTO = H00172_A41CANTIDADPRODUCTO[0];
               AssignAttri(sPrefix, false, "A41CANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(A41CANTIDADPRODUCTO), 12, 0));
               A40DESCRIPCIONPRODUCTO = H00172_A40DESCRIPCIONPRODUCTO[0];
               AssignAttri(sPrefix, false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
               A44DESCRIPCIONMARCAPRODUCTO = H00172_A44DESCRIPCIONMARCAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
               A39DESCRIPCIONCATEGORIAPRODUCTO = H00172_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
               AssignAttri(sPrefix, false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
               A38DESCRIPCIONESTADOPRODUCTO = H00172_A38DESCRIPCIONESTADOPRODUCTO[0];
               AssignAttri(sPrefix, false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
               /* Execute user event: Load */
               E14172 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB170( ) ;
         }
      }

      protected void send_integrity_lvl_hashes172( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "InventarioGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP170( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13172 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA7IDPRODUCTO"), ".", ","));
            /* Read variables values. */
            A40DESCRIPCIONPRODUCTO = cgiGet( edtDESCRIPCIONPRODUCTO_Internalname);
            AssignAttri(sPrefix, false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
            A41CANTIDADPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtCANTIDADPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A41CANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(A41CANTIDADPRODUCTO), 12, 0));
            A42PRECIOCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOCOMPRAPRODUCTO_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( A42PRECIOCOMPRAPRODUCTO, 12, 2));
            A43PRECIOVENTAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOVENTAPRODUCTO_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrimStr( A43PRECIOVENTAPRODUCTO, 12, 2));
            A5IDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDESTADOPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
            A38DESCRIPCIONESTADOPRODUCTO = cgiGet( edtDESCRIPCIONESTADOPRODUCTO_Internalname);
            AssignAttri(sPrefix, false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
            A6IDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDCATEGORIAPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
            A39DESCRIPCIONCATEGORIAPRODUCTO = cgiGet( edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname);
            AssignAttri(sPrefix, false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
            A8IDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDMARCAPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
            A44DESCRIPCIONMARCAPRODUCTO = cgiGet( edtDESCRIPCIONMARCAPRODUCTO_Internalname);
            AssignAttri(sPrefix, false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"InventarioGeneral");
            A5IDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDESTADOPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
            forbiddenHiddens.Add("IDESTADOPRODUCTO", context.localUtil.Format( (decimal)(A5IDESTADOPRODUCTO), "ZZZZZZZZZZZ9"));
            A6IDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDCATEGORIAPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
            forbiddenHiddens.Add("IDCATEGORIAPRODUCTO", context.localUtil.Format( (decimal)(A6IDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9"));
            A8IDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDMARCAPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
            forbiddenHiddens.Add("IDMARCAPRODUCTO", context.localUtil.Format( (decimal)(A8IDMARCAPRODUCTO), "ZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("inventariogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E13172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13172( )
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

      protected void E14172( )
      {
         /* Load Routine */
         returnInSub = false;
         edtDESCRIPCIONESTADOPRODUCTO_Link = formatLink("viewestado_producto.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A5IDESTADOPRODUCTO,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDESTADOPRODUCTO","TabCode"}) ;
         AssignProp(sPrefix, false, edtDESCRIPCIONESTADOPRODUCTO_Internalname, "Link", edtDESCRIPCIONESTADOPRODUCTO_Link, true);
         edtDESCRIPCIONCATEGORIAPRODUCTO_Link = formatLink("viewcategoria_producto.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A6IDCATEGORIAPRODUCTO,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDCATEGORIAPRODUCTO","TabCode"}) ;
         AssignProp(sPrefix, false, edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname, "Link", edtDESCRIPCIONCATEGORIAPRODUCTO_Link, true);
         edtDESCRIPCIONMARCAPRODUCTO_Link = formatLink("viewmarca_producto.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A8IDMARCAPRODUCTO,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDMARCAPRODUCTO","TabCode"}) ;
         AssignProp(sPrefix, false, edtDESCRIPCIONMARCAPRODUCTO_Internalname, "Link", edtDESCRIPCIONMARCAPRODUCTO_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Inventario";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "IDPRODUCTO";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6IDPRODUCTO), 12, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "TiendaRopaProyecto"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A7IDPRODUCTO = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
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
         PA172( ) ;
         WS172( ) ;
         WE172( ) ;
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
         sCtrlA7IDPRODUCTO = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA172( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "inventariogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA172( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A7IDPRODUCTO = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
         }
         wcpOA7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA7IDPRODUCTO"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A7IDPRODUCTO != wcpOA7IDPRODUCTO ) ) )
         {
            setjustcreated();
         }
         wcpOA7IDPRODUCTO = A7IDPRODUCTO;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA7IDPRODUCTO = cgiGet( sPrefix+"A7IDPRODUCTO_CTRL");
         if ( StringUtil.Len( sCtrlA7IDPRODUCTO) > 0 )
         {
            A7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sCtrlA7IDPRODUCTO), ".", ","));
            AssignAttri(sPrefix, false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
         }
         else
         {
            A7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"A7IDPRODUCTO_PARM"), ".", ","));
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
         PA172( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS172( ) ;
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
         WS172( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A7IDPRODUCTO_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA7IDPRODUCTO)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A7IDPRODUCTO_CTRL", StringUtil.RTrim( sCtrlA7IDPRODUCTO));
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
         WE172( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113012305681", true, true);
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
         context.AddJavascriptSource("inventariogeneral.js", "?2021113012305681", false, true);
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
         edtIDPRODUCTO_Internalname = sPrefix+"IDPRODUCTO";
         edtDESCRIPCIONPRODUCTO_Internalname = sPrefix+"DESCRIPCIONPRODUCTO";
         edtCANTIDADPRODUCTO_Internalname = sPrefix+"CANTIDADPRODUCTO";
         edtPRECIOCOMPRAPRODUCTO_Internalname = sPrefix+"PRECIOCOMPRAPRODUCTO";
         edtPRECIOVENTAPRODUCTO_Internalname = sPrefix+"PRECIOVENTAPRODUCTO";
         edtIDESTADOPRODUCTO_Internalname = sPrefix+"IDESTADOPRODUCTO";
         edtDESCRIPCIONESTADOPRODUCTO_Internalname = sPrefix+"DESCRIPCIONESTADOPRODUCTO";
         edtIDCATEGORIAPRODUCTO_Internalname = sPrefix+"IDCATEGORIAPRODUCTO";
         edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname = sPrefix+"DESCRIPCIONCATEGORIAPRODUCTO";
         edtIDMARCAPRODUCTO_Internalname = sPrefix+"IDMARCAPRODUCTO";
         edtDESCRIPCIONMARCAPRODUCTO_Internalname = sPrefix+"DESCRIPCIONMARCAPRODUCTO";
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
         edtDESCRIPCIONMARCAPRODUCTO_Link = "";
         edtDESCRIPCIONMARCAPRODUCTO_Enabled = 0;
         edtIDMARCAPRODUCTO_Jsonclick = "";
         edtIDMARCAPRODUCTO_Enabled = 0;
         edtDESCRIPCIONCATEGORIAPRODUCTO_Link = "";
         edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled = 0;
         edtIDCATEGORIAPRODUCTO_Jsonclick = "";
         edtIDCATEGORIAPRODUCTO_Enabled = 0;
         edtDESCRIPCIONESTADOPRODUCTO_Link = "";
         edtDESCRIPCIONESTADOPRODUCTO_Enabled = 0;
         edtIDESTADOPRODUCTO_Jsonclick = "";
         edtIDESTADOPRODUCTO_Enabled = 0;
         edtPRECIOVENTAPRODUCTO_Jsonclick = "";
         edtPRECIOVENTAPRODUCTO_Enabled = 0;
         edtPRECIOCOMPRAPRODUCTO_Jsonclick = "";
         edtPRECIOCOMPRAPRODUCTO_Enabled = 0;
         edtCANTIDADPRODUCTO_Jsonclick = "";
         edtCANTIDADPRODUCTO_Enabled = 0;
         edtDESCRIPCIONPRODUCTO_Enabled = 0;
         edtIDPRODUCTO_Jsonclick = "";
         edtIDPRODUCTO_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A7IDPRODUCTO',fld:'IDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A5IDESTADOPRODUCTO',fld:'IDESTADOPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A6IDCATEGORIAPRODUCTO',fld:'IDCATEGORIAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A8IDMARCAPRODUCTO',fld:'IDMARCAPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E11171',iparms:[{av:'A7IDPRODUCTO',fld:'IDPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E12171',iparms:[{av:'A7IDPRODUCTO',fld:'IDPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_IDPRODUCTO","{handler:'Valid_Idproducto',iparms:[]");
         setEventMetadata("VALID_IDPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_IDESTADOPRODUCTO","{handler:'Valid_Idestadoproducto',iparms:[]");
         setEventMetadata("VALID_IDESTADOPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_IDCATEGORIAPRODUCTO","{handler:'Valid_Idcategoriaproducto',iparms:[]");
         setEventMetadata("VALID_IDCATEGORIAPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_IDMARCAPRODUCTO","{handler:'Valid_Idmarcaproducto',iparms:[]");
         setEventMetadata("VALID_IDMARCAPRODUCTO",",oparms:[]}");
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
         A40DESCRIPCIONPRODUCTO = "";
         A38DESCRIPCIONESTADOPRODUCTO = "";
         A39DESCRIPCIONCATEGORIAPRODUCTO = "";
         A44DESCRIPCIONMARCAPRODUCTO = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00172_A7IDPRODUCTO = new long[1] ;
         H00172_A44DESCRIPCIONMARCAPRODUCTO = new string[] {""} ;
         H00172_A8IDMARCAPRODUCTO = new long[1] ;
         H00172_A39DESCRIPCIONCATEGORIAPRODUCTO = new string[] {""} ;
         H00172_A6IDCATEGORIAPRODUCTO = new long[1] ;
         H00172_A38DESCRIPCIONESTADOPRODUCTO = new string[] {""} ;
         H00172_A5IDESTADOPRODUCTO = new long[1] ;
         H00172_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         H00172_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         H00172_A41CANTIDADPRODUCTO = new long[1] ;
         H00172_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         hsh = "";
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA7IDPRODUCTO = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventariogeneral__default(),
            new Object[][] {
                new Object[] {
               H00172_A7IDPRODUCTO, H00172_A44DESCRIPCIONMARCAPRODUCTO, H00172_A8IDMARCAPRODUCTO, H00172_A39DESCRIPCIONCATEGORIAPRODUCTO, H00172_A6IDCATEGORIAPRODUCTO, H00172_A38DESCRIPCIONESTADOPRODUCTO, H00172_A5IDESTADOPRODUCTO, H00172_A43PRECIOVENTAPRODUCTO, H00172_A42PRECIOCOMPRAPRODUCTO, H00172_A41CANTIDADPRODUCTO,
               H00172_A40DESCRIPCIONPRODUCTO
               }
            }
         );
         AV13Pgmname = "InventarioGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "InventarioGeneral";
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
      private int edtIDPRODUCTO_Enabled ;
      private int edtDESCRIPCIONPRODUCTO_Enabled ;
      private int edtCANTIDADPRODUCTO_Enabled ;
      private int edtPRECIOCOMPRAPRODUCTO_Enabled ;
      private int edtPRECIOVENTAPRODUCTO_Enabled ;
      private int edtIDESTADOPRODUCTO_Enabled ;
      private int edtDESCRIPCIONESTADOPRODUCTO_Enabled ;
      private int edtIDCATEGORIAPRODUCTO_Enabled ;
      private int edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled ;
      private int edtIDMARCAPRODUCTO_Enabled ;
      private int edtDESCRIPCIONMARCAPRODUCTO_Enabled ;
      private int idxLst ;
      private long A7IDPRODUCTO ;
      private long wcpOA7IDPRODUCTO ;
      private long A5IDESTADOPRODUCTO ;
      private long A6IDCATEGORIAPRODUCTO ;
      private long A8IDMARCAPRODUCTO ;
      private long A41CANTIDADPRODUCTO ;
      private long AV6IDPRODUCTO ;
      private decimal A42PRECIOCOMPRAPRODUCTO ;
      private decimal A43PRECIOVENTAPRODUCTO ;
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
      private string edtIDPRODUCTO_Internalname ;
      private string edtIDPRODUCTO_Jsonclick ;
      private string edtDESCRIPCIONPRODUCTO_Internalname ;
      private string edtCANTIDADPRODUCTO_Internalname ;
      private string edtCANTIDADPRODUCTO_Jsonclick ;
      private string edtPRECIOCOMPRAPRODUCTO_Internalname ;
      private string edtPRECIOCOMPRAPRODUCTO_Jsonclick ;
      private string edtPRECIOVENTAPRODUCTO_Internalname ;
      private string edtPRECIOVENTAPRODUCTO_Jsonclick ;
      private string edtIDESTADOPRODUCTO_Internalname ;
      private string edtIDESTADOPRODUCTO_Jsonclick ;
      private string edtDESCRIPCIONESTADOPRODUCTO_Internalname ;
      private string edtDESCRIPCIONESTADOPRODUCTO_Link ;
      private string edtIDCATEGORIAPRODUCTO_Internalname ;
      private string edtIDCATEGORIAPRODUCTO_Jsonclick ;
      private string edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname ;
      private string edtDESCRIPCIONCATEGORIAPRODUCTO_Link ;
      private string edtIDMARCAPRODUCTO_Internalname ;
      private string edtIDMARCAPRODUCTO_Jsonclick ;
      private string edtDESCRIPCIONMARCAPRODUCTO_Internalname ;
      private string edtDESCRIPCIONMARCAPRODUCTO_Link ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA7IDPRODUCTO ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A40DESCRIPCIONPRODUCTO ;
      private string A38DESCRIPCIONESTADOPRODUCTO ;
      private string A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string A44DESCRIPCIONMARCAPRODUCTO ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H00172_A7IDPRODUCTO ;
      private string[] H00172_A44DESCRIPCIONMARCAPRODUCTO ;
      private long[] H00172_A8IDMARCAPRODUCTO ;
      private string[] H00172_A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private long[] H00172_A6IDCATEGORIAPRODUCTO ;
      private string[] H00172_A38DESCRIPCIONESTADOPRODUCTO ;
      private long[] H00172_A5IDESTADOPRODUCTO ;
      private decimal[] H00172_A43PRECIOVENTAPRODUCTO ;
      private decimal[] H00172_A42PRECIOCOMPRAPRODUCTO ;
      private long[] H00172_A41CANTIDADPRODUCTO ;
      private string[] H00172_A40DESCRIPCIONPRODUCTO ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class inventariogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00172;
          prmH00172 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00172", "SELECT T1.[IDPRODUCTO], T2.[DESCRIPCIONMARCAPRODUCTO], T1.[IDMARCAPRODUCTO], T3.[DESCRIPCIONCATEGORIAPRODUCTO], T1.[IDCATEGORIAPRODUCTO], T4.[DESCRIPCIONESTADOPRODUCTO], T1.[IDESTADOPRODUCTO], T1.[PRECIOVENTAPRODUCTO], T1.[PRECIOCOMPRAPRODUCTO], T1.[CANTIDADPRODUCTO], T1.[DESCRIPCIONPRODUCTO] FROM ((([Inventario] T1 INNER JOIN [Marca_producto] T2 ON T2.[IDMARCAPRODUCTO] = T1.[IDMARCAPRODUCTO]) INNER JOIN [Categoria_producto] T3 ON T3.[IDCATEGORIAPRODUCTO] = T1.[IDCATEGORIAPRODUCTO]) INNER JOIN [Estado_producto] T4 ON T4.[IDESTADOPRODUCTO] = T1.[IDESTADOPRODUCTO]) WHERE T1.[IDPRODUCTO] = @IDPRODUCTO ORDER BY T1.[IDPRODUCTO] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00172,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                return;
       }
    }

 }

}
