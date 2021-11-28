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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class areporte_empleados : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public areporte_empleados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public areporte_empleados( IGxContext context )
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
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         areporte_empleados objareporte_empleados;
         objareporte_empleados = new areporte_empleados();
         objareporte_empleados.context.SetSubmitInitialConfig(context);
         objareporte_empleados.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objareporte_empleados);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((areporte_empleados)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 21298, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0G0( false, 253) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("REPORTE DE EMPLEADOS DE LA TIENDA DE MODA", 380, Gx_line+160, 960, Gx_line+187, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 107, Gx_line+187, 200, Gx_line+202, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+214, 1480, Gx_line+214, 2, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ID", 33, Gx_line+227, 53, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Nombre Completo", 113, Gx_line+227, 246, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Telefono", 300, Gx_line+227, 373, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha de Contratacion", 440, Gx_line+227, 607, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Correo Electronico", 627, Gx_line+227, 760, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Tipo", 1360, Gx_line+227, 1393, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Fotografia", 973, Gx_line+227, 1040, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Direccion", 807, Gx_line+227, 887, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Estado", 1160, Gx_line+227, 1213, Gx_line+241, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 40, Gx_line+187, 89, Gx_line+202, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1380, Gx_line+173, 1419, Gx_line+188, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "6426d147-e335-46f3-9b38-8ad85a90aa77", "", context.GetTheme( )), 540, Gx_line+13, 833, Gx_line+146) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+253);
            /* Using cursor P000G2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2IDTIPOEMPLEADO = P000G2_A2IDTIPOEMPLEADO[0];
               A3IDESTADOEMPLEADO = P000G2_A3IDESTADOEMPLEADO[0];
               A40000FOTOEMPLEADO_GXI = P000G2_A40000FOTOEMPLEADO_GXI[0];
               A23NOMBRECOMPLETOEMPLEADO = P000G2_A23NOMBRECOMPLETOEMPLEADO[0];
               A29FECHACONTRATACIONEMPLEADO = P000G2_A29FECHACONTRATACIONEMPLEADO[0];
               A27CORREOEMPLEADO = P000G2_A27CORREOEMPLEADO[0];
               A28DIRECCIONEMPLEADO = P000G2_A28DIRECCIONEMPLEADO[0];
               A22DESCRIPCIONESTADOEMPLEADO = P000G2_A22DESCRIPCIONESTADOEMPLEADO[0];
               A21DESCRIPCIONTIPOEMPLEADO = P000G2_A21DESCRIPCIONTIPOEMPLEADO[0];
               A26TELEFONOEMPLEADO = P000G2_A26TELEFONOEMPLEADO[0];
               A1IDEMPLEADO = P000G2_A1IDEMPLEADO[0];
               A52FOTOEMPLEADO = P000G2_A52FOTOEMPLEADO[0];
               A21DESCRIPCIONTIPOEMPLEADO = P000G2_A21DESCRIPCIONTIPOEMPLEADO[0];
               A22DESCRIPCIONESTADOEMPLEADO = P000G2_A22DESCRIPCIONESTADOEMPLEADO[0];
               H0G0( false, 158) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A26TELEFONOEMPLEADO, "")), 273, Gx_line+80, 406, Gx_line+93, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A21DESCRIPCIONTIPOEMPLEADO, "")), 1300, Gx_line+80, 1469, Gx_line+95, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A22DESCRIPCIONESTADOEMPLEADO, "")), 1093, Gx_line+80, 1286, Gx_line+95, 1, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A52FOTOEMPLEADO)) ? A40000FOTOEMPLEADO_GXI : A52FOTOEMPLEADO);
               getPrinter().GxDrawBitMap(sImgUrl, 940, Gx_line+13, 1073, Gx_line+146) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28DIRECCIONEMPLEADO, "")), 780, Gx_line+80, 920, Gx_line+95, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A27CORREOEMPLEADO, "")), 627, Gx_line+80, 767, Gx_line+95, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A29FECHACONTRATACIONEMPLEADO, "99/99/99"), 413, Gx_line+80, 613, Gx_line+95, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A23NOMBRECOMPLETOEMPLEADO, "")), 87, Gx_line+80, 267, Gx_line+93, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1IDEMPLEADO), "ZZZZZZZZZZZ9")), 0, Gx_line+80, 80, Gx_line+93, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+158);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H0G0( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tienda: DE MODA", 13, Gx_line+0, 146, Gx_line+27, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException e )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException e )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0G0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         scmdbuf = "";
         P000G2_A2IDTIPOEMPLEADO = new long[1] ;
         P000G2_A3IDESTADOEMPLEADO = new long[1] ;
         P000G2_A40000FOTOEMPLEADO_GXI = new string[] {""} ;
         P000G2_A23NOMBRECOMPLETOEMPLEADO = new string[] {""} ;
         P000G2_A29FECHACONTRATACIONEMPLEADO = new DateTime[] {DateTime.MinValue} ;
         P000G2_A27CORREOEMPLEADO = new string[] {""} ;
         P000G2_A28DIRECCIONEMPLEADO = new string[] {""} ;
         P000G2_A22DESCRIPCIONESTADOEMPLEADO = new string[] {""} ;
         P000G2_A21DESCRIPCIONTIPOEMPLEADO = new string[] {""} ;
         P000G2_A26TELEFONOEMPLEADO = new string[] {""} ;
         P000G2_A1IDEMPLEADO = new long[1] ;
         P000G2_A52FOTOEMPLEADO = new string[] {""} ;
         A40000FOTOEMPLEADO_GXI = "";
         A23NOMBRECOMPLETOEMPLEADO = "";
         A29FECHACONTRATACIONEMPLEADO = DateTime.MinValue;
         A27CORREOEMPLEADO = "";
         A28DIRECCIONEMPLEADO = "";
         A22DESCRIPCIONESTADOEMPLEADO = "";
         A21DESCRIPCIONTIPOEMPLEADO = "";
         A26TELEFONOEMPLEADO = "";
         A52FOTOEMPLEADO = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporte_empleados__default(),
            new Object[][] {
                new Object[] {
               P000G2_A2IDTIPOEMPLEADO, P000G2_A3IDESTADOEMPLEADO, P000G2_A40000FOTOEMPLEADO_GXI, P000G2_A23NOMBRECOMPLETOEMPLEADO, P000G2_A29FECHACONTRATACIONEMPLEADO, P000G2_A27CORREOEMPLEADO, P000G2_A28DIRECCIONEMPLEADO, P000G2_A22DESCRIPCIONESTADOEMPLEADO, P000G2_A21DESCRIPCIONTIPOEMPLEADO, P000G2_A26TELEFONOEMPLEADO,
               P000G2_A1IDEMPLEADO, P000G2_A52FOTOEMPLEADO
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long A2IDTIPOEMPLEADO ;
      private long A3IDESTADOEMPLEADO ;
      private long A1IDEMPLEADO ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string Gx_time ;
      private string scmdbuf ;
      private string A26TELEFONOEMPLEADO ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private DateTime A29FECHACONTRATACIONEMPLEADO ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A40000FOTOEMPLEADO_GXI ;
      private string A23NOMBRECOMPLETOEMPLEADO ;
      private string A27CORREOEMPLEADO ;
      private string A28DIRECCIONEMPLEADO ;
      private string A22DESCRIPCIONESTADOEMPLEADO ;
      private string A21DESCRIPCIONTIPOEMPLEADO ;
      private string A52FOTOEMPLEADO ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P000G2_A2IDTIPOEMPLEADO ;
      private long[] P000G2_A3IDESTADOEMPLEADO ;
      private string[] P000G2_A40000FOTOEMPLEADO_GXI ;
      private string[] P000G2_A23NOMBRECOMPLETOEMPLEADO ;
      private DateTime[] P000G2_A29FECHACONTRATACIONEMPLEADO ;
      private string[] P000G2_A27CORREOEMPLEADO ;
      private string[] P000G2_A28DIRECCIONEMPLEADO ;
      private string[] P000G2_A22DESCRIPCIONESTADOEMPLEADO ;
      private string[] P000G2_A21DESCRIPCIONTIPOEMPLEADO ;
      private string[] P000G2_A26TELEFONOEMPLEADO ;
      private long[] P000G2_A1IDEMPLEADO ;
      private string[] P000G2_A52FOTOEMPLEADO ;
   }

   public class areporte_empleados__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT T1.[IDTIPOEMPLEADO], T1.[IDESTADOEMPLEADO], T1.[FOTOEMPLEADO_GXI], T1.[NOMBRECOMPLETOEMPLEADO], T1.[FECHACONTRATACIONEMPLEADO], T1.[CORREOEMPLEADO], T1.[DIRECCIONEMPLEADO], T3.[DESCRIPCIONESTADOEMPLEADO], T2.[DESCRIPCIONTIPOEMPLEADO], T1.[TELEFONOEMPLEADO], T1.[IDEMPLEADO], T1.[FOTOEMPLEADO] FROM (([Empleados] T1 INNER JOIN [Tipo_empleado] T2 ON T2.[IDTIPOEMPLEADO] = T1.[IDTIPOEMPLEADO]) INNER JOIN [Estado_empleado] T3 ON T3.[IDESTADOEMPLEADO] = T1.[IDESTADOEMPLEADO]) ORDER BY T1.[IDEMPLEADO] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(3));
                return;
       }
    }

 }

}
