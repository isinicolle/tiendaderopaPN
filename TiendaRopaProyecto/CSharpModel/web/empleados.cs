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
   public class empleados : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A2IDTIPOEMPLEADO = (long)(NumberUtil.Val( GetPar( "IDTIPOEMPLEADO"), "."));
            AssignAttri("", false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A2IDTIPOEMPLEADO) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A3IDESTADOEMPLEADO = (long)(NumberUtil.Val( GetPar( "IDESTADOEMPLEADO"), "."));
            AssignAttri("", false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A3IDESTADOEMPLEADO) ;
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
               AV7IDEMPLEADO = (long)(NumberUtil.Val( GetPar( "IDEMPLEADO"), "."));
               AssignAttri("", false, "AV7IDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV7IDEMPLEADO), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDEMPLEADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDEMPLEADO), "ZZZZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Empleados", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public empleados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public empleados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IDEMPLEADO )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IDEMPLEADO = aP1_IDEMPLEADO;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Empleados", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Empleados.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Empleados.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDEMPLEADO_Internalname, "IDEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIDEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")), ((edtIDEMPLEADO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDEMPLEADO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Empleados.htm");
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
         GxWebStd.gx_label_element( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, "NOMBRECOMPLETOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, A23NOMBRECOMPLETOEMPLEADO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtNOMBRECOMPLETOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUSUARIOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUSUARIOEMPLEADO_Internalname, "USUARIOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUSUARIOEMPLEADO_Internalname, A24USUARIOEMPLEADO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtUSUARIOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCONTRASENAEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCONTRASENAEMPLEADO_Internalname, "CONTRASENAEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCONTRASENAEMPLEADO_Internalname, A25CONTRASENAEMPLEADO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtCONTRASENAEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTELEFONOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTELEFONOEMPLEADO_Internalname, "TELEFONOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A26TELEFONOEMPLEADO);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTELEFONOEMPLEADO_Internalname, StringUtil.RTrim( A26TELEFONOEMPLEADO), StringUtil.RTrim( context.localUtil.Format( A26TELEFONOEMPLEADO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtTELEFONOEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTELEFONOEMPLEADO_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHACONTRATACIONEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFECHACONTRATACIONEMPLEADO_Internalname, "FECHACONTRATACIONEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFECHACONTRATACIONEMPLEADO_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFECHACONTRATACIONEMPLEADO_Internalname, context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"), context.localUtil.Format( A29FECHACONTRATACIONEMPLEADO, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHACONTRATACIONEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFECHACONTRATACIONEMPLEADO_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Empleados.htm");
         GxWebStd.gx_bitmap( context, edtFECHACONTRATACIONEMPLEADO_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHACONTRATACIONEMPLEADO_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Empleados.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCORREOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCORREOEMPLEADO_Internalname, "CORREOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCORREOEMPLEADO_Internalname, A27CORREOEMPLEADO, StringUtil.RTrim( context.localUtil.Format( A27CORREOEMPLEADO, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A27CORREOEMPLEADO, "", "", "", edtCORREOEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCORREOEMPLEADO_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDIRECCIONEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDIRECCIONEMPLEADO_Internalname, "DIRECCIONEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDIRECCIONEMPLEADO_Internalname, A28DIRECCIONEMPLEADO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtDIRECCIONEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgFOTOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "FOTOEMPLEADO", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A52FOTOEMPLEADO_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FOTOEMPLEADO_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.PathToRelativeUrl( A52FOTOEMPLEADO));
         GxWebStd.gx_bitmap( context, imgFOTOEMPLEADO_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgFOTOEMPLEADO_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", "", "", 0, A52FOTOEMPLEADO_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Empleados.htm");
         AssignProp("", false, imgFOTOEMPLEADO_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.PathToRelativeUrl( A52FOTOEMPLEADO)), true);
         AssignProp("", false, imgFOTOEMPLEADO_Internalname, "IsBlob", StringUtil.BoolToStr( A52FOTOEMPLEADO_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDTIPOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDTIPOEMPLEADO_Internalname, "IDTIPOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDTIPOEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2IDTIPOEMPLEADO), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2IDTIPOEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDTIPOEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDTIPOEMPLEADO_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Empleados.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_2_Internalname, sImgUrl, imgprompt_2_Link, "", "", context.GetTheme( ), imgprompt_2_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONTIPOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONTIPOEMPLEADO_Internalname, "DESCRIPCIONTIPOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONTIPOEMPLEADO_Internalname, A21DESCRIPCIONTIPOEMPLEADO, "", "", 0, 1, edtDESCRIPCIONTIPOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDESTADOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDESTADOEMPLEADO_Internalname, "IDESTADOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDESTADOEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3IDESTADOEMPLEADO), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A3IDESTADOEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDESTADOEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDESTADOEMPLEADO_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Empleados.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_3_Internalname, sImgUrl, imgprompt_3_Link, "", "", context.GetTheme( ), imgprompt_3_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONESTADOEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONESTADOEMPLEADO_Internalname, "DESCRIPCIONESTADOEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONESTADOEMPLEADO_Internalname, A22DESCRIPCIONESTADOEMPLEADO, "", "", 0, 1, edtDESCRIPCIONESTADOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Empleados.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleados.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Empleados.htm");
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
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "Z1IDEMPLEADO"), ".", ","));
               Z23NOMBRECOMPLETOEMPLEADO = cgiGet( "Z23NOMBRECOMPLETOEMPLEADO");
               Z24USUARIOEMPLEADO = cgiGet( "Z24USUARIOEMPLEADO");
               Z25CONTRASENAEMPLEADO = cgiGet( "Z25CONTRASENAEMPLEADO");
               Z26TELEFONOEMPLEADO = cgiGet( "Z26TELEFONOEMPLEADO");
               Z29FECHACONTRATACIONEMPLEADO = context.localUtil.CToD( cgiGet( "Z29FECHACONTRATACIONEMPLEADO"), 0);
               Z27CORREOEMPLEADO = cgiGet( "Z27CORREOEMPLEADO");
               Z28DIRECCIONEMPLEADO = cgiGet( "Z28DIRECCIONEMPLEADO");
               Z2IDTIPOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "Z2IDTIPOEMPLEADO"), ".", ","));
               Z3IDESTADOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "Z3IDESTADOEMPLEADO"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N2IDTIPOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "N2IDTIPOEMPLEADO"), ".", ","));
               N3IDESTADOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "N3IDESTADOEMPLEADO"), ".", ","));
               AV7IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "vIDEMPLEADO"), ".", ","));
               AV11Insert_IDTIPOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDTIPOEMPLEADO"), ".", ","));
               AV12Insert_IDESTADOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDESTADOEMPLEADO"), ".", ","));
               A40000FOTOEMPLEADO_GXI = cgiGet( "FOTOEMPLEADO_GXI");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
               AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               A23NOMBRECOMPLETOEMPLEADO = cgiGet( edtNOMBRECOMPLETOEMPLEADO_Internalname);
               AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
               A24USUARIOEMPLEADO = cgiGet( edtUSUARIOEMPLEADO_Internalname);
               AssignAttri("", false, "A24USUARIOEMPLEADO", A24USUARIOEMPLEADO);
               A25CONTRASENAEMPLEADO = cgiGet( edtCONTRASENAEMPLEADO_Internalname);
               AssignAttri("", false, "A25CONTRASENAEMPLEADO", A25CONTRASENAEMPLEADO);
               A26TELEFONOEMPLEADO = cgiGet( edtTELEFONOEMPLEADO_Internalname);
               AssignAttri("", false, "A26TELEFONOEMPLEADO", A26TELEFONOEMPLEADO);
               if ( context.localUtil.VCDate( cgiGet( edtFECHACONTRATACIONEMPLEADO_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FECHACONTRATACIONEMPLEADO"}), 1, "FECHACONTRATACIONEMPLEADO");
                  AnyError = 1;
                  GX_FocusControl = edtFECHACONTRATACIONEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
                  AssignAttri("", false, "A29FECHACONTRATACIONEMPLEADO", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
               }
               else
               {
                  A29FECHACONTRATACIONEMPLEADO = context.localUtil.CToD( cgiGet( edtFECHACONTRATACIONEMPLEADO_Internalname), 1);
                  AssignAttri("", false, "A29FECHACONTRATACIONEMPLEADO", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
               }
               A27CORREOEMPLEADO = cgiGet( edtCORREOEMPLEADO_Internalname);
               AssignAttri("", false, "A27CORREOEMPLEADO", A27CORREOEMPLEADO);
               A28DIRECCIONEMPLEADO = cgiGet( edtDIRECCIONEMPLEADO_Internalname);
               AssignAttri("", false, "A28DIRECCIONEMPLEADO", A28DIRECCIONEMPLEADO);
               A52FOTOEMPLEADO = cgiGet( imgFOTOEMPLEADO_Internalname);
               AssignAttri("", false, "A52FOTOEMPLEADO", A52FOTOEMPLEADO);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDTIPOEMPLEADO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDTIPOEMPLEADO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDTIPOEMPLEADO");
                  AnyError = 1;
                  GX_FocusControl = edtIDTIPOEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2IDTIPOEMPLEADO = 0;
                  AssignAttri("", false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
               }
               else
               {
                  A2IDTIPOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDTIPOEMPLEADO_Internalname), ".", ","));
                  AssignAttri("", false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
               }
               A21DESCRIPCIONTIPOEMPLEADO = cgiGet( edtDESCRIPCIONTIPOEMPLEADO_Internalname);
               AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDESTADOEMPLEADO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDESTADOEMPLEADO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDESTADOEMPLEADO");
                  AnyError = 1;
                  GX_FocusControl = edtIDESTADOEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3IDESTADOEMPLEADO = 0;
                  AssignAttri("", false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
               }
               else
               {
                  A3IDESTADOEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDESTADOEMPLEADO_Internalname), ".", ","));
                  AssignAttri("", false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
               }
               A22DESCRIPCIONESTADOEMPLEADO = cgiGet( edtDESCRIPCIONESTADOEMPLEADO_Internalname);
               AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgFOTOEMPLEADO_Internalname, ref  A52FOTOEMPLEADO, ref  A40000FOTOEMPLEADO_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Empleados");
               A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
               AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               forbiddenHiddens.Add("IDEMPLEADO", context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1IDEMPLEADO != Z1IDEMPLEADO ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("empleados:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1IDEMPLEADO = (long)(NumberUtil.Val( GetPar( "IDEMPLEADO"), "."));
                  AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDEMPLEADO");
                        AnyError = 1;
                        GX_FocusControl = edtIDEMPLEADO_Internalname;
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
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "TiendaRopaProyecto");
         AV11Insert_IDTIPOEMPLEADO = 0;
         AssignAttri("", false, "AV11Insert_IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV11Insert_IDTIPOEMPLEADO), 12, 0));
         AV12Insert_IDESTADOEMPLEADO = 0;
         AssignAttri("", false, "AV12Insert_IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV12Insert_IDESTADOEMPLEADO), 12, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "IDTIPOEMPLEADO") == 0 )
               {
                  AV11Insert_IDTIPOEMPLEADO = (long)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV11Insert_IDTIPOEMPLEADO), 12, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "IDESTADOEMPLEADO") == 0 )
               {
                  AV12Insert_IDESTADOEMPLEADO = (long)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(AV12Insert_IDESTADOEMPLEADO), 12, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwempleados.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z23NOMBRECOMPLETOEMPLEADO = T00013_A23NOMBRECOMPLETOEMPLEADO[0];
               Z24USUARIOEMPLEADO = T00013_A24USUARIOEMPLEADO[0];
               Z25CONTRASENAEMPLEADO = T00013_A25CONTRASENAEMPLEADO[0];
               Z26TELEFONOEMPLEADO = T00013_A26TELEFONOEMPLEADO[0];
               Z29FECHACONTRATACIONEMPLEADO = T00013_A29FECHACONTRATACIONEMPLEADO[0];
               Z27CORREOEMPLEADO = T00013_A27CORREOEMPLEADO[0];
               Z28DIRECCIONEMPLEADO = T00013_A28DIRECCIONEMPLEADO[0];
               Z2IDTIPOEMPLEADO = T00013_A2IDTIPOEMPLEADO[0];
               Z3IDESTADOEMPLEADO = T00013_A3IDESTADOEMPLEADO[0];
            }
            else
            {
               Z23NOMBRECOMPLETOEMPLEADO = A23NOMBRECOMPLETOEMPLEADO;
               Z24USUARIOEMPLEADO = A24USUARIOEMPLEADO;
               Z25CONTRASENAEMPLEADO = A25CONTRASENAEMPLEADO;
               Z26TELEFONOEMPLEADO = A26TELEFONOEMPLEADO;
               Z29FECHACONTRATACIONEMPLEADO = A29FECHACONTRATACIONEMPLEADO;
               Z27CORREOEMPLEADO = A27CORREOEMPLEADO;
               Z28DIRECCIONEMPLEADO = A28DIRECCIONEMPLEADO;
               Z2IDTIPOEMPLEADO = A2IDTIPOEMPLEADO;
               Z3IDESTADOEMPLEADO = A3IDESTADOEMPLEADO;
            }
         }
         if ( GX_JID == -21 )
         {
            Z1IDEMPLEADO = A1IDEMPLEADO;
            Z23NOMBRECOMPLETOEMPLEADO = A23NOMBRECOMPLETOEMPLEADO;
            Z24USUARIOEMPLEADO = A24USUARIOEMPLEADO;
            Z25CONTRASENAEMPLEADO = A25CONTRASENAEMPLEADO;
            Z26TELEFONOEMPLEADO = A26TELEFONOEMPLEADO;
            Z29FECHACONTRATACIONEMPLEADO = A29FECHACONTRATACIONEMPLEADO;
            Z27CORREOEMPLEADO = A27CORREOEMPLEADO;
            Z28DIRECCIONEMPLEADO = A28DIRECCIONEMPLEADO;
            Z52FOTOEMPLEADO = A52FOTOEMPLEADO;
            Z40000FOTOEMPLEADO_GXI = A40000FOTOEMPLEADO_GXI;
            Z2IDTIPOEMPLEADO = A2IDTIPOEMPLEADO;
            Z3IDESTADOEMPLEADO = A3IDESTADOEMPLEADO;
            Z21DESCRIPCIONTIPOEMPLEADO = A21DESCRIPCIONTIPOEMPLEADO;
            Z22DESCRIPCIONESTADOEMPLEADO = A22DESCRIPCIONESTADOEMPLEADO;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIDEMPLEADO_Enabled = 0;
         AssignProp("", false, edtIDEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDEMPLEADO_Enabled), 5, 0), true);
         imgprompt_2_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDTIPOEMPLEADO"+"'), id:'"+"IDTIPOEMPLEADO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_3_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDESTADOEMPLEADO"+"'), id:'"+"IDESTADOEMPLEADO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtIDEMPLEADO_Enabled = 0;
         AssignProp("", false, edtIDEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDEMPLEADO_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IDEMPLEADO) )
         {
            A1IDEMPLEADO = AV7IDEMPLEADO;
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDTIPOEMPLEADO) )
         {
            edtIDTIPOEMPLEADO_Enabled = 0;
            AssignProp("", false, edtIDTIPOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOEMPLEADO_Enabled), 5, 0), true);
         }
         else
         {
            edtIDTIPOEMPLEADO_Enabled = 1;
            AssignProp("", false, edtIDTIPOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOEMPLEADO_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_IDESTADOEMPLEADO) )
         {
            edtIDESTADOEMPLEADO_Enabled = 0;
            AssignProp("", false, edtIDESTADOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDESTADOEMPLEADO_Enabled), 5, 0), true);
         }
         else
         {
            edtIDESTADOEMPLEADO_Enabled = 1;
            AssignProp("", false, edtIDESTADOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDESTADOEMPLEADO_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_IDESTADOEMPLEADO) )
         {
            A3IDESTADOEMPLEADO = AV12Insert_IDESTADOEMPLEADO;
            AssignAttri("", false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDTIPOEMPLEADO) )
         {
            A2IDTIPOEMPLEADO = AV11Insert_IDTIPOEMPLEADO;
            AssignAttri("", false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV14Pgmname = "Empleados";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00015 */
            pr_default.execute(3, new Object[] {A3IDESTADOEMPLEADO});
            A22DESCRIPCIONESTADOEMPLEADO = T00015_A22DESCRIPCIONESTADOEMPLEADO[0];
            AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
            pr_default.close(3);
            /* Using cursor T00014 */
            pr_default.execute(2, new Object[] {A2IDTIPOEMPLEADO});
            A21DESCRIPCIONTIPOEMPLEADO = T00014_A21DESCRIPCIONTIPOEMPLEADO[0];
            AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
            pr_default.close(2);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
            A23NOMBRECOMPLETOEMPLEADO = T00016_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            A24USUARIOEMPLEADO = T00016_A24USUARIOEMPLEADO[0];
            AssignAttri("", false, "A24USUARIOEMPLEADO", A24USUARIOEMPLEADO);
            A25CONTRASENAEMPLEADO = T00016_A25CONTRASENAEMPLEADO[0];
            AssignAttri("", false, "A25CONTRASENAEMPLEADO", A25CONTRASENAEMPLEADO);
            A26TELEFONOEMPLEADO = T00016_A26TELEFONOEMPLEADO[0];
            AssignAttri("", false, "A26TELEFONOEMPLEADO", A26TELEFONOEMPLEADO);
            A29FECHACONTRATACIONEMPLEADO = T00016_A29FECHACONTRATACIONEMPLEADO[0];
            AssignAttri("", false, "A29FECHACONTRATACIONEMPLEADO", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
            A27CORREOEMPLEADO = T00016_A27CORREOEMPLEADO[0];
            AssignAttri("", false, "A27CORREOEMPLEADO", A27CORREOEMPLEADO);
            A28DIRECCIONEMPLEADO = T00016_A28DIRECCIONEMPLEADO[0];
            AssignAttri("", false, "A28DIRECCIONEMPLEADO", A28DIRECCIONEMPLEADO);
            A21DESCRIPCIONTIPOEMPLEADO = T00016_A21DESCRIPCIONTIPOEMPLEADO[0];
            AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
            A22DESCRIPCIONESTADOEMPLEADO = T00016_A22DESCRIPCIONESTADOEMPLEADO[0];
            AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
            A40000FOTOEMPLEADO_GXI = T00016_A40000FOTOEMPLEADO_GXI[0];
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
            A2IDTIPOEMPLEADO = T00016_A2IDTIPOEMPLEADO[0];
            AssignAttri("", false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
            A3IDESTADOEMPLEADO = T00016_A3IDESTADOEMPLEADO[0];
            AssignAttri("", false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
            A52FOTOEMPLEADO = T00016_A52FOTOEMPLEADO[0];
            AssignAttri("", false, "A52FOTOEMPLEADO", A52FOTOEMPLEADO);
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
            ZM011( -21) ;
         }
         pr_default.close(4);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV14Pgmname = "Empleados";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Empleados";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A23NOMBRECOMPLETOEMPLEADO)) )
         {
            GX_msglist.addItem("Ingrese el nombre completo del empleado", 1, "NOMBRECOMPLETOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A24USUARIOEMPLEADO)) )
         {
            GX_msglist.addItem("Ingrese el usuario del empleado", 1, "USUARIOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtUSUARIOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A25CONTRASENAEMPLEADO)) )
         {
            GX_msglist.addItem("Ingrese la contraseña del empleado", 1, "CONTRASENAEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtCONTRASENAEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A26TELEFONOEMPLEADO)) )
         {
            GX_msglist.addItem("Ingrese el telefono del empleado", 1, "TELEFONOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtTELEFONOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A29FECHACONTRATACIONEMPLEADO) || ( A29FECHACONTRATACIONEMPLEADO >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field FECHACONTRATACIONEMPLEADO is out of range", "OutOfRange", 1, "FECHACONTRATACIONEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtFECHACONTRATACIONEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A29FECHACONTRATACIONEMPLEADO) )
         {
            GX_msglist.addItem("Ingrese la fecha de contratacion del empleado", 1, "FECHACONTRATACIONEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtFECHACONTRATACIONEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A27CORREOEMPLEADO,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field CORREOEMPLEADO does not match the specified pattern", "OutOfRange", 1, "CORREOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtCORREOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A27CORREOEMPLEADO)) )
         {
            GX_msglist.addItem("Ingrese el correo del empleado", 1, "CORREOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtCORREOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A28DIRECCIONEMPLEADO)) )
         {
            GX_msglist.addItem("Ingrese la direccion del empleado", 1, "DIRECCIONEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtDIRECCIONEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) && String.IsNullOrEmpty(StringUtil.RTrim( A40000FOTOEMPLEADO_GXI)) )
         {
            GX_msglist.addItem("Ingrese la fotografia del empleado", 1, "FOTOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = imgFOTOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A2IDTIPOEMPLEADO});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo_empleado'.", "ForeignKeyNotFound", 1, "IDTIPOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDTIPOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21DESCRIPCIONTIPOEMPLEADO = T00014_A21DESCRIPCIONTIPOEMPLEADO[0];
         AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
         pr_default.close(2);
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A3IDESTADOEMPLEADO});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Estado_empleado'.", "ForeignKeyNotFound", 1, "IDESTADOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A22DESCRIPCIONESTADOEMPLEADO = T00015_A22DESCRIPCIONESTADOEMPLEADO[0];
         AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_22( long A2IDTIPOEMPLEADO )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A2IDTIPOEMPLEADO});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo_empleado'.", "ForeignKeyNotFound", 1, "IDTIPOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDTIPOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21DESCRIPCIONTIPOEMPLEADO = T00017_A21DESCRIPCIONTIPOEMPLEADO[0];
         AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A21DESCRIPCIONTIPOEMPLEADO)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_23( long A3IDESTADOEMPLEADO )
      {
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A3IDESTADOEMPLEADO});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Estado_empleado'.", "ForeignKeyNotFound", 1, "IDESTADOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A22DESCRIPCIONESTADOEMPLEADO = T00018_A22DESCRIPCIONESTADOEMPLEADO[0];
         AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A22DESCRIPCIONESTADOEMPLEADO)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey011( )
      {
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 21) ;
            RcdFound1 = 1;
            A1IDEMPLEADO = T00013_A1IDEMPLEADO[0];
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            A23NOMBRECOMPLETOEMPLEADO = T00013_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            A24USUARIOEMPLEADO = T00013_A24USUARIOEMPLEADO[0];
            AssignAttri("", false, "A24USUARIOEMPLEADO", A24USUARIOEMPLEADO);
            A25CONTRASENAEMPLEADO = T00013_A25CONTRASENAEMPLEADO[0];
            AssignAttri("", false, "A25CONTRASENAEMPLEADO", A25CONTRASENAEMPLEADO);
            A26TELEFONOEMPLEADO = T00013_A26TELEFONOEMPLEADO[0];
            AssignAttri("", false, "A26TELEFONOEMPLEADO", A26TELEFONOEMPLEADO);
            A29FECHACONTRATACIONEMPLEADO = T00013_A29FECHACONTRATACIONEMPLEADO[0];
            AssignAttri("", false, "A29FECHACONTRATACIONEMPLEADO", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
            A27CORREOEMPLEADO = T00013_A27CORREOEMPLEADO[0];
            AssignAttri("", false, "A27CORREOEMPLEADO", A27CORREOEMPLEADO);
            A28DIRECCIONEMPLEADO = T00013_A28DIRECCIONEMPLEADO[0];
            AssignAttri("", false, "A28DIRECCIONEMPLEADO", A28DIRECCIONEMPLEADO);
            A40000FOTOEMPLEADO_GXI = T00013_A40000FOTOEMPLEADO_GXI[0];
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
            A2IDTIPOEMPLEADO = T00013_A2IDTIPOEMPLEADO[0];
            AssignAttri("", false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
            A3IDESTADOEMPLEADO = T00013_A3IDESTADOEMPLEADO[0];
            AssignAttri("", false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
            A52FOTOEMPLEADO = T00013_A52FOTOEMPLEADO[0];
            AssignAttri("", false, "A52FOTOEMPLEADO", A52FOTOEMPLEADO);
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
            AssignProp("", false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
            Z1IDEMPLEADO = A1IDEMPLEADO;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T000110 */
         pr_default.execute(8, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000110_A1IDEMPLEADO[0] < A1IDEMPLEADO ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000110_A1IDEMPLEADO[0] > A1IDEMPLEADO ) ) )
            {
               A1IDEMPLEADO = T000110_A1IDEMPLEADO[0];
               AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T000111 */
         pr_default.execute(9, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000111_A1IDEMPLEADO[0] > A1IDEMPLEADO ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000111_A1IDEMPLEADO[0] < A1IDEMPLEADO ) ) )
            {
               A1IDEMPLEADO = T000111_A1IDEMPLEADO[0];
               AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1IDEMPLEADO != Z1IDEMPLEADO )
               {
                  A1IDEMPLEADO = Z1IDEMPLEADO;
                  AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDEMPLEADO");
                  AnyError = 1;
                  GX_FocusControl = edtIDEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1IDEMPLEADO != Z1IDEMPLEADO )
               {
                  /* Insert record */
                  GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDEMPLEADO");
                     AnyError = 1;
                     GX_FocusControl = edtIDEMPLEADO_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1IDEMPLEADO != Z1IDEMPLEADO )
         {
            A1IDEMPLEADO = Z1IDEMPLEADO;
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNOMBRECOMPLETOEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1IDEMPLEADO});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empleados"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z23NOMBRECOMPLETOEMPLEADO, T00012_A23NOMBRECOMPLETOEMPLEADO[0]) != 0 ) || ( StringUtil.StrCmp(Z24USUARIOEMPLEADO, T00012_A24USUARIOEMPLEADO[0]) != 0 ) || ( StringUtil.StrCmp(Z25CONTRASENAEMPLEADO, T00012_A25CONTRASENAEMPLEADO[0]) != 0 ) || ( StringUtil.StrCmp(Z26TELEFONOEMPLEADO, T00012_A26TELEFONOEMPLEADO[0]) != 0 ) || ( Z29FECHACONTRATACIONEMPLEADO != T00012_A29FECHACONTRATACIONEMPLEADO[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z27CORREOEMPLEADO, T00012_A27CORREOEMPLEADO[0]) != 0 ) || ( StringUtil.StrCmp(Z28DIRECCIONEMPLEADO, T00012_A28DIRECCIONEMPLEADO[0]) != 0 ) || ( Z2IDTIPOEMPLEADO != T00012_A2IDTIPOEMPLEADO[0] ) || ( Z3IDESTADOEMPLEADO != T00012_A3IDESTADOEMPLEADO[0] ) )
            {
               if ( StringUtil.StrCmp(Z23NOMBRECOMPLETOEMPLEADO, T00012_A23NOMBRECOMPLETOEMPLEADO[0]) != 0 )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"NOMBRECOMPLETOEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z23NOMBRECOMPLETOEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A23NOMBRECOMPLETOEMPLEADO[0]);
               }
               if ( StringUtil.StrCmp(Z24USUARIOEMPLEADO, T00012_A24USUARIOEMPLEADO[0]) != 0 )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"USUARIOEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z24USUARIOEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A24USUARIOEMPLEADO[0]);
               }
               if ( StringUtil.StrCmp(Z25CONTRASENAEMPLEADO, T00012_A25CONTRASENAEMPLEADO[0]) != 0 )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"CONTRASENAEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z25CONTRASENAEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A25CONTRASENAEMPLEADO[0]);
               }
               if ( StringUtil.StrCmp(Z26TELEFONOEMPLEADO, T00012_A26TELEFONOEMPLEADO[0]) != 0 )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"TELEFONOEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z26TELEFONOEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A26TELEFONOEMPLEADO[0]);
               }
               if ( Z29FECHACONTRATACIONEMPLEADO != T00012_A29FECHACONTRATACIONEMPLEADO[0] )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"FECHACONTRATACIONEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z29FECHACONTRATACIONEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A29FECHACONTRATACIONEMPLEADO[0]);
               }
               if ( StringUtil.StrCmp(Z27CORREOEMPLEADO, T00012_A27CORREOEMPLEADO[0]) != 0 )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"CORREOEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z27CORREOEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A27CORREOEMPLEADO[0]);
               }
               if ( StringUtil.StrCmp(Z28DIRECCIONEMPLEADO, T00012_A28DIRECCIONEMPLEADO[0]) != 0 )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"DIRECCIONEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z28DIRECCIONEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A28DIRECCIONEMPLEADO[0]);
               }
               if ( Z2IDTIPOEMPLEADO != T00012_A2IDTIPOEMPLEADO[0] )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"IDTIPOEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z2IDTIPOEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2IDTIPOEMPLEADO[0]);
               }
               if ( Z3IDESTADOEMPLEADO != T00012_A3IDESTADOEMPLEADO[0] )
               {
                  GXUtil.WriteLog("empleados:[seudo value changed for attri]"+"IDESTADOEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z3IDESTADOEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3IDESTADOEMPLEADO[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Empleados"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000112 */
                     pr_default.execute(10, new Object[] {A23NOMBRECOMPLETOEMPLEADO, A24USUARIOEMPLEADO, A25CONTRASENAEMPLEADO, A26TELEFONOEMPLEADO, A29FECHACONTRATACIONEMPLEADO, A27CORREOEMPLEADO, A28DIRECCIONEMPLEADO, A52FOTOEMPLEADO, A40000FOTOEMPLEADO_GXI, A2IDTIPOEMPLEADO, A3IDESTADOEMPLEADO});
                     A1IDEMPLEADO = T000112_A1IDEMPLEADO[0];
                     AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Empleados");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000113 */
                     pr_default.execute(11, new Object[] {A23NOMBRECOMPLETOEMPLEADO, A24USUARIOEMPLEADO, A25CONTRASENAEMPLEADO, A26TELEFONOEMPLEADO, A29FECHACONTRATACIONEMPLEADO, A27CORREOEMPLEADO, A28DIRECCIONEMPLEADO, A2IDTIPOEMPLEADO, A3IDESTADOEMPLEADO, A1IDEMPLEADO});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Empleados");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Empleados"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {A52FOTOEMPLEADO, A40000FOTOEMPLEADO_GXI, A1IDEMPLEADO});
            pr_default.close(12);
            dsDefault.SmartCacheProvider.SetUpdated("Empleados");
         }
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000115 */
                  pr_default.execute(13, new Object[] {A1IDEMPLEADO});
                  pr_default.close(13);
                  dsDefault.SmartCacheProvider.SetUpdated("Empleados");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Empleados";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000116 */
            pr_default.execute(14, new Object[] {A2IDTIPOEMPLEADO});
            A21DESCRIPCIONTIPOEMPLEADO = T000116_A21DESCRIPCIONTIPOEMPLEADO[0];
            AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
            pr_default.close(14);
            /* Using cursor T000117 */
            pr_default.execute(15, new Object[] {A3IDESTADOEMPLEADO});
            A22DESCRIPCIONESTADOEMPLEADO = T000117_A22DESCRIPCIONESTADOEMPLEADO[0];
            AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000118 */
            pr_default.execute(16, new Object[] {A1IDEMPLEADO});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ventas_inventario"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000119 */
            pr_default.execute(17, new Object[] {A1IDEMPLEADO});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compra_inventario"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.CommitDataStores("empleados",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(15);
            context.RollbackDataStores("empleados",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000120 */
         pr_default.execute(18);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound1 = 1;
            A1IDEMPLEADO = T000120_A1IDEMPLEADO[0];
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound1 = 1;
            A1IDEMPLEADO = T000120_A1IDEMPLEADO[0];
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtIDEMPLEADO_Enabled = 0;
         AssignProp("", false, edtIDEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDEMPLEADO_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOEMPLEADO_Enabled), 5, 0), true);
         edtUSUARIOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtUSUARIOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUSUARIOEMPLEADO_Enabled), 5, 0), true);
         edtCONTRASENAEMPLEADO_Enabled = 0;
         AssignProp("", false, edtCONTRASENAEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCONTRASENAEMPLEADO_Enabled), 5, 0), true);
         edtTELEFONOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtTELEFONOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTELEFONOEMPLEADO_Enabled), 5, 0), true);
         edtFECHACONTRATACIONEMPLEADO_Enabled = 0;
         AssignProp("", false, edtFECHACONTRATACIONEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHACONTRATACIONEMPLEADO_Enabled), 5, 0), true);
         edtCORREOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtCORREOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCORREOEMPLEADO_Enabled), 5, 0), true);
         edtDIRECCIONEMPLEADO_Enabled = 0;
         AssignProp("", false, edtDIRECCIONEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDIRECCIONEMPLEADO_Enabled), 5, 0), true);
         imgFOTOEMPLEADO_Enabled = 0;
         AssignProp("", false, imgFOTOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgFOTOEMPLEADO_Enabled), 5, 0), true);
         edtIDTIPOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtIDTIPOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDTIPOEMPLEADO_Enabled), 5, 0), true);
         edtDESCRIPCIONTIPOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONTIPOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONTIPOEMPLEADO_Enabled), 5, 0), true);
         edtIDESTADOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtIDESTADOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDESTADOEMPLEADO_Enabled), 5, 0), true);
         edtDESCRIPCIONESTADOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONESTADOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONESTADOEMPLEADO_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.AddJavascriptSource("gxcfg.js", "?202111280104746", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("empleados.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDEMPLEADO,12,0))}, new string[] {"Gx_mode","IDEMPLEADO"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Empleados");
         forbiddenHiddens.Add("IDEMPLEADO", context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("empleados:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1IDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23NOMBRECOMPLETOEMPLEADO", Z23NOMBRECOMPLETOEMPLEADO);
         GxWebStd.gx_hidden_field( context, "Z24USUARIOEMPLEADO", Z24USUARIOEMPLEADO);
         GxWebStd.gx_hidden_field( context, "Z25CONTRASENAEMPLEADO", Z25CONTRASENAEMPLEADO);
         GxWebStd.gx_hidden_field( context, "Z26TELEFONOEMPLEADO", StringUtil.RTrim( Z26TELEFONOEMPLEADO));
         GxWebStd.gx_hidden_field( context, "Z29FECHACONTRATACIONEMPLEADO", context.localUtil.DToC( Z29FECHACONTRATACIONEMPLEADO, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z27CORREOEMPLEADO", Z27CORREOEMPLEADO);
         GxWebStd.gx_hidden_field( context, "Z28DIRECCIONEMPLEADO", Z28DIRECCIONEMPLEADO);
         GxWebStd.gx_hidden_field( context, "Z2IDTIPOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2IDTIPOEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z3IDESTADOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3IDESTADOEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N2IDTIPOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2IDTIPOEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N3IDESTADOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3IDESTADOEMPLEADO), 12, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vIDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDEMPLEADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDEMPLEADO), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDTIPOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_IDTIPOEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDESTADOEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_IDESTADOEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FOTOEMPLEADO_GXI", A40000FOTOEMPLEADO_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "FOTOEMPLEADO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A52FOTOEMPLEADO);
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
         return formatLink("empleados.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDEMPLEADO,12,0))}, new string[] {"Gx_mode","IDEMPLEADO"})  ;
      }

      public override string GetPgmname( )
      {
         return "Empleados" ;
      }

      public override string GetPgmdesc( )
      {
         return "Empleados" ;
      }

      protected void InitializeNonKey011( )
      {
         A2IDTIPOEMPLEADO = 0;
         AssignAttri("", false, "A2IDTIPOEMPLEADO", StringUtil.LTrimStr( (decimal)(A2IDTIPOEMPLEADO), 12, 0));
         A3IDESTADOEMPLEADO = 0;
         AssignAttri("", false, "A3IDESTADOEMPLEADO", StringUtil.LTrimStr( (decimal)(A3IDESTADOEMPLEADO), 12, 0));
         A23NOMBRECOMPLETOEMPLEADO = "";
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
         A24USUARIOEMPLEADO = "";
         AssignAttri("", false, "A24USUARIOEMPLEADO", A24USUARIOEMPLEADO);
         A25CONTRASENAEMPLEADO = "";
         AssignAttri("", false, "A25CONTRASENAEMPLEADO", A25CONTRASENAEMPLEADO);
         A26TELEFONOEMPLEADO = "";
         AssignAttri("", false, "A26TELEFONOEMPLEADO", A26TELEFONOEMPLEADO);
         A29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         AssignAttri("", false, "A29FECHACONTRATACIONEMPLEADO", context.localUtil.Format(A29FECHACONTRATACIONEMPLEADO, "99/99/99"));
         A27CORREOEMPLEADO = "";
         AssignAttri("", false, "A27CORREOEMPLEADO", A27CORREOEMPLEADO);
         A28DIRECCIONEMPLEADO = "";
         AssignAttri("", false, "A28DIRECCIONEMPLEADO", A28DIRECCIONEMPLEADO);
         A52FOTOEMPLEADO = "";
         AssignAttri("", false, "A52FOTOEMPLEADO", A52FOTOEMPLEADO);
         AssignProp("", false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
         AssignProp("", false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
         A21DESCRIPCIONTIPOEMPLEADO = "";
         AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
         A22DESCRIPCIONESTADOEMPLEADO = "";
         AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
         A40000FOTOEMPLEADO_GXI = "";
         AssignProp("", false, imgFOTOEMPLEADO_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : context.convertURL( context.PathToRelativeUrl( A52FOTOEMPLEADO))), true);
         AssignProp("", false, imgFOTOEMPLEADO_Internalname, "SrcSet", context.GetImageSrcSet( A52FOTOEMPLEADO), true);
         Z23NOMBRECOMPLETOEMPLEADO = "";
         Z24USUARIOEMPLEADO = "";
         Z25CONTRASENAEMPLEADO = "";
         Z26TELEFONOEMPLEADO = "";
         Z29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         Z27CORREOEMPLEADO = "";
         Z28DIRECCIONEMPLEADO = "";
         Z2IDTIPOEMPLEADO = 0;
         Z3IDESTADOEMPLEADO = 0;
      }

      protected void InitAll011( )
      {
         A1IDEMPLEADO = 0;
         AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202111280104756", true, true);
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
         context.AddJavascriptSource("empleados.js", "?202111280104757", false, true);
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
         edtIDEMPLEADO_Internalname = "IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = "NOMBRECOMPLETOEMPLEADO";
         edtUSUARIOEMPLEADO_Internalname = "USUARIOEMPLEADO";
         edtCONTRASENAEMPLEADO_Internalname = "CONTRASENAEMPLEADO";
         edtTELEFONOEMPLEADO_Internalname = "TELEFONOEMPLEADO";
         edtFECHACONTRATACIONEMPLEADO_Internalname = "FECHACONTRATACIONEMPLEADO";
         edtCORREOEMPLEADO_Internalname = "CORREOEMPLEADO";
         edtDIRECCIONEMPLEADO_Internalname = "DIRECCIONEMPLEADO";
         imgFOTOEMPLEADO_Internalname = "FOTOEMPLEADO";
         edtIDTIPOEMPLEADO_Internalname = "IDTIPOEMPLEADO";
         edtDESCRIPCIONTIPOEMPLEADO_Internalname = "DESCRIPCIONTIPOEMPLEADO";
         edtIDESTADOEMPLEADO_Internalname = "IDESTADOEMPLEADO";
         edtDESCRIPCIONESTADOEMPLEADO_Internalname = "DESCRIPCIONESTADOEMPLEADO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_2_Internalname = "PROMPT_2";
         imgprompt_3_Internalname = "PROMPT_3";
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
         Form.Caption = "Empleados";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDESCRIPCIONESTADOEMPLEADO_Enabled = 0;
         imgprompt_3_Visible = 1;
         imgprompt_3_Link = "";
         edtIDESTADOEMPLEADO_Jsonclick = "";
         edtIDESTADOEMPLEADO_Enabled = 1;
         edtDESCRIPCIONTIPOEMPLEADO_Enabled = 0;
         imgprompt_2_Visible = 1;
         imgprompt_2_Link = "";
         edtIDTIPOEMPLEADO_Jsonclick = "";
         edtIDTIPOEMPLEADO_Enabled = 1;
         imgFOTOEMPLEADO_Enabled = 1;
         edtDIRECCIONEMPLEADO_Enabled = 1;
         edtCORREOEMPLEADO_Jsonclick = "";
         edtCORREOEMPLEADO_Enabled = 1;
         edtFECHACONTRATACIONEMPLEADO_Jsonclick = "";
         edtFECHACONTRATACIONEMPLEADO_Enabled = 1;
         edtTELEFONOEMPLEADO_Jsonclick = "";
         edtTELEFONOEMPLEADO_Enabled = 1;
         edtCONTRASENAEMPLEADO_Enabled = 1;
         edtUSUARIOEMPLEADO_Enabled = 1;
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 1;
         edtIDEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Enabled = 0;
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

      public void Valid_Idtipoempleado( )
      {
         /* Using cursor T000116 */
         pr_default.execute(14, new Object[] {A2IDTIPOEMPLEADO});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo_empleado'.", "ForeignKeyNotFound", 1, "IDTIPOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDTIPOEMPLEADO_Internalname;
         }
         A21DESCRIPCIONTIPOEMPLEADO = T000116_A21DESCRIPCIONTIPOEMPLEADO[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21DESCRIPCIONTIPOEMPLEADO", A21DESCRIPCIONTIPOEMPLEADO);
      }

      public void Valid_Idestadoempleado( )
      {
         /* Using cursor T000117 */
         pr_default.execute(15, new Object[] {A3IDESTADOEMPLEADO});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Estado_empleado'.", "ForeignKeyNotFound", 1, "IDESTADOEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOEMPLEADO_Internalname;
         }
         A22DESCRIPCIONESTADOEMPLEADO = T000117_A22DESCRIPCIONESTADOEMPLEADO[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A22DESCRIPCIONESTADOEMPLEADO", A22DESCRIPCIONESTADOEMPLEADO);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IDEMPLEADO',fld:'vIDEMPLEADO',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IDEMPLEADO',fld:'vIDEMPLEADO',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_IDEMPLEADO","{handler:'Valid_Idempleado',iparms:[]");
         setEventMetadata("VALID_IDEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_NOMBRECOMPLETOEMPLEADO","{handler:'Valid_Nombrecompletoempleado',iparms:[]");
         setEventMetadata("VALID_NOMBRECOMPLETOEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_USUARIOEMPLEADO","{handler:'Valid_Usuarioempleado',iparms:[]");
         setEventMetadata("VALID_USUARIOEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_CONTRASENAEMPLEADO","{handler:'Valid_Contrasenaempleado',iparms:[]");
         setEventMetadata("VALID_CONTRASENAEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_TELEFONOEMPLEADO","{handler:'Valid_Telefonoempleado',iparms:[]");
         setEventMetadata("VALID_TELEFONOEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_FECHACONTRATACIONEMPLEADO","{handler:'Valid_Fechacontratacionempleado',iparms:[]");
         setEventMetadata("VALID_FECHACONTRATACIONEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_CORREOEMPLEADO","{handler:'Valid_Correoempleado',iparms:[]");
         setEventMetadata("VALID_CORREOEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_DIRECCIONEMPLEADO","{handler:'Valid_Direccionempleado',iparms:[]");
         setEventMetadata("VALID_DIRECCIONEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_FOTOEMPLEADO","{handler:'Valid_Fotoempleado',iparms:[]");
         setEventMetadata("VALID_FOTOEMPLEADO",",oparms:[]}");
         setEventMetadata("VALID_IDTIPOEMPLEADO","{handler:'Valid_Idtipoempleado',iparms:[{av:'A2IDTIPOEMPLEADO',fld:'IDTIPOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A21DESCRIPCIONTIPOEMPLEADO',fld:'DESCRIPCIONTIPOEMPLEADO',pic:''}]");
         setEventMetadata("VALID_IDTIPOEMPLEADO",",oparms:[{av:'A21DESCRIPCIONTIPOEMPLEADO',fld:'DESCRIPCIONTIPOEMPLEADO',pic:''}]}");
         setEventMetadata("VALID_IDESTADOEMPLEADO","{handler:'Valid_Idestadoempleado',iparms:[{av:'A3IDESTADOEMPLEADO',fld:'IDESTADOEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A22DESCRIPCIONESTADOEMPLEADO',fld:'DESCRIPCIONESTADOEMPLEADO',pic:''}]");
         setEventMetadata("VALID_IDESTADOEMPLEADO",",oparms:[{av:'A22DESCRIPCIONESTADOEMPLEADO',fld:'DESCRIPCIONESTADOEMPLEADO',pic:''}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z23NOMBRECOMPLETOEMPLEADO = "";
         Z24USUARIOEMPLEADO = "";
         Z25CONTRASENAEMPLEADO = "";
         Z26TELEFONOEMPLEADO = "";
         Z29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         Z27CORREOEMPLEADO = "";
         Z28DIRECCIONEMPLEADO = "";
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
         A23NOMBRECOMPLETOEMPLEADO = "";
         A24USUARIOEMPLEADO = "";
         A25CONTRASENAEMPLEADO = "";
         gxphoneLink = "";
         A26TELEFONOEMPLEADO = "";
         A29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         A27CORREOEMPLEADO = "";
         A28DIRECCIONEMPLEADO = "";
         A52FOTOEMPLEADO = "";
         A40000FOTOEMPLEADO_GXI = "";
         sImgUrl = "";
         A21DESCRIPCIONTIPOEMPLEADO = "";
         A22DESCRIPCIONESTADOEMPLEADO = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z52FOTOEMPLEADO = "";
         Z40000FOTOEMPLEADO_GXI = "";
         Z21DESCRIPCIONTIPOEMPLEADO = "";
         Z22DESCRIPCIONESTADOEMPLEADO = "";
         T00015_A22DESCRIPCIONESTADOEMPLEADO = new string[] {""} ;
         T00014_A21DESCRIPCIONTIPOEMPLEADO = new string[] {""} ;
         T00016_A1IDEMPLEADO = new long[1] ;
         T00016_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T00016_A24USUARIOEMPLEADO = new string[] {""} ;
         T00016_A25CONTRASENAEMPLEADO = new string[] {""} ;
         T00016_A26TELEFONOEMPLEADO = new string[] {""} ;
         T00016_A29FECHACONTRATACIONEMPLEADO = new DateTime[] {DateTime.MinValue} ;
         T00016_A27CORREOEMPLEADO = new string[] {""} ;
         T00016_A28DIRECCIONEMPLEADO = new string[] {""} ;
         T00016_A21DESCRIPCIONTIPOEMPLEADO = new string[] {""} ;
         T00016_A22DESCRIPCIONESTADOEMPLEADO = new string[] {""} ;
         T00016_A40000FOTOEMPLEADO_GXI = new string[] {""} ;
         T00016_A2IDTIPOEMPLEADO = new long[1] ;
         T00016_A3IDESTADOEMPLEADO = new long[1] ;
         T00016_A52FOTOEMPLEADO = new string[] {""} ;
         T00017_A21DESCRIPCIONTIPOEMPLEADO = new string[] {""} ;
         T00018_A22DESCRIPCIONESTADOEMPLEADO = new string[] {""} ;
         T00019_A1IDEMPLEADO = new long[1] ;
         T00013_A1IDEMPLEADO = new long[1] ;
         T00013_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T00013_A24USUARIOEMPLEADO = new string[] {""} ;
         T00013_A25CONTRASENAEMPLEADO = new string[] {""} ;
         T00013_A26TELEFONOEMPLEADO = new string[] {""} ;
         T00013_A29FECHACONTRATACIONEMPLEADO = new DateTime[] {DateTime.MinValue} ;
         T00013_A27CORREOEMPLEADO = new string[] {""} ;
         T00013_A28DIRECCIONEMPLEADO = new string[] {""} ;
         T00013_A40000FOTOEMPLEADO_GXI = new string[] {""} ;
         T00013_A2IDTIPOEMPLEADO = new long[1] ;
         T00013_A3IDESTADOEMPLEADO = new long[1] ;
         T00013_A52FOTOEMPLEADO = new string[] {""} ;
         T000110_A1IDEMPLEADO = new long[1] ;
         T000111_A1IDEMPLEADO = new long[1] ;
         T00012_A1IDEMPLEADO = new long[1] ;
         T00012_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T00012_A24USUARIOEMPLEADO = new string[] {""} ;
         T00012_A25CONTRASENAEMPLEADO = new string[] {""} ;
         T00012_A26TELEFONOEMPLEADO = new string[] {""} ;
         T00012_A29FECHACONTRATACIONEMPLEADO = new DateTime[] {DateTime.MinValue} ;
         T00012_A27CORREOEMPLEADO = new string[] {""} ;
         T00012_A28DIRECCIONEMPLEADO = new string[] {""} ;
         T00012_A40000FOTOEMPLEADO_GXI = new string[] {""} ;
         T00012_A2IDTIPOEMPLEADO = new long[1] ;
         T00012_A3IDESTADOEMPLEADO = new long[1] ;
         T00012_A52FOTOEMPLEADO = new string[] {""} ;
         T000112_A1IDEMPLEADO = new long[1] ;
         T000116_A21DESCRIPCIONTIPOEMPLEADO = new string[] {""} ;
         T000117_A22DESCRIPCIONESTADOEMPLEADO = new string[] {""} ;
         T000118_A12IDVENTA = new long[1] ;
         T000119_A11IDCOMPRA = new long[1] ;
         T000120_A1IDEMPLEADO = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empleados__default(),
            new Object[][] {
                new Object[] {
               T00012_A1IDEMPLEADO, T00012_A23NOMBRECOMPLETOEMPLEADO, T00012_A24USUARIOEMPLEADO, T00012_A25CONTRASENAEMPLEADO, T00012_A26TELEFONOEMPLEADO, T00012_A29FECHACONTRATACIONEMPLEADO, T00012_A27CORREOEMPLEADO, T00012_A28DIRECCIONEMPLEADO, T00012_A40000FOTOEMPLEADO_GXI, T00012_A2IDTIPOEMPLEADO,
               T00012_A3IDESTADOEMPLEADO, T00012_A52FOTOEMPLEADO
               }
               , new Object[] {
               T00013_A1IDEMPLEADO, T00013_A23NOMBRECOMPLETOEMPLEADO, T00013_A24USUARIOEMPLEADO, T00013_A25CONTRASENAEMPLEADO, T00013_A26TELEFONOEMPLEADO, T00013_A29FECHACONTRATACIONEMPLEADO, T00013_A27CORREOEMPLEADO, T00013_A28DIRECCIONEMPLEADO, T00013_A40000FOTOEMPLEADO_GXI, T00013_A2IDTIPOEMPLEADO,
               T00013_A3IDESTADOEMPLEADO, T00013_A52FOTOEMPLEADO
               }
               , new Object[] {
               T00014_A21DESCRIPCIONTIPOEMPLEADO
               }
               , new Object[] {
               T00015_A22DESCRIPCIONESTADOEMPLEADO
               }
               , new Object[] {
               T00016_A1IDEMPLEADO, T00016_A23NOMBRECOMPLETOEMPLEADO, T00016_A24USUARIOEMPLEADO, T00016_A25CONTRASENAEMPLEADO, T00016_A26TELEFONOEMPLEADO, T00016_A29FECHACONTRATACIONEMPLEADO, T00016_A27CORREOEMPLEADO, T00016_A28DIRECCIONEMPLEADO, T00016_A21DESCRIPCIONTIPOEMPLEADO, T00016_A22DESCRIPCIONESTADOEMPLEADO,
               T00016_A40000FOTOEMPLEADO_GXI, T00016_A2IDTIPOEMPLEADO, T00016_A3IDESTADOEMPLEADO, T00016_A52FOTOEMPLEADO
               }
               , new Object[] {
               T00017_A21DESCRIPCIONTIPOEMPLEADO
               }
               , new Object[] {
               T00018_A22DESCRIPCIONESTADOEMPLEADO
               }
               , new Object[] {
               T00019_A1IDEMPLEADO
               }
               , new Object[] {
               T000110_A1IDEMPLEADO
               }
               , new Object[] {
               T000111_A1IDEMPLEADO
               }
               , new Object[] {
               T000112_A1IDEMPLEADO
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000116_A21DESCRIPCIONTIPOEMPLEADO
               }
               , new Object[] {
               T000117_A22DESCRIPCIONESTADOEMPLEADO
               }
               , new Object[] {
               T000118_A12IDVENTA
               }
               , new Object[] {
               T000119_A11IDCOMPRA
               }
               , new Object[] {
               T000120_A1IDEMPLEADO
               }
            }
         );
         AV14Pgmname = "Empleados";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_1 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIDEMPLEADO_Enabled ;
      private int edtNOMBRECOMPLETOEMPLEADO_Enabled ;
      private int edtUSUARIOEMPLEADO_Enabled ;
      private int edtCONTRASENAEMPLEADO_Enabled ;
      private int edtTELEFONOEMPLEADO_Enabled ;
      private int edtFECHACONTRATACIONEMPLEADO_Enabled ;
      private int edtCORREOEMPLEADO_Enabled ;
      private int edtDIRECCIONEMPLEADO_Enabled ;
      private int imgFOTOEMPLEADO_Enabled ;
      private int edtIDTIPOEMPLEADO_Enabled ;
      private int imgprompt_2_Visible ;
      private int edtDESCRIPCIONTIPOEMPLEADO_Enabled ;
      private int edtIDESTADOEMPLEADO_Enabled ;
      private int imgprompt_3_Visible ;
      private int edtDESCRIPCIONESTADOEMPLEADO_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV15GXV1 ;
      private int idxLst ;
      private long wcpOAV7IDEMPLEADO ;
      private long Z1IDEMPLEADO ;
      private long Z2IDTIPOEMPLEADO ;
      private long Z3IDESTADOEMPLEADO ;
      private long N2IDTIPOEMPLEADO ;
      private long N3IDESTADOEMPLEADO ;
      private long A2IDTIPOEMPLEADO ;
      private long A3IDESTADOEMPLEADO ;
      private long AV7IDEMPLEADO ;
      private long A1IDEMPLEADO ;
      private long AV11Insert_IDTIPOEMPLEADO ;
      private long AV12Insert_IDESTADOEMPLEADO ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z26TELEFONOEMPLEADO ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNOMBRECOMPLETOEMPLEADO_Internalname ;
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
      private string edtIDEMPLEADO_Internalname ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string edtUSUARIOEMPLEADO_Internalname ;
      private string edtCONTRASENAEMPLEADO_Internalname ;
      private string edtTELEFONOEMPLEADO_Internalname ;
      private string gxphoneLink ;
      private string A26TELEFONOEMPLEADO ;
      private string edtTELEFONOEMPLEADO_Jsonclick ;
      private string edtFECHACONTRATACIONEMPLEADO_Internalname ;
      private string edtFECHACONTRATACIONEMPLEADO_Jsonclick ;
      private string edtCORREOEMPLEADO_Internalname ;
      private string edtCORREOEMPLEADO_Jsonclick ;
      private string edtDIRECCIONEMPLEADO_Internalname ;
      private string imgFOTOEMPLEADO_Internalname ;
      private string sImgUrl ;
      private string edtIDTIPOEMPLEADO_Internalname ;
      private string edtIDTIPOEMPLEADO_Jsonclick ;
      private string imgprompt_2_Internalname ;
      private string imgprompt_2_Link ;
      private string edtDESCRIPCIONTIPOEMPLEADO_Internalname ;
      private string edtIDESTADOEMPLEADO_Internalname ;
      private string edtIDESTADOEMPLEADO_Jsonclick ;
      private string imgprompt_3_Internalname ;
      private string imgprompt_3_Link ;
      private string edtDESCRIPCIONESTADOEMPLEADO_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private DateTime Z29FECHACONTRATACIONEMPLEADO ;
      private DateTime A29FECHACONTRATACIONEMPLEADO ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A52FOTOEMPLEADO_IsBlob ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z23NOMBRECOMPLETOEMPLEADO ;
      private string Z24USUARIOEMPLEADO ;
      private string Z25CONTRASENAEMPLEADO ;
      private string Z27CORREOEMPLEADO ;
      private string Z28DIRECCIONEMPLEADO ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private string A24USUARIOEMPLEADO ;
      private string A25CONTRASENAEMPLEADO ;
      private string A27CORREOEMPLEADO ;
      private string A28DIRECCIONEMPLEADO ;
      private string A40000FOTOEMPLEADO_GXI ;
      private string A21DESCRIPCIONTIPOEMPLEADO ;
      private string A22DESCRIPCIONESTADOEMPLEADO ;
      private string Z40000FOTOEMPLEADO_GXI ;
      private string Z21DESCRIPCIONTIPOEMPLEADO ;
      private string Z22DESCRIPCIONESTADOEMPLEADO ;
      private string A52FOTOEMPLEADO ;
      private string Z52FOTOEMPLEADO ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00015_A22DESCRIPCIONESTADOEMPLEADO ;
      private string[] T00014_A21DESCRIPCIONTIPOEMPLEADO ;
      private long[] T00016_A1IDEMPLEADO ;
      private string[] T00016_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] T00016_A24USUARIOEMPLEADO ;
      private string[] T00016_A25CONTRASENAEMPLEADO ;
      private string[] T00016_A26TELEFONOEMPLEADO ;
      private DateTime[] T00016_A29FECHACONTRATACIONEMPLEADO ;
      private string[] T00016_A27CORREOEMPLEADO ;
      private string[] T00016_A28DIRECCIONEMPLEADO ;
      private string[] T00016_A21DESCRIPCIONTIPOEMPLEADO ;
      private string[] T00016_A22DESCRIPCIONESTADOEMPLEADO ;
      private string[] T00016_A40000FOTOEMPLEADO_GXI ;
      private long[] T00016_A2IDTIPOEMPLEADO ;
      private long[] T00016_A3IDESTADOEMPLEADO ;
      private string[] T00016_A52FOTOEMPLEADO ;
      private string[] T00017_A21DESCRIPCIONTIPOEMPLEADO ;
      private string[] T00018_A22DESCRIPCIONESTADOEMPLEADO ;
      private long[] T00019_A1IDEMPLEADO ;
      private long[] T00013_A1IDEMPLEADO ;
      private string[] T00013_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] T00013_A24USUARIOEMPLEADO ;
      private string[] T00013_A25CONTRASENAEMPLEADO ;
      private string[] T00013_A26TELEFONOEMPLEADO ;
      private DateTime[] T00013_A29FECHACONTRATACIONEMPLEADO ;
      private string[] T00013_A27CORREOEMPLEADO ;
      private string[] T00013_A28DIRECCIONEMPLEADO ;
      private string[] T00013_A40000FOTOEMPLEADO_GXI ;
      private long[] T00013_A2IDTIPOEMPLEADO ;
      private long[] T00013_A3IDESTADOEMPLEADO ;
      private string[] T00013_A52FOTOEMPLEADO ;
      private long[] T000110_A1IDEMPLEADO ;
      private long[] T000111_A1IDEMPLEADO ;
      private long[] T00012_A1IDEMPLEADO ;
      private string[] T00012_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] T00012_A24USUARIOEMPLEADO ;
      private string[] T00012_A25CONTRASENAEMPLEADO ;
      private string[] T00012_A26TELEFONOEMPLEADO ;
      private DateTime[] T00012_A29FECHACONTRATACIONEMPLEADO ;
      private string[] T00012_A27CORREOEMPLEADO ;
      private string[] T00012_A28DIRECCIONEMPLEADO ;
      private string[] T00012_A40000FOTOEMPLEADO_GXI ;
      private long[] T00012_A2IDTIPOEMPLEADO ;
      private long[] T00012_A3IDESTADOEMPLEADO ;
      private string[] T00012_A52FOTOEMPLEADO ;
      private long[] T000112_A1IDEMPLEADO ;
      private string[] T000116_A21DESCRIPCIONTIPOEMPLEADO ;
      private string[] T000117_A22DESCRIPCIONESTADOEMPLEADO ;
      private long[] T000118_A12IDVENTA ;
      private long[] T000119_A11IDCOMPRA ;
      private long[] T000120_A1IDEMPLEADO ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class empleados__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@IDTIPOEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@IDESTADOEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@IDTIPOEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@IDESTADOEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@NOMBRECOMPLETOEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@USUARIOEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@CONTRASENAEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@TELEFONOEMPLEADO",GXType.NChar,20,0) ,
          new ParDef("@FECHACONTRATACIONEMPLEADO",GXType.Date,8,0) ,
          new ParDef("@CORREOEMPLEADO",GXType.NVarChar,100,0) ,
          new ParDef("@DIRECCIONEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@FOTOEMPLEADO",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FOTOEMPLEADO_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=7, Tbl="Empleados", Fld="FOTOEMPLEADO"} ,
          new ParDef("@IDTIPOEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@IDESTADOEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@NOMBRECOMPLETOEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@USUARIOEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@CONTRASENAEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@TELEFONOEMPLEADO",GXType.NChar,20,0) ,
          new ParDef("@FECHACONTRATACIONEMPLEADO",GXType.Date,8,0) ,
          new ParDef("@CORREOEMPLEADO",GXType.NVarChar,100,0) ,
          new ParDef("@DIRECCIONEMPLEADO",GXType.NVarChar,255,0) ,
          new ParDef("@IDTIPOEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@IDESTADOEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@FOTOEMPLEADO",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FOTOEMPLEADO_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Empleados", Fld="FOTOEMPLEADO"} ,
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000118;
          prmT000118 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000119;
          prmT000119 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000120;
          prmT000120 = new Object[] {
          };
          Object[] prmT000116;
          prmT000116 = new Object[] {
          new ParDef("@IDTIPOEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000117;
          prmT000117 = new Object[] {
          new ParDef("@IDESTADOEMPLEADO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [IDEMPLEADO], [NOMBRECOMPLETOEMPLEADO], [USUARIOEMPLEADO], [CONTRASENAEMPLEADO], [TELEFONOEMPLEADO], [FECHACONTRATACIONEMPLEADO], [CORREOEMPLEADO], [DIRECCIONEMPLEADO], [FOTOEMPLEADO_GXI], [IDTIPOEMPLEADO], [IDESTADOEMPLEADO], [FOTOEMPLEADO] FROM [Empleados] WITH (UPDLOCK) WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [IDEMPLEADO], [NOMBRECOMPLETOEMPLEADO], [USUARIOEMPLEADO], [CONTRASENAEMPLEADO], [TELEFONOEMPLEADO], [FECHACONTRATACIONEMPLEADO], [CORREOEMPLEADO], [DIRECCIONEMPLEADO], [FOTOEMPLEADO_GXI], [IDTIPOEMPLEADO], [IDESTADOEMPLEADO], [FOTOEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [DESCRIPCIONTIPOEMPLEADO] FROM [Tipo_empleado] WHERE [IDTIPOEMPLEADO] = @IDTIPOEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [DESCRIPCIONESTADOEMPLEADO] FROM [Estado_empleado] WHERE [IDESTADOEMPLEADO] = @IDESTADOEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TM1.[IDEMPLEADO], TM1.[NOMBRECOMPLETOEMPLEADO], TM1.[USUARIOEMPLEADO], TM1.[CONTRASENAEMPLEADO], TM1.[TELEFONOEMPLEADO], TM1.[FECHACONTRATACIONEMPLEADO], TM1.[CORREOEMPLEADO], TM1.[DIRECCIONEMPLEADO], T2.[DESCRIPCIONTIPOEMPLEADO], T3.[DESCRIPCIONESTADOEMPLEADO], TM1.[FOTOEMPLEADO_GXI], TM1.[IDTIPOEMPLEADO], TM1.[IDESTADOEMPLEADO], TM1.[FOTOEMPLEADO] FROM (([Empleados] TM1 INNER JOIN [Tipo_empleado] T2 ON T2.[IDTIPOEMPLEADO] = TM1.[IDTIPOEMPLEADO]) INNER JOIN [Estado_empleado] T3 ON T3.[IDESTADOEMPLEADO] = TM1.[IDESTADOEMPLEADO]) WHERE TM1.[IDEMPLEADO] = @IDEMPLEADO ORDER BY TM1.[IDEMPLEADO]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [DESCRIPCIONTIPOEMPLEADO] FROM [Tipo_empleado] WHERE [IDTIPOEMPLEADO] = @IDTIPOEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT [DESCRIPCIONESTADOEMPLEADO] FROM [Estado_empleado] WHERE [IDESTADOEMPLEADO] = @IDESTADOEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00019", "SELECT [IDEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000110", "SELECT TOP 1 [IDEMPLEADO] FROM [Empleados] WHERE ( [IDEMPLEADO] > @IDEMPLEADO) ORDER BY [IDEMPLEADO]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000111", "SELECT TOP 1 [IDEMPLEADO] FROM [Empleados] WHERE ( [IDEMPLEADO] < @IDEMPLEADO) ORDER BY [IDEMPLEADO] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000112", "INSERT INTO [Empleados]([NOMBRECOMPLETOEMPLEADO], [USUARIOEMPLEADO], [CONTRASENAEMPLEADO], [TELEFONOEMPLEADO], [FECHACONTRATACIONEMPLEADO], [CORREOEMPLEADO], [DIRECCIONEMPLEADO], [FOTOEMPLEADO], [FOTOEMPLEADO_GXI], [IDTIPOEMPLEADO], [IDESTADOEMPLEADO]) VALUES(@NOMBRECOMPLETOEMPLEADO, @USUARIOEMPLEADO, @CONTRASENAEMPLEADO, @TELEFONOEMPLEADO, @FECHACONTRATACIONEMPLEADO, @CORREOEMPLEADO, @DIRECCIONEMPLEADO, @FOTOEMPLEADO, @FOTOEMPLEADO_GXI, @IDTIPOEMPLEADO, @IDESTADOEMPLEADO); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000112)
             ,new CursorDef("T000113", "UPDATE [Empleados] SET [NOMBRECOMPLETOEMPLEADO]=@NOMBRECOMPLETOEMPLEADO, [USUARIOEMPLEADO]=@USUARIOEMPLEADO, [CONTRASENAEMPLEADO]=@CONTRASENAEMPLEADO, [TELEFONOEMPLEADO]=@TELEFONOEMPLEADO, [FECHACONTRATACIONEMPLEADO]=@FECHACONTRATACIONEMPLEADO, [CORREOEMPLEADO]=@CORREOEMPLEADO, [DIRECCIONEMPLEADO]=@DIRECCIONEMPLEADO, [IDTIPOEMPLEADO]=@IDTIPOEMPLEADO, [IDESTADOEMPLEADO]=@IDESTADOEMPLEADO  WHERE [IDEMPLEADO] = @IDEMPLEADO", GxErrorMask.GX_NOMASK,prmT000113)
             ,new CursorDef("T000114", "UPDATE [Empleados] SET [FOTOEMPLEADO]=@FOTOEMPLEADO, [FOTOEMPLEADO_GXI]=@FOTOEMPLEADO_GXI  WHERE [IDEMPLEADO] = @IDEMPLEADO", GxErrorMask.GX_NOMASK,prmT000114)
             ,new CursorDef("T000115", "DELETE FROM [Empleados]  WHERE [IDEMPLEADO] = @IDEMPLEADO", GxErrorMask.GX_NOMASK,prmT000115)
             ,new CursorDef("T000116", "SELECT [DESCRIPCIONTIPOEMPLEADO] FROM [Tipo_empleado] WHERE [IDTIPOEMPLEADO] = @IDTIPOEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000117", "SELECT [DESCRIPCIONESTADOEMPLEADO] FROM [Estado_empleado] WHERE [IDESTADOEMPLEADO] = @IDESTADOEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000118", "SELECT TOP 1 [IDVENTA] FROM [Ventas_inventario] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000118,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000119", "SELECT TOP 1 [IDCOMPRA] FROM [Compra_inventario] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000120", "SELECT [IDEMPLEADO] FROM [Empleados] ORDER BY [IDEMPLEADO]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000120,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(9));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(9));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaUri(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((long[]) buf[12])[0] = rslt.getLong(13);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(11));
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 17 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 18 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
