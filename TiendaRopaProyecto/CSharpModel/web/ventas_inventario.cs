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
   public class ventas_inventario : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_30") == 0 )
         {
            A12IDVENTA = (long)(NumberUtil.Val( GetPar( "IDVENTA"), "."));
            AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_30( A12IDVENTA) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A12IDVENTA = (long)(NumberUtil.Val( GetPar( "IDVENTA"), "."));
            AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
            A57IMPUESTOVENTA = NumberUtil.Val( GetPar( "IMPUESTOVENTA"), ".");
            n57IMPUESTOVENTA = false;
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
            A58DESCUENTOVENTA = NumberUtil.Val( GetPar( "DESCUENTOVENTA"), ".");
            AssignAttri("", false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A12IDVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A1IDEMPLEADO = (long)(NumberUtil.Val( GetPar( "IDEMPLEADO"), "."));
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A1IDEMPLEADO) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A4IDCLIENTE = (long)(NumberUtil.Val( GetPar( "IDCLIENTE"), "."));
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A4IDCLIENTE) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A7IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A7IDPRODUCTO) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A7IDPRODUCTO = (long)(NumberUtil.Val( GetPar( "IDPRODUCTO"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A7IDPRODUCTO) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridventas_inventario_detalle_venta_producto") == 0 )
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
            gxnrGridventas_inventario_detalle_venta_producto_newrow( ) ;
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
               AV7IDVENTA = (long)(NumberUtil.Val( GetPar( "IDVENTA"), "."));
               AssignAttri("", false, "AV7IDVENTA", StringUtil.LTrimStr( (decimal)(AV7IDVENTA), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDVENTA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDVENTA), "ZZZZZZZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Ventas_inventario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ventas_inventario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public ventas_inventario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_IDVENTA )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IDVENTA = aP1_IDVENTA;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Ventas_inventario", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Ventas_inventario.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Ventas_inventario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDVENTA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDVENTA_Internalname, "IDVENTA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIDVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12IDVENTA), 12, 0, ".", "")), ((edtIDVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDVENTA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDVENTA_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFECHAVENTA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFECHAVENTA_Internalname, "FECHAVENTA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtFECHAVENTA_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFECHAVENTA_Internalname, context.localUtil.Format(A54FECHAVENTA, "99/99/99"), context.localUtil.Format( A54FECHAVENTA, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFECHAVENTA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFECHAVENTA_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ventas_inventario.htm");
         GxWebStd.gx_bitmap( context, edtFECHAVENTA_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFECHAVENTA_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ventas_inventario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCRIPCIONVENTA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCRIPCIONVENTA_Internalname, "DESCRIPCIONVENTA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDESCRIPCIONVENTA_Internalname, A55DESCRIPCIONVENTA, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtDESCRIPCIONVENTA_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Ventas_inventario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDEMPLEADO_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDEMPLEADO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDEMPLEADO_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Ventas_inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas_inventario.htm");
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
         GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOEMPLEADO_Internalname, A23NOMBRECOMPLETOEMPLEADO, "", "", 0, 1, edtNOMBRECOMPLETOEMPLEADO_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIDCLIENTE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIDCLIENTE_Internalname, "IDCLIENTE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIDCLIENTE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4IDCLIENTE), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIDCLIENTE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIDCLIENTE_Enabled, 1, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Codigo", "right", false, "", "HLP_Ventas_inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ventas_inventario.htm");
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
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNOMBRECOMPLETOCLIENTE_Internalname, A30NOMBRECOMPLETOCLIENTE, "", "", 0, 1, edtNOMBRECOMPLETOCLIENTE_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "Nombre", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDetalle_venta_productotable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitledetalle_venta_producto_Internalname, "Detalle_venta_producto", "", "", lblTitledetalle_venta_producto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridventas_inventario_detalle_venta_producto( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtIMPUESTOVENTA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIMPUESTOVENTA_Internalname, "IMPUESTOVENTA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIMPUESTOVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( A57IMPUESTOVENTA, 12, 2, ".", "")), ((edtIMPUESTOVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A57IMPUESTOVENTA, "ZZZZZZZZ9.99")) : context.localUtil.Format( A57IMPUESTOVENTA, "ZZZZZZZZ9.99")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIMPUESTOVENTA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIMPUESTOVENTA_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDESCUENTOVENTA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDESCUENTOVENTA_Internalname, "DESCUENTOVENTA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDESCUENTOVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( A58DESCUENTOVENTA, 12, 2, ".", "")), ((edtDESCUENTOVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99")) : context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDESCUENTOVENTA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDESCUENTOVENTA_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTOTALVENTA_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTOTALVENTA_Internalname, "TOTALVENTA", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTOTALVENTA_Internalname, StringUtil.LTrim( StringUtil.NToC( A59TOTALVENTA, 12, 2, ".", "")), ((edtTOTALVENTA_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A59TOTALVENTA, "ZZZZZZZZ9.99")) : context.localUtil.Format( A59TOTALVENTA, "ZZZZZZZZ9.99")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTOTALVENTA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTOTALVENTA_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "Money", "right", false, "", "HLP_Ventas_inventario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ventas_inventario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridventas_inventario_detalle_venta_producto( )
      {
         /*  Grid Control  */
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("GridName", "Gridventas_inventario_detalle_venta_producto");
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Header", subGridventas_inventario_detalle_venta_producto_Header);
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Class", "Grid");
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Backcolorstyle), 1, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("CmpContext", "");
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("InMasterPage", "false");
         Gridventas_inventario_detalle_venta_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddColumnProperties(Gridventas_inventario_detalle_venta_productoColumn);
         Gridventas_inventario_detalle_venta_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridventas_inventario_detalle_venta_productoContainer.AddColumnProperties(Gridventas_inventario_detalle_venta_productoColumn);
         Gridventas_inventario_detalle_venta_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Value", A40DESCRIPCIONPRODUCTO);
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddColumnProperties(Gridventas_inventario_detalle_venta_productoColumn);
         Gridventas_inventario_detalle_venta_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddColumnProperties(Gridventas_inventario_detalle_venta_productoColumn);
         Gridventas_inventario_detalle_venta_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddColumnProperties(Gridventas_inventario_detalle_venta_productoColumn);
         Gridventas_inventario_detalle_venta_productoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A56SUBTOTALVENTAPRODUCTO, 12, 2, ".", "")));
         Gridventas_inventario_detalle_venta_productoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddColumnProperties(Gridventas_inventario_detalle_venta_productoColumn);
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Selectedindex), 4, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Allowselection), 1, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Selectioncolor), 9, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Allowhovering), 1, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Hoveringcolor), 9, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Allowcollapsing), 1, 0, ".", "")));
         Gridventas_inventario_detalle_venta_productoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridventas_inventario_detalle_venta_producto_Collapsed), 1, 0, ".", "")));
         nGXsfl_73_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount5 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_5 = 1;
               ScanStart035( ) ;
               while ( RcdFound5 != 0 )
               {
                  init_level_properties5( ) ;
                  getByPrimaryKey035( ) ;
                  AddRow035( ) ;
                  ScanNext035( ) ;
               }
               ScanEnd035( ) ;
               nBlankRcdCount5 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal035( ) ;
            standaloneModal035( ) ;
            sMode5 = Gx_mode;
            while ( nGXsfl_73_idx < nRC_GXsfl_73 )
            {
               bGXsfl_73_Refreshing = true;
               ReadRow035( ) ;
               edtIDPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtDESCRIPCIONPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtDESCRIPCIONPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtCANTIDADPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCANTIDADPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtPRECIOVENTAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRECIOVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtPRECIOVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtSUBTOTALVENTAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "SUBTOTALVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtSUBTOTALVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               imgprompt_1_Link = cgiGet( "PROMPT_7_"+sGXsfl_73_idx+"Link");
               if ( ( nRcdExists_5 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal035( ) ;
               }
               SendRow035( ) ;
               bGXsfl_73_Refreshing = false;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount5 = 5;
            nRcdExists_5 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart035( ) ;
               while ( RcdFound5 != 0 )
               {
                  sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_735( ) ;
                  init_level_properties5( ) ;
                  standaloneNotModal035( ) ;
                  getByPrimaryKey035( ) ;
                  standaloneModal035( ) ;
                  AddRow035( ) ;
                  ScanNext035( ) ;
               }
               ScanEnd035( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode5 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
            SubsflControlProps_735( ) ;
            InitAll035( ) ;
            init_level_properties5( ) ;
            nRcdExists_5 = 0;
            nIsMod_5 = 0;
            nRcdDeleted_5 = 0;
            nBlankRcdCount5 = (short)(nBlankRcdUsr5+nBlankRcdCount5);
            fRowAdded = 0;
            while ( nBlankRcdCount5 > 0 )
            {
               standaloneNotModal035( ) ;
               standaloneModal035( ) ;
               AddRow035( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtIDPRODUCTO_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount5 = (short)(nBlankRcdCount5-1);
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridventas_inventario_detalle_venta_productoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridventas_inventario_detalle_venta_producto", Gridventas_inventario_detalle_venta_productoContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridventas_inventario_detalle_venta_productoContainerData", Gridventas_inventario_detalle_venta_productoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridventas_inventario_detalle_venta_productoContainerData"+"V", Gridventas_inventario_detalle_venta_productoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridventas_inventario_detalle_venta_productoContainerData"+"V"+"\" value='"+Gridventas_inventario_detalle_venta_productoContainer.GridValuesHidden()+"'/>") ;
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z12IDVENTA = (long)(context.localUtil.CToN( cgiGet( "Z12IDVENTA"), ".", ","));
               Z54FECHAVENTA = context.localUtil.CToD( cgiGet( "Z54FECHAVENTA"), 0);
               Z55DESCRIPCIONVENTA = cgiGet( "Z55DESCRIPCIONVENTA");
               Z58DESCUENTOVENTA = context.localUtil.CToN( cgiGet( "Z58DESCUENTOVENTA"), ".", ",");
               Z1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "Z1IDEMPLEADO"), ".", ","));
               Z4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( "Z4IDCLIENTE"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_73 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_73"), ".", ","));
               N1IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "N1IDEMPLEADO"), ".", ","));
               N4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( "N4IDCLIENTE"), ".", ","));
               AV7IDVENTA = (long)(context.localUtil.CToN( cgiGet( "vIDVENTA"), ".", ","));
               AV13Insert_IDEMPLEADO = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDEMPLEADO"), ".", ","));
               AV11Insert_IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( "vINSERT_IDCLIENTE"), ".", ","));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A12IDVENTA = (long)(context.localUtil.CToN( cgiGet( edtIDVENTA_Internalname), ".", ","));
               AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
               A54FECHAVENTA = context.localUtil.CToD( cgiGet( edtFECHAVENTA_Internalname), 1);
               AssignAttri("", false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
               A55DESCRIPCIONVENTA = cgiGet( edtDESCRIPCIONVENTA_Internalname);
               AssignAttri("", false, "A55DESCRIPCIONVENTA", A55DESCRIPCIONVENTA);
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDCLIENTE");
                  AnyError = 1;
                  GX_FocusControl = edtIDCLIENTE_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4IDCLIENTE = 0;
                  AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
               }
               else
               {
                  A4IDCLIENTE = (long)(context.localUtil.CToN( cgiGet( edtIDCLIENTE_Internalname), ".", ","));
                  AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
               }
               A30NOMBRECOMPLETOCLIENTE = cgiGet( edtNOMBRECOMPLETOCLIENTE_Internalname);
               AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
               A57IMPUESTOVENTA = context.localUtil.CToN( cgiGet( edtIMPUESTOVENTA_Internalname), ".", ",");
               n57IMPUESTOVENTA = false;
               AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
               A58DESCUENTOVENTA = context.localUtil.CToN( cgiGet( edtDESCUENTOVENTA_Internalname), ".", ",");
               AssignAttri("", false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
               A59TOTALVENTA = context.localUtil.CToN( cgiGet( edtTOTALVENTA_Internalname), ".", ",");
               n59TOTALVENTA = false;
               AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Ventas_inventario");
               A12IDVENTA = (long)(context.localUtil.CToN( cgiGet( edtIDVENTA_Internalname), ".", ","));
               AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
               forbiddenHiddens.Add("IDVENTA", context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               A54FECHAVENTA = context.localUtil.CToD( cgiGet( edtFECHAVENTA_Internalname), 1);
               AssignAttri("", false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
               forbiddenHiddens.Add("FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
               A58DESCUENTOVENTA = context.localUtil.CToN( cgiGet( edtDESCUENTOVENTA_Internalname), ".", ",");
               AssignAttri("", false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
               forbiddenHiddens.Add("DESCUENTOVENTA", context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A12IDVENTA != Z12IDVENTA ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("ventas_inventario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A12IDVENTA = (long)(NumberUtil.Val( GetPar( "IDVENTA"), "."));
                  AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
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
                     sMode4 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode4;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound4 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDVENTA");
                        AnyError = 1;
                        GX_FocusControl = edtIDVENTA_Internalname;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll034( ) ;
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
            DisableAttributes034( ) ;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls034( ) ;
            }
            else
            {
               CheckExtendedTable034( ) ;
               CloseExtendedTableCursors034( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode4 = Gx_mode;
            CONFIRM_035( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode4;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_035( )
      {
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow035( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               GetKey035( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate035( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable035( ) ;
                        CloseExtendedTableCursors035( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
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
                  if ( RcdFound5 != 0 )
                  {
                     if ( nRcdDeleted_5 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey035( ) ;
                        Load035( ) ;
                        BeforeValidate035( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls035( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate035( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable035( ) ;
                              CloseExtendedTableCursors035( ) ;
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
                     if ( nRcdDeleted_5 == 0 )
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
            ChangePostValue( edtPRECIOVENTAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( edtSUBTOTALVENTAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A56SUBTOTALVENTAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7IDPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRECIOVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUBTOTALVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T000314 */
         pr_default.execute(5, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A57IMPUESTOVENTA = T000314_A57IMPUESTOVENTA[0];
            n57IMPUESTOVENTA = T000314_n57IMPUESTOVENTA[0];
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         else
         {
            A57IMPUESTOVENTA = 0;
            n57IMPUESTOVENTA = false;
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         /* Using cursor T000310 */
         pr_default.execute(4, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A59TOTALVENTA = T000310_A59TOTALVENTA[0];
            n59TOTALVENTA = T000310_n59TOTALVENTA[0];
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         /* Using cursor T000310 */
         pr_default.execute(4, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(4) != 101) )
         {
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         pr_default.close(4);
         /* End of After( level) rules */
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "TiendaRopaProyecto");
         AV13Insert_IDEMPLEADO = 0;
         AssignAttri("", false, "AV13Insert_IDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV13Insert_IDEMPLEADO), 12, 0));
         AV11Insert_IDCLIENTE = 0;
         AssignAttri("", false, "AV11Insert_IDCLIENTE", StringUtil.LTrimStr( (decimal)(AV11Insert_IDCLIENTE), 12, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "IDEMPLEADO") == 0 )
               {
                  AV13Insert_IDEMPLEADO = (long)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_IDEMPLEADO", StringUtil.LTrimStr( (decimal)(AV13Insert_IDEMPLEADO), 12, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "IDCLIENTE") == 0 )
               {
                  AV11Insert_IDCLIENTE = (long)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_IDCLIENTE", StringUtil.LTrimStr( (decimal)(AV11Insert_IDCLIENTE), 12, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwventas_inventario.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM034( short GX_JID )
      {
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z54FECHAVENTA = T000316_A54FECHAVENTA[0];
               Z55DESCRIPCIONVENTA = T000316_A55DESCRIPCIONVENTA[0];
               Z58DESCUENTOVENTA = T000316_A58DESCUENTOVENTA[0];
               Z1IDEMPLEADO = T000316_A1IDEMPLEADO[0];
               Z4IDCLIENTE = T000316_A4IDCLIENTE[0];
            }
            else
            {
               Z54FECHAVENTA = A54FECHAVENTA;
               Z55DESCRIPCIONVENTA = A55DESCRIPCIONVENTA;
               Z58DESCUENTOVENTA = A58DESCUENTOVENTA;
               Z1IDEMPLEADO = A1IDEMPLEADO;
               Z4IDCLIENTE = A4IDCLIENTE;
            }
         }
         if ( GX_JID == -28 )
         {
            Z12IDVENTA = A12IDVENTA;
            Z54FECHAVENTA = A54FECHAVENTA;
            Z55DESCRIPCIONVENTA = A55DESCRIPCIONVENTA;
            Z58DESCUENTOVENTA = A58DESCUENTOVENTA;
            Z1IDEMPLEADO = A1IDEMPLEADO;
            Z4IDCLIENTE = A4IDCLIENTE;
            Z23NOMBRECOMPLETOEMPLEADO = A23NOMBRECOMPLETOEMPLEADO;
            Z30NOMBRECOMPLETOCLIENTE = A30NOMBRECOMPLETOCLIENTE;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIDVENTA_Enabled = 0;
         AssignProp("", false, edtIDVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDVENTA_Enabled), 5, 0), true);
         edtFECHAVENTA_Enabled = 0;
         AssignProp("", false, edtFECHAVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHAVENTA_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOEMPLEADO_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOCLIENTE_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOCLIENTE_Enabled), 5, 0), true);
         edtIMPUESTOVENTA_Enabled = 0;
         AssignProp("", false, edtIMPUESTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIMPUESTOVENTA_Enabled), 5, 0), true);
         edtDESCUENTOVENTA_Enabled = 0;
         AssignProp("", false, edtDESCUENTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCUENTOVENTA_Enabled), 5, 0), true);
         edtTOTALVENTA_Enabled = 0;
         AssignProp("", false, edtTOTALVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALVENTA_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDEMPLEADO"+"'), id:'"+"IDEMPLEADO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDCLIENTE"+"'), id:'"+"IDCLIENTE"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtIDVENTA_Enabled = 0;
         AssignProp("", false, edtIDVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDVENTA_Enabled), 5, 0), true);
         edtFECHAVENTA_Enabled = 0;
         AssignProp("", false, edtFECHAVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHAVENTA_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOEMPLEADO_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOCLIENTE_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOCLIENTE_Enabled), 5, 0), true);
         edtIMPUESTOVENTA_Enabled = 0;
         AssignProp("", false, edtIMPUESTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIMPUESTOVENTA_Enabled), 5, 0), true);
         edtDESCUENTOVENTA_Enabled = 0;
         AssignProp("", false, edtDESCUENTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCUENTOVENTA_Enabled), 5, 0), true);
         edtTOTALVENTA_Enabled = 0;
         AssignProp("", false, edtTOTALVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALVENTA_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IDVENTA) )
         {
            A12IDVENTA = AV7IDVENTA;
            AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDCLIENTE) )
         {
            edtIDCLIENTE_Enabled = 0;
            AssignProp("", false, edtIDCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCLIENTE_Enabled), 5, 0), true);
         }
         else
         {
            edtIDCLIENTE_Enabled = 1;
            AssignProp("", false, edtIDCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCLIENTE_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_IDCLIENTE) )
         {
            A4IDCLIENTE = AV11Insert_IDCLIENTE;
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_IDEMPLEADO) )
         {
            A1IDEMPLEADO = AV13Insert_IDEMPLEADO;
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A54FECHAVENTA) && ( Gx_BScreen == 0 ) )
         {
            A54FECHAVENTA = Gx_date;
            AssignAttri("", false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000314 */
            pr_default.execute(5, new Object[] {A12IDVENTA});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A57IMPUESTOVENTA = T000314_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = T000314_n57IMPUESTOVENTA[0];
               AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
            }
            else
            {
               A57IMPUESTOVENTA = 0;
               n57IMPUESTOVENTA = false;
               AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
            }
            pr_default.close(5);
            AV16Pgmname = "Ventas_inventario";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000318 */
            pr_default.execute(9, new Object[] {A4IDCLIENTE});
            A30NOMBRECOMPLETOCLIENTE = T000318_A30NOMBRECOMPLETOCLIENTE[0];
            AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
            pr_default.close(9);
            /* Using cursor T000317 */
            pr_default.execute(8, new Object[] {A1IDEMPLEADO});
            A23NOMBRECOMPLETOEMPLEADO = T000317_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            pr_default.close(8);
         }
      }

      protected void Load034( )
      {
         /* Using cursor T000319 */
         pr_default.execute(10, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound4 = 1;
            A54FECHAVENTA = T000319_A54FECHAVENTA[0];
            AssignAttri("", false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
            A55DESCRIPCIONVENTA = T000319_A55DESCRIPCIONVENTA[0];
            AssignAttri("", false, "A55DESCRIPCIONVENTA", A55DESCRIPCIONVENTA);
            A23NOMBRECOMPLETOEMPLEADO = T000319_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            A30NOMBRECOMPLETOCLIENTE = T000319_A30NOMBRECOMPLETOCLIENTE[0];
            AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
            A58DESCUENTOVENTA = T000319_A58DESCUENTOVENTA[0];
            AssignAttri("", false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
            A1IDEMPLEADO = T000319_A1IDEMPLEADO[0];
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            A4IDCLIENTE = T000319_A4IDCLIENTE[0];
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
            ZM034( -28) ;
         }
         pr_default.close(10);
         OnLoadActions034( ) ;
      }

      protected void OnLoadActions034( )
      {
         AV16Pgmname = "Ventas_inventario";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T000314 */
         pr_default.execute(5, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A57IMPUESTOVENTA = T000314_A57IMPUESTOVENTA[0];
            n57IMPUESTOVENTA = T000314_n57IMPUESTOVENTA[0];
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         else
         {
            A57IMPUESTOVENTA = 0;
            n57IMPUESTOVENTA = false;
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         pr_default.close(5);
         /* Using cursor T000310 */
         pr_default.execute(4, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A59TOTALVENTA = T000310_A59TOTALVENTA[0];
            n59TOTALVENTA = T000310_n59TOTALVENTA[0];
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         pr_default.close(4);
      }

      protected void CheckExtendedTable034( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "Ventas_inventario";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T000314 */
         pr_default.execute(5, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A57IMPUESTOVENTA = T000314_A57IMPUESTOVENTA[0];
            n57IMPUESTOVENTA = T000314_n57IMPUESTOVENTA[0];
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         else
         {
            nIsDirty_4 = 1;
            A57IMPUESTOVENTA = 0;
            n57IMPUESTOVENTA = false;
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         pr_default.close(5);
         /* Using cursor T000310 */
         pr_default.execute(4, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A59TOTALVENTA = T000310_A59TOTALVENTA[0];
            n59TOTALVENTA = T000310_n59TOTALVENTA[0];
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         else
         {
            nIsDirty_4 = 1;
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         pr_default.close(4);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A55DESCRIPCIONVENTA)) )
         {
            GX_msglist.addItem("Ingrese una descripcion sobre la venta", 1, "DESCRIPCIONVENTA");
            AnyError = 1;
            GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000317 */
         pr_default.execute(8, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Empleados'.", "ForeignKeyNotFound", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23NOMBRECOMPLETOEMPLEADO = T000317_A23NOMBRECOMPLETOEMPLEADO[0];
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
         pr_default.close(8);
         if ( (0==A1IDEMPLEADO) )
         {
            GX_msglist.addItem("Ingrese el id del empleado que realizo la venta", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000318 */
         pr_default.execute(9, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Clientes'.", "ForeignKeyNotFound", 1, "IDCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtIDCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30NOMBRECOMPLETOCLIENTE = T000318_A30NOMBRECOMPLETOCLIENTE[0];
         AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
         pr_default.close(9);
         if ( (0==A4IDCLIENTE) )
         {
            GX_msglist.addItem("Ingrese el id del cliente que realizo la compra", 1, "IDCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtIDCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors034( )
      {
         pr_default.close(5);
         pr_default.close(4);
         pr_default.close(8);
         pr_default.close(9);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_30( long A12IDVENTA )
      {
         /* Using cursor T000323 */
         pr_default.execute(11, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A57IMPUESTOVENTA = T000323_A57IMPUESTOVENTA[0];
            n57IMPUESTOVENTA = T000323_n57IMPUESTOVENTA[0];
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         else
         {
            A57IMPUESTOVENTA = 0;
            n57IMPUESTOVENTA = false;
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A57IMPUESTOVENTA, 12, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_29( long A12IDVENTA ,
                                decimal A57IMPUESTOVENTA ,
                                decimal A58DESCUENTOVENTA )
      {
         /* Using cursor T000327 */
         pr_default.execute(12, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A59TOTALVENTA = T000327_A59TOTALVENTA[0];
            n59TOTALVENTA = T000327_n59TOTALVENTA[0];
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A59TOTALVENTA, 12, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_31( long A1IDEMPLEADO )
      {
         /* Using cursor T000328 */
         pr_default.execute(13, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No matching 'Empleados'.", "ForeignKeyNotFound", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23NOMBRECOMPLETOEMPLEADO = T000328_A23NOMBRECOMPLETOEMPLEADO[0];
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A23NOMBRECOMPLETOEMPLEADO)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_32( long A4IDCLIENTE )
      {
         /* Using cursor T000329 */
         pr_default.execute(14, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'Clientes'.", "ForeignKeyNotFound", 1, "IDCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtIDCLIENTE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30NOMBRECOMPLETOCLIENTE = T000329_A30NOMBRECOMPLETOCLIENTE[0];
         AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A30NOMBRECOMPLETOCLIENTE)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey034( )
      {
         /* Using cursor T000330 */
         pr_default.execute(15, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000316 */
         pr_default.execute(7, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM034( 28) ;
            RcdFound4 = 1;
            A12IDVENTA = T000316_A12IDVENTA[0];
            AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
            A54FECHAVENTA = T000316_A54FECHAVENTA[0];
            AssignAttri("", false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
            A55DESCRIPCIONVENTA = T000316_A55DESCRIPCIONVENTA[0];
            AssignAttri("", false, "A55DESCRIPCIONVENTA", A55DESCRIPCIONVENTA);
            A58DESCUENTOVENTA = T000316_A58DESCUENTOVENTA[0];
            AssignAttri("", false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
            A1IDEMPLEADO = T000316_A1IDEMPLEADO[0];
            AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
            A4IDCLIENTE = T000316_A4IDCLIENTE[0];
            AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
            Z12IDVENTA = A12IDVENTA;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load034( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey034( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey034( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey034( ) ;
         if ( RcdFound4 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T000331 */
         pr_default.execute(16, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T000331_A12IDVENTA[0] < A12IDVENTA ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T000331_A12IDVENTA[0] > A12IDVENTA ) ) )
            {
               A12IDVENTA = T000331_A12IDVENTA[0];
               AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000332 */
         pr_default.execute(17, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T000332_A12IDVENTA[0] > A12IDVENTA ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T000332_A12IDVENTA[0] < A12IDVENTA ) ) )
            {
               A12IDVENTA = T000332_A12IDVENTA[0];
               AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey034( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert034( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A12IDVENTA != Z12IDVENTA )
               {
                  A12IDVENTA = Z12IDVENTA;
                  AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDVENTA");
                  AnyError = 1;
                  GX_FocusControl = edtIDVENTA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update034( ) ;
                  GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A12IDVENTA != Z12IDVENTA )
               {
                  /* Insert record */
                  GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert034( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDVENTA");
                     AnyError = 1;
                     GX_FocusControl = edtIDVENTA_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert034( ) ;
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
         if ( A12IDVENTA != Z12IDVENTA )
         {
            A12IDVENTA = Z12IDVENTA;
            AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDVENTA");
            AnyError = 1;
            GX_FocusControl = edtIDVENTA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDESCRIPCIONVENTA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency034( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000315 */
            pr_default.execute(6, new Object[] {A12IDVENTA});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ventas_inventario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( Z54FECHAVENTA != T000315_A54FECHAVENTA[0] ) || ( StringUtil.StrCmp(Z55DESCRIPCIONVENTA, T000315_A55DESCRIPCIONVENTA[0]) != 0 ) || ( Z58DESCUENTOVENTA != T000315_A58DESCUENTOVENTA[0] ) || ( Z1IDEMPLEADO != T000315_A1IDEMPLEADO[0] ) || ( Z4IDCLIENTE != T000315_A4IDCLIENTE[0] ) )
            {
               if ( Z54FECHAVENTA != T000315_A54FECHAVENTA[0] )
               {
                  GXUtil.WriteLog("ventas_inventario:[seudo value changed for attri]"+"FECHAVENTA");
                  GXUtil.WriteLogRaw("Old: ",Z54FECHAVENTA);
                  GXUtil.WriteLogRaw("Current: ",T000315_A54FECHAVENTA[0]);
               }
               if ( StringUtil.StrCmp(Z55DESCRIPCIONVENTA, T000315_A55DESCRIPCIONVENTA[0]) != 0 )
               {
                  GXUtil.WriteLog("ventas_inventario:[seudo value changed for attri]"+"DESCRIPCIONVENTA");
                  GXUtil.WriteLogRaw("Old: ",Z55DESCRIPCIONVENTA);
                  GXUtil.WriteLogRaw("Current: ",T000315_A55DESCRIPCIONVENTA[0]);
               }
               if ( Z58DESCUENTOVENTA != T000315_A58DESCUENTOVENTA[0] )
               {
                  GXUtil.WriteLog("ventas_inventario:[seudo value changed for attri]"+"DESCUENTOVENTA");
                  GXUtil.WriteLogRaw("Old: ",Z58DESCUENTOVENTA);
                  GXUtil.WriteLogRaw("Current: ",T000315_A58DESCUENTOVENTA[0]);
               }
               if ( Z1IDEMPLEADO != T000315_A1IDEMPLEADO[0] )
               {
                  GXUtil.WriteLog("ventas_inventario:[seudo value changed for attri]"+"IDEMPLEADO");
                  GXUtil.WriteLogRaw("Old: ",Z1IDEMPLEADO);
                  GXUtil.WriteLogRaw("Current: ",T000315_A1IDEMPLEADO[0]);
               }
               if ( Z4IDCLIENTE != T000315_A4IDCLIENTE[0] )
               {
                  GXUtil.WriteLog("ventas_inventario:[seudo value changed for attri]"+"IDCLIENTE");
                  GXUtil.WriteLogRaw("Old: ",Z4IDCLIENTE);
                  GXUtil.WriteLogRaw("Current: ",T000315_A4IDCLIENTE[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ventas_inventario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM034( 0) ;
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000333 */
                     pr_default.execute(18, new Object[] {A54FECHAVENTA, A55DESCRIPCIONVENTA, A58DESCUENTOVENTA, A1IDEMPLEADO, A4IDCLIENTE});
                     A12IDVENTA = T000333_A12IDVENTA[0];
                     AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("Ventas_inventario");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel034( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption030( ) ;
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
               Load034( ) ;
            }
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void Update034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000334 */
                     pr_default.execute(19, new Object[] {A54FECHAVENTA, A55DESCRIPCIONVENTA, A58DESCUENTOVENTA, A1IDEMPLEADO, A4IDCLIENTE, A12IDVENTA});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("Ventas_inventario");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ventas_inventario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate034( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel034( ) ;
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
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void DeferredUpdate034( )
      {
      }

      protected void delete( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls034( ) ;
            AfterConfirm034( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete034( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart035( ) ;
                  while ( RcdFound5 != 0 )
                  {
                     getByPrimaryKey035( ) ;
                     Delete035( ) ;
                     ScanNext035( ) ;
                  }
                  ScanEnd035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000335 */
                     pr_default.execute(20, new Object[] {A12IDVENTA});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("Ventas_inventario");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel034( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls034( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Ventas_inventario";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000339 */
            pr_default.execute(21, new Object[] {A12IDVENTA});
            if ( (pr_default.getStatus(21) != 101) )
            {
               A57IMPUESTOVENTA = T000339_A57IMPUESTOVENTA[0];
               n57IMPUESTOVENTA = T000339_n57IMPUESTOVENTA[0];
               AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
            }
            else
            {
               A57IMPUESTOVENTA = 0;
               n57IMPUESTOVENTA = false;
               AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
            }
            pr_default.close(21);
            /* Using cursor T000340 */
            pr_default.execute(22, new Object[] {A1IDEMPLEADO});
            A23NOMBRECOMPLETOEMPLEADO = T000340_A23NOMBRECOMPLETOEMPLEADO[0];
            AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
            pr_default.close(22);
            /* Using cursor T000341 */
            pr_default.execute(23, new Object[] {A4IDCLIENTE});
            A30NOMBRECOMPLETOCLIENTE = T000341_A30NOMBRECOMPLETOCLIENTE[0];
            AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
            pr_default.close(23);
            /* Using cursor T000345 */
            pr_default.execute(24, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A59TOTALVENTA = T000345_A59TOTALVENTA[0];
               n59TOTALVENTA = T000345_n59TOTALVENTA[0];
               AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
            }
            else
            {
               A59TOTALVENTA = 0;
               n59TOTALVENTA = false;
               AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
            }
            pr_default.close(24);
         }
      }

      protected void ProcessNestedLevel035( )
      {
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow035( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               standaloneNotModal035( ) ;
               GetKey035( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert035( ) ;
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( ( nRcdDeleted_5 != 0 ) && ( nRcdExists_5 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete035( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update035( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
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
            ChangePostValue( edtPRECIOVENTAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( edtSUBTOTALVENTAPRODUCTO_Internalname, StringUtil.LTrim( StringUtil.NToC( A56SUBTOTALVENTAPRODUCTO, 12, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7IDPRODUCTO), 12, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRECIOVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUBTOTALVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T000339 */
         pr_default.execute(21, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(21) != 101) )
         {
            A57IMPUESTOVENTA = T000339_A57IMPUESTOVENTA[0];
            n57IMPUESTOVENTA = T000339_n57IMPUESTOVENTA[0];
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         else
         {
            A57IMPUESTOVENTA = 0;
            n57IMPUESTOVENTA = false;
            AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         }
         /* Using cursor T000345 */
         pr_default.execute(24, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A59TOTALVENTA = T000345_A59TOTALVENTA[0];
            n59TOTALVENTA = T000345_n59TOTALVENTA[0];
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         /* Using cursor T000345 */
         pr_default.execute(24, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(24) != 101) )
         {
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
            AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         }
         pr_default.close(24);
         /* End of After( level) rules */
         InitAll035( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
      }

      protected void ProcessLevel034( )
      {
         /* Save parent mode. */
         sMode4 = Gx_mode;
         ProcessNestedLevel035( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel034( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete034( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(7);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(24);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("ventas_inventario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(7);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(24);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("ventas_inventario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart034( )
      {
         /* Scan By routine */
         /* Using cursor T000346 */
         pr_default.execute(25);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound4 = 1;
            A12IDVENTA = T000346_A12IDVENTA[0];
            AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext034( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound4 = 1;
            A12IDVENTA = T000346_A12IDVENTA[0];
            AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
         }
      }

      protected void ScanEnd034( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm034( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert034( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate034( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete034( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete034( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate034( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes034( )
      {
         edtIDVENTA_Enabled = 0;
         AssignProp("", false, edtIDVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDVENTA_Enabled), 5, 0), true);
         edtFECHAVENTA_Enabled = 0;
         AssignProp("", false, edtFECHAVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFECHAVENTA_Enabled), 5, 0), true);
         edtDESCRIPCIONVENTA_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONVENTA_Enabled), 5, 0), true);
         edtIDEMPLEADO_Enabled = 0;
         AssignProp("", false, edtIDEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDEMPLEADO_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOEMPLEADO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOEMPLEADO_Enabled), 5, 0), true);
         edtIDCLIENTE_Enabled = 0;
         AssignProp("", false, edtIDCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDCLIENTE_Enabled), 5, 0), true);
         edtNOMBRECOMPLETOCLIENTE_Enabled = 0;
         AssignProp("", false, edtNOMBRECOMPLETOCLIENTE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNOMBRECOMPLETOCLIENTE_Enabled), 5, 0), true);
         edtIMPUESTOVENTA_Enabled = 0;
         AssignProp("", false, edtIMPUESTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIMPUESTOVENTA_Enabled), 5, 0), true);
         edtDESCUENTOVENTA_Enabled = 0;
         AssignProp("", false, edtDESCUENTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCUENTOVENTA_Enabled), 5, 0), true);
         edtTOTALVENTA_Enabled = 0;
         AssignProp("", false, edtTOTALVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALVENTA_Enabled), 5, 0), true);
      }

      protected void ZM035( short GX_JID )
      {
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -33 )
         {
            Z12IDVENTA = A12IDVENTA;
            Z7IDPRODUCTO = A7IDPRODUCTO;
            Z40DESCRIPCIONPRODUCTO = A40DESCRIPCIONPRODUCTO;
            Z41CANTIDADPRODUCTO = A41CANTIDADPRODUCTO;
            Z43PRECIOVENTAPRODUCTO = A43PRECIOVENTAPRODUCTO;
            Z56SUBTOTALVENTAPRODUCTO = A56SUBTOTALVENTAPRODUCTO;
         }
      }

      protected void standaloneNotModal035( )
      {
         edtDESCRIPCIONPRODUCTO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtCANTIDADPRODUCTO_Enabled = 0;
         AssignProp("", false, edtCANTIDADPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtPRECIOVENTAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtPRECIOVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtSUBTOTALVENTAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtSUBTOTALVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtIMPUESTOVENTA_Enabled = 0;
         AssignProp("", false, edtIMPUESTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIMPUESTOVENTA_Enabled), 5, 0), true);
         edtTOTALVENTA_Enabled = 0;
         AssignProp("", false, edtTOTALVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALVENTA_Enabled), 5, 0), true);
         edtIMPUESTOVENTA_Enabled = 0;
         AssignProp("", false, edtIMPUESTOVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIMPUESTOVENTA_Enabled), 5, 0), true);
         edtTOTALVENTA_Enabled = 0;
         AssignProp("", false, edtTOTALVENTA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTOTALVENTA_Enabled), 5, 0), true);
      }

      protected void standaloneModal035( )
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

      protected void Load035( )
      {
         /* Using cursor T000348 */
         pr_default.execute(26, new Object[] {A12IDVENTA, A7IDPRODUCTO});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound5 = 1;
            A40DESCRIPCIONPRODUCTO = T000348_A40DESCRIPCIONPRODUCTO[0];
            A41CANTIDADPRODUCTO = T000348_A41CANTIDADPRODUCTO[0];
            A43PRECIOVENTAPRODUCTO = T000348_A43PRECIOVENTAPRODUCTO[0];
            A56SUBTOTALVENTAPRODUCTO = T000348_A56SUBTOTALVENTAPRODUCTO[0];
            n56SUBTOTALVENTAPRODUCTO = T000348_n56SUBTOTALVENTAPRODUCTO[0];
            ZM035( -33) ;
         }
         pr_default.close(26);
         OnLoadActions035( ) ;
      }

      protected void OnLoadActions035( )
      {
      }

      protected void CheckExtendedTable035( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal035( ) ;
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
            GX_msglist.addItem("No matching 'Inventario'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40DESCRIPCIONPRODUCTO = T00034_A40DESCRIPCIONPRODUCTO[0];
         A41CANTIDADPRODUCTO = T00034_A41CANTIDADPRODUCTO[0];
         A43PRECIOVENTAPRODUCTO = T00034_A43PRECIOVENTAPRODUCTO[0];
         pr_default.close(2);
         /* Using cursor T00036 */
         pr_default.execute(3, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A56SUBTOTALVENTAPRODUCTO = T00036_A56SUBTOTALVENTAPRODUCTO[0];
            n56SUBTOTALVENTAPRODUCTO = T00036_n56SUBTOTALVENTAPRODUCTO[0];
         }
         else
         {
            nIsDirty_5 = 1;
            A56SUBTOTALVENTAPRODUCTO = 0;
            n56SUBTOTALVENTAPRODUCTO = false;
         }
         pr_default.close(3);
         if ( (0==A7IDPRODUCTO) )
         {
            GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
            GX_msglist.addItem("Ingrese el id del producto que se vendio", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors035( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable035( )
      {
      }

      protected void gxLoad_34( long A7IDPRODUCTO )
      {
         /* Using cursor T000349 */
         pr_default.execute(27, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GXCCtl = "IDPRODUCTO_" + sGXsfl_73_idx;
            GX_msglist.addItem("No matching 'Inventario'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40DESCRIPCIONPRODUCTO = T000349_A40DESCRIPCIONPRODUCTO[0];
         A41CANTIDADPRODUCTO = T000349_A41CANTIDADPRODUCTO[0];
         A43PRECIOVENTAPRODUCTO = T000349_A43PRECIOVENTAPRODUCTO[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A40DESCRIPCIONPRODUCTO)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_35( long A7IDPRODUCTO )
      {
         /* Using cursor T000351 */
         pr_default.execute(28, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(28) != 101) )
         {
            A56SUBTOTALVENTAPRODUCTO = T000351_A56SUBTOTALVENTAPRODUCTO[0];
            n56SUBTOTALVENTAPRODUCTO = T000351_n56SUBTOTALVENTAPRODUCTO[0];
         }
         else
         {
            A56SUBTOTALVENTAPRODUCTO = 0;
            n56SUBTOTALVENTAPRODUCTO = false;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A56SUBTOTALVENTAPRODUCTO, 12, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void GetKey035( )
      {
         /* Using cursor T000352 */
         pr_default.execute(29, new Object[] {A12IDVENTA, A7IDPRODUCTO});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey035( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A12IDVENTA, A7IDPRODUCTO});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM035( 33) ;
            RcdFound5 = 1;
            InitializeNonKey035( ) ;
            A7IDPRODUCTO = T00033_A7IDPRODUCTO[0];
            Z12IDVENTA = A12IDVENTA;
            Z7IDPRODUCTO = A7IDPRODUCTO;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load035( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey035( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal035( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes035( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency035( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A12IDVENTA, A7IDPRODUCTO});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ventas_inventarioDetalle_venta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ventas_inventarioDetalle_venta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM035( 0) ;
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000353 */
                     pr_default.execute(30, new Object[] {A12IDVENTA, A7IDPRODUCTO});
                     pr_default.close(30);
                     dsDefault.SmartCacheProvider.SetUpdated("Ventas_inventarioDetalle_venta");
                     if ( (pr_default.getStatus(30) == 1) )
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
               Load035( ) ;
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void Update035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( ( nIsMod_5 != 0 ) || ( nIsDirty_5 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency035( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm035( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate035( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [Ventas_inventarioDetalle_venta] */
                        DeferredUpdate035( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey035( ) ;
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
               EndLevel035( ) ;
            }
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void DeferredUpdate035( )
      {
      }

      protected void Delete035( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls035( ) ;
            AfterConfirm035( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete035( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000354 */
                  pr_default.execute(31, new Object[] {A12IDVENTA, A7IDPRODUCTO});
                  pr_default.close(31);
                  dsDefault.SmartCacheProvider.SetUpdated("Ventas_inventarioDetalle_venta");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel035( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls035( )
      {
         standaloneModal035( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000355 */
            pr_default.execute(32, new Object[] {A7IDPRODUCTO});
            A40DESCRIPCIONPRODUCTO = T000355_A40DESCRIPCIONPRODUCTO[0];
            A41CANTIDADPRODUCTO = T000355_A41CANTIDADPRODUCTO[0];
            A43PRECIOVENTAPRODUCTO = T000355_A43PRECIOVENTAPRODUCTO[0];
            pr_default.close(32);
            /* Using cursor T000357 */
            pr_default.execute(33, new Object[] {A7IDPRODUCTO});
            if ( (pr_default.getStatus(33) != 101) )
            {
               A56SUBTOTALVENTAPRODUCTO = T000357_A56SUBTOTALVENTAPRODUCTO[0];
               n56SUBTOTALVENTAPRODUCTO = T000357_n56SUBTOTALVENTAPRODUCTO[0];
            }
            else
            {
               A56SUBTOTALVENTAPRODUCTO = 0;
               n56SUBTOTALVENTAPRODUCTO = false;
            }
            pr_default.close(33);
         }
      }

      protected void EndLevel035( )
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

      public void ScanStart035( )
      {
         /* Scan By routine */
         /* Using cursor T000358 */
         pr_default.execute(34, new Object[] {A12IDVENTA});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound5 = 1;
            A7IDPRODUCTO = T000358_A7IDPRODUCTO[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext035( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound5 = 1;
            A7IDPRODUCTO = T000358_A7IDPRODUCTO[0];
         }
      }

      protected void ScanEnd035( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm035( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert035( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate035( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete035( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete035( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate035( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes035( )
      {
         edtIDPRODUCTO_Enabled = 0;
         AssignProp("", false, edtIDPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIDPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtDESCRIPCIONPRODUCTO_Enabled = 0;
         AssignProp("", false, edtDESCRIPCIONPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtCANTIDADPRODUCTO_Enabled = 0;
         AssignProp("", false, edtCANTIDADPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtPRECIOVENTAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtPRECIOVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtSUBTOTALVENTAPRODUCTO_Enabled = 0;
         AssignProp("", false, edtSUBTOTALVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void send_integrity_lvl_hashes035( )
      {
      }

      protected void send_integrity_lvl_hashes034( )
      {
      }

      protected void SubsflControlProps_735( )
      {
         edtIDPRODUCTO_Internalname = "IDPRODUCTO_"+sGXsfl_73_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_73_idx;
         edtDESCRIPCIONPRODUCTO_Internalname = "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx;
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO_"+sGXsfl_73_idx;
         edtPRECIOVENTAPRODUCTO_Internalname = "PRECIOVENTAPRODUCTO_"+sGXsfl_73_idx;
         edtSUBTOTALVENTAPRODUCTO_Internalname = "SUBTOTALVENTAPRODUCTO_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_735( )
      {
         edtIDPRODUCTO_Internalname = "IDPRODUCTO_"+sGXsfl_73_fel_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_73_fel_idx;
         edtDESCRIPCIONPRODUCTO_Internalname = "DESCRIPCIONPRODUCTO_"+sGXsfl_73_fel_idx;
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO_"+sGXsfl_73_fel_idx;
         edtPRECIOVENTAPRODUCTO_Internalname = "PRECIOVENTAPRODUCTO_"+sGXsfl_73_fel_idx;
         edtSUBTOTALVENTAPRODUCTO_Internalname = "SUBTOTALVENTAPRODUCTO_"+sGXsfl_73_fel_idx;
      }

      protected void AddRow035( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_735( ) ;
         SendRow035( ) ;
      }

      protected void SendRow035( )
      {
         Gridventas_inventario_detalle_venta_productoRow = GXWebRow.GetNew(context);
         if ( subGridventas_inventario_detalle_venta_producto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridventas_inventario_detalle_venta_producto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridventas_inventario_detalle_venta_producto_Class, "") != 0 )
            {
               subGridventas_inventario_detalle_venta_producto_Linesclass = subGridventas_inventario_detalle_venta_producto_Class+"Odd";
            }
         }
         else if ( subGridventas_inventario_detalle_venta_producto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridventas_inventario_detalle_venta_producto_Backstyle = 0;
            subGridventas_inventario_detalle_venta_producto_Backcolor = subGridventas_inventario_detalle_venta_producto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridventas_inventario_detalle_venta_producto_Class, "") != 0 )
            {
               subGridventas_inventario_detalle_venta_producto_Linesclass = subGridventas_inventario_detalle_venta_producto_Class+"Uniform";
            }
         }
         else if ( subGridventas_inventario_detalle_venta_producto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridventas_inventario_detalle_venta_producto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridventas_inventario_detalle_venta_producto_Class, "") != 0 )
            {
               subGridventas_inventario_detalle_venta_producto_Linesclass = subGridventas_inventario_detalle_venta_producto_Class+"Odd";
            }
            subGridventas_inventario_detalle_venta_producto_Backcolor = (int)(0x0);
         }
         else if ( subGridventas_inventario_detalle_venta_producto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridventas_inventario_detalle_venta_producto_Backstyle = 1;
            if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
            {
               subGridventas_inventario_detalle_venta_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridventas_inventario_detalle_venta_producto_Class, "") != 0 )
               {
                  subGridventas_inventario_detalle_venta_producto_Linesclass = subGridventas_inventario_detalle_venta_producto_Class+"Even";
               }
            }
            else
            {
               subGridventas_inventario_detalle_venta_producto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridventas_inventario_detalle_venta_producto_Class, "") != 0 )
               {
                  subGridventas_inventario_detalle_venta_producto_Linesclass = subGridventas_inventario_detalle_venta_producto_Class+"Odd";
               }
            }
         }
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0090.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDPRODUCTO_"+sGXsfl_73_idx+"'), id:'"+"IDPRODUCTO_"+sGXsfl_73_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_5_"+sGXsfl_73_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridventas_inventario_detalle_venta_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIDPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7IDPRODUCTO), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIDPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtIDPRODUCTO_Enabled,(short)1,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Codigo",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridventas_inventario_detalle_venta_productoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_7_Internalname,(string)sImgUrl,(string)imgprompt_7_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_7_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridventas_inventario_detalle_venta_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDESCRIPCIONPRODUCTO_Internalname,(string)A40DESCRIPCIONPRODUCTO,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDESCRIPCIONPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtDESCRIPCIONPRODUCTO_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)255,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridventas_inventario_detalle_venta_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCANTIDADPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")),((edtCANTIDADPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCANTIDADPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCANTIDADPRODUCTO_Enabled,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Cantidad",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridventas_inventario_detalle_venta_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPRECIOVENTAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")),((edtPRECIOVENTAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPRECIOVENTAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPRECIOVENTAPRODUCTO_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridventas_inventario_detalle_venta_productoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSUBTOTALVENTAPRODUCTO_Internalname,StringUtil.LTrim( StringUtil.NToC( A56SUBTOTALVENTAPRODUCTO, 12, 2, ".", "")),((edtSUBTOTALVENTAPRODUCTO_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A56SUBTOTALVENTAPRODUCTO, "ZZZZZZZZ9.99")) : context.localUtil.Format( A56SUBTOTALVENTAPRODUCTO, "ZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSUBTOTALVENTAPRODUCTO_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSUBTOTALVENTAPRODUCTO_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(string)"Money",(string)"right",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridventas_inventario_detalle_venta_productoRow);
         send_integrity_lvl_hashes035( ) ;
         GXCCtl = "Z7IDPRODUCTO_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7IDPRODUCTO), 12, 0, ".", "")));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_5_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", "")));
         GXCCtl = "nIsMod_5_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", "")));
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
         GXCCtl = "vIDVENTA_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDVENTA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIDPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRECIOVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUBTOTALVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_7_"+sGXsfl_73_idx+"Link", StringUtil.RTrim( imgprompt_7_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridventas_inventario_detalle_venta_productoContainer.AddRow(Gridventas_inventario_detalle_venta_productoRow);
      }

      protected void ReadRow035( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_735( ) ;
         edtIDPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "IDPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtDESCRIPCIONPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "DESCRIPCIONPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtCANTIDADPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "CANTIDADPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtPRECIOVENTAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRECIOVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         edtSUBTOTALVENTAPRODUCTO_Enabled = (int)(context.localUtil.CToN( cgiGet( "SUBTOTALVENTAPRODUCTO_"+sGXsfl_73_idx+"Enabled"), ".", ","));
         imgprompt_1_Link = cgiGet( "PROMPT_7_"+sGXsfl_73_idx+"Link");
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
         A43PRECIOVENTAPRODUCTO = context.localUtil.CToN( cgiGet( edtPRECIOVENTAPRODUCTO_Internalname), ".", ",");
         A56SUBTOTALVENTAPRODUCTO = context.localUtil.CToN( cgiGet( edtSUBTOTALVENTAPRODUCTO_Internalname), ".", ",");
         n56SUBTOTALVENTAPRODUCTO = false;
         GXCCtl = "Z7IDPRODUCTO_" + sGXsfl_73_idx;
         Z7IDPRODUCTO = (long)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_73_idx;
         nRcdDeleted_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_5_" + sGXsfl_73_idx;
         nRcdExists_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_5_" + sGXsfl_73_idx;
         nIsMod_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtSUBTOTALVENTAPRODUCTO_Enabled = edtSUBTOTALVENTAPRODUCTO_Enabled;
         defedtPRECIOVENTAPRODUCTO_Enabled = edtPRECIOVENTAPRODUCTO_Enabled;
         defedtCANTIDADPRODUCTO_Enabled = edtCANTIDADPRODUCTO_Enabled;
         defedtDESCRIPCIONPRODUCTO_Enabled = edtDESCRIPCIONPRODUCTO_Enabled;
         defedtIDPRODUCTO_Enabled = edtIDPRODUCTO_Enabled;
      }

      protected void ConfirmValues030( )
      {
         nGXsfl_73_idx = 0;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_735( ) ;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_735( ) ;
            ChangePostValue( "Z7IDPRODUCTO_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z7IDPRODUCTO_"+sGXsfl_73_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021112620512924", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ventas_inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDVENTA,12,0))}, new string[] {"Gx_mode","IDVENTA"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Ventas_inventario");
         forbiddenHiddens.Add("IDVENTA", context.localUtil.Format( (decimal)(A12IDVENTA), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
         forbiddenHiddens.Add("DESCUENTOVENTA", context.localUtil.Format( A58DESCUENTOVENTA, "ZZZZZZZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ventas_inventario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z12IDVENTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12IDVENTA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z54FECHAVENTA", context.localUtil.DToC( Z54FECHAVENTA, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z55DESCRIPCIONVENTA", Z55DESCRIPCIONVENTA);
         GxWebStd.gx_hidden_field( context, "Z58DESCUENTOVENTA", StringUtil.LTrim( StringUtil.NToC( Z58DESCUENTOVENTA, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1IDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4IDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4IDCLIENTE), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_73_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N1IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1IDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N4IDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4IDCLIENTE), 12, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vIDVENTA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IDVENTA), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDVENTA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IDVENTA), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDEMPLEADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_IDEMPLEADO), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDCLIENTE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_IDCLIENTE), 12, 0, ".", "")));
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
         return formatLink("ventas_inventario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IDVENTA,12,0))}, new string[] {"Gx_mode","IDVENTA"})  ;
      }

      public override string GetPgmname( )
      {
         return "Ventas_inventario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ventas_inventario" ;
      }

      protected void InitializeNonKey034( )
      {
         A1IDEMPLEADO = 0;
         AssignAttri("", false, "A1IDEMPLEADO", StringUtil.LTrimStr( (decimal)(A1IDEMPLEADO), 12, 0));
         A4IDCLIENTE = 0;
         AssignAttri("", false, "A4IDCLIENTE", StringUtil.LTrimStr( (decimal)(A4IDCLIENTE), 12, 0));
         A59TOTALVENTA = 0;
         n59TOTALVENTA = false;
         AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrimStr( A59TOTALVENTA, 12, 2));
         A55DESCRIPCIONVENTA = "";
         AssignAttri("", false, "A55DESCRIPCIONVENTA", A55DESCRIPCIONVENTA);
         A23NOMBRECOMPLETOEMPLEADO = "";
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
         A30NOMBRECOMPLETOCLIENTE = "";
         AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
         A57IMPUESTOVENTA = 0;
         n57IMPUESTOVENTA = false;
         AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrimStr( A57IMPUESTOVENTA, 12, 2));
         A58DESCUENTOVENTA = 0;
         AssignAttri("", false, "A58DESCUENTOVENTA", StringUtil.LTrimStr( A58DESCUENTOVENTA, 12, 2));
         A54FECHAVENTA = Gx_date;
         AssignAttri("", false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
         Z54FECHAVENTA = DateTime.MinValue;
         Z55DESCRIPCIONVENTA = "";
         Z58DESCUENTOVENTA = 0;
         Z1IDEMPLEADO = 0;
         Z4IDCLIENTE = 0;
      }

      protected void InitAll034( )
      {
         A12IDVENTA = 0;
         AssignAttri("", false, "A12IDVENTA", StringUtil.LTrimStr( (decimal)(A12IDVENTA), 12, 0));
         InitializeNonKey034( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A54FECHAVENTA = i54FECHAVENTA;
         AssignAttri("", false, "A54FECHAVENTA", context.localUtil.Format(A54FECHAVENTA, "99/99/99"));
      }

      protected void InitializeNonKey035( )
      {
         A40DESCRIPCIONPRODUCTO = "";
         A41CANTIDADPRODUCTO = 0;
         A43PRECIOVENTAPRODUCTO = 0;
         A56SUBTOTALVENTAPRODUCTO = 0;
         n56SUBTOTALVENTAPRODUCTO = false;
      }

      protected void InitAll035( )
      {
         A7IDPRODUCTO = 0;
         InitializeNonKey035( ) ;
      }

      protected void StandaloneModalInsert035( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021112620512938", true, true);
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
         context.AddJavascriptSource("ventas_inventario.js", "?2021112620512938", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties5( )
      {
         edtSUBTOTALVENTAPRODUCTO_Enabled = defedtSUBTOTALVENTAPRODUCTO_Enabled;
         AssignProp("", false, edtSUBTOTALVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSUBTOTALVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtPRECIOVENTAPRODUCTO_Enabled = defedtPRECIOVENTAPRODUCTO_Enabled;
         AssignProp("", false, edtPRECIOVENTAPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPRECIOVENTAPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtCANTIDADPRODUCTO_Enabled = defedtCANTIDADPRODUCTO_Enabled;
         AssignProp("", false, edtCANTIDADPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCANTIDADPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtDESCRIPCIONPRODUCTO_Enabled = defedtDESCRIPCIONPRODUCTO_Enabled;
         AssignProp("", false, edtDESCRIPCIONPRODUCTO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDESCRIPCIONPRODUCTO_Enabled), 5, 0), !bGXsfl_73_Refreshing);
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
         edtIDVENTA_Internalname = "IDVENTA";
         edtFECHAVENTA_Internalname = "FECHAVENTA";
         edtDESCRIPCIONVENTA_Internalname = "DESCRIPCIONVENTA";
         edtIDEMPLEADO_Internalname = "IDEMPLEADO";
         edtNOMBRECOMPLETOEMPLEADO_Internalname = "NOMBRECOMPLETOEMPLEADO";
         edtIDCLIENTE_Internalname = "IDCLIENTE";
         edtNOMBRECOMPLETOCLIENTE_Internalname = "NOMBRECOMPLETOCLIENTE";
         lblTitledetalle_venta_producto_Internalname = "TITLEDETALLE_VENTA_PRODUCTO";
         edtIDPRODUCTO_Internalname = "IDPRODUCTO";
         edtDESCRIPCIONPRODUCTO_Internalname = "DESCRIPCIONPRODUCTO";
         edtCANTIDADPRODUCTO_Internalname = "CANTIDADPRODUCTO";
         edtPRECIOVENTAPRODUCTO_Internalname = "PRECIOVENTAPRODUCTO";
         edtSUBTOTALVENTAPRODUCTO_Internalname = "SUBTOTALVENTAPRODUCTO";
         divDetalle_venta_productotable_Internalname = "DETALLE_VENTA_PRODUCTOTABLE";
         edtIMPUESTOVENTA_Internalname = "IMPUESTOVENTA";
         edtDESCUENTOVENTA_Internalname = "DESCUENTOVENTA";
         edtTOTALVENTA_Internalname = "TOTALVENTA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_7_Internalname = "PROMPT_7";
         subGridventas_inventario_detalle_venta_producto_Internalname = "GRIDVENTAS_INVENTARIO_DETALLE_VENTA_PRODUCTO";
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
         Form.Caption = "Ventas_inventario";
         edtSUBTOTALVENTAPRODUCTO_Jsonclick = "";
         edtPRECIOVENTAPRODUCTO_Jsonclick = "";
         edtCANTIDADPRODUCTO_Jsonclick = "";
         edtDESCRIPCIONPRODUCTO_Jsonclick = "";
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         imgprompt_1_Visible = 1;
         edtIDPRODUCTO_Jsonclick = "";
         subGridventas_inventario_detalle_venta_producto_Class = "Grid";
         subGridventas_inventario_detalle_venta_producto_Backcolorstyle = 0;
         subGridventas_inventario_detalle_venta_producto_Allowcollapsing = 0;
         subGridventas_inventario_detalle_venta_producto_Allowselection = 0;
         edtSUBTOTALVENTAPRODUCTO_Enabled = 0;
         edtPRECIOVENTAPRODUCTO_Enabled = 0;
         edtCANTIDADPRODUCTO_Enabled = 0;
         edtDESCRIPCIONPRODUCTO_Enabled = 0;
         edtIDPRODUCTO_Enabled = 1;
         subGridventas_inventario_detalle_venta_producto_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTOTALVENTA_Jsonclick = "";
         edtTOTALVENTA_Enabled = 0;
         edtDESCUENTOVENTA_Jsonclick = "";
         edtDESCUENTOVENTA_Enabled = 0;
         edtIMPUESTOVENTA_Jsonclick = "";
         edtIMPUESTOVENTA_Enabled = 0;
         edtNOMBRECOMPLETOCLIENTE_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtIDCLIENTE_Jsonclick = "";
         edtIDCLIENTE_Enabled = 1;
         edtNOMBRECOMPLETOEMPLEADO_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtIDEMPLEADO_Jsonclick = "";
         edtIDEMPLEADO_Enabled = 1;
         edtDESCRIPCIONVENTA_Enabled = 1;
         edtFECHAVENTA_Jsonclick = "";
         edtFECHAVENTA_Enabled = 0;
         edtIDVENTA_Jsonclick = "";
         edtIDVENTA_Enabled = 0;
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

      protected void gxnrGridventas_inventario_detalle_venta_producto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_735( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal035( ) ;
            standaloneModal035( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow035( ) ;
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_735( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridventas_inventario_detalle_venta_productoContainer)) ;
         /* End function gxnrGridventas_inventario_detalle_venta_producto_newrow */
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

      public void Valid_Idventa( )
      {
         n57IMPUESTOVENTA = false;
         /* Using cursor T000339 */
         pr_default.execute(21, new Object[] {A12IDVENTA});
         if ( (pr_default.getStatus(21) != 101) )
         {
            A57IMPUESTOVENTA = T000339_A57IMPUESTOVENTA[0];
            n57IMPUESTOVENTA = T000339_n57IMPUESTOVENTA[0];
         }
         else
         {
            A57IMPUESTOVENTA = 0;
            n57IMPUESTOVENTA = false;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A57IMPUESTOVENTA", StringUtil.LTrim( StringUtil.NToC( A57IMPUESTOVENTA, 12, 2, ".", "")));
      }

      public void Valid_Idempleado( )
      {
         /* Using cursor T000340 */
         pr_default.execute(22, new Object[] {A1IDEMPLEADO});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No matching 'Empleados'.", "ForeignKeyNotFound", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
         }
         A23NOMBRECOMPLETOEMPLEADO = T000340_A23NOMBRECOMPLETOEMPLEADO[0];
         pr_default.close(22);
         if ( (0==A1IDEMPLEADO) )
         {
            GX_msglist.addItem("Ingrese el id del empleado que realizo la venta", 1, "IDEMPLEADO");
            AnyError = 1;
            GX_FocusControl = edtIDEMPLEADO_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23NOMBRECOMPLETOEMPLEADO", A23NOMBRECOMPLETOEMPLEADO);
      }

      public void Valid_Idcliente( )
      {
         /* Using cursor T000341 */
         pr_default.execute(23, new Object[] {A4IDCLIENTE});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No matching 'Clientes'.", "ForeignKeyNotFound", 1, "IDCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtIDCLIENTE_Internalname;
         }
         A30NOMBRECOMPLETOCLIENTE = T000341_A30NOMBRECOMPLETOCLIENTE[0];
         pr_default.close(23);
         if ( (0==A4IDCLIENTE) )
         {
            GX_msglist.addItem("Ingrese el id del cliente que realizo la compra", 1, "IDCLIENTE");
            AnyError = 1;
            GX_FocusControl = edtIDCLIENTE_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A30NOMBRECOMPLETOCLIENTE", A30NOMBRECOMPLETOCLIENTE);
      }

      public void Valid_Descuentoventa( )
      {
         n57IMPUESTOVENTA = false;
         n59TOTALVENTA = false;
         /* Using cursor T000345 */
         pr_default.execute(24, new Object[] {n57IMPUESTOVENTA, A57IMPUESTOVENTA, A58DESCUENTOVENTA, A12IDVENTA});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A59TOTALVENTA = T000345_A59TOTALVENTA[0];
            n59TOTALVENTA = T000345_n59TOTALVENTA[0];
         }
         else
         {
            A59TOTALVENTA = 0;
            n59TOTALVENTA = false;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A59TOTALVENTA", StringUtil.LTrim( StringUtil.NToC( A59TOTALVENTA, 12, 2, ".", "")));
      }

      public void Valid_Idproducto( )
      {
         n56SUBTOTALVENTAPRODUCTO = false;
         /* Using cursor T000355 */
         pr_default.execute(32, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No matching 'Inventario'.", "ForeignKeyNotFound", 1, "IDPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
         }
         A40DESCRIPCIONPRODUCTO = T000355_A40DESCRIPCIONPRODUCTO[0];
         A41CANTIDADPRODUCTO = T000355_A41CANTIDADPRODUCTO[0];
         A43PRECIOVENTAPRODUCTO = T000355_A43PRECIOVENTAPRODUCTO[0];
         pr_default.close(32);
         /* Using cursor T000357 */
         pr_default.execute(33, new Object[] {A7IDPRODUCTO});
         if ( (pr_default.getStatus(33) != 101) )
         {
            A56SUBTOTALVENTAPRODUCTO = T000357_A56SUBTOTALVENTAPRODUCTO[0];
            n56SUBTOTALVENTAPRODUCTO = T000357_n56SUBTOTALVENTAPRODUCTO[0];
         }
         else
         {
            A56SUBTOTALVENTAPRODUCTO = 0;
            n56SUBTOTALVENTAPRODUCTO = false;
         }
         pr_default.close(33);
         if ( (0==A7IDPRODUCTO) )
         {
            GX_msglist.addItem("Ingrese el id del producto que se vendio", 1, "IDPRODUCTO");
            AnyError = 1;
            GX_FocusControl = edtIDPRODUCTO_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A40DESCRIPCIONPRODUCTO", A40DESCRIPCIONPRODUCTO);
         AssignAttri("", false, "A41CANTIDADPRODUCTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CANTIDADPRODUCTO), 12, 0, ".", "")));
         AssignAttri("", false, "A43PRECIOVENTAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( A43PRECIOVENTAPRODUCTO, 12, 2, ".", "")));
         AssignAttri("", false, "A56SUBTOTALVENTAPRODUCTO", StringUtil.LTrim( StringUtil.NToC( A56SUBTOTALVENTAPRODUCTO, 12, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IDVENTA',fld:'vIDVENTA',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IDVENTA',fld:'vIDVENTA',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9'},{av:'A54FECHAVENTA',fld:'FECHAVENTA',pic:''},{av:'A58DESCUENTOVENTA',fld:'DESCUENTOVENTA',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_IDVENTA","{handler:'Valid_Idventa',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9'},{av:'A57IMPUESTOVENTA',fld:'IMPUESTOVENTA',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("VALID_IDVENTA",",oparms:[{av:'A57IMPUESTOVENTA',fld:'IMPUESTOVENTA',pic:'ZZZZZZZZ9.99'}]}");
         setEventMetadata("VALID_DESCRIPCIONVENTA","{handler:'Valid_Descripcionventa',iparms:[]");
         setEventMetadata("VALID_DESCRIPCIONVENTA",",oparms:[]}");
         setEventMetadata("VALID_IDEMPLEADO","{handler:'Valid_Idempleado',iparms:[{av:'A1IDEMPLEADO',fld:'IDEMPLEADO',pic:'ZZZZZZZZZZZ9'},{av:'A23NOMBRECOMPLETOEMPLEADO',fld:'NOMBRECOMPLETOEMPLEADO',pic:''}]");
         setEventMetadata("VALID_IDEMPLEADO",",oparms:[{av:'A23NOMBRECOMPLETOEMPLEADO',fld:'NOMBRECOMPLETOEMPLEADO',pic:''}]}");
         setEventMetadata("VALID_IDCLIENTE","{handler:'Valid_Idcliente',iparms:[{av:'A4IDCLIENTE',fld:'IDCLIENTE',pic:'ZZZZZZZZZZZ9'},{av:'A30NOMBRECOMPLETOCLIENTE',fld:'NOMBRECOMPLETOCLIENTE',pic:''}]");
         setEventMetadata("VALID_IDCLIENTE",",oparms:[{av:'A30NOMBRECOMPLETOCLIENTE',fld:'NOMBRECOMPLETOCLIENTE',pic:''}]}");
         setEventMetadata("VALID_IMPUESTOVENTA","{handler:'Valid_Impuestoventa',iparms:[]");
         setEventMetadata("VALID_IMPUESTOVENTA",",oparms:[]}");
         setEventMetadata("VALID_DESCUENTOVENTA","{handler:'Valid_Descuentoventa',iparms:[{av:'A12IDVENTA',fld:'IDVENTA',pic:'ZZZZZZZZZZZ9'},{av:'A57IMPUESTOVENTA',fld:'IMPUESTOVENTA',pic:'ZZZZZZZZ9.99'},{av:'A58DESCUENTOVENTA',fld:'DESCUENTOVENTA',pic:'ZZZZZZZZ9.99'},{av:'A59TOTALVENTA',fld:'TOTALVENTA',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("VALID_DESCUENTOVENTA",",oparms:[{av:'A59TOTALVENTA',fld:'TOTALVENTA',pic:'ZZZZZZZZ9.99'}]}");
         setEventMetadata("VALID_IDPRODUCTO","{handler:'Valid_Idproducto',iparms:[{av:'A7IDPRODUCTO',fld:'IDPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A40DESCRIPCIONPRODUCTO',fld:'DESCRIPCIONPRODUCTO',pic:''},{av:'A41CANTIDADPRODUCTO',fld:'CANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A43PRECIOVENTAPRODUCTO',fld:'PRECIOVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'A56SUBTOTALVENTAPRODUCTO',fld:'SUBTOTALVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'}]");
         setEventMetadata("VALID_IDPRODUCTO",",oparms:[{av:'A40DESCRIPCIONPRODUCTO',fld:'DESCRIPCIONPRODUCTO',pic:''},{av:'A41CANTIDADPRODUCTO',fld:'CANTIDADPRODUCTO',pic:'ZZZZZZZZZZZ9'},{av:'A43PRECIOVENTAPRODUCTO',fld:'PRECIOVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'},{av:'A56SUBTOTALVENTAPRODUCTO',fld:'SUBTOTALVENTAPRODUCTO',pic:'ZZZZZZZZ9.99'}]}");
         setEventMetadata("NULL","{handler:'Valid_Subtotalventaproducto',iparms:[]");
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
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(7);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z54FECHAVENTA = DateTime.MinValue;
         Z55DESCRIPCIONVENTA = "";
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
         A54FECHAVENTA = DateTime.MinValue;
         A55DESCRIPCIONVENTA = "";
         sImgUrl = "";
         A23NOMBRECOMPLETOEMPLEADO = "";
         A30NOMBRECOMPLETOCLIENTE = "";
         lblTitledetalle_venta_producto_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridventas_inventario_detalle_venta_productoContainer = new GXWebGrid( context);
         Gridventas_inventario_detalle_venta_productoColumn = new GXWebColumn();
         A40DESCRIPCIONPRODUCTO = "";
         sMode5 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode4 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T000314_A57IMPUESTOVENTA = new decimal[1] ;
         T000314_n57IMPUESTOVENTA = new bool[] {false} ;
         T000310_A59TOTALVENTA = new decimal[1] ;
         T000310_n59TOTALVENTA = new bool[] {false} ;
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z23NOMBRECOMPLETOEMPLEADO = "";
         Z30NOMBRECOMPLETOCLIENTE = "";
         T000318_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         T000317_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T000319_A12IDVENTA = new long[1] ;
         T000319_A54FECHAVENTA = new DateTime[] {DateTime.MinValue} ;
         T000319_A55DESCRIPCIONVENTA = new string[] {""} ;
         T000319_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T000319_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         T000319_A58DESCUENTOVENTA = new decimal[1] ;
         T000319_A1IDEMPLEADO = new long[1] ;
         T000319_A4IDCLIENTE = new long[1] ;
         T000323_A57IMPUESTOVENTA = new decimal[1] ;
         T000323_n57IMPUESTOVENTA = new bool[] {false} ;
         T000327_A59TOTALVENTA = new decimal[1] ;
         T000327_n59TOTALVENTA = new bool[] {false} ;
         T000328_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T000329_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         T000330_A12IDVENTA = new long[1] ;
         T000316_A12IDVENTA = new long[1] ;
         T000316_A54FECHAVENTA = new DateTime[] {DateTime.MinValue} ;
         T000316_A55DESCRIPCIONVENTA = new string[] {""} ;
         T000316_A58DESCUENTOVENTA = new decimal[1] ;
         T000316_A1IDEMPLEADO = new long[1] ;
         T000316_A4IDCLIENTE = new long[1] ;
         T000331_A12IDVENTA = new long[1] ;
         T000332_A12IDVENTA = new long[1] ;
         T000315_A12IDVENTA = new long[1] ;
         T000315_A54FECHAVENTA = new DateTime[] {DateTime.MinValue} ;
         T000315_A55DESCRIPCIONVENTA = new string[] {""} ;
         T000315_A58DESCUENTOVENTA = new decimal[1] ;
         T000315_A1IDEMPLEADO = new long[1] ;
         T000315_A4IDCLIENTE = new long[1] ;
         T000333_A12IDVENTA = new long[1] ;
         T000339_A57IMPUESTOVENTA = new decimal[1] ;
         T000339_n57IMPUESTOVENTA = new bool[] {false} ;
         T000340_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         T000341_A30NOMBRECOMPLETOCLIENTE = new string[] {""} ;
         T000345_A59TOTALVENTA = new decimal[1] ;
         T000345_n59TOTALVENTA = new bool[] {false} ;
         T000346_A12IDVENTA = new long[1] ;
         Z40DESCRIPCIONPRODUCTO = "";
         T000348_A12IDVENTA = new long[1] ;
         T000348_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T000348_A41CANTIDADPRODUCTO = new long[1] ;
         T000348_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         T000348_A7IDPRODUCTO = new long[1] ;
         T000348_A56SUBTOTALVENTAPRODUCTO = new decimal[1] ;
         T000348_n56SUBTOTALVENTAPRODUCTO = new bool[] {false} ;
         T00034_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T00034_A41CANTIDADPRODUCTO = new long[1] ;
         T00034_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         T00036_A56SUBTOTALVENTAPRODUCTO = new decimal[1] ;
         T00036_n56SUBTOTALVENTAPRODUCTO = new bool[] {false} ;
         T000349_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T000349_A41CANTIDADPRODUCTO = new long[1] ;
         T000349_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         T000351_A56SUBTOTALVENTAPRODUCTO = new decimal[1] ;
         T000351_n56SUBTOTALVENTAPRODUCTO = new bool[] {false} ;
         T000352_A12IDVENTA = new long[1] ;
         T000352_A7IDPRODUCTO = new long[1] ;
         T00033_A12IDVENTA = new long[1] ;
         T00033_A7IDPRODUCTO = new long[1] ;
         T00032_A12IDVENTA = new long[1] ;
         T00032_A7IDPRODUCTO = new long[1] ;
         T000355_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         T000355_A41CANTIDADPRODUCTO = new long[1] ;
         T000355_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         T000357_A56SUBTOTALVENTAPRODUCTO = new decimal[1] ;
         T000357_n56SUBTOTALVENTAPRODUCTO = new bool[] {false} ;
         T000358_A12IDVENTA = new long[1] ;
         T000358_A7IDPRODUCTO = new long[1] ;
         Gridventas_inventario_detalle_venta_productoRow = new GXWebRow();
         subGridventas_inventario_detalle_venta_producto_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i54FECHAVENTA = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas_inventario__default(),
            new Object[][] {
                new Object[] {
               T00032_A12IDVENTA, T00032_A7IDPRODUCTO
               }
               , new Object[] {
               T00033_A12IDVENTA, T00033_A7IDPRODUCTO
               }
               , new Object[] {
               T00034_A40DESCRIPCIONPRODUCTO, T00034_A41CANTIDADPRODUCTO, T00034_A43PRECIOVENTAPRODUCTO
               }
               , new Object[] {
               T00036_A56SUBTOTALVENTAPRODUCTO, T00036_n56SUBTOTALVENTAPRODUCTO
               }
               , new Object[] {
               T000310_A59TOTALVENTA, T000310_n59TOTALVENTA
               }
               , new Object[] {
               T000314_A57IMPUESTOVENTA, T000314_n57IMPUESTOVENTA
               }
               , new Object[] {
               T000315_A12IDVENTA, T000315_A54FECHAVENTA, T000315_A55DESCRIPCIONVENTA, T000315_A58DESCUENTOVENTA, T000315_A1IDEMPLEADO, T000315_A4IDCLIENTE
               }
               , new Object[] {
               T000316_A12IDVENTA, T000316_A54FECHAVENTA, T000316_A55DESCRIPCIONVENTA, T000316_A58DESCUENTOVENTA, T000316_A1IDEMPLEADO, T000316_A4IDCLIENTE
               }
               , new Object[] {
               T000317_A23NOMBRECOMPLETOEMPLEADO
               }
               , new Object[] {
               T000318_A30NOMBRECOMPLETOCLIENTE
               }
               , new Object[] {
               T000319_A12IDVENTA, T000319_A54FECHAVENTA, T000319_A55DESCRIPCIONVENTA, T000319_A23NOMBRECOMPLETOEMPLEADO, T000319_A30NOMBRECOMPLETOCLIENTE, T000319_A58DESCUENTOVENTA, T000319_A1IDEMPLEADO, T000319_A4IDCLIENTE
               }
               , new Object[] {
               T000323_A57IMPUESTOVENTA, T000323_n57IMPUESTOVENTA
               }
               , new Object[] {
               T000327_A59TOTALVENTA, T000327_n59TOTALVENTA
               }
               , new Object[] {
               T000328_A23NOMBRECOMPLETOEMPLEADO
               }
               , new Object[] {
               T000329_A30NOMBRECOMPLETOCLIENTE
               }
               , new Object[] {
               T000330_A12IDVENTA
               }
               , new Object[] {
               T000331_A12IDVENTA
               }
               , new Object[] {
               T000332_A12IDVENTA
               }
               , new Object[] {
               T000333_A12IDVENTA
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000339_A57IMPUESTOVENTA, T000339_n57IMPUESTOVENTA
               }
               , new Object[] {
               T000340_A23NOMBRECOMPLETOEMPLEADO
               }
               , new Object[] {
               T000341_A30NOMBRECOMPLETOCLIENTE
               }
               , new Object[] {
               T000345_A59TOTALVENTA, T000345_n59TOTALVENTA
               }
               , new Object[] {
               T000346_A12IDVENTA
               }
               , new Object[] {
               T000348_A12IDVENTA, T000348_A40DESCRIPCIONPRODUCTO, T000348_A41CANTIDADPRODUCTO, T000348_A43PRECIOVENTAPRODUCTO, T000348_A7IDPRODUCTO, T000348_A56SUBTOTALVENTAPRODUCTO, T000348_n56SUBTOTALVENTAPRODUCTO
               }
               , new Object[] {
               T000349_A40DESCRIPCIONPRODUCTO, T000349_A41CANTIDADPRODUCTO, T000349_A43PRECIOVENTAPRODUCTO
               }
               , new Object[] {
               T000351_A56SUBTOTALVENTAPRODUCTO, T000351_n56SUBTOTALVENTAPRODUCTO
               }
               , new Object[] {
               T000352_A12IDVENTA, T000352_A7IDPRODUCTO
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000355_A40DESCRIPCIONPRODUCTO, T000355_A41CANTIDADPRODUCTO, T000355_A43PRECIOVENTAPRODUCTO
               }
               , new Object[] {
               T000357_A56SUBTOTALVENTAPRODUCTO, T000357_n56SUBTOTALVENTAPRODUCTO
               }
               , new Object[] {
               T000358_A12IDVENTA, T000358_A7IDPRODUCTO
               }
            }
         );
         AV16Pgmname = "Ventas_inventario";
         Z54FECHAVENTA = DateTime.MinValue;
         A54FECHAVENTA = DateTime.MinValue;
         i54FECHAVENTA = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_5 ;
      private short nRcdDeleted_5 ;
      private short nRcdExists_5 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridventas_inventario_detalle_venta_producto_Backcolorstyle ;
      private short subGridventas_inventario_detalle_venta_producto_Allowselection ;
      private short subGridventas_inventario_detalle_venta_producto_Allowhovering ;
      private short subGridventas_inventario_detalle_venta_producto_Allowcollapsing ;
      private short subGridventas_inventario_detalle_venta_producto_Collapsed ;
      private short nBlankRcdCount5 ;
      private short RcdFound5 ;
      private short nBlankRcdUsr5 ;
      private short Gx_BScreen ;
      private short RcdFound4 ;
      private short GX_JID ;
      private short nIsDirty_4 ;
      private short nIsDirty_5 ;
      private short subGridventas_inventario_detalle_venta_producto_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_73 ;
      private int nGXsfl_73_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIDVENTA_Enabled ;
      private int edtFECHAVENTA_Enabled ;
      private int edtDESCRIPCIONVENTA_Enabled ;
      private int edtIDEMPLEADO_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtNOMBRECOMPLETOEMPLEADO_Enabled ;
      private int edtIDCLIENTE_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtNOMBRECOMPLETOCLIENTE_Enabled ;
      private int edtIMPUESTOVENTA_Enabled ;
      private int edtDESCUENTOVENTA_Enabled ;
      private int edtTOTALVENTA_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtIDPRODUCTO_Enabled ;
      private int edtDESCRIPCIONPRODUCTO_Enabled ;
      private int edtCANTIDADPRODUCTO_Enabled ;
      private int edtPRECIOVENTAPRODUCTO_Enabled ;
      private int edtSUBTOTALVENTAPRODUCTO_Enabled ;
      private int subGridventas_inventario_detalle_venta_producto_Selectedindex ;
      private int subGridventas_inventario_detalle_venta_producto_Selectioncolor ;
      private int subGridventas_inventario_detalle_venta_producto_Hoveringcolor ;
      private int fRowAdded ;
      private int AV17GXV1 ;
      private int subGridventas_inventario_detalle_venta_producto_Backcolor ;
      private int subGridventas_inventario_detalle_venta_producto_Allbackcolor ;
      private int imgprompt_7_Visible ;
      private int defedtSUBTOTALVENTAPRODUCTO_Enabled ;
      private int defedtPRECIOVENTAPRODUCTO_Enabled ;
      private int defedtCANTIDADPRODUCTO_Enabled ;
      private int defedtDESCRIPCIONPRODUCTO_Enabled ;
      private int defedtIDPRODUCTO_Enabled ;
      private int idxLst ;
      private long wcpOAV7IDVENTA ;
      private long Z12IDVENTA ;
      private long Z1IDEMPLEADO ;
      private long Z4IDCLIENTE ;
      private long N1IDEMPLEADO ;
      private long N4IDCLIENTE ;
      private long Z7IDPRODUCTO ;
      private long A12IDVENTA ;
      private long A1IDEMPLEADO ;
      private long A4IDCLIENTE ;
      private long A7IDPRODUCTO ;
      private long AV7IDVENTA ;
      private long A41CANTIDADPRODUCTO ;
      private long AV13Insert_IDEMPLEADO ;
      private long AV11Insert_IDCLIENTE ;
      private long GRIDVENTAS_INVENTARIO_DETALLE_VENTA_PRODUCTO_nFirstRecordOnPage ;
      private long Z41CANTIDADPRODUCTO ;
      private decimal Z58DESCUENTOVENTA ;
      private decimal A57IMPUESTOVENTA ;
      private decimal A58DESCUENTOVENTA ;
      private decimal A59TOTALVENTA ;
      private decimal A43PRECIOVENTAPRODUCTO ;
      private decimal A56SUBTOTALVENTAPRODUCTO ;
      private decimal Z43PRECIOVENTAPRODUCTO ;
      private decimal Z56SUBTOTALVENTAPRODUCTO ;
      private decimal Z57IMPUESTOVENTA ;
      private decimal Z59TOTALVENTA ;
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
      private string edtDESCRIPCIONVENTA_Internalname ;
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
      private string edtIDVENTA_Internalname ;
      private string edtIDVENTA_Jsonclick ;
      private string edtFECHAVENTA_Internalname ;
      private string edtFECHAVENTA_Jsonclick ;
      private string edtIDEMPLEADO_Internalname ;
      private string edtIDEMPLEADO_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtNOMBRECOMPLETOEMPLEADO_Internalname ;
      private string edtIDCLIENTE_Internalname ;
      private string edtIDCLIENTE_Jsonclick ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtNOMBRECOMPLETOCLIENTE_Internalname ;
      private string divDetalle_venta_productotable_Internalname ;
      private string lblTitledetalle_venta_producto_Internalname ;
      private string lblTitledetalle_venta_producto_Jsonclick ;
      private string edtIMPUESTOVENTA_Internalname ;
      private string edtIMPUESTOVENTA_Jsonclick ;
      private string edtDESCUENTOVENTA_Internalname ;
      private string edtDESCUENTOVENTA_Jsonclick ;
      private string edtTOTALVENTA_Internalname ;
      private string edtTOTALVENTA_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridventas_inventario_detalle_venta_producto_Header ;
      private string sMode5 ;
      private string edtIDPRODUCTO_Internalname ;
      private string edtDESCRIPCIONPRODUCTO_Internalname ;
      private string edtCANTIDADPRODUCTO_Internalname ;
      private string edtPRECIOVENTAPRODUCTO_Internalname ;
      private string edtSUBTOTALVENTAPRODUCTO_Internalname ;
      private string sStyleString ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode4 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_7_Internalname ;
      private string sGXsfl_73_fel_idx="0001" ;
      private string subGridventas_inventario_detalle_venta_producto_Class ;
      private string subGridventas_inventario_detalle_venta_producto_Linesclass ;
      private string imgprompt_7_Link ;
      private string ROClassString ;
      private string edtIDPRODUCTO_Jsonclick ;
      private string edtDESCRIPCIONPRODUCTO_Jsonclick ;
      private string edtCANTIDADPRODUCTO_Jsonclick ;
      private string edtPRECIOVENTAPRODUCTO_Jsonclick ;
      private string edtSUBTOTALVENTAPRODUCTO_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridventas_inventario_detalle_venta_producto_Internalname ;
      private DateTime Z54FECHAVENTA ;
      private DateTime A54FECHAVENTA ;
      private DateTime Gx_date ;
      private DateTime i54FECHAVENTA ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n57IMPUESTOVENTA ;
      private bool wbErr ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool n59TOTALVENTA ;
      private bool returnInSub ;
      private bool n56SUBTOTALVENTAPRODUCTO ;
      private string Z55DESCRIPCIONVENTA ;
      private string A55DESCRIPCIONVENTA ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private string A30NOMBRECOMPLETOCLIENTE ;
      private string A40DESCRIPCIONPRODUCTO ;
      private string Z23NOMBRECOMPLETOEMPLEADO ;
      private string Z30NOMBRECOMPLETOCLIENTE ;
      private string Z40DESCRIPCIONPRODUCTO ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridventas_inventario_detalle_venta_productoContainer ;
      private GXWebRow Gridventas_inventario_detalle_venta_productoRow ;
      private GXWebColumn Gridventas_inventario_detalle_venta_productoColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000314_A57IMPUESTOVENTA ;
      private bool[] T000314_n57IMPUESTOVENTA ;
      private decimal[] T000310_A59TOTALVENTA ;
      private bool[] T000310_n59TOTALVENTA ;
      private string[] T000318_A30NOMBRECOMPLETOCLIENTE ;
      private string[] T000317_A23NOMBRECOMPLETOEMPLEADO ;
      private long[] T000319_A12IDVENTA ;
      private DateTime[] T000319_A54FECHAVENTA ;
      private string[] T000319_A55DESCRIPCIONVENTA ;
      private string[] T000319_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] T000319_A30NOMBRECOMPLETOCLIENTE ;
      private decimal[] T000319_A58DESCUENTOVENTA ;
      private long[] T000319_A1IDEMPLEADO ;
      private long[] T000319_A4IDCLIENTE ;
      private decimal[] T000323_A57IMPUESTOVENTA ;
      private bool[] T000323_n57IMPUESTOVENTA ;
      private decimal[] T000327_A59TOTALVENTA ;
      private bool[] T000327_n59TOTALVENTA ;
      private string[] T000328_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] T000329_A30NOMBRECOMPLETOCLIENTE ;
      private long[] T000330_A12IDVENTA ;
      private long[] T000316_A12IDVENTA ;
      private DateTime[] T000316_A54FECHAVENTA ;
      private string[] T000316_A55DESCRIPCIONVENTA ;
      private decimal[] T000316_A58DESCUENTOVENTA ;
      private long[] T000316_A1IDEMPLEADO ;
      private long[] T000316_A4IDCLIENTE ;
      private long[] T000331_A12IDVENTA ;
      private long[] T000332_A12IDVENTA ;
      private long[] T000315_A12IDVENTA ;
      private DateTime[] T000315_A54FECHAVENTA ;
      private string[] T000315_A55DESCRIPCIONVENTA ;
      private decimal[] T000315_A58DESCUENTOVENTA ;
      private long[] T000315_A1IDEMPLEADO ;
      private long[] T000315_A4IDCLIENTE ;
      private long[] T000333_A12IDVENTA ;
      private decimal[] T000339_A57IMPUESTOVENTA ;
      private bool[] T000339_n57IMPUESTOVENTA ;
      private string[] T000340_A23NOMBRECOMPLETOEMPLEADO ;
      private string[] T000341_A30NOMBRECOMPLETOCLIENTE ;
      private decimal[] T000345_A59TOTALVENTA ;
      private bool[] T000345_n59TOTALVENTA ;
      private long[] T000346_A12IDVENTA ;
      private long[] T000348_A12IDVENTA ;
      private string[] T000348_A40DESCRIPCIONPRODUCTO ;
      private long[] T000348_A41CANTIDADPRODUCTO ;
      private decimal[] T000348_A43PRECIOVENTAPRODUCTO ;
      private long[] T000348_A7IDPRODUCTO ;
      private decimal[] T000348_A56SUBTOTALVENTAPRODUCTO ;
      private bool[] T000348_n56SUBTOTALVENTAPRODUCTO ;
      private string[] T00034_A40DESCRIPCIONPRODUCTO ;
      private long[] T00034_A41CANTIDADPRODUCTO ;
      private decimal[] T00034_A43PRECIOVENTAPRODUCTO ;
      private decimal[] T00036_A56SUBTOTALVENTAPRODUCTO ;
      private bool[] T00036_n56SUBTOTALVENTAPRODUCTO ;
      private string[] T000349_A40DESCRIPCIONPRODUCTO ;
      private long[] T000349_A41CANTIDADPRODUCTO ;
      private decimal[] T000349_A43PRECIOVENTAPRODUCTO ;
      private decimal[] T000351_A56SUBTOTALVENTAPRODUCTO ;
      private bool[] T000351_n56SUBTOTALVENTAPRODUCTO ;
      private long[] T000352_A12IDVENTA ;
      private long[] T000352_A7IDPRODUCTO ;
      private long[] T00033_A12IDVENTA ;
      private long[] T00033_A7IDPRODUCTO ;
      private long[] T00032_A12IDVENTA ;
      private long[] T00032_A7IDPRODUCTO ;
      private string[] T000355_A40DESCRIPCIONPRODUCTO ;
      private long[] T000355_A41CANTIDADPRODUCTO ;
      private decimal[] T000355_A43PRECIOVENTAPRODUCTO ;
      private decimal[] T000357_A56SUBTOTALVENTAPRODUCTO ;
      private bool[] T000357_n56SUBTOTALVENTAPRODUCTO ;
      private long[] T000358_A12IDVENTA ;
      private long[] T000358_A7IDPRODUCTO ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class ventas_inventario__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new UpdateCursor(def[30])
         ,new UpdateCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000319;
          prmT000319 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@IMPUESTOVENTA",GXType.Decimal,12,2){Nullable=true} ,
          new ParDef("@DESCUENTOVENTA",GXType.Decimal,12,2) ,
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000323;
          prmT000323 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000327;
          prmT000327 = new Object[] {
          new ParDef("@IMPUESTOVENTA",GXType.Decimal,12,2){Nullable=true} ,
          new ParDef("@DESCUENTOVENTA",GXType.Decimal,12,2) ,
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000328;
          prmT000328 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000329;
          prmT000329 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000330;
          prmT000330 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000331;
          prmT000331 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000332;
          prmT000332 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000333;
          prmT000333 = new Object[] {
          new ParDef("@FECHAVENTA",GXType.Date,8,0) ,
          new ParDef("@DESCRIPCIONVENTA",GXType.NVarChar,255,0) ,
          new ParDef("@DESCUENTOVENTA",GXType.Decimal,12,2) ,
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000334;
          prmT000334 = new Object[] {
          new ParDef("@FECHAVENTA",GXType.Date,8,0) ,
          new ParDef("@DESCRIPCIONVENTA",GXType.NVarChar,255,0) ,
          new ParDef("@DESCUENTOVENTA",GXType.Decimal,12,2) ,
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0) ,
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0) ,
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000335;
          prmT000335 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000346;
          prmT000346 = new Object[] {
          };
          Object[] prmT000348;
          prmT000348 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000349;
          prmT000349 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000351;
          prmT000351 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000352;
          prmT000352 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000353;
          prmT000353 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000354;
          prmT000354 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0) ,
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000358;
          prmT000358 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000339;
          prmT000339 = new Object[] {
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000340;
          prmT000340 = new Object[] {
          new ParDef("@IDEMPLEADO",GXType.Decimal,12,0)
          };
          Object[] prmT000341;
          prmT000341 = new Object[] {
          new ParDef("@IDCLIENTE",GXType.Decimal,12,0)
          };
          Object[] prmT000345;
          prmT000345 = new Object[] {
          new ParDef("@IMPUESTOVENTA",GXType.Decimal,12,2){Nullable=true} ,
          new ParDef("@DESCUENTOVENTA",GXType.Decimal,12,2) ,
          new ParDef("@IDVENTA",GXType.Decimal,12,0)
          };
          Object[] prmT000355;
          prmT000355 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          Object[] prmT000357;
          prmT000357 = new Object[] {
          new ParDef("@IDPRODUCTO",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [IDVENTA], [IDPRODUCTO] FROM [Ventas_inventarioDetalle_venta] WITH (UPDLOCK) WHERE [IDVENTA] = @IDVENTA AND [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [IDVENTA], [IDPRODUCTO] FROM [Ventas_inventarioDetalle_venta] WHERE [IDVENTA] = @IDVENTA AND [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOVENTAPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT COALESCE( T1.[SUBTOTALVENTAPRODUCTO], 0) AS SUBTOTALVENTAPRODUCTO FROM (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T1 WHERE T1.[IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000310", "SELECT COALESCE( T1.[TOTALVENTA], 0) AS TOTALVENTA FROM (SELECT COALESCE( T2.[GXC1], 0) + @IMPUESTOVENTA - @DESCUENTOVENTA AS TOTALVENTA FROM (SELECT SUM(COALESCE( T4.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC1, T3.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T3 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T4 ON T4.[IDPRODUCTO] = T3.[IDPRODUCTO]) GROUP BY T3.[IDVENTA] ) T2 WHERE T2.[IDVENTA] = @IDVENTA ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000314", "SELECT COALESCE( T1.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA FROM (SELECT COALESCE( T2.[GXC1], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA FROM (SELECT SUM(COALESCE( T4.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC1, T3.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T3 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T4 ON T4.[IDPRODUCTO] = T3.[IDPRODUCTO]) GROUP BY T3.[IDVENTA] ) T2 WHERE T2.[IDVENTA] = @IDVENTA ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000315", "SELECT [IDVENTA], [FECHAVENTA], [DESCRIPCIONVENTA], [DESCUENTOVENTA], [IDEMPLEADO], [IDCLIENTE] FROM [Ventas_inventario] WITH (UPDLOCK) WHERE [IDVENTA] = @IDVENTA ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000316", "SELECT [IDVENTA], [FECHAVENTA], [DESCRIPCIONVENTA], [DESCUENTOVENTA], [IDEMPLEADO], [IDCLIENTE] FROM [Ventas_inventario] WHERE [IDVENTA] = @IDVENTA ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000317", "SELECT [NOMBRECOMPLETOEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000318", "SELECT [NOMBRECOMPLETOCLIENTE] FROM [Clientes] WHERE [IDCLIENTE] = @IDCLIENTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000319", "SELECT TM1.[IDVENTA], TM1.[FECHAVENTA], TM1.[DESCRIPCIONVENTA], T2.[NOMBRECOMPLETOEMPLEADO], T3.[NOMBRECOMPLETOCLIENTE], TM1.[DESCUENTOVENTA], TM1.[IDEMPLEADO], TM1.[IDCLIENTE] FROM (([Ventas_inventario] TM1 INNER JOIN [Empleados] T2 ON T2.[IDEMPLEADO] = TM1.[IDEMPLEADO]) INNER JOIN [Clientes] T3 ON T3.[IDCLIENTE] = TM1.[IDCLIENTE]) WHERE TM1.[IDVENTA] = @IDVENTA ORDER BY TM1.[IDVENTA]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000319,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000323", "SELECT COALESCE( T1.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA FROM (SELECT COALESCE( T2.[GXC1], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA FROM (SELECT SUM(COALESCE( T4.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC1, T3.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T3 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T4 ON T4.[IDPRODUCTO] = T3.[IDPRODUCTO]) GROUP BY T3.[IDVENTA] ) T2 WHERE T2.[IDVENTA] = @IDVENTA ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000323,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000327", "SELECT COALESCE( T1.[TOTALVENTA], 0) AS TOTALVENTA FROM (SELECT COALESCE( T2.[GXC1], 0) + @IMPUESTOVENTA - @DESCUENTOVENTA AS TOTALVENTA FROM (SELECT SUM(COALESCE( T4.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC1, T3.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T3 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T4 ON T4.[IDPRODUCTO] = T3.[IDPRODUCTO]) GROUP BY T3.[IDVENTA] ) T2 WHERE T2.[IDVENTA] = @IDVENTA ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000327,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000328", "SELECT [NOMBRECOMPLETOEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000328,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000329", "SELECT [NOMBRECOMPLETOCLIENTE] FROM [Clientes] WHERE [IDCLIENTE] = @IDCLIENTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000329,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000330", "SELECT [IDVENTA] FROM [Ventas_inventario] WHERE [IDVENTA] = @IDVENTA  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000330,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000331", "SELECT TOP 1 [IDVENTA] FROM [Ventas_inventario] WHERE ( [IDVENTA] > @IDVENTA) ORDER BY [IDVENTA]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000331,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000332", "SELECT TOP 1 [IDVENTA] FROM [Ventas_inventario] WHERE ( [IDVENTA] < @IDVENTA) ORDER BY [IDVENTA] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000332,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000333", "INSERT INTO [Ventas_inventario]([FECHAVENTA], [DESCRIPCIONVENTA], [DESCUENTOVENTA], [IDEMPLEADO], [IDCLIENTE]) VALUES(@FECHAVENTA, @DESCRIPCIONVENTA, @DESCUENTOVENTA, @IDEMPLEADO, @IDCLIENTE); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000333)
             ,new CursorDef("T000334", "UPDATE [Ventas_inventario] SET [FECHAVENTA]=@FECHAVENTA, [DESCRIPCIONVENTA]=@DESCRIPCIONVENTA, [DESCUENTOVENTA]=@DESCUENTOVENTA, [IDEMPLEADO]=@IDEMPLEADO, [IDCLIENTE]=@IDCLIENTE  WHERE [IDVENTA] = @IDVENTA", GxErrorMask.GX_NOMASK,prmT000334)
             ,new CursorDef("T000335", "DELETE FROM [Ventas_inventario]  WHERE [IDVENTA] = @IDVENTA", GxErrorMask.GX_NOMASK,prmT000335)
             ,new CursorDef("T000339", "SELECT COALESCE( T1.[IMPUESTOVENTA], 0) AS IMPUESTOVENTA FROM (SELECT COALESCE( T2.[GXC1], 0) * CAST(0.15 AS decimal( 22, 10)) AS IMPUESTOVENTA FROM (SELECT SUM(COALESCE( T4.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC1, T3.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T3 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T4 ON T4.[IDPRODUCTO] = T3.[IDPRODUCTO]) GROUP BY T3.[IDVENTA] ) T2 WHERE T2.[IDVENTA] = @IDVENTA ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000339,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000340", "SELECT [NOMBRECOMPLETOEMPLEADO] FROM [Empleados] WHERE [IDEMPLEADO] = @IDEMPLEADO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000340,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000341", "SELECT [NOMBRECOMPLETOCLIENTE] FROM [Clientes] WHERE [IDCLIENTE] = @IDCLIENTE ",true, GxErrorMask.GX_NOMASK, false, this,prmT000341,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000345", "SELECT COALESCE( T1.[TOTALVENTA], 0) AS TOTALVENTA FROM (SELECT COALESCE( T2.[GXC1], 0) + @IMPUESTOVENTA - @DESCUENTOVENTA AS TOTALVENTA FROM (SELECT SUM(COALESCE( T4.[SUBTOTALVENTAPRODUCTO], 0)) AS GXC1, T3.[IDVENTA] FROM ([Ventas_inventarioDetalle_venta] T3 WITH (UPDLOCK) INNER JOIN (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T4 ON T4.[IDPRODUCTO] = T3.[IDPRODUCTO]) GROUP BY T3.[IDVENTA] ) T2 WHERE T2.[IDVENTA] = @IDVENTA ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000345,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000346", "SELECT [IDVENTA] FROM [Ventas_inventario] ORDER BY [IDVENTA]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000346,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000348", "SELECT T1.[IDVENTA], T2.[DESCRIPCIONPRODUCTO], T2.[CANTIDADPRODUCTO], T2.[PRECIOVENTAPRODUCTO], T1.[IDPRODUCTO], COALESCE( T3.[SUBTOTALVENTAPRODUCTO], 0) AS SUBTOTALVENTAPRODUCTO FROM (([Ventas_inventarioDetalle_venta] T1 INNER JOIN [Inventario] T2 ON T2.[IDPRODUCTO] = T1.[IDPRODUCTO]) INNER JOIN (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T3 ON T3.[IDPRODUCTO] = T1.[IDPRODUCTO]) WHERE T1.[IDVENTA] = @IDVENTA and T1.[IDPRODUCTO] = @IDPRODUCTO ORDER BY T1.[IDVENTA], T1.[IDPRODUCTO] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000348,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000349", "SELECT [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOVENTAPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000349,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000351", "SELECT COALESCE( T1.[SUBTOTALVENTAPRODUCTO], 0) AS SUBTOTALVENTAPRODUCTO FROM (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T1 WHERE T1.[IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000351,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000352", "SELECT [IDVENTA], [IDPRODUCTO] FROM [Ventas_inventarioDetalle_venta] WHERE [IDVENTA] = @IDVENTA AND [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000352,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000353", "INSERT INTO [Ventas_inventarioDetalle_venta]([IDVENTA], [IDPRODUCTO]) VALUES(@IDVENTA, @IDPRODUCTO)", GxErrorMask.GX_NOMASK,prmT000353)
             ,new CursorDef("T000354", "DELETE FROM [Ventas_inventarioDetalle_venta]  WHERE [IDVENTA] = @IDVENTA AND [IDPRODUCTO] = @IDPRODUCTO", GxErrorMask.GX_NOMASK,prmT000354)
             ,new CursorDef("T000355", "SELECT [DESCRIPCIONPRODUCTO], [CANTIDADPRODUCTO], [PRECIOVENTAPRODUCTO] FROM [Inventario] WHERE [IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000355,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000357", "SELECT COALESCE( T1.[SUBTOTALVENTAPRODUCTO], 0) AS SUBTOTALVENTAPRODUCTO FROM (SELECT COALESCE( [GXC3], 0) AS SUBTOTALVENTAPRODUCTO, [IDPRODUCTO] FROM [Inventario] ) T1 WHERE T1.[IDPRODUCTO] = @IDPRODUCTO ",true, GxErrorMask.GX_NOMASK, false, this,prmT000357,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000358", "SELECT [IDVENTA], [IDPRODUCTO] FROM [Ventas_inventarioDetalle_venta] WHERE [IDVENTA] = @IDVENTA ORDER BY [IDVENTA], [IDPRODUCTO] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000358,11, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 11 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
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
             case 21 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 24 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 26 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 28 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 32 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 33 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 34 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
