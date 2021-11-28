using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public reorg( IGxContext context )
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

      void executePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void ReorganizeEmpleados( )
      {
         string cmdBuffer = "";
         /* Indices for table Empleados */
         cmdBuffer=" ALTER TABLE [Empleados] ALTER COLUMN [CONTRASENAEMPLEADO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE [Empleados] ALTER COLUMN [USUARIOEMPLEADO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE [Empleados] ALTER COLUMN [NOMBRECOMPLETOEMPLEADO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeCompra_inventario( )
      {
         string cmdBuffer = "";
         /* Indices for table Compra_inventario */
         cmdBuffer=" ALTER TABLE [Compra_inventario] ALTER COLUMN [DESCRIPCIONCOMPRA] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeVentas_inventario( )
      {
         string cmdBuffer = "";
         /* Indices for table Ventas_inventario */
         cmdBuffer=" ALTER TABLE [Ventas_inventario] ALTER COLUMN [DESCRIPCIONVENTA] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTipo_empleado( )
      {
         string cmdBuffer = "";
         /* Indices for table Tipo_empleado */
         cmdBuffer=" ALTER TABLE [Tipo_empleado] ALTER COLUMN [DESCRIPCIONTIPOEMPLEADO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeEstado_empleado( )
      {
         string cmdBuffer = "";
         /* Indices for table Estado_empleado */
         cmdBuffer=" ALTER TABLE [Estado_empleado] ALTER COLUMN [DESCRIPCIONESTADOEMPLEADO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeClientes( )
      {
         string cmdBuffer = "";
         /* Indices for table Clientes */
         cmdBuffer=" ALTER TABLE [Clientes] ALTER COLUMN [CONTRASENACLIENTE] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE [Clientes] ALTER COLUMN [USUARIOCLIENTE] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE [Clientes] ALTER COLUMN [NOMBRECOMPLETOCLIENTE] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeInventario( )
      {
         string cmdBuffer = "";
         /* Indices for table Inventario */
         cmdBuffer=" ALTER TABLE [Inventario] ALTER COLUMN [DESCRIPCIONPRODUCTO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeEstado_producto( )
      {
         string cmdBuffer = "";
         /* Indices for table Estado_producto */
         cmdBuffer=" ALTER TABLE [Estado_producto] ALTER COLUMN [DESCRIPCIONESTADOPRODUCTO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeCategoria_producto( )
      {
         string cmdBuffer = "";
         /* Indices for table Categoria_producto */
         cmdBuffer=" ALTER TABLE [Categoria_producto] ALTER COLUMN [DESCRIPCIONCATEGORIAPRODUCTO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeMarca_producto( )
      {
         string cmdBuffer = "";
         /* Indices for table Marca_producto */
         cmdBuffer=" ALTER TABLE [Marca_producto] ALTER COLUMN [DESCRIPCIONMARCAPRODUCTO] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeProveedores( )
      {
         string cmdBuffer = "";
         /* Indices for table Proveedores */
         cmdBuffer=" ALTER TABLE [Proveedores] ALTER COLUMN [NOMBREPROVEEDOR] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      public void ReorganizeTipo_proveedor( )
      {
         string cmdBuffer = "";
         /* Indices for table Tipo_proveedor */
         cmdBuffer=" ALTER TABLE [Tipo_proveedor] ALTER COLUMN [DESCRIPCIONTIPOPROVEEDOR] nvarchar(255) NOT NULL  "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            EmpleadosCount = P00012_AEmpleadosCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Empleados" ,  EmpleadosCount );
            /* Using cursor P00023 */
            pr_default.execute(1);
            Compra_inventarioCount = P00023_ACompra_inventarioCount[0];
            pr_default.close(1);
            PrintRecordCount ( "Compra_inventario" ,  Compra_inventarioCount );
            /* Using cursor P00034 */
            pr_default.execute(2);
            Ventas_inventarioCount = P00034_AVentas_inventarioCount[0];
            pr_default.close(2);
            PrintRecordCount ( "Ventas_inventario" ,  Ventas_inventarioCount );
            /* Using cursor P00045 */
            pr_default.execute(3);
            Tipo_empleadoCount = P00045_ATipo_empleadoCount[0];
            pr_default.close(3);
            PrintRecordCount ( "Tipo_empleado" ,  Tipo_empleadoCount );
            /* Using cursor P00056 */
            pr_default.execute(4);
            Estado_empleadoCount = P00056_AEstado_empleadoCount[0];
            pr_default.close(4);
            PrintRecordCount ( "Estado_empleado" ,  Estado_empleadoCount );
            /* Using cursor P00067 */
            pr_default.execute(5);
            ClientesCount = P00067_AClientesCount[0];
            pr_default.close(5);
            PrintRecordCount ( "Clientes" ,  ClientesCount );
            /* Using cursor P00078 */
            pr_default.execute(6);
            InventarioCount = P00078_AInventarioCount[0];
            pr_default.close(6);
            PrintRecordCount ( "Inventario" ,  InventarioCount );
            /* Using cursor P00089 */
            pr_default.execute(7);
            Estado_productoCount = P00089_AEstado_productoCount[0];
            pr_default.close(7);
            PrintRecordCount ( "Estado_producto" ,  Estado_productoCount );
            /* Using cursor P000910 */
            pr_default.execute(8);
            Categoria_productoCount = P000910_ACategoria_productoCount[0];
            pr_default.close(8);
            PrintRecordCount ( "Categoria_producto" ,  Categoria_productoCount );
            /* Using cursor P000A11 */
            pr_default.execute(9);
            Marca_productoCount = P000A11_AMarca_productoCount[0];
            pr_default.close(9);
            PrintRecordCount ( "Marca_producto" ,  Marca_productoCount );
            /* Using cursor P000B12 */
            pr_default.execute(10);
            ProveedoresCount = P000B12_AProveedoresCount[0];
            pr_default.close(10);
            PrintRecordCount ( "Proveedores" ,  ProveedoresCount );
            /* Using cursor P000C13 */
            pr_default.execute(11);
            Tipo_proveedorCount = P000C13_ATipo_proveedorCount[0];
            pr_default.close(11);
            PrintRecordCount ( "Tipo_proveedor" ,  Tipo_proveedorCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P000D14 */
            pr_default.execute(12);
            while ( (pr_default.getStatus(12) != 101) )
            {
               sSchemaVar = P000D14_AsSchemaVar[0];
               nsSchemaVar = P000D14_nsSchemaVar[0];
               pr_default.readNext(12);
            }
            pr_default.close(12);
         }
         else
         {
            /* Using cursor P000E15 */
            pr_default.execute(13);
            while ( (pr_default.getStatus(13) != 101) )
            {
               sSchemaVar = P000E15_AsSchemaVar[0];
               nsSchemaVar = P000E15_nsSchemaVar[0];
               pr_default.readNext(13);
            }
            pr_default.close(13);
         }
         return true ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeEmpleados" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "ReorganizeCompra_inventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "ReorganizeVentas_inventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "ReorganizeTipo_empleado" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "ReorganizeEstado_empleado" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "ReorganizeClientes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "ReorganizeInventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "ReorganizeEstado_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "ReorganizeCategoria_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "ReorganizeMarca_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "ReorganizeProveedores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "ReorganizeTipo_proveedor" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Empleados", ""}) );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Compra_inventario", ""}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Ventas_inventario", ""}) );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Tipo_empleado", ""}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Estado_empleado", ""}) );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Clientes", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Inventario", ""}) );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Estado_producto", ""}) );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Categoria_producto", ""}) );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Marca_producto", ""}) );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Proveedores", ""}) );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Tipo_proveedor", ""}) );
      }

      private void SetPrecedenceris( )
      {
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P00012_AEmpleadosCount = new int[1] ;
         P00023_ACompra_inventarioCount = new int[1] ;
         P00034_AVentas_inventarioCount = new int[1] ;
         P00045_ATipo_empleadoCount = new int[1] ;
         P00056_AEstado_empleadoCount = new int[1] ;
         P00067_AClientesCount = new int[1] ;
         P00078_AInventarioCount = new int[1] ;
         P00089_AEstado_productoCount = new int[1] ;
         P000910_ACategoria_productoCount = new int[1] ;
         P000A11_AMarca_productoCount = new int[1] ;
         P000B12_AProveedoresCount = new int[1] ;
         P000C13_ATipo_proveedorCount = new int[1] ;
         sSchemaVar = "";
         nsSchemaVar = false;
         P000D14_AsSchemaVar = new string[] {""} ;
         P000D14_nsSchemaVar = new bool[] {false} ;
         P000E15_AsSchemaVar = new string[] {""} ;
         P000E15_nsSchemaVar = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_AEmpleadosCount
               }
               , new Object[] {
               P00023_ACompra_inventarioCount
               }
               , new Object[] {
               P00034_AVentas_inventarioCount
               }
               , new Object[] {
               P00045_ATipo_empleadoCount
               }
               , new Object[] {
               P00056_AEstado_empleadoCount
               }
               , new Object[] {
               P00067_AClientesCount
               }
               , new Object[] {
               P00078_AInventarioCount
               }
               , new Object[] {
               P00089_AEstado_productoCount
               }
               , new Object[] {
               P000910_ACategoria_productoCount
               }
               , new Object[] {
               P000A11_AMarca_productoCount
               }
               , new Object[] {
               P000B12_AProveedoresCount
               }
               , new Object[] {
               P000C13_ATipo_proveedorCount
               }
               , new Object[] {
               P000D14_AsSchemaVar
               }
               , new Object[] {
               P000E15_AsSchemaVar
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int EmpleadosCount ;
      protected int Compra_inventarioCount ;
      protected int Ventas_inventarioCount ;
      protected int Tipo_empleadoCount ;
      protected int Estado_empleadoCount ;
      protected int ClientesCount ;
      protected int InventarioCount ;
      protected int Estado_productoCount ;
      protected int Categoria_productoCount ;
      protected int Marca_productoCount ;
      protected int ProveedoresCount ;
      protected int Tipo_proveedorCount ;
      protected string scmdbuf ;
      protected string sSchemaVar ;
      protected bool nsSchemaVar ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_AEmpleadosCount ;
      protected int[] P00023_ACompra_inventarioCount ;
      protected int[] P00034_AVentas_inventarioCount ;
      protected int[] P00045_ATipo_empleadoCount ;
      protected int[] P00056_AEstado_empleadoCount ;
      protected int[] P00067_AClientesCount ;
      protected int[] P00078_AInventarioCount ;
      protected int[] P00089_AEstado_productoCount ;
      protected int[] P000910_ACategoria_productoCount ;
      protected int[] P000A11_AMarca_productoCount ;
      protected int[] P000B12_AProveedoresCount ;
      protected int[] P000C13_ATipo_proveedorCount ;
      protected string[] P000D14_AsSchemaVar ;
      protected bool[] P000D14_nsSchemaVar ;
      protected string[] P000E15_AsSchemaVar ;
      protected bool[] P000E15_nsSchemaVar ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          };
          Object[] prmP00056;
          prmP00056 = new Object[] {
          };
          Object[] prmP00067;
          prmP00067 = new Object[] {
          };
          Object[] prmP00078;
          prmP00078 = new Object[] {
          };
          Object[] prmP00089;
          prmP00089 = new Object[] {
          };
          Object[] prmP000910;
          prmP000910 = new Object[] {
          };
          Object[] prmP000A11;
          prmP000A11 = new Object[] {
          };
          Object[] prmP000B12;
          prmP000B12 = new Object[] {
          };
          Object[] prmP000C13;
          prmP000C13 = new Object[] {
          };
          Object[] prmP000D14;
          prmP000D14 = new Object[] {
          };
          Object[] prmP000E15;
          prmP000E15 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM [Empleados] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT COUNT(*) FROM [Compra_inventario] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT COUNT(*) FROM [Ventas_inventario] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT COUNT(*) FROM [Tipo_empleado] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00056", "SELECT COUNT(*) FROM [Estado_empleado] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00056,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00067", "SELECT COUNT(*) FROM [Clientes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00067,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00078", "SELECT COUNT(*) FROM [Inventario] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00078,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00089", "SELECT COUNT(*) FROM [Estado_producto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00089,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000910", "SELECT COUNT(*) FROM [Categoria_producto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000910,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000A11", "SELECT COUNT(*) FROM [Marca_producto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000A11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000B12", "SELECT COUNT(*) FROM [Proveedores] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000B12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000C13", "SELECT COUNT(*) FROM [Tipo_proveedor] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000C13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000D14", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000D14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000E15", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E15,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
       }
    }

 }

}
