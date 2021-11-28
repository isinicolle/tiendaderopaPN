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
   public class areporte_inventario : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public areporte_inventario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public areporte_inventario( IGxContext context )
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
         areporte_inventario objareporte_inventario;
         objareporte_inventario = new areporte_inventario();
         objareporte_inventario.context.SetSubmitInitialConfig(context);
         objareporte_inventario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objareporte_inventario);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((areporte_inventario)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 18115, 0, 1, 1, 0, 1, 1) )
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
            H0H0( false, 238) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("REPORTE  DE INVENTARIO TIENDA DE MODA", 333, Gx_line+133, 913, Gx_line+160, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1207, Gx_line+173, 1246, Gx_line+188, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 33, Gx_line+173, 82, Gx_line+188, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Categoria", 960, Gx_line+213, 1040, Gx_line+227, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Marca", 1140, Gx_line+213, 1207, Gx_line+227, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Estado", 793, Gx_line+213, 913, Gx_line+227, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Precio Venta", 600, Gx_line+213, 747, Gx_line+227, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Precio Compra", 453, Gx_line+213, 566, Gx_line+227, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("Nombre", 93, Gx_line+213, 246, Gx_line+227, 1, 0, 0, 0) ;
            getPrinter().GxDrawText("ID", 27, Gx_line+213, 47, Gx_line+227, 1, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+201, 1253, Gx_line+201, 2, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 100, Gx_line+173, 193, Gx_line+188, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Stock", 280, Gx_line+213, 413, Gx_line+227, 1, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+238);
            /* Using cursor P000H2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A5IDESTADOPRODUCTO = P000H2_A5IDESTADOPRODUCTO[0];
               A6IDCATEGORIAPRODUCTO = P000H2_A6IDCATEGORIAPRODUCTO[0];
               A8IDMARCAPRODUCTO = P000H2_A8IDMARCAPRODUCTO[0];
               A44DESCRIPCIONMARCAPRODUCTO = P000H2_A44DESCRIPCIONMARCAPRODUCTO[0];
               A39DESCRIPCIONCATEGORIAPRODUCTO = P000H2_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
               A38DESCRIPCIONESTADOPRODUCTO = P000H2_A38DESCRIPCIONESTADOPRODUCTO[0];
               A43PRECIOVENTAPRODUCTO = P000H2_A43PRECIOVENTAPRODUCTO[0];
               A42PRECIOCOMPRAPRODUCTO = P000H2_A42PRECIOCOMPRAPRODUCTO[0];
               A41CANTIDADPRODUCTO = P000H2_A41CANTIDADPRODUCTO[0];
               A40DESCRIPCIONPRODUCTO = P000H2_A40DESCRIPCIONPRODUCTO[0];
               A7IDPRODUCTO = P000H2_A7IDPRODUCTO[0];
               A38DESCRIPCIONESTADOPRODUCTO = P000H2_A38DESCRIPCIONESTADOPRODUCTO[0];
               A39DESCRIPCIONCATEGORIAPRODUCTO = P000H2_A39DESCRIPCIONCATEGORIAPRODUCTO[0];
               A44DESCRIPCIONMARCAPRODUCTO = P000H2_A44DESCRIPCIONMARCAPRODUCTO[0];
               H0H0( false, 42) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A7IDPRODUCTO), "ZZZZZZZZZZZ9")), 0, Gx_line+0, 80, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A40DESCRIPCIONPRODUCTO, "")), 107, Gx_line+0, 260, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A41CANTIDADPRODUCTO), "ZZZZZZZZZZZ9")), 280, Gx_line+0, 420, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A42PRECIOCOMPRAPRODUCTO, "ZZZZZZZZ9.99")), 440, Gx_line+0, 607, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A43PRECIOVENTAPRODUCTO, "ZZZZZZZZ9.99")), 640, Gx_line+0, 733, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A38DESCRIPCIONESTADOPRODUCTO, "")), 773, Gx_line+0, 946, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A39DESCRIPCIONCATEGORIAPRODUCTO, "")), 960, Gx_line+0, 1080, Gx_line+15, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A44DESCRIPCIONMARCAPRODUCTO, "")), 1093, Gx_line+0, 1249, Gx_line+15, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H0H0( false, 29) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, true, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tienda: DE MODA", 0, Gx_line+0, 133, Gx_line+27, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+29);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
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

      protected void H0H0( bool bFoot ,
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
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         scmdbuf = "";
         P000H2_A5IDESTADOPRODUCTO = new long[1] ;
         P000H2_A6IDCATEGORIAPRODUCTO = new long[1] ;
         P000H2_A8IDMARCAPRODUCTO = new long[1] ;
         P000H2_A44DESCRIPCIONMARCAPRODUCTO = new string[] {""} ;
         P000H2_A39DESCRIPCIONCATEGORIAPRODUCTO = new string[] {""} ;
         P000H2_A38DESCRIPCIONESTADOPRODUCTO = new string[] {""} ;
         P000H2_A43PRECIOVENTAPRODUCTO = new decimal[1] ;
         P000H2_A42PRECIOCOMPRAPRODUCTO = new decimal[1] ;
         P000H2_A41CANTIDADPRODUCTO = new long[1] ;
         P000H2_A40DESCRIPCIONPRODUCTO = new string[] {""} ;
         P000H2_A7IDPRODUCTO = new long[1] ;
         A44DESCRIPCIONMARCAPRODUCTO = "";
         A39DESCRIPCIONCATEGORIAPRODUCTO = "";
         A38DESCRIPCIONESTADOPRODUCTO = "";
         A40DESCRIPCIONPRODUCTO = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areporte_inventario__default(),
            new Object[][] {
                new Object[] {
               P000H2_A5IDESTADOPRODUCTO, P000H2_A6IDCATEGORIAPRODUCTO, P000H2_A8IDMARCAPRODUCTO, P000H2_A44DESCRIPCIONMARCAPRODUCTO, P000H2_A39DESCRIPCIONCATEGORIAPRODUCTO, P000H2_A38DESCRIPCIONESTADOPRODUCTO, P000H2_A43PRECIOVENTAPRODUCTO, P000H2_A42PRECIOCOMPRAPRODUCTO, P000H2_A41CANTIDADPRODUCTO, P000H2_A40DESCRIPCIONPRODUCTO,
               P000H2_A7IDPRODUCTO
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
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
      private long A5IDESTADOPRODUCTO ;
      private long A6IDCATEGORIAPRODUCTO ;
      private long A8IDMARCAPRODUCTO ;
      private long A41CANTIDADPRODUCTO ;
      private long A7IDPRODUCTO ;
      private decimal A43PRECIOVENTAPRODUCTO ;
      private decimal A42PRECIOCOMPRAPRODUCTO ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string Gx_time ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A44DESCRIPCIONMARCAPRODUCTO ;
      private string A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string A38DESCRIPCIONESTADOPRODUCTO ;
      private string A40DESCRIPCIONPRODUCTO ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P000H2_A5IDESTADOPRODUCTO ;
      private long[] P000H2_A6IDCATEGORIAPRODUCTO ;
      private long[] P000H2_A8IDMARCAPRODUCTO ;
      private string[] P000H2_A44DESCRIPCIONMARCAPRODUCTO ;
      private string[] P000H2_A39DESCRIPCIONCATEGORIAPRODUCTO ;
      private string[] P000H2_A38DESCRIPCIONESTADOPRODUCTO ;
      private decimal[] P000H2_A43PRECIOVENTAPRODUCTO ;
      private decimal[] P000H2_A42PRECIOCOMPRAPRODUCTO ;
      private long[] P000H2_A41CANTIDADPRODUCTO ;
      private string[] P000H2_A40DESCRIPCIONPRODUCTO ;
      private long[] P000H2_A7IDPRODUCTO ;
   }

   public class areporte_inventario__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T1.[IDESTADOPRODUCTO], T1.[IDCATEGORIAPRODUCTO], T1.[IDMARCAPRODUCTO], T4.[DESCRIPCIONMARCAPRODUCTO], T3.[DESCRIPCIONCATEGORIAPRODUCTO], T2.[DESCRIPCIONESTADOPRODUCTO], T1.[PRECIOVENTAPRODUCTO], T1.[PRECIOCOMPRAPRODUCTO], T1.[CANTIDADPRODUCTO], T1.[DESCRIPCIONPRODUCTO], T1.[IDPRODUCTO] FROM ((([Inventario] T1 INNER JOIN [Estado_producto] T2 ON T2.[IDESTADOPRODUCTO] = T1.[IDESTADOPRODUCTO]) INNER JOIN [Categoria_producto] T3 ON T3.[IDCATEGORIAPRODUCTO] = T1.[IDCATEGORIAPRODUCTO]) INNER JOIN [Marca_producto] T4 ON T4.[IDMARCAPRODUCTO] = T1.[IDMARCAPRODUCTO]) ORDER BY T1.[IDPRODUCTO] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
       }
    }

 }

}
