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
   public class gx0080 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0080( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0080( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pIDCLIENTE )
      {
         this.AV13pIDCLIENTE = 0 ;
         executePrivate();
         aP0_pIDCLIENTE=this.AV13pIDCLIENTE;
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
            gxfirstwebparm = GetFirstPar( "pIDCLIENTE");
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
               gxfirstwebparm = GetFirstPar( "pIDCLIENTE");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pIDCLIENTE");
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
               AV6cIDCLIENTE = (long)(NumberUtil.Val( GetPar( "cIDCLIENTE"), "."));
               AV10cTELEFONOCLIENTE = GetPar( "cTELEFONOCLIENTE");
               AV11cCORREOCLIENTE = GetPar( "cCORREOCLIENTE");
               AV12cFECHANACIMIENTOCLIENTE = context.localUtil.ParseDateParm( GetPar( "cFECHANACIMIENTOCLIENTE"));
               AV15cFECHAREGISTROCLIENTE = context.localUtil.ParseDateParm( GetPar( "cFECHAREGISTROCLIENTE"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCLIENTE, AV10cTELEFONOCLIENTE, AV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "IDCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divIdclientefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TELEFONOCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divTelefonoclientefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "CORREOCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divCorreoclientefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "FECHANACIMIENTOCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divFechanacimientoclientefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "FECHAREGISTROCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divFecharegistroclientefiltercontainer_Class));
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
               AV13pIDCLIENTE = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pIDCLIENTE", StringUtil.LTrimStr( (decimal)(AV13pIDCLIENTE), 12, 0));
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
         PA1U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1U2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202111280105594", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pIDCLIENTE,12,0))}, new string[] {"pIDCLIENTE"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCIDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDCLIENTE), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTELEFONOCLIENTE", StringUtil.RTrim( AV10cTELEFONOCLIENTE));
         GxWebStd.gx_hidden_field( context, "GXH_vCCORREOCLIENTE", AV11cCORREOCLIENTE);
         GxWebStd.gx_hidden_field( context, "GXH_vCFECHANACIMIENTOCLIENTE", context.localUtil.Format(AV12cFECHANACIMIENTOCLIENTE, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCFECHAREGISTROCLIENTE", context.localUtil.Format(AV15cFECHAREGISTROCLIENTE, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPIDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pIDCLIENTE), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "IDCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divIdclientefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TELEFONOCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divTelefonoclientefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORREOCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divCorreoclientefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FECHANACIMIENTOCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divFechanacimientoclientefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FECHAREGISTROCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divFecharegistroclientefiltercontainer_Class));
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
            WE1U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1U2( ) ;
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
         return formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pIDCLIENTE,12,0))}, new string[] {"pIDCLIENTE"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0080" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Clientes" ;
      }

      protected void WB1U0( )
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
            GxWebStd.gx_div_start( context, divIdclientefiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdclientefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidclientefilter_Internalname, "IDCLIENTE", "", "", lblLblidclientefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111u1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidcliente_Internalname, "IDCLIENTE", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidcliente_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDCLIENTE), 12, 0, ".", "")), ((edtavCidcliente_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cIDCLIENTE), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cIDCLIENTE), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidcliente_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidcliente_Visible, edtavCidcliente_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divTelefonoclientefiltercontainer_Internalname, 1, 0, "px", 0, "px", divTelefonoclientefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltelefonoclientefilter_Internalname, "TELEFONOCLIENTE", "", "", lblLbltelefonoclientefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121u1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtelefonocliente_Internalname, "TELEFONOCLIENTE", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtelefonocliente_Internalname, StringUtil.RTrim( AV10cTELEFONOCLIENTE), StringUtil.RTrim( context.localUtil.Format( AV10cTELEFONOCLIENTE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtelefonocliente_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtelefonocliente_Visible, edtavCtelefonocliente_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divCorreoclientefiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorreoclientefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorreoclientefilter_Internalname, "CORREOCLIENTE", "", "", lblLblcorreoclientefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131u1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorreocliente_Internalname, "CORREOCLIENTE", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorreocliente_Internalname, AV11cCORREOCLIENTE, StringUtil.RTrim( context.localUtil.Format( AV11cCORREOCLIENTE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorreocliente_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorreocliente_Visible, edtavCcorreocliente_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divFechanacimientoclientefiltercontainer_Internalname, 1, 0, "px", 0, "px", divFechanacimientoclientefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfechanacimientoclientefilter_Internalname, "FECHANACIMIENTOCLIENTE", "", "", lblLblfechanacimientoclientefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141u1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfechanacimientocliente_Internalname, "FECHANACIMIENTOCLIENTE", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCfechanacimientocliente_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCfechanacimientocliente_Internalname, context.localUtil.Format(AV12cFECHANACIMIENTOCLIENTE, "99/99/99"), context.localUtil.Format( AV12cFECHANACIMIENTOCLIENTE, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfechanacimientocliente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCfechanacimientocliente_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divFecharegistroclientefiltercontainer_Internalname, 1, 0, "px", 0, "px", divFecharegistroclientefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfecharegistroclientefilter_Internalname, "FECHAREGISTROCLIENTE", "", "", lblLblfecharegistroclientefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151u1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfecharegistrocliente_Internalname, "FECHAREGISTROCLIENTE", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCfecharegistrocliente_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCfecharegistrocliente_Internalname, context.localUtil.Format(AV15cFECHAREGISTROCLIENTE, "99/99/99"), context.localUtil.Format( AV15cFECHAREGISTROCLIENTE, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfecharegistrocliente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCfecharegistrocliente_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161u1_client"+"'", TempTags, "", 2, "HLP_Gx0080.htm");
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
               context.SendWebValue( "IDCLIENTE") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "TELEFONOCLIENTE") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "FECHANACIMIENTOCLIENTE") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "FECHAREGISTROCLIENTE") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "FOTOCLIENTE") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A33TELEFONOCLIENTE));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( A53FOTOCLIENTE));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0080.htm");
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

      protected void START1U2( )
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
            Form.Meta.addItem("description", "Selection List Clientes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1U0( ) ;
      }

      protected void WS1U2( )
      {
         START1U2( ) ;
         EVT1U2( ) ;
      }

      protected void EVT1U2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ","));
                              A33TELEFONOCLIENTE = cgiGet( edtTELEFONOCLIENTE_Internalname);
                              A35FECHANACIMIENTOCLIENTE = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFECHANACIMIENTOCLIENTE_Internalname), 0));
                              A37FECHAREGISTROCLIENTE = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFECHAREGISTROCLIENTE_Internalname), 0));
                              A53FOTOCLIENTE = cgiGet( edtFOTOCLIENTE_Internalname);
                              AssignProp("", false, edtFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E181U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cidcliente Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDCLIENTE"), ".", ",") != Convert.ToDecimal( AV6cIDCLIENTE )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctelefonocliente Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCTELEFONOCLIENTE"), AV10cTELEFONOCLIENTE) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorreocliente Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOCLIENTE"), AV11cCORREOCLIENTE) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfechanacimientocliente Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCFECHANACIMIENTOCLIENTE"), 0) != AV12cFECHANACIMIENTOCLIENTE )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfecharegistrocliente Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCFECHAREGISTROCLIENTE"), 0) != AV15cFECHAREGISTROCLIENTE )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E191U2 ();
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

      protected void WE1U2( )
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

      protected void PA1U2( )
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
                                        long AV6cIDCLIENTE ,
                                        string AV10cTELEFONOCLIENTE ,
                                        string AV11cCORREOCLIENTE ,
                                        DateTime AV12cFECHANACIMIENTOCLIENTE ,
                                        DateTime AV15cFECHAREGISTROCLIENTE )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1U2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDCLIENTE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "IDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")));
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
         RF1U2( ) ;
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

      protected void RF1U2( )
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
                                                 AV10cTELEFONOCLIENTE ,
                                                 AV11cCORREOCLIENTE ,
                                                 AV12cFECHANACIMIENTOCLIENTE ,
                                                 AV15cFECHAREGISTROCLIENTE ,
                                                 A33TELEFONOCLIENTE ,
                                                 A34CORREOCLIENTE ,
                                                 A35FECHANACIMIENTOCLIENTE ,
                                                 A37FECHAREGISTROCLIENTE ,
                                                 AV6cIDCLIENTE } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG
                                                 }
            });
            lV10cTELEFONOCLIENTE = StringUtil.PadR( StringUtil.RTrim( AV10cTELEFONOCLIENTE), 20, "%");
            lV11cCORREOCLIENTE = StringUtil.Concat( StringUtil.RTrim( AV11cCORREOCLIENTE), "%", "");
            /* Using cursor H001U2 */
            pr_default.execute(0, new Object[] {AV6cIDCLIENTE, lV10cTELEFONOCLIENTE, lV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A34CORREOCLIENTE = H001U2_A34CORREOCLIENTE[0];
               A40000FOTOCLIENTE_GXI = H001U2_A40000FOTOCLIENTE_GXI[0];
               AssignProp("", false, edtFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), !bGXsfl_64_Refreshing);
               AssignProp("", false, edtFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
               A37FECHAREGISTROCLIENTE = H001U2_A37FECHAREGISTROCLIENTE[0];
               A35FECHANACIMIENTOCLIENTE = H001U2_A35FECHANACIMIENTOCLIENTE[0];
               A33TELEFONOCLIENTE = H001U2_A33TELEFONOCLIENTE[0];
               A4IDCLIENTE = H001U2_A4IDCLIENTE[0];
               A53FOTOCLIENTE = H001U2_A53FOTOCLIENTE[0];
               AssignProp("", false, edtFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), !bGXsfl_64_Refreshing);
               AssignProp("", false, edtFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
               /* Execute user event: Load */
               E181U2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB1U0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1U2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDCLIENTE"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"), context));
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
                                              AV10cTELEFONOCLIENTE ,
                                              AV11cCORREOCLIENTE ,
                                              AV12cFECHANACIMIENTOCLIENTE ,
                                              AV15cFECHAREGISTROCLIENTE ,
                                              A33TELEFONOCLIENTE ,
                                              A34CORREOCLIENTE ,
                                              A35FECHANACIMIENTOCLIENTE ,
                                              A37FECHAREGISTROCLIENTE ,
                                              AV6cIDCLIENTE } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG
                                              }
         });
         lV10cTELEFONOCLIENTE = StringUtil.PadR( StringUtil.RTrim( AV10cTELEFONOCLIENTE), 20, "%");
         lV11cCORREOCLIENTE = StringUtil.Concat( StringUtil.RTrim( AV11cCORREOCLIENTE), "%", "");
         /* Using cursor H001U3 */
         pr_default.execute(1, new Object[] {AV6cIDCLIENTE, lV10cTELEFONOCLIENTE, lV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE});
         GRID1_nRecordCount = H001U3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCLIENTE, AV10cTELEFONOCLIENTE, AV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCLIENTE, AV10cTELEFONOCLIENTE, AV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCLIENTE, AV10cTELEFONOCLIENTE, AV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCLIENTE, AV10cTELEFONOCLIENTE, AV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDCLIENTE, AV10cTELEFONOCLIENTE, AV11cCORREOCLIENTE, AV12cFECHANACIMIENTOCLIENTE, AV15cFECHAREGISTROCLIENTE) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171U2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidcliente_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidcliente_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDCLIENTE");
               GX_FocusControl = edtavCidcliente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cIDCLIENTE = 0;
               AssignAttri("", false, "AV6cIDCLIENTE", StringUtil.LTrimStr( (decimal)(AV6cIDCLIENTE), 12, 0));
            }
            else
            {
               AV6cIDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtavCidcliente_Internalname), ".", ","));
               AssignAttri("", false, "AV6cIDCLIENTE", StringUtil.LTrimStr( (decimal)(AV6cIDCLIENTE), 12, 0));
            }
            AV10cTELEFONOCLIENTE = cgiGet( edtavCtelefonocliente_Internalname);
            AssignAttri("", false, "AV10cTELEFONOCLIENTE", AV10cTELEFONOCLIENTE);
            AV11cCORREOCLIENTE = cgiGet( edtavCcorreocliente_Internalname);
            AssignAttri("", false, "AV11cCORREOCLIENTE", AV11cCORREOCLIENTE);
            if ( context.localUtil.VCDate( cgiGet( edtavCfechanacimientocliente_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FECHANACIMIENTOCLIENTE"}), 1, "vCFECHANACIMIENTOCLIENTE");
               GX_FocusControl = edtavCfechanacimientocliente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cFECHANACIMIENTOCLIENTE = DateTime.MinValue;
               AssignAttri("", false, "AV12cFECHANACIMIENTOCLIENTE", context.localUtil.Format(AV12cFECHANACIMIENTOCLIENTE, "99/99/99"));
            }
            else
            {
               AV12cFECHANACIMIENTOCLIENTE = context.localUtil.CToD( cgiGet( edtavCfechanacimientocliente_Internalname), 1);
               AssignAttri("", false, "AV12cFECHANACIMIENTOCLIENTE", context.localUtil.Format(AV12cFECHANACIMIENTOCLIENTE, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCfecharegistrocliente_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FECHAREGISTROCLIENTE"}), 1, "vCFECHAREGISTROCLIENTE");
               GX_FocusControl = edtavCfecharegistrocliente_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cFECHAREGISTROCLIENTE = DateTime.MinValue;
               AssignAttri("", false, "AV15cFECHAREGISTROCLIENTE", context.localUtil.Format(AV15cFECHAREGISTROCLIENTE, "99/99/99"));
            }
            else
            {
               AV15cFECHAREGISTROCLIENTE = context.localUtil.CToD( cgiGet( edtavCfecharegistrocliente_Internalname), 1);
               AssignAttri("", false, "AV15cFECHAREGISTROCLIENTE", context.localUtil.Format(AV15cFECHAREGISTROCLIENTE, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDCLIENTE"), ".", ",") != Convert.ToDecimal( AV6cIDCLIENTE )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCTELEFONOCLIENTE"), AV10cTELEFONOCLIENTE) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCORREOCLIENTE"), AV11cCORREOCLIENTE) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCFECHANACIMIENTOCLIENTE"), 1) != AV12cFECHANACIMIENTOCLIENTE )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCFECHAREGISTROCLIENTE"), 1) != AV15cFECHAREGISTROCLIENTE )
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
         E171U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171U2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Clientes", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E181U2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E191U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191U2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pIDCLIENTE = A4IDCLIENTE;
         AssignAttri("", false, "AV13pIDCLIENTE", StringUtil.LTrimStr( (decimal)(AV13pIDCLIENTE), 12, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pIDCLIENTE});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pIDCLIENTE"});
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
         AV13pIDCLIENTE = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pIDCLIENTE", StringUtil.LTrimStr( (decimal)(AV13pIDCLIENTE), 12, 0));
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
         PA1U2( ) ;
         WS1U2( ) ;
         WE1U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202111280105632", true, true);
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
         context.AddJavascriptSource("gx0080.js", "?202111280105632", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtIDCLIENTE_Internalname = "IDCLIENTE_"+sGXsfl_64_idx;
         edtTELEFONOCLIENTE_Internalname = "TELEFONOCLIENTE_"+sGXsfl_64_idx;
         edtFECHANACIMIENTOCLIENTE_Internalname = "FECHANACIMIENTOCLIENTE_"+sGXsfl_64_idx;
         edtFECHAREGISTROCLIENTE_Internalname = "FECHAREGISTROCLIENTE_"+sGXsfl_64_idx;
         edtFOTOCLIENTE_Internalname = "FOTOCLIENTE_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtIDCLIENTE_Internalname = "IDCLIENTE_"+sGXsfl_64_fel_idx;
         edtTELEFONOCLIENTE_Internalname = "TELEFONOCLIENTE_"+sGXsfl_64_fel_idx;
         edtFECHANACIMIENTOCLIENTE_Internalname = "FECHANACIMIENTOCLIENTE_"+sGXsfl_64_fel_idx;
         edtFECHAREGISTROCLIENTE_Internalname = "FECHAREGISTROCLIENTE_"+sGXsfl_64_fel_idx;
         edtFOTOCLIENTE_Internalname = "FOTOCLIENTE_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB1U0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDCLIENTE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A33TELEFONOCLIENTE);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTELEFONOCLIENTE_Internalname,StringUtil.RTrim( A33TELEFONOCLIENTE),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtTELEFONOCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFECHANACIMIENTOCLIENTE_Internalname,context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"),context.localUtil.Format( A35FECHANACIMIENTOCLIENTE, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFECHANACIMIENTOCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFECHAREGISTROCLIENTE_Internalname,context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"),context.localUtil.Format( A37FECHAREGISTROCLIENTE, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFECHAREGISTROCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A53FOTOCLIENTE_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FOTOCLIENTE_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.PathToRelativeUrl( A53FOTOCLIENTE));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtFOTOCLIENTE_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A53FOTOCLIENTE_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes1U2( ) ;
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
         lblLblidclientefilter_Internalname = "LBLIDCLIENTEFILTER";
         edtavCidcliente_Internalname = "vCIDCLIENTE";
         divIdclientefiltercontainer_Internalname = "IDCLIENTEFILTERCONTAINER";
         lblLbltelefonoclientefilter_Internalname = "LBLTELEFONOCLIENTEFILTER";
         edtavCtelefonocliente_Internalname = "vCTELEFONOCLIENTE";
         divTelefonoclientefiltercontainer_Internalname = "TELEFONOCLIENTEFILTERCONTAINER";
         lblLblcorreoclientefilter_Internalname = "LBLCORREOCLIENTEFILTER";
         edtavCcorreocliente_Internalname = "vCCORREOCLIENTE";
         divCorreoclientefiltercontainer_Internalname = "CORREOCLIENTEFILTERCONTAINER";
         lblLblfechanacimientoclientefilter_Internalname = "LBLFECHANACIMIENTOCLIENTEFILTER";
         edtavCfechanacimientocliente_Internalname = "vCFECHANACIMIENTOCLIENTE";
         divFechanacimientoclientefiltercontainer_Internalname = "FECHANACIMIENTOCLIENTEFILTERCONTAINER";
         lblLblfecharegistroclientefilter_Internalname = "LBLFECHAREGISTROCLIENTEFILTER";
         edtavCfecharegistrocliente_Internalname = "vCFECHAREGISTROCLIENTE";
         divFecharegistroclientefiltercontainer_Internalname = "FECHAREGISTROCLIENTEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtIDCLIENTE_Internalname = "IDCLIENTE";
         edtTELEFONOCLIENTE_Internalname = "TELEFONOCLIENTE";
         edtFECHANACIMIENTOCLIENTE_Internalname = "FECHANACIMIENTOCLIENTE";
         edtFECHAREGISTROCLIENTE_Internalname = "FECHAREGISTROCLIENTE";
         edtFOTOCLIENTE_Internalname = "FOTOCLIENTE";
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
         edtFECHAREGISTROCLIENTE_Jsonclick = "";
         edtFECHANACIMIENTOCLIENTE_Jsonclick = "";
         edtTELEFONOCLIENTE_Jsonclick = "";
         edtIDCLIENTE_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCfecharegistrocliente_Jsonclick = "";
         edtavCfecharegistrocliente_Enabled = 1;
         edtavCfechanacimientocliente_Jsonclick = "";
         edtavCfechanacimientocliente_Enabled = 1;
         edtavCcorreocliente_Jsonclick = "";
         edtavCcorreocliente_Enabled = 1;
         edtavCcorreocliente_Visible = 1;
         edtavCtelefonocliente_Jsonclick = "";
         edtavCtelefonocliente_Enabled = 1;
         edtavCtelefonocliente_Visible = 1;
         edtavCidcliente_Jsonclick = "";
         edtavCidcliente_Enabled = 1;
         edtavCidcliente_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Clientes";
         divFecharegistroclientefiltercontainer_Class = "AdvancedContainerItem";
         divFechanacimientoclientefiltercontainer_Class = "AdvancedContainerItem";
         divCorreoclientefiltercontainer_Class = "AdvancedContainerItem";
         divTelefonoclientefiltercontainer_Class = "AdvancedContainerItem";
         divIdclientefiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCLIENTE',fld:'vCIDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOCLIENTE',fld:'vCTELEFONOCLIENTE',pic:''},{av:'AV11cCORREOCLIENTE',fld:'vCCORREOCLIENTE',pic:''},{av:'AV12cFECHANACIMIENTOCLIENTE',fld:'vCFECHANACIMIENTOCLIENTE',pic:''},{av:'AV15cFECHAREGISTROCLIENTE',fld:'vCFECHAREGISTROCLIENTE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E161U1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLIDCLIENTEFILTER.CLICK","{handler:'E111U1',iparms:[{av:'divIdclientefiltercontainer_Class',ctrl:'IDCLIENTEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDCLIENTEFILTER.CLICK",",oparms:[{av:'divIdclientefiltercontainer_Class',ctrl:'IDCLIENTEFILTERCONTAINER',prop:'Class'},{av:'edtavCidcliente_Visible',ctrl:'vCIDCLIENTE',prop:'Visible'}]}");
         setEventMetadata("LBLTELEFONOCLIENTEFILTER.CLICK","{handler:'E121U1',iparms:[{av:'divTelefonoclientefiltercontainer_Class',ctrl:'TELEFONOCLIENTEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTELEFONOCLIENTEFILTER.CLICK",",oparms:[{av:'divTelefonoclientefiltercontainer_Class',ctrl:'TELEFONOCLIENTEFILTERCONTAINER',prop:'Class'},{av:'edtavCtelefonocliente_Visible',ctrl:'vCTELEFONOCLIENTE',prop:'Visible'}]}");
         setEventMetadata("LBLCORREOCLIENTEFILTER.CLICK","{handler:'E131U1',iparms:[{av:'divCorreoclientefiltercontainer_Class',ctrl:'CORREOCLIENTEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORREOCLIENTEFILTER.CLICK",",oparms:[{av:'divCorreoclientefiltercontainer_Class',ctrl:'CORREOCLIENTEFILTERCONTAINER',prop:'Class'},{av:'edtavCcorreocliente_Visible',ctrl:'vCCORREOCLIENTE',prop:'Visible'}]}");
         setEventMetadata("LBLFECHANACIMIENTOCLIENTEFILTER.CLICK","{handler:'E141U1',iparms:[{av:'divFechanacimientoclientefiltercontainer_Class',ctrl:'FECHANACIMIENTOCLIENTEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFECHANACIMIENTOCLIENTEFILTER.CLICK",",oparms:[{av:'divFechanacimientoclientefiltercontainer_Class',ctrl:'FECHANACIMIENTOCLIENTEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLFECHAREGISTROCLIENTEFILTER.CLICK","{handler:'E151U1',iparms:[{av:'divFecharegistroclientefiltercontainer_Class',ctrl:'FECHAREGISTROCLIENTEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFECHAREGISTROCLIENTEFILTER.CLICK",",oparms:[{av:'divFecharegistroclientefiltercontainer_Class',ctrl:'FECHAREGISTROCLIENTEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E191U2',iparms:[{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pIDCLIENTE',fld:'vPIDCLIENTE',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCLIENTE',fld:'vCIDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOCLIENTE',fld:'vCTELEFONOCLIENTE',pic:''},{av:'AV11cCORREOCLIENTE',fld:'vCCORREOCLIENTE',pic:''},{av:'AV12cFECHANACIMIENTOCLIENTE',fld:'vCFECHANACIMIENTOCLIENTE',pic:''},{av:'AV15cFECHAREGISTROCLIENTE',fld:'vCFECHAREGISTROCLIENTE',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCLIENTE',fld:'vCIDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOCLIENTE',fld:'vCTELEFONOCLIENTE',pic:''},{av:'AV11cCORREOCLIENTE',fld:'vCCORREOCLIENTE',pic:''},{av:'AV12cFECHANACIMIENTOCLIENTE',fld:'vCFECHANACIMIENTOCLIENTE',pic:''},{av:'AV15cFECHAREGISTROCLIENTE',fld:'vCFECHAREGISTROCLIENTE',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCLIENTE',fld:'vCIDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOCLIENTE',fld:'vCTELEFONOCLIENTE',pic:''},{av:'AV11cCORREOCLIENTE',fld:'vCCORREOCLIENTE',pic:''},{av:'AV12cFECHANACIMIENTOCLIENTE',fld:'vCFECHANACIMIENTOCLIENTE',pic:''},{av:'AV15cFECHAREGISTROCLIENTE',fld:'vCFECHAREGISTROCLIENTE',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDCLIENTE',fld:'vCIDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'AV10cTELEFONOCLIENTE',fld:'vCTELEFONOCLIENTE',pic:''},{av:'AV11cCORREOCLIENTE',fld:'vCCORREOCLIENTE',pic:''},{av:'AV12cFECHANACIMIENTOCLIENTE',fld:'vCFECHANACIMIENTOCLIENTE',pic:''},{av:'AV15cFECHAREGISTROCLIENTE',fld:'vCFECHAREGISTROCLIENTE',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCORREOCLIENTE","{handler:'Validv_Ccorreocliente',iparms:[]");
         setEventMetadata("VALIDV_CCORREOCLIENTE",",oparms:[]}");
         setEventMetadata("VALIDV_CFECHANACIMIENTOCLIENTE","{handler:'Validv_Cfechanacimientocliente',iparms:[]");
         setEventMetadata("VALIDV_CFECHANACIMIENTOCLIENTE",",oparms:[]}");
         setEventMetadata("VALIDV_CFECHAREGISTROCLIENTE","{handler:'Validv_Cfecharegistrocliente',iparms:[]");
         setEventMetadata("VALIDV_CFECHAREGISTROCLIENTE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Fotocliente',iparms:[]");
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
         AV10cTELEFONOCLIENTE = "";
         AV11cCORREOCLIENTE = "";
         AV12cFECHANACIMIENTOCLIENTE = DateTime.MinValue;
         AV15cFECHAREGISTROCLIENTE = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblidclientefilter_Jsonclick = "";
         TempTags = "";
         lblLbltelefonoclientefilter_Jsonclick = "";
         lblLblcorreoclientefilter_Jsonclick = "";
         lblLblfechanacimientoclientefilter_Jsonclick = "";
         lblLblfecharegistroclientefilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A33TELEFONOCLIENTE = "";
         A35FECHANACIMIENTOCLIENTE = DateTime.MinValue;
         A37FECHAREGISTROCLIENTE = DateTime.MinValue;
         A53FOTOCLIENTE = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Linkselection_GXI = "";
         A40000FOTOCLIENTE_GXI = "";
         scmdbuf = "";
         lV10cTELEFONOCLIENTE = "";
         lV11cCORREOCLIENTE = "";
         A34CORREOCLIENTE = "";
         H001U2_A34CORREOCLIENTE = new string[] {""} ;
         H001U2_A40000FOTOCLIENTE_GXI = new string[] {""} ;
         H001U2_A37FECHAREGISTROCLIENTE = new DateTime[] {DateTime.MinValue} ;
         H001U2_A35FECHANACIMIENTOCLIENTE = new DateTime[] {DateTime.MinValue} ;
         H001U2_A33TELEFONOCLIENTE = new string[] {""} ;
         H001U2_A4IDCLIENTE = new long[1] ;
         H001U2_A53FOTOCLIENTE = new string[] {""} ;
         H001U3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0080__default(),
            new Object[][] {
                new Object[] {
               H001U2_A34CORREOCLIENTE, H001U2_A40000FOTOCLIENTE_GXI, H001U2_A37FECHAREGISTROCLIENTE, H001U2_A35FECHANACIMIENTOCLIENTE, H001U2_A33TELEFONOCLIENTE, H001U2_A4IDCLIENTE, H001U2_A53FOTOCLIENTE
               }
               , new Object[] {
               H001U3_AGRID1_nRecordCount
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
      private int edtavCidcliente_Enabled ;
      private int edtavCidcliente_Visible ;
      private int edtavCtelefonocliente_Visible ;
      private int edtavCtelefonocliente_Enabled ;
      private int edtavCcorreocliente_Visible ;
      private int edtavCcorreocliente_Enabled ;
      private int edtavCfechanacimientocliente_Enabled ;
      private int edtavCfecharegistrocliente_Enabled ;
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
      private long AV13pIDCLIENTE ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cIDCLIENTE ;
      private long A4IDCLIENTE ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divIdclientefiltercontainer_Class ;
      private string divTelefonoclientefiltercontainer_Class ;
      private string divCorreoclientefiltercontainer_Class ;
      private string divFechanacimientoclientefiltercontainer_Class ;
      private string divFecharegistroclientefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV10cTELEFONOCLIENTE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divIdclientefiltercontainer_Internalname ;
      private string lblLblidclientefilter_Internalname ;
      private string lblLblidclientefilter_Jsonclick ;
      private string edtavCidcliente_Internalname ;
      private string TempTags ;
      private string edtavCidcliente_Jsonclick ;
      private string divTelefonoclientefiltercontainer_Internalname ;
      private string lblLbltelefonoclientefilter_Internalname ;
      private string lblLbltelefonoclientefilter_Jsonclick ;
      private string edtavCtelefonocliente_Internalname ;
      private string edtavCtelefonocliente_Jsonclick ;
      private string divCorreoclientefiltercontainer_Internalname ;
      private string lblLblcorreoclientefilter_Internalname ;
      private string lblLblcorreoclientefilter_Jsonclick ;
      private string edtavCcorreocliente_Internalname ;
      private string edtavCcorreocliente_Jsonclick ;
      private string divFechanacimientoclientefiltercontainer_Internalname ;
      private string lblLblfechanacimientoclientefilter_Internalname ;
      private string lblLblfechanacimientoclientefilter_Jsonclick ;
      private string edtavCfechanacimientocliente_Internalname ;
      private string edtavCfechanacimientocliente_Jsonclick ;
      private string divFecharegistroclientefiltercontainer_Internalname ;
      private string lblLblfecharegistroclientefilter_Internalname ;
      private string lblLblfecharegistroclientefilter_Jsonclick ;
      private string edtavCfecharegistrocliente_Internalname ;
      private string edtavCfecharegistrocliente_Jsonclick ;
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
      private string A33TELEFONOCLIENTE ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtIDCLIENTE_Internalname ;
      private string edtTELEFONOCLIENTE_Internalname ;
      private string edtFECHANACIMIENTOCLIENTE_Internalname ;
      private string edtFECHAREGISTROCLIENTE_Internalname ;
      private string edtFOTOCLIENTE_Internalname ;
      private string scmdbuf ;
      private string lV10cTELEFONOCLIENTE ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtIDCLIENTE_Jsonclick ;
      private string gxphoneLink ;
      private string edtTELEFONOCLIENTE_Jsonclick ;
      private string edtFECHANACIMIENTOCLIENTE_Jsonclick ;
      private string edtFECHAREGISTROCLIENTE_Jsonclick ;
      private DateTime AV12cFECHANACIMIENTOCLIENTE ;
      private DateTime AV15cFECHAREGISTROCLIENTE ;
      private DateTime A35FECHANACIMIENTOCLIENTE ;
      private DateTime A37FECHAREGISTROCLIENTE ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A53FOTOCLIENTE_IsBlob ;
      private string AV11cCORREOCLIENTE ;
      private string AV18Linkselection_GXI ;
      private string A40000FOTOCLIENTE_GXI ;
      private string lV11cCORREOCLIENTE ;
      private string A34CORREOCLIENTE ;
      private string AV5LinkSelection ;
      private string A53FOTOCLIENTE ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H001U2_A34CORREOCLIENTE ;
      private string[] H001U2_A40000FOTOCLIENTE_GXI ;
      private DateTime[] H001U2_A37FECHAREGISTROCLIENTE ;
      private DateTime[] H001U2_A35FECHANACIMIENTOCLIENTE ;
      private string[] H001U2_A33TELEFONOCLIENTE ;
      private long[] H001U2_A4IDCLIENTE ;
      private string[] H001U2_A53FOTOCLIENTE ;
      private long[] H001U3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pIDCLIENTE ;
      private GXWebForm Form ;
   }

   public class gx0080__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001U2( IGxContext context ,
                                             string AV10cTELEFONOCLIENTE ,
                                             string AV11cCORREOCLIENTE ,
                                             DateTime AV12cFECHANACIMIENTOCLIENTE ,
                                             DateTime AV15cFECHAREGISTROCLIENTE ,
                                             string A33TELEFONOCLIENTE ,
                                             string A34CORREOCLIENTE ,
                                             DateTime A35FECHANACIMIENTOCLIENTE ,
                                             DateTime A37FECHAREGISTROCLIENTE ,
                                             long AV6cIDCLIENTE )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CORREOCLIENTE], [FOTOCLIENTE_GXI], [FECHAREGISTROCLIENTE], [FECHANACIMIENTOCLIENTE], [TELEFONOCLIENTE], [IDCLIENTE], [FOTOCLIENTE]";
         sFromString = " FROM [Clientes]";
         sOrderString = "";
         AddWhere(sWhereString, "([IDCLIENTE] >= @AV6cIDCLIENTE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cTELEFONOCLIENTE)) )
         {
            AddWhere(sWhereString, "([TELEFONOCLIENTE] like @lV10cTELEFONOCLIENTE)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCORREOCLIENTE)) )
         {
            AddWhere(sWhereString, "([CORREOCLIENTE] like @lV11cCORREOCLIENTE)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cFECHANACIMIENTOCLIENTE) )
         {
            AddWhere(sWhereString, "([FECHANACIMIENTOCLIENTE] >= @AV12cFECHANACIMIENTOCLIENTE)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV15cFECHAREGISTROCLIENTE) )
         {
            AddWhere(sWhereString, "([FECHAREGISTROCLIENTE] >= @AV15cFECHAREGISTROCLIENTE)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [IDCLIENTE]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001U3( IGxContext context ,
                                             string AV10cTELEFONOCLIENTE ,
                                             string AV11cCORREOCLIENTE ,
                                             DateTime AV12cFECHANACIMIENTOCLIENTE ,
                                             DateTime AV15cFECHAREGISTROCLIENTE ,
                                             string A33TELEFONOCLIENTE ,
                                             string A34CORREOCLIENTE ,
                                             DateTime A35FECHANACIMIENTOCLIENTE ,
                                             DateTime A37FECHAREGISTROCLIENTE ,
                                             long AV6cIDCLIENTE )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Clientes]";
         AddWhere(sWhereString, "([IDCLIENTE] >= @AV6cIDCLIENTE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cTELEFONOCLIENTE)) )
         {
            AddWhere(sWhereString, "([TELEFONOCLIENTE] like @lV10cTELEFONOCLIENTE)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cCORREOCLIENTE)) )
         {
            AddWhere(sWhereString, "([CORREOCLIENTE] like @lV11cCORREOCLIENTE)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cFECHANACIMIENTOCLIENTE) )
         {
            AddWhere(sWhereString, "([FECHANACIMIENTOCLIENTE] >= @AV12cFECHANACIMIENTOCLIENTE)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV15cFECHAREGISTROCLIENTE) )
         {
            AddWhere(sWhereString, "([FECHAREGISTROCLIENTE] >= @AV15cFECHAREGISTROCLIENTE)");
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
                     return conditional_H001U2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] );
               case 1 :
                     return conditional_H001U3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] );
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
          Object[] prmH001U2;
          prmH001U2 = new Object[] {
          new ParDef("@AV6cIDCLIENTE",GXType.Decimal,12,0) ,
          new ParDef("@lV10cTELEFONOCLIENTE",GXType.NChar,20,0) ,
          new ParDef("@lV11cCORREOCLIENTE",GXType.NVarChar,100,0) ,
          new ParDef("@AV12cFECHANACIMIENTOCLIENTE",GXType.Date,8,0) ,
          new ParDef("@AV15cFECHAREGISTROCLIENTE",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001U3;
          prmH001U3 = new Object[] {
          new ParDef("@AV6cIDCLIENTE",GXType.Decimal,12,0) ,
          new ParDef("@lV10cTELEFONOCLIENTE",GXType.NChar,20,0) ,
          new ParDef("@lV11cCORREOCLIENTE",GXType.NVarChar,100,0) ,
          new ParDef("@AV12cFECHANACIMIENTOCLIENTE",GXType.Date,8,0) ,
          new ParDef("@AV15cFECHAREGISTROCLIENTE",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001U2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001U3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
