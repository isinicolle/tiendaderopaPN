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
   public class proveedores : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A9IDTIPOPROVEEDOR = (long)(NumberUtil.Val( GetPar( "IDTIPOPROVEEDOR"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A9IDTIPOPROVEEDOR) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridproveedores_tipo_proveedor") == 0 )
         {
            nRC_GXsfl_63 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."));
            nGXsfl_63_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."));
            sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridproveedores_tipo_proveedor_newrow( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7IDPROVEEDOR = (long)(NumberUtil.Val( GetPar( "IDPROVEEDOR"), "."));
               AssignAttri("", false, "AV7IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(AV7IDPROVEEDOR), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDPROVEEDOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDPROVEEDOR), "ZZZZZZZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_5-152925", 0) ;
            }
            Form.Meta.addItem("description", "Proveedores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public proveedores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public proveedores( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IDPROVEEDOR )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IDPROVEEDOR = aP1_IDPROVEEDOR;
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

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Proveedores", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDPROVEEDOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDPROVEEDOR_Internalname, "IDPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIDPROVEEDOR_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10IDPROVEEDOR), 12, 0, ".", "")), ((edtIDPROVEEDOR_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDPROVEEDOR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDPROVEEDOR_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Proveedores.htm");
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
         GxWebStd.gx_label_element( context, edtNOMBREPROVEEDOR_Internalname, "NOMBREPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOMBREPROVEEDOR_Internalname, A46NOMBREPROVEEDOR, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtNOMBREPROVEEDOR_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTELEFONOPROVEEDOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTELEFONOPROVEEDOR_Internalname, "TELEFONOPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A47TELEFONOPROVEEDOR);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTELEFONOPROVEEDOR_Internalname, StringUtil.RTrim( A47TELEFONOPROVEEDOR), StringUtil.RTrim( context.localUtil.Format( A47TELEFONOPROVEEDOR, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtTELEFONOPROVEEDOR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTELEFONOPROVEEDOR_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCORREOPROVEEDOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCORREOPROVEEDOR_Internalname, "CORREOPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCORREOPROVEEDOR_Internalname, A48CORREOPROVEEDOR, StringUtil.RTrim( context.localUtil.Format( A48CORREOPROVEEDOR, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A48CORREOPROVEEDOR, "", "", "", edtCORREOPROVEEDOR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCORREOPROVEEDOR_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDIRECCIONPROVEEDOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDIRECCIONPROVEEDOR_Internalname, "DIRECCIONPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDIRECCIONPROVEEDOR_Internalname, A49DIRECCIONPROVEEDOR, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtDIRECCIONPROVEEDOR_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Direccion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTipo_proveedortable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitletipo_proveedor_Internalname, "Tipo_proveedor", "", "", lblTitletipo_proveedor_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridproveedores_tipo_proveedor( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridproveedores_tipo_proveedor( )
      {
         /*  Grid Control  */
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("GridName", "Gridproveedores_tipo_proveedor");
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Header", subGridproveedores_tipo_proveedor_Header);
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Class", "Grid");
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Backcolorstyle), 1, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("CmpContext", "");
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("InMasterPage", "false");
         Gridproveedores_tipo_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridproveedores_tipo_proveedorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9IDTIPOPROVEEDOR), 12, 0, ".", "")));
         Gridproveedores_tipo_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddColumnProperties(Gridproveedores_tipo_proveedorColumn);
         Gridproveedores_tipo_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridproveedores_tipo_proveedorContainer.AddColumnProperties(Gridproveedores_tipo_proveedorColumn);
         Gridproveedores_tipo_proveedorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridproveedores_tipo_proveedorColumn.AddObjectProperty("Value", A45DESCRIPCIONTIPOPROVEEDOR);
         Gridproveedores_tipo_proveedorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONTIPOPROVEEDOR_Enabled), 5, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddColumnProperties(Gridproveedores_tipo_proveedorColumn);
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Selectedindex), 4, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Allowselection), 1, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Selectioncolor), 9, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Allowhovering), 1, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Hoveringcolor), 9, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Allowcollapsing), 1, 0, ".", "")));
         Gridproveedores_tipo_proveedorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridproveedores_tipo_proveedor_Collapsed), 1, 0, ".", "")));
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount14 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_14 = 1;
               ScanStart0B14( ) ;
               while ( RcdFound14 != 0 )
               {
                  init_level_properties14( ) ;
                  getByPrimaryKey0B14( ) ;
                  AddRow0B14( ) ;
                  ScanNext0B14( ) ;
               }
               ScanEnd0B14( ) ;
               nBlankRcdCount14 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0B14( ) ;
            standaloneModal0B14( ) ;
            sMode14 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow0B14( ) ;
               edtIDTIPOPROVEEDOR_Enabled = (int)(context.localUtil.CToN( cgiGet( "IDTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtDESCRIPCIONTIPOPROVEEDOR_Enabled = (int)(context.localUtil.CToN( cgiGet( "DESCRIPCIONTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtDESCRIPCIONTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONTIPOPROVEEDOR_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               imgprompt_9_Link = cgiGet( "PROMPT_9_"+sGXsfl_63_idx+"Link");
               if ( ( nRcdExists_14 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0B14( ) ;
               }
               SendRow0B14( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount14 = 5;
            nRcdExists_14 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0B14( ) ;
               while ( RcdFound14 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6314( ) ;
                  init_level_properties14( ) ;
                  standaloneNotModal0B14( ) ;
                  getByPrimaryKey0B14( ) ;
                  standaloneModal0B14( ) ;
                  AddRow0B14( ) ;
                  ScanNext0B14( ) ;
               }
               ScanEnd0B14( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode14 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6314( ) ;
            InitAll0B14( ) ;
            init_level_properties14( ) ;
            nRcdExists_14 = 0;
            nIsMod_14 = 0;
            nRcdDeleted_14 = 0;
            nBlankRcdCount14 = (short)(nBlankRcdUsr14+nBlankRcdCount14);
            fRowAdded = 0;
            while ( nBlankRcdCount14 > 0 )
            {
               standaloneNotModal0B14( ) ;
               standaloneModal0B14( ) ;
               AddRow0B14( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount14 = (short)(nBlankRcdCount14-1);
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridproveedores_tipo_proveedorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridproveedores_tipo_proveedor", Gridproveedores_tipo_proveedorContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridproveedores_tipo_proveedorContainerData", Gridproveedores_tipo_proveedorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridproveedores_tipo_proveedorContainerData"+"V", Gridproveedores_tipo_proveedorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridproveedores_tipo_proveedorContainerData"+"V"+"\" value='"+Gridproveedores_tipo_proveedorContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( "Z10IDPROVEEDOR"), ".", ","));
               Z46NOMBREPROVEEDOR = cgiGet( "Z46NOMBREPROVEEDOR");
               Z47TELEFONOPROVEEDOR = cgiGet( "Z47TELEFONOPROVEEDOR");
               Z48CORREOPROVEEDOR = cgiGet( "Z48CORREOPROVEEDOR");
               Z49DIRECCIONPROVEEDOR = cgiGet( "Z49DIRECCIONPROVEEDOR");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_63 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ".", ","));
               AV7IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( "vIDPROVEEDOR"), ".", ","));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ","));
               AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
               A46NOMBREPROVEEDOR = cgiGet( edtNOMBREPROVEEDOR_Internalname);
               AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
               A47TELEFONOPROVEEDOR = cgiGet( edtTELEFONOPROVEEDOR_Internalname);
               AssignAttri("", false, "A47TELEFONOPROVEEDOR", A47TELEFONOPROVEEDOR);
               A48CORREOPROVEEDOR = cgiGet( edtCORREOPROVEEDOR_Internalname);
               AssignAttri("", false, "A48CORREOPROVEEDOR", A48CORREOPROVEEDOR);
               A49DIRECCIONPROVEEDOR = cgiGet( edtDIRECCIONPROVEEDOR_Internalname);
               AssignAttri("", false, "A49DIRECCIONPROVEEDOR", A49DIRECCIONPROVEEDOR);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Proveedores");
               A10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ","));
               AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
               forbiddenHiddens.Add("IDPROVEEDOR", context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A10IDPROVEEDOR != Z10IDPROVEEDOR ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("proveedores:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A10IDPROVEEDOR = (long)(NumberUtil.Val( GetPar( "IDPROVEEDOR"), "."));
                  AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode13 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode13;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound13 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDPROVEEDOR");
                        AnyError = 1;
                        GX_FocusControl = edtIDPROVEEDOR_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0B13( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0B13( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B13( ) ;
            }
            else
            {
               CheckExtendedTable0B13( ) ;
               CloseExtendedTableCursors0B13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode13 = Gx_mode;
            CONFIRM_0B14( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode13;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0B14( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow0B14( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               GetKey0B14( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0B14( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0B14( ) ;
                        CloseExtendedTableCursors0B14( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( nRcdDeleted_14 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0B14( ) ;
                        Load0B14( ) ;
                        BeforeValidate0B14( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0B14( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0B14( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0B14( ) ;
                              CloseExtendedTableCursors0B14( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIDTIPOPROVEEDOR_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9IDTIPOPROVEEDOR), 12, 0, ".", ""))) ;
            ChangePostValue( edtDESCRIPCIONTIPOPROVEEDOR_Internalname, A45DESCRIPCIONTIPOPROVEEDOR) ;
            ChangePostValue( "ZT_"+"Z9IDTIPOPROVEEDOR_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9IDTIPOPROVEEDOR), 12, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "IDTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DESCRIPCIONTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONTIPOPROVEEDOR_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0B0( )
      {
      }

      protected void E110B2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "TiendaRopaProyecto");
      }

      protected void E120B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproveedores.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0B13( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z46NOMBREPROVEEDOR = T000B6_A46NOMBREPROVEEDOR[0];
               Z47TELEFONOPROVEEDOR = T000B6_A47TELEFONOPROVEEDOR[0];
               Z48CORREOPROVEEDOR = T000B6_A48CORREOPROVEEDOR[0];
               Z49DIRECCIONPROVEEDOR = T000B6_A49DIRECCIONPROVEEDOR[0];
            }
            else
            {
               Z46NOMBREPROVEEDOR = A46NOMBREPROVEEDOR;
               Z47TELEFONOPROVEEDOR = A47TELEFONOPROVEEDOR;
               Z48CORREOPROVEEDOR = A48CORREOPROVEEDOR;
               Z49DIRECCIONPROVEEDOR = A49DIRECCIONPROVEEDOR;
            }
         }
         if ( GX_JID == -9 )
         {
            Z10IDPROVEEDOR = A10IDPROVEEDOR;
            Z46NOMBREPROVEEDOR = A46NOMBREPROVEEDOR;
            Z47TELEFONOPROVEEDOR = A47TELEFONOPROVEEDOR;
            Z48CORREOPROVEEDOR = A48CORREOPROVEEDOR;
            Z49DIRECCIONPROVEEDOR = A49DIRECCIONPROVEEDOR;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIDPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPROVEEDOR_Enabled), 5, 0), true);
         edtIDPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPROVEEDOR_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IDPROVEEDOR) )
         {
            A10IDPROVEEDOR = AV7IDPROVEEDOR;
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0B13( )
      {
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
            A46NOMBREPROVEEDOR = T000B7_A46NOMBREPROVEEDOR[0];
            AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
            A47TELEFONOPROVEEDOR = T000B7_A47TELEFONOPROVEEDOR[0];
            AssignAttri("", false, "A47TELEFONOPROVEEDOR", A47TELEFONOPROVEEDOR);
            A48CORREOPROVEEDOR = T000B7_A48CORREOPROVEEDOR[0];
            AssignAttri("", false, "A48CORREOPROVEEDOR", A48CORREOPROVEEDOR);
            A49DIRECCIONPROVEEDOR = T000B7_A49DIRECCIONPROVEEDOR[0];
            AssignAttri("", false, "A49DIRECCIONPROVEEDOR", A49DIRECCIONPROVEEDOR);
            ZM0B13( -9) ;
         }
         pr_default.close(5);
         OnLoadActions0B13( ) ;
      }

      protected void OnLoadActions0B13( )
      {
         AV11Pgmname = "Proveedores";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable0B13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Proveedores";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A46NOMBREPROVEEDOR)) )
         {
            GX_msglist.addItem("Ingrese el nombre del proveedor", 1, "NOMBREPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A47TELEFONOPROVEEDOR)) )
         {
            GX_msglist.addItem("Ingrese el telefono del proveedor", 1, "TELEFONOPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtTELEFONOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A48CORREOPROVEEDOR,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field CORREOPROVEEDOR does not match the specified pattern", "OutOfRange", 1, "CORREOPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtCORREOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A48CORREOPROVEEDOR)) )
         {
            GX_msglist.addItem("Ingrese correo del proveedor", 1, "CORREOPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtCORREOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A49DIRECCIONPROVEEDOR)) )
         {
            GX_msglist.addItem("Ingrese la direccion del proveedor", 1, "DIRECCIONPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtDIRECCIONPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B13( )
      {
         /* Using cursor T000B8 */
         pr_default.execute(6, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0B13( 9) ;
            RcdFound13 = 1;
            A10IDPROVEEDOR = T000B6_A10IDPROVEEDOR[0];
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
            A46NOMBREPROVEEDOR = T000B6_A46NOMBREPROVEEDOR[0];
            AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
            A47TELEFONOPROVEEDOR = T000B6_A47TELEFONOPROVEEDOR[0];
            AssignAttri("", false, "A47TELEFONOPROVEEDOR", A47TELEFONOPROVEEDOR);
            A48CORREOPROVEEDOR = T000B6_A48CORREOPROVEEDOR[0];
            AssignAttri("", false, "A48CORREOPROVEEDOR", A48CORREOPROVEEDOR);
            A49DIRECCIONPROVEEDOR = T000B6_A49DIRECCIONPROVEEDOR[0];
            AssignAttri("", false, "A49DIRECCIONPROVEEDOR", A49DIRECCIONPROVEEDOR);
            Z10IDPROVEEDOR = A10IDPROVEEDOR;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0B13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0B13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0B13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B13( ) ;
         if ( RcdFound13 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T000B9 */
         pr_default.execute(7, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000B9_A10IDPROVEEDOR[0] < A10IDPROVEEDOR ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000B9_A10IDPROVEEDOR[0] > A10IDPROVEEDOR ) ) )
            {
               A10IDPROVEEDOR = T000B9_A10IDPROVEEDOR[0];
               AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000B10 */
         pr_default.execute(8, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A10IDPROVEEDOR[0] > A10IDPROVEEDOR ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000B10_A10IDPROVEEDOR[0] < A10IDPROVEEDOR ) ) )
            {
               A10IDPROVEEDOR = T000B10_A10IDPROVEEDOR[0];
               AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A10IDPROVEEDOR != Z10IDPROVEEDOR )
               {
                  A10IDPROVEEDOR = Z10IDPROVEEDOR;
                  AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDPROVEEDOR");
                  AnyError = 1;
                  GX_FocusControl = edtIDPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0B13( ) ;
                  GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A10IDPROVEEDOR != Z10IDPROVEEDOR )
               {
                  /* Insert record */
                  GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B13( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDPROVEEDOR");
                     AnyError = 1;
                     GX_FocusControl = edtIDPROVEEDOR_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B13( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A10IDPROVEEDOR != Z10IDPROVEEDOR )
         {
            A10IDPROVEEDOR = Z10IDPROVEEDOR;
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtIDPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNOMBREPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0B13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B5 */
            pr_default.execute(3, new Object[] {A10IDPROVEEDOR});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedores"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z46NOMBREPROVEEDOR, T000B5_A46NOMBREPROVEEDOR[0]) != 0 ) || ( StringUtil.StrCmp(Z47TELEFONOPROVEEDOR, T000B5_A47TELEFONOPROVEEDOR[0]) != 0 ) || ( StringUtil.StrCmp(Z48CORREOPROVEEDOR, T000B5_A48CORREOPROVEEDOR[0]) != 0 ) || ( StringUtil.StrCmp(Z49DIRECCIONPROVEEDOR, T000B5_A49DIRECCIONPROVEEDOR[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z46NOMBREPROVEEDOR, T000B5_A46NOMBREPROVEEDOR[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedores:[seudo value changed for attri]"+"NOMBREPROVEEDOR");
                  GXUtil.WriteLogRaw("Old: ",Z46NOMBREPROVEEDOR);
                  GXUtil.WriteLogRaw("Current: ",T000B5_A46NOMBREPROVEEDOR[0]);
               }
               if ( StringUtil.StrCmp(Z47TELEFONOPROVEEDOR, T000B5_A47TELEFONOPROVEEDOR[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedores:[seudo value changed for attri]"+"TELEFONOPROVEEDOR");
                  GXUtil.WriteLogRaw("Old: ",Z47TELEFONOPROVEEDOR);
                  GXUtil.WriteLogRaw("Current: ",T000B5_A47TELEFONOPROVEEDOR[0]);
               }
               if ( StringUtil.StrCmp(Z48CORREOPROVEEDOR, T000B5_A48CORREOPROVEEDOR[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedores:[seudo value changed for attri]"+"CORREOPROVEEDOR");
                  GXUtil.WriteLogRaw("Old: ",Z48CORREOPROVEEDOR);
                  GXUtil.WriteLogRaw("Current: ",T000B5_A48CORREOPROVEEDOR[0]);
               }
               if ( StringUtil.StrCmp(Z49DIRECCIONPROVEEDOR, T000B5_A49DIRECCIONPROVEEDOR[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedores:[seudo value changed for attri]"+"DIRECCIONPROVEEDOR");
                  GXUtil.WriteLogRaw("Old: ",Z49DIRECCIONPROVEEDOR);
                  GXUtil.WriteLogRaw("Current: ",T000B5_A49DIRECCIONPROVEEDOR[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proveedores"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B13( )
      {
         BeforeValidate0B13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B13( 0) ;
            CheckOptimisticConcurrency0B13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B11 */
                     pr_default.execute(9, new Object[] {A46NOMBREPROVEEDOR, A47TELEFONOPROVEEDOR, A48CORREOPROVEEDOR, A49DIRECCIONPROVEEDOR});
                     A10IDPROVEEDOR = T000B11_A10IDPROVEEDOR[0];
                     AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Proveedores");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0B13( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0B0( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0B13( ) ;
            }
            EndLevel0B13( ) ;
         }
         CloseExtendedTableCursors0B13( ) ;
      }

      protected void Update0B13( )
      {
         BeforeValidate0B13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B12 */
                     pr_default.execute(10, new Object[] {A46NOMBREPROVEEDOR, A47TELEFONOPROVEEDOR, A48CORREOPROVEEDOR, A49DIRECCIONPROVEEDOR, A10IDPROVEEDOR});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Proveedores");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedores"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0B13( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0B13( ) ;
         }
         CloseExtendedTableCursors0B13( ) ;
      }

      protected void DeferredUpdate0B13( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0B13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B13( ) ;
            AfterConfirm0B13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B13( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0B14( ) ;
                  while ( RcdFound14 != 0 )
                  {
                     getByPrimaryKey0B14( ) ;
                     Delete0B14( ) ;
                     ScanNext0B14( ) ;
                  }
                  ScanEnd0B14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B13 */
                     pr_default.execute(11, new Object[] {A10IDPROVEEDOR});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Proveedores");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Proveedores";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000B14 */
            pr_default.execute(12, new Object[] {A10IDPROVEEDOR});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compra_inventario"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel0B14( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow0B14( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               standaloneNotModal0B14( ) ;
               GetKey0B14( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0B14( ) ;
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( ( nRcdDeleted_14 != 0 ) && ( nRcdExists_14 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0B14( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0B14( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIDTIPOPROVEEDOR_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9IDTIPOPROVEEDOR), 12, 0, ".", ""))) ;
            ChangePostValue( edtDESCRIPCIONTIPOPROVEEDOR_Internalname, A45DESCRIPCIONTIPOPROVEEDOR) ;
            ChangePostValue( "ZT_"+"Z9IDTIPOPROVEEDOR_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9IDTIPOPROVEEDOR), 12, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "IDTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DESCRIPCIONTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONTIPOPROVEEDOR_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0B14( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
         nRcdDeleted_14 = 0;
      }

      protected void ProcessLevel0B13( )
      {
         /* Save parent mode. */
         sMode13 = Gx_mode;
         ProcessNestedLevel0B14( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0B13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("proveedores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("proveedores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B13( )
      {
         /* Scan By routine */
         /* Using cursor T000B15 */
         pr_default.execute(13);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound13 = 1;
            A10IDPROVEEDOR = T000B15_A10IDPROVEEDOR[0];
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B13( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound13 = 1;
            A10IDPROVEEDOR = T000B15_A10IDPROVEEDOR[0];
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
         }
      }

      protected void ScanEnd0B13( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0B13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B13( )
      {
         edtIDPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPROVEEDOR_Enabled), 5, 0), true);
         edtNOMBREPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtNOMBREPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBREPROVEEDOR_Enabled), 5, 0), true);
         edtTELEFONOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtTELEFONOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTELEFONOPROVEEDOR_Enabled), 5, 0), true);
         edtCORREOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtCORREOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCORREOPROVEEDOR_Enabled), 5, 0), true);
         edtDIRECCIONPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtDIRECCIONPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDIRECCIONPROVEEDOR_Enabled), 5, 0), true);
      }

      protected void ZM0B14( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -10 )
         {
            Z10IDPROVEEDOR = A10IDPROVEEDOR;
            Z9IDTIPOPROVEEDOR = A9IDTIPOPROVEEDOR;
            Z45DESCRIPCIONTIPOPROVEEDOR = A45DESCRIPCIONTIPOPROVEEDOR;
         }
      }

      protected void standaloneNotModal0B14( )
      {
      }

      protected void standaloneModal0B14( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtIDTIPOPROVEEDOR_Enabled = 0;
            AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtIDTIPOPROVEEDOR_Enabled = 1;
            AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load0B14( )
      {
         /* Using cursor T000B16 */
         pr_default.execute(14, new Object[] {A10IDPROVEEDOR, A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound14 = 1;
            A45DESCRIPCIONTIPOPROVEEDOR = T000B16_A45DESCRIPCIONTIPOPROVEEDOR[0];
            ZM0B14( -10) ;
         }
         pr_default.close(14);
         OnLoadActions0B14( ) ;
      }

      protected void OnLoadActions0B14( )
      {
      }

      protected void CheckExtendedTable0B14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal0B14( ) ;
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
            GX_msglist.addItem("No matching 'Tipo_proveedor'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A45DESCRIPCIONTIPOPROVEEDOR = T000B4_A45DESCRIPCIONTIPOPROVEEDOR[0];
         pr_default.close(2);
         if ( (0==A9IDTIPOPROVEEDOR) )
         {
            GXCCtl = "IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
            GX_msglist.addItem("Seleccione el tipo de proveedor", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0B14( )
      {
      }

      protected void gxLoad_11( long A9IDTIPOPROVEEDOR )
      {
         /* Using cursor T000B17 */
         pr_default.execute(15, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GXCCtl = "IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
            GX_msglist.addItem("No matching 'Tipo_proveedor'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A45DESCRIPCIONTIPOPROVEEDOR = T000B17_A45DESCRIPCIONTIPOPROVEEDOR[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A45DESCRIPCIONTIPOPROVEEDOR)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey0B14( )
      {
         /* Using cursor T000B18 */
         pr_default.execute(16, new Object[] {A10IDPROVEEDOR, A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey0B14( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A10IDPROVEEDOR, A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B14( 10) ;
            RcdFound14 = 1;
            InitializeNonKey0B14( ) ;
            A9IDTIPOPROVEEDOR = T000B3_A9IDTIPOPROVEEDOR[0];
            Z10IDPROVEEDOR = A10IDPROVEEDOR;
            Z9IDTIPOPROVEEDOR = A9IDTIPOPROVEEDOR;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0B14( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0B14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0B14( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0B14( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0B14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A10IDPROVEEDOR, A9IDTIPOPROVEEDOR});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedoresTipo_proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProveedoresTipo_proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B14( )
      {
         BeforeValidate0B14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B14( 0) ;
            CheckOptimisticConcurrency0B14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B19 */
                     pr_default.execute(17, new Object[] {A10IDPROVEEDOR, A9IDTIPOPROVEEDOR});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("ProveedoresTipo_proveedor");
                     if ( (pr_default.getStatus(17) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0B14( ) ;
            }
            EndLevel0B14( ) ;
         }
         CloseExtendedTableCursors0B14( ) ;
      }

      protected void Update0B14( )
      {
         BeforeValidate0B14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B14( ) ;
         }
         if ( ( nIsMod_14 != 0 ) || ( nIsDirty_14 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0B14( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0B14( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0B14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [ProveedoresTipo_proveedor] */
                        DeferredUpdate0B14( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0B14( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel0B14( ) ;
            }
         }
         CloseExtendedTableCursors0B14( ) ;
      }

      protected void DeferredUpdate0B14( )
      {
      }

      protected void Delete0B14( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B14( ) ;
            AfterConfirm0B14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B20 */
                  pr_default.execute(18, new Object[] {A10IDPROVEEDOR, A9IDTIPOPROVEEDOR});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("ProveedoresTipo_proveedor");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B14( )
      {
         standaloneModal0B14( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000B21 */
            pr_default.execute(19, new Object[] {A9IDTIPOPROVEEDOR});
            A45DESCRIPCIONTIPOPROVEEDOR = T000B21_A45DESCRIPCIONTIPOPROVEEDOR[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel0B14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B14( )
      {
         /* Scan By routine */
         /* Using cursor T000B22 */
         pr_default.execute(20, new Object[] {A10IDPROVEEDOR});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A9IDTIPOPROVEEDOR = T000B22_A9IDTIPOPROVEEDOR[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B14( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A9IDTIPOPROVEEDOR = T000B22_A9IDTIPOPROVEEDOR[0];
         }
      }

      protected void ScanEnd0B14( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0B14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B14( )
      {
         edtIDTIPOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtDESCRIPCIONTIPOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONTIPOPROVEEDOR_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes0B14( )
      {
      }

      protected void send_integrity_lvl_hashes0B13( )
      {
      }

      protected void SubsflControlProps_6314( )
      {
         edtIDTIPOPROVEEDOR_Internalname = "IDTIPOPROVEEDOR_"+sGXsfl_63_idx;
         imgprompt_9_Internalname = "PROMPT_9_"+sGXsfl_63_idx;
         edtDESCRIPCIONTIPOPROVEEDOR_Internalname = "DESCRIPCIONTIPOPROVEEDOR_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_6314( )
      {
         edtIDTIPOPROVEEDOR_Internalname = "IDTIPOPROVEEDOR_"+sGXsfl_63_fel_idx;
         imgprompt_9_Internalname = "PROMPT_9_"+sGXsfl_63_fel_idx;
         edtDESCRIPCIONTIPOPROVEEDOR_Internalname = "DESCRIPCIONTIPOPROVEEDOR_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow0B14( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6314( ) ;
         SendRow0B14( ) ;
      }

      protected void SendRow0B14( )
      {
         Gridproveedores_tipo_proveedorRow = GXWebRow.GetNew(context);
         if ( subGridproveedores_tipo_proveedor_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridproveedores_tipo_proveedor_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridproveedores_tipo_proveedor_Class, "") != 0 )
            {
               subGridproveedores_tipo_proveedor_Linesclass = subGridproveedores_tipo_proveedor_Class+"Odd";
            }
         }
         else if ( subGridproveedores_tipo_proveedor_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridproveedores_tipo_proveedor_Backstyle = 0;
            subGridproveedores_tipo_proveedor_Backcolor = subGridproveedores_tipo_proveedor_Allbackcolor;
            if ( StringUtil.StrCmp(subGridproveedores_tipo_proveedor_Class, "") != 0 )
            {
               subGridproveedores_tipo_proveedor_Linesclass = subGridproveedores_tipo_proveedor_Class+"Uniform";
            }
         }
         else if ( subGridproveedores_tipo_proveedor_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridproveedores_tipo_proveedor_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridproveedores_tipo_proveedor_Class, "") != 0 )
            {
               subGridproveedores_tipo_proveedor_Linesclass = subGridproveedores_tipo_proveedor_Class+"Odd";
            }
            subGridproveedores_tipo_proveedor_Backcolor = (int)(0x0);
         }
         else if ( subGridproveedores_tipo_proveedor_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridproveedores_tipo_proveedor_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridproveedores_tipo_proveedor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridproveedores_tipo_proveedor_Class, "") != 0 )
               {
                  subGridproveedores_tipo_proveedor_Linesclass = subGridproveedores_tipo_proveedor_Class+"Even";
               }
            }
            else
            {
               subGridproveedores_tipo_proveedor_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridproveedores_tipo_proveedor_Class, "") != 0 )
               {
                  subGridproveedores_tipo_proveedor_Linesclass = subGridproveedores_tipo_proveedor_Class+"Odd";
               }
            }
         }
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00f0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDTIPOPROVEEDOR_"+sGXsfl_63_idx+"'), id:'"+"IDTIPOPROVEEDOR_"+sGXsfl_63_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_14_"+sGXsfl_63_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridproveedores_tipo_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDTIPOPROVEEDOR_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9IDTIPOPROVEEDOR), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A9IDTIPOPROVEEDOR), "ZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDTIPOPROVEEDOR_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtIDTIPOPROVEEDOR_Enabled,(short)1,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridproveedores_tipo_proveedorRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_9_Internalname,(string)sImgUrl,(string)imgprompt_9_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_9_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridproveedores_tipo_proveedorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDESCRIPCIONTIPOPROVEEDOR_Internalname,(string)A45DESCRIPCIONTIPOPROVEEDOR,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDESCRIPCIONTIPOPROVEEDOR_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtDESCRIPCIONTIPOPROVEEDOR_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridproveedores_tipo_proveedorRow);
         send_integrity_lvl_hashes0B14( ) ;
         GXCCtl = "Z9IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9IDTIPOPROVEEDOR), 12, 0, ".", "")));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_14_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", "")));
         GXCCtl = "nIsMod_14_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_63_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vIDPROVEEDOR_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IDTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DESCRIPCIONTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONTIPOPROVEEDOR_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_9_"+sGXsfl_63_idx+"Link", StringUtil.RTrim( imgprompt_9_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridproveedores_tipo_proveedorContainer.AddRow(Gridproveedores_tipo_proveedorRow);
      }

      protected void ReadRow0B14( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6314( ) ;
         edtIDTIPOPROVEEDOR_Enabled = (int)(context.localUtil.CToN( cgiGet( "IDTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         edtDESCRIPCIONTIPOPROVEEDOR_Enabled = (int)(context.localUtil.CToN( cgiGet( "DESCRIPCIONTIPOPROVEEDOR_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         imgprompt_9_Link = cgiGet( "PROMPT_9_"+sGXsfl_63_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtIDTIPOPROVEEDOR_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDTIPOPROVEEDOR_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
         {
            GXCCtl = "IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
            wbErr = true;
            A9IDTIPOPROVEEDOR = 0;
         }
         else
         {
            A9IDTIPOPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDTIPOPROVEEDOR_Internalname), ".", ","));
         }
         A45DESCRIPCIONTIPOPROVEEDOR = cgiGet( edtDESCRIPCIONTIPOPROVEEDOR_Internalname);
         GXCCtl = "Z9IDTIPOPROVEEDOR_" + sGXsfl_63_idx;
         Z9IDTIPOPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_63_idx;
         nRcdDeleted_14 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_14_" + sGXsfl_63_idx;
         nRcdExists_14 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_14_" + sGXsfl_63_idx;
         nIsMod_14 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtIDTIPOPROVEEDOR_Enabled = edtIDTIPOPROVEEDOR_Enabled;
      }

      protected void ConfirmValues0B0( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6314( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6314( ) ;
            ChangePostValue( "Z9IDTIPOPROVEEDOR_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z9IDTIPOPROVEEDOR_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z9IDTIPOPROVEEDOR_"+sGXsfl_63_idx) ;
         }
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1152180), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2021113012542543", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("proveedores.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDPROVEEDOR,12,0))}, new string[] {"Gx_mode","IDPROVEEDOR"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Proveedores");
         forbiddenHiddens.Add("IDPROVEEDOR", context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("proveedores:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z10IDPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10IDPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z46NOMBREPROVEEDOR", Z46NOMBREPROVEEDOR);
         GxWebStd.gx_hidden_field( context, "Z47TELEFONOPROVEEDOR", StringUtil.RTrim( Z47TELEFONOPROVEEDOR));
         GxWebStd.gx_hidden_field( context, "Z48CORREOPROVEEDOR", Z48CORREOPROVEEDOR);
         GxWebStd.gx_hidden_field( context, "Z49DIRECCIONPROVEEDOR", Z49DIRECCIONPROVEEDOR);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vIDPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDPROVEEDOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDPROVEEDOR), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("proveedores.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDPROVEEDOR,12,0))}, new string[] {"Gx_mode","IDPROVEEDOR"})  ;
      }

      public override string GetPgmname( )
      {
         return "Proveedores" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proveedores" ;
      }

      protected void InitializeNonKey0B13( )
      {
         A46NOMBREPROVEEDOR = "";
         AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
         A47TELEFONOPROVEEDOR = "";
         AssignAttri("", false, "A47TELEFONOPROVEEDOR", A47TELEFONOPROVEEDOR);
         A48CORREOPROVEEDOR = "";
         AssignAttri("", false, "A48CORREOPROVEEDOR", A48CORREOPROVEEDOR);
         A49DIRECCIONPROVEEDOR = "";
         AssignAttri("", false, "A49DIRECCIONPROVEEDOR", A49DIRECCIONPROVEEDOR);
         Z46NOMBREPROVEEDOR = "";
         Z47TELEFONOPROVEEDOR = "";
         Z48CORREOPROVEEDOR = "";
         Z49DIRECCIONPROVEEDOR = "";
      }

      protected void InitAll0B13( )
      {
         A10IDPROVEEDOR = 0;
         AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
         InitializeNonKey0B13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0B14( )
      {
         A45DESCRIPCIONTIPOPROVEEDOR = "";
      }

      protected void InitAll0B14( )
      {
         A9IDTIPOPROVEEDOR = 0;
         InitializeNonKey0B14( ) ;
      }

      protected void StandaloneModalInsert0B14( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113012542548", true, true);
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
         context.AddJavascriptSource("proveedores.js", "?2021113012542549", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties14( )
      {
         edtIDTIPOPROVEEDOR_Enabled = defedtIDTIPOPROVEEDOR_Enabled;
         AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtIDPROVEEDOR_Internalname = "IDPROVEEDOR";
         edtNOMBREPROVEEDOR_Internalname = "NOMBREPROVEEDOR";
         edtTELEFONOPROVEEDOR_Internalname = "TELEFONOPROVEEDOR";
         edtCORREOPROVEEDOR_Internalname = "CORREOPROVEEDOR";
         edtDIRECCIONPROVEEDOR_Internalname = "DIRECCIONPROVEEDOR";
         lblTitletipo_proveedor_Internalname = "TITLETIPO_PROVEEDOR";
         edtIDTIPOPROVEEDOR_Internalname = "IDTIPOPROVEEDOR";
         edtDESCRIPCIONTIPOPROVEEDOR_Internalname = "DESCRIPCIONTIPOPROVEEDOR";
         divTipo_proveedortable_Internalname = "TIPO_PROVEEDORTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         subGridproveedores_tipo_proveedor_Internalname = "GRIDPROVEEDORES_TIPO_PROVEEDOR";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Proveedores";
         edtDESCRIPCIONTIPOPROVEEDOR_Jsonclick = "";
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         imgprompt_9_Visible = 1;
         edtIDTIPOPROVEEDOR_Jsonclick = "";
         subGridproveedores_tipo_proveedor_Class = "Grid";
         subGridproveedores_tipo_proveedor_Backcolorstyle = 0;
         subGridproveedores_tipo_proveedor_Allowcollapsing = 0;
         subGridproveedores_tipo_proveedor_Allowselection = 0;
         edtDESCRIPCIONTIPOPROVEEDOR_Enabled = 0;
         edtIDTIPOPROVEEDOR_Enabled = 1;
         subGridproveedores_tipo_proveedor_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDIRECCIONPROVEEDOR_Enabled = 1;
         edtCORREOPROVEEDOR_Jsonclick = "";
         edtCORREOPROVEEDOR_Enabled = 1;
         edtTELEFONOPROVEEDOR_Jsonclick = "";
         edtTELEFONOPROVEEDOR_Enabled = 1;
         edtNOMBREPROVEEDOR_Enabled = 1;
         edtIDPROVEEDOR_Jsonclick = "";
         edtIDPROVEEDOR_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridproveedores_tipo_proveedor_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6314( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0B14( ) ;
            standaloneModal0B14( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0B14( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6314( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridproveedores_tipo_proveedorContainer)) ;
         /* End function gxnrGridproveedores_tipo_proveedor_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Idtipoproveedor( )
      {
         /* Using cursor T000B21 */
         pr_default.execute(19, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo_proveedor'.", "ForeignKeyNotFound", 1, "IDTIPOPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
         }
         A45DESCRIPCIONTIPOPROVEEDOR = T000B21_A45DESCRIPCIONTIPOPROVEEDOR[0];
         pr_default.close(19);
         if ( (0==A9IDTIPOPROVEEDOR) )
         {
            GX_msglist.addItem("Seleccione el tipo de proveedor", 1, "IDTIPOPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A45DESCRIPCIONTIPOPROVEEDOR", A45DESCRIPCIONTIPOPROVEEDOR);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IDPROVEEDOR',fld:'vIDPROVEEDOR',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IDPROVEEDOR',fld:'vIDPROVEEDOR',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A10IDPROVEEDOR',fld:'IDPROVEEDOR',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120B2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_IDPROVEEDOR","{handler:'Valid_Idproveedor',iparms:[]");
         setEventMetadata("VALID_IDPROVEEDOR",",oparms:[]}");
         setEventMetadata("VALID_NOMBREPROVEEDOR","{handler:'Valid_Nombreproveedor',iparms:[]");
         setEventMetadata("VALID_NOMBREPROVEEDOR",",oparms:[]}");
         setEventMetadata("VALID_TELEFONOPROVEEDOR","{handler:'Valid_Telefonoproveedor',iparms:[]");
         setEventMetadata("VALID_TELEFONOPROVEEDOR",",oparms:[]}");
         setEventMetadata("VALID_CORREOPROVEEDOR","{handler:'Valid_Correoproveedor',iparms:[]");
         setEventMetadata("VALID_CORREOPROVEEDOR",",oparms:[]}");
         setEventMetadata("VALID_DIRECCIONPROVEEDOR","{handler:'Valid_Direccionproveedor',iparms:[]");
         setEventMetadata("VALID_DIRECCIONPROVEEDOR",",oparms:[]}");
         setEventMetadata("VALID_IDTIPOPROVEEDOR","{handler:'Valid_Idtipoproveedor',iparms:[{av:'A9IDTIPOPROVEEDOR',fld:'IDTIPOPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'A45DESCRIPCIONTIPOPROVEEDOR',fld:'DESCRIPCIONTIPOPROVEEDOR',pic:''}]");
         setEventMetadata("VALID_IDTIPOPROVEEDOR",",oparms:[{av:'A45DESCRIPCIONTIPOPROVEEDOR',fld:'DESCRIPCIONTIPOPROVEEDOR',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Descripciontipoproveedor',iparms:[]");
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
         pr_default.close(1);
         pr_default.close(19);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z46NOMBREPROVEEDOR = "";
         Z47TELEFONOPROVEEDOR = "";
         Z48CORREOPROVEEDOR = "";
         Z49DIRECCIONPROVEEDOR = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A46NOMBREPROVEEDOR = "";
         gxphoneLink = "";
         A47TELEFONOPROVEEDOR = "";
         A48CORREOPROVEEDOR = "";
         A49DIRECCIONPROVEEDOR = "";
         lblTitletipo_proveedor_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridproveedores_tipo_proveedorContainer = new GXWebGrid( context);
         Gridproveedores_tipo_proveedorColumn = new GXWebColumn();
         A45DESCRIPCIONTIPOPROVEEDOR = "";
         sMode14 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode13 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000B7_A10IDPROVEEDOR = new long[1] ;
         T000B7_A46NOMBREPROVEEDOR = new string[] {""} ;
         T000B7_A47TELEFONOPROVEEDOR = new string[] {""} ;
         T000B7_A48CORREOPROVEEDOR = new string[] {""} ;
         T000B7_A49DIRECCIONPROVEEDOR = new string[] {""} ;
         T000B8_A10IDPROVEEDOR = new long[1] ;
         T000B6_A10IDPROVEEDOR = new long[1] ;
         T000B6_A46NOMBREPROVEEDOR = new string[] {""} ;
         T000B6_A47TELEFONOPROVEEDOR = new string[] {""} ;
         T000B6_A48CORREOPROVEEDOR = new string[] {""} ;
         T000B6_A49DIRECCIONPROVEEDOR = new string[] {""} ;
         T000B9_A10IDPROVEEDOR = new long[1] ;
         T000B10_A10IDPROVEEDOR = new long[1] ;
         T000B5_A10IDPROVEEDOR = new long[1] ;
         T000B5_A46NOMBREPROVEEDOR = new string[] {""} ;
         T000B5_A47TELEFONOPROVEEDOR = new string[] {""} ;
         T000B5_A48CORREOPROVEEDOR = new string[] {""} ;
         T000B5_A49DIRECCIONPROVEEDOR = new string[] {""} ;
         T000B11_A10IDPROVEEDOR = new long[1] ;
         T000B14_A11IDCOMPRA = new long[1] ;
         T000B15_A10IDPROVEEDOR = new long[1] ;
         Z45DESCRIPCIONTIPOPROVEEDOR = "";
         T000B16_A10IDPROVEEDOR = new long[1] ;
         T000B16_A45DESCRIPCIONTIPOPROVEEDOR = new string[] {""} ;
         T000B16_A9IDTIPOPROVEEDOR = new long[1] ;
         T000B4_A45DESCRIPCIONTIPOPROVEEDOR = new string[] {""} ;
         T000B17_A45DESCRIPCIONTIPOPROVEEDOR = new string[] {""} ;
         T000B18_A10IDPROVEEDOR = new long[1] ;
         T000B18_A9IDTIPOPROVEEDOR = new long[1] ;
         T000B3_A10IDPROVEEDOR = new long[1] ;
         T000B3_A9IDTIPOPROVEEDOR = new long[1] ;
         T000B2_A10IDPROVEEDOR = new long[1] ;
         T000B2_A9IDTIPOPROVEEDOR = new long[1] ;
         T000B21_A45DESCRIPCIONTIPOPROVEEDOR = new string[] {""} ;
         T000B22_A10IDPROVEEDOR = new long[1] ;
         T000B22_A9IDTIPOPROVEEDOR = new long[1] ;
         Gridproveedores_tipo_proveedorRow = new GXWebRow();
         subGridproveedores_tipo_proveedor_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedores__default(),
            new Object[][] {
                new Object[] {
               T000B2_A10IDPROVEEDOR, T000B2_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               T000B3_A10IDPROVEEDOR, T000B3_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               T000B4_A45DESCRIPCIONTIPOPROVEEDOR
               }
               , new Object[] {
               T000B5_A10IDPROVEEDOR, T000B5_A46NOMBREPROVEEDOR, T000B5_A47TELEFONOPROVEEDOR, T000B5_A48CORREOPROVEEDOR, T000B5_A49DIRECCIONPROVEEDOR
               }
               , new Object[] {
               T000B6_A10IDPROVEEDOR, T000B6_A46NOMBREPROVEEDOR, T000B6_A47TELEFONOPROVEEDOR, T000B6_A48CORREOPROVEEDOR, T000B6_A49DIRECCIONPROVEEDOR
               }
               , new Object[] {
               T000B7_A10IDPROVEEDOR, T000B7_A46NOMBREPROVEEDOR, T000B7_A47TELEFONOPROVEEDOR, T000B7_A48CORREOPROVEEDOR, T000B7_A49DIRECCIONPROVEEDOR
               }
               , new Object[] {
               T000B8_A10IDPROVEEDOR
               }
               , new Object[] {
               T000B9_A10IDPROVEEDOR
               }
               , new Object[] {
               T000B10_A10IDPROVEEDOR
               }
               , new Object[] {
               T000B11_A10IDPROVEEDOR
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B14_A11IDCOMPRA
               }
               , new Object[] {
               T000B15_A10IDPROVEEDOR
               }
               , new Object[] {
               T000B16_A10IDPROVEEDOR, T000B16_A45DESCRIPCIONTIPOPROVEEDOR, T000B16_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               T000B17_A45DESCRIPCIONTIPOPROVEEDOR
               }
               , new Object[] {
               T000B18_A10IDPROVEEDOR, T000B18_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B21_A45DESCRIPCIONTIPOPROVEEDOR
               }
               , new Object[] {
               T000B22_A10IDPROVEEDOR, T000B22_A9IDTIPOPROVEEDOR
               }
            }
         );
         AV11Pgmname = "Proveedores";
      }

      private short nIsMod_14 ;
      private short nRcdDeleted_14 ;
      private short nRcdExists_14 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridproveedores_tipo_proveedor_Backcolorstyle ;
      private short subGridproveedores_tipo_proveedor_Allowselection ;
      private short subGridproveedores_tipo_proveedor_Allowhovering ;
      private short subGridproveedores_tipo_proveedor_Allowcollapsing ;
      private short subGridproveedores_tipo_proveedor_Collapsed ;
      private short nBlankRcdCount14 ;
      private short RcdFound14 ;
      private short nBlankRcdUsr14 ;
      private short RcdFound13 ;
      private short GX_JID ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private short nIsDirty_14 ;
      private short subGridproveedores_tipo_proveedor_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIDPROVEEDOR_Enabled ;
      private int edtNOMBREPROVEEDOR_Enabled ;
      private int edtTELEFONOPROVEEDOR_Enabled ;
      private int edtCORREOPROVEEDOR_Enabled ;
      private int edtDIRECCIONPROVEEDOR_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtIDTIPOPROVEEDOR_Enabled ;
      private int edtDESCRIPCIONTIPOPROVEEDOR_Enabled ;
      private int subGridproveedores_tipo_proveedor_Selectedindex ;
      private int subGridproveedores_tipo_proveedor_Selectioncolor ;
      private int subGridproveedores_tipo_proveedor_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridproveedores_tipo_proveedor_Backcolor ;
      private int subGridproveedores_tipo_proveedor_Allbackcolor ;
      private int imgprompt_9_Visible ;
      private int defedtIDTIPOPROVEEDOR_Enabled ;
      private int idxLst ;
      private long wcpOAV7IDPROVEEDOR ;
      private long Z10IDPROVEEDOR ;
      private long Z9IDTIPOPROVEEDOR ;
      private long A9IDTIPOPROVEEDOR ;
      private long AV7IDPROVEEDOR ;
      private long A10IDPROVEEDOR ;
      private long GRIDPROVEEDORES_TIPO_PROVEEDOR_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_63_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z47TELEFONOPROVEEDOR ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNOMBREPROVEEDOR_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtIDPROVEEDOR_Internalname ;
      private string edtIDPROVEEDOR_Jsonclick ;
      private string edtTELEFONOPROVEEDOR_Internalname ;
      private string gxphoneLink ;
      private string A47TELEFONOPROVEEDOR ;
      private string edtTELEFONOPROVEEDOR_Jsonclick ;
      private string edtCORREOPROVEEDOR_Internalname ;
      private string edtCORREOPROVEEDOR_Jsonclick ;
      private string edtDIRECCIONPROVEEDOR_Internalname ;
      private string divTipo_proveedortable_Internalname ;
      private string lblTitletipo_proveedor_Internalname ;
      private string lblTitletipo_proveedor_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridproveedores_tipo_proveedor_Header ;
      private string sMode14 ;
      private string edtIDTIPOPROVEEDOR_Internalname ;
      private string edtDESCRIPCIONTIPOPROVEEDOR_Internalname ;
      private string imgprompt_9_Link ;
      private string sStyleString ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode13 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_9_Internalname ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridproveedores_tipo_proveedor_Class ;
      private string subGridproveedores_tipo_proveedor_Linesclass ;
      private string ROClassString ;
      private string edtIDTIPOPROVEEDOR_Jsonclick ;
      private string sImgUrl ;
      private string edtDESCRIPCIONTIPOPROVEEDOR_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridproveedores_tipo_proveedor_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool returnInSub ;
      private string Z46NOMBREPROVEEDOR ;
      private string Z48CORREOPROVEEDOR ;
      private string Z49DIRECCIONPROVEEDOR ;
      private string A46NOMBREPROVEEDOR ;
      private string A48CORREOPROVEEDOR ;
      private string A49DIRECCIONPROVEEDOR ;
      private string A45DESCRIPCIONTIPOPROVEEDOR ;
      private string Z45DESCRIPCIONTIPOPROVEEDOR ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridproveedores_tipo_proveedorContainer ;
      private GXWebRow Gridproveedores_tipo_proveedorRow ;
      private GXWebColumn Gridproveedores_tipo_proveedorColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T000B7_A10IDPROVEEDOR ;
      private string[] T000B7_A46NOMBREPROVEEDOR ;
      private string[] T000B7_A47TELEFONOPROVEEDOR ;
      private string[] T000B7_A48CORREOPROVEEDOR ;
      private string[] T000B7_A49DIRECCIONPROVEEDOR ;
      private long[] T000B8_A10IDPROVEEDOR ;
      private long[] T000B6_A10IDPROVEEDOR ;
      private string[] T000B6_A46NOMBREPROVEEDOR ;
      private string[] T000B6_A47TELEFONOPROVEEDOR ;
      private string[] T000B6_A48CORREOPROVEEDOR ;
      private string[] T000B6_A49DIRECCIONPROVEEDOR ;
      private long[] T000B9_A10IDPROVEEDOR ;
      private long[] T000B10_A10IDPROVEEDOR ;
      private long[] T000B5_A10IDPROVEEDOR ;
      private string[] T000B5_A46NOMBREPROVEEDOR ;
      private string[] T000B5_A47TELEFONOPROVEEDOR ;
      private string[] T000B5_A48CORREOPROVEEDOR ;
      private string[] T000B5_A49DIRECCIONPROVEEDOR ;
      private long[] T000B11_A10IDPROVEEDOR ;
      private long[] T000B14_A11IDCOMPRA ;
      private long[] T000B15_A10IDPROVEEDOR ;
      private long[] T000B16_A10IDPROVEEDOR ;
      private string[] T000B16_A45DESCRIPCIONTIPOPROVEEDOR ;
      private long[] T000B16_A9IDTIPOPROVEEDOR ;
      private string[] T000B4_A45DESCRIPCIONTIPOPROVEEDOR ;
      private string[] T000B17_A45DESCRIPCIONTIPOPROVEEDOR ;
      private long[] T000B18_A10IDPROVEEDOR ;
      private long[] T000B18_A9IDTIPOPROVEEDOR ;
      private long[] T000B3_A10IDPROVEEDOR ;
      private long[] T000B3_A9IDTIPOPROVEEDOR ;
      private long[] T000B2_A10IDPROVEEDOR ;
      private long[] T000B2_A9IDTIPOPROVEEDOR ;
      private string[] T000B21_A45DESCRIPCIONTIPOPROVEEDOR ;
      private long[] T000B22_A10IDPROVEEDOR ;
      private long[] T000B22_A9IDTIPOPROVEEDOR ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class proveedores__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000B7;
          prmT000B7 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B8;
          prmT000B8 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B6;
          prmT000B6 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B9;
          prmT000B9 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B10;
          prmT000B10 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B5;
          prmT000B5 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B11;
          prmT000B11 = new Object[] {
          new ParDef("@NOMBREPROVEEDOR",GXType.NVarChar,255,0) ,
          new ParDef("@TELEFONOPROVEEDOR",GXType.NChar,20,0) ,
          new ParDef("@CORREOPROVEEDOR",GXType.NVarChar,100,0) ,
          new ParDef("@DIRECCIONPROVEEDOR",GXType.NVarChar,255,0)
          };
          Object[] prmT000B12;
          prmT000B12 = new Object[] {
          new ParDef("@NOMBREPROVEEDOR",GXType.NVarChar,255,0) ,
          new ParDef("@TELEFONOPROVEEDOR",GXType.NChar,20,0) ,
          new ParDef("@CORREOPROVEEDOR",GXType.NVarChar,100,0) ,
          new ParDef("@DIRECCIONPROVEEDOR",GXType.NVarChar,255,0) ,
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B13;
          prmT000B13 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B14;
          prmT000B14 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B15;
          prmT000B15 = new Object[] {
          };
          Object[] prmT000B16;
          prmT000B16 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B4;
          prmT000B4 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B17;
          prmT000B17 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B18;
          prmT000B18 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B3;
          prmT000B3 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B2;
          prmT000B2 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B19;
          prmT000B19 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B20;
          prmT000B20 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B22;
          prmT000B22 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000B21;
          prmT000B21 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000B2", "SELECT [IDPROVEEDOR], [IDTIPOPROVEEDOR] FROM [ProveedoresTipo_proveedor] WITH (UPDLOCK) WHERE [IDPROVEEDOR] = @IDPROVEEDOR AND [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B3", "SELECT [IDPROVEEDOR], [IDTIPOPROVEEDOR] FROM [ProveedoresTipo_proveedor] WHERE [IDPROVEEDOR] = @IDPROVEEDOR AND [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B4", "SELECT [DESCRIPCIONTIPOPROVEEDOR] FROM [Tipo_proveedor] WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B5", "SELECT [IDPROVEEDOR], [NOMBREPROVEEDOR], [TELEFONOPROVEEDOR], [CORREOPROVEEDOR], [DIRECCIONPROVEEDOR] FROM [Proveedores] WITH (UPDLOCK) WHERE [IDPROVEEDOR] = @IDPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B6", "SELECT [IDPROVEEDOR], [NOMBREPROVEEDOR], [TELEFONOPROVEEDOR], [CORREOPROVEEDOR], [DIRECCIONPROVEEDOR] FROM [Proveedores] WHERE [IDPROVEEDOR] = @IDPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B7", "SELECT TM1.[IDPROVEEDOR], TM1.[NOMBREPROVEEDOR], TM1.[TELEFONOPROVEEDOR], TM1.[CORREOPROVEEDOR], TM1.[DIRECCIONPROVEEDOR] FROM [Proveedores] TM1 WHERE TM1.[IDPROVEEDOR] = @IDPROVEEDOR ORDER BY TM1.[IDPROVEEDOR]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B8", "SELECT [IDPROVEEDOR] FROM [Proveedores] WHERE [IDPROVEEDOR] = @IDPROVEEDOR  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B9", "SELECT TOP 1 [IDPROVEEDOR] FROM [Proveedores] WHERE ( [IDPROVEEDOR] > @IDPROVEEDOR) ORDER BY [IDPROVEEDOR]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B10", "SELECT TOP 1 [IDPROVEEDOR] FROM [Proveedores] WHERE ( [IDPROVEEDOR] < @IDPROVEEDOR) ORDER BY [IDPROVEEDOR] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B11", "INSERT INTO [Proveedores]([NOMBREPROVEEDOR], [TELEFONOPROVEEDOR], [CORREOPROVEEDOR], [DIRECCIONPROVEEDOR]) VALUES(@NOMBREPROVEEDOR, @TELEFONOPROVEEDOR, @CORREOPROVEEDOR, @DIRECCIONPROVEEDOR); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000B11)
             ,new CursorDef("T000B12", "UPDATE [Proveedores] SET [NOMBREPROVEEDOR]=@NOMBREPROVEEDOR, [TELEFONOPROVEEDOR]=@TELEFONOPROVEEDOR, [CORREOPROVEEDOR]=@CORREOPROVEEDOR, [DIRECCIONPROVEEDOR]=@DIRECCIONPROVEEDOR  WHERE [IDPROVEEDOR] = @IDPROVEEDOR", GxErrorMask.GX_NOMASK,prmT000B12)
             ,new CursorDef("T000B13", "DELETE FROM [Proveedores]  WHERE [IDPROVEEDOR] = @IDPROVEEDOR", GxErrorMask.GX_NOMASK,prmT000B13)
             ,new CursorDef("T000B14", "SELECT TOP 1 [IDCOMPRA] FROM [Compra_inventario] WHERE [IDPROVEEDOR] = @IDPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B15", "SELECT [IDPROVEEDOR] FROM [Proveedores] ORDER BY [IDPROVEEDOR]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B16", "SELECT T1.[IDPROVEEDOR], T2.[DESCRIPCIONTIPOPROVEEDOR], T1.[IDTIPOPROVEEDOR] FROM ([ProveedoresTipo_proveedor] T1 INNER JOIN [Tipo_proveedor] T2 ON T2.[IDTIPOPROVEEDOR] = T1.[IDTIPOPROVEEDOR]) WHERE T1.[IDPROVEEDOR] = @IDPROVEEDOR and T1.[IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ORDER BY T1.[IDPROVEEDOR], T1.[IDTIPOPROVEEDOR] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B16,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B17", "SELECT [DESCRIPCIONTIPOPROVEEDOR] FROM [Tipo_proveedor] WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B18", "SELECT [IDPROVEEDOR], [IDTIPOPROVEEDOR] FROM [ProveedoresTipo_proveedor] WHERE [IDPROVEEDOR] = @IDPROVEEDOR AND [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B19", "INSERT INTO [ProveedoresTipo_proveedor]([IDPROVEEDOR], [IDTIPOPROVEEDOR]) VALUES(@IDPROVEEDOR, @IDTIPOPROVEEDOR)", GxErrorMask.GX_NOMASK,prmT000B19)
             ,new CursorDef("T000B20", "DELETE FROM [ProveedoresTipo_proveedor]  WHERE [IDPROVEEDOR] = @IDPROVEEDOR AND [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR", GxErrorMask.GX_NOMASK,prmT000B20)
             ,new CursorDef("T000B21", "SELECT [DESCRIPCIONTIPOPROVEEDOR] FROM [Tipo_proveedor] WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B22", "SELECT [IDPROVEEDOR], [IDTIPOPROVEEDOR] FROM [ProveedoresTipo_proveedor] WHERE [IDPROVEEDOR] = @IDPROVEEDOR ORDER BY [IDPROVEEDOR], [IDTIPOPROVEEDOR] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B22,11, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
