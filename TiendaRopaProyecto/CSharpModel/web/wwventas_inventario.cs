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
   public class wwventas_inventario : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwventas_inventario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wwventas_inventario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
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
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_25 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_25"), "."));
               nGXsfl_25_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_25_idx"), "."));
               sGXsfl_25_idx = GetPar( "sGXsfl_25_idx");
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
               AV11FECHAVENTA = context.localUtil.ParseDateParm( GetPar( "FECHAVENTA"));
               AV12Update = GetPar( "Update");
               AV13Delete = GetPar( "Delete");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV11FECHAVENTA, AV12Update, AV13Delete) ;
               GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
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
         PA2W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2W2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021113013582823", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwventas_inventario.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         GxWebStd.gx_hidden_field( context, "GXH_vFECHAVENTA", context.localUtil.Format(AV11FECHAVENTA, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_25", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_25), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2W2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwventas_inventario.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWVentas_inventario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ventas_inventarios" ;
      }

      protected void WB2W0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-7 col-sm-2 col-sm-offset-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Ventas_inventarios", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, 0, "HLP_WWVentas_inventario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-5 col-sm-3 col-sm-push-6 WWActionsCell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            ClassString = "BtnAdd";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWVentas_inventario.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-sm-pull-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFechaventa_Internalname, "FECHAVENTA", "col-sm-3 DateFilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_25_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFechaventa_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFechaventa_Internalname, context.localUtil.Format(AV11FECHAVENTA, "99/99/99"), context.localUtil.Format( AV11FECHAVENTA, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechaventa_Jsonclick, 0, "DateFilterSearchAttribute", "", "", "", "", 1, edtavFechaventa_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWVentas_inventario.htm");
            GxWebStd.gx_bitmap( context, edtavFechaventa_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechaventa_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWVentas_inventario.htm");
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
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ViewGridCellAdvanced", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "ContainerFluid WWAdvancedContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"25\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               GridContainer.AddObjectProperty("Class", "WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
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
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            nRC_GXsfl_25 = (int)(nGXsfl_25_idx-1);
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 25 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2W2( )
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
            Form.Meta.addItem("description", "Ventas_inventarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2W0( ) ;
      }

      protected void WS2W2( )
      {
         START2W2( ) ;
         EVT2W2( ) ;
      }

      protected void EVT2W2( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E112W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_25_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
                              SubsflControlProps_252( ) ;
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
                              AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E132W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E142W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Fechaventa Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFECHAVENTA"), 0) != AV11FECHAVENTA )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void WE2W2( )
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

      protected void PA2W2( )
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFechaventa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_252( ) ;
         while ( nGXsfl_25_idx <= nRC_GXsfl_25 )
         {
            sendrow_252( ) ;
            nGXsfl_25_idx = ((subGrid_Islastpage==1)&&(nGXsfl_25_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       DateTime AV11FECHAVENTA ,
                                       string AV12Update ,
                                       string AV13Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E132W2 ();
         GRID_nCurrentRecord = 0;
         RF2W2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDVENTA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "IDVENTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")));
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
         RF2W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "WWVentas_inventario";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
      }

      protected void RF2W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 25;
         /* Execute user event: Refresh */
         E132W2 ();
         nGXsfl_25_idx = 1;
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_252( ) ;
         bGXsfl_25_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_252( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11FECHAVENTA ,
                                                 A54FECHAVENTA } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor H002W14 */
            pr_default.execute(0, new Object[] {AV11FECHAVENTA, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_25_idx = 1;
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A58DESCUENTOVENTA = H002W14_A58DESCUENTOVENTA[0];
               A30NOMBRECOMPLETOCLIENTE = H002W14_A30NOMBRECOMPLETOCLIENTE[0];
               A4IDCLIENTE = H002W14_A4IDCLIENTE[0];
               A23NOMBRECOMPLETOEMPLEADO = H002W14_A23NOMBRECOMPLETOEMPLEADO[0];
               A1IDEMPLEADO = H002W14_A1IDEMPLEADO[0];
               A55DESCRIPCIONVENTA = H002W14_A55DESCRIPCIONVENTA[0];
               A54FECHAVENTA = H002W14_A54FECHAVENTA[0];
               A12IDVENTA = H002W14_A12IDVENTA[0];
               A59TOTALVENTA = H002W14_A59TOTALVENTA[0];
               n59TOTALVENTA = H002W14_n59TOTALVENTA[0];
               A57IMPUESTOVENTA = H002W14_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = H002W14_n57IMPUESTOVENTA[0];
               A30NOMBRECOMPLETOCLIENTE = H002W14_A30NOMBRECOMPLETOCLIENTE[0];
               A23NOMBRECOMPLETOEMPLEADO = H002W14_A23NOMBRECOMPLETOEMPLEADO[0];
               A59TOTALVENTA = H002W14_A59TOTALVENTA[0];
               n59TOTALVENTA = H002W14_n59TOTALVENTA[0];
               A57IMPUESTOVENTA = H002W14_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = H002W14_n57IMPUESTOVENTA[0];
               E142W2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 25;
            WB2W0( ) ;
         }
         bGXsfl_25_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2W2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_IDVENTA"+"_"+sGXsfl_25_idx, GetSecureSignedToken( sGXsfl_25_idx, context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11FECHAVENTA ,
                                              A54FECHAVENTA } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor H002W27 */
         pr_default.execute(1, new Object[] {AV11FECHAVENTA});
         GRID_nRecordCount = H002W27_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11FECHAVENTA, AV12Update, AV13Delete) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11FECHAVENTA, AV12Update, AV13Delete) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11FECHAVENTA, AV12Update, AV13Delete) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11FECHAVENTA, AV12Update, AV13Delete) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11FECHAVENTA, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11FECHAVENTA = context.localUtil.CToD( GridState.FilterValues("Fechaventa"), 1);
            AssignAttri("", false, "AV11FECHAVENTA", context.localUtil.Format(AV11FECHAVENTA, "99/99/99"));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.ClearFilterValues();
         GridState.AddFilterValue("FECHAVENTA", context.localUtil.Format(AV11FECHAVENTA, "99/99/99"));
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "WWVentas_inventario";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_25 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_25"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavFechaventa_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FECHAVENTA"}), 1, "vFECHAVENTA");
               GX_FocusControl = edtavFechaventa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11FECHAVENTA = DateTime.MinValue;
               AssignAttri("", false, "AV11FECHAVENTA", context.localUtil.Format(AV11FECHAVENTA, "99/99/99"));
            }
            else
            {
               AV11FECHAVENTA = context.localUtil.CToD( cgiGet( edtavFechaventa_Internalname), 1);
               AssignAttri("", false, "AV11FECHAVENTA", context.localUtil.Format(AV11FECHAVENTA, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( context.localUtil.CToD( cgiGet( "GXH_vFECHAVENTA"), 1) != AV11FECHAVENTA )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E122W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E122W2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = "Update";
         AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
         AV13Delete = "Delete";
         AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
         Form.Caption = "Ventas_inventarios";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E132W2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
      }

      private void E142W2( )
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
            wbStart = 25;
         }
         sendrow_252( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_25_Refreshing )
         {
            context.DoAjaxLoad(25, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E112W2( )
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
         AV9TrnContext = new SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Ventas_inventario";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "TransactionContext", "TiendaRopaProyecto"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA2W2( ) ;
         WS2W2( ) ;
         WE2W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113013582863", true, true);
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
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1152180), false, true);
            context.AddJavascriptSource("wwventas_inventario.js", "?2021113013582864", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_252( )
      {
         edtIDVENTA_Internalname = "IDVENTA_"+sGXsfl_25_idx;
         edtFECHAVENTA_Internalname = "FECHAVENTA_"+sGXsfl_25_idx;
         edtDESCRIPCIONVENTA_Internalname = "DESCRIPCIONVENTA_"+sGXsfl_25_idx;
         edtIDEMPLEADO_Internalname = "IDEMPLEADO_"+sGXsfl_25_idx;
         edtNOMBRECOMPLETOEMPLEADO_Internalname = "NOMBRECOMPLETOEMPLEADO_"+sGXsfl_25_idx;
         edtIDCLIENTE_Internalname = "IDCLIENTE_"+sGXsfl_25_idx;
         edtNOMBRECOMPLETOCLIENTE_Internalname = "NOMBRECOMPLETOCLIENTE_"+sGXsfl_25_idx;
         edtIMPUESTOVENTA_Internalname = "IMPUESTOVENTA_"+sGXsfl_25_idx;
         edtDESCUENTOVENTA_Internalname = "DESCUENTOVENTA_"+sGXsfl_25_idx;
         edtTOTALVENTA_Internalname = "TOTALVENTA_"+sGXsfl_25_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_25_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_25_idx;
      }

      protected void SubsflControlProps_fel_252( )
      {
         edtIDVENTA_Internalname = "IDVENTA_"+sGXsfl_25_fel_idx;
         edtFECHAVENTA_Internalname = "FECHAVENTA_"+sGXsfl_25_fel_idx;
         edtDESCRIPCIONVENTA_Internalname = "DESCRIPCIONVENTA_"+sGXsfl_25_fel_idx;
         edtIDEMPLEADO_Internalname = "IDEMPLEADO_"+sGXsfl_25_fel_idx;
         edtNOMBRECOMPLETOEMPLEADO_Internalname = "NOMBRECOMPLETOEMPLEADO_"+sGXsfl_25_fel_idx;
         edtIDCLIENTE_Internalname = "IDCLIENTE_"+sGXsfl_25_fel_idx;
         edtNOMBRECOMPLETOCLIENTE_Internalname = "NOMBRECOMPLETOCLIENTE_"+sGXsfl_25_fel_idx;
         edtIMPUESTOVENTA_Internalname = "IMPUESTOVENTA_"+sGXsfl_25_fel_idx;
         edtDESCUENTOVENTA_Internalname = "DESCUENTOVENTA_"+sGXsfl_25_fel_idx;
         edtTOTALVENTA_Internalname = "TOTALVENTA_"+sGXsfl_25_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_25_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_25_fel_idx;
      }

      protected void sendrow_252( )
      {
         SubsflControlProps_252( ) ;
         WB2W0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_25_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_25_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_25_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFECHAVENTA_Internalname,context.localUtil.Format(A54FECHAVENTA, "99/99/99"),context.localUtil.Format( A54FECHAVENTA, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtFECHAVENTA_Link,(string)"",(string)"",(string)"",(string)edtFECHAVENTA_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDESCRIPCIONVENTA_Internalname,(string)A55DESCRIPCIONVENTA,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDESCRIPCIONVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDEMPLEADO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNOMBRECOMPLETOEMPLEADO_Internalname,(string)A23NOMBRECOMPLETOEMPLEADO,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtNOMBRECOMPLETOEMPLEADO_Link,(string)"",(string)"",(string)"",(string)edtNOMBRECOMPLETOEMPLEADO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDCLIENTE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNOMBRECOMPLETOCLIENTE_Internalname,(string)A30NOMBRECOMPLETOCLIENTE,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtNOMBRECOMPLETOCLIENTE_Link,(string)"",(string)"",(string)"",(string)edtNOMBRECOMPLETOCLIENTE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIMPUESTOVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( A57IMPUESTOVENTA, 12, 2, ".", "")),context.localUtil.Format( A57IMPUESTOVENTA, "ZZZZZZZZ9.99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIMPUESTOVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDESCUENTOVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( A58DESCUENTOVENTA, 12, 2, ".", "")),context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDESCUENTOVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTOTALVENTA_Internalname,StringUtil.LTrim( StringUtil.NToC( A59TOTALVENTA, 12, 2, ".", "")),context.localUtil.Format( A59TOTALVENTA, "ZZZZZZZZ9.99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTOTALVENTA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes2W2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_25_idx = ((subGrid_Islastpage==1)&&(nGXsfl_25_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         /* End function sendrow_252 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         bttBtninsert_Internalname = "BTNINSERT";
         edtavFechaventa_Internalname = "vFECHAVENTA";
         divTabletop_Internalname = "TABLETOP";
         edtIDVENTA_Internalname = "IDVENTA";
         edtFECHAVENTA_Internalname = "FECHAVENTA";
         edtDESCRIPCIONVENTA_Internalname = "DESCRIPCIONVENTA";
         edtIDEMPLEADO_Internalname = "IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = "NOMBRECOMPLETOEMPLEADO";
         edtIDCLIENTE_Internalname = "IDCLIENTE";
         edtNOMBRECOMPLETOCLIENTE_Internalname = "NOMBRECOMPLETOCLIENTE";
         edtIMPUESTOVENTA_Internalname = "IMPUESTOVENTA";
         edtDESCUENTOVENTA_Internalname = "DESCUENTOVENTA";
         edtTOTALVENTA_Internalname = "TOTALVENTA";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
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
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFechaventa_Jsonclick = "";
         edtavFechaventa_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Ventas_inventarios";
         subGrid_Rows = 10;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11FECHAVENTA',fld:'vFECHAVENTA',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E142W2',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtFECHAVENTA_Link',ctrl:'FECHAVENTA',prop:'Link'},{av:'edtNOMBRECOMPLETOEMPLEADO_Link',ctrl:'NOMBRECOMPLETOEMPLEADO',prop:'Link'},{av:'edtNOMBRECOMPLETOCLIENTE_Link',ctrl:'NOMBRECOMPLETOCLIENTE',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E112W2',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11FECHAVENTA',fld:'vFECHAVENTA',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11FECHAVENTA',fld:'vFECHAVENTA',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11FECHAVENTA',fld:'vFECHAVENTA',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11FECHAVENTA',fld:'vFECHAVENTA',pic:''},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_FECHAVENTA","{handler:'Validv_Fechaventa',iparms:[]");
         setEventMetadata("VALIDV_FECHAVENTA",",oparms:[]}");
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
         AV12Update = "";
         AV13Delete = "";
         AV11FECHAVENTA = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         AV17Pgmname = "";
         scmdbuf = "";
         H002W14_A58DESCUENTOVENTA = new decimal[1] ;
         H002W14_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         H002W14_A4IDCLIENTE = new long[1] ;
         H002W14_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         H002W14_A1IDEMPLEADO = new long[1] ;
         H002W14_A55DESCRIPCIONVENTA = new string[] {""} ;
         H002W14_A54FECHAVENTA = new DateTime[] {DateTime.MinValue} ;
         H002W14_A12IDVENTA = new long[1] ;
         H002W14_A59TOTALVENTA = new decimal[1] ;
         H002W14_n59TOTALVENTA = new bool[] {false} ;
         H002W14_A57IMPUESTOVENTA = new decimal[1] ;
         H002W14_n57IMPUESTOVENTA = new bool[] {false} ;
         H002W27_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV9TrnContext = new SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwventas_inventario__default(),
            new Object[][] {
                new Object[] {
               H002W14_A58DESCUENTOVENTA, H002W14_A30NOMBRECOMPLETOCLIENTE, H002W14_A4IDCLIENTE, H002W14_A23NOMBRECOMPLETOEMPLEADO, H002W14_A1IDEMPLEADO, H002W14_A55DESCRIPCIONVENTA, H002W14_A54FECHAVENTA, H002W14_A12IDVENTA, H002W14_A59TOTALVENTA, H002W14_n59TOTALVENTA,
               H002W14_A57IMPUESTOVENTA, H002W14_n57IMPUESTOVENTA
               }
               , new Object[] {
               H002W27_AGRID_nRecordCount
               }
            }
         );
         AV17Pgmname = "WWVentas_inventario";
         /* GeneXus formulas. */
         AV17Pgmname = "WWVentas_inventario";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_25 ;
      private int nGXsfl_25_idx=1 ;
      private int subGrid_Rows ;
      private int edtavFechaventa_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long A12IDVENTA ;
      private long A1IDEMPLEADO ;
      private long A4IDCLIENTE ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A57IMPUESTOVENTA ;
      private decimal A58DESCUENTOVENTA ;
      private decimal A59TOTALVENTA ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_25_idx="0001" ;
      private string AV12Update ;
      private string AV13Delete ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavFechaventa_Internalname ;
      private string edtavFechaventa_Jsonclick ;
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
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string AV17Pgmname ;
      private string scmdbuf ;
      private string sGXsfl_25_fel_idx="0001" ;
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
      private DateTime AV11FECHAVENTA ;
      private DateTime A54FECHAVENTA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n57IMPUESTOVENTA ;
      private bool n59TOTALVENTA ;
      private bool bGXsfl_25_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A55DESCRIPCIONVENTA ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private string A30NOMBRECOMPLETOCLIENTE ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H002W14_A58DESCUENTOVENTA ;
      private string[] H002W14_A30NOMBRECOMPLETOCLIENTE ;
      private long[] H002W14_A4IDCLIENTE ;
      private string[] H002W14_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] H002W14_A1IDEMPLEADO ;
      private string[] H002W14_A55DESCRIPCIONVENTA ;
      private DateTime[] H002W14_A54FECHAVENTA ;
      private long[] H002W14_A12IDVENTA ;
      private decimal[] H002W14_A59TOTALVENTA ;
      private bool[] H002W14_n59TOTALVENTA ;
      private decimal[] H002W14_A57IMPUESTOVENTA ;
      private bool[] H002W14_n57IMPUESTOVENTA ;
      private long[] H002W27_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class wwventas_inventario__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002W14( IGxContext context ,
                                              DateTime AV11FECHAVENTA ,
                                              DateTime A54FECHAVENTA )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[DESCUENTOVENTA], T2.[NOMBRECOMPLETOCLIENTE], T1.[IDCLIENTE], T3.[NOMBRECOMPLETOEMPLEADO], T1.[IDEMPLEADO], T1.[DESCRIPCIONVENTA], T1.[FECHAVENTA], T1.[IDVENTA], COALESCE( T4.[TOTALVENTA], 0) AS TOTALVENTA, COALESCE( T5.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA";
         sFromString = " FROM (((([Ventas_inventario] T1 INNER JOIN [Clientes] T2 ON T2.[IDCLIENTE] = T1.[IDCLIENTE]) INNER JOIN [Empleados] T3 ON T3.[IDEMPLEADO] = T1.[IDEMPLEADO]) INNER JOIN (SELECT COALESCE( T8.[GXC3], 0) + COALESCE( T7.[IMPUESTOVENTA], 0) - T6.[DESCUENTOVENTA] AS TOTALVENTA, T6.[IDVENTA] FROM (([Ventas_inventario] T6 LEFT JOIN (SELECT COALESCE( T10.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T9.[IDVENTA] FROM ([Ventas_inventario] T9 LEFT JOIN (SELECT SUM(COALESCE( T12.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T11.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T11 LEFT JOIN (SELECT COALESCE( T14.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T13 LEFT JOIN (SELECT SUM(T16.[CANTIDADPRODUCTO] * CAST(T16.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T15.[IDVENTA], T15.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T15 INNER JOIN [Inventario] T16 ON T16.[IDPRODUCTO] = T15.[IDPRODUCTO]) GROUP BY T15.[IDVENTA], T15.[IDDETALLEVENTAPRODUCTO] ) T14 ON T14.[IDVENTA] = T13.[IDVENTA] AND T14.[IDDETALLEVENTAPRODUCTO] = T13.[IDDETALLEVENTAPRODUCTO]) ) T12 ON T12.[IDVENTA] = T11.[IDVENTA] AND T12.[IDDETALLEVENTAPRODUCTO] = T11.[IDDETALLEVENTAPRODUCTO]) GROUP BY T11.[IDVENTA] ) T10 ON T10.[IDVENTA] = T9.[IDVENTA]) ) T7 ON T7.[IDVENTA] = T6.[IDVENTA]) LEFT JOIN (SELECT SUM(COALESCE( T10.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T9.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T9 LEFT JOIN (SELECT COALESCE( T12.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T11.[IDVENTA], T11.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T11 LEFT JOIN (SELECT SUM(T14.[CANTIDADPRODUCTO] * CAST(T14.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO]";
         sFromString += " FROM ([Ventas_inventarioDetalle_venta] T13 INNER JOIN [Inventario] T14 ON T14.[IDPRODUCTO] = T13.[IDPRODUCTO]) GROUP BY T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] ) T12 ON T12.[IDVENTA] = T11.[IDVENTA] AND T12.[IDDETALLEVENTAPRODUCTO] = T11.[IDDETALLEVENTAPRODUCTO]) ) T10 ON T10.[IDVENTA] = T9.[IDVENTA] AND T10.[IDDETALLEVENTAPRODUCTO] = T9.[IDDETALLEVENTAPRODUCTO]) GROUP BY T9.[IDVENTA] ) T8 ON T8.[IDVENTA] = T6.[IDVENTA]) ) T4 ON T4.[IDVENTA] = T1.[IDVENTA]) LEFT JOIN (SELECT COALESCE( T7.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T6.[IDVENTA] FROM ([Ventas_inventario] T6 LEFT JOIN (SELECT SUM(COALESCE( T9.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T8.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T8 LEFT JOIN (SELECT COALESCE( T11.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T10.[IDVENTA], T10.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T10 LEFT JOIN (SELECT SUM(T13.[CANTIDADPRODUCTO] * CAST(T13.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T12.[IDVENTA], T12.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T12 INNER JOIN [Inventario] T13 ON T13.[IDPRODUCTO] = T12.[IDPRODUCTO]) GROUP BY T12.[IDVENTA], T12.[IDDETALLEVENTAPRODUCTO] ) T11 ON T11.[IDVENTA] = T10.[IDVENTA] AND T11.[IDDETALLEVENTAPRODUCTO] = T10.[IDDETALLEVENTAPRODUCTO]) ) T9 ON T9.[IDVENTA] = T8.[IDVENTA] AND T9.[IDDETALLEVENTAPRODUCTO] = T8.[IDDETALLEVENTAPRODUCTO]) GROUP BY T8.[IDVENTA] ) T7 ON T7.[IDVENTA] = T6.[IDVENTA]) ) T5 ON T5.[IDVENTA] = T1.[IDVENTA])";
         sOrderString = "";
         if ( ! (DateTime.MinValue==AV11FECHAVENTA) )
         {
            AddWhere(sWhereString, "(T1.[FECHAVENTA] >= @AV11FECHAVENTA)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY T1.[FECHAVENTA]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002W27( IGxContext context ,
                                              DateTime AV11FECHAVENTA ,
                                              DateTime A54FECHAVENTA )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((([Ventas_inventario] T1 INNER JOIN [Clientes] T3 ON T3.[IDCLIENTE] = T1.[IDCLIENTE]) INNER JOIN [Empleados] T2 ON T2.[IDEMPLEADO] = T1.[IDEMPLEADO]) INNER JOIN (SELECT COALESCE( T8.[GXC3], 0) + COALESCE( T7.[IMPUESTOVENTA], 0) - T6.[DESCUENTOVENTA] AS TOTALVENTA, T6.[IDVENTA] FROM (([Ventas_inventario] T6 LEFT JOIN (SELECT COALESCE( T10.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T9.[IDVENTA] FROM ([Ventas_inventario] T9 LEFT JOIN (SELECT SUM(COALESCE( T12.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T11.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T11 LEFT JOIN (SELECT COALESCE( T14.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T13 LEFT JOIN (SELECT SUM(T16.[CANTIDADPRODUCTO] * CAST(T16.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T15.[IDVENTA], T15.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T15 INNER JOIN [Inventario] T16 ON T16.[IDPRODUCTO] = T15.[IDPRODUCTO]) GROUP BY T15.[IDVENTA], T15.[IDDETALLEVENTAPRODUCTO] ) T14 ON T14.[IDVENTA] = T13.[IDVENTA] AND T14.[IDDETALLEVENTAPRODUCTO] = T13.[IDDETALLEVENTAPRODUCTO]) ) T12 ON T12.[IDVENTA] = T11.[IDVENTA] AND T12.[IDDETALLEVENTAPRODUCTO] = T11.[IDDETALLEVENTAPRODUCTO]) GROUP BY T11.[IDVENTA] ) T10 ON T10.[IDVENTA] = T9.[IDVENTA]) ) T7 ON T7.[IDVENTA] = T6.[IDVENTA]) LEFT JOIN (SELECT SUM(COALESCE( T10.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T9.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T9 LEFT JOIN (SELECT COALESCE( T12.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T11.[IDVENTA], T11.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T11 LEFT JOIN (SELECT SUM(T14.[CANTIDADPRODUCTO] * CAST(T14.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO]";
         scmdbuf += " FROM ([Ventas_inventarioDetalle_venta] T13 INNER JOIN [Inventario] T14 ON T14.[IDPRODUCTO] = T13.[IDPRODUCTO]) GROUP BY T13.[IDVENTA], T13.[IDDETALLEVENTAPRODUCTO] ) T12 ON T12.[IDVENTA] = T11.[IDVENTA] AND T12.[IDDETALLEVENTAPRODUCTO] = T11.[IDDETALLEVENTAPRODUCTO]) ) T10 ON T10.[IDVENTA] = T9.[IDVENTA] AND T10.[IDDETALLEVENTAPRODUCTO] = T9.[IDDETALLEVENTAPRODUCTO]) GROUP BY T9.[IDVENTA] ) T8 ON T8.[IDVENTA] = T6.[IDVENTA]) ) T4 ON T4.[IDVENTA] = T1.[IDVENTA]) LEFT JOIN (SELECT COALESCE( T7.[GXC3], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA, T6.[IDVENTA] FROM ([Ventas_inventario] T6 LEFT JOIN (SELECT SUM(COALESCE( T9.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC3, T8.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T8 LEFT JOIN (SELECT COALESCE( T11.[GXC5], 0) AS SUBTOTALVENTAPRODUCTO, T10.[IDVENTA], T10.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T10 LEFT JOIN (SELECT SUM(T13.[CANTIDADPRODUCTO] * CAST(T13.[PRECIOVENTAPRODUCTO] AS decimal( 22, 10))) AS GXC5, T12.[IDVENTA], T12.[IDDETALLEVENTAPRODUCTO] FROM ([Ventas_inventarioDetalle_venta] T12 INNER JOIN [Inventario] T13 ON T13.[IDPRODUCTO] = T12.[IDPRODUCTO]) GROUP BY T12.[IDVENTA], T12.[IDDETALLEVENTAPRODUCTO] ) T11 ON T11.[IDVENTA] = T10.[IDVENTA] AND T11.[IDDETALLEVENTAPRODUCTO] = T10.[IDDETALLEVENTAPRODUCTO]) ) T9 ON T9.[IDVENTA] = T8.[IDVENTA] AND T9.[IDDETALLEVENTAPRODUCTO] = T8.[IDDETALLEVENTAPRODUCTO]) GROUP BY T8.[IDVENTA] ) T7 ON T7.[IDVENTA] = T6.[IDVENTA]) ) T5 ON T5.[IDVENTA] = T1.[IDVENTA])";
         if ( ! (DateTime.MinValue==AV11FECHAVENTA) )
         {
            AddWhere(sWhereString, "(T1.[FECHAVENTA] >= @AV11FECHAVENTA)");
         }
         else
         {
            GXv_int3[0] = 1;
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
                     return conditional_H002W14(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] );
               case 1 :
                     return conditional_H002W27(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] );
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
          Object[] prmH002W14;
          prmH002W14 = new Object[] {
          new ParDef("@AV11FECHAVENTA",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002W27;
          prmH002W27 = new Object[] {
          new ParDef("@AV11FECHAVENTA",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002W14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W14,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002W27", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002W27,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
