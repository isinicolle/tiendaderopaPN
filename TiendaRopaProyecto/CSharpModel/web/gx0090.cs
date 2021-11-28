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
   public class gx0090 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0090( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0090( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pIDPRODUCTO )
      {
         this.AV13pIDPRODUCTO = 0 ;
         executePrivate();
         aP0_pIDPRODUCTO=this.AV13pIDPRODUCTO;
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
            gxfirstwebparm = GetFirstPar( "pIDPRODUCTO");
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
               gxfirstwebparm = GetFirstPar( "pIDPRODUCTO");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pIDPRODUCTO");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."));
               sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
               AV6cIDPRODUCTO = (long)(NumberUtil.Val( GetPar( "cIDPRODUCTO"), "."));
               AV8cCANTIDADPRODUCTO = (long)(NumberUtil.Val( GetPar( "cCANTIDADPRODUCTO"), "."));
               AV9cPRECIOCOMPRAPRODUCTO = NumberUtil.Val( GetPar( "cPRECIOCOMPRAPRODUCTO"), ".");
               AV10cPRECIOVENTAPRODUCTO = NumberUtil.Val( GetPar( "cPRECIOVENTAPRODUCTO"), ".");
               AV11cIDESTADOPRODUCTO = (long)(NumberUtil.Val( GetPar( "cIDESTADOPRODUCTO"), "."));
               AV12cIDCATEGORIAPRODUCTO = (long)(NumberUtil.Val( GetPar( "cIDCATEGORIAPRODUCTO"), "."));
               AV15cIDMARCAPRODUCTO = (long)(NumberUtil.Val( GetPar( "cIDMARCAPRODUCTO"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "IDPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdproductofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "CANTIDADPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divCantidadproductofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "PRECIOCOMPRAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divPreciocompraproductofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "PRECIOVENTAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divPrecioventaproductofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "IDESTADOPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdestadoproductofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "IDCATEGORIAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdcategoriaproductofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "IDMARCAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdmarcaproductofiltercontainer_Class));
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
               AV13pIDPRODUCTO = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pIDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV13pIDPRODUCTO), 12, 0));
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
         PA1V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1V2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021112620513440", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pIDPRODUCTO,12,0))}, new string[] {"pIDPRODUCTO"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCIDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCANTIDADPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCANTIDADPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRECIOCOMPRAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( AV9cPRECIOCOMPRAPRODUCTO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRECIOVENTAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( AV10cPRECIOVENTAPRODUCTO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCIDESTADOPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cIDESTADOPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCIDCATEGORIAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cIDCATEGORIAPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCIDMARCAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cIDMARCAPRODUCTO), 12, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPIDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pIDPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "IDPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdproductofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CANTIDADPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divCantidadproductofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRECIOCOMPRAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divPreciocompraproductofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRECIOVENTAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divPrecioventaproductofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IDESTADOPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdestadoproductofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IDCATEGORIAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdcategoriaproductofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "IDMARCAPRODUCTOFILTERCONTAINER_Class", StringUtil.RTrim( divIdmarcaproductofiltercontainer_Class));
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
            WE1V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1V2( ) ;
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
         return formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pIDPRODUCTO,12,0))}, new string[] {"pIDPRODUCTO"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0090" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Inventario" ;
      }

      protected void WB1V0( )
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
            GxWebStd.gx_div_start( context, divIdproductofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdproductofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidproductofilter_Internalname, "IDPRODUCTO", "", "", lblLblidproductofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidproducto_Internalname, "IDPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidproducto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cIDPRODUCTO), 12, 0, ".", "")), ((edtavCidproducto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cIDPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cIDPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidproducto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidproducto_Visible, edtavCidproducto_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divCantidadproductofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCantidadproductofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcantidadproductofilter_Internalname, "CANTIDADPRODUCTO", "", "", lblLblcantidadproductofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcantidadproducto_Internalname, "CANTIDADPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcantidadproducto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCANTIDADPRODUCTO), 12, 0, ".", "")), ((edtavCcantidadproducto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8cCANTIDADPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV8cCANTIDADPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcantidadproducto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcantidadproducto_Visible, edtavCcantidadproducto_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divPreciocompraproductofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPreciocompraproductofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpreciocompraproductofilter_Internalname, "PRECIOCOMPRAPRODUCTO", "", "", lblLblpreciocompraproductofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpreciocompraproducto_Internalname, "PRECIOCOMPRAPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpreciocompraproducto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cPRECIOCOMPRAPRODUCTO, 12, 2, ".", "")), ((edtavCpreciocompraproducto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( AV9cPRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( AV9cPRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpreciocompraproducto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpreciocompraproducto_Visible, edtavCpreciocompraproducto_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divPrecioventaproductofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPrecioventaproductofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprecioventaproductofilter_Internalname, "PRECIOVENTAPRODUCTO", "", "", lblLblprecioventaproductofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprecioventaproducto_Internalname, "PRECIOVENTAPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprecioventaproducto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cPRECIOVENTAPRODUCTO, 12, 2, ".", "")), ((edtavCprecioventaproducto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( AV10cPRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( AV10cPRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprecioventaproducto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprecioventaproducto_Visible, edtavCprecioventaproducto_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divIdestadoproductofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdestadoproductofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidestadoproductofilter_Internalname, "IDESTADOPRODUCTO", "", "", lblLblidestadoproductofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidestadoproducto_Internalname, "IDESTADOPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidestadoproducto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cIDESTADOPRODUCTO), 12, 0, ".", "")), ((edtavCidestadoproducto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11cIDESTADOPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV11cIDESTADOPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidestadoproducto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidestadoproducto_Visible, edtavCidestadoproducto_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divIdcategoriaproductofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdcategoriaproductofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidcategoriaproductofilter_Internalname, "IDCATEGORIAPRODUCTO", "", "", lblLblidcategoriaproductofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e161v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidcategoriaproducto_Internalname, "IDCATEGORIAPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidcategoriaproducto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cIDCATEGORIAPRODUCTO), 12, 0, ".", "")), ((edtavCidcategoriaproducto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12cIDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV12cIDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidcategoriaproducto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidcategoriaproducto_Visible, edtavCidcategoriaproducto_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divIdmarcaproductofiltercontainer_Internalname, 1, 0, "px", 0, "px", divIdmarcaproductofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblidmarcaproductofilter_Internalname, "IDMARCAPRODUCTO", "", "", lblLblidmarcaproductofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e171v1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCidmarcaproducto_Internalname, "IDMARCAPRODUCTO", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCidmarcaproducto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cIDMARCAPRODUCTO), 12, 0, ".", "")), ((edtavCidmarcaproducto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15cIDMARCAPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV15cIDMARCAPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCidmarcaproducto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCidmarcaproducto_Visible, edtavCidmarcaproducto_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e181v1_client"+"'", TempTags, "", 2, "HLP_Gx0090.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
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
               context.SendWebValue( "IDPRODUCTO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "CANTIDADPRODUCTO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "PRECIOCOMPRAPRODUCTO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "PRECIOVENTAPRODUCTO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDESTADOPRODUCTO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDCATEGORIAPRODUCTO") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "IDMARCAPRODUCTO") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5IDESTADOPRODUCTO), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8IDMARCAPRODUCTO), 12, 0, ".", "")));
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
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void START1V2( )
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
            Form.Meta.addItem("description", "Selection List Inventario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1V0( ) ;
      }

      protected void WS1V2( )
      {
         START1V2( ) ;
         EVT1V2( ) ;
      }

      protected void EVT1V2( )
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
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDPRODUCTO_Internalname), ".", ","));
                              A41CANTIDADPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtCANTIDADPRODUCTO_Internalname), ".", ","));
                              A42PRECIOCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOCOMPRAPRODUCTO_Internalname), ".", ",");
                              A43PRECIOVENTAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOVENTAPRODUCTO_Internalname), ".", ",");
                              A5IDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDESTADOPRODUCTO_Internalname), ".", ","));
                              A6IDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDCATEGORIAPRODUCTO_Internalname), ".", ","));
                              A8IDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDMARCAPRODUCTO_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E191V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E201V2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cidproducto Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDPRODUCTO"), ".", ",") != Convert.ToDecimal( AV6cIDPRODUCTO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccantidadproducto Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCANTIDADPRODUCTO"), ".", ",") != Convert.ToDecimal( AV8cCANTIDADPRODUCTO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpreciocompraproducto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPRECIOCOMPRAPRODUCTO"), ".", ",") != AV9cPRECIOCOMPRAPRODUCTO )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprecioventaproducto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPRECIOVENTAPRODUCTO"), ".", ",") != AV10cPRECIOVENTAPRODUCTO )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cidestadoproducto Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDESTADOPRODUCTO"), ".", ",") != Convert.ToDecimal( AV11cIDESTADOPRODUCTO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cidcategoriaproducto Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDCATEGORIAPRODUCTO"), ".", ",") != Convert.ToDecimal( AV12cIDCATEGORIAPRODUCTO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cidmarcaproducto Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDMARCAPRODUCTO"), ".", ",") != Convert.ToDecimal( AV15cIDMARCAPRODUCTO )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E211V2 ();
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

      protected void WE1V2( )
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

      protected void PA1V2( )
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
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cIDPRODUCTO ,
                                        long AV8cCANTIDADPRODUCTO ,
                                        decimal AV9cPRECIOCOMPRAPRODUCTO ,
                                        decimal AV10cPRECIOVENTAPRODUCTO ,
                                        long AV11cIDESTADOPRODUCTO ,
                                        long AV12cIDCATEGORIAPRODUCTO ,
                                        long AV15cIDMARCAPRODUCTO )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1V2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDPRODUCTO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "IDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")));
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
         RF1V2( ) ;
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

      protected void RF1V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
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
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cCANTIDADPRODUCTO ,
                                                 AV9cPRECIOCOMPRAPRODUCTO ,
                                                 AV10cPRECIOVENTAPRODUCTO ,
                                                 AV11cIDESTADOPRODUCTO ,
                                                 AV12cIDCATEGORIAPRODUCTO ,
                                                 AV15cIDMARCAPRODUCTO ,
                                                 A41CANTIDADPRODUCTO ,
                                                 A42PRECIOCOMPRAPRODUCTO ,
                                                 A43PRECIOVENTAPRODUCTO ,
                                                 A5IDESTADOPRODUCTO ,
                                                 A6IDCATEGORIAPRODUCTO ,
                                                 A8IDMARCAPRODUCTO ,
                                                 AV6cIDPRODUCTO } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H001V2 */
            pr_default.execute(0, new Object[] {AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A8IDMARCAPRODUCTO = H001V2_A8IDMARCAPRODUCTO[0];
               A6IDCATEGORIAPRODUCTO = H001V2_A6IDCATEGORIAPRODUCTO[0];
               A5IDESTADOPRODUCTO = H001V2_A5IDESTADOPRODUCTO[0];
               A43PRECIOVENTAPRODUCTO = H001V2_A43PRECIOVENTAPRODUCTO[0];
               A42PRECIOCOMPRAPRODUCTO = H001V2_A42PRECIOCOMPRAPRODUCTO[0];
               A41CANTIDADPRODUCTO = H001V2_A41CANTIDADPRODUCTO[0];
               A7IDPRODUCTO = H001V2_A7IDPRODUCTO[0];
               /* Execute user event: Load */
               E201V2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB1V0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1V2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDPRODUCTO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9"), context));
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
                                              AV8cCANTIDADPRODUCTO ,
                                              AV9cPRECIOCOMPRAPRODUCTO ,
                                              AV10cPRECIOVENTAPRODUCTO ,
                                              AV11cIDESTADOPRODUCTO ,
                                              AV12cIDCATEGORIAPRODUCTO ,
                                              AV15cIDMARCAPRODUCTO ,
                                              A41CANTIDADPRODUCTO ,
                                              A42PRECIOCOMPRAPRODUCTO ,
                                              A43PRECIOVENTAPRODUCTO ,
                                              A5IDESTADOPRODUCTO ,
                                              A6IDCATEGORIAPRODUCTO ,
                                              A8IDMARCAPRODUCTO ,
                                              AV6cIDPRODUCTO } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H001V3 */
         pr_default.execute(1, new Object[] {AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO});
         GRID1_nRecordCount = H001V3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cIDPRODUCTO, AV8cCANTIDADPRODUCTO, AV9cPRECIOCOMPRAPRODUCTO, AV10cPRECIOVENTAPRODUCTO, AV11cIDESTADOPRODUCTO, AV12cIDCATEGORIAPRODUCTO, AV15cIDMARCAPRODUCTO) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E191V2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidproducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidproducto_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDPRODUCTO");
               GX_FocusControl = edtavCidproducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cIDPRODUCTO = 0;
               AssignAttri("", false, "AV6cIDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV6cIDPRODUCTO), 12, 0));
            }
            else
            {
               AV6cIDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtavCidproducto_Internalname), ".", ","));
               AssignAttri("", false, "AV6cIDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV6cIDPRODUCTO), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcantidadproducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcantidadproducto_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCANTIDADPRODUCTO");
               GX_FocusControl = edtavCcantidadproducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCANTIDADPRODUCTO = 0;
               AssignAttri("", false, "AV8cCANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(AV8cCANTIDADPRODUCTO), 12, 0));
            }
            else
            {
               AV8cCANTIDADPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtavCcantidadproducto_Internalname), ".", ","));
               AssignAttri("", false, "AV8cCANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(AV8cCANTIDADPRODUCTO), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpreciocompraproducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpreciocompraproducto_Internalname), ".", ",") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRECIOCOMPRAPRODUCTO");
               GX_FocusControl = edtavCpreciocompraproducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cPRECIOCOMPRAPRODUCTO = 0;
               AssignAttri("", false, "AV9cPRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( AV9cPRECIOCOMPRAPRODUCTO, 12, 2));
            }
            else
            {
               AV9cPRECIOCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtavCpreciocompraproducto_Internalname), ".", ",");
               AssignAttri("", false, "AV9cPRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( AV9cPRECIOCOMPRAPRODUCTO, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprecioventaproducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprecioventaproducto_Internalname), ".", ",") > 999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRECIOVENTAPRODUCTO");
               GX_FocusControl = edtavCprecioventaproducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cPRECIOVENTAPRODUCTO = 0;
               AssignAttri("", false, "AV10cPRECIOVENTAPRODUCTO", StringUtil.LTrimStr( AV10cPRECIOVENTAPRODUCTO, 12, 2));
            }
            else
            {
               AV10cPRECIOVENTAPRODUCTO = context.localUtil.CToN( cgiGet( edtavCprecioventaproducto_Internalname), ".", ",");
               AssignAttri("", false, "AV10cPRECIOVENTAPRODUCTO", StringUtil.LTrimStr( AV10cPRECIOVENTAPRODUCTO, 12, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidestadoproducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidestadoproducto_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDESTADOPRODUCTO");
               GX_FocusControl = edtavCidestadoproducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cIDESTADOPRODUCTO = 0;
               AssignAttri("", false, "AV11cIDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(AV11cIDESTADOPRODUCTO), 12, 0));
            }
            else
            {
               AV11cIDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtavCidestadoproducto_Internalname), ".", ","));
               AssignAttri("", false, "AV11cIDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(AV11cIDESTADOPRODUCTO), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidcategoriaproducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidcategoriaproducto_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDCATEGORIAPRODUCTO");
               GX_FocusControl = edtavCidcategoriaproducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cIDCATEGORIAPRODUCTO = 0;
               AssignAttri("", false, "AV12cIDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV12cIDCATEGORIAPRODUCTO), 12, 0));
            }
            else
            {
               AV12cIDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtavCidcategoriaproducto_Internalname), ".", ","));
               AssignAttri("", false, "AV12cIDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV12cIDCATEGORIAPRODUCTO), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCidmarcaproducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCidmarcaproducto_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCIDMARCAPRODUCTO");
               GX_FocusControl = edtavCidmarcaproducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cIDMARCAPRODUCTO = 0;
               AssignAttri("", false, "AV15cIDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV15cIDMARCAPRODUCTO), 12, 0));
            }
            else
            {
               AV15cIDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtavCidmarcaproducto_Internalname), ".", ","));
               AssignAttri("", false, "AV15cIDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV15cIDMARCAPRODUCTO), 12, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDPRODUCTO"), ".", ",") != Convert.ToDecimal( AV6cIDPRODUCTO )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCANTIDADPRODUCTO"), ".", ",") != Convert.ToDecimal( AV8cCANTIDADPRODUCTO )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPRECIOCOMPRAPRODUCTO"), ".", ",") != AV9cPRECIOCOMPRAPRODUCTO )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPRECIOVENTAPRODUCTO"), ".", ",") != AV10cPRECIOVENTAPRODUCTO )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDESTADOPRODUCTO"), ".", ",") != Convert.ToDecimal( AV11cIDESTADOPRODUCTO )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDCATEGORIAPRODUCTO"), ".", ",") != Convert.ToDecimal( AV12cIDCATEGORIAPRODUCTO )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCIDMARCAPRODUCTO"), ".", ",") != Convert.ToDecimal( AV15cIDMARCAPRODUCTO )) )
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
         E191V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191V2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Inventario", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E201V2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E211V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E211V2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pIDPRODUCTO = A7IDPRODUCTO;
         AssignAttri("", false, "AV13pIDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV13pIDPRODUCTO), 12, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pIDPRODUCTO});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pIDPRODUCTO"});
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
         AV13pIDPRODUCTO = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pIDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV13pIDPRODUCTO), 12, 0));
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
         PA1V2( ) ;
         WS1V2( ) ;
         WE1V2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021112620513499", true, true);
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
         context.AddJavascriptSource("gx0090.js", "?2021112620513499", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtIDPRODUCTO_Internalname = "IDPRODUCTO_"+sGXsfl_84_idx;
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO_"+sGXsfl_84_idx;
         edtPRECIOCOMPRAPRODUCTO_Internalname = "PRECIOCOMPRAPRODUCTO_"+sGXsfl_84_idx;
         edtPRECIOVENTAPRODUCTO_Internalname = "PRECIOVENTAPRODUCTO_"+sGXsfl_84_idx;
         edtIDESTADOPRODUCTO_Internalname = "IDESTADOPRODUCTO_"+sGXsfl_84_idx;
         edtIDCATEGORIAPRODUCTO_Internalname = "IDCATEGORIAPRODUCTO_"+sGXsfl_84_idx;
         edtIDMARCAPRODUCTO_Internalname = "IDMARCAPRODUCTO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtIDPRODUCTO_Internalname = "IDPRODUCTO_"+sGXsfl_84_fel_idx;
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO_"+sGXsfl_84_fel_idx;
         edtPRECIOCOMPRAPRODUCTO_Internalname = "PRECIOCOMPRAPRODUCTO_"+sGXsfl_84_fel_idx;
         edtPRECIOVENTAPRODUCTO_Internalname = "PRECIOVENTAPRODUCTO_"+sGXsfl_84_fel_idx;
         edtIDESTADOPRODUCTO_Internalname = "IDESTADOPRODUCTO_"+sGXsfl_84_fel_idx;
         edtIDCATEGORIAPRODUCTO_Internalname = "IDCATEGORIAPRODUCTO_"+sGXsfl_84_fel_idx;
         edtIDMARCAPRODUCTO_Internalname = "IDMARCAPRODUCTO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB1V0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCANTIDADPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCANTIDADPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Cantidad",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPRECIOCOMPRAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")),context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPRECIOCOMPRAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPRECIOVENTAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")),context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPRECIOVENTAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDESTADOPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5IDESTADOPRODUCTO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A5IDESTADOPRODUCTO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDESTADOPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDCATEGORIAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A6IDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDCATEGORIAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDMARCAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8IDMARCAPRODUCTO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A8IDMARCAPRODUCTO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDMARCAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1V2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblidproductofilter_Internalname = "LBLIDPRODUCTOFILTER";
         edtavCidproducto_Internalname = "vCIDPRODUCTO";
         divIdproductofiltercontainer_Internalname = "IDPRODUCTOFILTERCONTAINER";
         lblLblcantidadproductofilter_Internalname = "LBLCANTIDADPRODUCTOFILTER";
         edtavCcantidadproducto_Internalname = "vCCANTIDADPRODUCTO";
         divCantidadproductofiltercontainer_Internalname = "CANTIDADPRODUCTOFILTERCONTAINER";
         lblLblpreciocompraproductofilter_Internalname = "LBLPRECIOCOMPRAPRODUCTOFILTER";
         edtavCpreciocompraproducto_Internalname = "vCPRECIOCOMPRAPRODUCTO";
         divPreciocompraproductofiltercontainer_Internalname = "PRECIOCOMPRAPRODUCTOFILTERCONTAINER";
         lblLblprecioventaproductofilter_Internalname = "LBLPRECIOVENTAPRODUCTOFILTER";
         edtavCprecioventaproducto_Internalname = "vCPRECIOVENTAPRODUCTO";
         divPrecioventaproductofiltercontainer_Internalname = "PRECIOVENTAPRODUCTOFILTERCONTAINER";
         lblLblidestadoproductofilter_Internalname = "LBLIDESTADOPRODUCTOFILTER";
         edtavCidestadoproducto_Internalname = "vCIDESTADOPRODUCTO";
         divIdestadoproductofiltercontainer_Internalname = "IDESTADOPRODUCTOFILTERCONTAINER";
         lblLblidcategoriaproductofilter_Internalname = "LBLIDCATEGORIAPRODUCTOFILTER";
         edtavCidcategoriaproducto_Internalname = "vCIDCATEGORIAPRODUCTO";
         divIdcategoriaproductofiltercontainer_Internalname = "IDCATEGORIAPRODUCTOFILTERCONTAINER";
         lblLblidmarcaproductofilter_Internalname = "LBLIDMARCAPRODUCTOFILTER";
         edtavCidmarcaproducto_Internalname = "vCIDMARCAPRODUCTO";
         divIdmarcaproductofiltercontainer_Internalname = "IDMARCAPRODUCTOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtIDPRODUCTO_Internalname = "IDPRODUCTO";
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO";
         edtPRECIOCOMPRAPRODUCTO_Internalname = "PRECIOCOMPRAPRODUCTO";
         edtPRECIOVENTAPRODUCTO_Internalname = "PRECIOVENTAPRODUCTO";
         edtIDESTADOPRODUCTO_Internalname = "IDESTADOPRODUCTO";
         edtIDCATEGORIAPRODUCTO_Internalname = "IDCATEGORIAPRODUCTO";
         edtIDMARCAPRODUCTO_Internalname = "IDMARCAPRODUCTO";
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
         edtIDMARCAPRODUCTO_Jsonclick = "";
         edtIDCATEGORIAPRODUCTO_Jsonclick = "";
         edtIDESTADOPRODUCTO_Jsonclick = "";
         edtPRECIOVENTAPRODUCTO_Jsonclick = "";
         edtPRECIOCOMPRAPRODUCTO_Jsonclick = "";
         edtCANTIDADPRODUCTO_Jsonclick = "";
         edtIDPRODUCTO_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCidmarcaproducto_Jsonclick = "";
         edtavCidmarcaproducto_Enabled = 1;
         edtavCidmarcaproducto_Visible = 1;
         edtavCidcategoriaproducto_Jsonclick = "";
         edtavCidcategoriaproducto_Enabled = 1;
         edtavCidcategoriaproducto_Visible = 1;
         edtavCidestadoproducto_Jsonclick = "";
         edtavCidestadoproducto_Enabled = 1;
         edtavCidestadoproducto_Visible = 1;
         edtavCprecioventaproducto_Jsonclick = "";
         edtavCprecioventaproducto_Enabled = 1;
         edtavCprecioventaproducto_Visible = 1;
         edtavCpreciocompraproducto_Jsonclick = "";
         edtavCpreciocompraproducto_Enabled = 1;
         edtavCpreciocompraproducto_Visible = 1;
         edtavCcantidadproducto_Jsonclick = "";
         edtavCcantidadproducto_Enabled = 1;
         edtavCcantidadproducto_Visible = 1;
         edtavCidproducto_Jsonclick = "";
         edtavCidproducto_Enabled = 1;
         edtavCidproducto_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Inventario";
         divIdmarcaproductofiltercontainer_Class = "AdvancedContainerItem";
         divIdcategoriaproductofiltercontainer_Class = "AdvancedContainerItem";
         divIdestadoproductofiltercontainer_Class = "AdvancedContainerItem";
         divPrecioventaproductofiltercontainer_Class = "AdvancedContainerItem";
         divPreciocompraproductofiltercontainer_Class = "AdvancedContainerItem";
         divCantidadproductofiltercontainer_Class = "AdvancedContainerItem";
         divIdproductofiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDPRODUCTO',fld:'vCIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV8cCANTIDADPRODUCTO',fld:'vCCANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV9cPRECIOCOMPRAPRODUCTO',fld:'vCPRECIOCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV10cPRECIOVENTAPRODUCTO',fld:'vCPRECIOVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV11cIDESTADOPRODUCTO',fld:'vCIDESTADOPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12cIDCATEGORIAPRODUCTO',fld:'vCIDCATEGORIAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV15cIDMARCAPRODUCTO',fld:'vCIDMARCAPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E181V1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLIDPRODUCTOFILTER.CLICK","{handler:'E111V1',iparms:[{av:'divIdproductofiltercontainer_Class',ctrl:'IDPRODUCTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDPRODUCTOFILTER.CLICK",",oparms:[{av:'divIdproductofiltercontainer_Class',ctrl:'IDPRODUCTOFILTERCONTAINER',prop:'Class'},{av:'edtavCidproducto_Visible',ctrl:'vCIDPRODUCTO',prop:'Visible'}]}");
         setEventMetadata("LBLCANTIDADPRODUCTOFILTER.CLICK","{handler:'E121V1',iparms:[{av:'divCantidadproductofiltercontainer_Class',ctrl:'CANTIDADPRODUCTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCANTIDADPRODUCTOFILTER.CLICK",",oparms:[{av:'divCantidadproductofiltercontainer_Class',ctrl:'CANTIDADPRODUCTOFILTERCONTAINER',prop:'Class'},{av:'edtavCcantidadproducto_Visible',ctrl:'vCCANTIDADPRODUCTO',prop:'Visible'}]}");
         setEventMetadata("LBLPRECIOCOMPRAPRODUCTOFILTER.CLICK","{handler:'E131V1',iparms:[{av:'divPreciocompraproductofiltercontainer_Class',ctrl:'PRECIOCOMPRAPRODUCTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRECIOCOMPRAPRODUCTOFILTER.CLICK",",oparms:[{av:'divPreciocompraproductofiltercontainer_Class',ctrl:'PRECIOCOMPRAPRODUCTOFILTERCONTAINER',prop:'Class'},{av:'edtavCpreciocompraproducto_Visible',ctrl:'vCPRECIOCOMPRAPRODUCTO',prop:'Visible'}]}");
         setEventMetadata("LBLPRECIOVENTAPRODUCTOFILTER.CLICK","{handler:'E141V1',iparms:[{av:'divPrecioventaproductofiltercontainer_Class',ctrl:'PRECIOVENTAPRODUCTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRECIOVENTAPRODUCTOFILTER.CLICK",",oparms:[{av:'divPrecioventaproductofiltercontainer_Class',ctrl:'PRECIOVENTAPRODUCTOFILTERCONTAINER',prop:'Class'},{av:'edtavCprecioventaproducto_Visible',ctrl:'vCPRECIOVENTAPRODUCTO',prop:'Visible'}]}");
         setEventMetadata("LBLIDESTADOPRODUCTOFILTER.CLICK","{handler:'E151V1',iparms:[{av:'divIdestadoproductofiltercontainer_Class',ctrl:'IDESTADOPRODUCTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDESTADOPRODUCTOFILTER.CLICK",",oparms:[{av:'divIdestadoproductofiltercontainer_Class',ctrl:'IDESTADOPRODUCTOFILTERCONTAINER',prop:'Class'},{av:'edtavCidestadoproducto_Visible',ctrl:'vCIDESTADOPRODUCTO',prop:'Visible'}]}");
         setEventMetadata("LBLIDCATEGORIAPRODUCTOFILTER.CLICK","{handler:'E161V1',iparms:[{av:'divIdcategoriaproductofiltercontainer_Class',ctrl:'IDCATEGORIAPRODUCTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDCATEGORIAPRODUCTOFILTER.CLICK",",oparms:[{av:'divIdcategoriaproductofiltercontainer_Class',ctrl:'IDCATEGORIAPRODUCTOFILTERCONTAINER',prop:'Class'},{av:'edtavCidcategoriaproducto_Visible',ctrl:'vCIDCATEGORIAPRODUCTO',prop:'Visible'}]}");
         setEventMetadata("LBLIDMARCAPRODUCTOFILTER.CLICK","{handler:'E171V1',iparms:[{av:'divIdmarcaproductofiltercontainer_Class',ctrl:'IDMARCAPRODUCTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLIDMARCAPRODUCTOFILTER.CLICK",",oparms:[{av:'divIdmarcaproductofiltercontainer_Class',ctrl:'IDMARCAPRODUCTOFILTERCONTAINER',prop:'Class'},{av:'edtavCidmarcaproducto_Visible',ctrl:'vCIDMARCAPRODUCTO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E211V2',iparms:[{av:'A7IDPRODUCTO',fld:'IDPRODUCTO',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pIDPRODUCTO',fld:'vPIDPRODUCTO',pic:'ZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDPRODUCTO',fld:'vCIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV8cCANTIDADPRODUCTO',fld:'vCCANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV9cPRECIOCOMPRAPRODUCTO',fld:'vCPRECIOCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV10cPRECIOVENTAPRODUCTO',fld:'vCPRECIOVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV11cIDESTADOPRODUCTO',fld:'vCIDESTADOPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12cIDCATEGORIAPRODUCTO',fld:'vCIDCATEGORIAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV15cIDMARCAPRODUCTO',fld:'vCIDMARCAPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDPRODUCTO',fld:'vCIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV8cCANTIDADPRODUCTO',fld:'vCCANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV9cPRECIOCOMPRAPRODUCTO',fld:'vCPRECIOCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV10cPRECIOVENTAPRODUCTO',fld:'vCPRECIOVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV11cIDESTADOPRODUCTO',fld:'vCIDESTADOPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12cIDCATEGORIAPRODUCTO',fld:'vCIDCATEGORIAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV15cIDMARCAPRODUCTO',fld:'vCIDMARCAPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDPRODUCTO',fld:'vCIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV8cCANTIDADPRODUCTO',fld:'vCCANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV9cPRECIOCOMPRAPRODUCTO',fld:'vCPRECIOCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV10cPRECIOVENTAPRODUCTO',fld:'vCPRECIOVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV11cIDESTADOPRODUCTO',fld:'vCIDESTADOPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12cIDCATEGORIAPRODUCTO',fld:'vCIDCATEGORIAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV15cIDMARCAPRODUCTO',fld:'vCIDMARCAPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cIDPRODUCTO',fld:'vCIDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV8cCANTIDADPRODUCTO',fld:'vCCANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV9cPRECIOCOMPRAPRODUCTO',fld:'vCPRECIOCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV10cPRECIOVENTAPRODUCTO',fld:'vCPRECIOVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'AV11cIDESTADOPRODUCTO',fld:'vCIDESTADOPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV12cIDCATEGORIAPRODUCTO',fld:'vCIDCATEGORIAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'AV15cIDMARCAPRODUCTO',fld:'vCIDMARCAPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Idmarcaproducto',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblidproductofilter_Jsonclick = "";
         TempTags = "";
         lblLblcantidadproductofilter_Jsonclick = "";
         lblLblpreciocompraproductofilter_Jsonclick = "";
         lblLblprecioventaproductofilter_Jsonclick = "";
         lblLblidestadoproductofilter_Jsonclick = "";
         lblLblidcategoriaproductofilter_Jsonclick = "";
         lblLblidmarcaproductofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Linkselection_GXI = "";
         scmdbuf = "";
         H001V2_A8IDMARCAPRODUCTO = new long[1] ;
         H001V2_A6IDCATEGORIAPRODUCTO = new long[1] ;
         H001V2_A5IDESTADOPRODUCTO = new long[1] ;
         H001V2_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         H001V2_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         H001V2_A41CANTIDADPRODUCTO = new long[1] ;
         H001V2_A7IDPRODUCTO = new long[1] ;
         H001V3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0090__default(),
            new Object[][] {
                new Object[] {
               H001V2_A8IDMARCAPRODUCTO, H001V2_A6IDCATEGORIAPRODUCTO, H001V2_A5IDESTADOPRODUCTO, H001V2_A43PRECIOVENTAPRODUCTO, H001V2_A42PRECIOCOMPRAPRODUCTO, H001V2_A41CANTIDADPRODUCTO, H001V2_A7IDPRODUCTO
               }
               , new Object[] {
               H001V3_AGRID1_nRecordCount
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
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCidproducto_Enabled ;
      private int edtavCidproducto_Visible ;
      private int edtavCcantidadproducto_Enabled ;
      private int edtavCcantidadproducto_Visible ;
      private int edtavCpreciocompraproducto_Enabled ;
      private int edtavCpreciocompraproducto_Visible ;
      private int edtavCprecioventaproducto_Enabled ;
      private int edtavCprecioventaproducto_Visible ;
      private int edtavCidestadoproducto_Enabled ;
      private int edtavCidestadoproducto_Visible ;
      private int edtavCidcategoriaproducto_Enabled ;
      private int edtavCidcategoriaproducto_Visible ;
      private int edtavCidmarcaproducto_Enabled ;
      private int edtavCidmarcaproducto_Visible ;
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
      private long AV13pIDPRODUCTO ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cIDPRODUCTO ;
      private long AV8cCANTIDADPRODUCTO ;
      private long AV11cIDESTADOPRODUCTO ;
      private long AV12cIDCATEGORIAPRODUCTO ;
      private long AV15cIDMARCAPRODUCTO ;
      private long A7IDPRODUCTO ;
      private long A41CANTIDADPRODUCTO ;
      private long A5IDESTADOPRODUCTO ;
      private long A6IDCATEGORIAPRODUCTO ;
      private long A8IDMARCAPRODUCTO ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV9cPRECIOCOMPRAPRODUCTO ;
      private decimal AV10cPRECIOVENTAPRODUCTO ;
      private decimal A42PRECIOCOMPRAPRODUCTO ;
      private decimal A43PRECIOVENTAPRODUCTO ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divIdproductofiltercontainer_Class ;
      private string divCantidadproductofiltercontainer_Class ;
      private string divPreciocompraproductofiltercontainer_Class ;
      private string divPrecioventaproductofiltercontainer_Class ;
      private string divIdestadoproductofiltercontainer_Class ;
      private string divIdcategoriaproductofiltercontainer_Class ;
      private string divIdmarcaproductofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divIdproductofiltercontainer_Internalname ;
      private string lblLblidproductofilter_Internalname ;
      private string lblLblidproductofilter_Jsonclick ;
      private string edtavCidproducto_Internalname ;
      private string TempTags ;
      private string edtavCidproducto_Jsonclick ;
      private string divCantidadproductofiltercontainer_Internalname ;
      private string lblLblcantidadproductofilter_Internalname ;
      private string lblLblcantidadproductofilter_Jsonclick ;
      private string edtavCcantidadproducto_Internalname ;
      private string edtavCcantidadproducto_Jsonclick ;
      private string divPreciocompraproductofiltercontainer_Internalname ;
      private string lblLblpreciocompraproductofilter_Internalname ;
      private string lblLblpreciocompraproductofilter_Jsonclick ;
      private string edtavCpreciocompraproducto_Internalname ;
      private string edtavCpreciocompraproducto_Jsonclick ;
      private string divPrecioventaproductofiltercontainer_Internalname ;
      private string lblLblprecioventaproductofilter_Internalname ;
      private string lblLblprecioventaproductofilter_Jsonclick ;
      private string edtavCprecioventaproducto_Internalname ;
      private string edtavCprecioventaproducto_Jsonclick ;
      private string divIdestadoproductofiltercontainer_Internalname ;
      private string lblLblidestadoproductofilter_Internalname ;
      private string lblLblidestadoproductofilter_Jsonclick ;
      private string edtavCidestadoproducto_Internalname ;
      private string edtavCidestadoproducto_Jsonclick ;
      private string divIdcategoriaproductofiltercontainer_Internalname ;
      private string lblLblidcategoriaproductofilter_Internalname ;
      private string lblLblidcategoriaproductofilter_Jsonclick ;
      private string edtavCidcategoriaproducto_Internalname ;
      private string edtavCidcategoriaproducto_Jsonclick ;
      private string divIdmarcaproductofiltercontainer_Internalname ;
      private string lblLblidmarcaproductofilter_Internalname ;
      private string lblLblidmarcaproductofilter_Jsonclick ;
      private string edtavCidmarcaproducto_Internalname ;
      private string edtavCidmarcaproducto_Jsonclick ;
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
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtIDPRODUCTO_Internalname ;
      private string edtCANTIDADPRODUCTO_Internalname ;
      private string edtPRECIOCOMPRAPRODUCTO_Internalname ;
      private string edtPRECIOVENTAPRODUCTO_Internalname ;
      private string edtIDESTADOPRODUCTO_Internalname ;
      private string edtIDCATEGORIAPRODUCTO_Internalname ;
      private string edtIDMARCAPRODUCTO_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtIDPRODUCTO_Jsonclick ;
      private string edtCANTIDADPRODUCTO_Jsonclick ;
      private string edtPRECIOCOMPRAPRODUCTO_Jsonclick ;
      private string edtPRECIOVENTAPRODUCTO_Jsonclick ;
      private string edtIDESTADOPRODUCTO_Jsonclick ;
      private string edtIDCATEGORIAPRODUCTO_Jsonclick ;
      private string edtIDMARCAPRODUCTO_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV18Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H001V2_A8IDMARCAPRODUCTO ;
      private long[] H001V2_A6IDCATEGORIAPRODUCTO ;
      private long[] H001V2_A5IDESTADOPRODUCTO ;
      private decimal[] H001V2_A43PRECIOVENTAPRODUCTO ;
      private decimal[] H001V2_A42PRECIOCOMPRAPRODUCTO ;
      private long[] H001V2_A41CANTIDADPRODUCTO ;
      private long[] H001V2_A7IDPRODUCTO ;
      private long[] H001V3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pIDPRODUCTO ;
      private GXWebForm Form ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001V2( IGxContext context ,
                                             long AV8cCANTIDADPRODUCTO ,
                                             decimal AV9cPRECIOCOMPRAPRODUCTO ,
                                             decimal AV10cPRECIOVENTAPRODUCTO ,
                                             long AV11cIDESTADOPRODUCTO ,
                                             long AV12cIDCATEGORIAPRODUCTO ,
                                             long AV15cIDMARCAPRODUCTO ,
                                             long A41CANTIDADPRODUCTO ,
                                             decimal A42PRECIOCOMPRAPRODUCTO ,
                                             decimal A43PRECIOVENTAPRODUCTO ,
                                             long A5IDESTADOPRODUCTO ,
                                             long A6IDCATEGORIAPRODUCTO ,
                                             long A8IDMARCAPRODUCTO ,
                                             long AV6cIDPRODUCTO )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [IDMARCAPRODUCTO], [IDCATEGORIAPRODUCTO], [IDESTADOPRODUCTO], [PRECIOVENTAPRODUCTO], [PRECIOCOMPRAPRODUCTO], [CANTIDADPRODUCTO], [IDPRODUCTO]";
         sFromString = " FROM [Inventario]";
         sOrderString = "";
         AddWhere(sWhereString, "([IDPRODUCTO] >= @AV6cIDPRODUCTO)");
         if ( ! (0==AV8cCANTIDADPRODUCTO) )
         {
            AddWhere(sWhereString, "([CANTIDADPRODUCTO] >= @AV8cCANTIDADPRODUCTO)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cPRECIOCOMPRAPRODUCTO) )
         {
            AddWhere(sWhereString, "([PRECIOCOMPRAPRODUCTO] >= @AV9cPRECIOCOMPRAPRODUCTO)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cPRECIOVENTAPRODUCTO) )
         {
            AddWhere(sWhereString, "([PRECIOVENTAPRODUCTO] >= @AV10cPRECIOVENTAPRODUCTO)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV11cIDESTADOPRODUCTO) )
         {
            AddWhere(sWhereString, "([IDESTADOPRODUCTO] >= @AV11cIDESTADOPRODUCTO)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV12cIDCATEGORIAPRODUCTO) )
         {
            AddWhere(sWhereString, "([IDCATEGORIAPRODUCTO] >= @AV12cIDCATEGORIAPRODUCTO)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV15cIDMARCAPRODUCTO) )
         {
            AddWhere(sWhereString, "([IDMARCAPRODUCTO] >= @AV15cIDMARCAPRODUCTO)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [IDPRODUCTO]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001V3( IGxContext context ,
                                             long AV8cCANTIDADPRODUCTO ,
                                             decimal AV9cPRECIOCOMPRAPRODUCTO ,
                                             decimal AV10cPRECIOVENTAPRODUCTO ,
                                             long AV11cIDESTADOPRODUCTO ,
                                             long AV12cIDCATEGORIAPRODUCTO ,
                                             long AV15cIDMARCAPRODUCTO ,
                                             long A41CANTIDADPRODUCTO ,
                                             decimal A42PRECIOCOMPRAPRODUCTO ,
                                             decimal A43PRECIOVENTAPRODUCTO ,
                                             long A5IDESTADOPRODUCTO ,
                                             long A6IDCATEGORIAPRODUCTO ,
                                             long A8IDMARCAPRODUCTO ,
                                             long AV6cIDPRODUCTO )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Inventario]";
         AddWhere(sWhereString, "([IDPRODUCTO] >= @AV6cIDPRODUCTO)");
         if ( ! (0==AV8cCANTIDADPRODUCTO) )
         {
            AddWhere(sWhereString, "([CANTIDADPRODUCTO] >= @AV8cCANTIDADPRODUCTO)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cPRECIOCOMPRAPRODUCTO) )
         {
            AddWhere(sWhereString, "([PRECIOCOMPRAPRODUCTO] >= @AV9cPRECIOCOMPRAPRODUCTO)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cPRECIOVENTAPRODUCTO) )
         {
            AddWhere(sWhereString, "([PRECIOVENTAPRODUCTO] >= @AV10cPRECIOVENTAPRODUCTO)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV11cIDESTADOPRODUCTO) )
         {
            AddWhere(sWhereString, "([IDESTADOPRODUCTO] >= @AV11cIDESTADOPRODUCTO)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV12cIDCATEGORIAPRODUCTO) )
         {
            AddWhere(sWhereString, "([IDCATEGORIAPRODUCTO] >= @AV12cIDCATEGORIAPRODUCTO)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV15cIDMARCAPRODUCTO) )
         {
            AddWhere(sWhereString, "([IDMARCAPRODUCTO] >= @AV15cIDMARCAPRODUCTO)");
         }
         else
         {
            GXv_int3[6] = 1;
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
                     return conditional_H001V2(context, (long)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H001V3(context, (long)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH001V2;
          prmH001V2 = new Object[] {
          new ParDef("@AV6cIDPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV8cCANTIDADPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV9cPRECIOCOMPRAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@AV10cPRECIOVENTAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@AV11cIDESTADOPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV12cIDCATEGORIAPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV15cIDMARCAPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001V3;
          prmH001V3 = new Object[] {
          new ParDef("@AV6cIDPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV8cCANTIDADPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV9cPRECIOCOMPRAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@AV10cPRECIOVENTAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@AV11cIDESTADOPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV12cIDCATEGORIAPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@AV15cIDMARCAPRODUCTO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001V2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001V3,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
