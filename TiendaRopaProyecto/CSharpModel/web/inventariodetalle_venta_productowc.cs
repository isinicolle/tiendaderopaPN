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
   public class inventariodetalle_venta_productowc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public inventariodetalle_venta_productowc( )
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

      public inventariodetalle_venta_productowc( IGxContext context )
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
         this.AV6IDPRODUCTO = aP0_IDPRODUCTO;
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
                  AV6IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
                  AssignAttri(sPrefix, false, "AV6IDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV6IDPRODUCTO), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV6IDPRODUCTO});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_20 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_20"), "."));
                  nGXsfl_20_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_20_idx"), "."));
                  sGXsfl_20_idx = GetPar( "sGXsfl_20_idx");
                  sPrefix = GetPar( "sPrefix");
                  AV12Update = GetPar( "Update");
                  AV13Delete = GetPar( "Delete");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
                  AV6IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
                  AV12Update = GetPar( "Update");
                  AV13Delete = GetPar( "Delete");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( subGrid_Rows, AV6IDPRODUCTO, AV12Update, AV13Delete, sPrefix) ;
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
                  AddString( context.getJSONResponse( )) ;
                  return  ;
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
            PA312( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "InventarioDetalle_venta_productoWC";
               context.Gx_err = 0;
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
               WS312( ) ;
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
            context.SendWebValue( "Inventario Detalle_venta_producto WC") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021113013582653", false, true);
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
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("inventariodetalle_venta_productowc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6IDPRODUCTO,12,0))}, new string[] {"IDPRODUCTO"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6IDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6IDPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vIDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6IDPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm312( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "InventarioDetalle_venta_productoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inventario Detalle_venta_producto WC" ;
      }

      protected void WB310( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "inventariodetalle_venta_productowc.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "GridTabMainTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-7 col-sm-2 col-sm-offset-1 ViewGridActionsCell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WWViewActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnAdd";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(20), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_InventarioDetalle_venta_productoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ViewGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"20\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ViewGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDVENTA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "FECHAVENTA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "DESCRIPCIONVENTA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDEMPLEADO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "NOMBRECOMPLETOEMPLEADO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDCLIENTE") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "NOMBRECOMPLETOCLIENTE") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IMPUESTOVENTA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "DESCUENTOVENTA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "TOTALVENTA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "ViewGrid");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtFECHAVENTA_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A55DESCRIPCIONVENTA);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A23NOMBRECOMPLETOEMPLEADO);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtNOMBRECOMPLETOEMPLEADO_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A30NOMBRECOMPLETOCLIENTE);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtNOMBRECOMPLETOCLIENTE_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A57IMPUESTOVENTA, 12, 2, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A58DESCUENTOVENTA, 12, 2, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A59TOTALVENTA, 12, 2, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV13Delete));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtIDPRODUCTO_Internalname, "IDPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtIDPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")), ((edtIDPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", edtIDPRODUCTO_Visible, edtIDPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_InventarioDetalle_venta_productoWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START312( )
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
               Form.Meta.addItem("description", "Inventario Detalle_venta_producto WC", 0) ;
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
               STRUP310( ) ;
            }
         }
      }

      protected void WS312( )
      {
         START312( ) ;
         EVT312( ) ;
      }

      protected void EVT312( )
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
                                 STRUP310( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E11312 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP310( ) ;
                              }
                              nGXsfl_20_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_202( ) ;
                              A12IDVENTA = (long)(context.localUtil.CToN( cgiGet( edtIDVENTA_Internalname), ".", ","));
                              A54FECHAVENTA = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFECHAVENTA_Internalname), 0));
                              A55DESCRIPCIONVENTA = cgiGet( edtDESCRIPCIONVENTA_Internalname);
                              A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
                              A23NOMBRECOMPLETOEMPLEADO = cgiGet( edtNOMBRECOMPLETOEMPLEADO_Internalname);
                              A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ","));
                              A30NOMBRECOMPLETOCLIENTE = cgiGet( edtNOMBRECOMPLETOCLIENTE_Internalname);
                              A57IMPUESTOVENTA = context.localUtil.CToN( cgiGet( edtIMPUESTOVENTA_Internalname), ".", ",");
                              n57IMPUESTOVENTA = false;
                              A58DESCUENTOVENTA = context.localUtil.CToN( cgiGet( edtDESCUENTOVENTA_Internalname), ".", ",");
                              A59TOTALVENTA = context.localUtil.CToN( cgiGet( edtTOTALVENTA_Internalname), ".", ",");
                              n59TOTALVENTA = false;
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E12312 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E13312 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
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
                                       STRUP310( ) ;
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
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE312( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm312( ) ;
            }
         }
      }

      protected void PA312( )
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_202( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_202( ) ;
            nGXsfl_20_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       long AV6IDPRODUCTO ,
                                       string AV12Update ,
                                       string AV13Delete ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF312( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_IDVENTA", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"IDVENTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")));
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
         RF312( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "InventarioDetalle_venta_productoWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
      }

      protected void RF312( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 20;
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_202( ) ;
         bGXsfl_20_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ViewGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_202( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H003114 */
            pr_default.execute(0, new Object[] {AV6IDPRODUCTO, GXPagingFrom2, GXPagingTo2});
            nGXsfl_20_idx = 1;
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A7IDPRODUCTO = H003114_A7IDPRODUCTO[0];
               AssignAttri(sPrefix, false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
               A58DESCUENTOVENTA = H003114_A58DESCUENTOVENTA[0];
               A30NOMBRECOMPLETOCLIENTE = H003114_A30NOMBRECOMPLETOCLIENTE[0];
               A4IDCLIENTE = H003114_A4IDCLIENTE[0];
               A23NOMBRECOMPLETOEMPLEADO = H003114_A23NOMBRECOMPLETOEMPLEADO[0];
               A1IDEMPLEADO = H003114_A1IDEMPLEADO[0];
               A55DESCRIPCIONVENTA = H003114_A55DESCRIPCIONVENTA[0];
               A54FECHAVENTA = H003114_A54FECHAVENTA[0];
               A12IDVENTA = H003114_A12IDVENTA[0];
               A59TOTALVENTA = H003114_A59TOTALVENTA[0];
               n59TOTALVENTA = H003114_n59TOTALVENTA[0];
               A57IMPUESTOVENTA = H003114_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = H003114_n57IMPUESTOVENTA[0];
               A58DESCUENTOVENTA = H003114_A58DESCUENTOVENTA[0];
               A4IDCLIENTE = H003114_A4IDCLIENTE[0];
               A1IDEMPLEADO = H003114_A1IDEMPLEADO[0];
               A55DESCRIPCIONVENTA = H003114_A55DESCRIPCIONVENTA[0];
               A54FECHAVENTA = H003114_A54FECHAVENTA[0];
               A30NOMBRECOMPLETOCLIENTE = H003114_A30NOMBRECOMPLETOCLIENTE[0];
               A23NOMBRECOMPLETOEMPLEADO = H003114_A23NOMBRECOMPLETOEMPLEADO[0];
               A59TOTALVENTA = H003114_A59TOTALVENTA[0];
               n59TOTALVENTA = H003114_n59TOTALVENTA[0];
               A57IMPUESTOVENTA = H003114_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = H003114_n57IMPUESTOVENTA[0];
               E13312 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 20;
            WB310( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes312( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_IDVENTA"+"_"+sGXsfl_20_idx, GetSecureSignedToken( sPrefix+sGXsfl_20_idx, context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         /* Using cursor H003127 */
         pr_default.execute(1, new Object[] {AV6IDPRODUCTO});
         GRID_nRecordCount = H003127_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6IDPRODUCTO, AV12Update, AV13Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6IDPRODUCTO, AV12Update, AV13Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6IDPRODUCTO, AV12Update, AV13Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6IDPRODUCTO, AV12Update, AV13Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6IDPRODUCTO, AV12Update, AV13Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "InventarioDetalle_venta_productoWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP310( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12312 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_20 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_20"), ".", ","));
            wcpOAV6IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6IDPRODUCTO"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            A7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDPRODUCTO_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12312 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12312( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = "Update";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV12Update);
         AV13Delete = "Delete";
         AssignAttri(sPrefix, false, edtavDelete_Internalname, AV13Delete);
         edtIDPRODUCTO_Visible = 0;
         AssignProp(sPrefix, false, edtIDPRODUCTO_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E13312( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("ventas_inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A12IDVENTA,12,0))}, new string[] {"Mode","IDVENTA"}) ;
         edtavDelete_Link = formatLink("ventas_inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A12IDVENTA,12,0))}, new string[] {"Mode","IDVENTA"}) ;
         edtFECHAVENTA_Link = formatLink("viewventas_inventario.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A12IDVENTA,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDVENTA","TabCode"}) ;
         edtNOMBRECOMPLETOEMPLEADO_Link = formatLink("viewempleados.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1IDEMPLEADO,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDEMPLEADO","TabCode"}) ;
         edtNOMBRECOMPLETOCLIENTE_Link = formatLink("viewclientes.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A4IDCLIENTE,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IDCLIENTE","TabCode"}) ;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 20;
         }
         sendrow_202( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
         {
            context.DoAjaxLoad(20, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11312( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("ventas_inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","IDVENTA"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new SdtTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Ventas_inventario";
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "IDPRODUCTO";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6IDPRODUCTO), 12, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV7Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "TransactionContext", "TiendaRopaProyecto"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6IDPRODUCTO = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6IDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV6IDPRODUCTO), 12, 0));
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
         PA312( ) ;
         WS312( ) ;
         WE312( ) ;
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
         sCtrlAV6IDPRODUCTO = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA312( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "inventariodetalle_venta_productowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA312( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6IDPRODUCTO = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6IDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV6IDPRODUCTO), 12, 0));
         }
         wcpOAV6IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6IDPRODUCTO"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV6IDPRODUCTO != wcpOAV6IDPRODUCTO ) ) )
         {
            setjustcreated();
         }
         wcpOAV6IDPRODUCTO = AV6IDPRODUCTO;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6IDPRODUCTO = cgiGet( sPrefix+"AV6IDPRODUCTO_CTRL");
         if ( StringUtil.Len( sCtrlAV6IDPRODUCTO) > 0 )
         {
            AV6IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sCtrlAV6IDPRODUCTO), ".", ","));
            AssignAttri(sPrefix, false, "AV6IDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV6IDPRODUCTO), 12, 0));
         }
         else
         {
            AV6IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV6IDPRODUCTO_PARM"), ".", ","));
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
         PA312( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS312( ) ;
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
         WS312( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6IDPRODUCTO_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6IDPRODUCTO), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6IDPRODUCTO)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6IDPRODUCTO_CTRL", StringUtil.RTrim( sCtrlAV6IDPRODUCTO));
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
         WE312( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113013582713", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("inventariodetalle_venta_productowc.js", "?2021113013582713", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_202( )
      {
         edtIDVENTA_Internalname = sPrefix+"IDVENTA_"+sGXsfl_20_idx;
         edtFECHAVENTA_Internalname = sPrefix+"FECHAVENTA_"+sGXsfl_20_idx;
         edtDESCRIPCIONVENTA_Internalname = sPrefix+"DESCRIPCIONVENTA_"+sGXsfl_20_idx;
         edtIDEMPLEADO_Internalname = sPrefix+"IDEMPLEADO_"+sGXsfl_20_idx;
         edtNOMBRECOMPLETOEMPLEADO_Internalname = sPrefix+"NOMBRECOMPLETOEMPLEADO_"+sGXsfl_20_idx;
         edtIDCLIENTE_Internalname = sPrefix+"IDCLIENTE_"+sGXsfl_20_idx;
         edtNOMBRECOMPLETOCLIENTE_Internalname = sPrefix+"NOMBRECOMPLETOCLIENTE_"+sGXsfl_20_idx;
         edtIMPUESTOVENTA_Internalname = sPrefix+"IMPUESTOVENTA_"+sGXsfl_20_idx;
         edtDESCUENTOVENTA_Internalname = sPrefix+"DESCUENTOVENTA_"+sGXsfl_20_idx;
         edtTOTALVENTA_Internalname = sPrefix+"TOTALVENTA_"+sGXsfl_20_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_20_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_202( )
      {
         edtIDVENTA_Internalname = sPrefix+"IDVENTA_"+sGXsfl_20_fel_idx;
         edtFECHAVENTA_Internalname = sPrefix+"FECHAVENTA_"+sGXsfl_20_fel_idx;
         edtDESCRIPCIONVENTA_Internalname = sPrefix+"DESCRIPCIONVENTA_"+sGXsfl_20_fel_idx;
         edtIDEMPLEADO_Internalname = sPrefix+"IDEMPLEADO_"+sGXsfl_20_fel_idx;
         edtNOMBRECOMPLETOEMPLEADO_Internalname = sPrefix+"NOMBRECOMPLETOEMPLEADO_"+sGXsfl_20_fel_idx;
         edtIDCLIENTE_Internalname = sPrefix+"IDCLIENTE_"+sGXsfl_20_fel_idx;
         edtNOMBRECOMPLETOCLIENTE_Internalname = sPrefix+"NOMBRECOMPLETOCLIENTE_"+sGXsfl_20_fel_idx;
         edtIMPUESTOVENTA_Internalname = sPrefix+"IMPUESTOVENTA_"+sGXsfl_20_fel_idx;
         edtDESCUENTOVENTA_Internalname = sPrefix+"DESCUENTOVENTA_"+sGXsfl_20_fel_idx;
         edtTOTALVENTA_Internalname = sPrefix+"TOTALVENTA_"+sGXsfl_20_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_20_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_202( )
      {
         SubsflControlProps_202( ) ;
         WB310( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_20_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_20_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ViewGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_20_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFECHAVENTA_Internalname,context.localUtil.Format(A54FECHAVENTA, "99/99/99"),context.localUtil.Format( A54FECHAVENTA, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtFECHAVENTA_Link,(string)"",(string)"",(string)"",(string)edtFECHAVENTA_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDESCRIPCIONVENTA_Internalname,(string)A55DESCRIPCIONVENTA,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDESCRIPCIONVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDEMPLEADO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNOMBRECOMPLETOEMPLEADO_Internalname,(string)A23NOMBRECOMPLETOEMPLEADO,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtNOMBRECOMPLETOEMPLEADO_Link,(string)"",(string)"",(string)"",(string)edtNOMBRECOMPLETOEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDCLIENTE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNOMBRECOMPLETOCLIENTE_Internalname,(string)A30NOMBRECOMPLETOCLIENTE,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtNOMBRECOMPLETOCLIENTE_Link,(string)"",(string)"",(string)"",(string)edtNOMBRECOMPLETOCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIMPUESTOVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( A57IMPUESTOVENTA, 12, 2, ".", "")),context.localUtil.Format( A57IMPUESTOVENTA, "ZZZZZZZZ9.99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIMPUESTOVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDESCUENTOVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( A58DESCUENTOVENTA, 12, 2, ".", "")),context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDESCUENTOVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTOTALVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( A59TOTALVENTA, 12, 2, ".", "")),context.localUtil.Format( A59TOTALVENTA, "ZZZZZZZZ9.99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTOTALVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes312( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_20_idx = ((subGrid_Islastpage==1)&&(nGXsfl_20_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_202( ) ;
         }
         /* End function sendrow_202 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTabletop_Internalname = sPrefix+"TABLETOP";
         edtIDVENTA_Internalname = sPrefix+"IDVENTA";
         edtFECHAVENTA_Internalname = sPrefix+"FECHAVENTA";
         edtDESCRIPCIONVENTA_Internalname = sPrefix+"DESCRIPCIONVENTA";
         edtIDEMPLEADO_Internalname = sPrefix+"IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = sPrefix+"NOMBRECOMPLETOEMPLEADO";
         edtIDCLIENTE_Internalname = sPrefix+"IDCLIENTE";
         edtNOMBRECOMPLETOCLIENTE_Internalname = sPrefix+"NOMBRECOMPLETOCLIENTE";
         edtIMPUESTOVENTA_Internalname = sPrefix+"IMPUESTOVENTA";
         edtDESCUENTOVENTA_Internalname = sPrefix+"DESCUENTOVENTA";
         edtTOTALVENTA_Internalname = sPrefix+"TOTALVENTA";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         divGridtable_Internalname = sPrefix+"GRIDTABLE";
         divGridcell_Internalname = sPrefix+"GRIDCELL";
         edtIDPRODUCTO_Internalname = sPrefix+"IDPRODUCTO";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         edtavDelete_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtTOTALVENTA_Jsonclick = "";
         edtDESCUENTOVENTA_Jsonclick = "";
         edtIMPUESTOVENTA_Jsonclick = "";
         edtNOMBRECOMPLETOCLIENTE_Jsonclick = "";
         edtIDCLIENTE_Jsonclick = "";
         edtNOMBRECOMPLETOEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Jsonclick = "";
         edtDESCRIPCIONVENTA_Jsonclick = "";
         edtFECHAVENTA_Jsonclick = "";
         edtIDVENTA_Jsonclick = "";
         edtIDPRODUCTO_Jsonclick = "";
         edtIDPRODUCTO_Enabled = 0;
         edtIDPRODUCTO_Visible = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavDelete_Link = "";
         edtavUpdate_Link = "";
         edtNOMBRECOMPLETOCLIENTE_Link = "";
         edtNOMBRECOMPLETOEMPLEADO_Link = "";
         edtFECHAVENTA_Link = "";
         subGrid_Header = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Enabled = 0;
         subGrid_Class = "ViewGrid";
         subGrid_Backcolorstyle = 0;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6IDPRODUCTO',fld:'vIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E13312',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtFECHAVENTA_Link',ctrl:'FECHAVENTA',prop:'Link'},{av:'edtNOMBRECOMPLETOEMPLEADO_Link',ctrl:'NOMBRECOMPLETOEMPLEADO',prop:'Link'},{av:'edtNOMBRECOMPLETOCLIENTE_Link',ctrl:'NOMBRECOMPLETOCLIENTE',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E11312',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6IDPRODUCTO',fld:'vIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6IDPRODUCTO',fld:'vIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6IDPRODUCTO',fld:'vIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6IDPRODUCTO',fld:'vIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALID_IDVENTA","{handler:'Valid_Idventa',iparms:[]");
         setEventMetadata("VALID_IDVENTA",",oparms:[]}");
         setEventMetadata("VALID_IDEMPLEADO","{handler:'Valid_Idempleado',iparms:[]");
         setEventMetadata("VALID_IDEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_IDCLIENTE","{handler:'Valid_Idcliente',iparms:[]");
         setEventMetadata("VALID_IDCLIENTE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV12Update = "";
         AV13Delete = "";
         AV17Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A54FECHAVENTA = DateTime.MinValue;
         A55DESCRIPCIONVENTA = "";
         A23NOMBRECOMPLETOEMPLEADO = "";
         A30NOMBRECOMPLETOCLIENTE = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H003114_A66IDDETALLEVENTAPRODUCTO = new long[1] ;
         H003114_A7IDPRODUCTO = new long[1] ;
         H003114_A58DESCUENTOVENTA = new decimal[1] ;
         H003114_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         H003114_A4IDCLIENTE = new long[1] ;
         H003114_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         H003114_A1IDEMPLEADO = new long[1] ;
         H003114_A55DESCRIPCIONVENTA = new string[] {""} ;
         H003114_A54FECHAVENTA = new DateTime[] {DateTime.MinValue} ;
         H003114_A12IDVENTA = new long[1] ;
         H003114_A59TOTALVENTA = new decimal[1] ;
         H003114_n59TOTALVENTA = new bool[] {false} ;
         H003114_A57IMPUESTOVENTA = new decimal[1] ;
         H003114_n57IMPUESTOVENTA = new bool[] {false} ;
         H003127_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV10TrnContext = new SdtTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV7Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6IDPRODUCTO = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventariodetalle_venta_productowc__default(),
            new Object[][] {
                new Object[] {
               H003114_A66IDDETALLEVENTAPRODUCTO, H003114_A7IDPRODUCTO, H003114_A58DESCUENTOVENTA, H003114_A30NOMBRECOMPLETOCLIENTE, H003114_A4IDCLIENTE, H003114_A23NOMBRECOMPLETOEMPLEADO, H003114_A1IDEMPLEADO, H003114_A55DESCRIPCIONVENTA, H003114_A54FECHAVENTA, H003114_A12IDVENTA,
               H003114_A59TOTALVENTA, H003114_n59TOTALVENTA, H003114_A57IMPUESTOVENTA, H003114_n57IMPUESTOVENTA
               }
               , new Object[] {
               H003127_AGRID_nRecordCount
               }
            }
         );
         AV17Pgmname = "InventarioDetalle_venta_productoWC";
         /* GeneXus formulas. */
         AV17Pgmname = "InventarioDetalle_venta_productoWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_20 ;
      private int nGXsfl_20_idx=1 ;
      private int subGrid_Rows ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int edtIDPRODUCTO_Enabled ;
      private int edtIDPRODUCTO_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long AV6IDPRODUCTO ;
      private long wcpOAV6IDPRODUCTO ;
      private long GRID_nFirstRecordOnPage ;
      private long A12IDVENTA ;
      private long A1IDEMPLEADO ;
      private long A4IDCLIENTE ;
      private long A7IDPRODUCTO ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A57IMPUESTOVENTA ;
      private decimal A58DESCUENTOVENTA ;
      private decimal A59TOTALVENTA ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_20_idx="0001" ;
      private string AV12Update ;
      private string AV13Delete ;
      private string AV17Pgmname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divTabletop_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string divGridcell_Internalname ;
      private string divGridtable_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string edtFECHAVENTA_Link ;
      private string edtNOMBRECOMPLETOEMPLEADO_Link ;
      private string edtNOMBRECOMPLETOCLIENTE_Link ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtIDPRODUCTO_Internalname ;
      private string edtIDPRODUCTO_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtIDVENTA_Internalname ;
      private string edtFECHAVENTA_Internalname ;
      private string edtDESCRIPCIONVENTA_Internalname ;
      private string edtIDEMPLEADO_Internalname ;
      private string edtNOMBRECOMPLETOEMPLEADO_Internalname ;
      private string edtIDCLIENTE_Internalname ;
      private string edtNOMBRECOMPLETOCLIENTE_Internalname ;
      private string edtIMPUESTOVENTA_Internalname ;
      private string edtDESCUENTOVENTA_Internalname ;
      private string edtTOTALVENTA_Internalname ;
      private string scmdbuf ;
      private string sCtrlAV6IDPRODUCTO ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string ROClassString ;
      private string edtIDVENTA_Jsonclick ;
      private string edtFECHAVENTA_Jsonclick ;
      private string edtDESCRIPCIONVENTA_Jsonclick ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string edtNOMBRECOMPLETOEMPLEADO_Jsonclick ;
      private string edtIDCLIENTE_Jsonclick ;
      private string edtNOMBRECOMPLETOCLIENTE_Jsonclick ;
      private string edtIMPUESTOVENTA_Jsonclick ;
      private string edtDESCUENTOVENTA_Jsonclick ;
      private string edtTOTALVENTA_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private DateTime A54FECHAVENTA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n57IMPUESTOVENTA ;
      private bool n59TOTALVENTA ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A55DESCRIPCIONVENTA ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private string A30NOMBRECOMPLETOCLIENTE ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H003114_A66IDDETALLEVENTAPRODUCTO ;
      private long[] H003114_A7IDPRODUCTO ;
      private decimal[] H003114_A58DESCUENTOVENTA ;
      private string[] H003114_A30NOMBRECOMPLETOCLIENTE ;
      private long[] H003114_A4IDCLIENTE ;
      private string[] H003114_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] H003114_A1IDEMPLEADO ;
      private string[] H003114_A55DESCRIPCIONVENTA ;
      private DateTime[] H003114_A54FECHAVENTA ;
      private long[] H003114_A12IDVENTA ;
      private decimal[] H003114_A59TOTALVENTA ;
      private bool[] H003114_n59TOTALVENTA ;
      private decimal[] H003114_A57IMPUESTOVENTA ;
      private bool[] H003114_n57IMPUESTOVENTA ;
      private long[] H003127_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV7Session ;
      private SdtTransactionContext AV10TrnContext ;
      private SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class inventariodetalle_venta_productowc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003114;
          prmH003114 = new Object[] {
          new ParDef("@AV6IDPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          string cmdBufferH003114;
          cmdBufferH003114=" SELECT T1.[IDDETALLEVENTAPRODUCTO], T1.[IDPRODUCTO], T2.[DESCUENTOVENTA], T3.[NOMBRECOMPLETOCLIENTE], T2.[IDCLIENTE], T4.[NOMBRECOMPLETOEMPLEADO], T2.[IDEMPLEADO], T2.[DESCRIPCIONVENTA], T2.[FECHAVENTA], T1.[IDVENTA], COALESCE( T5.[TOTALVENTA], 0) AS TOTALVENTA, COALESCE( T6.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA FROM ((((([Ventas_inventarioDetalle_venta] T1 INNER JOIN [Ventas_inventario] T2 ON T2.[IDVENTA] = T1.[IDVENTA]) INNER JOIN [Clientes] T3 ON T3.[IDCLIENTE] = T2.[IDCLIENTE]) INNER JOIN [Empleados] T4 ON T4.[IDEMPLEADO] = T2.[IDEMPLEADO]) INNER JOIN (SELECT COALESCE( T9.[GXC3], 0) + COALESCE( T8.[IMPUESTOVENTA], 0) - T7.[DESCUENTOVENTA] AS TOTALVENTA, T7.[IDVENTA] FROM (([Ventas_inventario] T7 LEFT JOIN (SELECT COALESCE( T11.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T10.[IDVENTA] FROM ([Ventas_inventario] T10 LEFT JOIN (SELECT SUM(COALESCE( T13.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T12.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T12 LEFT JOIN (SELECT COALESCE( T15.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T14.[IDVENTA], T14.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T14 LEFT JOIN (SELECT SUM(T17.[CANTIDADPRODUCTO] * CAST(T17.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T16.[IDVENTA], T16.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T16 INNER JOIN [Inventario] T17 ON T17.[IDPRODUCTO] = T16.[IDPRODUCTO]) GROUP BY T16.[IDVENTA], T16.[IDDETALLEVENTAPRODUCTO] ) T15 ON T15.[IDVENTA] = T14.[IDVENTA] AND T15.[IDDETALLEVENTAPRODUCTO] = T14.[IDDETALLEVENTAPRODUCTO]) ) T13 ON T13.[IDVENTA] = T12.[IDVENTA] AND T13.[IDDETALLEVENTAPRODUCTO] = T12.[IDDETALLEVENTAPRODUCTO]) GROUP BY T12.[IDVENTA] ) T11 ON T11.[IDVENTA] = T10.[IDVENTA]) ) T8 ON T8.[IDVENTA] = T7.[IDVENTA]) LEFT JOIN (SELECT SUM(COALESCE( T11.[SUBTOTALVENTAPRODUCTO], "
          + " 0)) AS GXC3, T10.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T10 LEFT JOIN (SELECT COALESCE( T13.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T12.[IDVENTA], T12.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T12 LEFT JOIN (SELECT SUM(T15.[CANTIDADPRODUCTO] * CAST(T15.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T14.[IDVENTA], T14.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T14 INNER JOIN [Inventario] T15 ON T15.[IDPRODUCTO] = T14.[IDPRODUCTO]) GROUP BY T14.[IDVENTA], T14.[IDDETALLEVENTAPRODUCTO] ) T13 ON T13.[IDVENTA] = T12.[IDVENTA] AND T13.[IDDETALLEVENTAPRODUCTO] = T12.[IDDETALLEVENTAPRODUCTO]) ) T11 ON T11.[IDVENTA] = T10.[IDVENTA] AND T11.[IDDETALLEVENTAPRODUCTO] = T10.[IDDETALLEVENTAPRODUCTO]) GROUP BY T10.[IDVENTA] ) T9 ON T9.[IDVENTA] = T7.[IDVENTA]) ) T5 ON T5.[IDVENTA] = T1.[IDVENTA]) LEFT JOIN (SELECT COALESCE( T8.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T7.[IDVENTA] FROM ([Ventas_inventario] T7 LEFT JOIN (SELECT SUM(COALESCE( T10.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T9.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T9 LEFT JOIN (SELECT COALESCE( T12.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T11.[IDVENTA], T11.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T11 LEFT JOIN (SELECT SUM(T14.[CANTIDADPRODUCTO] * CAST(T14.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T13 INNER JOIN [Inventario] T14 ON T14.[IDPRODUCTO] = T13.[IDPRODUCTO]) GROUP BY T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] ) T12 ON T12.[IDVENTA] = T11.[IDVENTA] AND T12.[IDDETALLEVENTAPRODUCTO] = T11.[IDDETALLEVENTAPRODUCTO]) ) T10 ON T10.[IDVENTA] = T9.[IDVENTA] AND T10.[IDDETALLEVENTAPRODUCTO] = T9.[IDDETALLEVENTAPRODUCTO]) GROUP BY"
          + " T9.[IDVENTA] ) T8 ON T8.[IDVENTA] = T7.[IDVENTA]) ) T6 ON T6.[IDVENTA] = T1.[IDVENTA]) WHERE T1.[IDPRODUCTO] = @AV6IDPRODUCTO ORDER BY T1.[IDPRODUCTO]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY" ;
          Object[] prmH003127;
          prmH003127 = new Object[] {
          new ParDef("@AV6IDPRODUCTO",GXType.Decimal,12,0)
          };
          string cmdBufferH003127;
          cmdBufferH003127=" SELECT COUNT(*) FROM ((((([Ventas_inventarioDetalle_venta] T1 INNER JOIN [Ventas_inventario] T2 ON T2.[IDVENTA] = T1.[IDVENTA]) INNER JOIN [Clientes] T4 ON T4.[IDCLIENTE] = T2.[IDCLIENTE]) INNER JOIN [Empleados] T3 ON T3.[IDEMPLEADO] = T2.[IDEMPLEADO]) INNER JOIN (SELECT COALESCE( T9.[GXC3], 0) + COALESCE( T8.[IMPUESTOVENTA], 0) - T7.[DESCUENTOVENTA] AS TOTALVENTA, T7.[IDVENTA] FROM (([Ventas_inventario] T7 LEFT JOIN (SELECT COALESCE( T11.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T10.[IDVENTA] FROM ([Ventas_inventario] T10 LEFT JOIN (SELECT SUM(COALESCE( T13.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T12.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T12 LEFT JOIN (SELECT COALESCE( T15.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T14.[IDVENTA], T14.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T14 LEFT JOIN (SELECT SUM(T17.[CANTIDADPRODUCTO] * CAST(T17.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T16.[IDVENTA], T16.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T16 INNER JOIN [Inventario] T17 ON T17.[IDPRODUCTO] = T16.[IDPRODUCTO]) GROUP BY T16.[IDVENTA], T16.[IDDETALLEVENTAPRODUCTO] ) T15 ON T15.[IDVENTA] = T14.[IDVENTA] AND T15.[IDDETALLEVENTAPRODUCTO] = T14.[IDDETALLEVENTAPRODUCTO]) ) T13 ON T13.[IDVENTA] = T12.[IDVENTA] AND T13.[IDDETALLEVENTAPRODUCTO] = T12.[IDDETALLEVENTAPRODUCTO]) GROUP BY T12.[IDVENTA] ) T11 ON T11.[IDVENTA] = T10.[IDVENTA]) ) T8 ON T8.[IDVENTA] = T7.[IDVENTA]) LEFT JOIN (SELECT SUM(COALESCE( T11.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T10.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T10 LEFT JOIN (SELECT COALESCE( T13.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T12.[IDVENTA], T12.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T12 LEFT JOIN (SELECT SUM(T15.[CANTIDADPRODUCTO] * CAST(T15.[PRECIOVENTAPRODUCTO] "
          + " AS decimal( 22, 10))) AS GXC5, T14.[IDVENTA], T14.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T14 INNER JOIN [Inventario] T15 ON T15.[IDPRODUCTO] = T14.[IDPRODUCTO]) GROUP BY T14.[IDVENTA], T14.[IDDETALLEVENTAPRODUCTO] ) T13 ON T13.[IDVENTA] = T12.[IDVENTA] AND T13.[IDDETALLEVENTAPRODUCTO] = T12.[IDDETALLEVENTAPRODUCTO]) ) T11 ON T11.[IDVENTA] = T10.[IDVENTA] AND T11.[IDDETALLEVENTAPRODUCTO] = T10.[IDDETALLEVENTAPRODUCTO]) GROUP BY T10.[IDVENTA] ) T9 ON T9.[IDVENTA] = T7.[IDVENTA]) ) T5 ON T5.[IDVENTA] = T1.[IDVENTA]) LEFT JOIN (SELECT COALESCE( T8.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T7.[IDVENTA] FROM ([Ventas_inventario] T7 LEFT JOIN (SELECT SUM(COALESCE( T10.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T9.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T9 LEFT JOIN (SELECT COALESCE( T12.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T11.[IDVENTA], T11.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T11 LEFT JOIN (SELECT SUM(T14.[CANTIDADPRODUCTO] * CAST(T14.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T13 INNER JOIN [Inventario] T14 ON T14.[IDPRODUCTO] = T13.[IDPRODUCTO]) GROUP BY T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] ) T12 ON T12.[IDVENTA] = T11.[IDVENTA] AND T12.[IDDETALLEVENTAPRODUCTO] = T11.[IDDETALLEVENTAPRODUCTO]) ) T10 ON T10.[IDVENTA] = T9.[IDVENTA] AND T10.[IDDETALLEVENTAPRODUCTO] = T9.[IDDETALLEVENTAPRODUCTO]) GROUP BY T9.[IDVENTA] ) T8 ON T8.[IDVENTA] = T7.[IDVENTA]) ) T6 ON T6.[IDVENTA] = T1.[IDVENTA]) WHERE T1.[IDPRODUCTO] = @AV6IDPRODUCTO" ;
          def= new CursorDef[] {
              new CursorDef("H003114", cmdBufferH003114,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003114,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003127", cmdBufferH003127,false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003127,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
