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
   public class compra_inventario : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A11IDCOMPRA = (long)(NumberUtil.Val( GetPar( "IDCOMPRA"), "."));
            AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A11IDCOMPRA) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A10IDPROVEEDOR = (long)(NumberUtil.Val( GetPar( "IDPROVEEDOR"), "."));
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A10IDPROVEEDOR) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A1IDEMPLEADO = (long)(NumberUtil.Val( GetPar( "IDEMPLEADO"), "."));
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A1IDEMPLEADO) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A7IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A7IDPRODUCTO) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A7IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A7IDPRODUCTO) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcompra_inventario_detalle_compra_producto") == 0 )
         {
            nRC_GXsfl_73 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_73"), "."));
            nGXsfl_73_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_73_idx"), "."));
            sGXsfl_73_idx = GetPar( "sGXsfl_73_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridcompra_inventario_detalle_compra_producto_newrow( ) ;
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
               AV7IDCOMPRA = (long)(NumberUtil.Val( GetPar( "IDCOMPRA"), "."));
               AssignAttri("", false, "AV7IDCOMPRA", StringUtil.LTrimStr( (decimal)(AV7IDCOMPRA), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDCOMPRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDCOMPRA), "ZZZZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Compra_inventario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public compra_inventario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public compra_inventario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IDCOMPRA )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IDCOMPRA = aP1_IDCOMPRA;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Compra_inventario", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Compra_inventario.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Compra_inventario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDCOMPRA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDCOMPRA_Internalname, "IDCOMPRA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIDCOMPRA_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11IDCOMPRA), 12, 0, ".", "")), ((edtIDCOMPRA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCOMPRA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDCOMPRA_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHACOMPRA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFECHACOMPRA_Internalname, "FECHACOMPRA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtFECHACOMPRA_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFECHACOMPRA_Internalname, context.localUtil.Format(A50FECHACOMPRA, "99/99/99"), context.localUtil.Format( A50FECHACOMPRA, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHACOMPRA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFECHACOMPRA_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Compra_inventario.htm");
         GxWebStd.gx_bitmap( context, edtFECHACOMPRA_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHACOMPRA_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Compra_inventario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONCOMPRA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONCOMPRA_Internalname, "DESCRIPCIONCOMPRA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONCOMPRA_Internalname, A51DESCRIPCIONCOMPRA, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtDESCRIPCIONCOMPRA_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDPROVEEDOR_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDPROVEEDOR_Internalname, "IDPROVEEDOR", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDPROVEEDOR_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10IDPROVEEDOR), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A10IDPROVEEDOR), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDPROVEEDOR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDPROVEEDOR_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Compra_inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_10_Internalname, sImgUrl, imgprompt_10_Link, "", "", context.GetTheme( ), imgprompt_10_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Compra_inventario.htm");
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
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOMBREPROVEEDOR_Internalname, A46NOMBREPROVEEDOR, "", "", 0, 1, edtNOMBREPROVEEDOR_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDEMPLEADO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDEMPLEADO_Internalname, "IDEMPLEADO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDEMPLEADO_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Compra_inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Compra_inventario.htm");
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
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, A23NOMBRECOMPLETOEMPLEADO, "", "", 0, 1, edtNOMBRECOMPLETOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDetalle_compra_productotable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitledetalle_compra_producto_Internalname, "Detalle_compra_producto", "", "", lblTitledetalle_compra_producto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridcompra_inventario_detalle_compra_producto( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTOTALCOMPRAPRODUCTO_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTOTALCOMPRAPRODUCTO_Internalname, "TOTALCOMPRAPRODUCTO", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTOTALCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A61TOTALCOMPRAPRODUCTO, 12, 2, ".", "")), ((edtTOTALCOMPRAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A61TOTALCOMPRAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A61TOTALCOMPRAPRODUCTO, "ZZZZZZZZ9.99")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTOTALCOMPRAPRODUCTO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTOTALCOMPRAPRODUCTO_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Compra_inventario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Compra_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridcompra_inventario_detalle_compra_producto( )
      {
         /*  Grid Control  */
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("GridName", "Gridcompra_inventario_detalle_compra_producto");
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Header", subGridcompra_inventario_detalle_compra_producto_Header);
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Class", "Grid");
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Backcolorstyle), 1, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("CmpContext", "");
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("InMasterPage", "false");
         Gridcompra_inventario_detalle_compra_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddColumnProperties(Gridcompra_inventario_detalle_compra_productoColumn);
         Gridcompra_inventario_detalle_compra_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcompra_inventario_detalle_compra_productoContainer.AddColumnProperties(Gridcompra_inventario_detalle_compra_productoColumn);
         Gridcompra_inventario_detalle_compra_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Value", A40DESCRIPCIONPRODUCTO);
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddColumnProperties(Gridcompra_inventario_detalle_compra_productoColumn);
         Gridcompra_inventario_detalle_compra_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddColumnProperties(Gridcompra_inventario_detalle_compra_productoColumn);
         Gridcompra_inventario_detalle_compra_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOCOMPRAPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddColumnProperties(Gridcompra_inventario_detalle_compra_productoColumn);
         Gridcompra_inventario_detalle_compra_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", "")));
         Gridcompra_inventario_detalle_compra_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddColumnProperties(Gridcompra_inventario_detalle_compra_productoColumn);
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Selectedindex), 4, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Allowselection), 1, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Selectioncolor), 9, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Allowhovering), 1, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Hoveringcolor), 9, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Allowcollapsing), 1, 0, ".", "")));
         Gridcompra_inventario_detalle_compra_productoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcompra_inventario_detalle_compra_producto_Collapsed), 1, 0, ".", "")));
         nGXsfl_73_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount3 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_3 = 1;
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  init_level_properties3( ) ;
                  getByPrimaryKey023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
               nBlankRcdCount3 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            sMode3 = Gx_mode;
            while ( nGXsfl_73_idx < nRC_GXsfl_73 )
            {
               bGXsfl_73_Refreshing = true;
               ReadRow023( ) ;
               edtIDPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtDESCRIPCIONPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtDESCRIPCIONPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtCANTIDADPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCANTIDADPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtPRECIOCOMPRAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRECIOCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPRECIOCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOCOMPRAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtSUBTOTALCOMPRAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtSUBTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               imgprompt_10_Link = cgiGet( "PROMPT_7_"+sGXsfl_73_idx+"Link");
               if ( ( nRcdExists_3 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal023( ) ;
               }
               SendRow023( ) ;
               bGXsfl_73_Refreshing = false;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A61TOTALCOMPRAPRODUCTO = B61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount3 = 5;
            nRcdExists_3 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_733( ) ;
                  init_level_properties3( ) ;
                  standaloneNotModal023( ) ;
                  getByPrimaryKey023( ) ;
                  standaloneModal023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode3 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
            SubsflControlProps_733( ) ;
            InitAll023( ) ;
            init_level_properties3( ) ;
            B61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            nRcdExists_3 = 0;
            nIsMod_3 = 0;
            nRcdDeleted_3 = 0;
            nBlankRcdCount3 = (short)(nBlankRcdUsr3+nBlankRcdCount3);
            fRowAdded = 0;
            while ( nBlankRcdCount3 > 0 )
            {
               standaloneNotModal023( ) ;
               standaloneModal023( ) ;
               AddRow023( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtIDPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount3 = (short)(nBlankRcdCount3-1);
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A61TOTALCOMPRAPRODUCTO = B61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridcompra_inventario_detalle_compra_productoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcompra_inventario_detalle_compra_producto", Gridcompra_inventario_detalle_compra_productoContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcompra_inventario_detalle_compra_productoContainerData", Gridcompra_inventario_detalle_compra_productoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcompra_inventario_detalle_compra_productoContainerData"+"V", Gridcompra_inventario_detalle_compra_productoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridcompra_inventario_detalle_compra_productoContainerData"+"V"+"\" value='"+Gridcompra_inventario_detalle_compra_productoContainer.GridValuesHidden()+"'/>") ;
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( "Z11IDCOMPRA"), ".", ","));
               Z50FECHACOMPRA = context.localUtil.CToD( cgiGet( "Z50FECHACOMPRA"), 0);
               Z51DESCRIPCIONCOMPRA = cgiGet( "Z51DESCRIPCIONCOMPRA");
               Z10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( "Z10IDPROVEEDOR"), ".", ","));
               Z1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "Z1IDEMPLEADO"), ".", ","));
               O61TOTALCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( "O61TOTALCOMPRAPRODUCTO"), ".", ",");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_73 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_73"), ".", ","));
               N10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( "N10IDPROVEEDOR"), ".", ","));
               N1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "N1IDEMPLEADO"), ".", ","));
               AV7IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( "vIDCOMPRA"), ".", ","));
               AV11Insert_IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDPROVEEDOR"), ".", ","));
               AV13Insert_IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDEMPLEADO"), ".", ","));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( edtIDCOMPRA_Internalname), ".", ","));
               AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
               A50FECHACOMPRA = context.localUtil.CToD( cgiGet( edtFECHACOMPRA_Internalname), 1);
               AssignAttri("", false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
               A51DESCRIPCIONCOMPRA = cgiGet( edtDESCRIPCIONCOMPRA_Internalname);
               AssignAttri("", false, "A51DESCRIPCIONCOMPRA", A51DESCRIPCIONCOMPRA);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDPROVEEDOR");
                  AnyError = 1;
                  GX_FocusControl = edtIDPROVEEDOR_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A10IDPROVEEDOR = 0;
                  AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
               }
               else
               {
                  A10IDPROVEEDOR = (long)(context.localUtil.CToN( cgiGet( edtIDPROVEEDOR_Internalname), ".", ","));
                  AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
               }
               A46NOMBREPROVEEDOR = cgiGet( edtNOMBREPROVEEDOR_Internalname);
               AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDEMPLEADO");
                  AnyError = 1;
                  GX_FocusControl = edtIDEMPLEADO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1IDEMPLEADO = 0;
                  AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               }
               else
               {
                  A1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( edtIDEMPLEADO_Internalname), ".", ","));
                  AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
               }
               A23NOMBRECOMPLETOEMPLEADO = cgiGet( edtNOMBRECOMPLETOEMPLEADO_Internalname);
               AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
               A61TOTALCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtTOTALCOMPRAPRODUCTO_Internalname), ".", ",");
               n61TOTALCOMPRAPRODUCTO = false;
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Compra_inventario");
               A11IDCOMPRA = (long)(context.localUtil.CToN( cgiGet( edtIDCOMPRA_Internalname), ".", ","));
               AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
               forbiddenHiddens.Add("IDCOMPRA", context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A50FECHACOMPRA = context.localUtil.CToD( cgiGet( edtFECHACOMPRA_Internalname), 1);
               AssignAttri("", false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
               forbiddenHiddens.Add("FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A11IDCOMPRA != Z11IDCOMPRA ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("compra_inventario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A11IDCOMPRA = (long)(NumberUtil.Val( GetPar( "IDCOMPRA"), "."));
                  AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDCOMPRA");
                        AnyError = 1;
                        GX_FocusControl = edtIDCOMPRA_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode2 = Gx_mode;
            CONFIRM_023( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode2;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_023( )
      {
         s61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
         n61TOTALCOMPRAPRODUCTO = false;
         AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate023( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable023( ) ;
                        CloseExtendedTableCursors023( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
                        n61TOTALCOMPRAPRODUCTO = false;
                        AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtIDPRODUCTO_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( nRcdDeleted_3 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey023( ) ;
                        Load023( ) ;
                        BeforeValidate023( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls023( ) ;
                           O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
                           n61TOTALCOMPRAPRODUCTO = false;
                           AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate023( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable023( ) ;
                              CloseExtendedTableCursors023( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
                              n61TOTALCOMPRAPRODUCTO = false;
                              AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIDPRODUCTO_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIDPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( edtDESCRIPCIONPRODUCTO_Internalname, A40DESCRIPCIONPRODUCTO) ;
            ChangePostValue( edtCANTIDADPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( edtPRECIOCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( edtSUBTOTALCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7IDPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( "T60SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( O60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRECIOCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOCOMPRAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O61TOTALCOMPRAPRODUCTO = s61TOTALCOMPRAPRODUCTO;
         n61TOTALCOMPRAPRODUCTO = false;
         AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "TiendaRopaProyecto");
         AV11Insert_IDPROVEEDOR = 0;
         AssignAttri("", false, "AV11Insert_IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(AV11Insert_IDPROVEEDOR), 12, 0));
         AV13Insert_IDEMPLEADO = 0;
         AssignAttri("", false, "AV13Insert_IDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV13Insert_IDEMPLEADO), 12, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "IDPROVEEDOR") == 0 )
               {
                  AV11Insert_IDPROVEEDOR = (long)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(AV11Insert_IDPROVEEDOR), 12, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "IDEMPLEADO") == 0 )
               {
                  AV13Insert_IDEMPLEADO = (long)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_IDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV13Insert_IDEMPLEADO), 12, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwcompra_inventario.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z50FECHACOMPRA = T00028_A50FECHACOMPRA[0];
               Z51DESCRIPCIONCOMPRA = T00028_A51DESCRIPCIONCOMPRA[0];
               Z10IDPROVEEDOR = T00028_A10IDPROVEEDOR[0];
               Z1IDEMPLEADO = T00028_A1IDEMPLEADO[0];
            }
            else
            {
               Z50FECHACOMPRA = A50FECHACOMPRA;
               Z51DESCRIPCIONCOMPRA = A51DESCRIPCIONCOMPRA;
               Z10IDPROVEEDOR = A10IDPROVEEDOR;
               Z1IDEMPLEADO = A1IDEMPLEADO;
            }
         }
         if ( GX_JID == -18 )
         {
            Z11IDCOMPRA = A11IDCOMPRA;
            Z50FECHACOMPRA = A50FECHACOMPRA;
            Z51DESCRIPCIONCOMPRA = A51DESCRIPCIONCOMPRA;
            Z10IDPROVEEDOR = A10IDPROVEEDOR;
            Z1IDEMPLEADO = A1IDEMPLEADO;
            Z61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
            Z46NOMBREPROVEEDOR = A46NOMBREPROVEEDOR;
            Z23NOMBRECOMPLETOEMPLEADO = A23NOMBRECOMPLETOEMPLEADO;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIDCOMPRA_Enabled = 0;
         AssignProp("", false, edtIDCOMPRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCOMPRA_Enabled), 5, 0), true);
         edtFECHACOMPRA_Enabled = 0;
         AssignProp("", false, edtFECHACOMPRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHACOMPRA_Enabled), 5, 0), true);
         edtTOTALCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALCOMPRAPRODUCTO_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00d0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDPROVEEDOR"+"'), id:'"+"IDPROVEEDOR"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDEMPLEADO"+"'), id:'"+"IDEMPLEADO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtIDCOMPRA_Enabled = 0;
         AssignProp("", false, edtIDCOMPRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCOMPRA_Enabled), 5, 0), true);
         edtFECHACOMPRA_Enabled = 0;
         AssignProp("", false, edtFECHACOMPRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHACOMPRA_Enabled), 5, 0), true);
         edtTOTALCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALCOMPRAPRODUCTO_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IDCOMPRA) )
         {
            A11IDCOMPRA = AV7IDCOMPRA;
            AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDPROVEEDOR) )
         {
            edtIDPROVEEDOR_Enabled = 0;
            AssignProp("", false, edtIDPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPROVEEDOR_Enabled), 5, 0), true);
         }
         else
         {
            edtIDPROVEEDOR_Enabled = 1;
            AssignProp("", false, edtIDPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPROVEEDOR_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_IDEMPLEADO) )
         {
            edtIDEMPLEADO_Enabled = 0;
            AssignProp("", false, edtIDEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDEMPLEADO_Enabled), 5, 0), true);
         }
         else
         {
            edtIDEMPLEADO_Enabled = 1;
            AssignProp("", false, edtIDEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDEMPLEADO_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_IDEMPLEADO) )
         {
            A1IDEMPLEADO = AV13Insert_IDEMPLEADO;
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDPROVEEDOR) )
         {
            A10IDPROVEEDOR = AV11Insert_IDPROVEEDOR;
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A50FECHACOMPRA) && ( Gx_BScreen == 0 ) )
         {
            A50FECHACOMPRA = Gx_date;
            AssignAttri("", false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000213 */
            pr_default.execute(8, new Object[] {A11IDCOMPRA});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A61TOTALCOMPRAPRODUCTO = T000213_A61TOTALCOMPRAPRODUCTO[0];
               n61TOTALCOMPRAPRODUCTO = T000213_n61TOTALCOMPRAPRODUCTO[0];
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            else
            {
               A61TOTALCOMPRAPRODUCTO = 0;
               n61TOTALCOMPRAPRODUCTO = false;
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            pr_default.close(8);
            AV16Pgmname = "Compra_inventario";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000210 */
            pr_default.execute(7, new Object[] {A1IDEMPLEADO});
            A23NOMBRECOMPLETOEMPLEADO = T000210_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            pr_default.close(7);
            /* Using cursor T00029 */
            pr_default.execute(6, new Object[] {A10IDPROVEEDOR});
            A46NOMBREPROVEEDOR = T00029_A46NOMBREPROVEEDOR[0];
            AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
            pr_default.close(6);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T000216 */
         pr_default.execute(9, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A50FECHACOMPRA = T000216_A50FECHACOMPRA[0];
            AssignAttri("", false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
            A51DESCRIPCIONCOMPRA = T000216_A51DESCRIPCIONCOMPRA[0];
            AssignAttri("", false, "A51DESCRIPCIONCOMPRA", A51DESCRIPCIONCOMPRA);
            A46NOMBREPROVEEDOR = T000216_A46NOMBREPROVEEDOR[0];
            AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
            A23NOMBRECOMPLETOEMPLEADO = T000216_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            A10IDPROVEEDOR = T000216_A10IDPROVEEDOR[0];
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
            A1IDEMPLEADO = T000216_A1IDEMPLEADO[0];
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            A61TOTALCOMPRAPRODUCTO = T000216_A61TOTALCOMPRAPRODUCTO[0];
            n61TOTALCOMPRAPRODUCTO = T000216_n61TOTALCOMPRAPRODUCTO[0];
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            ZM022( -18) ;
         }
         pr_default.close(9);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
         n61TOTALCOMPRAPRODUCTO = false;
         AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         AV16Pgmname = "Compra_inventario";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "Compra_inventario";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T000213 */
         pr_default.execute(8, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A61TOTALCOMPRAPRODUCTO = T000213_A61TOTALCOMPRAPRODUCTO[0];
            n61TOTALCOMPRAPRODUCTO = T000213_n61TOTALCOMPRAPRODUCTO[0];
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         else
         {
            nIsDirty_2 = 1;
            A61TOTALCOMPRAPRODUCTO = 0;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         pr_default.close(8);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A51DESCRIPCIONCOMPRA)) )
         {
            GX_msglist.addItem("Ingrese la Descripcion de la Compra", 1, "DESCRIPCIONCOMPRA");
            AnyError = 1;
            GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00029 */
         pr_default.execute(6, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Proveedores'.", "ForeignKeyNotFound", 1, "IDPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtIDPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A46NOMBREPROVEEDOR = T00029_A46NOMBREPROVEEDOR[0];
         AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
         pr_default.close(6);
         /* Using cursor T000210 */
         pr_default.execute(7, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Empleados'.", "ForeignKeyNotFound", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23NOMBRECOMPLETOEMPLEADO = T000210_A23NOMBRECOMPLETOEMPLEADO[0];
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( long A11IDCOMPRA )
      {
         /* Using cursor T000219 */
         pr_default.execute(10, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A61TOTALCOMPRAPRODUCTO = T000219_A61TOTALCOMPRAPRODUCTO[0];
            n61TOTALCOMPRAPRODUCTO = T000219_n61TOTALCOMPRAPRODUCTO[0];
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         else
         {
            A61TOTALCOMPRAPRODUCTO = 0;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A61TOTALCOMPRAPRODUCTO, 12, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_19( long A10IDPROVEEDOR )
      {
         /* Using cursor T000220 */
         pr_default.execute(11, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Proveedores'.", "ForeignKeyNotFound", 1, "IDPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtIDPROVEEDOR_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A46NOMBREPROVEEDOR = T000220_A46NOMBREPROVEEDOR[0];
         AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A46NOMBREPROVEEDOR)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_20( long A1IDEMPLEADO )
      {
         /* Using cursor T000221 */
         pr_default.execute(12, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'Empleados'.", "ForeignKeyNotFound", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23NOMBRECOMPLETOEMPLEADO = T000221_A23NOMBRECOMPLETOEMPLEADO[0];
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A23NOMBRECOMPLETOEMPLEADO)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000222 */
         pr_default.execute(13, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00028 */
         pr_default.execute(5, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM022( 18) ;
            RcdFound2 = 1;
            A11IDCOMPRA = T00028_A11IDCOMPRA[0];
            AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
            A50FECHACOMPRA = T00028_A50FECHACOMPRA[0];
            AssignAttri("", false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
            A51DESCRIPCIONCOMPRA = T00028_A51DESCRIPCIONCOMPRA[0];
            AssignAttri("", false, "A51DESCRIPCIONCOMPRA", A51DESCRIPCIONCOMPRA);
            A10IDPROVEEDOR = T00028_A10IDPROVEEDOR[0];
            AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
            A1IDEMPLEADO = T00028_A1IDEMPLEADO[0];
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            Z11IDCOMPRA = A11IDCOMPRA;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000223 */
         pr_default.execute(14, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000223_A11IDCOMPRA[0] < A11IDCOMPRA ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000223_A11IDCOMPRA[0] > A11IDCOMPRA ) ) )
            {
               A11IDCOMPRA = T000223_A11IDCOMPRA[0];
               AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000224 */
         pr_default.execute(15, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000224_A11IDCOMPRA[0] > A11IDCOMPRA ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000224_A11IDCOMPRA[0] < A11IDCOMPRA ) ) )
            {
               A11IDCOMPRA = T000224_A11IDCOMPRA[0];
               AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A11IDCOMPRA != Z11IDCOMPRA )
               {
                  A11IDCOMPRA = Z11IDCOMPRA;
                  AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDCOMPRA");
                  AnyError = 1;
                  GX_FocusControl = edtIDCOMPRA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                  Update022( ) ;
                  GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A11IDCOMPRA != Z11IDCOMPRA )
               {
                  /* Insert record */
                  A61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                  GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDCOMPRA");
                     AnyError = 1;
                     GX_FocusControl = edtIDCOMPRA_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
                     n61TOTALCOMPRAPRODUCTO = false;
                     AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                     GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A11IDCOMPRA != Z11IDCOMPRA )
         {
            A11IDCOMPRA = Z11IDCOMPRA;
            AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDCOMPRA");
            AnyError = 1;
            GX_FocusControl = edtIDCOMPRA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDESCRIPCIONCOMPRA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00027 */
            pr_default.execute(4, new Object[] {A11IDCOMPRA});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Compra_inventario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( Z50FECHACOMPRA != T00027_A50FECHACOMPRA[0] ) || ( StringUtil.StrCmp(Z51DESCRIPCIONCOMPRA, T00027_A51DESCRIPCIONCOMPRA[0]) != 0 ) || ( Z10IDPROVEEDOR != T00027_A10IDPROVEEDOR[0] ) || ( Z1IDEMPLEADO != T00027_A1IDEMPLEADO[0] ) )
            {
               if ( Z50FECHACOMPRA != T00027_A50FECHACOMPRA[0] )
               {
                  GXUtil.WriteLog("compra_inventario:[seudo value changed for attri]"+"FECHACOMPRA");
                  GXUtil.WriteLogRaw("Old: ",Z50FECHACOMPRA);
                  GXUtil.WriteLogRaw("Current: ",T00027_A50FECHACOMPRA[0]);
               }
               if ( StringUtil.StrCmp(Z51DESCRIPCIONCOMPRA, T00027_A51DESCRIPCIONCOMPRA[0]) != 0 )
               {
                  GXUtil.WriteLog("compra_inventario:[seudo value changed for attri]"+"DESCRIPCIONCOMPRA");
                  GXUtil.WriteLogRaw("Old: ",Z51DESCRIPCIONCOMPRA);
                  GXUtil.WriteLogRaw("Current: ",T00027_A51DESCRIPCIONCOMPRA[0]);
               }
               if ( Z10IDPROVEEDOR != T00027_A10IDPROVEEDOR[0] )
               {
                  GXUtil.WriteLog("compra_inventario:[seudo value changed for attri]"+"IDPROVEEDOR");
                  GXUtil.WriteLogRaw("Old: ",Z10IDPROVEEDOR);
                  GXUtil.WriteLogRaw("Current: ",T00027_A10IDPROVEEDOR[0]);
               }
               if ( Z1IDEMPLEADO != T00027_A1IDEMPLEADO[0] )
               {
                  GXUtil.WriteLog("compra_inventario:[seudo value changed for attri]"+"IDEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z1IDEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T00027_A1IDEMPLEADO[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Compra_inventario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000225 */
                     pr_default.execute(16, new Object[] {A50FECHACOMPRA, A51DESCRIPCIONCOMPRA, A10IDPROVEEDOR, A1IDEMPLEADO});
                     A11IDCOMPRA = T000225_A11IDCOMPRA[0];
                     AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("Compra_inventario");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000226 */
                     pr_default.execute(17, new Object[] {A50FECHACOMPRA, A51DESCRIPCIONCOMPRA, A10IDPROVEEDOR, A1IDEMPLEADO, A11IDCOMPRA});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("Compra_inventario");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Compra_inventario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  A61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                  ScanStart023( ) ;
                  while ( RcdFound3 != 0 )
                  {
                     getByPrimaryKey023( ) ;
                     Delete023( ) ;
                     ScanNext023( ) ;
                     O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
                     n61TOTALCOMPRAPRODUCTO = false;
                     AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                  }
                  ScanEnd023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000227 */
                     pr_default.execute(18, new Object[] {A11IDCOMPRA});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("Compra_inventario");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Compra_inventario";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000230 */
            pr_default.execute(19, new Object[] {A11IDCOMPRA});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A61TOTALCOMPRAPRODUCTO = T000230_A61TOTALCOMPRAPRODUCTO[0];
               n61TOTALCOMPRAPRODUCTO = T000230_n61TOTALCOMPRAPRODUCTO[0];
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            else
            {
               A61TOTALCOMPRAPRODUCTO = 0;
               n61TOTALCOMPRAPRODUCTO = false;
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            pr_default.close(19);
            /* Using cursor T000231 */
            pr_default.execute(20, new Object[] {A10IDPROVEEDOR});
            A46NOMBREPROVEEDOR = T000231_A46NOMBREPROVEEDOR[0];
            AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
            pr_default.close(20);
            /* Using cursor T000232 */
            pr_default.execute(21, new Object[] {A1IDEMPLEADO});
            A23NOMBRECOMPLETOEMPLEADO = T000232_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel023( )
      {
         s61TOTALCOMPRAPRODUCTO = O61TOTALCOMPRAPRODUCTO;
         n61TOTALCOMPRAPRODUCTO = false;
         AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal023( ) ;
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert023( ) ;
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( ( nRcdDeleted_3 != 0 ) && ( nRcdExists_3 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete023( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update023( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIDPRODUCTO_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
               n61TOTALCOMPRAPRODUCTO = false;
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            ChangePostValue( edtIDPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( edtDESCRIPCIONPRODUCTO_Internalname, A40DESCRIPCIONPRODUCTO) ;
            ChangePostValue( edtCANTIDADPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( edtPRECIOCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( edtSUBTOTALCOMPRAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7IDPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( "T60SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( O60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRECIOCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOCOMPRAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll023( ) ;
         if ( AnyError != 0 )
         {
            O61TOTALCOMPRAPRODUCTO = s61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         nRcdExists_3 = 0;
         nIsMod_3 = 0;
         nRcdDeleted_3 = 0;
      }

      protected void ProcessLevel022( )
      {
         /* Save parent mode. */
         sMode2 = Gx_mode;
         ProcessNestedLevel023( ) ;
         if ( AnyError != 0 )
         {
            O61TOTALCOMPRAPRODUCTO = s61TOTALCOMPRAPRODUCTO;
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("compra_inventario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("compra_inventario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000233 */
         pr_default.execute(22);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound2 = 1;
            A11IDCOMPRA = T000233_A11IDCOMPRA[0];
            AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound2 = 1;
            A11IDCOMPRA = T000233_A11IDCOMPRA[0];
            AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtIDCOMPRA_Enabled = 0;
         AssignProp("", false, edtIDCOMPRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCOMPRA_Enabled), 5, 0), true);
         edtFECHACOMPRA_Enabled = 0;
         AssignProp("", false, edtFECHACOMPRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHACOMPRA_Enabled), 5, 0), true);
         edtDESCRIPCIONCOMPRA_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONCOMPRA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONCOMPRA_Enabled), 5, 0), true);
         edtIDPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtIDPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPROVEEDOR_Enabled), 5, 0), true);
         edtNOMBREPROVEEDOR_Enabled = 0;
         AssignProp("", false, edtNOMBREPROVEEDOR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBREPROVEEDOR_Enabled), 5, 0), true);
         edtIDEMPLEADO_Enabled = 0;
         AssignProp("", false, edtIDEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDEMPLEADO_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOEMPLEADO_Enabled), 5, 0), true);
         edtTOTALCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALCOMPRAPRODUCTO_Enabled), 5, 0), true);
      }

      protected void ZM023( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -22 )
         {
            Z11IDCOMPRA = A11IDCOMPRA;
            Z7IDPRODUCTO = A7IDPRODUCTO;
            Z40DESCRIPCIONPRODUCTO = A40DESCRIPCIONPRODUCTO;
            Z41CANTIDADPRODUCTO = A41CANTIDADPRODUCTO;
            Z42PRECIOCOMPRAPRODUCTO = A42PRECIOCOMPRAPRODUCTO;
            Z60SUBTOTALCOMPRAPRODUCTO = A60SUBTOTALCOMPRAPRODUCTO;
         }
      }

      protected void standaloneNotModal023( )
      {
         edtSUBTOTALCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtSUBTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtTOTALCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALCOMPRAPRODUCTO_Enabled), 5, 0), true);
         edtTOTALCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALCOMPRAPRODUCTO_Enabled), 5, 0), true);
      }

      protected void standaloneModal023( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtIDPRODUCTO_Enabled = 0;
            AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
         else
         {
            edtIDPRODUCTO_Enabled = 1;
            AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
      }

      protected void Load023( )
      {
         /* Using cursor T000235 */
         pr_default.execute(23, new Object[] {A11IDCOMPRA, A7IDPRODUCTO});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound3 = 1;
            A40DESCRIPCIONPRODUCTO = T000235_A40DESCRIPCIONPRODUCTO[0];
            A41CANTIDADPRODUCTO = T000235_A41CANTIDADPRODUCTO[0];
            A42PRECIOCOMPRAPRODUCTO = T000235_A42PRECIOCOMPRAPRODUCTO[0];
            A60SUBTOTALCOMPRAPRODUCTO = T000235_A60SUBTOTALCOMPRAPRODUCTO[0];
            n60SUBTOTALCOMPRAPRODUCTO = T000235_n60SUBTOTALCOMPRAPRODUCTO[0];
            ZM023( -22) ;
         }
         pr_default.close(23);
         OnLoadActions023( ) ;
      }

      protected void OnLoadActions023( )
      {
         if ( IsIns( )  )
         {
            A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO+A60SUBTOTALCOMPRAPRODUCTO);
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO+A60SUBTOTALCOMPRAPRODUCTO-O60SUBTOTALCOMPRAPRODUCTO);
               n61TOTALCOMPRAPRODUCTO = false;
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO-O60SUBTOTALCOMPRAPRODUCTO);
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               }
            }
         }
      }

      protected void CheckExtendedTable023( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal023( ) ;
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
            GX_msglist.addItem("No matching 'Inventario'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40DESCRIPCIONPRODUCTO = T00024_A40DESCRIPCIONPRODUCTO[0];
         A41CANTIDADPRODUCTO = T00024_A41CANTIDADPRODUCTO[0];
         A42PRECIOCOMPRAPRODUCTO = T00024_A42PRECIOCOMPRAPRODUCTO[0];
         pr_default.close(2);
         /* Using cursor T00026 */
         pr_default.execute(3, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A60SUBTOTALCOMPRAPRODUCTO = T00026_A60SUBTOTALCOMPRAPRODUCTO[0];
            n60SUBTOTALCOMPRAPRODUCTO = T00026_n60SUBTOTALCOMPRAPRODUCTO[0];
         }
         else
         {
            nIsDirty_3 = 1;
            A60SUBTOTALCOMPRAPRODUCTO = 0;
            n60SUBTOTALCOMPRAPRODUCTO = false;
         }
         pr_default.close(3);
         if ( IsIns( )  )
         {
            nIsDirty_3 = 1;
            A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO+A60SUBTOTALCOMPRAPRODUCTO);
            n61TOTALCOMPRAPRODUCTO = false;
            AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_3 = 1;
               A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO+A60SUBTOTALCOMPRAPRODUCTO-O60SUBTOTALCOMPRAPRODUCTO);
               n61TOTALCOMPRAPRODUCTO = false;
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_3 = 1;
                  A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO-O60SUBTOTALCOMPRAPRODUCTO);
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors023( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable023( )
      {
      }

      protected void gxLoad_23( long A7IDPRODUCTO )
      {
         /* Using cursor T000236 */
         pr_default.execute(24, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
            GX_msglist.addItem("No matching 'Inventario'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40DESCRIPCIONPRODUCTO = T000236_A40DESCRIPCIONPRODUCTO[0];
         A41CANTIDADPRODUCTO = T000236_A41CANTIDADPRODUCTO[0];
         A42PRECIOCOMPRAPRODUCTO = T000236_A42PRECIOCOMPRAPRODUCTO[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A40DESCRIPCIONPRODUCTO)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_24( long A7IDPRODUCTO )
      {
         /* Using cursor T000238 */
         pr_default.execute(25, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A60SUBTOTALCOMPRAPRODUCTO = T000238_A60SUBTOTALCOMPRAPRODUCTO[0];
            n60SUBTOTALCOMPRAPRODUCTO = T000238_n60SUBTOTALCOMPRAPRODUCTO[0];
         }
         else
         {
            A60SUBTOTALCOMPRAPRODUCTO = 0;
            n60SUBTOTALCOMPRAPRODUCTO = false;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey023( )
      {
         /* Using cursor T000239 */
         pr_default.execute(26, new Object[] {A11IDCOMPRA, A7IDPRODUCTO});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey023( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A11IDCOMPRA, A7IDPRODUCTO});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM023( 22) ;
            RcdFound3 = 1;
            InitializeNonKey023( ) ;
            A7IDPRODUCTO = T00023_A7IDPRODUCTO[0];
            Z11IDCOMPRA = A11IDCOMPRA;
            Z7IDPRODUCTO = A7IDPRODUCTO;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load023( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey023( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal023( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes023( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency023( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A11IDCOMPRA, A7IDPRODUCTO});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Compra_inventarioCompra_produc"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Compra_inventarioCompra_produc"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM023( 0) ;
            CheckOptimisticConcurrency023( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm023( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000240 */
                     pr_default.execute(27, new Object[] {A11IDCOMPRA, A7IDPRODUCTO});
                     pr_default.close(27);
                     dsDefault.SmartCacheProvider.SetUpdated("Compra_inventarioCompra_produc");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load023( ) ;
            }
            EndLevel023( ) ;
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void Update023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( ( nIsMod_3 != 0 ) || ( nIsDirty_3 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency023( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm023( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate023( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [Compra_inventarioCompra_produc] */
                        DeferredUpdate023( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey023( ) ;
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
               EndLevel023( ) ;
            }
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void DeferredUpdate023( )
      {
      }

      protected void Delete023( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency023( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls023( ) ;
            AfterConfirm023( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete023( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000241 */
                  pr_default.execute(28, new Object[] {A11IDCOMPRA, A7IDPRODUCTO});
                  pr_default.close(28);
                  dsDefault.SmartCacheProvider.SetUpdated("Compra_inventarioCompra_produc");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel023( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls023( )
      {
         standaloneModal023( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000242 */
            pr_default.execute(29, new Object[] {A7IDPRODUCTO});
            A40DESCRIPCIONPRODUCTO = T000242_A40DESCRIPCIONPRODUCTO[0];
            A41CANTIDADPRODUCTO = T000242_A41CANTIDADPRODUCTO[0];
            A42PRECIOCOMPRAPRODUCTO = T000242_A42PRECIOCOMPRAPRODUCTO[0];
            pr_default.close(29);
            /* Using cursor T000244 */
            pr_default.execute(30, new Object[] {A7IDPRODUCTO});
            if ( (pr_default.getStatus(30) != 101) )
            {
               A60SUBTOTALCOMPRAPRODUCTO = T000244_A60SUBTOTALCOMPRAPRODUCTO[0];
               n60SUBTOTALCOMPRAPRODUCTO = T000244_n60SUBTOTALCOMPRAPRODUCTO[0];
            }
            else
            {
               A60SUBTOTALCOMPRAPRODUCTO = 0;
               n60SUBTOTALCOMPRAPRODUCTO = false;
            }
            pr_default.close(30);
            if ( IsIns( )  )
            {
               A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO+A60SUBTOTALCOMPRAPRODUCTO);
               n61TOTALCOMPRAPRODUCTO = false;
               AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO+A60SUBTOTALCOMPRAPRODUCTO-O60SUBTOTALCOMPRAPRODUCTO);
                  n61TOTALCOMPRAPRODUCTO = false;
                  AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A61TOTALCOMPRAPRODUCTO = (decimal)(O61TOTALCOMPRAPRODUCTO-O60SUBTOTALCOMPRAPRODUCTO);
                     n61TOTALCOMPRAPRODUCTO = false;
                     AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
                  }
               }
            }
         }
      }

      protected void EndLevel023( )
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

      public void ScanStart023( )
      {
         /* Scan By routine */
         /* Using cursor T000245 */
         pr_default.execute(31, new Object[] {A11IDCOMPRA});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound3 = 1;
            A7IDPRODUCTO = T000245_A7IDPRODUCTO[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext023( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound3 = 1;
            A7IDPRODUCTO = T000245_A7IDPRODUCTO[0];
         }
      }

      protected void ScanEnd023( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm023( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert023( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate023( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete023( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete023( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate023( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes023( )
      {
         edtIDPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtDESCRIPCIONPRODUCTO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtCANTIDADPRODUCTO_Enabled = 0;
         AssignProp("", false, edtCANTIDADPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtPRECIOCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtPRECIOCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOCOMPRAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtSUBTOTALCOMPRAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtSUBTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void send_integrity_lvl_hashes023( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void SubsflControlProps_733( )
      {
         edtIDPRODUCTO_Internalname = "IDPRODUCTO_"+sGXsfl_73_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_73_idx;
         edtDESCRIPCIONPRODUCTO_Internalname = "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx;
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO_"+sGXsfl_73_idx;
         edtPRECIOCOMPRAPRODUCTO_Internalname = "PRECIOCOMPRAPRODUCTO_"+sGXsfl_73_idx;
         edtSUBTOTALCOMPRAPRODUCTO_Internalname = "SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_733( )
      {
         edtIDPRODUCTO_Internalname = "IDPRODUCTO_"+sGXsfl_73_fel_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_73_fel_idx;
         edtDESCRIPCIONPRODUCTO_Internalname = "DESCRIPCIONPRODUCTO_"+sGXsfl_73_fel_idx;
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO_"+sGXsfl_73_fel_idx;
         edtPRECIOCOMPRAPRODUCTO_Internalname = "PRECIOCOMPRAPRODUCTO_"+sGXsfl_73_fel_idx;
         edtSUBTOTALCOMPRAPRODUCTO_Internalname = "SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_fel_idx;
      }

      protected void AddRow023( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_733( ) ;
         SendRow023( ) ;
      }

      protected void SendRow023( )
      {
         Gridcompra_inventario_detalle_compra_productoRow = GXWebRow.GetNew(context);
         if ( subGridcompra_inventario_detalle_compra_producto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcompra_inventario_detalle_compra_producto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcompra_inventario_detalle_compra_producto_Class, "") != 0 )
            {
               subGridcompra_inventario_detalle_compra_producto_Linesclass = subGridcompra_inventario_detalle_compra_producto_Class+"Odd";
            }
         }
         else if ( subGridcompra_inventario_detalle_compra_producto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcompra_inventario_detalle_compra_producto_Backstyle = 0;
            subGridcompra_inventario_detalle_compra_producto_Backcolor = subGridcompra_inventario_detalle_compra_producto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcompra_inventario_detalle_compra_producto_Class, "") != 0 )
            {
               subGridcompra_inventario_detalle_compra_producto_Linesclass = subGridcompra_inventario_detalle_compra_producto_Class+"Uniform";
            }
         }
         else if ( subGridcompra_inventario_detalle_compra_producto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcompra_inventario_detalle_compra_producto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcompra_inventario_detalle_compra_producto_Class, "") != 0 )
            {
               subGridcompra_inventario_detalle_compra_producto_Linesclass = subGridcompra_inventario_detalle_compra_producto_Class+"Odd";
            }
            subGridcompra_inventario_detalle_compra_producto_Backcolor = (int)(0x0);
         }
         else if ( subGridcompra_inventario_detalle_compra_producto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcompra_inventario_detalle_compra_producto_Backstyle = 1;
            if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
            {
               subGridcompra_inventario_detalle_compra_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcompra_inventario_detalle_compra_producto_Class, "") != 0 )
               {
                  subGridcompra_inventario_detalle_compra_producto_Linesclass = subGridcompra_inventario_detalle_compra_producto_Class+"Even";
               }
            }
            else
            {
               subGridcompra_inventario_detalle_compra_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcompra_inventario_detalle_compra_producto_Class, "") != 0 )
               {
                  subGridcompra_inventario_detalle_compra_producto_Linesclass = subGridcompra_inventario_detalle_compra_producto_Class+"Odd";
               }
            }
         }
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0090.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDPRODUCTO_"+sGXsfl_73_idx+"'), id:'"+"IDPRODUCTO_"+sGXsfl_73_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_3_"+sGXsfl_73_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridcompra_inventario_detalle_compra_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtIDPRODUCTO_Enabled,(short)1,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridcompra_inventario_detalle_compra_productoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_7_Internalname,(string)sImgUrl,(string)imgprompt_7_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_7_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcompra_inventario_detalle_compra_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDESCRIPCIONPRODUCTO_Internalname,(string)A40DESCRIPCIONPRODUCTO,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDESCRIPCIONPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtDESCRIPCIONPRODUCTO_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcompra_inventario_detalle_compra_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCANTIDADPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")),((edtCANTIDADPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCANTIDADPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCANTIDADPRODUCTO_Enabled,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Cantidad",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcompra_inventario_detalle_compra_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPRECIOCOMPRAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")),((edtPRECIOCOMPRAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPRECIOCOMPRAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPRECIOCOMPRAPRODUCTO_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcompra_inventario_detalle_compra_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSUBTOTALCOMPRAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( A60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", "")),((edtSUBTOTALCOMPRAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A60SUBTOTALCOMPRAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A60SUBTOTALCOMPRAPRODUCTO, "ZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSUBTOTALCOMPRAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSUBTOTALCOMPRAPRODUCTO_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridcompra_inventario_detalle_compra_productoRow);
         send_integrity_lvl_hashes023( ) ;
         GXCCtl = "Z7IDPRODUCTO_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7IDPRODUCTO), 12, 0, ".", "")));
         GXCCtl = "O60SUBTOTALCOMPRAPRODUCTO_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", "")));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_3_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", "")));
         GXCCtl = "nIsMod_3_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_73_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vIDCOMPRA_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDCOMPRA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRECIOCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOCOMPRAPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_7_"+sGXsfl_73_idx+"Link", StringUtil.RTrim( imgprompt_7_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridcompra_inventario_detalle_compra_productoContainer.AddRow(Gridcompra_inventario_detalle_compra_productoRow);
      }

      protected void ReadRow023( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_733( ) ;
         edtIDPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtDESCRIPCIONPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtCANTIDADPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtPRECIOCOMPRAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRECIOCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtSUBTOTALCOMPRAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "SUBTOTALCOMPRAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         imgprompt_10_Link = cgiGet( "PROMPT_7_"+sGXsfl_73_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtIDPRODUCTO_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDPRODUCTO_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
         {
            GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
            wbErr = true;
            A7IDPRODUCTO = 0;
         }
         else
         {
            A7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtIDPRODUCTO_Internalname), ".", ","));
         }
         A40DESCRIPCIONPRODUCTO = cgiGet( edtDESCRIPCIONPRODUCTO_Internalname);
         A41CANTIDADPRODUCTO = (long)(context.localUtil.CToN( cgiGet( edtCANTIDADPRODUCTO_Internalname), ".", ","));
         A42PRECIOCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOCOMPRAPRODUCTO_Internalname), ".", ",");
         A60SUBTOTALCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( edtSUBTOTALCOMPRAPRODUCTO_Internalname), ".", ",");
         n60SUBTOTALCOMPRAPRODUCTO = false;
         GXCCtl = "Z7IDPRODUCTO_" + sGXsfl_73_idx;
         Z7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "O60SUBTOTALCOMPRAPRODUCTO_" + sGXsfl_73_idx;
         O60SUBTOTALCOMPRAPRODUCTO = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_73_idx;
         nRcdDeleted_3 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_3_" + sGXsfl_73_idx;
         nRcdExists_3 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_3_" + sGXsfl_73_idx;
         nIsMod_3 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtSUBTOTALCOMPRAPRODUCTO_Enabled = edtSUBTOTALCOMPRAPRODUCTO_Enabled;
         defedtIDPRODUCTO_Enabled = edtIDPRODUCTO_Enabled;
      }

      protected void ConfirmValues020( )
      {
         nGXsfl_73_idx = 0;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_733( ) ;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_733( ) ;
            ChangePostValue( "Z7IDPRODUCTO_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx) ;
         }
         ChangePostValue( "O60SUBTOTALCOMPRAPRODUCTO", cgiGet( "T60SUBTOTALCOMPRAPRODUCTO")) ;
         DeletePostValue( "T60SUBTOTALCOMPRAPRODUCTO") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021112620512757", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("compra_inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDCOMPRA,12,0))}, new string[] {"Gx_mode","IDCOMPRA"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Compra_inventario");
         forbiddenHiddens.Add("IDCOMPRA", context.localUtil.Format( (decimal)(A11IDCOMPRA), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("compra_inventario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z11IDCOMPRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11IDCOMPRA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z50FECHACOMPRA", context.localUtil.DToC( Z50FECHACOMPRA, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z51DESCRIPCIONCOMPRA", Z51DESCRIPCIONCOMPRA);
         GxWebStd.gx_hidden_field( context, "Z10IDPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10IDPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1IDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O61TOTALCOMPRAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( O61TOTALCOMPRAPRODUCTO, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_73_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N10IDPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10IDPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N1IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vIDCOMPRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDCOMPRA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDCOMPRA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDCOMPRA), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDPROVEEDOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_IDPROVEEDOR), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_IDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
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
         return formatLink("compra_inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDCOMPRA,12,0))}, new string[] {"Gx_mode","IDCOMPRA"})  ;
      }

      public override string GetPgmname( )
      {
         return "Compra_inventario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Compra_inventario" ;
      }

      protected void InitializeNonKey022( )
      {
         A10IDPROVEEDOR = 0;
         AssignAttri("", false, "A10IDPROVEEDOR", StringUtil.LTrimStr( (decimal)(A10IDPROVEEDOR), 12, 0));
         A1IDEMPLEADO = 0;
         AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         A51DESCRIPCIONCOMPRA = "";
         AssignAttri("", false, "A51DESCRIPCIONCOMPRA", A51DESCRIPCIONCOMPRA);
         A46NOMBREPROVEEDOR = "";
         AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
         A23NOMBRECOMPLETOEMPLEADO = "";
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
         A61TOTALCOMPRAPRODUCTO = 0;
         n61TOTALCOMPRAPRODUCTO = false;
         AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         A50FECHACOMPRA = Gx_date;
         AssignAttri("", false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
         O61TOTALCOMPRAPRODUCTO = A61TOTALCOMPRAPRODUCTO;
         n61TOTALCOMPRAPRODUCTO = false;
         AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrimStr( A61TOTALCOMPRAPRODUCTO, 12, 2));
         Z50FECHACOMPRA = DateTime.MinValue;
         Z51DESCRIPCIONCOMPRA = "";
         Z10IDPROVEEDOR = 0;
         Z1IDEMPLEADO = 0;
      }

      protected void InitAll022( )
      {
         A11IDCOMPRA = 0;
         AssignAttri("", false, "A11IDCOMPRA", StringUtil.LTrimStr( (decimal)(A11IDCOMPRA), 12, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A50FECHACOMPRA = i50FECHACOMPRA;
         AssignAttri("", false, "A50FECHACOMPRA", context.localUtil.Format(A50FECHACOMPRA, "99/99/99"));
      }

      protected void InitializeNonKey023( )
      {
         A40DESCRIPCIONPRODUCTO = "";
         A41CANTIDADPRODUCTO = 0;
         A42PRECIOCOMPRAPRODUCTO = 0;
         A60SUBTOTALCOMPRAPRODUCTO = 0;
         n60SUBTOTALCOMPRAPRODUCTO = false;
         O60SUBTOTALCOMPRAPRODUCTO = A60SUBTOTALCOMPRAPRODUCTO;
         n60SUBTOTALCOMPRAPRODUCTO = false;
      }

      protected void InitAll023( )
      {
         A7IDPRODUCTO = 0;
         InitializeNonKey023( ) ;
      }

      protected void StandaloneModalInsert023( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021112620512768", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1152180), false, true);
         context.AddJavascriptSource("compra_inventario.js", "?2021112620512768", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties3( )
      {
         edtSUBTOTALCOMPRAPRODUCTO_Enabled = defedtSUBTOTALCOMPRAPRODUCTO_Enabled;
         AssignProp("", false, edtSUBTOTALCOMPRAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALCOMPRAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtIDPRODUCTO_Enabled = defedtIDPRODUCTO_Enabled;
         AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
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
         edtIDCOMPRA_Internalname = "IDCOMPRA";
         edtFECHACOMPRA_Internalname = "FECHACOMPRA";
         edtDESCRIPCIONCOMPRA_Internalname = "DESCRIPCIONCOMPRA";
         edtIDPROVEEDOR_Internalname = "IDPROVEEDOR";
         edtNOMBREPROVEEDOR_Internalname = "NOMBREPROVEEDOR";
         edtIDEMPLEADO_Internalname = "IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = "NOMBRECOMPLETOEMPLEADO";
         lblTitledetalle_compra_producto_Internalname = "TITLEDETALLE_COMPRA_PRODUCTO";
         edtIDPRODUCTO_Internalname = "IDPRODUCTO";
         edtDESCRIPCIONPRODUCTO_Internalname = "DESCRIPCIONPRODUCTO";
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO";
         edtPRECIOCOMPRAPRODUCTO_Internalname = "PRECIOCOMPRAPRODUCTO";
         edtSUBTOTALCOMPRAPRODUCTO_Internalname = "SUBTOTALCOMPRAPRODUCTO";
         divDetalle_compra_productotable_Internalname = "DETALLE_COMPRA_PRODUCTOTABLE";
         edtTOTALCOMPRAPRODUCTO_Internalname = "TOTALCOMPRAPRODUCTO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_10_Internalname = "PROMPT_10";
         imgprompt_1_Internalname = "PROMPT_1";
         imgprompt_7_Internalname = "PROMPT_7";
         subGridcompra_inventario_detalle_compra_producto_Internalname = "GRIDCOMPRA_INVENTARIO_DETALLE_COMPRA_PRODUCTO";
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
         Form.Caption = "Compra_inventario";
         edtSUBTOTALCOMPRAPRODUCTO_Jsonclick = "";
         edtPRECIOCOMPRAPRODUCTO_Jsonclick = "";
         edtCANTIDADPRODUCTO_Jsonclick = "";
         edtDESCRIPCIONPRODUCTO_Jsonclick = "";
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         imgprompt_10_Visible = 1;
         edtIDPRODUCTO_Jsonclick = "";
         subGridcompra_inventario_detalle_compra_producto_Class = "Grid";
         subGridcompra_inventario_detalle_compra_producto_Backcolorstyle = 0;
         subGridcompra_inventario_detalle_compra_producto_Allowcollapsing = 0;
         subGridcompra_inventario_detalle_compra_producto_Allowselection = 0;
         edtSUBTOTALCOMPRAPRODUCTO_Enabled = 0;
         edtPRECIOCOMPRAPRODUCTO_Enabled = 0;
         edtCANTIDADPRODUCTO_Enabled = 0;
         edtDESCRIPCIONPRODUCTO_Enabled = 0;
         edtIDPRODUCTO_Enabled = 1;
         subGridcompra_inventario_detalle_compra_producto_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTOTALCOMPRAPRODUCTO_Jsonclick = "";
         edtTOTALCOMPRAPRODUCTO_Enabled = 0;
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtIDEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Enabled = 1;
         edtNOMBREPROVEEDOR_Enabled = 0;
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         edtIDPROVEEDOR_Jsonclick = "";
         edtIDPROVEEDOR_Enabled = 1;
         edtDESCRIPCIONCOMPRA_Enabled = 1;
         edtFECHACOMPRA_Jsonclick = "";
         edtFECHACOMPRA_Enabled = 0;
         edtIDCOMPRA_Jsonclick = "";
         edtIDCOMPRA_Enabled = 0;
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

      protected void gxnrGridcompra_inventario_detalle_compra_producto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_733( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow023( ) ;
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_733( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridcompra_inventario_detalle_compra_productoContainer)) ;
         /* End function gxnrGridcompra_inventario_detalle_compra_producto_newrow */
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

      public void Valid_Idcompra( )
      {
         n61TOTALCOMPRAPRODUCTO = false;
         /* Using cursor T000230 */
         pr_default.execute(19, new Object[] {A11IDCOMPRA});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A61TOTALCOMPRAPRODUCTO = T000230_A61TOTALCOMPRAPRODUCTO[0];
            n61TOTALCOMPRAPRODUCTO = T000230_n61TOTALCOMPRAPRODUCTO[0];
         }
         else
         {
            A61TOTALCOMPRAPRODUCTO = 0;
            n61TOTALCOMPRAPRODUCTO = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A61TOTALCOMPRAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( A61TOTALCOMPRAPRODUCTO, 12, 2, ".", "")));
      }

      public void Valid_Idproveedor( )
      {
         /* Using cursor T000231 */
         pr_default.execute(20, new Object[] {A10IDPROVEEDOR});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'Proveedores'.", "ForeignKeyNotFound", 1, "IDPROVEEDOR");
            AnyError = 1;
            GX_FocusControl = edtIDPROVEEDOR_Internalname;
         }
         A46NOMBREPROVEEDOR = T000231_A46NOMBREPROVEEDOR[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A46NOMBREPROVEEDOR", A46NOMBREPROVEEDOR);
      }

      public void Valid_Idempleado( )
      {
         /* Using cursor T000232 */
         pr_default.execute(21, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'Empleados'.", "ForeignKeyNotFound", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
         }
         A23NOMBRECOMPLETOEMPLEADO = T000232_A23NOMBRECOMPLETOEMPLEADO[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
      }

      public void Valid_Idproducto( )
      {
         n60SUBTOTALCOMPRAPRODUCTO = false;
         /* Using cursor T000242 */
         pr_default.execute(29, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No matching 'Inventario'.", "ForeignKeyNotFound", 1, "IDPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
         }
         A40DESCRIPCIONPRODUCTO = T000242_A40DESCRIPCIONPRODUCTO[0];
         A41CANTIDADPRODUCTO = T000242_A41CANTIDADPRODUCTO[0];
         A42PRECIOCOMPRAPRODUCTO = T000242_A42PRECIOCOMPRAPRODUCTO[0];
         pr_default.close(29);
         /* Using cursor T000244 */
         pr_default.execute(30, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(30) != 101) )
         {
            A60SUBTOTALCOMPRAPRODUCTO = T000244_A60SUBTOTALCOMPRAPRODUCTO[0];
            n60SUBTOTALCOMPRAPRODUCTO = T000244_n60SUBTOTALCOMPRAPRODUCTO[0];
         }
         else
         {
            A60SUBTOTALCOMPRAPRODUCTO = 0;
            n60SUBTOTALCOMPRAPRODUCTO = false;
         }
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
         AssignAttri("", false, "A41CANTIDADPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")));
         AssignAttri("", false, "A42PRECIOCOMPRAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( A42PRECIOCOMPRAPRODUCTO, 12, 2, ".", "")));
         AssignAttri("", false, "A60SUBTOTALCOMPRAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( A60SUBTOTALCOMPRAPRODUCTO, 12, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IDCOMPRA',fld:'vIDCOMPRA',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IDCOMPRA',fld:'vIDCOMPRA',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A11IDCOMPRA',fld:'IDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'A50FECHACOMPRA',fld:'FECHACOMPRA',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_IDCOMPRA","{handler:'Valid_Idcompra',iparms:[{av:'A11IDCOMPRA',fld:'IDCOMPRA',pic:'ZZZZZZZZZZZ9'},{av:'A61TOTALCOMPRAPRODUCTO',fld:'TOTALCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("VALID_IDCOMPRA",",oparms:[{av:'A61TOTALCOMPRAPRODUCTO',fld:'TOTALCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'}]}");
         setEventMetadata("VALID_DESCRIPCIONCOMPRA","{handler:'Valid_Descripcioncompra',iparms:[]");
         setEventMetadata("VALID_DESCRIPCIONCOMPRA",",oparms:[]}");
         setEventMetadata("VALID_IDPROVEEDOR","{handler:'Valid_Idproveedor',iparms:[{av:'A10IDPROVEEDOR',fld:'IDPROVEEDOR',pic:'ZZZZZZZZZZZ9'},{av:'A46NOMBREPROVEEDOR',fld:'NOMBREPROVEEDOR',pic:''}]");
         setEventMetadata("VALID_IDPROVEEDOR",",oparms:[{av:'A46NOMBREPROVEEDOR',fld:'NOMBREPROVEEDOR',pic:''}]}");
         setEventMetadata("VALID_IDEMPLEADO","{handler:'Valid_Idempleado',iparms:[{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A23NOMBRECOMPLETOEMPLEADO',fld:'NOMBRECOMPLETOEMPLEADO',pic:''}]");
         setEventMetadata("VALID_IDEMPLEADO",",oparms:[{av:'A23NOMBRECOMPLETOEMPLEADO',fld:'NOMBRECOMPLETOEMPLEADO',pic:''}]}");
         setEventMetadata("VALID_IDPRODUCTO","{handler:'Valid_Idproducto',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'O60SUBTOTALCOMPRAPRODUCTO'},{av:'O61TOTALCOMPRAPRODUCTO'},{av:'A7IDPRODUCTO',fld:'IDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A60SUBTOTALCOMPRAPRODUCTO',fld:'SUBTOTALCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'A40DESCRIPCIONPRODUCTO',fld:'DESCRIPCIONPRODUCTO',pic:''},{av:'A41CANTIDADPRODUCTO',fld:'CANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A42PRECIOCOMPRAPRODUCTO',fld:'PRECIOCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("VALID_IDPRODUCTO",",oparms:[{av:'A40DESCRIPCIONPRODUCTO',fld:'DESCRIPCIONPRODUCTO',pic:''},{av:'A41CANTIDADPRODUCTO',fld:'CANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A42PRECIOCOMPRAPRODUCTO',fld:'PRECIOCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'A60SUBTOTALCOMPRAPRODUCTO',fld:'SUBTOTALCOMPRAPRODUCTO',pic:'ZZZZZZZZ9.99'}]}");
         setEventMetadata("VALID_SUBTOTALCOMPRAPRODUCTO","{handler:'Valid_Subtotalcompraproducto',iparms:[]");
         setEventMetadata("VALID_SUBTOTALCOMPRAPRODUCTO",",oparms:[]}");
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
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(5);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z50FECHACOMPRA = DateTime.MinValue;
         Z51DESCRIPCIONCOMPRA = "";
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
         A50FECHACOMPRA = DateTime.MinValue;
         A51DESCRIPCIONCOMPRA = "";
         sImgUrl = "";
         A46NOMBREPROVEEDOR = "";
         A23NOMBRECOMPLETOEMPLEADO = "";
         lblTitledetalle_compra_producto_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridcompra_inventario_detalle_compra_productoContainer = new GXWebGrid( context);
         Gridcompra_inventario_detalle_compra_productoColumn = new GXWebColumn();
         A40DESCRIPCIONPRODUCTO = "";
         sMode3 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z46NOMBREPROVEEDOR = "";
         Z23NOMBRECOMPLETOEMPLEADO = "";
         T000213_A61TOTALCOMPRAPRODUCTO = new decimal[1] ;
         T000213_n61TOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T000210_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T00029_A46NOMBREPROVEEDOR = new string[] {""} ;
         T000216_A11IDCOMPRA = new long[1] ;
         T000216_A50FECHACOMPRA = new DateTime[] {DateTime.MinValue} ;
         T000216_A51DESCRIPCIONCOMPRA = new string[] {""} ;
         T000216_A46NOMBREPROVEEDOR = new string[] {""} ;
         T000216_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T000216_A10IDPROVEEDOR = new long[1] ;
         T000216_A1IDEMPLEADO = new long[1] ;
         T000216_A61TOTALCOMPRAPRODUCTO = new decimal[1] ;
         T000216_n61TOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T000219_A61TOTALCOMPRAPRODUCTO = new decimal[1] ;
         T000219_n61TOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T000220_A46NOMBREPROVEEDOR = new string[] {""} ;
         T000221_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T000222_A11IDCOMPRA = new long[1] ;
         T00028_A11IDCOMPRA = new long[1] ;
         T00028_A50FECHACOMPRA = new DateTime[] {DateTime.MinValue} ;
         T00028_A51DESCRIPCIONCOMPRA = new string[] {""} ;
         T00028_A10IDPROVEEDOR = new long[1] ;
         T00028_A1IDEMPLEADO = new long[1] ;
         T000223_A11IDCOMPRA = new long[1] ;
         T000224_A11IDCOMPRA = new long[1] ;
         T00027_A11IDCOMPRA = new long[1] ;
         T00027_A50FECHACOMPRA = new DateTime[] {DateTime.MinValue} ;
         T00027_A51DESCRIPCIONCOMPRA = new string[] {""} ;
         T00027_A10IDPROVEEDOR = new long[1] ;
         T00027_A1IDEMPLEADO = new long[1] ;
         T000225_A11IDCOMPRA = new long[1] ;
         T000230_A61TOTALCOMPRAPRODUCTO = new decimal[1] ;
         T000230_n61TOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T000231_A46NOMBREPROVEEDOR = new string[] {""} ;
         T000232_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T000233_A11IDCOMPRA = new long[1] ;
         Z40DESCRIPCIONPRODUCTO = "";
         T000235_A11IDCOMPRA = new long[1] ;
         T000235_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T000235_A41CANTIDADPRODUCTO = new long[1] ;
         T000235_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         T000235_A7IDPRODUCTO = new long[1] ;
         T000235_A60SUBTOTALCOMPRAPRODUCTO = new decimal[1] ;
         T000235_n60SUBTOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T00024_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T00024_A41CANTIDADPRODUCTO = new long[1] ;
         T00024_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         T00026_A60SUBTOTALCOMPRAPRODUCTO = new decimal[1] ;
         T00026_n60SUBTOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T000236_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T000236_A41CANTIDADPRODUCTO = new long[1] ;
         T000236_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         T000238_A60SUBTOTALCOMPRAPRODUCTO = new decimal[1] ;
         T000238_n60SUBTOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T000239_A11IDCOMPRA = new long[1] ;
         T000239_A7IDPRODUCTO = new long[1] ;
         T00023_A11IDCOMPRA = new long[1] ;
         T00023_A7IDPRODUCTO = new long[1] ;
         T00022_A11IDCOMPRA = new long[1] ;
         T00022_A7IDPRODUCTO = new long[1] ;
         T000242_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T000242_A41CANTIDADPRODUCTO = new long[1] ;
         T000242_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         T000244_A60SUBTOTALCOMPRAPRODUCTO = new decimal[1] ;
         T000244_n60SUBTOTALCOMPRAPRODUCTO = new bool[] {false} ;
         T000245_A11IDCOMPRA = new long[1] ;
         T000245_A7IDPRODUCTO = new long[1] ;
         Gridcompra_inventario_detalle_compra_productoRow = new GXWebRow();
         subGridcompra_inventario_detalle_compra_producto_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i50FECHACOMPRA = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compra_inventario__default(),
            new Object[][] {
                new Object[] {
               T00022_A11IDCOMPRA, T00022_A7IDPRODUCTO
               }
               , new Object[] {
               T00023_A11IDCOMPRA, T00023_A7IDPRODUCTO
               }
               , new Object[] {
               T00024_A40DESCRIPCIONPRODUCTO, T00024_A41CANTIDADPRODUCTO, T00024_A42PRECIOCOMPRAPRODUCTO
               }
               , new Object[] {
               T00026_A60SUBTOTALCOMPRAPRODUCTO, T00026_n60SUBTOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T00027_A11IDCOMPRA, T00027_A50FECHACOMPRA, T00027_A51DESCRIPCIONCOMPRA, T00027_A10IDPROVEEDOR, T00027_A1IDEMPLEADO
               }
               , new Object[] {
               T00028_A11IDCOMPRA, T00028_A50FECHACOMPRA, T00028_A51DESCRIPCIONCOMPRA, T00028_A10IDPROVEEDOR, T00028_A1IDEMPLEADO
               }
               , new Object[] {
               T00029_A46NOMBREPROVEEDOR
               }
               , new Object[] {
               T000210_A23NOMBRECOMPLETOEMPLEADO
               }
               , new Object[] {
               T000213_A61TOTALCOMPRAPRODUCTO, T000213_n61TOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T000216_A11IDCOMPRA, T000216_A50FECHACOMPRA, T000216_A51DESCRIPCIONCOMPRA, T000216_A46NOMBREPROVEEDOR, T000216_A23NOMBRECOMPLETOEMPLEADO, T000216_A10IDPROVEEDOR, T000216_A1IDEMPLEADO, T000216_A61TOTALCOMPRAPRODUCTO, T000216_n61TOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T000219_A61TOTALCOMPRAPRODUCTO, T000219_n61TOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T000220_A46NOMBREPROVEEDOR
               }
               , new Object[] {
               T000221_A23NOMBRECOMPLETOEMPLEADO
               }
               , new Object[] {
               T000222_A11IDCOMPRA
               }
               , new Object[] {
               T000223_A11IDCOMPRA
               }
               , new Object[] {
               T000224_A11IDCOMPRA
               }
               , new Object[] {
               T000225_A11IDCOMPRA
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000230_A61TOTALCOMPRAPRODUCTO, T000230_n61TOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T000231_A46NOMBREPROVEEDOR
               }
               , new Object[] {
               T000232_A23NOMBRECOMPLETOEMPLEADO
               }
               , new Object[] {
               T000233_A11IDCOMPRA
               }
               , new Object[] {
               T000235_A11IDCOMPRA, T000235_A40DESCRIPCIONPRODUCTO, T000235_A41CANTIDADPRODUCTO, T000235_A42PRECIOCOMPRAPRODUCTO, T000235_A7IDPRODUCTO, T000235_A60SUBTOTALCOMPRAPRODUCTO, T000235_n60SUBTOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T000236_A40DESCRIPCIONPRODUCTO, T000236_A41CANTIDADPRODUCTO, T000236_A42PRECIOCOMPRAPRODUCTO
               }
               , new Object[] {
               T000238_A60SUBTOTALCOMPRAPRODUCTO, T000238_n60SUBTOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T000239_A11IDCOMPRA, T000239_A7IDPRODUCTO
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000242_A40DESCRIPCIONPRODUCTO, T000242_A41CANTIDADPRODUCTO, T000242_A42PRECIOCOMPRAPRODUCTO
               }
               , new Object[] {
               T000244_A60SUBTOTALCOMPRAPRODUCTO, T000244_n60SUBTOTALCOMPRAPRODUCTO
               }
               , new Object[] {
               T000245_A11IDCOMPRA, T000245_A7IDPRODUCTO
               }
            }
         );
         AV16Pgmname = "Compra_inventario";
         Z50FECHACOMPRA = DateTime.MinValue;
         A50FECHACOMPRA = DateTime.MinValue;
         i50FECHACOMPRA = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_3 ;
      private short nRcdDeleted_3 ;
      private short nRcdExists_3 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridcompra_inventario_detalle_compra_producto_Backcolorstyle ;
      private short subGridcompra_inventario_detalle_compra_producto_Allowselection ;
      private short subGridcompra_inventario_detalle_compra_producto_Allowhovering ;
      private short subGridcompra_inventario_detalle_compra_producto_Allowcollapsing ;
      private short subGridcompra_inventario_detalle_compra_producto_Collapsed ;
      private short nBlankRcdCount3 ;
      private short RcdFound3 ;
      private short nBlankRcdUsr3 ;
      private short Gx_BScreen ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short nIsDirty_2 ;
      private short nIsDirty_3 ;
      private short subGridcompra_inventario_detalle_compra_producto_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_73 ;
      private int nGXsfl_73_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIDCOMPRA_Enabled ;
      private int edtFECHACOMPRA_Enabled ;
      private int edtDESCRIPCIONCOMPRA_Enabled ;
      private int edtIDPROVEEDOR_Enabled ;
      private int imgprompt_10_Visible ;
      private int edtNOMBREPROVEEDOR_Enabled ;
      private int edtIDEMPLEADO_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtNOMBRECOMPLETOEMPLEADO_Enabled ;
      private int edtTOTALCOMPRAPRODUCTO_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtIDPRODUCTO_Enabled ;
      private int edtDESCRIPCIONPRODUCTO_Enabled ;
      private int edtCANTIDADPRODUCTO_Enabled ;
      private int edtPRECIOCOMPRAPRODUCTO_Enabled ;
      private int edtSUBTOTALCOMPRAPRODUCTO_Enabled ;
      private int subGridcompra_inventario_detalle_compra_producto_Selectedindex ;
      private int subGridcompra_inventario_detalle_compra_producto_Selectioncolor ;
      private int subGridcompra_inventario_detalle_compra_producto_Hoveringcolor ;
      private int fRowAdded ;
      private int AV17GXV1 ;
      private int subGridcompra_inventario_detalle_compra_producto_Backcolor ;
      private int subGridcompra_inventario_detalle_compra_producto_Allbackcolor ;
      private int imgprompt_7_Visible ;
      private int defedtSUBTOTALCOMPRAPRODUCTO_Enabled ;
      private int defedtIDPRODUCTO_Enabled ;
      private int idxLst ;
      private long wcpOAV7IDCOMPRA ;
      private long Z11IDCOMPRA ;
      private long Z10IDPROVEEDOR ;
      private long Z1IDEMPLEADO ;
      private long N10IDPROVEEDOR ;
      private long N1IDEMPLEADO ;
      private long Z7IDPRODUCTO ;
      private long A11IDCOMPRA ;
      private long A10IDPROVEEDOR ;
      private long A1IDEMPLEADO ;
      private long A7IDPRODUCTO ;
      private long AV7IDCOMPRA ;
      private long A41CANTIDADPRODUCTO ;
      private long AV11Insert_IDPROVEEDOR ;
      private long AV13Insert_IDEMPLEADO ;
      private long GRIDCOMPRA_INVENTARIO_DETALLE_COMPRA_PRODUCTO_nFirstRecordOnPage ;
      private long Z41CANTIDADPRODUCTO ;
      private decimal O61TOTALCOMPRAPRODUCTO ;
      private decimal O60SUBTOTALCOMPRAPRODUCTO ;
      private decimal A61TOTALCOMPRAPRODUCTO ;
      private decimal A42PRECIOCOMPRAPRODUCTO ;
      private decimal A60SUBTOTALCOMPRAPRODUCTO ;
      private decimal B61TOTALCOMPRAPRODUCTO ;
      private decimal s61TOTALCOMPRAPRODUCTO ;
      private decimal T60SUBTOTALCOMPRAPRODUCTO ;
      private decimal Z61TOTALCOMPRAPRODUCTO ;
      private decimal Z42PRECIOCOMPRAPRODUCTO ;
      private decimal Z60SUBTOTALCOMPRAPRODUCTO ;
      private string sPrefix ;
      private string sGXsfl_73_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDESCRIPCIONCOMPRA_Internalname ;
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
      private string edtIDCOMPRA_Internalname ;
      private string edtIDCOMPRA_Jsonclick ;
      private string edtFECHACOMPRA_Internalname ;
      private string edtFECHACOMPRA_Jsonclick ;
      private string edtIDPROVEEDOR_Internalname ;
      private string edtIDPROVEEDOR_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_10_Internalname ;
      private string imgprompt_10_Link ;
      private string edtNOMBREPROVEEDOR_Internalname ;
      private string edtIDEMPLEADO_Internalname ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtNOMBRECOMPLETOEMPLEADO_Internalname ;
      private string divDetalle_compra_productotable_Internalname ;
      private string lblTitledetalle_compra_producto_Internalname ;
      private string lblTitledetalle_compra_producto_Jsonclick ;
      private string edtTOTALCOMPRAPRODUCTO_Internalname ;
      private string edtTOTALCOMPRAPRODUCTO_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridcompra_inventario_detalle_compra_producto_Header ;
      private string sMode3 ;
      private string edtIDPRODUCTO_Internalname ;
      private string edtDESCRIPCIONPRODUCTO_Internalname ;
      private string edtCANTIDADPRODUCTO_Internalname ;
      private string edtPRECIOCOMPRAPRODUCTO_Internalname ;
      private string edtSUBTOTALCOMPRAPRODUCTO_Internalname ;
      private string sStyleString ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_7_Internalname ;
      private string sGXsfl_73_fel_idx="0001" ;
      private string subGridcompra_inventario_detalle_compra_producto_Class ;
      private string subGridcompra_inventario_detalle_compra_producto_Linesclass ;
      private string imgprompt_7_Link ;
      private string ROClassString ;
      private string edtIDPRODUCTO_Jsonclick ;
      private string edtDESCRIPCIONPRODUCTO_Jsonclick ;
      private string edtCANTIDADPRODUCTO_Jsonclick ;
      private string edtPRECIOCOMPRAPRODUCTO_Jsonclick ;
      private string edtSUBTOTALCOMPRAPRODUCTO_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridcompra_inventario_detalle_compra_producto_Internalname ;
      private DateTime Z50FECHACOMPRA ;
      private DateTime A50FECHACOMPRA ;
      private DateTime Gx_date ;
      private DateTime i50FECHACOMPRA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n61TOTALCOMPRAPRODUCTO ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool returnInSub ;
      private bool n60SUBTOTALCOMPRAPRODUCTO ;
      private string Z51DESCRIPCIONCOMPRA ;
      private string A51DESCRIPCIONCOMPRA ;
      private string A46NOMBREPROVEEDOR ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private string A40DESCRIPCIONPRODUCTO ;
      private string Z46NOMBREPROVEEDOR ;
      private string Z23NOMBRECOMPLETOEMPLEADO ;
      private string Z40DESCRIPCIONPRODUCTO ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridcompra_inventario_detalle_compra_productoContainer ;
      private GXWebRow Gridcompra_inventario_detalle_compra_productoRow ;
      private GXWebColumn Gridcompra_inventario_detalle_compra_productoColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000213_A61TOTALCOMPRAPRODUCTO ;
      private bool[] T000213_n61TOTALCOMPRAPRODUCTO ;
      private string[] T000210_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] T00029_A46NOMBREPROVEEDOR ;
      private long[] T000216_A11IDCOMPRA ;
      private DateTime[] T000216_A50FECHACOMPRA ;
      private string[] T000216_A51DESCRIPCIONCOMPRA ;
      private string[] T000216_A46NOMBREPROVEEDOR ;
      private string[] T000216_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] T000216_A10IDPROVEEDOR ;
      private long[] T000216_A1IDEMPLEADO ;
      private decimal[] T000216_A61TOTALCOMPRAPRODUCTO ;
      private bool[] T000216_n61TOTALCOMPRAPRODUCTO ;
      private decimal[] T000219_A61TOTALCOMPRAPRODUCTO ;
      private bool[] T000219_n61TOTALCOMPRAPRODUCTO ;
      private string[] T000220_A46NOMBREPROVEEDOR ;
      private string[] T000221_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] T000222_A11IDCOMPRA ;
      private long[] T00028_A11IDCOMPRA ;
      private DateTime[] T00028_A50FECHACOMPRA ;
      private string[] T00028_A51DESCRIPCIONCOMPRA ;
      private long[] T00028_A10IDPROVEEDOR ;
      private long[] T00028_A1IDEMPLEADO ;
      private long[] T000223_A11IDCOMPRA ;
      private long[] T000224_A11IDCOMPRA ;
      private long[] T00027_A11IDCOMPRA ;
      private DateTime[] T00027_A50FECHACOMPRA ;
      private string[] T00027_A51DESCRIPCIONCOMPRA ;
      private long[] T00027_A10IDPROVEEDOR ;
      private long[] T00027_A1IDEMPLEADO ;
      private long[] T000225_A11IDCOMPRA ;
      private decimal[] T000230_A61TOTALCOMPRAPRODUCTO ;
      private bool[] T000230_n61TOTALCOMPRAPRODUCTO ;
      private string[] T000231_A46NOMBREPROVEEDOR ;
      private string[] T000232_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] T000233_A11IDCOMPRA ;
      private long[] T000235_A11IDCOMPRA ;
      private string[] T000235_A40DESCRIPCIONPRODUCTO ;
      private long[] T000235_A41CANTIDADPRODUCTO ;
      private decimal[] T000235_A42PRECIOCOMPRAPRODUCTO ;
      private long[] T000235_A7IDPRODUCTO ;
      private decimal[] T000235_A60SUBTOTALCOMPRAPRODUCTO ;
      private bool[] T000235_n60SUBTOTALCOMPRAPRODUCTO ;
      private string[] T00024_A40DESCRIPCIONPRODUCTO ;
      private long[] T00024_A41CANTIDADPRODUCTO ;
      private decimal[] T00024_A42PRECIOCOMPRAPRODUCTO ;
      private decimal[] T00026_A60SUBTOTALCOMPRAPRODUCTO ;
      private bool[] T00026_n60SUBTOTALCOMPRAPRODUCTO ;
      private string[] T000236_A40DESCRIPCIONPRODUCTO ;
      private long[] T000236_A41CANTIDADPRODUCTO ;
      private decimal[] T000236_A42PRECIOCOMPRAPRODUCTO ;
      private decimal[] T000238_A60SUBTOTALCOMPRAPRODUCTO ;
      private bool[] T000238_n60SUBTOTALCOMPRAPRODUCTO ;
      private long[] T000239_A11IDCOMPRA ;
      private long[] T000239_A7IDPRODUCTO ;
      private long[] T00023_A11IDCOMPRA ;
      private long[] T00023_A7IDPRODUCTO ;
      private long[] T00022_A11IDCOMPRA ;
      private long[] T00022_A7IDPRODUCTO ;
      private string[] T000242_A40DESCRIPCIONPRODUCTO ;
      private long[] T000242_A41CANTIDADPRODUCTO ;
      private decimal[] T000242_A42PRECIOCOMPRAPRODUCTO ;
      private decimal[] T000244_A60SUBTOTALCOMPRAPRODUCTO ;
      private bool[] T000244_n60SUBTOTALCOMPRAPRODUCTO ;
      private long[] T000245_A11IDCOMPRA ;
      private long[] T000245_A7IDPRODUCTO ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class compra_inventario__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000224;
          prmT000224 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000225;
          prmT000225 = new Object[] {
          new ParDef("@FECHACOMPRA",GXType.Date,8,0) ,
          new ParDef("@DESCRIPCIONCOMPRA",GXType.NVarChar,255,0) ,
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000226;
          prmT000226 = new Object[] {
          new ParDef("@FECHACOMPRA",GXType.Date,8,0) ,
          new ParDef("@DESCRIPCIONCOMPRA",GXType.NVarChar,255,0) ,
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0) ,
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000227;
          prmT000227 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000233;
          prmT000233 = new Object[] {
          };
          Object[] prmT000235;
          prmT000235 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000236;
          prmT000236 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000238;
          prmT000238 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000239;
          prmT000239 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000240;
          prmT000240 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000241;
          prmT000241 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000245;
          prmT000245 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000230;
          prmT000230 = new Object[] {
          new ParDef("@IDCOMPRA",GXType.Decimal,12,0)
          };
          Object[] prmT000231;
          prmT000231 = new Object[] {
          new ParDef("@IDPROVEEDOR",GXType.Decimal,12,0)
          };
          Object[] prmT000232;
          prmT000232 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000242;
          prmT000242 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000244;
          prmT000244 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [IDCOMPRA], [IDPRODUCTO] FROM [Compra_inventarioCompra_produc] WITH (UPDLOCK) WHERE [IDCOMPRA] = @IDCOMPRA AND [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [IDCOMPRA], [IDPRODUCTO] FROM [Compra_inventarioCompra_produc] WHERE [IDCOMPRA] = @IDCOMPRA AND [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOCOMPRAPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT COALESCE( T1.[SUBTOTALCOMPRAPRODUCTO], 0) AS SUBTOTALCOMPRAPRODUCTO FROM (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T1 WHERE T1.[IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [IDCOMPRA], [FECHACOMPRA], [DESCRIPCIONCOMPRA], [IDPROVEEDOR], [IDEMPLEADO] FROM [Compra_inventario] WITH (UPDLOCK) WHERE [IDCOMPRA] = @IDCOMPRA ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [IDCOMPRA], [FECHACOMPRA], [DESCRIPCIONCOMPRA], [IDPROVEEDOR], [IDEMPLEADO] FROM [Compra_inventario] WHERE [IDCOMPRA] = @IDCOMPRA ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [NOMBREPROVEEDOR] FROM [Proveedores] WHERE [IDPROVEEDOR] = @IDPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [NOMBRECOMPLETOEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000213", "SELECT COALESCE( T1.[TOTALCOMPRAPRODUCTO], 0) AS TOTALCOMPRAPRODUCTO FROM (SELECT SUM(COALESCE( T3.[SUBTOTALCOMPRAPRODUCTO], 0)) AS TOTALCOMPRAPRODUCTO, T2.[IDCOMPRA] FROM ([Compra_inventarioCompra_produc] T2 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T3 ON T3.[IDPRODUCTO] = T2.[IDPRODUCTO]) GROUP BY T2.[IDCOMPRA] ) T1 WHERE T1.[IDCOMPRA] = @IDCOMPRA ",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000216", "SELECT TM1.[IDCOMPRA], TM1.[FECHACOMPRA], TM1.[DESCRIPCIONCOMPRA], T3.[NOMBREPROVEEDOR], T4.[NOMBRECOMPLETOEMPLEADO], TM1.[IDPROVEEDOR], TM1.[IDEMPLEADO], COALESCE( T2.[TOTALCOMPRAPRODUCTO], 0) AS TOTALCOMPRAPRODUCTO FROM ((([Compra_inventario] TM1 LEFT JOIN (SELECT SUM(COALESCE( T6.[SUBTOTALCOMPRAPRODUCTO], 0)) AS TOTALCOMPRAPRODUCTO, T5.[IDCOMPRA] FROM ([Compra_inventarioCompra_produc] T5 INNER JOIN (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T6 ON T6.[IDPRODUCTO] = T5.[IDPRODUCTO]) GROUP BY T5.[IDCOMPRA] ) T2 ON T2.[IDCOMPRA] = TM1.[IDCOMPRA]) INNER JOIN [Proveedores] T3 ON T3.[IDPROVEEDOR] = TM1.[IDPROVEEDOR]) INNER JOIN [Empleados] T4 ON T4.[IDEMPLEADO] = TM1.[IDEMPLEADO]) WHERE TM1.[IDCOMPRA] = @IDCOMPRA ORDER BY TM1.[IDCOMPRA]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000219", "SELECT COALESCE( T1.[TOTALCOMPRAPRODUCTO], 0) AS TOTALCOMPRAPRODUCTO FROM (SELECT SUM(COALESCE( T3.[SUBTOTALCOMPRAPRODUCTO], 0)) AS TOTALCOMPRAPRODUCTO, T2.[IDCOMPRA] FROM ([Compra_inventarioCompra_produc] T2 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T3 ON T3.[IDPRODUCTO] = T2.[IDPRODUCTO]) GROUP BY T2.[IDCOMPRA] ) T1 WHERE T1.[IDCOMPRA] = @IDCOMPRA ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000220", "SELECT [NOMBREPROVEEDOR] FROM [Proveedores] WHERE [IDPROVEEDOR] = @IDPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000221", "SELECT [NOMBRECOMPLETOEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000222", "SELECT [IDCOMPRA] FROM [Compra_inventario] WHERE [IDCOMPRA] = @IDCOMPRA  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000223", "SELECT TOP 1 [IDCOMPRA] FROM [Compra_inventario] WHERE ( [IDCOMPRA] > @IDCOMPRA) ORDER BY [IDCOMPRA]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000224", "SELECT TOP 1 [IDCOMPRA] FROM [Compra_inventario] WHERE ( [IDCOMPRA] < @IDCOMPRA) ORDER BY [IDCOMPRA] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000225", "INSERT INTO [Compra_inventario]([FECHACOMPRA], [DESCRIPCIONCOMPRA], [IDPROVEEDOR], [IDEMPLEADO]) VALUES(@FECHACOMPRA, @DESCRIPCIONCOMPRA, @IDPROVEEDOR, @IDEMPLEADO); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000225)
             ,new CursorDef("T000226", "UPDATE [Compra_inventario] SET [FECHACOMPRA]=@FECHACOMPRA, [DESCRIPCIONCOMPRA]=@DESCRIPCIONCOMPRA, [IDPROVEEDOR]=@IDPROVEEDOR, [IDEMPLEADO]=@IDEMPLEADO  WHERE [IDCOMPRA] = @IDCOMPRA", GxErrorMask.GX_NOMASK,prmT000226)
             ,new CursorDef("T000227", "DELETE FROM [Compra_inventario]  WHERE [IDCOMPRA] = @IDCOMPRA", GxErrorMask.GX_NOMASK,prmT000227)
             ,new CursorDef("T000230", "SELECT COALESCE( T1.[TOTALCOMPRAPRODUCTO], 0) AS TOTALCOMPRAPRODUCTO FROM (SELECT SUM(COALESCE( T3.[SUBTOTALCOMPRAPRODUCTO], 0)) AS TOTALCOMPRAPRODUCTO, T2.[IDCOMPRA] FROM ([Compra_inventarioCompra_produc] T2 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T3 ON T3.[IDPRODUCTO] = T2.[IDPRODUCTO]) GROUP BY T2.[IDCOMPRA] ) T1 WHERE T1.[IDCOMPRA] = @IDCOMPRA ",true, GxErrorMask.GX_NOMASK, false, this,prmT000230,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000231", "SELECT [NOMBREPROVEEDOR] FROM [Proveedores] WHERE [IDPROVEEDOR] = @IDPROVEEDOR ",true, GxErrorMask.GX_NOMASK, false, this,prmT000231,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000232", "SELECT [NOMBRECOMPLETOEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000232,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000233", "SELECT [IDCOMPRA] FROM [Compra_inventario] ORDER BY [IDCOMPRA]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000233,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000235", "SELECT T1.[IDCOMPRA], T2.[DESCRIPCIONPRODUCTO], T2.[CANTIDADPRODUCTO], T2.[PRECIOCOMPRAPRODUCTO], T1.[IDPRODUCTO], COALESCE( T3.[SUBTOTALCOMPRAPRODUCTO], 0) AS SUBTOTALCOMPRAPRODUCTO FROM (([Compra_inventarioCompra_produc] T1 INNER JOIN [Inventario] T2 ON T2.[IDPRODUCTO] = T1.[IDPRODUCTO]) INNER JOIN (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T3 ON T3.[IDPRODUCTO] = T1.[IDPRODUCTO]) WHERE T1.[IDCOMPRA] = @IDCOMPRA and T1.[IDPRODUCTO] = @IDPRODUCTO ORDER BY T1.[IDCOMPRA], T1.[IDPRODUCTO] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000235,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000236", "SELECT [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOCOMPRAPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000236,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000238", "SELECT COALESCE( T1.[SUBTOTALCOMPRAPRODUCTO], 0) AS SUBTOTALCOMPRAPRODUCTO FROM (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T1 WHERE T1.[IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000238,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000239", "SELECT [IDCOMPRA], [IDPRODUCTO] FROM [Compra_inventarioCompra_produc] WHERE [IDCOMPRA] = @IDCOMPRA AND [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000239,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000240", "INSERT INTO [Compra_inventarioCompra_produc]([IDCOMPRA], [IDPRODUCTO]) VALUES(@IDCOMPRA, @IDPRODUCTO)", GxErrorMask.GX_NOMASK,prmT000240)
             ,new CursorDef("T000241", "DELETE FROM [Compra_inventarioCompra_produc]  WHERE [IDCOMPRA] = @IDCOMPRA AND [IDPRODUCTO] = @IDPRODUCTO", GxErrorMask.GX_NOMASK,prmT000241)
             ,new CursorDef("T000242", "SELECT [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOCOMPRAPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000242,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000244", "SELECT COALESCE( T1.[SUBTOTALCOMPRAPRODUCTO], 0) AS SUBTOTALCOMPRAPRODUCTO FROM (SELECT COALESCE( [GXC1], 0) AS SUBTOTALCOMPRAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T1 WHERE T1.[IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000244,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000245", "SELECT [IDCOMPRA], [IDPRODUCTO] FROM [Compra_inventarioCompra_produc] WHERE [IDCOMPRA] = @IDCOMPRA ORDER BY [IDCOMPRA], [IDPRODUCTO] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000245,11, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 15 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 16 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 23 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 25 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 31 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
