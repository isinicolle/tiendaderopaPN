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
   public class clientes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
               AV7IDCLIENTE = (long)(NumberUtil.Val( GetPar( "IDCLIENTE"), "."));
               AssignAttri("", false, "AV7IDCLIENTE", StringUtil.LTrimStr( (decimal)(AV7IDCLIENTE), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDCLIENTE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDCLIENTE), "ZZZZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Clientes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public clientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IDCLIENTE )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IDCLIENTE = aP1_IDCLIENTE;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Clientes", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Clientes.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDCLIENTE_Internalname, "IDCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIDCLIENTE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")), ((edtIDCLIENTE_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCLIENTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDCLIENTE_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNOMBRECOMPLETOCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNOMBRECOMPLETOCLIENTE_Internalname, "NOMBRECOMPLETOCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOCLIENTE_Internalname, A30NOMBRECOMPLETOCLIENTE, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtNOMBRECOMPLETOCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUSUARIOCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUSUARIOCLIENTE_Internalname, "USUARIOCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUSUARIOCLIENTE_Internalname, A31USUARIOCLIENTE, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtUSUARIOCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCONTRASENACLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCONTRASENACLIENTE_Internalname, "CONTRASENACLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCONTRASENACLIENTE_Internalname, A32CONTRASENACLIENTE, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtCONTRASENACLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTELEFONOCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTELEFONOCLIENTE_Internalname, "TELEFONOCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A33TELEFONOCLIENTE);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTELEFONOCLIENTE_Internalname, StringUtil.RTrim( A33TELEFONOCLIENTE), StringUtil.RTrim( context.localUtil.Format( A33TELEFONOCLIENTE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtTELEFONOCLIENTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTELEFONOCLIENTE_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCORREOCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCORREOCLIENTE_Internalname, "CORREOCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCORREOCLIENTE_Internalname, A34CORREOCLIENTE, StringUtil.RTrim( context.localUtil.Format( A34CORREOCLIENTE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A34CORREOCLIENTE, "", "", "", edtCORREOCLIENTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCORREOCLIENTE_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHANACIMIENTOCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFECHANACIMIENTOCLIENTE_Internalname, "FECHANACIMIENTOCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFECHANACIMIENTOCLIENTE_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFECHANACIMIENTOCLIENTE_Internalname, context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"), context.localUtil.Format( A35FECHANACIMIENTOCLIENTE, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHANACIMIENTOCLIENTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFECHANACIMIENTOCLIENTE_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Clientes.htm");
         GxWebStd.gx_bitmap( context, edtFECHANACIMIENTOCLIENTE_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHANACIMIENTOCLIENTE_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDIRECCIONCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDIRECCIONCLIENTE_Internalname, "DIRECCIONCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDIRECCIONCLIENTE_Internalname, A36DIRECCIONCLIENTE, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtDIRECCIONCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Direccion", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHAREGISTROCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFECHAREGISTROCLIENTE_Internalname, "FECHAREGISTROCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtFECHAREGISTROCLIENTE_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFECHAREGISTROCLIENTE_Internalname, context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"), context.localUtil.Format( A37FECHAREGISTROCLIENTE, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHAREGISTROCLIENTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFECHAREGISTROCLIENTE_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Clientes.htm");
         GxWebStd.gx_bitmap( context, edtFECHAREGISTROCLIENTE_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHAREGISTROCLIENTE_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Clientes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgFOTOCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "FOTOCLIENTE", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A53FOTOCLIENTE_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FOTOCLIENTE_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.PathToRelativeUrl( A53FOTOCLIENTE));
         GxWebStd.gx_bitmap( context, imgFOTOCLIENTE_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgFOTOCLIENTE_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", "", "", 0, A53FOTOCLIENTE_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Clientes.htm");
         AssignProp("", false, imgFOTOCLIENTE_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.PathToRelativeUrl( A53FOTOCLIENTE)), true);
         AssignProp("", false, imgFOTOCLIENTE_Internalname, "IsBlob", StringUtil.BoolToStr( A53FOTOCLIENTE_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Clientes.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( "Z4IDCLIENTE"), ".", ","));
               Z30NOMBRECOMPLETOCLIENTE = cgiGet( "Z30NOMBRECOMPLETOCLIENTE");
               Z31USUARIOCLIENTE = cgiGet( "Z31USUARIOCLIENTE");
               Z32CONTRASENACLIENTE = cgiGet( "Z32CONTRASENACLIENTE");
               Z33TELEFONOCLIENTE = cgiGet( "Z33TELEFONOCLIENTE");
               Z34CORREOCLIENTE = cgiGet( "Z34CORREOCLIENTE");
               Z35FECHANACIMIENTOCLIENTE = context.localUtil.CToD( cgiGet( "Z35FECHANACIMIENTOCLIENTE"), 0);
               Z36DIRECCIONCLIENTE = cgiGet( "Z36DIRECCIONCLIENTE");
               Z37FECHAREGISTROCLIENTE = context.localUtil.CToD( cgiGet( "Z37FECHAREGISTROCLIENTE"), 0);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( "vIDCLIENTE"), ".", ","));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A40000FOTOCLIENTE_GXI = cgiGet( "FOTOCLIENTE_GXI");
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ","));
               AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
               A30NOMBRECOMPLETOCLIENTE = cgiGet( edtNOMBRECOMPLETOCLIENTE_Internalname);
               AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
               A31USUARIOCLIENTE = cgiGet( edtUSUARIOCLIENTE_Internalname);
               AssignAttri("", false, "A31USUARIOCLIENTE", A31USUARIOCLIENTE);
               A32CONTRASENACLIENTE = cgiGet( edtCONTRASENACLIENTE_Internalname);
               AssignAttri("", false, "A32CONTRASENACLIENTE", A32CONTRASENACLIENTE);
               A33TELEFONOCLIENTE = cgiGet( edtTELEFONOCLIENTE_Internalname);
               AssignAttri("", false, "A33TELEFONOCLIENTE", A33TELEFONOCLIENTE);
               A34CORREOCLIENTE = cgiGet( edtCORREOCLIENTE_Internalname);
               AssignAttri("", false, "A34CORREOCLIENTE", A34CORREOCLIENTE);
               if ( context.localUtil.VCDate( cgiGet( edtFECHANACIMIENTOCLIENTE_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"FECHANACIMIENTOCLIENTE"}), 1, "FECHANACIMIENTOCLIENTE");
                  AnyError = 1;
                  GX_FocusControl = edtFECHANACIMIENTOCLIENTE_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A35FECHANACIMIENTOCLIENTE = DateTime.MinValue;
                  AssignAttri("", false, "A35FECHANACIMIENTOCLIENTE", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
               }
               else
               {
                  A35FECHANACIMIENTOCLIENTE = context.localUtil.CToD( cgiGet( edtFECHANACIMIENTOCLIENTE_Internalname), 1);
                  AssignAttri("", false, "A35FECHANACIMIENTOCLIENTE", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
               }
               A36DIRECCIONCLIENTE = cgiGet( edtDIRECCIONCLIENTE_Internalname);
               AssignAttri("", false, "A36DIRECCIONCLIENTE", A36DIRECCIONCLIENTE);
               A37FECHAREGISTROCLIENTE = context.localUtil.CToD( cgiGet( edtFECHAREGISTROCLIENTE_Internalname), 1);
               AssignAttri("", false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
               A53FOTOCLIENTE = cgiGet( imgFOTOCLIENTE_Internalname);
               AssignAttri("", false, "A53FOTOCLIENTE", A53FOTOCLIENTE);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgFOTOCLIENTE_Internalname, ref  A53FOTOCLIENTE, ref  A40000FOTOCLIENTE_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Clientes");
               A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ","));
               AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
               forbiddenHiddens.Add("IDCLIENTE", context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A37FECHAREGISTROCLIENTE = context.localUtil.CToD( cgiGet( edtFECHAREGISTROCLIENTE_Internalname), 1);
               AssignAttri("", false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
               forbiddenHiddens.Add("FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A4IDCLIENTE != Z4IDCLIENTE ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("clientes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A4IDCLIENTE = (long)(NumberUtil.Val( GetPar( "IDCLIENTE"), "."));
                  AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
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
                     sMode8 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode8;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDCLIENTE");
                        AnyError = 1;
                        GX_FocusControl = edtIDCLIENTE_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll068( ) ;
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
            DisableAttributes068( ) ;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls068( ) ;
            }
            else
            {
               CheckExtendedTable068( ) ;
               CloseExtendedTableCursors068( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "TiendaRopaProyecto");
      }

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwclientes.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM068( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z30NOMBRECOMPLETOCLIENTE = T00063_A30NOMBRECOMPLETOCLIENTE[0];
               Z31USUARIOCLIENTE = T00063_A31USUARIOCLIENTE[0];
               Z32CONTRASENACLIENTE = T00063_A32CONTRASENACLIENTE[0];
               Z33TELEFONOCLIENTE = T00063_A33TELEFONOCLIENTE[0];
               Z34CORREOCLIENTE = T00063_A34CORREOCLIENTE[0];
               Z35FECHANACIMIENTOCLIENTE = T00063_A35FECHANACIMIENTOCLIENTE[0];
               Z36DIRECCIONCLIENTE = T00063_A36DIRECCIONCLIENTE[0];
               Z37FECHAREGISTROCLIENTE = T00063_A37FECHAREGISTROCLIENTE[0];
            }
            else
            {
               Z30NOMBRECOMPLETOCLIENTE = A30NOMBRECOMPLETOCLIENTE;
               Z31USUARIOCLIENTE = A31USUARIOCLIENTE;
               Z32CONTRASENACLIENTE = A32CONTRASENACLIENTE;
               Z33TELEFONOCLIENTE = A33TELEFONOCLIENTE;
               Z34CORREOCLIENTE = A34CORREOCLIENTE;
               Z35FECHANACIMIENTOCLIENTE = A35FECHANACIMIENTOCLIENTE;
               Z36DIRECCIONCLIENTE = A36DIRECCIONCLIENTE;
               Z37FECHAREGISTROCLIENTE = A37FECHAREGISTROCLIENTE;
            }
         }
         if ( GX_JID == -15 )
         {
            Z4IDCLIENTE = A4IDCLIENTE;
            Z30NOMBRECOMPLETOCLIENTE = A30NOMBRECOMPLETOCLIENTE;
            Z31USUARIOCLIENTE = A31USUARIOCLIENTE;
            Z32CONTRASENACLIENTE = A32CONTRASENACLIENTE;
            Z33TELEFONOCLIENTE = A33TELEFONOCLIENTE;
            Z34CORREOCLIENTE = A34CORREOCLIENTE;
            Z35FECHANACIMIENTOCLIENTE = A35FECHANACIMIENTOCLIENTE;
            Z36DIRECCIONCLIENTE = A36DIRECCIONCLIENTE;
            Z37FECHAREGISTROCLIENTE = A37FECHAREGISTROCLIENTE;
            Z53FOTOCLIENTE = A53FOTOCLIENTE;
            Z40000FOTOCLIENTE_GXI = A40000FOTOCLIENTE_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIDCLIENTE_Enabled = 0;
         AssignProp("", false, edtIDCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCLIENTE_Enabled), 5, 0), true);
         edtFECHAREGISTROCLIENTE_Enabled = 0;
         AssignProp("", false, edtFECHAREGISTROCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHAREGISTROCLIENTE_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtIDCLIENTE_Enabled = 0;
         AssignProp("", false, edtIDCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCLIENTE_Enabled), 5, 0), true);
         edtFECHAREGISTROCLIENTE_Enabled = 0;
         AssignProp("", false, edtFECHAREGISTROCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHAREGISTROCLIENTE_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IDCLIENTE) )
         {
            A4IDCLIENTE = AV7IDCLIENTE;
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A37FECHAREGISTROCLIENTE) && ( Gx_BScreen == 0 ) )
         {
            A37FECHAREGISTROCLIENTE = Gx_date;
            AssignAttri("", false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
         }
      }

      protected void Load068( )
      {
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A30NOMBRECOMPLETOCLIENTE = T00064_A30NOMBRECOMPLETOCLIENTE[0];
            AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
            A31USUARIOCLIENTE = T00064_A31USUARIOCLIENTE[0];
            AssignAttri("", false, "A31USUARIOCLIENTE", A31USUARIOCLIENTE);
            A32CONTRASENACLIENTE = T00064_A32CONTRASENACLIENTE[0];
            AssignAttri("", false, "A32CONTRASENACLIENTE", A32CONTRASENACLIENTE);
            A33TELEFONOCLIENTE = T00064_A33TELEFONOCLIENTE[0];
            AssignAttri("", false, "A33TELEFONOCLIENTE", A33TELEFONOCLIENTE);
            A34CORREOCLIENTE = T00064_A34CORREOCLIENTE[0];
            AssignAttri("", false, "A34CORREOCLIENTE", A34CORREOCLIENTE);
            A35FECHANACIMIENTOCLIENTE = T00064_A35FECHANACIMIENTOCLIENTE[0];
            AssignAttri("", false, "A35FECHANACIMIENTOCLIENTE", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
            A36DIRECCIONCLIENTE = T00064_A36DIRECCIONCLIENTE[0];
            AssignAttri("", false, "A36DIRECCIONCLIENTE", A36DIRECCIONCLIENTE);
            A37FECHAREGISTROCLIENTE = T00064_A37FECHAREGISTROCLIENTE[0];
            AssignAttri("", false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
            A40000FOTOCLIENTE_GXI = T00064_A40000FOTOCLIENTE_GXI[0];
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
            A53FOTOCLIENTE = T00064_A53FOTOCLIENTE[0];
            AssignAttri("", false, "A53FOTOCLIENTE", A53FOTOCLIENTE);
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
            ZM068( -15) ;
         }
         pr_default.close(2);
         OnLoadActions068( ) ;
      }

      protected void OnLoadActions068( )
      {
         AV13Pgmname = "Clientes";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable068( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV13Pgmname = "Clientes";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A30NOMBRECOMPLETOCLIENTE)) )
         {
            GX_msglist.addItem("Ingrese el nombre completo del cliente", 1, "NOMBRECOMPLETOCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A31USUARIOCLIENTE)) )
         {
            GX_msglist.addItem("Ingrese el usuario del cliente", 1, "USUARIOCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtUSUARIOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A32CONTRASENACLIENTE)) )
         {
            GX_msglist.addItem("Ingrese la contraseña del cliente", 1, "CONTRASENACLIENTE");
            AnyError = 1;
            GX_FocusControl = edtCONTRASENACLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A33TELEFONOCLIENTE)) )
         {
            GX_msglist.addItem("Ingrese el numero de telefono del cliente", 1, "TELEFONOCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtTELEFONOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A34CORREOCLIENTE,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field CORREOCLIENTE does not match the specified pattern", "OutOfRange", 1, "CORREOCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtCORREOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A34CORREOCLIENTE)) )
         {
            GX_msglist.addItem("Ingrese el correo del cliente", 1, "CORREOCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtCORREOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A35FECHANACIMIENTOCLIENTE) || ( A35FECHANACIMIENTOCLIENTE >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field FECHANACIMIENTOCLIENTE is out of range", "OutOfRange", 1, "FECHANACIMIENTOCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtFECHANACIMIENTOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A35FECHANACIMIENTOCLIENTE) )
         {
            GX_msglist.addItem("Ingrese la fecha de nacimiento del cliente", 1, "FECHANACIMIENTOCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtFECHANACIMIENTOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A36DIRECCIONCLIENTE)) )
         {
            GX_msglist.addItem("Ingrese la direccion del cliente", 1, "DIRECCIONCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtDIRECCIONCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) && String.IsNullOrEmpty(StringUtil.RTrim( A40000FOTOCLIENTE_GXI)) )
         {
            GX_msglist.addItem("La foto del cliente es opcional", 0, "FOTOCLIENTE");
         }
      }

      protected void CloseExtendedTableCursors068( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey068( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM068( 15) ;
            RcdFound8 = 1;
            A4IDCLIENTE = T00063_A4IDCLIENTE[0];
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
            A30NOMBRECOMPLETOCLIENTE = T00063_A30NOMBRECOMPLETOCLIENTE[0];
            AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
            A31USUARIOCLIENTE = T00063_A31USUARIOCLIENTE[0];
            AssignAttri("", false, "A31USUARIOCLIENTE", A31USUARIOCLIENTE);
            A32CONTRASENACLIENTE = T00063_A32CONTRASENACLIENTE[0];
            AssignAttri("", false, "A32CONTRASENACLIENTE", A32CONTRASENACLIENTE);
            A33TELEFONOCLIENTE = T00063_A33TELEFONOCLIENTE[0];
            AssignAttri("", false, "A33TELEFONOCLIENTE", A33TELEFONOCLIENTE);
            A34CORREOCLIENTE = T00063_A34CORREOCLIENTE[0];
            AssignAttri("", false, "A34CORREOCLIENTE", A34CORREOCLIENTE);
            A35FECHANACIMIENTOCLIENTE = T00063_A35FECHANACIMIENTOCLIENTE[0];
            AssignAttri("", false, "A35FECHANACIMIENTOCLIENTE", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
            A36DIRECCIONCLIENTE = T00063_A36DIRECCIONCLIENTE[0];
            AssignAttri("", false, "A36DIRECCIONCLIENTE", A36DIRECCIONCLIENTE);
            A37FECHAREGISTROCLIENTE = T00063_A37FECHAREGISTROCLIENTE[0];
            AssignAttri("", false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
            A40000FOTOCLIENTE_GXI = T00063_A40000FOTOCLIENTE_GXI[0];
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
            A53FOTOCLIENTE = T00063_A53FOTOCLIENTE[0];
            AssignAttri("", false, "A53FOTOCLIENTE", A53FOTOCLIENTE);
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
            AssignProp("", false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
            Z4IDCLIENTE = A4IDCLIENTE;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load068( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey068( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey068( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey068( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00066_A4IDCLIENTE[0] < A4IDCLIENTE ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00066_A4IDCLIENTE[0] > A4IDCLIENTE ) ) )
            {
               A4IDCLIENTE = T00066_A4IDCLIENTE[0];
               AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00067_A4IDCLIENTE[0] > A4IDCLIENTE ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00067_A4IDCLIENTE[0] < A4IDCLIENTE ) ) )
            {
               A4IDCLIENTE = T00067_A4IDCLIENTE[0];
               AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey068( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert068( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A4IDCLIENTE != Z4IDCLIENTE )
               {
                  A4IDCLIENTE = Z4IDCLIENTE;
                  AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDCLIENTE");
                  AnyError = 1;
                  GX_FocusControl = edtIDCLIENTE_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update068( ) ;
                  GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4IDCLIENTE != Z4IDCLIENTE )
               {
                  /* Insert record */
                  GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert068( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDCLIENTE");
                     AnyError = 1;
                     GX_FocusControl = edtIDCLIENTE_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert068( ) ;
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
         if ( A4IDCLIENTE != Z4IDCLIENTE )
         {
            A4IDCLIENTE = Z4IDCLIENTE;
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtIDCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNOMBRECOMPLETOCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency068( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A4IDCLIENTE});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Clientes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30NOMBRECOMPLETOCLIENTE, T00062_A30NOMBRECOMPLETOCLIENTE[0]) != 0 ) || ( StringUtil.StrCmp(Z31USUARIOCLIENTE, T00062_A31USUARIOCLIENTE[0]) != 0 ) || ( StringUtil.StrCmp(Z32CONTRASENACLIENTE, T00062_A32CONTRASENACLIENTE[0]) != 0 ) || ( StringUtil.StrCmp(Z33TELEFONOCLIENTE, T00062_A33TELEFONOCLIENTE[0]) != 0 ) || ( StringUtil.StrCmp(Z34CORREOCLIENTE, T00062_A34CORREOCLIENTE[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z35FECHANACIMIENTOCLIENTE != T00062_A35FECHANACIMIENTOCLIENTE[0] ) || ( StringUtil.StrCmp(Z36DIRECCIONCLIENTE, T00062_A36DIRECCIONCLIENTE[0]) != 0 ) || ( Z37FECHAREGISTROCLIENTE != T00062_A37FECHAREGISTROCLIENTE[0] ) )
            {
               if ( StringUtil.StrCmp(Z30NOMBRECOMPLETOCLIENTE, T00062_A30NOMBRECOMPLETOCLIENTE[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"NOMBRECOMPLETOCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z30NOMBRECOMPLETOCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A30NOMBRECOMPLETOCLIENTE[0]);
               }
               if ( StringUtil.StrCmp(Z31USUARIOCLIENTE, T00062_A31USUARIOCLIENTE[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"USUARIOCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z31USUARIOCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A31USUARIOCLIENTE[0]);
               }
               if ( StringUtil.StrCmp(Z32CONTRASENACLIENTE, T00062_A32CONTRASENACLIENTE[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"CONTRASENACLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z32CONTRASENACLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A32CONTRASENACLIENTE[0]);
               }
               if ( StringUtil.StrCmp(Z33TELEFONOCLIENTE, T00062_A33TELEFONOCLIENTE[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"TELEFONOCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z33TELEFONOCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A33TELEFONOCLIENTE[0]);
               }
               if ( StringUtil.StrCmp(Z34CORREOCLIENTE, T00062_A34CORREOCLIENTE[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"CORREOCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z34CORREOCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A34CORREOCLIENTE[0]);
               }
               if ( Z35FECHANACIMIENTOCLIENTE != T00062_A35FECHANACIMIENTOCLIENTE[0] )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"FECHANACIMIENTOCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z35FECHANACIMIENTOCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A35FECHANACIMIENTOCLIENTE[0]);
               }
               if ( StringUtil.StrCmp(Z36DIRECCIONCLIENTE, T00062_A36DIRECCIONCLIENTE[0]) != 0 )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"DIRECCIONCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z36DIRECCIONCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A36DIRECCIONCLIENTE[0]);
               }
               if ( Z37FECHAREGISTROCLIENTE != T00062_A37FECHAREGISTROCLIENTE[0] )
               {
                  GXUtil.WriteLog("clientes:[seudo value changed for attri]"+"FECHAREGISTROCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z37FECHAREGISTROCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T00062_A37FECHAREGISTROCLIENTE[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Clientes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM068( 0) ;
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00068 */
                     pr_default.execute(6, new Object[] {A30NOMBRECOMPLETOCLIENTE, A31USUARIOCLIENTE, A32CONTRASENACLIENTE, A33TELEFONOCLIENTE, A34CORREOCLIENTE, A35FECHANACIMIENTOCLIENTE, A36DIRECCIONCLIENTE, A37FECHAREGISTROCLIENTE, A53FOTOCLIENTE, A40000FOTOCLIENTE_GXI});
                     A4IDCLIENTE = T00068_A4IDCLIENTE[0];
                     AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Clientes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load068( ) ;
            }
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void Update068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00069 */
                     pr_default.execute(7, new Object[] {A30NOMBRECOMPLETOCLIENTE, A31USUARIOCLIENTE, A32CONTRASENACLIENTE, A33TELEFONOCLIENTE, A34CORREOCLIENTE, A35FECHANACIMIENTOCLIENTE, A36DIRECCIONCLIENTE, A37FECHAREGISTROCLIENTE, A4IDCLIENTE});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Clientes");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Clientes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate068( ) ;
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
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void DeferredUpdate068( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000610 */
            pr_default.execute(8, new Object[] {A53FOTOCLIENTE, A40000FOTOCLIENTE_GXI, A4IDCLIENTE});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("Clientes");
         }
      }

      protected void delete( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls068( ) ;
            AfterConfirm068( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete068( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000611 */
                  pr_default.execute(9, new Object[] {A4IDCLIENTE});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("Clientes");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel068( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls068( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Clientes";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000612 */
            pr_default.execute(10, new Object[] {A4IDCLIENTE});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ventas_inventario"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel068( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete068( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clientes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clientes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart068( )
      {
         /* Scan By routine */
         /* Using cursor T000613 */
         pr_default.execute(11);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound8 = 1;
            A4IDCLIENTE = T000613_A4IDCLIENTE[0];
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext068( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound8 = 1;
            A4IDCLIENTE = T000613_A4IDCLIENTE[0];
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
         }
      }

      protected void ScanEnd068( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm068( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert068( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate068( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete068( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete068( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate068( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes068( )
      {
         edtIDCLIENTE_Enabled = 0;
         AssignProp("", false, edtIDCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCLIENTE_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOCLIENTE_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOCLIENTE_Enabled), 5, 0), true);
         edtUSUARIOCLIENTE_Enabled = 0;
         AssignProp("", false, edtUSUARIOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUSUARIOCLIENTE_Enabled), 5, 0), true);
         edtCONTRASENACLIENTE_Enabled = 0;
         AssignProp("", false, edtCONTRASENACLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCONTRASENACLIENTE_Enabled), 5, 0), true);
         edtTELEFONOCLIENTE_Enabled = 0;
         AssignProp("", false, edtTELEFONOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTELEFONOCLIENTE_Enabled), 5, 0), true);
         edtCORREOCLIENTE_Enabled = 0;
         AssignProp("", false, edtCORREOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCORREOCLIENTE_Enabled), 5, 0), true);
         edtFECHANACIMIENTOCLIENTE_Enabled = 0;
         AssignProp("", false, edtFECHANACIMIENTOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHANACIMIENTOCLIENTE_Enabled), 5, 0), true);
         edtDIRECCIONCLIENTE_Enabled = 0;
         AssignProp("", false, edtDIRECCIONCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDIRECCIONCLIENTE_Enabled), 5, 0), true);
         edtFECHAREGISTROCLIENTE_Enabled = 0;
         AssignProp("", false, edtFECHAREGISTROCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHAREGISTROCLIENTE_Enabled), 5, 0), true);
         imgFOTOCLIENTE_Enabled = 0;
         AssignProp("", false, imgFOTOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgFOTOCLIENTE_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes068( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.AddJavascriptSource("gxcfg.js", "?202111280105071", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientes.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDCLIENTE,12,0))}, new string[] {"Gx_mode","IDCLIENTE"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Clientes");
         forbiddenHiddens.Add("IDCLIENTE", context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clientes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z4IDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4IDCLIENTE), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30NOMBRECOMPLETOCLIENTE", Z30NOMBRECOMPLETOCLIENTE);
         GxWebStd.gx_hidden_field( context, "Z31USUARIOCLIENTE", Z31USUARIOCLIENTE);
         GxWebStd.gx_hidden_field( context, "Z32CONTRASENACLIENTE", Z32CONTRASENACLIENTE);
         GxWebStd.gx_hidden_field( context, "Z33TELEFONOCLIENTE", StringUtil.RTrim( Z33TELEFONOCLIENTE));
         GxWebStd.gx_hidden_field( context, "Z34CORREOCLIENTE", Z34CORREOCLIENTE);
         GxWebStd.gx_hidden_field( context, "Z35FECHANACIMIENTOCLIENTE", context.localUtil.DToC( Z35FECHANACIMIENTOCLIENTE, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z36DIRECCIONCLIENTE", Z36DIRECCIONCLIENTE);
         GxWebStd.gx_hidden_field( context, "Z37FECHAREGISTROCLIENTE", context.localUtil.DToC( Z37FECHAREGISTROCLIENTE, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vIDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDCLIENTE), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDCLIENTE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDCLIENTE), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FOTOCLIENTE_GXI", A40000FOTOCLIENTE_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
         GXCCtlgxBlob = "FOTOCLIENTE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A53FOTOCLIENTE);
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
         return formatLink("clientes.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDCLIENTE,12,0))}, new string[] {"Gx_mode","IDCLIENTE"})  ;
      }

      public override string GetPgmname( )
      {
         return "Clientes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Clientes" ;
      }

      protected void InitializeNonKey068( )
      {
         A30NOMBRECOMPLETOCLIENTE = "";
         AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
         A31USUARIOCLIENTE = "";
         AssignAttri("", false, "A31USUARIOCLIENTE", A31USUARIOCLIENTE);
         A32CONTRASENACLIENTE = "";
         AssignAttri("", false, "A32CONTRASENACLIENTE", A32CONTRASENACLIENTE);
         A33TELEFONOCLIENTE = "";
         AssignAttri("", false, "A33TELEFONOCLIENTE", A33TELEFONOCLIENTE);
         A34CORREOCLIENTE = "";
         AssignAttri("", false, "A34CORREOCLIENTE", A34CORREOCLIENTE);
         A35FECHANACIMIENTOCLIENTE = DateTime.MinValue;
         AssignAttri("", false, "A35FECHANACIMIENTOCLIENTE", context.localUtil.Format(A35FECHANACIMIENTOCLIENTE, "99/99/99"));
         A36DIRECCIONCLIENTE = "";
         AssignAttri("", false, "A36DIRECCIONCLIENTE", A36DIRECCIONCLIENTE);
         A53FOTOCLIENTE = "";
         AssignAttri("", false, "A53FOTOCLIENTE", A53FOTOCLIENTE);
         AssignProp("", false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
         AssignProp("", false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
         A40000FOTOCLIENTE_GXI = "";
         AssignProp("", false, imgFOTOCLIENTE_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A53FOTOCLIENTE)) ? A40000FOTOCLIENTE_GXI : context.convertURL( context.PathToRelativeUrl( A53FOTOCLIENTE))), true);
         AssignProp("", false, imgFOTOCLIENTE_Internalname, "SrcSet", context.GetImageSrcSet( A53FOTOCLIENTE), true);
         A37FECHAREGISTROCLIENTE = Gx_date;
         AssignAttri("", false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
         Z30NOMBRECOMPLETOCLIENTE = "";
         Z31USUARIOCLIENTE = "";
         Z32CONTRASENACLIENTE = "";
         Z33TELEFONOCLIENTE = "";
         Z34CORREOCLIENTE = "";
         Z35FECHANACIMIENTOCLIENTE = DateTime.MinValue;
         Z36DIRECCIONCLIENTE = "";
         Z37FECHAREGISTROCLIENTE = DateTime.MinValue;
      }

      protected void InitAll068( )
      {
         A4IDCLIENTE = 0;
         AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
         InitializeNonKey068( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A37FECHAREGISTROCLIENTE = i37FECHAREGISTROCLIENTE;
         AssignAttri("", false, "A37FECHAREGISTROCLIENTE", context.localUtil.Format(A37FECHAREGISTROCLIENTE, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202111280105079", true, true);
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
         context.AddJavascriptSource("clientes.js", "?202111280105079", false, true);
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
         edtIDCLIENTE_Internalname = "IDCLIENTE";
         edtNOMBRECOMPLETOCLIENTE_Internalname = "NOMBRECOMPLETOCLIENTE";
         edtUSUARIOCLIENTE_Internalname = "USUARIOCLIENTE";
         edtCONTRASENACLIENTE_Internalname = "CONTRASENACLIENTE";
         edtTELEFONOCLIENTE_Internalname = "TELEFONOCLIENTE";
         edtCORREOCLIENTE_Internalname = "CORREOCLIENTE";
         edtFECHANACIMIENTOCLIENTE_Internalname = "FECHANACIMIENTOCLIENTE";
         edtDIRECCIONCLIENTE_Internalname = "DIRECCIONCLIENTE";
         edtFECHAREGISTROCLIENTE_Internalname = "FECHAREGISTROCLIENTE";
         imgFOTOCLIENTE_Internalname = "FOTOCLIENTE";
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
         Form.Caption = "Clientes";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgFOTOCLIENTE_Enabled = 1;
         edtFECHAREGISTROCLIENTE_Jsonclick = "";
         edtFECHAREGISTROCLIENTE_Enabled = 0;
         edtDIRECCIONCLIENTE_Enabled = 1;
         edtFECHANACIMIENTOCLIENTE_Jsonclick = "";
         edtFECHANACIMIENTOCLIENTE_Enabled = 1;
         edtCORREOCLIENTE_Jsonclick = "";
         edtCORREOCLIENTE_Enabled = 1;
         edtTELEFONOCLIENTE_Jsonclick = "";
         edtTELEFONOCLIENTE_Enabled = 1;
         edtCONTRASENACLIENTE_Enabled = 1;
         edtUSUARIOCLIENTE_Enabled = 1;
         edtNOMBRECOMPLETOCLIENTE_Enabled = 1;
         edtIDCLIENTE_Jsonclick = "";
         edtIDCLIENTE_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IDCLIENTE',fld:'vIDCLIENTE',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IDCLIENTE',fld:'vIDCLIENTE',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'A37FECHAREGISTROCLIENTE',fld:'FECHAREGISTROCLIENTE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_IDCLIENTE","{handler:'Valid_Idcliente',iparms:[]");
         setEventMetadata("VALID_IDCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_NOMBRECOMPLETOCLIENTE","{handler:'Valid_Nombrecompletocliente',iparms:[]");
         setEventMetadata("VALID_NOMBRECOMPLETOCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOCLIENTE","{handler:'Valid_Usuariocliente',iparms:[]");
         setEventMetadata("VALID_USUARIOCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_CONTRASENACLIENTE","{handler:'Valid_Contrasenacliente',iparms:[]");
         setEventMetadata("VALID_CONTRASENACLIENTE",",oparms:[]}");
         setEventMetadata("VALID_TELEFONOCLIENTE","{handler:'Valid_Telefonocliente',iparms:[]");
         setEventMetadata("VALID_TELEFONOCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_CORREOCLIENTE","{handler:'Valid_Correocliente',iparms:[]");
         setEventMetadata("VALID_CORREOCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_FECHANACIMIENTOCLIENTE","{handler:'Valid_Fechanacimientocliente',iparms:[]");
         setEventMetadata("VALID_FECHANACIMIENTOCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_DIRECCIONCLIENTE","{handler:'Valid_Direccioncliente',iparms:[]");
         setEventMetadata("VALID_DIRECCIONCLIENTE",",oparms:[]}");
         setEventMetadata("VALID_FOTOCLIENTE","{handler:'Valid_Fotocliente',iparms:[]");
         setEventMetadata("VALID_FOTOCLIENTE",",oparms:[]}");
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
         Z30NOMBRECOMPLETOCLIENTE = "";
         Z31USUARIOCLIENTE = "";
         Z32CONTRASENACLIENTE = "";
         Z33TELEFONOCLIENTE = "";
         Z34CORREOCLIENTE = "";
         Z35FECHANACIMIENTOCLIENTE = DateTime.MinValue;
         Z36DIRECCIONCLIENTE = "";
         Z37FECHAREGISTROCLIENTE = DateTime.MinValue;
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
         A30NOMBRECOMPLETOCLIENTE = "";
         A31USUARIOCLIENTE = "";
         A32CONTRASENACLIENTE = "";
         gxphoneLink = "";
         A33TELEFONOCLIENTE = "";
         A34CORREOCLIENTE = "";
         A35FECHANACIMIENTOCLIENTE = DateTime.MinValue;
         A36DIRECCIONCLIENTE = "";
         A37FECHAREGISTROCLIENTE = DateTime.MinValue;
         A53FOTOCLIENTE = "";
         A40000FOTOCLIENTE_GXI = "";
         sImgUrl = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode8 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z53FOTOCLIENTE = "";
         Z40000FOTOCLIENTE_GXI = "";
         T00064_A4IDCLIENTE = new long[1] ;
         T00064_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         T00064_A31USUARIOCLIENTE = new string[] {""} ;
         T00064_A32CONTRASENACLIENTE = new string[] {""} ;
         T00064_A33TELEFONOCLIENTE = new string[] {""} ;
         T00064_A34CORREOCLIENTE = new string[] {""} ;
         T00064_A35FECHANACIMIENTOCLIENTE = new DateTime[] {DateTime.MinValue} ;
         T00064_A36DIRECCIONCLIENTE = new string[] {""} ;
         T00064_A37FECHAREGISTROCLIENTE = new DateTime[] {DateTime.MinValue} ;
         T00064_A40000FOTOCLIENTE_GXI = new string[] {""} ;
         T00064_A53FOTOCLIENTE = new string[] {""} ;
         T00065_A4IDCLIENTE = new long[1] ;
         T00063_A4IDCLIENTE = new long[1] ;
         T00063_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         T00063_A31USUARIOCLIENTE = new string[] {""} ;
         T00063_A32CONTRASENACLIENTE = new string[] {""} ;
         T00063_A33TELEFONOCLIENTE = new string[] {""} ;
         T00063_A34CORREOCLIENTE = new string[] {""} ;
         T00063_A35FECHANACIMIENTOCLIENTE = new DateTime[] {DateTime.MinValue} ;
         T00063_A36DIRECCIONCLIENTE = new string[] {""} ;
         T00063_A37FECHAREGISTROCLIENTE = new DateTime[] {DateTime.MinValue} ;
         T00063_A40000FOTOCLIENTE_GXI = new string[] {""} ;
         T00063_A53FOTOCLIENTE = new string[] {""} ;
         T00066_A4IDCLIENTE = new long[1] ;
         T00067_A4IDCLIENTE = new long[1] ;
         T00062_A4IDCLIENTE = new long[1] ;
         T00062_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         T00062_A31USUARIOCLIENTE = new string[] {""} ;
         T00062_A32CONTRASENACLIENTE = new string[] {""} ;
         T00062_A33TELEFONOCLIENTE = new string[] {""} ;
         T00062_A34CORREOCLIENTE = new string[] {""} ;
         T00062_A35FECHANACIMIENTOCLIENTE = new DateTime[] {DateTime.MinValue} ;
         T00062_A36DIRECCIONCLIENTE = new string[] {""} ;
         T00062_A37FECHAREGISTROCLIENTE = new DateTime[] {DateTime.MinValue} ;
         T00062_A40000FOTOCLIENTE_GXI = new string[] {""} ;
         T00062_A53FOTOCLIENTE = new string[] {""} ;
         T00068_A4IDCLIENTE = new long[1] ;
         T000612_A12IDVENTA = new long[1] ;
         T000613_A4IDCLIENTE = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i37FECHAREGISTROCLIENTE = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientes__default(),
            new Object[][] {
                new Object[] {
               T00062_A4IDCLIENTE, T00062_A30NOMBRECOMPLETOCLIENTE, T00062_A31USUARIOCLIENTE, T00062_A32CONTRASENACLIENTE, T00062_A33TELEFONOCLIENTE, T00062_A34CORREOCLIENTE, T00062_A35FECHANACIMIENTOCLIENTE, T00062_A36DIRECCIONCLIENTE, T00062_A37FECHAREGISTROCLIENTE, T00062_A40000FOTOCLIENTE_GXI,
               T00062_A53FOTOCLIENTE
               }
               , new Object[] {
               T00063_A4IDCLIENTE, T00063_A30NOMBRECOMPLETOCLIENTE, T00063_A31USUARIOCLIENTE, T00063_A32CONTRASENACLIENTE, T00063_A33TELEFONOCLIENTE, T00063_A34CORREOCLIENTE, T00063_A35FECHANACIMIENTOCLIENTE, T00063_A36DIRECCIONCLIENTE, T00063_A37FECHAREGISTROCLIENTE, T00063_A40000FOTOCLIENTE_GXI,
               T00063_A53FOTOCLIENTE
               }
               , new Object[] {
               T00064_A4IDCLIENTE, T00064_A30NOMBRECOMPLETOCLIENTE, T00064_A31USUARIOCLIENTE, T00064_A32CONTRASENACLIENTE, T00064_A33TELEFONOCLIENTE, T00064_A34CORREOCLIENTE, T00064_A35FECHANACIMIENTOCLIENTE, T00064_A36DIRECCIONCLIENTE, T00064_A37FECHAREGISTROCLIENTE, T00064_A40000FOTOCLIENTE_GXI,
               T00064_A53FOTOCLIENTE
               }
               , new Object[] {
               T00065_A4IDCLIENTE
               }
               , new Object[] {
               T00066_A4IDCLIENTE
               }
               , new Object[] {
               T00067_A4IDCLIENTE
               }
               , new Object[] {
               T00068_A4IDCLIENTE
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000612_A12IDVENTA
               }
               , new Object[] {
               T000613_A4IDCLIENTE
               }
            }
         );
         AV13Pgmname = "Clientes";
         Z37FECHAREGISTROCLIENTE = DateTime.MinValue;
         A37FECHAREGISTROCLIENTE = DateTime.MinValue;
         i37FECHAREGISTROCLIENTE = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound8 ;
      private short GX_JID ;
      private short nIsDirty_8 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIDCLIENTE_Enabled ;
      private int edtNOMBRECOMPLETOCLIENTE_Enabled ;
      private int edtUSUARIOCLIENTE_Enabled ;
      private int edtCONTRASENACLIENTE_Enabled ;
      private int edtTELEFONOCLIENTE_Enabled ;
      private int edtCORREOCLIENTE_Enabled ;
      private int edtFECHANACIMIENTOCLIENTE_Enabled ;
      private int edtDIRECCIONCLIENTE_Enabled ;
      private int edtFECHAREGISTROCLIENTE_Enabled ;
      private int imgFOTOCLIENTE_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long wcpOAV7IDCLIENTE ;
      private long Z4IDCLIENTE ;
      private long AV7IDCLIENTE ;
      private long A4IDCLIENTE ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z33TELEFONOCLIENTE ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNOMBRECOMPLETOCLIENTE_Internalname ;
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
      private string edtIDCLIENTE_Internalname ;
      private string edtIDCLIENTE_Jsonclick ;
      private string edtUSUARIOCLIENTE_Internalname ;
      private string edtCONTRASENACLIENTE_Internalname ;
      private string edtTELEFONOCLIENTE_Internalname ;
      private string gxphoneLink ;
      private string A33TELEFONOCLIENTE ;
      private string edtTELEFONOCLIENTE_Jsonclick ;
      private string edtCORREOCLIENTE_Internalname ;
      private string edtCORREOCLIENTE_Jsonclick ;
      private string edtFECHANACIMIENTOCLIENTE_Internalname ;
      private string edtFECHANACIMIENTOCLIENTE_Jsonclick ;
      private string edtDIRECCIONCLIENTE_Internalname ;
      private string edtFECHAREGISTROCLIENTE_Internalname ;
      private string edtFECHAREGISTROCLIENTE_Jsonclick ;
      private string imgFOTOCLIENTE_Internalname ;
      private string sImgUrl ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode8 ;
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
      private DateTime Z35FECHANACIMIENTOCLIENTE ;
      private DateTime Z37FECHAREGISTROCLIENTE ;
      private DateTime A35FECHANACIMIENTOCLIENTE ;
      private DateTime A37FECHAREGISTROCLIENTE ;
      private DateTime Gx_date ;
      private DateTime i37FECHAREGISTROCLIENTE ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A53FOTOCLIENTE_IsBlob ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z30NOMBRECOMPLETOCLIENTE ;
      private string Z31USUARIOCLIENTE ;
      private string Z32CONTRASENACLIENTE ;
      private string Z34CORREOCLIENTE ;
      private string Z36DIRECCIONCLIENTE ;
      private string A30NOMBRECOMPLETOCLIENTE ;
      private string A31USUARIOCLIENTE ;
      private string A32CONTRASENACLIENTE ;
      private string A34CORREOCLIENTE ;
      private string A36DIRECCIONCLIENTE ;
      private string A40000FOTOCLIENTE_GXI ;
      private string Z40000FOTOCLIENTE_GXI ;
      private string A53FOTOCLIENTE ;
      private string Z53FOTOCLIENTE ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T00064_A4IDCLIENTE ;
      private string[] T00064_A30NOMBRECOMPLETOCLIENTE ;
      private string[] T00064_A31USUARIOCLIENTE ;
      private string[] T00064_A32CONTRASENACLIENTE ;
      private string[] T00064_A33TELEFONOCLIENTE ;
      private string[] T00064_A34CORREOCLIENTE ;
      private DateTime[] T00064_A35FECHANACIMIENTOCLIENTE ;
      private string[] T00064_A36DIRECCIONCLIENTE ;
      private DateTime[] T00064_A37FECHAREGISTROCLIENTE ;
      private string[] T00064_A40000FOTOCLIENTE_GXI ;
      private string[] T00064_A53FOTOCLIENTE ;
      private long[] T00065_A4IDCLIENTE ;
      private long[] T00063_A4IDCLIENTE ;
      private string[] T00063_A30NOMBRECOMPLETOCLIENTE ;
      private string[] T00063_A31USUARIOCLIENTE ;
      private string[] T00063_A32CONTRASENACLIENTE ;
      private string[] T00063_A33TELEFONOCLIENTE ;
      private string[] T00063_A34CORREOCLIENTE ;
      private DateTime[] T00063_A35FECHANACIMIENTOCLIENTE ;
      private string[] T00063_A36DIRECCIONCLIENTE ;
      private DateTime[] T00063_A37FECHAREGISTROCLIENTE ;
      private string[] T00063_A40000FOTOCLIENTE_GXI ;
      private string[] T00063_A53FOTOCLIENTE ;
      private long[] T00066_A4IDCLIENTE ;
      private long[] T00067_A4IDCLIENTE ;
      private long[] T00062_A4IDCLIENTE ;
      private string[] T00062_A30NOMBRECOMPLETOCLIENTE ;
      private string[] T00062_A31USUARIOCLIENTE ;
      private string[] T00062_A32CONTRASENACLIENTE ;
      private string[] T00062_A33TELEFONOCLIENTE ;
      private string[] T00062_A34CORREOCLIENTE ;
      private DateTime[] T00062_A35FECHANACIMIENTOCLIENTE ;
      private string[] T00062_A36DIRECCIONCLIENTE ;
      private DateTime[] T00062_A37FECHAREGISTROCLIENTE ;
      private string[] T00062_A40000FOTOCLIENTE_GXI ;
      private string[] T00062_A53FOTOCLIENTE ;
      private long[] T00068_A4IDCLIENTE ;
      private long[] T000612_A12IDVENTA ;
      private long[] T000613_A4IDCLIENTE ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class clientes__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@NOMBRECOMPLETOCLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@USUARIOCLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@CONTRASENACLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@TELEFONOCLIENTE",GXType.NChar,20,0) ,
          new ParDef("@CORREOCLIENTE",GXType.NVarChar,100,0) ,
          new ParDef("@FECHANACIMIENTOCLIENTE",GXType.Date,8,0) ,
          new ParDef("@DIRECCIONCLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@FECHAREGISTROCLIENTE",GXType.Date,8,0) ,
          new ParDef("@FOTOCLIENTE",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FOTOCLIENTE_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=8, Tbl="Clientes", Fld="FOTOCLIENTE"}
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@NOMBRECOMPLETOCLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@USUARIOCLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@CONTRASENACLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@TELEFONOCLIENTE",GXType.NChar,20,0) ,
          new ParDef("@CORREOCLIENTE",GXType.NVarChar,100,0) ,
          new ParDef("@FECHANACIMIENTOCLIENTE",GXType.Date,8,0) ,
          new ParDef("@DIRECCIONCLIENTE",GXType.NVarChar,255,0) ,
          new ParDef("@FECHAREGISTROCLIENTE",GXType.Date,8,0) ,
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@FOTOCLIENTE",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@FOTOCLIENTE_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Clientes", Fld="FOTOCLIENTE"} ,
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000613;
          prmT000613 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [IDCLIENTE], [NOMBRECOMPLETOCLIENTE], [USUARIOCLIENTE], [CONTRASENACLIENTE], [TELEFONOCLIENTE], [CORREOCLIENTE], [FECHANACIMIENTOCLIENTE], [DIRECCIONCLIENTE], [FECHAREGISTROCLIENTE], [FOTOCLIENTE_GXI], [FOTOCLIENTE] FROM [Clientes] WITH (UPDLOCK) WHERE [IDCLIENTE] = @IDCLIENTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [IDCLIENTE], [NOMBRECOMPLETOCLIENTE], [USUARIOCLIENTE], [CONTRASENACLIENTE], [TELEFONOCLIENTE], [CORREOCLIENTE], [FECHANACIMIENTOCLIENTE], [DIRECCIONCLIENTE], [FECHAREGISTROCLIENTE], [FOTOCLIENTE_GXI], [FOTOCLIENTE] FROM [Clientes] WHERE [IDCLIENTE] = @IDCLIENTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT TM1.[IDCLIENTE], TM1.[NOMBRECOMPLETOCLIENTE], TM1.[USUARIOCLIENTE], TM1.[CONTRASENACLIENTE], TM1.[TELEFONOCLIENTE], TM1.[CORREOCLIENTE], TM1.[FECHANACIMIENTOCLIENTE], TM1.[DIRECCIONCLIENTE], TM1.[FECHAREGISTROCLIENTE], TM1.[FOTOCLIENTE_GXI], TM1.[FOTOCLIENTE] FROM [Clientes] TM1 WHERE TM1.[IDCLIENTE] = @IDCLIENTE ORDER BY TM1.[IDCLIENTE]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [IDCLIENTE] FROM [Clientes] WHERE [IDCLIENTE] = @IDCLIENTE  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT TOP 1 [IDCLIENTE] FROM [Clientes] WHERE ( [IDCLIENTE] > @IDCLIENTE) ORDER BY [IDCLIENTE]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00067", "SELECT TOP 1 [IDCLIENTE] FROM [Clientes] WHERE ( [IDCLIENTE] < @IDCLIENTE) ORDER BY [IDCLIENTE] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00068", "INSERT INTO [Clientes]([NOMBRECOMPLETOCLIENTE], [USUARIOCLIENTE], [CONTRASENACLIENTE], [TELEFONOCLIENTE], [CORREOCLIENTE], [FECHANACIMIENTOCLIENTE], [DIRECCIONCLIENTE], [FECHAREGISTROCLIENTE], [FOTOCLIENTE], [FOTOCLIENTE_GXI]) VALUES(@NOMBRECOMPLETOCLIENTE, @USUARIOCLIENTE, @CONTRASENACLIENTE, @TELEFONOCLIENTE, @CORREOCLIENTE, @FECHANACIMIENTOCLIENTE, @DIRECCIONCLIENTE, @FECHAREGISTROCLIENTE, @FOTOCLIENTE, @FOTOCLIENTE_GXI); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT00068)
             ,new CursorDef("T00069", "UPDATE [Clientes] SET [NOMBRECOMPLETOCLIENTE]=@NOMBRECOMPLETOCLIENTE, [USUARIOCLIENTE]=@USUARIOCLIENTE, [CONTRASENACLIENTE]=@CONTRASENACLIENTE, [TELEFONOCLIENTE]=@TELEFONOCLIENTE, [CORREOCLIENTE]=@CORREOCLIENTE, [FECHANACIMIENTOCLIENTE]=@FECHANACIMIENTOCLIENTE, [DIRECCIONCLIENTE]=@DIRECCIONCLIENTE, [FECHAREGISTROCLIENTE]=@FECHAREGISTROCLIENTE  WHERE [IDCLIENTE] = @IDCLIENTE", GxErrorMask.GX_NOMASK,prmT00069)
             ,new CursorDef("T000610", "UPDATE [Clientes] SET [FOTOCLIENTE]=@FOTOCLIENTE, [FOTOCLIENTE_GXI]=@FOTOCLIENTE_GXI  WHERE [IDCLIENTE] = @IDCLIENTE", GxErrorMask.GX_NOMASK,prmT000610)
             ,new CursorDef("T000611", "DELETE FROM [Clientes]  WHERE [IDCLIENTE] = @IDCLIENTE", GxErrorMask.GX_NOMASK,prmT000611)
             ,new CursorDef("T000612", "SELECT TOP 1 [IDVENTA] FROM [Ventas_inventario] WHERE [IDCLIENTE] = @IDCLIENTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000613", "SELECT [IDCLIENTE] FROM [Clientes] ORDER BY [IDCLIENTE]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(10));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(10));
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(10));
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
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
