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
   public class tipo_proveedor : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
               AV7IDTIPOPROVEEDOR = (long)(NumberUtil.Val( GetPar( "IDTIPOPROVEEDOR"), "."));
               AssignAttri("", false, "AV7IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(AV7IDTIPOPROVEEDOR), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDTIPOPROVEEDOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDTIPOPROVEEDOR), "ZZZZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Tipo_proveedor", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipo_proveedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tipo_proveedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IDTIPOPROVEEDOR )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IDTIPOPROVEEDOR = aP1_IDTIPOPROVEEDOR;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tipo_proveedor", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Tipo_proveedor.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Tipo_proveedor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDTIPOPROVEEDOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDTIPOPROVEEDOR_Internalname, "IDTIPOPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIDTIPOPROVEEDOR_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9IDTIPOPROVEEDOR), 12, 0, ".", "")), ((edtIDTIPOPROVEEDOR_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A9IDTIPOPROVEEDOR), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A9IDTIPOPROVEEDOR), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDTIPOPROVEEDOR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDTIPOPROVEEDOR_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONTIPOPROVEEDOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONTIPOPROVEEDOR_Internalname, "DESCRIPCIONTIPOPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONTIPOPROVEEDOR_Internalname, A45DESCRIPCIONTIPOPROVEEDOR, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtDESCRIPCIONTIPOPROVEEDOR_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Tipo_proveedor.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Tipo_proveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z9IDTIPOPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( "Z9IDTIPOPROVEEDOR"), ".", ","));
               Z45DESCRIPCIONTIPOPROVEEDOR = cgiGet( "Z45DESCRIPCIONTIPOPROVEEDOR");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7IDTIPOPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( "vIDTIPOPROVEEDOR"), ".", ","));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A9IDTIPOPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDTIPOPROVEEDOR_Internalname), ".", ","));
               AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
               A45DESCRIPCIONTIPOPROVEEDOR = cgiGet( edtDESCRIPCIONTIPOPROVEEDOR_Internalname);
               AssignAttri("", false, "A45DESCRIPCIONTIPOPROVEEDOR", A45DESCRIPCIONTIPOPROVEEDOR);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Tipo_proveedor");
               A9IDTIPOPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDTIPOPROVEEDOR_Internalname), ".", ","));
               AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
               forbiddenHiddens.Add("IDTIPOPROVEEDOR", context.localUtil.Format( (decimal)(A9IDTIPOPROVEEDOR), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A9IDTIPOPROVEEDOR != Z9IDTIPOPROVEEDOR ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tipo_proveedor:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A9IDTIPOPROVEEDOR = (long)(NumberUtil.Val( GetPar( "IDTIPOPROVEEDOR"), "."));
                  AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
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
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDTIPOPROVEEDOR");
                        AnyError = 1;
                        GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
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
                           E110C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120C2 ();
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
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C15( ) ;
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
            DisableAttributes0C15( ) ;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C15( ) ;
            }
            else
            {
               CheckExtendedTable0C15( ) ;
               CloseExtendedTableCursors0C15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
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

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwtipo_proveedor.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0C15( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z45DESCRIPCIONTIPOPROVEEDOR = T000C3_A45DESCRIPCIONTIPOPROVEEDOR[0];
            }
            else
            {
               Z45DESCRIPCIONTIPOPROVEEDOR = A45DESCRIPCIONTIPOPROVEEDOR;
            }
         }
         if ( GX_JID == -4 )
         {
            Z9IDTIPOPROVEEDOR = A9IDTIPOPROVEEDOR;
            Z45DESCRIPCIONTIPOPROVEEDOR = A45DESCRIPCIONTIPOPROVEEDOR;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIDTIPOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), true);
         edtIDTIPOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IDTIPOPROVEEDOR) )
         {
            A9IDTIPOPROVEEDOR = AV7IDTIPOPROVEEDOR;
            AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
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

      protected void Load0C15( )
      {
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound15 = 1;
            A45DESCRIPCIONTIPOPROVEEDOR = T000C4_A45DESCRIPCIONTIPOPROVEEDOR[0];
            AssignAttri("", false, "A45DESCRIPCIONTIPOPROVEEDOR", A45DESCRIPCIONTIPOPROVEEDOR);
            ZM0C15( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0C15( ) ;
      }

      protected void OnLoadActions0C15( )
      {
         AV11Pgmname = "Tipo_proveedor";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable0C15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Tipo_proveedor";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A45DESCRIPCIONTIPOPROVEEDOR)) )
         {
            GX_msglist.addItem("Ingrese la descripcion del tipo del proveedor", 1, "DESCRIPCIONTIPOPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0C15( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C15( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C15( 4) ;
            RcdFound15 = 1;
            A9IDTIPOPROVEEDOR = T000C3_A9IDTIPOPROVEEDOR[0];
            AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
            A45DESCRIPCIONTIPOPROVEEDOR = T000C3_A45DESCRIPCIONTIPOPROVEEDOR[0];
            AssignAttri("", false, "A45DESCRIPCIONTIPOPROVEEDOR", A45DESCRIPCIONTIPOPROVEEDOR);
            Z9IDTIPOPROVEEDOR = A9IDTIPOPROVEEDOR;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0C15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0C15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000C6_A9IDTIPOPROVEEDOR[0] < A9IDTIPOPROVEEDOR ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000C6_A9IDTIPOPROVEEDOR[0] > A9IDTIPOPROVEEDOR ) ) )
            {
               A9IDTIPOPROVEEDOR = T000C6_A9IDTIPOPROVEEDOR[0];
               AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A9IDTIPOPROVEEDOR});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000C7_A9IDTIPOPROVEEDOR[0] > A9IDTIPOPROVEEDOR ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000C7_A9IDTIPOPROVEEDOR[0] < A9IDTIPOPROVEEDOR ) ) )
            {
               A9IDTIPOPROVEEDOR = T000C7_A9IDTIPOPROVEEDOR[0];
               AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A9IDTIPOPROVEEDOR != Z9IDTIPOPROVEEDOR )
               {
                  A9IDTIPOPROVEEDOR = Z9IDTIPOPROVEEDOR;
                  AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDTIPOPROVEEDOR");
                  AnyError = 1;
                  GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C15( ) ;
                  GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A9IDTIPOPROVEEDOR != Z9IDTIPOPROVEEDOR )
               {
                  /* Insert record */
                  GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDTIPOPROVEEDOR");
                     AnyError = 1;
                     GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C15( ) ;
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
         if ( A9IDTIPOPROVEEDOR != Z9IDTIPOPROVEEDOR )
         {
            A9IDTIPOPROVEEDOR = Z9IDTIPOPROVEEDOR;
            AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDTIPOPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtIDTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDESCRIPCIONTIPOPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A9IDTIPOPROVEEDOR});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tipo_proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z45DESCRIPCIONTIPOPROVEEDOR, T000C2_A45DESCRIPCIONTIPOPROVEEDOR[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z45DESCRIPCIONTIPOPROVEEDOR, T000C2_A45DESCRIPCIONTIPOPROVEEDOR[0]) != 0 )
               {
                  GXUtil.WriteLog("tipo_proveedor:[seudo value changed for attri]"+"DESCRIPCIONTIPOPROVEEDOR");
                  GXUtil.WriteLogRaw("Old: ",Z45DESCRIPCIONTIPOPROVEEDOR);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A45DESCRIPCIONTIPOPROVEEDOR[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tipo_proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C15( )
      {
         BeforeValidate0C15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C15( 0) ;
            CheckOptimisticConcurrency0C15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C8 */
                     pr_default.execute(6, new Object[] {A45DESCRIPCIONTIPOPROVEEDOR});
                     A9IDTIPOPROVEEDOR = T000C8_A9IDTIPOPROVEEDOR[0];
                     AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Tipo_proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0C0( ) ;
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
               Load0C15( ) ;
            }
            EndLevel0C15( ) ;
         }
         CloseExtendedTableCursors0C15( ) ;
      }

      protected void Update0C15( )
      {
         BeforeValidate0C15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C9 */
                     pr_default.execute(7, new Object[] {A45DESCRIPCIONTIPOPROVEEDOR, A9IDTIPOPROVEEDOR});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Tipo_proveedor");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tipo_proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel0C15( ) ;
         }
         CloseExtendedTableCursors0C15( ) ;
      }

      protected void DeferredUpdate0C15( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0C15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C15( ) ;
            AfterConfirm0C15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C10 */
                  pr_default.execute(8, new Object[] {A9IDTIPOPROVEEDOR});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Tipo_proveedor");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Tipo_proveedor";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C11 */
            pr_default.execute(9, new Object[] {A9IDTIPOPROVEEDOR});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tipo_proveedor"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0C15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C15( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tipo_proveedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tipo_proveedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C15( )
      {
         /* Scan By routine */
         /* Using cursor T000C12 */
         pr_default.execute(10);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound15 = 1;
            A9IDTIPOPROVEEDOR = T000C12_A9IDTIPOPROVEEDOR[0];
            AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C15( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound15 = 1;
            A9IDTIPOPROVEEDOR = T000C12_A9IDTIPOPROVEEDOR[0];
            AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
         }
      }

      protected void ScanEnd0C15( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0C15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C15( )
      {
         edtIDTIPOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOPROVEEDOR_Enabled), 5, 0), true);
         edtDESCRIPCIONTIPOPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONTIPOPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONTIPOPROVEEDOR_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
      {
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
         context.AddJavascriptSource("gxcfg.js", "?2021112620512953", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tipo_proveedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDTIPOPROVEEDOR,12,0))}, new string[] {"Gx_mode","IDTIPOPROVEEDOR"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Tipo_proveedor");
         forbiddenHiddens.Add("IDTIPOPROVEEDOR", context.localUtil.Format( (decimal)(A9IDTIPOPROVEEDOR), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tipo_proveedor:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z9IDTIPOPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9IDTIPOPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z45DESCRIPCIONTIPOPROVEEDOR", Z45DESCRIPCIONTIPOPROVEEDOR);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vIDTIPOPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDTIPOPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDTIPOPROVEEDOR", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDTIPOPROVEEDOR), "ZZZZZZZZZZZ9"), context));
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
         return formatLink("tipo_proveedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDTIPOPROVEEDOR,12,0))}, new string[] {"Gx_mode","IDTIPOPROVEEDOR"})  ;
      }

      public override string GetPgmname( )
      {
         return "Tipo_proveedor" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo_proveedor" ;
      }

      protected void InitializeNonKey0C15( )
      {
         A45DESCRIPCIONTIPOPROVEEDOR = "";
         AssignAttri("", false, "A45DESCRIPCIONTIPOPROVEEDOR", A45DESCRIPCIONTIPOPROVEEDOR);
         Z45DESCRIPCIONTIPOPROVEEDOR = "";
      }

      protected void InitAll0C15( )
      {
         A9IDTIPOPROVEEDOR = 0;
         AssignAttri("", false, "A9IDTIPOPROVEEDOR", StringUtil.LTrimStr( (decimal)(A9IDTIPOPROVEEDOR), 12, 0));
         InitializeNonKey0C15( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021112620512956", true, true);
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
         context.AddJavascriptSource("tipo_proveedor.js", "?2021112620512957", false, true);
         /* End function include_jscripts */
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
         edtIDTIPOPROVEEDOR_Internalname = "IDTIPOPROVEEDOR";
         edtDESCRIPCIONTIPOPROVEEDOR_Internalname = "DESCRIPCIONTIPOPROVEEDOR";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Tipo_proveedor";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDESCRIPCIONTIPOPROVEEDOR_Enabled = 1;
         edtIDTIPOPROVEEDOR_Jsonclick = "";
         edtIDTIPOPROVEEDOR_Enabled = 0;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IDTIPOPROVEEDOR',fld:'vIDTIPOPROVEEDOR',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IDTIPOPROVEEDOR',fld:'vIDTIPOPROVEEDOR',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A9IDTIPOPROVEEDOR',fld:'IDTIPOPROVEEDOR',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120C2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_IDTIPOPROVEEDOR","{handler:'Valid_Idtipoproveedor',iparms:[]");
         setEventMetadata("VALID_IDTIPOPROVEEDOR",",oparms:[]}");
         setEventMetadata("VALID_DESCRIPCIONTIPOPROVEEDOR","{handler:'Valid_Descripciontipoproveedor',iparms:[]");
         setEventMetadata("VALID_DESCRIPCIONTIPOPROVEEDOR",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z45DESCRIPCIONTIPOPROVEEDOR = "";
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
         A45DESCRIPCIONTIPOPROVEEDOR = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000C4_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C4_A45DESCRIPCIONTIPOPROVEEDOR = new string[] {""} ;
         T000C5_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C3_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C3_A45DESCRIPCIONTIPOPROVEEDOR = new string[] {""} ;
         T000C6_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C7_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C2_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C2_A45DESCRIPCIONTIPOPROVEEDOR = new string[] {""} ;
         T000C8_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C11_A10IDPROVEEDOR = new long[1] ;
         T000C11_A9IDTIPOPROVEEDOR = new long[1] ;
         T000C12_A9IDTIPOPROVEEDOR = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipo_proveedor__default(),
            new Object[][] {
                new Object[] {
               T000C2_A9IDTIPOPROVEEDOR, T000C2_A45DESCRIPCIONTIPOPROVEEDOR
               }
               , new Object[] {
               T000C3_A9IDTIPOPROVEEDOR, T000C3_A45DESCRIPCIONTIPOPROVEEDOR
               }
               , new Object[] {
               T000C4_A9IDTIPOPROVEEDOR, T000C4_A45DESCRIPCIONTIPOPROVEEDOR
               }
               , new Object[] {
               T000C5_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               T000C6_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               T000C7_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               T000C8_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C11_A10IDPROVEEDOR, T000C11_A9IDTIPOPROVEEDOR
               }
               , new Object[] {
               T000C12_A9IDTIPOPROVEEDOR
               }
            }
         );
         AV11Pgmname = "Tipo_proveedor";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound15 ;
      private short GX_JID ;
      private short nIsDirty_15 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIDTIPOPROVEEDOR_Enabled ;
      private int edtDESCRIPCIONTIPOPROVEEDOR_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long wcpOAV7IDTIPOPROVEEDOR ;
      private long Z9IDTIPOPROVEEDOR ;
      private long AV7IDTIPOPROVEEDOR ;
      private long A9IDTIPOPROVEEDOR ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDESCRIPCIONTIPOPROVEEDOR_Internalname ;
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
      private string edtIDTIPOPROVEEDOR_Internalname ;
      private string edtIDTIPOPROVEEDOR_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode15 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string Z45DESCRIPCIONTIPOPROVEEDOR ;
      private string A45DESCRIPCIONTIPOPROVEEDOR ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T000C4_A9IDTIPOPROVEEDOR ;
      private string[] T000C4_A45DESCRIPCIONTIPOPROVEEDOR ;
      private long[] T000C5_A9IDTIPOPROVEEDOR ;
      private long[] T000C3_A9IDTIPOPROVEEDOR ;
      private string[] T000C3_A45DESCRIPCIONTIPOPROVEEDOR ;
      private long[] T000C6_A9IDTIPOPROVEEDOR ;
      private long[] T000C7_A9IDTIPOPROVEEDOR ;
      private long[] T000C2_A9IDTIPOPROVEEDOR ;
      private string[] T000C2_A45DESCRIPCIONTIPOPROVEEDOR ;
      private long[] T000C8_A9IDTIPOPROVEEDOR ;
      private long[] T000C11_A10IDPROVEEDOR ;
      private long[] T000C11_A9IDTIPOPROVEEDOR ;
      private long[] T000C12_A9IDTIPOPROVEEDOR ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class tipo_proveedor__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000C4;
          prmT000C4 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C5;
          prmT000C5 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C3;
          prmT000C3 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C6;
          prmT000C6 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C7;
          prmT000C7 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C2;
          prmT000C2 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C8;
          prmT000C8 = new Object[] {
          new ParDef("@DESCRIPCIONTIPOPROVEEDOR",GXType.NVarChar,255,0)
          };
          Object[] prmT000C9;
          prmT000C9 = new Object[] {
          new ParDef("@DESCRIPCIONTIPOPROVEEDOR",GXType.NVarChar,255,0) ,
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C10;
          prmT000C10 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C11;
          prmT000C11 = new Object[] {
          new ParDef("@IDTIPOPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000C12;
          prmT000C12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT [IDTIPOPROVEEDOR], [DESCRIPCIONTIPOPROVEEDOR] FROM [Tipo_proveedor] WITH (UPDLOCK) WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT [IDTIPOPROVEEDOR], [DESCRIPCIONTIPOPROVEEDOR] FROM [Tipo_proveedor] WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C4", "SELECT TM1.[IDTIPOPROVEEDOR], TM1.[DESCRIPCIONTIPOPROVEEDOR] FROM [Tipo_proveedor] TM1 WHERE TM1.[IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ORDER BY TM1.[IDTIPOPROVEEDOR]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C5", "SELECT [IDTIPOPROVEEDOR] FROM [Tipo_proveedor] WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT TOP 1 [IDTIPOPROVEEDOR] FROM [Tipo_proveedor] WHERE ( [IDTIPOPROVEEDOR] > @IDTIPOPROVEEDOR) ORDER BY [IDTIPOPROVEEDOR]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C7", "SELECT TOP 1 [IDTIPOPROVEEDOR] FROM [Tipo_proveedor] WHERE ( [IDTIPOPROVEEDOR] < @IDTIPOPROVEEDOR) ORDER BY [IDTIPOPROVEEDOR] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C8", "INSERT INTO [Tipo_proveedor]([DESCRIPCIONTIPOPROVEEDOR]) VALUES(@DESCRIPCIONTIPOPROVEEDOR); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000C8)
             ,new CursorDef("T000C9", "UPDATE [Tipo_proveedor] SET [DESCRIPCIONTIPOPROVEEDOR]=@DESCRIPCIONTIPOPROVEEDOR  WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR", GxErrorMask.GX_NOMASK,prmT000C9)
             ,new CursorDef("T000C10", "DELETE FROM [Tipo_proveedor]  WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR", GxErrorMask.GX_NOMASK,prmT000C10)
             ,new CursorDef("T000C11", "SELECT TOP 1 [IDPROVEEDOR], [IDTIPOPROVEEDOR] FROM [ProveedoresTipo_proveedor] WHERE [IDTIPOPROVEEDOR] = @IDTIPOPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C12", "SELECT [IDTIPOPROVEEDOR] FROM [Tipo_proveedor] ORDER BY [IDTIPOPROVEEDOR]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C12,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
