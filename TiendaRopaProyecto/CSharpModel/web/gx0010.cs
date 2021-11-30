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
   public class gx0010 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0010( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0010( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pIDEMPLEADO )
      {
         this.AV13pIDEMPLEADO = 0 ;
         executePrivate();
         aP0_pIDEMPLEADO=this.AV13pIDEMPLEADO;
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
            gxfirstwebparm = GetFirstPar( "pIDEMPLEADO");
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
               gxfirstwebparm = GetFirstPar( "pIDEMPLEADO");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pIDEMPLEADO");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_64 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."));
               nGXsfl_64_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."));
               sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
               AV6cIDEMPLEADO = (long)(NumberUtil.Val( GetPar( "cIDEMPLEADO"), "."));
               AV10cTELEFONOEMPLEADO = GetPar( "cTELEFONOEMPLEADO");
               AV11cFECHACONTRATACIONEMPLEADO = context.localUtil.ParseDateParm( GetPar( "cFECHACONTRATACIONEMPLEADO"));
               AV15cIDTIPOEMPLEADO = (long)(NumberUtil.Val( GetPar( "cIDTIPOEMPLEADO"), "."));
               AV16cIDESTADOEMPLEADO = (long)(NumberUtil.Val( GetPar( "cIDESTADOEMPLEADO"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cIDEMPLEADO, AV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "IDEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdempleadofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TELEFONOEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divTelefonoempleadofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "FECHACONTRATACIONEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divFechacontratacionempleadofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "IDTIPOEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdtipoempleadofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "IDESTADOEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdestadoempleadofiltercontainer_Class));
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
               AV13pIDEMPLEADO = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pIDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV13pIDEMPLEADO), 12, 0));
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
         PA1R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1R2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021113014131263", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0010.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pIDEMPLEADO,12,0))}, new string[] {"pIDEMPLEADO"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCIDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTELEFONOEMPLEADO", StringUtil.RTrim( AV10cTELEFONOEMPLEADO));
         GxWebStd.gx_hidden_field( context, "GXH_vCFECHACONTRATACIONEMPLEADO", context.localUtil.Format(AV11cFECHACONTRATACIONEMPLEADO, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCIDTIPOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cIDTIPOEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCIDESTADOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cIDESTADOEMPLEADO), 12, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPIDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pIDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "IDEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdempleadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TELEFONOEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divTelefonoempleadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FECHACONTRATACIONEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divFechacontratacionempleadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IDTIPOEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdtipoempleadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IDESTADOEMPLEADOFILTERCONTAINER_Class", StringUtil.RTrim( divIdestadoempleadofiltercontainer_Class));
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
            WE1R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1R2( ) ;
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
         return formatLink("gx0010.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pIDEMPLEADO,12,0))}, new string[] {"pIDEMPLEADO"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0010" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Empleados" ;
      }

      protected void WB1R0( )
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
            GxWebStd.gx_div_start( context, divIdempleadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdempleadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidempleadofilter_Internalname, "IDEMPLEADO", "", "", lblLblidempleadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidempleado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDEMPLEADO), 12, 0, ".", "")), ((edtavCidempleado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cIDEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cIDEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidempleado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidempleado_Visible, edtavCidempleado_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divTelefonoempleadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTelefonoempleadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltelefonoempleadofilter_Internalname, "TELEFONOEMPLEADO", "", "", lblLbltelefonoempleadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtelefonoempleado_Internalname, "TELEFONOEMPLEADO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtelefonoempleado_Internalname, StringUtil.RTrim( AV10cTELEFONOEMPLEADO), StringUtil.RTrim( context.localUtil.Format( AV10cTELEFONOEMPLEADO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtelefonoempleado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtelefonoempleado_Visible, edtavCtelefonoempleado_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divFechacontratacionempleadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divFechacontratacionempleadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfechacontratacionempleadofilter_Internalname, "FECHACONTRATACIONEMPLEADO", "", "", lblLblfechacontratacionempleadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131r1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfechacontratacionempleado_Internalname, "FECHACONTRATACIONEMPLEADO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCfechacontratacionempleado_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCfechacontratacionempleado_Internalname, context.localUtil.Format(AV11cFECHACONTRATACIONEMPLEADO, "99/99/99"), context.localUtil.Format( AV11cFECHACONTRATACIONEMPLEADO, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfechacontratacionempleado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCfechacontratacionempleado_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divIdtipoempleadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdtipoempleadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidtipoempleadofilter_Internalname, "IDTIPOEMPLEADO", "", "", lblLblidtipoempleadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidtipoempleado_Internalname, "IDTIPOEMPLEADO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidtipoempleado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cIDTIPOEMPLEADO), 12, 0, ".", "")), ((edtavCidtipoempleado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15cIDTIPOEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV15cIDTIPOEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidtipoempleado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidtipoempleado_Visible, edtavCidtipoempleado_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
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
            GxWebStd.gx_div_start( context, divIdestadoempleadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdestadoempleadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidestadoempleadofilter_Internalname, "IDESTADOEMPLEADO", "", "", lblLblidestadoempleadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151r1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidestadoempleado_Internalname, "IDESTADOEMPLEADO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidestadoempleado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cIDESTADOEMPLEADO), 12, 0, ".", "")), ((edtavCidestadoempleado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16cIDESTADOEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV16cIDESTADOEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidestadoempleado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidestadoempleado_Visible, edtavCidestadoempleado_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0010.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161r1_client"+"'", TempTags, "", 2, "HLP_Gx0010.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
               context.SendWebValue( "IDEMPLEADO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "TELEFONOEMPLEADO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "FECHACONTRATACIONEMPLEADO") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A26TELEFONOEMPLEADO));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
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
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0010.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void START1R2( )
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
            Form.Meta.addItem("description", "Selection List Empleados", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1R0( ) ;
      }

      protected void WS1R2( )
      {
         START1R2( ) ;
         EVT1R2( ) ;
      }

      protected void EVT1R2( )
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
                              nGXsfl_64_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
                              A26TELEFONOEMPLEADO = cgiGet( edtTELEFONOEMPLEADO_Internalname);
                              A29FECHACONTRATACIONEMPLEADO = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFECHACONTRATACIONEMPLEADO_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E181R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cidempleado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDEMPLEADO"), ".", ",") != Convert.ToDecimal( AV6cIDEMPLEADO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctelefonoempleado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTELEFONOEMPLEADO"), AV10cTELEFONOEMPLEADO) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfechacontratacionempleado Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCFECHACONTRATACIONEMPLEADO"), 0) != AV11cFECHACONTRATACIONEMPLEADO )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cidtipoempleado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDTIPOEMPLEADO"), ".", ",") != Convert.ToDecimal( AV15cIDTIPOEMPLEADO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cidestadoempleado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDESTADOEMPLEADO"), ".", ",") != Convert.ToDecimal( AV16cIDESTADOEMPLEADO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E191R2 ();
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

      protected void WE1R2( )
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

      protected void PA1R2( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cIDEMPLEADO ,
                                        string AV10cTELEFONOEMPLEADO ,
                                        DateTime AV11cFECHACONTRATACIONEMPLEADO ,
                                        long AV15cIDTIPOEMPLEADO ,
                                        long AV16cIDESTADOEMPLEADO )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDEMPLEADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")));
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
         RF1R2( ) ;
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

      protected void RF1R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV10cTELEFONOEMPLEADO ,
                                                 AV11cFECHACONTRATACIONEMPLEADO ,
                                                 AV15cIDTIPOEMPLEADO ,
                                                 AV16cIDESTADOEMPLEADO ,
                                                 A26TELEFONOEMPLEADO ,
                                                 A29FECHACONTRATACIONEMPLEADO ,
                                                 A2IDTIPOEMPLEADO ,
                                                 A3IDESTADOEMPLEADO ,
                                                 AV6cIDEMPLEADO } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV10cTELEFONOEMPLEADO = StringUtil.PadR( StringUtil.RTrim( AV10cTELEFONOEMPLEADO), 20, "%");
            /* Using cursor H001R2 */
            pr_default.execute(0, new Object[] {AV6cIDEMPLEADO, lV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A3IDESTADOEMPLEADO = H001R2_A3IDESTADOEMPLEADO[0];
               A2IDTIPOEMPLEADO = H001R2_A2IDTIPOEMPLEADO[0];
               A29FECHACONTRATACIONEMPLEADO = H001R2_A29FECHACONTRATACIONEMPLEADO[0];
               A26TELEFONOEMPLEADO = H001R2_A26TELEFONOEMPLEADO[0];
               A1IDEMPLEADO = H001R2_A1IDEMPLEADO[0];
               /* Execute user event: Load */
               E181R2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB1R0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1R2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDEMPLEADO"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"), context));
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
                                              AV10cTELEFONOEMPLEADO ,
                                              AV11cFECHACONTRATACIONEMPLEADO ,
                                              AV15cIDTIPOEMPLEADO ,
                                              AV16cIDESTADOEMPLEADO ,
                                              A26TELEFONOEMPLEADO ,
                                              A29FECHACONTRATACIONEMPLEADO ,
                                              A2IDTIPOEMPLEADO ,
                                              A3IDESTADOEMPLEADO ,
                                              AV6cIDEMPLEADO } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV10cTELEFONOEMPLEADO = StringUtil.PadR( StringUtil.RTrim( AV10cTELEFONOEMPLEADO), 20, "%");
         /* Using cursor H001R3 */
         pr_default.execute(1, new Object[] {AV6cIDEMPLEADO, lV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO});
         GRID1_nRecordCount = H001R3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDEMPLEADO, AV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDEMPLEADO, AV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDEMPLEADO, AV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDEMPLEADO, AV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDEMPLEADO, AV10cTELEFONOEMPLEADO, AV11cFECHACONTRATACIONEMPLEADO, AV15cIDTIPOEMPLEADO, AV16cIDESTADOEMPLEADO) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidempleado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidempleado_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDEMPLEADO");
               GX_FocusControl = edtavCidempleado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cIDEMPLEADO = 0;
               AssignAttri("", false, "AV6cIDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV6cIDEMPLEADO), 12, 0));
            }
            else
            {
               AV6cIDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtavCidempleado_Internalname), ".", ","));
               AssignAttri("", false, "AV6cIDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV6cIDEMPLEADO), 12, 0));
            }
            AV10cTELEFONOEMPLEADO = cgiGet( edtavCtelefonoempleado_Internalname);
            AssignAttri("", false, "AV10cTELEFONOEMPLEADO", AV10cTELEFONOEMPLEADO);
            if ( context.localUtil.VCDate( cgiGet( edtavCfechacontratacionempleado_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FECHACONTRATACIONEMPLEADO"}), 1, "vCFECHACONTRATACIONEMPLEADO");
               GX_FocusControl = edtavCfechacontratacionempleado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cFECHACONTRATACIONEMPLEADO = DateTime.MinValue;
               AssignAttri("", false, "AV11cFECHACONTRATACIONEMPLEADO", context.localUtil.Format(AV11cFECHACONTRATACIONEMPLEADO, "99/99/99"));
            }
            else
            {
               AV11cFECHACONTRATACIONEMPLEADO = context.localUtil.CToD( cgiGet( edtavCfechacontratacionempleado_Internalname), 1);
               AssignAttri("", false, "AV11cFECHACONTRATACIONEMPLEADO", context.localUtil.Format(AV11cFECHACONTRATACIONEMPLEADO, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidtipoempleado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidtipoempleado_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDTIPOEMPLEADO");
               GX_FocusControl = edtavCidtipoempleado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cIDTIPOEMPLEADO = 0;
               AssignAttri("", false, "AV15cIDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV15cIDTIPOEMPLEADO), 12, 0));
            }
            else
            {
               AV15cIDTIPOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtavCidtipoempleado_Internalname), ".", ","));
               AssignAttri("", false, "AV15cIDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV15cIDTIPOEMPLEADO), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidestadoempleado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidestadoempleado_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDESTADOEMPLEADO");
               GX_FocusControl = edtavCidestadoempleado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cIDESTADOEMPLEADO = 0;
               AssignAttri("", false, "AV16cIDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV16cIDESTADOEMPLEADO), 12, 0));
            }
            else
            {
               AV16cIDESTADOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtavCidestadoempleado_Internalname), ".", ","));
               AssignAttri("", false, "AV16cIDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV16cIDESTADOEMPLEADO), 12, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDEMPLEADO"), ".", ",") != Convert.ToDecimal( AV6cIDEMPLEADO )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTELEFONOEMPLEADO"), AV10cTELEFONOEMPLEADO) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCFECHACONTRATACIONEMPLEADO"), 1) != AV11cFECHACONTRATACIONEMPLEADO )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDTIPOEMPLEADO"), ".", ",") != Convert.ToDecimal( AV15cIDTIPOEMPLEADO )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDESTADOEMPLEADO"), ".", ",") != Convert.ToDecimal( AV16cIDESTADOEMPLEADO )) )
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
         E171R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171R2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Empleados", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E181R2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV19Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E191R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pIDEMPLEADO = A1IDEMPLEADO;
         AssignAttri("", false, "AV13pIDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV13pIDEMPLEADO), 12, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pIDEMPLEADO});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pIDEMPLEADO"});
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
         AV13pIDEMPLEADO = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pIDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV13pIDEMPLEADO), 12, 0));
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
         PA1R2( ) ;
         WS1R2( ) ;
         WE1R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113014131296", true, true);
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
         context.AddJavascriptSource("gx0010.js", "?2021113014131296", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtIDEMPLEADO_Internalname = "IDEMPLEADO_"+sGXsfl_64_idx;
         edtTELEFONOEMPLEADO_Internalname = "TELEFONOEMPLEADO_"+sGXsfl_64_idx;
         edtFECHACONTRATACIONEMPLEADO_Internalname = "FECHACONTRATACIONEMPLEADO_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtIDEMPLEADO_Internalname = "IDEMPLEADO_"+sGXsfl_64_fel_idx;
         edtTELEFONOEMPLEADO_Internalname = "TELEFONOEMPLEADO_"+sGXsfl_64_fel_idx;
         edtFECHACONTRATACIONEMPLEADO_Internalname = "FECHACONTRATACIONEMPLEADO_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB1R0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDEMPLEADO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A26TELEFONOEMPLEADO);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTELEFONOEMPLEADO_Internalname,StringUtil.RTrim( A26TELEFONOEMPLEADO),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtTELEFONOEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFECHACONTRATACIONEMPLEADO_Internalname,context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"),context.localUtil.Format( A29FECHACONTRATACIONEMPLEADO, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFECHACONTRATACIONEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1R2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblidempleadofilter_Internalname = "LBLIDEMPLEADOFILTER";
         edtavCidempleado_Internalname = "vCIDEMPLEADO";
         divIdempleadofiltercontainer_Internalname = "IDEMPLEADOFILTERCONTAINER";
         lblLbltelefonoempleadofilter_Internalname = "LBLTELEFONOEMPLEADOFILTER";
         edtavCtelefonoempleado_Internalname = "vCTELEFONOEMPLEADO";
         divTelefonoempleadofiltercontainer_Internalname = "TELEFONOEMPLEADOFILTERCONTAINER";
         lblLblfechacontratacionempleadofilter_Internalname = "LBLFECHACONTRATACIONEMPLEADOFILTER";
         edtavCfechacontratacionempleado_Internalname = "vCFECHACONTRATACIONEMPLEADO";
         divFechacontratacionempleadofiltercontainer_Internalname = "FECHACONTRATACIONEMPLEADOFILTERCONTAINER";
         lblLblidtipoempleadofilter_Internalname = "LBLIDTIPOEMPLEADOFILTER";
         edtavCidtipoempleado_Internalname = "vCIDTIPOEMPLEADO";
         divIdtipoempleadofiltercontainer_Internalname = "IDTIPOEMPLEADOFILTERCONTAINER";
         lblLblidestadoempleadofilter_Internalname = "LBLIDESTADOEMPLEADOFILTER";
         edtavCidestadoempleado_Internalname = "vCIDESTADOEMPLEADO";
         divIdestadoempleadofiltercontainer_Internalname = "IDESTADOEMPLEADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtIDEMPLEADO_Internalname = "IDEMPLEADO";
         edtTELEFONOEMPLEADO_Internalname = "TELEFONOEMPLEADO";
         edtFECHACONTRATACIONEMPLEADO_Internalname = "FECHACONTRATACIONEMPLEADO";
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
         edtFECHACONTRATACIONEMPLEADO_Jsonclick = "";
         edtTELEFONOEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCidestadoempleado_Jsonclick = "";
         edtavCidestadoempleado_Enabled = 1;
         edtavCidestadoempleado_Visible = 1;
         edtavCidtipoempleado_Jsonclick = "";
         edtavCidtipoempleado_Enabled = 1;
         edtavCidtipoempleado_Visible = 1;
         edtavCfechacontratacionempleado_Jsonclick = "";
         edtavCfechacontratacionempleado_Enabled = 1;
         edtavCtelefonoempleado_Jsonclick = "";
         edtavCtelefonoempleado_Enabled = 1;
         edtavCtelefonoempleado_Visible = 1;
         edtavCidempleado_Jsonclick = "";
         edtavCidempleado_Enabled = 1;
         edtavCidempleado_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Empleados";
         divIdestadoempleadofiltercontainer_Class = "AdvancedContainerItem";
         divIdtipoempleadofiltercontainer_Class = "AdvancedContainerItem";
         divFechacontratacionempleadofiltercontainer_Class = "AdvancedContainerItem";
         divTelefonoempleadofiltercontainer_Class = "AdvancedContainerItem";
         divIdempleadofiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOEMPLEADO',fld:'vCTELEFONOEMPLEADO',pic:''},{av:'AV11cFECHACONTRATACIONEMPLEADO',fld:'vCFECHACONTRATACIONEMPLEADO',pic:''},{av:'AV15cIDTIPOEMPLEADO',fld:'vCIDTIPOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV16cIDESTADOEMPLEADO',fld:'vCIDESTADOEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E161R1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLIDEMPLEADOFILTER.CLICK","{handler:'E111R1',iparms:[{av:'divIdempleadofiltercontainer_Class',ctrl:'IDEMPLEADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDEMPLEADOFILTER.CLICK",",oparms:[{av:'divIdempleadofiltercontainer_Class',ctrl:'IDEMPLEADOFILTERCONTAINER',prop:'Class'},{av:'edtavCidempleado_Visible',ctrl:'vCIDEMPLEADO',prop:'Visible'}]}");
         setEventMetadata("LBLTELEFONOEMPLEADOFILTER.CLICK","{handler:'E121R1',iparms:[{av:'divTelefonoempleadofiltercontainer_Class',ctrl:'TELEFONOEMPLEADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTELEFONOEMPLEADOFILTER.CLICK",",oparms:[{av:'divTelefonoempleadofiltercontainer_Class',ctrl:'TELEFONOEMPLEADOFILTERCONTAINER',prop:'Class'},{av:'edtavCtelefonoempleado_Visible',ctrl:'vCTELEFONOEMPLEADO',prop:'Visible'}]}");
         setEventMetadata("LBLFECHACONTRATACIONEMPLEADOFILTER.CLICK","{handler:'E131R1',iparms:[{av:'divFechacontratacionempleadofiltercontainer_Class',ctrl:'FECHACONTRATACIONEMPLEADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFECHACONTRATACIONEMPLEADOFILTER.CLICK",",oparms:[{av:'divFechacontratacionempleadofiltercontainer_Class',ctrl:'FECHACONTRATACIONEMPLEADOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLIDTIPOEMPLEADOFILTER.CLICK","{handler:'E141R1',iparms:[{av:'divIdtipoempleadofiltercontainer_Class',ctrl:'IDTIPOEMPLEADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDTIPOEMPLEADOFILTER.CLICK",",oparms:[{av:'divIdtipoempleadofiltercontainer_Class',ctrl:'IDTIPOEMPLEADOFILTERCONTAINER',prop:'Class'},{av:'edtavCidtipoempleado_Visible',ctrl:'vCIDTIPOEMPLEADO',prop:'Visible'}]}");
         setEventMetadata("LBLIDESTADOEMPLEADOFILTER.CLICK","{handler:'E151R1',iparms:[{av:'divIdestadoempleadofiltercontainer_Class',ctrl:'IDESTADOEMPLEADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDESTADOEMPLEADOFILTER.CLICK",",oparms:[{av:'divIdestadoempleadofiltercontainer_Class',ctrl:'IDESTADOEMPLEADOFILTERCONTAINER',prop:'Class'},{av:'edtavCidestadoempleado_Visible',ctrl:'vCIDESTADOEMPLEADO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E191R2',iparms:[{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pIDEMPLEADO',fld:'vPIDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOEMPLEADO',fld:'vCTELEFONOEMPLEADO',pic:''},{av:'AV11cFECHACONTRATACIONEMPLEADO',fld:'vCFECHACONTRATACIONEMPLEADO',pic:''},{av:'AV15cIDTIPOEMPLEADO',fld:'vCIDTIPOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV16cIDESTADOEMPLEADO',fld:'vCIDESTADOEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOEMPLEADO',fld:'vCTELEFONOEMPLEADO',pic:''},{av:'AV11cFECHACONTRATACIONEMPLEADO',fld:'vCFECHACONTRATACIONEMPLEADO',pic:''},{av:'AV15cIDTIPOEMPLEADO',fld:'vCIDTIPOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV16cIDESTADOEMPLEADO',fld:'vCIDESTADOEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOEMPLEADO',fld:'vCTELEFONOEMPLEADO',pic:''},{av:'AV11cFECHACONTRATACIONEMPLEADO',fld:'vCFECHACONTRATACIONEMPLEADO',pic:''},{av:'AV15cIDTIPOEMPLEADO',fld:'vCIDTIPOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV16cIDESTADOEMPLEADO',fld:'vCIDESTADOEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDEMPLEADO',fld:'vCIDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOEMPLEADO',fld:'vCTELEFONOEMPLEADO',pic:''},{av:'AV11cFECHACONTRATACIONEMPLEADO',fld:'vCFECHACONTRATACIONEMPLEADO',pic:''},{av:'AV15cIDTIPOEMPLEADO',fld:'vCIDTIPOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'AV16cIDESTADOEMPLEADO',fld:'vCIDESTADOEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CFECHACONTRATACIONEMPLEADO","{handler:'Validv_Cfechacontratacionempleado',iparms:[]");
         setEventMetadata("VALIDV_CFECHACONTRATACIONEMPLEADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Fechacontratacionempleado',iparms:[]");
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
         AV10cTELEFONOEMPLEADO = "";
         AV11cFECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblidempleadofilter_Jsonclick = "";
         TempTags = "";
         lblLbltelefonoempleadofilter_Jsonclick = "";
         lblLblfechacontratacionempleadofilter_Jsonclick = "";
         lblLblidtipoempleadofilter_Jsonclick = "";
         lblLblidestadoempleadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A26TELEFONOEMPLEADO = "";
         A29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19Linkselection_GXI = "";
         scmdbuf = "";
         lV10cTELEFONOEMPLEADO = "";
         H001R2_A3IDESTADOEMPLEADO = new long[1] ;
         H001R2_A2IDTIPOEMPLEADO = new long[1] ;
         H001R2_A29FECHACONTRATACIONEMPLEADO = new DateTime[] {DateTime.MinValue} ;
         H001R2_A26TELEFONOEMPLEADO = new string[] {""} ;
         H001R2_A1IDEMPLEADO = new long[1] ;
         H001R3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0010__default(),
            new Object[][] {
                new Object[] {
               H001R2_A3IDESTADOEMPLEADO, H001R2_A2IDTIPOEMPLEADO, H001R2_A29FECHACONTRATACIONEMPLEADO, H001R2_A26TELEFONOEMPLEADO, H001R2_A1IDEMPLEADO
               }
               , new Object[] {
               H001R3_AGRID1_nRecordCount
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
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCidempleado_Enabled ;
      private int edtavCidempleado_Visible ;
      private int edtavCtelefonoempleado_Visible ;
      private int edtavCtelefonoempleado_Enabled ;
      private int edtavCfechacontratacionempleado_Enabled ;
      private int edtavCidtipoempleado_Enabled ;
      private int edtavCidtipoempleado_Visible ;
      private int edtavCidestadoempleado_Enabled ;
      private int edtavCidestadoempleado_Visible ;
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
      private long AV13pIDEMPLEADO ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cIDEMPLEADO ;
      private long AV15cIDTIPOEMPLEADO ;
      private long AV16cIDESTADOEMPLEADO ;
      private long A1IDEMPLEADO ;
      private long GRID1_nCurrentRecord ;
      private long A2IDTIPOEMPLEADO ;
      private long A3IDESTADOEMPLEADO ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divIdempleadofiltercontainer_Class ;
      private string divTelefonoempleadofiltercontainer_Class ;
      private string divFechacontratacionempleadofiltercontainer_Class ;
      private string divIdtipoempleadofiltercontainer_Class ;
      private string divIdestadoempleadofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV10cTELEFONOEMPLEADO ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divIdempleadofiltercontainer_Internalname ;
      private string lblLblidempleadofilter_Internalname ;
      private string lblLblidempleadofilter_Jsonclick ;
      private string edtavCidempleado_Internalname ;
      private string TempTags ;
      private string edtavCidempleado_Jsonclick ;
      private string divTelefonoempleadofiltercontainer_Internalname ;
      private string lblLbltelefonoempleadofilter_Internalname ;
      private string lblLbltelefonoempleadofilter_Jsonclick ;
      private string edtavCtelefonoempleado_Internalname ;
      private string edtavCtelefonoempleado_Jsonclick ;
      private string divFechacontratacionempleadofiltercontainer_Internalname ;
      private string lblLblfechacontratacionempleadofilter_Internalname ;
      private string lblLblfechacontratacionempleadofilter_Jsonclick ;
      private string edtavCfechacontratacionempleado_Internalname ;
      private string edtavCfechacontratacionempleado_Jsonclick ;
      private string divIdtipoempleadofiltercontainer_Internalname ;
      private string lblLblidtipoempleadofilter_Internalname ;
      private string lblLblidtipoempleadofilter_Jsonclick ;
      private string edtavCidtipoempleado_Internalname ;
      private string edtavCidtipoempleado_Jsonclick ;
      private string divIdestadoempleadofiltercontainer_Internalname ;
      private string lblLblidestadoempleadofilter_Internalname ;
      private string lblLblidestadoempleadofilter_Jsonclick ;
      private string edtavCidestadoempleado_Internalname ;
      private string edtavCidestadoempleado_Jsonclick ;
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
      private string A26TELEFONOEMPLEADO ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtIDEMPLEADO_Internalname ;
      private string edtTELEFONOEMPLEADO_Internalname ;
      private string edtFECHACONTRATACIONEMPLEADO_Internalname ;
      private string scmdbuf ;
      private string lV10cTELEFONOEMPLEADO ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string gxphoneLink ;
      private string edtTELEFONOEMPLEADO_Jsonclick ;
      private string edtFECHACONTRATACIONEMPLEADO_Jsonclick ;
      private DateTime AV11cFECHACONTRATACIONEMPLEADO ;
      private DateTime A29FECHACONTRATACIONEMPLEADO ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV19Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H001R2_A3IDESTADOEMPLEADO ;
      private long[] H001R2_A2IDTIPOEMPLEADO ;
      private DateTime[] H001R2_A29FECHACONTRATACIONEMPLEADO ;
      private string[] H001R2_A26TELEFONOEMPLEADO ;
      private long[] H001R2_A1IDEMPLEADO ;
      private long[] H001R3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pIDEMPLEADO ;
      private GXWebForm Form ;
   }

   public class gx0010__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001R2( IGxContext context ,
                                             string AV10cTELEFONOEMPLEADO ,
                                             DateTime AV11cFECHACONTRATACIONEMPLEADO ,
                                             long AV15cIDTIPOEMPLEADO ,
                                             long AV16cIDESTADOEMPLEADO ,
                                             string A26TELEFONOEMPLEADO ,
                                             DateTime A29FECHACONTRATACIONEMPLEADO ,
                                             long A2IDTIPOEMPLEADO ,
                                             long A3IDESTADOEMPLEADO ,
                                             long AV6cIDEMPLEADO )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [IDESTADOEMPLEADO], [IDTIPOEMPLEADO], [FECHACONTRATACIONEMPLEADO], [TELEFONOEMPLEADO], [IDEMPLEADO]";
         sFromString = " FROM [Empleados]";
         sOrderString = "";
         AddWhere(sWhereString, "([IDEMPLEADO] >= @AV6cIDEMPLEADO)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cTELEFONOEMPLEADO)) )
         {
            AddWhere(sWhereString, "([TELEFONOEMPLEADO] like @lV10cTELEFONOEMPLEADO)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cFECHACONTRATACIONEMPLEADO) )
         {
            AddWhere(sWhereString, "([FECHACONTRATACIONEMPLEADO] >= @AV11cFECHACONTRATACIONEMPLEADO)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV15cIDTIPOEMPLEADO) )
         {
            AddWhere(sWhereString, "([IDTIPOEMPLEADO] >= @AV15cIDTIPOEMPLEADO)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV16cIDESTADOEMPLEADO) )
         {
            AddWhere(sWhereString, "([IDESTADOEMPLEADO] >= @AV16cIDESTADOEMPLEADO)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [IDEMPLEADO]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001R3( IGxContext context ,
                                             string AV10cTELEFONOEMPLEADO ,
                                             DateTime AV11cFECHACONTRATACIONEMPLEADO ,
                                             long AV15cIDTIPOEMPLEADO ,
                                             long AV16cIDESTADOEMPLEADO ,
                                             string A26TELEFONOEMPLEADO ,
                                             DateTime A29FECHACONTRATACIONEMPLEADO ,
                                             long A2IDTIPOEMPLEADO ,
                                             long A3IDESTADOEMPLEADO ,
                                             long AV6cIDEMPLEADO )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Empleados]";
         AddWhere(sWhereString, "([IDEMPLEADO] >= @AV6cIDEMPLEADO)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cTELEFONOEMPLEADO)) )
         {
            AddWhere(sWhereString, "([TELEFONOEMPLEADO] like @lV10cTELEFONOEMPLEADO)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cFECHACONTRATACIONEMPLEADO) )
         {
            AddWhere(sWhereString, "([FECHACONTRATACIONEMPLEADO] >= @AV11cFECHACONTRATACIONEMPLEADO)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV15cIDTIPOEMPLEADO) )
         {
            AddWhere(sWhereString, "([IDTIPOEMPLEADO] >= @AV15cIDTIPOEMPLEADO)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV16cIDESTADOEMPLEADO) )
         {
            AddWhere(sWhereString, "([IDESTADOEMPLEADO] >= @AV16cIDESTADOEMPLEADO)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H001R2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
               case 1 :
                     return conditional_H001R3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] );
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
          Object[] prmH001R2;
          prmH001R2 = new Object[] {
          new ParDef("@AV6cIDEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@lV10cTELEFONOEMPLEADO",GXType.NChar,20,0) ,
          new ParDef("@AV11cFECHACONTRATACIONEMPLEADO",GXType.Date,8,0) ,
          new ParDef("@AV15cIDTIPOEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@AV16cIDESTADOEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001R3;
          prmH001R3 = new Object[] {
          new ParDef("@AV6cIDEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@lV10cTELEFONOEMPLEADO",GXType.NChar,20,0) ,
          new ParDef("@AV11cFECHACONTRATACIONEMPLEADO",GXType.Date,8,0) ,
          new ParDef("@AV15cIDTIPOEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@AV16cIDESTADOEMPLEADO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001R2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001R3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
