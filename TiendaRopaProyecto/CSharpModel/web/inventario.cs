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
   public class inventario : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A5IDESTADOPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDESTADOPRODUCTO"), "."));
            AssignAttri("", false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A5IDESTADOPRODUCTO) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A6IDCATEGORIAPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDCATEGORIAPRODUCTO"), "."));
            AssignAttri("", false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A6IDCATEGORIAPRODUCTO) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A8IDMARCAPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDMARCAPRODUCTO"), "."));
            AssignAttri("", false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A8IDMARCAPRODUCTO) ;
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
               AV7IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
               AssignAttri("", false, "AV7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(AV7IDPRODUCTO), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDPRODUCTO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDPRODUCTO), "ZZZZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Inventario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public inventario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public inventario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IDPRODUCTO )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IDPRODUCTO = aP1_IDPRODUCTO;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Inventario", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Inventario.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Inventario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDPRODUCTO_Internalname, "IDPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIDPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")), ((edtIDPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONPRODUCTO_Internalname, "DESCRIPCIONPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONPRODUCTO_Internalname, A40DESCRIPCIONPRODUCTO, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtDESCRIPCIONPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCANTIDADPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCANTIDADPRODUCTO_Internalname, "CANTIDADPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCANTIDADPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")), ((edtCANTIDADPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCANTIDADPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCANTIDADPRODUCTO_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Cantidad", "right", false, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECIOCOMPRAPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPRECIOCOMPRAPRODUCTO_Internalname, "PRECIOCOMPRAPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPRECIOCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")), ((edtPRECIOCOMPRAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECIOCOMPRAPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPRECIOCOMPRAPRODUCTO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPRECIOVENTAPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPRECIOVENTAPRODUCTO_Internalname, "PRECIOVENTAPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPRECIOVENTAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")), ((edtPRECIOVENTAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPRECIOVENTAPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPRECIOVENTAPRODUCTO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDESTADOPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDESTADOPRODUCTO_Internalname, "IDESTADOPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDESTADOPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5IDESTADOPRODUCTO), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A5IDESTADOPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDESTADOPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDESTADOPRODUCTO_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONESTADOPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONESTADOPRODUCTO_Internalname, "DESCRIPCIONESTADOPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONESTADOPRODUCTO_Internalname, A38DESCRIPCIONESTADOPRODUCTO, "", "", 0, 1, edtDESCRIPCIONESTADOPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDCATEGORIAPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDCATEGORIAPRODUCTO_Internalname, "IDCATEGORIAPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDCATEGORIAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A6IDCATEGORIAPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCATEGORIAPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDCATEGORIAPRODUCTO_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_6_Internalname, sImgUrl, imgprompt_6_Link, "", "", context.GetTheme( ), imgprompt_6_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname, "DESCRIPCIONCATEGORIAPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname, A39DESCRIPCIONCATEGORIAPRODUCTO, "", "", 0, 1, edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDMARCAPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDMARCAPRODUCTO_Internalname, "IDMARCAPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDMARCAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8IDMARCAPRODUCTO), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A8IDMARCAPRODUCTO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDMARCAPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDMARCAPRODUCTO_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_8_Internalname, sImgUrl, imgprompt_8_Link, "", "", context.GetTheme( ), imgprompt_8_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONMARCAPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONMARCAPRODUCTO_Internalname, "DESCRIPCIONMARCAPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONMARCAPRODUCTO_Internalname, A44DESCRIPCIONMARCAPRODUCTO, "", "", 0, 1, edtDESCRIPCIONMARCAPRODUCTO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Inventario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "Z7IDPRODUCTO"), ".", ","));
               Z40DESCRIPCIONPRODUCTO = cgiGet( "Z40DESCRIPCIONPRODUCTO");
               Z41CANTIDADPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "Z41CANTIDADPRODUCTO"), ".", ","));
               Z42PRECIOCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( "Z42PRECIOCOMPRAPRODUCTO"), ".", ",");
               Z43PRECIOVENTAPRODUCTO = context.localUtil.CToN( cgiGet( "Z43PRECIOVENTAPRODUCTO"), ".", ",");
               Z5IDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "Z5IDESTADOPRODUCTO"), ".", ","));
               Z6IDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "Z6IDCATEGORIAPRODUCTO"), ".", ","));
               Z8IDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "Z8IDMARCAPRODUCTO"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N5IDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "N5IDESTADOPRODUCTO"), ".", ","));
               N6IDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "N6IDCATEGORIAPRODUCTO"), ".", ","));
               N8IDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "N8IDMARCAPRODUCTO"), ".", ","));
               AV7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "vIDPRODUCTO"), ".", ","));
               AV11Insert_IDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDESTADOPRODUCTO"), ".", ","));
               AV12Insert_IDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDCATEGORIAPRODUCTO"), ".", ","));
               AV13Insert_IDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDMARCAPRODUCTO"), ".", ","));
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDPRODUCTO_Internalname), ".", ","));
               AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
               A40DESCRIPCIONPRODUCTO = cgiGet( edtDESCRIPCIONPRODUCTO_Internalname);
               AssignAttri("", false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCANTIDADPRODUCTO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCANTIDADPRODUCTO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CANTIDADPRODUCTO");
                  AnyError = 1;
                  GX_FocusControl = edtCANTIDADPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A41CANTIDADPRODUCTO = 0;
                  AssignAttri("", false, "A41CANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(A41CANTIDADPRODUCTO), 12, 0));
               }
               else
               {
                  A41CANTIDADPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtCANTIDADPRODUCTO_Internalname), ".", ","));
                  AssignAttri("", false, "A41CANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(A41CANTIDADPRODUCTO), 12, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPRECIOCOMPRAPRODUCTO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPRECIOCOMPRAPRODUCTO_Internalname), ".", ",") > 999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRECIOCOMPRAPRODUCTO");
                  AnyError = 1;
                  GX_FocusControl = edtPRECIOCOMPRAPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A42PRECIOCOMPRAPRODUCTO = 0;
                  AssignAttri("", false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( A42PRECIOCOMPRAPRODUCTO, 12, 2));
               }
               else
               {
                  A42PRECIOCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOCOMPRAPRODUCTO_Internalname), ".", ",");
                  AssignAttri("", false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( A42PRECIOCOMPRAPRODUCTO, 12, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPRECIOVENTAPRODUCTO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPRECIOVENTAPRODUCTO_Internalname), ".", ",") > 999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRECIOVENTAPRODUCTO");
                  AnyError = 1;
                  GX_FocusControl = edtPRECIOVENTAPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A43PRECIOVENTAPRODUCTO = 0;
                  AssignAttri("", false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrimStr( A43PRECIOVENTAPRODUCTO, 12, 2));
               }
               else
               {
                  A43PRECIOVENTAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOVENTAPRODUCTO_Internalname), ".", ",");
                  AssignAttri("", false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrimStr( A43PRECIOVENTAPRODUCTO, 12, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDESTADOPRODUCTO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDESTADOPRODUCTO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDESTADOPRODUCTO");
                  AnyError = 1;
                  GX_FocusControl = edtIDESTADOPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A5IDESTADOPRODUCTO = 0;
                  AssignAttri("", false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
               }
               else
               {
                  A5IDESTADOPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDESTADOPRODUCTO_Internalname), ".", ","));
                  AssignAttri("", false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
               }
               A38DESCRIPCIONESTADOPRODUCTO = cgiGet( edtDESCRIPCIONESTADOPRODUCTO_Internalname);
               AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDCATEGORIAPRODUCTO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDCATEGORIAPRODUCTO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDCATEGORIAPRODUCTO");
                  AnyError = 1;
                  GX_FocusControl = edtIDCATEGORIAPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6IDCATEGORIAPRODUCTO = 0;
                  AssignAttri("", false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
               }
               else
               {
                  A6IDCATEGORIAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDCATEGORIAPRODUCTO_Internalname), ".", ","));
                  AssignAttri("", false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
               }
               A39DESCRIPCIONCATEGORIAPRODUCTO = cgiGet( edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname);
               AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDMARCAPRODUCTO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDMARCAPRODUCTO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDMARCAPRODUCTO");
                  AnyError = 1;
                  GX_FocusControl = edtIDMARCAPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8IDMARCAPRODUCTO = 0;
                  AssignAttri("", false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
               }
               else
               {
                  A8IDMARCAPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDMARCAPRODUCTO_Internalname), ".", ","));
                  AssignAttri("", false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
               }
               A44DESCRIPCIONMARCAPRODUCTO = cgiGet( edtDESCRIPCIONMARCAPRODUCTO_Internalname);
               AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Inventario");
               A7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDPRODUCTO_Internalname), ".", ","));
               AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
               forbiddenHiddens.Add("IDPRODUCTO", context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A7IDPRODUCTO != Z7IDPRODUCTO ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("inventario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A7IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
                  AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDPRODUCTO");
                        AnyError = 1;
                        GX_FocusControl = edtIDPRODUCTO_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll079( ) ;
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
            DisableAttributes079( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls079( ) ;
            }
            else
            {
               CheckExtendedTable079( ) ;
               CloseExtendedTableCursors079( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "TiendaRopaProyecto");
         AV11Insert_IDESTADOPRODUCTO = 0;
         AssignAttri("", false, "AV11Insert_IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(AV11Insert_IDESTADOPRODUCTO), 12, 0));
         AV12Insert_IDCATEGORIAPRODUCTO = 0;
         AssignAttri("", false, "AV12Insert_IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV12Insert_IDCATEGORIAPRODUCTO), 12, 0));
         AV13Insert_IDMARCAPRODUCTO = 0;
         AssignAttri("", false, "AV13Insert_IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV13Insert_IDMARCAPRODUCTO), 12, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "IDESTADOPRODUCTO") == 0 )
               {
                  AV11Insert_IDESTADOPRODUCTO = (long)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(AV11Insert_IDESTADOPRODUCTO), 12, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "IDCATEGORIAPRODUCTO") == 0 )
               {
                  AV12Insert_IDCATEGORIAPRODUCTO = (long)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV12Insert_IDCATEGORIAPRODUCTO), 12, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "IDMARCAPRODUCTO") == 0 )
               {
                  AV13Insert_IDMARCAPRODUCTO = (long)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(AV13Insert_IDMARCAPRODUCTO), 12, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwinventario.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM079( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z40DESCRIPCIONPRODUCTO = T00073_A40DESCRIPCIONPRODUCTO[0];
               Z41CANTIDADPRODUCTO = T00073_A41CANTIDADPRODUCTO[0];
               Z42PRECIOCOMPRAPRODUCTO = T00073_A42PRECIOCOMPRAPRODUCTO[0];
               Z43PRECIOVENTAPRODUCTO = T00073_A43PRECIOVENTAPRODUCTO[0];
               Z5IDESTADOPRODUCTO = T00073_A5IDESTADOPRODUCTO[0];
               Z6IDCATEGORIAPRODUCTO = T00073_A6IDCATEGORIAPRODUCTO[0];
               Z8IDMARCAPRODUCTO = T00073_A8IDMARCAPRODUCTO[0];
            }
            else
            {
               Z40DESCRIPCIONPRODUCTO = A40DESCRIPCIONPRODUCTO;
               Z41CANTIDADPRODUCTO = A41CANTIDADPRODUCTO;
               Z42PRECIOCOMPRAPRODUCTO = A42PRECIOCOMPRAPRODUCTO;
               Z43PRECIOVENTAPRODUCTO = A43PRECIOVENTAPRODUCTO;
               Z5IDESTADOPRODUCTO = A5IDESTADOPRODUCTO;
               Z6IDCATEGORIAPRODUCTO = A6IDCATEGORIAPRODUCTO;
               Z8IDMARCAPRODUCTO = A8IDMARCAPRODUCTO;
            }
         }
         if ( GX_JID == -21 )
         {
            Z7IDPRODUCTO = A7IDPRODUCTO;
            Z40DESCRIPCIONPRODUCTO = A40DESCRIPCIONPRODUCTO;
            Z41CANTIDADPRODUCTO = A41CANTIDADPRODUCTO;
            Z42PRECIOCOMPRAPRODUCTO = A42PRECIOCOMPRAPRODUCTO;
            Z43PRECIOVENTAPRODUCTO = A43PRECIOVENTAPRODUCTO;
            Z5IDESTADOPRODUCTO = A5IDESTADOPRODUCTO;
            Z6IDCATEGORIAPRODUCTO = A6IDCATEGORIAPRODUCTO;
            Z8IDMARCAPRODUCTO = A8IDMARCAPRODUCTO;
            Z38DESCRIPCIONESTADOPRODUCTO = A38DESCRIPCIONESTADOPRODUCTO;
            Z39DESCRIPCIONCATEGORIAPRODUCTO = A39DESCRIPCIONCATEGORIAPRODUCTO;
            Z44DESCRIPCIONMARCAPRODUCTO = A44DESCRIPCIONMARCAPRODUCTO;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIDPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), true);
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDESTADOPRODUCTO"+"'), id:'"+"IDESTADOPRODUCTO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_6_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00b0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDCATEGORIAPRODUCTO"+"'), id:'"+"IDCATEGORIAPRODUCTO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_8_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00c0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDMARCAPRODUCTO"+"'), id:'"+"IDMARCAPRODUCTO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtIDPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IDPRODUCTO) )
         {
            A7IDPRODUCTO = AV7IDPRODUCTO;
            AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDESTADOPRODUCTO) )
         {
            edtIDESTADOPRODUCTO_Enabled = 0;
            AssignProp("", false, edtIDESTADOPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDESTADOPRODUCTO_Enabled), 5, 0), true);
         }
         else
         {
            edtIDESTADOPRODUCTO_Enabled = 1;
            AssignProp("", false, edtIDESTADOPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDESTADOPRODUCTO_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_IDCATEGORIAPRODUCTO) )
         {
            edtIDCATEGORIAPRODUCTO_Enabled = 0;
            AssignProp("", false, edtIDCATEGORIAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCATEGORIAPRODUCTO_Enabled), 5, 0), true);
         }
         else
         {
            edtIDCATEGORIAPRODUCTO_Enabled = 1;
            AssignProp("", false, edtIDCATEGORIAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCATEGORIAPRODUCTO_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_IDMARCAPRODUCTO) )
         {
            edtIDMARCAPRODUCTO_Enabled = 0;
            AssignProp("", false, edtIDMARCAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDMARCAPRODUCTO_Enabled), 5, 0), true);
         }
         else
         {
            edtIDMARCAPRODUCTO_Enabled = 1;
            AssignProp("", false, edtIDMARCAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDMARCAPRODUCTO_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_IDMARCAPRODUCTO) )
         {
            A8IDMARCAPRODUCTO = AV13Insert_IDMARCAPRODUCTO;
            AssignAttri("", false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_IDCATEGORIAPRODUCTO) )
         {
            A6IDCATEGORIAPRODUCTO = AV12Insert_IDCATEGORIAPRODUCTO;
            AssignAttri("", false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDESTADOPRODUCTO) )
         {
            A5IDESTADOPRODUCTO = AV11Insert_IDESTADOPRODUCTO;
            AssignAttri("", false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
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
            AV15Pgmname = "Inventario";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00076 */
            pr_default.execute(4, new Object[] {A8IDMARCAPRODUCTO});
            A44DESCRIPCIONMARCAPRODUCTO = T00076_A44DESCRIPCIONMARCAPRODUCTO[0];
            AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
            pr_default.close(4);
            /* Using cursor T00075 */
            pr_default.execute(3, new Object[] {A6IDCATEGORIAPRODUCTO});
            A39DESCRIPCIONCATEGORIAPRODUCTO = T00075_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
            AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
            pr_default.close(3);
            /* Using cursor T00074 */
            pr_default.execute(2, new Object[] {A5IDESTADOPRODUCTO});
            A38DESCRIPCIONESTADOPRODUCTO = T00074_A38DESCRIPCIONESTADOPRODUCTO[0];
            AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
            pr_default.close(2);
         }
      }

      protected void Load079( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
            A40DESCRIPCIONPRODUCTO = T00077_A40DESCRIPCIONPRODUCTO[0];
            AssignAttri("", false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
            A41CANTIDADPRODUCTO = T00077_A41CANTIDADPRODUCTO[0];
            AssignAttri("", false, "A41CANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(A41CANTIDADPRODUCTO), 12, 0));
            A42PRECIOCOMPRAPRODUCTO = T00077_A42PRECIOCOMPRAPRODUCTO[0];
            AssignAttri("", false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( A42PRECIOCOMPRAPRODUCTO, 12, 2));
            A43PRECIOVENTAPRODUCTO = T00077_A43PRECIOVENTAPRODUCTO[0];
            AssignAttri("", false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrimStr( A43PRECIOVENTAPRODUCTO, 12, 2));
            A38DESCRIPCIONESTADOPRODUCTO = T00077_A38DESCRIPCIONESTADOPRODUCTO[0];
            AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
            A39DESCRIPCIONCATEGORIAPRODUCTO = T00077_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
            AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
            A44DESCRIPCIONMARCAPRODUCTO = T00077_A44DESCRIPCIONMARCAPRODUCTO[0];
            AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
            A5IDESTADOPRODUCTO = T00077_A5IDESTADOPRODUCTO[0];
            AssignAttri("", false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
            A6IDCATEGORIAPRODUCTO = T00077_A6IDCATEGORIAPRODUCTO[0];
            AssignAttri("", false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
            A8IDMARCAPRODUCTO = T00077_A8IDMARCAPRODUCTO[0];
            AssignAttri("", false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
            ZM079( -21) ;
         }
         pr_default.close(5);
         OnLoadActions079( ) ;
      }

      protected void OnLoadActions079( )
      {
         AV15Pgmname = "Inventario";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable079( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "Inventario";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A40DESCRIPCIONPRODUCTO)) )
         {
            GX_msglist.addItem("Ingrese la descripcion del producto", 1, "DESCRIPCIONPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A41CANTIDADPRODUCTO) )
         {
            GX_msglist.addItem("Ingrese la cantidad del producto", 1, "CANTIDADPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtCANTIDADPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A42PRECIOCOMPRAPRODUCTO) )
         {
            GX_msglist.addItem("Ingrese el precio de compra del producto", 1, "PRECIOCOMPRAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtPRECIOCOMPRAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A43PRECIOVENTAPRODUCTO) )
         {
            GX_msglist.addItem("Ingrese el precio de venta del producto", 1, "PRECIOVENTAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtPRECIOVENTAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A5IDESTADOPRODUCTO});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Estado_producto'.", "ForeignKeyNotFound", 1, "IDESTADOPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A38DESCRIPCIONESTADOPRODUCTO = T00074_A38DESCRIPCIONESTADOPRODUCTO[0];
         AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
         pr_default.close(2);
         if ( (0==A5IDESTADOPRODUCTO) )
         {
            GX_msglist.addItem("Seleccione el estado del producto", 1, "IDESTADOPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A6IDCATEGORIAPRODUCTO});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria_producto'.", "ForeignKeyNotFound", 1, "IDCATEGORIAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDCATEGORIAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A39DESCRIPCIONCATEGORIAPRODUCTO = T00075_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
         AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
         pr_default.close(3);
         if ( (0==A6IDCATEGORIAPRODUCTO) )
         {
            GX_msglist.addItem("Seleccione la categoria del producto", 1, "IDCATEGORIAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDCATEGORIAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A8IDMARCAPRODUCTO});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Marca_producto'.", "ForeignKeyNotFound", 1, "IDMARCAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDMARCAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A44DESCRIPCIONMARCAPRODUCTO = T00076_A44DESCRIPCIONMARCAPRODUCTO[0];
         AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
         pr_default.close(4);
         if ( (0==A8IDMARCAPRODUCTO) )
         {
            GX_msglist.addItem("Seleccione la marca del producto", 1, "IDMARCAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDMARCAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors079( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_22( long A5IDESTADOPRODUCTO )
      {
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A5IDESTADOPRODUCTO});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Estado_producto'.", "ForeignKeyNotFound", 1, "IDESTADOPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A38DESCRIPCIONESTADOPRODUCTO = T00078_A38DESCRIPCIONESTADOPRODUCTO[0];
         AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A38DESCRIPCIONESTADOPRODUCTO)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_23( long A6IDCATEGORIAPRODUCTO )
      {
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A6IDCATEGORIAPRODUCTO});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria_producto'.", "ForeignKeyNotFound", 1, "IDCATEGORIAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDCATEGORIAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A39DESCRIPCIONCATEGORIAPRODUCTO = T00079_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
         AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A39DESCRIPCIONCATEGORIAPRODUCTO)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_24( long A8IDMARCAPRODUCTO )
      {
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A8IDMARCAPRODUCTO});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Marca_producto'.", "ForeignKeyNotFound", 1, "IDMARCAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDMARCAPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A44DESCRIPCIONMARCAPRODUCTO = T000710_A44DESCRIPCIONMARCAPRODUCTO[0];
         AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A44DESCRIPCIONMARCAPRODUCTO)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey079( )
      {
         /* Using cursor T000711 */
         pr_default.execute(9, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM079( 21) ;
            RcdFound9 = 1;
            A7IDPRODUCTO = T00073_A7IDPRODUCTO[0];
            AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
            A40DESCRIPCIONPRODUCTO = T00073_A40DESCRIPCIONPRODUCTO[0];
            AssignAttri("", false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
            A41CANTIDADPRODUCTO = T00073_A41CANTIDADPRODUCTO[0];
            AssignAttri("", false, "A41CANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(A41CANTIDADPRODUCTO), 12, 0));
            A42PRECIOCOMPRAPRODUCTO = T00073_A42PRECIOCOMPRAPRODUCTO[0];
            AssignAttri("", false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( A42PRECIOCOMPRAPRODUCTO, 12, 2));
            A43PRECIOVENTAPRODUCTO = T00073_A43PRECIOVENTAPRODUCTO[0];
            AssignAttri("", false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrimStr( A43PRECIOVENTAPRODUCTO, 12, 2));
            A5IDESTADOPRODUCTO = T00073_A5IDESTADOPRODUCTO[0];
            AssignAttri("", false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
            A6IDCATEGORIAPRODUCTO = T00073_A6IDCATEGORIAPRODUCTO[0];
            AssignAttri("", false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
            A8IDMARCAPRODUCTO = T00073_A8IDMARCAPRODUCTO[0];
            AssignAttri("", false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
            Z7IDPRODUCTO = A7IDPRODUCTO;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load079( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey079( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey079( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey079( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000712 */
         pr_default.execute(10, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000712_A7IDPRODUCTO[0] < A7IDPRODUCTO ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000712_A7IDPRODUCTO[0] > A7IDPRODUCTO ) ) )
            {
               A7IDPRODUCTO = T000712_A7IDPRODUCTO[0];
               AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000713 */
         pr_default.execute(11, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000713_A7IDPRODUCTO[0] > A7IDPRODUCTO ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000713_A7IDPRODUCTO[0] < A7IDPRODUCTO ) ) )
            {
               A7IDPRODUCTO = T000713_A7IDPRODUCTO[0];
               AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey079( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert079( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A7IDPRODUCTO != Z7IDPRODUCTO )
               {
                  A7IDPRODUCTO = Z7IDPRODUCTO;
                  AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDPRODUCTO");
                  AnyError = 1;
                  GX_FocusControl = edtIDPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update079( ) ;
                  GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7IDPRODUCTO != Z7IDPRODUCTO )
               {
                  /* Insert record */
                  GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert079( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDPRODUCTO");
                     AnyError = 1;
                     GX_FocusControl = edtIDPRODUCTO_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert079( ) ;
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
         if ( A7IDPRODUCTO != Z7IDPRODUCTO )
         {
            A7IDPRODUCTO = Z7IDPRODUCTO;
            AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDESCRIPCIONPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency079( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A7IDPRODUCTO});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Inventario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z40DESCRIPCIONPRODUCTO, T00072_A40DESCRIPCIONPRODUCTO[0]) != 0 ) || ( Z41CANTIDADPRODUCTO != T00072_A41CANTIDADPRODUCTO[0] ) || ( Z42PRECIOCOMPRAPRODUCTO != T00072_A42PRECIOCOMPRAPRODUCTO[0] ) || ( Z43PRECIOVENTAPRODUCTO != T00072_A43PRECIOVENTAPRODUCTO[0] ) || ( Z5IDESTADOPRODUCTO != T00072_A5IDESTADOPRODUCTO[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z6IDCATEGORIAPRODUCTO != T00072_A6IDCATEGORIAPRODUCTO[0] ) || ( Z8IDMARCAPRODUCTO != T00072_A8IDMARCAPRODUCTO[0] ) )
            {
               if ( StringUtil.StrCmp(Z40DESCRIPCIONPRODUCTO, T00072_A40DESCRIPCIONPRODUCTO[0]) != 0 )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"DESCRIPCIONPRODUCTO");
                  GXUtil.WriteLogRaw("Old: ",Z40DESCRIPCIONPRODUCTO);
                  GXUtil.WriteLogRaw("Current: ",T00072_A40DESCRIPCIONPRODUCTO[0]);
               }
               if ( Z41CANTIDADPRODUCTO != T00072_A41CANTIDADPRODUCTO[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"CANTIDADPRODUCTO");
                  GXUtil.WriteLogRaw("Old: ",Z41CANTIDADPRODUCTO);
                  GXUtil.WriteLogRaw("Current: ",T00072_A41CANTIDADPRODUCTO[0]);
               }
               if ( Z42PRECIOCOMPRAPRODUCTO != T00072_A42PRECIOCOMPRAPRODUCTO[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"PRECIOCOMPRAPRODUCTO");
                  GXUtil.WriteLogRaw("Old: ",Z42PRECIOCOMPRAPRODUCTO);
                  GXUtil.WriteLogRaw("Current: ",T00072_A42PRECIOCOMPRAPRODUCTO[0]);
               }
               if ( Z43PRECIOVENTAPRODUCTO != T00072_A43PRECIOVENTAPRODUCTO[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"PRECIOVENTAPRODUCTO");
                  GXUtil.WriteLogRaw("Old: ",Z43PRECIOVENTAPRODUCTO);
                  GXUtil.WriteLogRaw("Current: ",T00072_A43PRECIOVENTAPRODUCTO[0]);
               }
               if ( Z5IDESTADOPRODUCTO != T00072_A5IDESTADOPRODUCTO[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"IDESTADOPRODUCTO");
                  GXUtil.WriteLogRaw("Old: ",Z5IDESTADOPRODUCTO);
                  GXUtil.WriteLogRaw("Current: ",T00072_A5IDESTADOPRODUCTO[0]);
               }
               if ( Z6IDCATEGORIAPRODUCTO != T00072_A6IDCATEGORIAPRODUCTO[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"IDCATEGORIAPRODUCTO");
                  GXUtil.WriteLogRaw("Old: ",Z6IDCATEGORIAPRODUCTO);
                  GXUtil.WriteLogRaw("Current: ",T00072_A6IDCATEGORIAPRODUCTO[0]);
               }
               if ( Z8IDMARCAPRODUCTO != T00072_A8IDMARCAPRODUCTO[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"IDMARCAPRODUCTO");
                  GXUtil.WriteLogRaw("Old: ",Z8IDMARCAPRODUCTO);
                  GXUtil.WriteLogRaw("Current: ",T00072_A8IDMARCAPRODUCTO[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Inventario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM079( 0) ;
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000714 */
                     pr_default.execute(12, new Object[] {A40DESCRIPCIONPRODUCTO, A41CANTIDADPRODUCTO, A42PRECIOCOMPRAPRODUCTO, A43PRECIOVENTAPRODUCTO, A5IDESTADOPRODUCTO, A6IDCATEGORIAPRODUCTO, A8IDMARCAPRODUCTO});
                     A7IDPRODUCTO = T000714_A7IDPRODUCTO[0];
                     AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Inventario");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
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
               Load079( ) ;
            }
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void Update079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000715 */
                     pr_default.execute(13, new Object[] {A40DESCRIPCIONPRODUCTO, A41CANTIDADPRODUCTO, A42PRECIOCOMPRAPRODUCTO, A43PRECIOVENTAPRODUCTO, A5IDESTADOPRODUCTO, A6IDCATEGORIAPRODUCTO, A8IDMARCAPRODUCTO, A7IDPRODUCTO});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Inventario");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Inventario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate079( ) ;
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
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void DeferredUpdate079( )
      {
      }

      protected void delete( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls079( ) ;
            AfterConfirm079( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete079( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000716 */
                  pr_default.execute(14, new Object[] {A7IDPRODUCTO});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("Inventario");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel079( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls079( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "Inventario";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000717 */
            pr_default.execute(15, new Object[] {A5IDESTADOPRODUCTO});
            A38DESCRIPCIONESTADOPRODUCTO = T000717_A38DESCRIPCIONESTADOPRODUCTO[0];
            AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
            pr_default.close(15);
            /* Using cursor T000718 */
            pr_default.execute(16, new Object[] {A6IDCATEGORIAPRODUCTO});
            A39DESCRIPCIONCATEGORIAPRODUCTO = T000718_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
            AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
            pr_default.close(16);
            /* Using cursor T000719 */
            pr_default.execute(17, new Object[] {A8IDMARCAPRODUCTO});
            A44DESCRIPCIONMARCAPRODUCTO = T000719_A44DESCRIPCIONMARCAPRODUCTO[0];
            AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000720 */
            pr_default.execute(18, new Object[] {A7IDPRODUCTO});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle_venta_producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000721 */
            pr_default.execute(19, new Object[] {A7IDPRODUCTO});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle_compra_producto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel079( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete079( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.CommitDataStores("inventario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.RollbackDataStores("inventario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart079( )
      {
         /* Scan By routine */
         /* Using cursor T000722 */
         pr_default.execute(20);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound9 = 1;
            A7IDPRODUCTO = T000722_A7IDPRODUCTO[0];
            AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext079( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound9 = 1;
            A7IDPRODUCTO = T000722_A7IDPRODUCTO[0];
            AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
         }
      }

      protected void ScanEnd079( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm079( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert079( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate079( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete079( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete079( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate079( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes079( )
      {
         edtIDPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), true);
         edtDESCRIPCIONPRODUCTO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0), true);
         edtCANTIDADPRODUCTO_Enabled = 0;
         AssignProp("", false, edtCANTIDADPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0), true);
         edtPRECIOCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtPRECIOCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOCOMPRAPRODUCTO_Enabled), 5, 0), true);
         edtPRECIOVENTAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtPRECIOVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0), true);
         edtIDESTADOPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDESTADOPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDESTADOPRODUCTO_Enabled), 5, 0), true);
         edtDESCRIPCIONESTADOPRODUCTO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONESTADOPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONESTADOPRODUCTO_Enabled), 5, 0), true);
         edtIDCATEGORIAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDCATEGORIAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCATEGORIAPRODUCTO_Enabled), 5, 0), true);
         edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled), 5, 0), true);
         edtIDMARCAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDMARCAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDMARCAPRODUCTO_Enabled), 5, 0), true);
         edtDESCRIPCIONMARCAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONMARCAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONMARCAPRODUCTO_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes079( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.AddJavascriptSource("gxcfg.js", "?2021113013582772", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDPRODUCTO,12,0))}, new string[] {"Gx_mode","IDPRODUCTO"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Inventario");
         forbiddenHiddens.Add("IDPRODUCTO", context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("inventario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7IDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7IDPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z40DESCRIPCIONPRODUCTO", Z40DESCRIPCIONPRODUCTO);
         GxWebStd.gx_hidden_field( context, "Z41CANTIDADPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41CANTIDADPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42PRECIOCOMPRAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( Z42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z43PRECIOVENTAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( Z43PRECIOVENTAPRODUCTO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5IDESTADOPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5IDESTADOPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z6IDCATEGORIAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6IDCATEGORIAPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8IDMARCAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8IDMARCAPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N5IDESTADOPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5IDESTADOPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N6IDCATEGORIAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N8IDMARCAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8IDMARCAPRODUCTO), 12, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vIDPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDPRODUCTO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDPRODUCTO), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDESTADOPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_IDESTADOPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDCATEGORIAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_IDCATEGORIAPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDMARCAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_IDMARCAPRODUCTO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         return formatLink("inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDPRODUCTO,12,0))}, new string[] {"Gx_mode","IDPRODUCTO"})  ;
      }

      public override string GetPgmname( )
      {
         return "Inventario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inventario" ;
      }

      protected void InitializeNonKey079( )
      {
         A5IDESTADOPRODUCTO = 0;
         AssignAttri("", false, "A5IDESTADOPRODUCTO", StringUtil.LTrimStr( (decimal)(A5IDESTADOPRODUCTO), 12, 0));
         A6IDCATEGORIAPRODUCTO = 0;
         AssignAttri("", false, "A6IDCATEGORIAPRODUCTO", StringUtil.LTrimStr( (decimal)(A6IDCATEGORIAPRODUCTO), 12, 0));
         A8IDMARCAPRODUCTO = 0;
         AssignAttri("", false, "A8IDMARCAPRODUCTO", StringUtil.LTrimStr( (decimal)(A8IDMARCAPRODUCTO), 12, 0));
         A40DESCRIPCIONPRODUCTO = "";
         AssignAttri("", false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
         A41CANTIDADPRODUCTO = 0;
         AssignAttri("", false, "A41CANTIDADPRODUCTO", StringUtil.LTrimStr( (decimal)(A41CANTIDADPRODUCTO), 12, 0));
         A42PRECIOCOMPRAPRODUCTO = 0;
         AssignAttri("", false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrimStr( A42PRECIOCOMPRAPRODUCTO, 12, 2));
         A43PRECIOVENTAPRODUCTO = 0;
         AssignAttri("", false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrimStr( A43PRECIOVENTAPRODUCTO, 12, 2));
         A38DESCRIPCIONESTADOPRODUCTO = "";
         AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
         A39DESCRIPCIONCATEGORIAPRODUCTO = "";
         AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
         A44DESCRIPCIONMARCAPRODUCTO = "";
         AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
         Z40DESCRIPCIONPRODUCTO = "";
         Z41CANTIDADPRODUCTO = 0;
         Z42PRECIOCOMPRAPRODUCTO = 0;
         Z43PRECIOVENTAPRODUCTO = 0;
         Z5IDESTADOPRODUCTO = 0;
         Z6IDCATEGORIAPRODUCTO = 0;
         Z8IDMARCAPRODUCTO = 0;
      }

      protected void InitAll079( )
      {
         A7IDPRODUCTO = 0;
         AssignAttri("", false, "A7IDPRODUCTO", StringUtil.LTrimStr( (decimal)(A7IDPRODUCTO), 12, 0));
         InitializeNonKey079( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021113013582780", true, true);
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
         context.AddJavascriptSource("inventario.js", "?2021113013582780", false, true);
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
         edtIDPRODUCTO_Internalname = "IDPRODUCTO";
         edtDESCRIPCIONPRODUCTO_Internalname = "DESCRIPCIONPRODUCTO";
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO";
         edtPRECIOCOMPRAPRODUCTO_Internalname = "PRECIOCOMPRAPRODUCTO";
         edtPRECIOVENTAPRODUCTO_Internalname = "PRECIOVENTAPRODUCTO";
         edtIDESTADOPRODUCTO_Internalname = "IDESTADOPRODUCTO";
         edtDESCRIPCIONESTADOPRODUCTO_Internalname = "DESCRIPCIONESTADOPRODUCTO";
         edtIDCATEGORIAPRODUCTO_Internalname = "IDCATEGORIAPRODUCTO";
         edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname = "DESCRIPCIONCATEGORIAPRODUCTO";
         edtIDMARCAPRODUCTO_Internalname = "IDMARCAPRODUCTO";
         edtDESCRIPCIONMARCAPRODUCTO_Internalname = "DESCRIPCIONMARCAPRODUCTO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
         imgprompt_6_Internalname = "PROMPT_6";
         imgprompt_8_Internalname = "PROMPT_8";
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
         Form.Caption = "Inventario";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDESCRIPCIONMARCAPRODUCTO_Enabled = 0;
         imgprompt_8_Visible = 1;
         imgprompt_8_Link = "";
         edtIDMARCAPRODUCTO_Jsonclick = "";
         edtIDMARCAPRODUCTO_Enabled = 1;
         edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled = 0;
         imgprompt_6_Visible = 1;
         imgprompt_6_Link = "";
         edtIDCATEGORIAPRODUCTO_Jsonclick = "";
         edtIDCATEGORIAPRODUCTO_Enabled = 1;
         edtDESCRIPCIONESTADOPRODUCTO_Enabled = 0;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtIDESTADOPRODUCTO_Jsonclick = "";
         edtIDESTADOPRODUCTO_Enabled = 1;
         edtPRECIOVENTAPRODUCTO_Jsonclick = "";
         edtPRECIOVENTAPRODUCTO_Enabled = 1;
         edtPRECIOCOMPRAPRODUCTO_Jsonclick = "";
         edtPRECIOCOMPRAPRODUCTO_Enabled = 1;
         edtCANTIDADPRODUCTO_Jsonclick = "";
         edtCANTIDADPRODUCTO_Enabled = 1;
         edtDESCRIPCIONPRODUCTO_Enabled = 1;
         edtIDPRODUCTO_Jsonclick = "";
         edtIDPRODUCTO_Enabled = 0;
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

      public void Valid_Idestadoproducto( )
      {
         /* Using cursor T000717 */
         pr_default.execute(15, new Object[] {A5IDESTADOPRODUCTO});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Estado_producto'.", "ForeignKeyNotFound", 1, "IDESTADOPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOPRODUCTO_Internalname;
         }
         A38DESCRIPCIONESTADOPRODUCTO = T000717_A38DESCRIPCIONESTADOPRODUCTO[0];
         pr_default.close(15);
         if ( (0==A5IDESTADOPRODUCTO) )
         {
            GX_msglist.addItem("Seleccione el estado del producto", 1, "IDESTADOPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDESTADOPRODUCTO_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A38DESCRIPCIONESTADOPRODUCTO", A38DESCRIPCIONESTADOPRODUCTO);
      }

      public void Valid_Idcategoriaproducto( )
      {
         /* Using cursor T000718 */
         pr_default.execute(16, new Object[] {A6IDCATEGORIAPRODUCTO});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria_producto'.", "ForeignKeyNotFound", 1, "IDCATEGORIAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDCATEGORIAPRODUCTO_Internalname;
         }
         A39DESCRIPCIONCATEGORIAPRODUCTO = T000718_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
         pr_default.close(16);
         if ( (0==A6IDCATEGORIAPRODUCTO) )
         {
            GX_msglist.addItem("Seleccione la categoria del producto", 1, "IDCATEGORIAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDCATEGORIAPRODUCTO_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A39DESCRIPCIONCATEGORIAPRODUCTO", A39DESCRIPCIONCATEGORIAPRODUCTO);
      }

      public void Valid_Idmarcaproducto( )
      {
         /* Using cursor T000719 */
         pr_default.execute(17, new Object[] {A8IDMARCAPRODUCTO});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Marca_producto'.", "ForeignKeyNotFound", 1, "IDMARCAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDMARCAPRODUCTO_Internalname;
         }
         A44DESCRIPCIONMARCAPRODUCTO = T000719_A44DESCRIPCIONMARCAPRODUCTO[0];
         pr_default.close(17);
         if ( (0==A8IDMARCAPRODUCTO) )
         {
            GX_msglist.addItem("Seleccione la marca del producto", 1, "IDMARCAPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDMARCAPRODUCTO_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A44DESCRIPCIONMARCAPRODUCTO", A44DESCRIPCIONMARCAPRODUCTO);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IDPRODUCTO',fld:'vIDPRODUCTO',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IDPRODUCTO',fld:'vIDPRODUCTO',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A7IDPRODUCTO',fld:'IDPRODUCTO',pic:'ZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_IDPRODUCTO","{handler:'Valid_Idproducto',iparms:[]");
         setEventMetadata("VALID_IDPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_DESCRIPCIONPRODUCTO","{handler:'Valid_Descripcionproducto',iparms:[]");
         setEventMetadata("VALID_DESCRIPCIONPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_CANTIDADPRODUCTO","{handler:'Valid_Cantidadproducto',iparms:[]");
         setEventMetadata("VALID_CANTIDADPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_PRECIOCOMPRAPRODUCTO","{handler:'Valid_Preciocompraproducto',iparms:[]");
         setEventMetadata("VALID_PRECIOCOMPRAPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_PRECIOVENTAPRODUCTO","{handler:'Valid_Precioventaproducto',iparms:[]");
         setEventMetadata("VALID_PRECIOVENTAPRODUCTO",",oparms:[]}");
         setEventMetadata("VALID_IDESTADOPRODUCTO","{handler:'Valid_Idestadoproducto',iparms:[{av:'A5IDESTADOPRODUCTO',fld:'IDESTADOPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A38DESCRIPCIONESTADOPRODUCTO',fld:'DESCRIPCIONESTADOPRODUCTO',pic:''}]");
         setEventMetadata("VALID_IDESTADOPRODUCTO",",oparms:[{av:'A38DESCRIPCIONESTADOPRODUCTO',fld:'DESCRIPCIONESTADOPRODUCTO',pic:''}]}");
         setEventMetadata("VALID_IDCATEGORIAPRODUCTO","{handler:'Valid_Idcategoriaproducto',iparms:[{av:'A6IDCATEGORIAPRODUCTO',fld:'IDCATEGORIAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A39DESCRIPCIONCATEGORIAPRODUCTO',fld:'DESCRIPCIONCATEGORIAPRODUCTO',pic:''}]");
         setEventMetadata("VALID_IDCATEGORIAPRODUCTO",",oparms:[{av:'A39DESCRIPCIONCATEGORIAPRODUCTO',fld:'DESCRIPCIONCATEGORIAPRODUCTO',pic:''}]}");
         setEventMetadata("VALID_IDMARCAPRODUCTO","{handler:'Valid_Idmarcaproducto',iparms:[{av:'A8IDMARCAPRODUCTO',fld:'IDMARCAPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A44DESCRIPCIONMARCAPRODUCTO',fld:'DESCRIPCIONMARCAPRODUCTO',pic:''}]");
         setEventMetadata("VALID_IDMARCAPRODUCTO",",oparms:[{av:'A44DESCRIPCIONMARCAPRODUCTO',fld:'DESCRIPCIONMARCAPRODUCTO',pic:''}]}");
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
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z40DESCRIPCIONPRODUCTO = "";
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
         A40DESCRIPCIONPRODUCTO = "";
         sImgUrl = "";
         A38DESCRIPCIONESTADOPRODUCTO = "";
         A39DESCRIPCIONCATEGORIAPRODUCTO = "";
         A44DESCRIPCIONMARCAPRODUCTO = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z38DESCRIPCIONESTADOPRODUCTO = "";
         Z39DESCRIPCIONCATEGORIAPRODUCTO = "";
         Z44DESCRIPCIONMARCAPRODUCTO = "";
         T00076_A44DESCRIPCIONMARCAPRODUCTO = new string[] {""} ;
         T00075_A39DESCRIPCIONCATEGORIAPRODUCTO = new string[] {""} ;
         T00074_A38DESCRIPCIONESTADOPRODUCTO = new string[] {""} ;
         T00077_A7IDPRODUCTO = new long[1] ;
         T00077_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T00077_A41CANTIDADPRODUCTO = new long[1] ;
         T00077_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         T00077_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         T00077_A38DESCRIPCIONESTADOPRODUCTO = new string[] {""} ;
         T00077_A39DESCRIPCIONCATEGORIAPRODUCTO = new string[] {""} ;
         T00077_A44DESCRIPCIONMARCAPRODUCTO = new string[] {""} ;
         T00077_A5IDESTADOPRODUCTO = new long[1] ;
         T00077_A6IDCATEGORIAPRODUCTO = new long[1] ;
         T00077_A8IDMARCAPRODUCTO = new long[1] ;
         T00078_A38DESCRIPCIONESTADOPRODUCTO = new string[] {""} ;
         T00079_A39DESCRIPCIONCATEGORIAPRODUCTO = new string[] {""} ;
         T000710_A44DESCRIPCIONMARCAPRODUCTO = new string[] {""} ;
         T000711_A7IDPRODUCTO = new long[1] ;
         T00073_A7IDPRODUCTO = new long[1] ;
         T00073_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T00073_A41CANTIDADPRODUCTO = new long[1] ;
         T00073_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         T00073_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         T00073_A5IDESTADOPRODUCTO = new long[1] ;
         T00073_A6IDCATEGORIAPRODUCTO = new long[1] ;
         T00073_A8IDMARCAPRODUCTO = new long[1] ;
         T000712_A7IDPRODUCTO = new long[1] ;
         T000713_A7IDPRODUCTO = new long[1] ;
         T00072_A7IDPRODUCTO = new long[1] ;
         T00072_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T00072_A41CANTIDADPRODUCTO = new long[1] ;
         T00072_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         T00072_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         T00072_A5IDESTADOPRODUCTO = new long[1] ;
         T00072_A6IDCATEGORIAPRODUCTO = new long[1] ;
         T00072_A8IDMARCAPRODUCTO = new long[1] ;
         T000714_A7IDPRODUCTO = new long[1] ;
         T000717_A38DESCRIPCIONESTADOPRODUCTO = new string[] {""} ;
         T000718_A39DESCRIPCIONCATEGORIAPRODUCTO = new string[] {""} ;
         T000719_A44DESCRIPCIONMARCAPRODUCTO = new string[] {""} ;
         T000720_A12IDVENTA = new long[1] ;
         T000720_A66IDDETALLEVENTAPRODUCTO = new long[1] ;
         T000721_A11IDCOMPRA = new long[1] ;
         T000721_A65IDETALLECOMPRAPRODUCTO = new long[1] ;
         T000722_A7IDPRODUCTO = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventario__default(),
            new Object[][] {
                new Object[] {
               T00072_A7IDPRODUCTO, T00072_A40DESCRIPCIONPRODUCTO, T00072_A41CANTIDADPRODUCTO, T00072_A42PRECIOCOMPRAPRODUCTO, T00072_A43PRECIOVENTAPRODUCTO, T00072_A5IDESTADOPRODUCTO, T00072_A6IDCATEGORIAPRODUCTO, T00072_A8IDMARCAPRODUCTO
               }
               , new Object[] {
               T00073_A7IDPRODUCTO, T00073_A40DESCRIPCIONPRODUCTO, T00073_A41CANTIDADPRODUCTO, T00073_A42PRECIOCOMPRAPRODUCTO, T00073_A43PRECIOVENTAPRODUCTO, T00073_A5IDESTADOPRODUCTO, T00073_A6IDCATEGORIAPRODUCTO, T00073_A8IDMARCAPRODUCTO
               }
               , new Object[] {
               T00074_A38DESCRIPCIONESTADOPRODUCTO
               }
               , new Object[] {
               T00075_A39DESCRIPCIONCATEGORIAPRODUCTO
               }
               , new Object[] {
               T00076_A44DESCRIPCIONMARCAPRODUCTO
               }
               , new Object[] {
               T00077_A7IDPRODUCTO, T00077_A40DESCRIPCIONPRODUCTO, T00077_A41CANTIDADPRODUCTO, T00077_A42PRECIOCOMPRAPRODUCTO, T00077_A43PRECIOVENTAPRODUCTO, T00077_A38DESCRIPCIONESTADOPRODUCTO, T00077_A39DESCRIPCIONCATEGORIAPRODUCTO, T00077_A44DESCRIPCIONMARCAPRODUCTO, T00077_A5IDESTADOPRODUCTO, T00077_A6IDCATEGORIAPRODUCTO,
               T00077_A8IDMARCAPRODUCTO
               }
               , new Object[] {
               T00078_A38DESCRIPCIONESTADOPRODUCTO
               }
               , new Object[] {
               T00079_A39DESCRIPCIONCATEGORIAPRODUCTO
               }
               , new Object[] {
               T000710_A44DESCRIPCIONMARCAPRODUCTO
               }
               , new Object[] {
               T000711_A7IDPRODUCTO
               }
               , new Object[] {
               T000712_A7IDPRODUCTO
               }
               , new Object[] {
               T000713_A7IDPRODUCTO
               }
               , new Object[] {
               T000714_A7IDPRODUCTO
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000717_A38DESCRIPCIONESTADOPRODUCTO
               }
               , new Object[] {
               T000718_A39DESCRIPCIONCATEGORIAPRODUCTO
               }
               , new Object[] {
               T000719_A44DESCRIPCIONMARCAPRODUCTO
               }
               , new Object[] {
               T000720_A12IDVENTA, T000720_A66IDDETALLEVENTAPRODUCTO
               }
               , new Object[] {
               T000721_A11IDCOMPRA, T000721_A65IDETALLECOMPRAPRODUCTO
               }
               , new Object[] {
               T000722_A7IDPRODUCTO
               }
            }
         );
         AV15Pgmname = "Inventario";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_9 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIDPRODUCTO_Enabled ;
      private int edtDESCRIPCIONPRODUCTO_Enabled ;
      private int edtCANTIDADPRODUCTO_Enabled ;
      private int edtPRECIOCOMPRAPRODUCTO_Enabled ;
      private int edtPRECIOVENTAPRODUCTO_Enabled ;
      private int edtIDESTADOPRODUCTO_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtDESCRIPCIONESTADOPRODUCTO_Enabled ;
      private int edtIDCATEGORIAPRODUCTO_Enabled ;
      private int imgprompt_6_Visible ;
      private int edtDESCRIPCIONCATEGORIAPRODUCTO_Enabled ;
      private int edtIDMARCAPRODUCTO_Enabled ;
      private int imgprompt_8_Visible ;
      private int edtDESCRIPCIONMARCAPRODUCTO_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV16GXV1 ;
      private int idxLst ;
      private long wcpOAV7IDPRODUCTO ;
      private long Z7IDPRODUCTO ;
      private long Z41CANTIDADPRODUCTO ;
      private long Z5IDESTADOPRODUCTO ;
      private long Z6IDCATEGORIAPRODUCTO ;
      private long Z8IDMARCAPRODUCTO ;
      private long N5IDESTADOPRODUCTO ;
      private long N6IDCATEGORIAPRODUCTO ;
      private long N8IDMARCAPRODUCTO ;
      private long A5IDESTADOPRODUCTO ;
      private long A6IDCATEGORIAPRODUCTO ;
      private long A8IDMARCAPRODUCTO ;
      private long AV7IDPRODUCTO ;
      private long A7IDPRODUCTO ;
      private long A41CANTIDADPRODUCTO ;
      private long AV11Insert_IDESTADOPRODUCTO ;
      private long AV12Insert_IDCATEGORIAPRODUCTO ;
      private long AV13Insert_IDMARCAPRODUCTO ;
      private decimal Z42PRECIOCOMPRAPRODUCTO ;
      private decimal Z43PRECIOVENTAPRODUCTO ;
      private decimal A42PRECIOCOMPRAPRODUCTO ;
      private decimal A43PRECIOVENTAPRODUCTO ;
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
      private string edtDESCRIPCIONPRODUCTO_Internalname ;
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
      private string edtIDPRODUCTO_Internalname ;
      private string edtIDPRODUCTO_Jsonclick ;
      private string edtCANTIDADPRODUCTO_Internalname ;
      private string edtCANTIDADPRODUCTO_Jsonclick ;
      private string edtPRECIOCOMPRAPRODUCTO_Internalname ;
      private string edtPRECIOCOMPRAPRODUCTO_Jsonclick ;
      private string edtPRECIOVENTAPRODUCTO_Internalname ;
      private string edtPRECIOVENTAPRODUCTO_Jsonclick ;
      private string edtIDESTADOPRODUCTO_Internalname ;
      private string edtIDESTADOPRODUCTO_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtDESCRIPCIONESTADOPRODUCTO_Internalname ;
      private string edtIDCATEGORIAPRODUCTO_Internalname ;
      private string edtIDCATEGORIAPRODUCTO_Jsonclick ;
      private string imgprompt_6_Internalname ;
      private string imgprompt_6_Link ;
      private string edtDESCRIPCIONCATEGORIAPRODUCTO_Internalname ;
      private string edtIDMARCAPRODUCTO_Internalname ;
      private string edtIDMARCAPRODUCTO_Jsonclick ;
      private string imgprompt_8_Internalname ;
      private string imgprompt_8_Link ;
      private string edtDESCRIPCIONMARCAPRODUCTO_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode9 ;
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
      private bool Gx_longc ;
      private string Z40DESCRIPCIONPRODUCTO ;
      private string A40DESCRIPCIONPRODUCTO ;
      private string A38DESCRIPCIONESTADOPRODUCTO ;
      private string A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string A44DESCRIPCIONMARCAPRODUCTO ;
      private string Z38DESCRIPCIONESTADOPRODUCTO ;
      private string Z39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string Z44DESCRIPCIONMARCAPRODUCTO ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00076_A44DESCRIPCIONMARCAPRODUCTO ;
      private string[] T00075_A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string[] T00074_A38DESCRIPCIONESTADOPRODUCTO ;
      private long[] T00077_A7IDPRODUCTO ;
      private string[] T00077_A40DESCRIPCIONPRODUCTO ;
      private long[] T00077_A41CANTIDADPRODUCTO ;
      private decimal[] T00077_A42PRECIOCOMPRAPRODUCTO ;
      private decimal[] T00077_A43PRECIOVENTAPRODUCTO ;
      private string[] T00077_A38DESCRIPCIONESTADOPRODUCTO ;
      private string[] T00077_A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string[] T00077_A44DESCRIPCIONMARCAPRODUCTO ;
      private long[] T00077_A5IDESTADOPRODUCTO ;
      private long[] T00077_A6IDCATEGORIAPRODUCTO ;
      private long[] T00077_A8IDMARCAPRODUCTO ;
      private string[] T00078_A38DESCRIPCIONESTADOPRODUCTO ;
      private string[] T00079_A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string[] T000710_A44DESCRIPCIONMARCAPRODUCTO ;
      private long[] T000711_A7IDPRODUCTO ;
      private long[] T00073_A7IDPRODUCTO ;
      private string[] T00073_A40DESCRIPCIONPRODUCTO ;
      private long[] T00073_A41CANTIDADPRODUCTO ;
      private decimal[] T00073_A42PRECIOCOMPRAPRODUCTO ;
      private decimal[] T00073_A43PRECIOVENTAPRODUCTO ;
      private long[] T00073_A5IDESTADOPRODUCTO ;
      private long[] T00073_A6IDCATEGORIAPRODUCTO ;
      private long[] T00073_A8IDMARCAPRODUCTO ;
      private long[] T000712_A7IDPRODUCTO ;
      private long[] T000713_A7IDPRODUCTO ;
      private long[] T00072_A7IDPRODUCTO ;
      private string[] T00072_A40DESCRIPCIONPRODUCTO ;
      private long[] T00072_A41CANTIDADPRODUCTO ;
      private decimal[] T00072_A42PRECIOCOMPRAPRODUCTO ;
      private decimal[] T00072_A43PRECIOVENTAPRODUCTO ;
      private long[] T00072_A5IDESTADOPRODUCTO ;
      private long[] T00072_A6IDCATEGORIAPRODUCTO ;
      private long[] T00072_A8IDMARCAPRODUCTO ;
      private long[] T000714_A7IDPRODUCTO ;
      private string[] T000717_A38DESCRIPCIONESTADOPRODUCTO ;
      private string[] T000718_A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string[] T000719_A44DESCRIPCIONMARCAPRODUCTO ;
      private long[] T000720_A12IDVENTA ;
      private long[] T000720_A66IDDETALLEVENTAPRODUCTO ;
      private long[] T000721_A11IDCOMPRA ;
      private long[] T000721_A65IDETALLECOMPRAPRODUCTO ;
      private long[] T000722_A7IDPRODUCTO ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class inventario__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@IDESTADOPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@IDCATEGORIAPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@IDMARCAPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@IDESTADOPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@IDCATEGORIAPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@IDMARCAPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@DESCRIPCIONPRODUCTO",GXType.NVarChar,255,0) ,
          new ParDef("@CANTIDADPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@PRECIOCOMPRAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@PRECIOVENTAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@IDESTADOPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@IDCATEGORIAPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@IDMARCAPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@DESCRIPCIONPRODUCTO",GXType.NVarChar,255,0) ,
          new ParDef("@CANTIDADPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@PRECIOCOMPRAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@PRECIOVENTAPRODUCTO",GXType.Decimal,12,2) ,
          new ParDef("@IDESTADOPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@IDCATEGORIAPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@IDMARCAPRODUCTO",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000720;
          prmT000720 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000721;
          prmT000721 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000722;
          prmT000722 = new Object[] {
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          new ParDef("@IDESTADOPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@IDCATEGORIAPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          new ParDef("@IDMARCAPRODUCTO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [IDPRODUCTO], [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOCOMPRAPRODUCTO], [PRECIOVENTAPRODUCTO], [IDESTADOPRODUCTO], [IDCATEGORIAPRODUCTO], [IDMARCAPRODUCTO] FROM [Inventario] WITH (UPDLOCK) WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [IDPRODUCTO], [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOCOMPRAPRODUCTO], [PRECIOVENTAPRODUCTO], [IDESTADOPRODUCTO], [IDCATEGORIAPRODUCTO], [IDMARCAPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [DESCRIPCIONESTADOPRODUCTO] FROM [Estado_producto] WHERE [IDESTADOPRODUCTO] = @IDESTADOPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [DESCRIPCIONCATEGORIAPRODUCTO] FROM [Categoria_producto] WHERE [IDCATEGORIAPRODUCTO] = @IDCATEGORIAPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [DESCRIPCIONMARCAPRODUCTO] FROM [Marca_producto] WHERE [IDMARCAPRODUCTO] = @IDMARCAPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT TM1.[IDPRODUCTO], TM1.[DESCRIPCIONPRODUCTO], TM1.[CANTIDADPRODUCTO], TM1.[PRECIOCOMPRAPRODUCTO], TM1.[PRECIOVENTAPRODUCTO], T2.[DESCRIPCIONESTADOPRODUCTO], T3.[DESCRIPCIONCATEGORIAPRODUCTO], T4.[DESCRIPCIONMARCAPRODUCTO], TM1.[IDESTADOPRODUCTO], TM1.[IDCATEGORIAPRODUCTO], TM1.[IDMARCAPRODUCTO] FROM ((([Inventario] TM1 INNER JOIN [Estado_producto] T2 ON T2.[IDESTADOPRODUCTO] = TM1.[IDESTADOPRODUCTO]) INNER JOIN [Categoria_producto] T3 ON T3.[IDCATEGORIAPRODUCTO] = TM1.[IDCATEGORIAPRODUCTO]) INNER JOIN [Marca_producto] T4 ON T4.[IDMARCAPRODUCTO] = TM1.[IDMARCAPRODUCTO]) WHERE TM1.[IDPRODUCTO] = @IDPRODUCTO ORDER BY TM1.[IDPRODUCTO]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT [DESCRIPCIONESTADOPRODUCTO] FROM [Estado_producto] WHERE [IDESTADOPRODUCTO] = @IDESTADOPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT [DESCRIPCIONCATEGORIAPRODUCTO] FROM [Categoria_producto] WHERE [IDCATEGORIAPRODUCTO] = @IDCATEGORIAPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000710", "SELECT [DESCRIPCIONMARCAPRODUCTO] FROM [Marca_producto] WHERE [IDMARCAPRODUCTO] = @IDMARCAPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000711", "SELECT [IDPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000712", "SELECT TOP 1 [IDPRODUCTO] FROM [Inventario] WHERE ( [IDPRODUCTO] > @IDPRODUCTO) ORDER BY [IDPRODUCTO]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000713", "SELECT TOP 1 [IDPRODUCTO] FROM [Inventario] WHERE ( [IDPRODUCTO] < @IDPRODUCTO) ORDER BY [IDPRODUCTO] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000714", "INSERT INTO [Inventario]([DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOCOMPRAPRODUCTO], [PRECIOVENTAPRODUCTO], [IDESTADOPRODUCTO], [IDCATEGORIAPRODUCTO], [IDMARCAPRODUCTO]) VALUES(@DESCRIPCIONPRODUCTO, @CANTIDADPRODUCTO, @PRECIOCOMPRAPRODUCTO, @PRECIOVENTAPRODUCTO, @IDESTADOPRODUCTO, @IDCATEGORIAPRODUCTO, @IDMARCAPRODUCTO); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000714)
             ,new CursorDef("T000715", "UPDATE [Inventario] SET [DESCRIPCIONPRODUCTO]=@DESCRIPCIONPRODUCTO, [CANTIDADPRODUCTO]=@CANTIDADPRODUCTO, [PRECIOCOMPRAPRODUCTO]=@PRECIOCOMPRAPRODUCTO, [PRECIOVENTAPRODUCTO]=@PRECIOVENTAPRODUCTO, [IDESTADOPRODUCTO]=@IDESTADOPRODUCTO, [IDCATEGORIAPRODUCTO]=@IDCATEGORIAPRODUCTO, [IDMARCAPRODUCTO]=@IDMARCAPRODUCTO  WHERE [IDPRODUCTO] = @IDPRODUCTO", GxErrorMask.GX_NOMASK,prmT000715)
             ,new CursorDef("T000716", "DELETE FROM [Inventario]  WHERE [IDPRODUCTO] = @IDPRODUCTO", GxErrorMask.GX_NOMASK,prmT000716)
             ,new CursorDef("T000717", "SELECT [DESCRIPCIONESTADOPRODUCTO] FROM [Estado_producto] WHERE [IDESTADOPRODUCTO] = @IDESTADOPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000718", "SELECT [DESCRIPCIONCATEGORIAPRODUCTO] FROM [Categoria_producto] WHERE [IDCATEGORIAPRODUCTO] = @IDCATEGORIAPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000719", "SELECT [DESCRIPCIONMARCAPRODUCTO] FROM [Marca_producto] WHERE [IDMARCAPRODUCTO] = @IDMARCAPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000719,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000720", "SELECT TOP 1 [IDVENTA], [IDDETALLEVENTAPRODUCTO] FROM [Ventas_inventarioDetalle_venta] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000720,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000721", "SELECT TOP 1 [IDCOMPRA], [IDETALLECOMPRAPRODUCTO] FROM [Compra_inventarioDetalle_compr] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000721,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000722", "SELECT [IDPRODUCTO] FROM [Inventario] ORDER BY [IDPRODUCTO]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 19 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 20 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
