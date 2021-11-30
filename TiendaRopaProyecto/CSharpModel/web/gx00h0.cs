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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx00h0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00h0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx00h0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pIDCOMPRA )
      {
         this.AV10pIDCOMPRA = 0 ;
         executePrivate();
         aP0_pIDCOMPRA=this.AV10pIDCOMPRA;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pIDCOMPRA");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pIDCOMPRA");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pIDCOMPRA");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_54 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_54"), "."));
               nGXsfl_54_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_54_idx"), "."));
               sGXsfl_54_idx = GetPar( "sGXsfl_54_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
               AV6cIDCOMPRA = (long)(NumberUtil.Val( GetPar( "cIDCOMPRA"), "."));
               AV7cFECHACOMPRA = context.localUtil.ParseDateParm( GetPar( "cFECHACOMPRA"));
               AV8cIDPROVEEDOR = (long)(NumberUtil.Val( GetPar( "cIDPROVEEDOR"), "."));
               AV9cIDEMPLEADO = (long)(NumberUtil.Val( GetPar( "cIDEMPLEADO"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "IDCOMPRAFILTERCONTAINER_Class", StringUtil.RTrim( divIdcomprafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "FECHACOMPRAFILTERCONTAINER_Class", StringUtil.RTrim( divFechacomprafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "IDPROVEEDORFILTERCONTAINER_Class", StringUtil.RTrim( divIdproveedorfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "IDEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdempleadofiltercontainer_Class));
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV10pIDCOMPRA = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV10pIDCOMPRA", StringUtil.LTrimStr( (decimal)(AV10pIDCOMPRA), 12, 0));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA2D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2D2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1152180), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202111301231261", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pIDCOMPRA,12,0))}, new string[] {"pIDCOMPRA"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCIDCOMPRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDCOMPRA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFECHACOMPRA", context.localUtil.Format(AV7cFECHACOMPRA, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCIDPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cIDPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCIDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cIDEMPLEADO), 12, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_54", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_54), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPIDCOMPRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pIDCOMPRA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "IDCOMPRAFILTERCONTAINER_Class", StringUtil.RTrim( divIdcomprafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FECHACOMPRAFILTERCONTAINER_Class", StringUtil.RTrim( divFechacomprafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IDPROVEEDORFILTERCONTAINER_Class", StringUtil.RTrim( divIdproveedorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IDEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdempleadofiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2D2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx00h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pIDCOMPRA,12,0))}, new string[] {"pIDCOMPRA"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00H0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Compra_inventario" ;
      }

      protected void WB2D0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divIdcomprafiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdcomprafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidcomprafilter_Internalname, "IDCOMPRA", "", "", lblLblidcomprafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidcompra_Internalname, "IDCOMPRA", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidcompra_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDCOMPRA), 12, 0, ".", "")), ((edtavCidcompra_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cIDCOMPRA), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cIDCOMPRA), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidcompra_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidcompra_Visible, edtavCidcompra_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divFechacomprafiltercontainer_Internalname, 1, 0, "px", 0, "px", divFechacomprafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfechacomprafilter_Internalname, "FECHACOMPRA", "", "", lblLblfechacomprafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e122d1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfechacompra_Internalname, "FECHACOMPRA", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_54_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCfechacompra_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCfechacompra_Internalname, context.localUtil.Format(AV7cFECHACOMPRA, "99/99/99"), context.localUtil.Format( AV7cFECHACOMPRA, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfechacompra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCfechacompra_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divIdproveedorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdproveedorfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidproveedorfilter_Internalname, "IDPROVEEDOR", "", "", lblLblidproveedorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e132d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidproveedor_Internalname, "IDPROVEEDOR", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidproveedor_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cIDPROVEEDOR), 12, 0, ".", "")), ((edtavCidproveedor_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8cIDPROVEEDOR), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV8cIDPROVEEDOR), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidproveedor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidproveedor_Visible, edtavCidproveedor_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divIdempleadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdempleadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidempleadofilter_Internalname, "IDEMPLEADO", "", "", lblLblidempleadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e142d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidempleado_Internalname, "IDEMPLEADO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidempleado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cIDEMPLEADO), 12, 0, ".", "")), ((edtavCidempleado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9cIDEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV9cIDEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidempleado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidempleado_Visible, edtavCidempleado_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e152d1_client"+"'", TempTags, "", 2, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"54\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDCOMPRA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "FECHACOMPRA") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDPROVEEDOR") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDEMPLEADO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtFECHACOMPRA_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10IDPROVEEDOR), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 54 )
         {
            wbEnd = 0;
            nRC_GXsfl_54 = (int)(nGXsfl_54_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 54 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2D2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_5-152925", 0) ;
            }
            Form.Meta.addItem("description", "Selection List Compra_inventario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2D0( ) ;
      }

      protected void WS2D2( )
      {
         START2D2( ) ;
         EVT2D2( ) ;
      }

      protected void EVT2D2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_54_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
                              SubsflControlProps_542( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_54_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( edtIDCOMPRA_Internalname), ".", ","));
                              A50FECHACOMPRA = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFECHACOMPRA_Internalname), 0));
                              A10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ","));
                              A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E162D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E172D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cidcompra Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDCOMPRA"), ".", ",") != Convert.ToDecimal( AV6cIDCOMPRA )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfechacompra Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCFECHACOMPRA"), 0) != AV7cFECHACOMPRA )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cidproveedor Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDPROVEEDOR"), ".", ",") != Convert.ToDecimal( AV8cIDPROVEEDOR )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cidempleado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDEMPLEADO"), ".", ",") != Convert.ToDecimal( AV9cIDEMPLEADO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E182D2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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

      protected void WE2D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA2D2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_542( ) ;
         while ( nGXsfl_54_idx <= nRC_GXsfl_54 )
         {
            sendrow_542( ) ;
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cIDCOMPRA ,
                                        DateTime AV7cFECHACOMPRA ,
                                        long AV8cIDPROVEEDOR ,
                                        long AV9cIDEMPLEADO )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDCOMPRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "IDCOMPRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")));
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
         RF2D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF2D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 54;
         nGXsfl_54_idx = 1;
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_542( ) ;
         bGXsfl_54_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_542( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cFECHACOMPRA ,
                                                 AV8cIDPROVEEDOR ,
                                                 AV9cIDEMPLEADO ,
                                                 A50FECHACOMPRA ,
                                                 A10IDPROVEEDOR ,
                                                 A1IDEMPLEADO ,
                                                 AV6cIDCOMPRA } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H002D2 */
            pr_default.execute(0, new Object[] {AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_54_idx = 1;
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A1IDEMPLEADO = H002D2_A1IDEMPLEADO[0];
               A10IDPROVEEDOR = H002D2_A10IDPROVEEDOR[0];
               A50FECHACOMPRA = H002D2_A50FECHACOMPRA[0];
               A11IDCOMPRA = H002D2_A11IDCOMPRA[0];
               /* Execute user event: Load */
               E172D2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 54;
            WB2D0( ) ;
         }
         bGXsfl_54_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2D2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDCOMPRA"+"_"+sGXsfl_54_idx, GetSecureSignedToken( sGXsfl_54_idx, context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cFECHACOMPRA ,
                                              AV8cIDPROVEEDOR ,
                                              AV9cIDEMPLEADO ,
                                              A50FECHACOMPRA ,
                                              A10IDPROVEEDOR ,
                                              A1IDEMPLEADO ,
                                              AV6cIDCOMPRA } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H002D3 */
         pr_default.execute(1, new Object[] {AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO});
         GRID1_nRecordCount = H002D3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCOMPRA, AV7cFECHACOMPRA, AV8cIDPROVEEDOR, AV9cIDEMPLEADO) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_54 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_54"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidcompra_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidcompra_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDCOMPRA");
               GX_FocusControl = edtavCidcompra_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cIDCOMPRA = 0;
               AssignAttri("", false, "AV6cIDCOMPRA", StringUtil.LTrimStr( (decimal)(AV6cIDCOMPRA), 12, 0));
            }
            else
            {
               AV6cIDCOMPRA = (long)(context.localUtil.CToN( cgiGet( edtavCidcompra_Internalname), ".", ","));
               AssignAttri("", false, "AV6cIDCOMPRA", StringUtil.LTrimStr( (decimal)(AV6cIDCOMPRA), 12, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCfechacompra_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FECHACOMPRA"}), 1, "vCFECHACOMPRA");
               GX_FocusControl = edtavCfechacompra_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cFECHACOMPRA = DateTime.MinValue;
               AssignAttri("", false, "AV7cFECHACOMPRA", context.localUtil.Format(AV7cFECHACOMPRA, "99/99/99"));
            }
            else
            {
               AV7cFECHACOMPRA = context.localUtil.CToD( cgiGet( edtavCfechacompra_Internalname), 1);
               AssignAttri("", false, "AV7cFECHACOMPRA", context.localUtil.Format(AV7cFECHACOMPRA, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidproveedor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidproveedor_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDPROVEEDOR");
               GX_FocusControl = edtavCidproveedor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cIDPROVEEDOR = 0;
               AssignAttri("", false, "AV8cIDPROVEEDOR", StringUtil.LTrimStr( (decimal)(AV8cIDPROVEEDOR), 12, 0));
            }
            else
            {
               AV8cIDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtavCidproveedor_Internalname), ".", ","));
               AssignAttri("", false, "AV8cIDPROVEEDOR", StringUtil.LTrimStr( (decimal)(AV8cIDPROVEEDOR), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidempleado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidempleado_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDEMPLEADO");
               GX_FocusControl = edtavCidempleado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cIDEMPLEADO = 0;
               AssignAttri("", false, "AV9cIDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV9cIDEMPLEADO), 12, 0));
            }
            else
            {
               AV9cIDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtavCidempleado_Internalname), ".", ","));
               AssignAttri("", false, "AV9cIDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV9cIDEMPLEADO), 12, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDCOMPRA"), ".", ",") != Convert.ToDecimal( AV6cIDCOMPRA )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCFECHACOMPRA"), 1) != AV7cFECHACOMPRA )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDPROVEEDOR"), ".", ",") != Convert.ToDecimal( AV8cIDPROVEEDOR )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDEMPLEADO"), ".", ",") != Convert.ToDecimal( AV9cIDEMPLEADO )) )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E162D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E162D2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Compra_inventario", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV11ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E172D2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_542( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_54_Refreshing )
         {
            context.DoAjaxLoad(54, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E182D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182D2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10pIDCOMPRA = A11IDCOMPRA;
         AssignAttri("", false, "AV10pIDCOMPRA", StringUtil.LTrimStr( (decimal)(AV10pIDCOMPRA), 12, 0));
         context.setWebReturnParms(new Object[] {(long)AV10pIDCOMPRA});
         context.setWebReturnParmsMetadata(new Object[] {"AV10pIDCOMPRA"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10pIDCOMPRA = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV10pIDCOMPRA", StringUtil.LTrimStr( (decimal)(AV10pIDCOMPRA), 12, 0));
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
         PA2D2( ) ;
         WS2D2( ) ;
         WE2D2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202111301231290", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx00h0.js", "?202111301231290", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_idx;
         edtIDCOMPRA_Internalname = "IDCOMPRA_"+sGXsfl_54_idx;
         edtFECHACOMPRA_Internalname = "FECHACOMPRA_"+sGXsfl_54_idx;
         edtIDPROVEEDOR_Internalname = "IDPROVEEDOR_"+sGXsfl_54_idx;
         edtIDEMPLEADO_Internalname = "IDEMPLEADO_"+sGXsfl_54_idx;
      }

      protected void SubsflControlProps_fel_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_fel_idx;
         edtIDCOMPRA_Internalname = "IDCOMPRA_"+sGXsfl_54_fel_idx;
         edtFECHACOMPRA_Internalname = "FECHACOMPRA_"+sGXsfl_54_fel_idx;
         edtIDPROVEEDOR_Internalname = "IDPROVEEDOR_"+sGXsfl_54_fel_idx;
         edtIDEMPLEADO_Internalname = "IDEMPLEADO_"+sGXsfl_54_fel_idx;
      }

      protected void sendrow_542( )
      {
         SubsflControlProps_542( ) ;
         WB2D0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_54_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_54_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_54_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_54_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDCOMPRA_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDCOMPRA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtFECHACOMPRA_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtFECHACOMPRA_Internalname, "Link", edtFECHACOMPRA_Link, !bGXsfl_54_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFECHACOMPRA_Internalname,context.localUtil.Format(A50FECHACOMPRA, "99/99/99"),context.localUtil.Format( A50FECHACOMPRA, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtFECHACOMPRA_Link,(string)"",(string)"",(string)"",(string)edtFECHACOMPRA_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDPROVEEDOR_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10IDPROVEEDOR), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDPROVEEDOR_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDEMPLEADO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)54,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2D2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         /* End function sendrow_542 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblidcomprafilter_Internalname = "LBLIDCOMPRAFILTER";
         edtavCidcompra_Internalname = "vCIDCOMPRA";
         divIdcomprafiltercontainer_Internalname = "IDCOMPRAFILTERCONTAINER";
         lblLblfechacomprafilter_Internalname = "LBLFECHACOMPRAFILTER";
         edtavCfechacompra_Internalname = "vCFECHACOMPRA";
         divFechacomprafiltercontainer_Internalname = "FECHACOMPRAFILTERCONTAINER";
         lblLblidproveedorfilter_Internalname = "LBLIDPROVEEDORFILTER";
         edtavCidproveedor_Internalname = "vCIDPROVEEDOR";
         divIdproveedorfiltercontainer_Internalname = "IDPROVEEDORFILTERCONTAINER";
         lblLblidempleadofilter_Internalname = "LBLIDEMPLEADOFILTER";
         edtavCidempleado_Internalname = "vCIDEMPLEADO";
         divIdempleadofiltercontainer_Internalname = "IDEMPLEADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtIDCOMPRA_Internalname = "IDCOMPRA";
         edtFECHACOMPRA_Internalname = "FECHACOMPRA";
         edtIDPROVEEDOR_Internalname = "IDPROVEEDOR";
         edtIDEMPLEADO_Internalname = "IDEMPLEADO";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtIDEMPLEADO_Jsonclick = "";
         edtIDPROVEEDOR_Jsonclick = "";
         edtFECHACOMPRA_Jsonclick = "";
         edtIDCOMPRA_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtFECHACOMPRA_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCidempleado_Jsonclick = "";
         edtavCidempleado_Enabled = 1;
         edtavCidempleado_Visible = 1;
         edtavCidproveedor_Jsonclick = "";
         edtavCidproveedor_Enabled = 1;
         edtavCidproveedor_Visible = 1;
         edtavCfechacompra_Jsonclick = "";
         edtavCfechacompra_Enabled = 1;
         edtavCidcompra_Jsonclick = "";
         edtavCidcompra_Enabled = 1;
         edtavCidcompra_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Compra_inventario";
         divIdempleadofiltercontainer_Class = "AdvancedContainerItem";
         divIdproveedorfiltercontainer_Class = "AdvancedContainerItem";
         divFechacomprafiltercontainer_Class = "AdvancedContainerItem";
         divIdcomprafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCOMPRA',fld:'vCIDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'AV7cFECHACOMPRA',fld:'vCFECHACOMPRA',pic:''},{av:'AV8cIDPROVEEDOR',fld:'vCIDPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'AV9cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E152D1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLIDCOMPRAFILTER.CLICK","{handler:'E112D1',iparms:[{av:'divIdcomprafiltercontainer_Class',ctrl:'IDCOMPRAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDCOMPRAFILTER.CLICK",",oparms:[{av:'divIdcomprafiltercontainer_Class',ctrl:'IDCOMPRAFILTERCONTAINER',prop:'Class'},{av:'edtavCidcompra_Visible',ctrl:'vCIDCOMPRA',prop:'Visible'}]}");
         setEventMetadata("LBLFECHACOMPRAFILTER.CLICK","{handler:'E122D1',iparms:[{av:'divFechacomprafiltercontainer_Class',ctrl:'FECHACOMPRAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFECHACOMPRAFILTER.CLICK",",oparms:[{av:'divFechacomprafiltercontainer_Class',ctrl:'FECHACOMPRAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLIDPROVEEDORFILTER.CLICK","{handler:'E132D1',iparms:[{av:'divIdproveedorfiltercontainer_Class',ctrl:'IDPROVEEDORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDPROVEEDORFILTER.CLICK",",oparms:[{av:'divIdproveedorfiltercontainer_Class',ctrl:'IDPROVEEDORFILTERCONTAINER',prop:'Class'},{av:'edtavCidproveedor_Visible',ctrl:'vCIDPROVEEDOR',prop:'Visible'}]}");
         setEventMetadata("LBLIDEMPLEADOFILTER.CLICK","{handler:'E142D1',iparms:[{av:'divIdempleadofiltercontainer_Class',ctrl:'IDEMPLEADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDEMPLEADOFILTER.CLICK",",oparms:[{av:'divIdempleadofiltercontainer_Class',ctrl:'IDEMPLEADOFILTERCONTAINER',prop:'Class'},{av:'edtavCidempleado_Visible',ctrl:'vCIDEMPLEADO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E182D2',iparms:[{av:'A11IDCOMPRA',fld:'IDCOMPRA',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV10pIDCOMPRA',fld:'vPIDCOMPRA',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCOMPRA',fld:'vCIDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'AV7cFECHACOMPRA',fld:'vCFECHACOMPRA',pic:''},{av:'AV8cIDPROVEEDOR',fld:'vCIDPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'AV9cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCOMPRA',fld:'vCIDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'AV7cFECHACOMPRA',fld:'vCFECHACOMPRA',pic:''},{av:'AV8cIDPROVEEDOR',fld:'vCIDPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'AV9cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCOMPRA',fld:'vCIDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'AV7cFECHACOMPRA',fld:'vCFECHACOMPRA',pic:''},{av:'AV8cIDPROVEEDOR',fld:'vCIDPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'AV9cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCOMPRA',fld:'vCIDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'AV7cFECHACOMPRA',fld:'vCFECHACOMPRA',pic:''},{av:'AV8cIDPROVEEDOR',fld:'vCIDPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'AV9cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CFECHACOMPRA","{handler:'Validv_Cfechacompra',iparms:[]");
         setEventMetadata("VALIDV_CFECHACOMPRA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Idempleado',iparms:[]");
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
         AV7cFECHACOMPRA = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblidcomprafilter_Jsonclick = "";
         TempTags = "";
         lblLblfechacomprafilter_Jsonclick = "";
         lblLblidproveedorfilter_Jsonclick = "";
         lblLblidempleadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A50FECHACOMPRA = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV14Linkselection_GXI = "";
         scmdbuf = "";
         H002D2_A1IDEMPLEADO = new long[1] ;
         H002D2_A10IDPROVEEDOR = new long[1] ;
         H002D2_A50FECHACOMPRA = new DateTime[] {DateTime.MinValue} ;
         H002D2_A11IDCOMPRA = new long[1] ;
         H002D3_AGRID1_nRecordCount = new long[1] ;
         AV11ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00h0__default(),
            new Object[][] {
                new Object[] {
               H002D2_A1IDEMPLEADO, H002D2_A10IDPROVEEDOR, H002D2_A50FECHACOMPRA, H002D2_A11IDCOMPRA
               }
               , new Object[] {
               H002D3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_54 ;
      private int nGXsfl_54_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCidcompra_Enabled ;
      private int edtavCidcompra_Visible ;
      private int edtavCfechacompra_Enabled ;
      private int edtavCidproveedor_Enabled ;
      private int edtavCidproveedor_Visible ;
      private int edtavCidempleado_Enabled ;
      private int edtavCidempleado_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long AV10pIDCOMPRA ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cIDCOMPRA ;
      private long AV8cIDPROVEEDOR ;
      private long AV9cIDEMPLEADO ;
      private long A11IDCOMPRA ;
      private long A10IDPROVEEDOR ;
      private long A1IDEMPLEADO ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divIdcomprafiltercontainer_Class ;
      private string divFechacomprafiltercontainer_Class ;
      private string divIdproveedorfiltercontainer_Class ;
      private string divIdempleadofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_54_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divIdcomprafiltercontainer_Internalname ;
      private string lblLblidcomprafilter_Internalname ;
      private string lblLblidcomprafilter_Jsonclick ;
      private string edtavCidcompra_Internalname ;
      private string TempTags ;
      private string edtavCidcompra_Jsonclick ;
      private string divFechacomprafiltercontainer_Internalname ;
      private string lblLblfechacomprafilter_Internalname ;
      private string lblLblfechacomprafilter_Jsonclick ;
      private string edtavCfechacompra_Internalname ;
      private string edtavCfechacompra_Jsonclick ;
      private string divIdproveedorfiltercontainer_Internalname ;
      private string lblLblidproveedorfilter_Internalname ;
      private string lblLblidproveedorfilter_Jsonclick ;
      private string edtavCidproveedor_Internalname ;
      private string edtavCidproveedor_Jsonclick ;
      private string divIdempleadofiltercontainer_Internalname ;
      private string lblLblidempleadofilter_Internalname ;
      private string lblLblidempleadofilter_Jsonclick ;
      private string edtavCidempleado_Internalname ;
      private string edtavCidempleado_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string edtFECHACOMPRA_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtIDCOMPRA_Internalname ;
      private string edtFECHACOMPRA_Internalname ;
      private string edtIDPROVEEDOR_Internalname ;
      private string edtIDEMPLEADO_Internalname ;
      private string scmdbuf ;
      private string AV11ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_54_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtIDCOMPRA_Jsonclick ;
      private string edtFECHACOMPRA_Jsonclick ;
      private string edtIDPROVEEDOR_Jsonclick ;
      private string edtIDEMPLEADO_Jsonclick ;
      private DateTime AV7cFECHACOMPRA ;
      private DateTime A50FECHACOMPRA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_54_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H002D2_A1IDEMPLEADO ;
      private long[] H002D2_A10IDPROVEEDOR ;
      private DateTime[] H002D2_A50FECHACOMPRA ;
      private long[] H002D2_A11IDCOMPRA ;
      private long[] H002D3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pIDCOMPRA ;
      private GXWebForm Form ;
   }

   public class gx00h0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002D2( IGxContext context ,
                                             DateTime AV7cFECHACOMPRA ,
                                             long AV8cIDPROVEEDOR ,
                                             long AV9cIDEMPLEADO ,
                                             DateTime A50FECHACOMPRA ,
                                             long A10IDPROVEEDOR ,
                                             long A1IDEMPLEADO ,
                                             long AV6cIDCOMPRA )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [IDEMPLEADO], [IDPROVEEDOR], [FECHACOMPRA], [IDCOMPRA]";
         sFromString = " FROM [Compra_inventario]";
         sOrderString = "";
         AddWhere(sWhereString, "([IDCOMPRA] >= @AV6cIDCOMPRA)");
         if ( ! (DateTime.MinValue==AV7cFECHACOMPRA) )
         {
            AddWhere(sWhereString, "([FECHACOMPRA] >= @AV7cFECHACOMPRA)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cIDPROVEEDOR) )
         {
            AddWhere(sWhereString, "([IDPROVEEDOR] >= @AV8cIDPROVEEDOR)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cIDEMPLEADO) )
         {
            AddWhere(sWhereString, "([IDEMPLEADO] >= @AV9cIDEMPLEADO)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         sOrderString += " ORDER BY [IDCOMPRA]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002D3( IGxContext context ,
                                             DateTime AV7cFECHACOMPRA ,
                                             long AV8cIDPROVEEDOR ,
                                             long AV9cIDEMPLEADO ,
                                             DateTime A50FECHACOMPRA ,
                                             long A10IDPROVEEDOR ,
                                             long A1IDEMPLEADO ,
                                             long AV6cIDCOMPRA )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Compra_inventario]";
         AddWhere(sWhereString, "([IDCOMPRA] >= @AV6cIDCOMPRA)");
         if ( ! (DateTime.MinValue==AV7cFECHACOMPRA) )
         {
            AddWhere(sWhereString, "([FECHACOMPRA] >= @AV7cFECHACOMPRA)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cIDPROVEEDOR) )
         {
            AddWhere(sWhereString, "([IDPROVEEDOR] >= @AV8cIDPROVEEDOR)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cIDEMPLEADO) )
         {
            AddWhere(sWhereString, "([IDEMPLEADO] >= @AV9cIDEMPLEADO)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002D2(context, (DateTime)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] );
               case 1 :
                     return conditional_H002D3(context, (DateTime)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH002D2;
          prmH002D2 = new Object[] {
          new ParDef("@AV6cIDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@AV7cFECHACOMPRA",GXType.Date,8,0) ,
          new ParDef("@AV8cIDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@AV9cIDEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002D3;
          prmH002D3 = new Object[] {
          new ParDef("@AV6cIDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@AV7cFECHACOMPRA",GXType.Date,8,0) ,
          new ParDef("@AV8cIDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@AV9cIDEMPLEADO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
