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
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "[" + DataBaseName + "]";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
               setupDB = 0;
               if ( ( setupDB == 1 ) || GeneXus.Configuration.Preferences.MustSetupDB( ) )
               {
                  defaultUsers = GXUtil.DefaultWebUser( context);
                  short gxidx;
                  gxidx = 1;
                  while ( gxidx <= defaultUsers.Count )
                  {
                     defaultUser = ((string)defaultUsers.Item(gxidx));
                     try
                     {
                        GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbadduser", new   object[]  {defaultUser, DataBaseName}) , null);
                        cmdBuffer = "CREATE LOGIN " + "[" + defaultUser + "]" + " FROM WINDOWS";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "CREATE USER " + "[" + defaultUser + "]" + " FOR LOGIN " + "[" + defaultUser + "]";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datareader', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datawriter', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     gxidx = (short)(gxidx+1);
                  }
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateVentas_inventarioDetalle_venta( )
      {
         string cmdBuffer = "";
         /* Indices for table Ventas_inventarioDetalle_venta */
         try
         {
            cmdBuffer=" CREATE TABLE [Ventas_inventarioDetalle_venta] ([IDVENTA] decimal( 12) NOT NULL , [IDDETALLEVENTAPRODUCTO] decimal( 12) NOT NULL , [IDPRODUCTO] decimal( 12) NOT NULL , PRIMARY KEY([IDVENTA], [IDDETALLEVENTAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Ventas_inventarioDetalle_venta]") ;
               cmdBuffer=" DROP TABLE [Ventas_inventarioDetalle_venta] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Ventas_inventarioDetalle_venta]") ;
                  cmdBuffer=" DROP VIEW [Ventas_inventarioDetalle_venta] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Ventas_inventarioDetalle_venta]") ;
                     cmdBuffer=" DROP FUNCTION [Ventas_inventarioDetalle_venta] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Ventas_inventarioDetalle_venta] ([IDVENTA] decimal( 12) NOT NULL , [IDDETALLEVENTAPRODUCTO] decimal( 12) NOT NULL , [IDPRODUCTO] decimal( 12) NOT NULL , PRIMARY KEY([IDVENTA], [IDDETALLEVENTAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS_INVENTARIODETALLE_VEN1] ON [Ventas_inventarioDetalle_venta] ([IDPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IVENTAS_INVENTARIODETALLE_VEN1] ON [Ventas_inventarioDetalle_venta] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS_INVENTARIODETALLE_VEN1] ON [Ventas_inventarioDetalle_venta] ([IDPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateVentas_inventario( )
      {
         string cmdBuffer = "";
         /* Indices for table Ventas_inventario */
         try
         {
            cmdBuffer=" CREATE TABLE [Ventas_inventario] ([IDVENTA] decimal( 12) NOT NULL IDENTITY(1,1), [FECHAVENTA] datetime NOT NULL , [DESCRIPCIONVENTA] nvarchar(255) NOT NULL , [IDEMPLEADO] decimal( 12) NOT NULL , [IDCLIENTE] decimal( 12) NOT NULL , [DESCUENTOVENTA] money NOT NULL , PRIMARY KEY([IDVENTA]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Ventas_inventario]") ;
               cmdBuffer=" DROP TABLE [Ventas_inventario] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Ventas_inventario]") ;
                  cmdBuffer=" DROP VIEW [Ventas_inventario] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Ventas_inventario]") ;
                     cmdBuffer=" DROP FUNCTION [Ventas_inventario] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Ventas_inventario] ([IDVENTA] decimal( 12) NOT NULL IDENTITY(1,1), [FECHAVENTA] datetime NOT NULL , [DESCRIPCIONVENTA] nvarchar(255) NOT NULL , [IDEMPLEADO] decimal( 12) NOT NULL , [IDCLIENTE] decimal( 12) NOT NULL , [DESCUENTOVENTA] money NOT NULL , PRIMARY KEY([IDVENTA]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS_INVENTARIO1] ON [Ventas_inventario] ([IDCLIENTE] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IVENTAS_INVENTARIO1] ON [Ventas_inventario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS_INVENTARIO1] ON [Ventas_inventario] ([IDCLIENTE] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS_INVENTARIO2] ON [Ventas_inventario] ([IDEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IVENTAS_INVENTARIO2] ON [Ventas_inventario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENTAS_INVENTARIO2] ON [Ventas_inventario] ([IDEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCompra_inventarioDetalle_compr( )
      {
         string cmdBuffer = "";
         /* Indices for table Compra_inventarioDetalle_compr */
         try
         {
            cmdBuffer=" CREATE TABLE [Compra_inventarioDetalle_compr] ([IDCOMPRA] decimal( 12) NOT NULL , [IDETALLECOMPRAPRODUCTO] decimal( 12) NOT NULL , [IDPRODUCTO] decimal( 12) NOT NULL , PRIMARY KEY([IDCOMPRA], [IDETALLECOMPRAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Compra_inventarioDetalle_compr]") ;
               cmdBuffer=" DROP TABLE [Compra_inventarioDetalle_compr] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Compra_inventarioDetalle_compr]") ;
                  cmdBuffer=" DROP VIEW [Compra_inventarioDetalle_compr] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Compra_inventarioDetalle_compr]") ;
                     cmdBuffer=" DROP FUNCTION [Compra_inventarioDetalle_compr] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Compra_inventarioDetalle_compr] ([IDCOMPRA] decimal( 12) NOT NULL , [IDETALLECOMPRAPRODUCTO] decimal( 12) NOT NULL , [IDPRODUCTO] decimal( 12) NOT NULL , PRIMARY KEY([IDCOMPRA], [IDETALLECOMPRAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOMPRA_INVENTARIODETALLE_COM1] ON [Compra_inventarioDetalle_compr] ([IDPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOMPRA_INVENTARIODETALLE_COM1] ON [Compra_inventarioDetalle_compr] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOMPRA_INVENTARIODETALLE_COM1] ON [Compra_inventarioDetalle_compr] ([IDPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCompra_inventario( )
      {
         string cmdBuffer = "";
         /* Indices for table Compra_inventario */
         try
         {
            cmdBuffer=" CREATE TABLE [Compra_inventario] ([IDCOMPRA] decimal( 12) NOT NULL IDENTITY(1,1), [FECHACOMPRA] datetime NOT NULL , [DESCRIPCIONCOMPRA] nvarchar(255) NOT NULL , [IDPROVEEDOR] decimal( 12) NOT NULL , [IDEMPLEADO] decimal( 12) NOT NULL , PRIMARY KEY([IDCOMPRA]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Compra_inventario]") ;
               cmdBuffer=" DROP TABLE [Compra_inventario] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Compra_inventario]") ;
                  cmdBuffer=" DROP VIEW [Compra_inventario] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Compra_inventario]") ;
                     cmdBuffer=" DROP FUNCTION [Compra_inventario] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Compra_inventario] ([IDCOMPRA] decimal( 12) NOT NULL IDENTITY(1,1), [FECHACOMPRA] datetime NOT NULL , [DESCRIPCIONCOMPRA] nvarchar(255) NOT NULL , [IDPROVEEDOR] decimal( 12) NOT NULL , [IDEMPLEADO] decimal( 12) NOT NULL , PRIMARY KEY([IDCOMPRA]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOMPRA_INVENTARIO1] ON [Compra_inventario] ([IDPROVEEDOR] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOMPRA_INVENTARIO1] ON [Compra_inventario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOMPRA_INVENTARIO1] ON [Compra_inventario] ([IDPROVEEDOR] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOMPRA_INVENTARIO2] ON [Compra_inventario] ([IDEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICOMPRA_INVENTARIO2] ON [Compra_inventario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICOMPRA_INVENTARIO2] ON [Compra_inventario] ([IDEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipo_proveedor( )
      {
         string cmdBuffer = "";
         /* Indices for table Tipo_proveedor */
         try
         {
            cmdBuffer=" CREATE TABLE [Tipo_proveedor] ([IDTIPOPROVEEDOR] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONTIPOPROVEEDOR] nvarchar(255) NOT NULL , PRIMARY KEY([IDTIPOPROVEEDOR]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Tipo_proveedor]") ;
               cmdBuffer=" DROP TABLE [Tipo_proveedor] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Tipo_proveedor]") ;
                  cmdBuffer=" DROP VIEW [Tipo_proveedor] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Tipo_proveedor]") ;
                     cmdBuffer=" DROP FUNCTION [Tipo_proveedor] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Tipo_proveedor] ([IDTIPOPROVEEDOR] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONTIPOPROVEEDOR] nvarchar(255) NOT NULL , PRIMARY KEY([IDTIPOPROVEEDOR]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProveedoresTipo_proveedor( )
      {
         string cmdBuffer = "";
         /* Indices for table ProveedoresTipo_proveedor */
         try
         {
            cmdBuffer=" CREATE TABLE [ProveedoresTipo_proveedor] ([IDPROVEEDOR] decimal( 12) NOT NULL , [IDTIPOPROVEEDOR] decimal( 12) NOT NULL , PRIMARY KEY([IDPROVEEDOR], [IDTIPOPROVEEDOR]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[ProveedoresTipo_proveedor]") ;
               cmdBuffer=" DROP TABLE [ProveedoresTipo_proveedor] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[ProveedoresTipo_proveedor]") ;
                  cmdBuffer=" DROP VIEW [ProveedoresTipo_proveedor] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[ProveedoresTipo_proveedor]") ;
                     cmdBuffer=" DROP FUNCTION [ProveedoresTipo_proveedor] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [ProveedoresTipo_proveedor] ([IDPROVEEDOR] decimal( 12) NOT NULL , [IDTIPOPROVEEDOR] decimal( 12) NOT NULL , PRIMARY KEY([IDPROVEEDOR], [IDTIPOPROVEEDOR]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPROVEEDORESTIPO_PROVEEDOR1] ON [ProveedoresTipo_proveedor] ([IDTIPOPROVEEDOR] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPROVEEDORESTIPO_PROVEEDOR1] ON [ProveedoresTipo_proveedor] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPROVEEDORESTIPO_PROVEEDOR1] ON [ProveedoresTipo_proveedor] ([IDTIPOPROVEEDOR] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProveedores( )
      {
         string cmdBuffer = "";
         /* Indices for table Proveedores */
         try
         {
            cmdBuffer=" CREATE TABLE [Proveedores] ([IDPROVEEDOR] decimal( 12) NOT NULL IDENTITY(1,1), [NOMBREPROVEEDOR] nvarchar(255) NOT NULL , [TELEFONOPROVEEDOR] nchar(20) NOT NULL , [CORREOPROVEEDOR] nvarchar(100) NOT NULL , [DIRECCIONPROVEEDOR] nvarchar(255) NOT NULL , PRIMARY KEY([IDPROVEEDOR]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Proveedores]") ;
               cmdBuffer=" DROP TABLE [Proveedores] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Proveedores]") ;
                  cmdBuffer=" DROP VIEW [Proveedores] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Proveedores]") ;
                     cmdBuffer=" DROP FUNCTION [Proveedores] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Proveedores] ([IDPROVEEDOR] decimal( 12) NOT NULL IDENTITY(1,1), [NOMBREPROVEEDOR] nvarchar(255) NOT NULL , [TELEFONOPROVEEDOR] nchar(20) NOT NULL , [CORREOPROVEEDOR] nvarchar(100) NOT NULL , [DIRECCIONPROVEEDOR] nvarchar(255) NOT NULL , PRIMARY KEY([IDPROVEEDOR]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateMarca_producto( )
      {
         string cmdBuffer = "";
         /* Indices for table Marca_producto */
         try
         {
            cmdBuffer=" CREATE TABLE [Marca_producto] ([IDMARCAPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONMARCAPRODUCTO] nvarchar(255) NOT NULL , PRIMARY KEY([IDMARCAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Marca_producto]") ;
               cmdBuffer=" DROP TABLE [Marca_producto] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Marca_producto]") ;
                  cmdBuffer=" DROP VIEW [Marca_producto] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Marca_producto]") ;
                     cmdBuffer=" DROP FUNCTION [Marca_producto] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Marca_producto] ([IDMARCAPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONMARCAPRODUCTO] nvarchar(255) NOT NULL , PRIMARY KEY([IDMARCAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCategoria_producto( )
      {
         string cmdBuffer = "";
         /* Indices for table Categoria_producto */
         try
         {
            cmdBuffer=" CREATE TABLE [Categoria_producto] ([IDCATEGORIAPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONCATEGORIAPRODUCTO] nvarchar(255) NOT NULL , PRIMARY KEY([IDCATEGORIAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Categoria_producto]") ;
               cmdBuffer=" DROP TABLE [Categoria_producto] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Categoria_producto]") ;
                  cmdBuffer=" DROP VIEW [Categoria_producto] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Categoria_producto]") ;
                     cmdBuffer=" DROP FUNCTION [Categoria_producto] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Categoria_producto] ([IDCATEGORIAPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONCATEGORIAPRODUCTO] nvarchar(255) NOT NULL , PRIMARY KEY([IDCATEGORIAPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEstado_producto( )
      {
         string cmdBuffer = "";
         /* Indices for table Estado_producto */
         try
         {
            cmdBuffer=" CREATE TABLE [Estado_producto] ([IDESTADOPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONESTADOPRODUCTO] nvarchar(255) NOT NULL , PRIMARY KEY([IDESTADOPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Estado_producto]") ;
               cmdBuffer=" DROP TABLE [Estado_producto] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Estado_producto]") ;
                  cmdBuffer=" DROP VIEW [Estado_producto] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Estado_producto]") ;
                     cmdBuffer=" DROP FUNCTION [Estado_producto] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Estado_producto] ([IDESTADOPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONESTADOPRODUCTO] nvarchar(255) NOT NULL , PRIMARY KEY([IDESTADOPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateInventario( )
      {
         string cmdBuffer = "";
         /* Indices for table Inventario */
         try
         {
            cmdBuffer=" CREATE TABLE [Inventario] ([IDPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONPRODUCTO] nvarchar(255) NOT NULL , [CANTIDADPRODUCTO] decimal( 12) NOT NULL , [PRECIOCOMPRAPRODUCTO] money NOT NULL , [PRECIOVENTAPRODUCTO] money NOT NULL , [IDESTADOPRODUCTO] decimal( 12) NOT NULL , [IDCATEGORIAPRODUCTO] decimal( 12) NOT NULL , [IDMARCAPRODUCTO] decimal( 12) NOT NULL , PRIMARY KEY([IDPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Inventario]") ;
               cmdBuffer=" DROP TABLE [Inventario] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Inventario]") ;
                  cmdBuffer=" DROP VIEW [Inventario] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Inventario]") ;
                     cmdBuffer=" DROP FUNCTION [Inventario] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Inventario] ([IDPRODUCTO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONPRODUCTO] nvarchar(255) NOT NULL , [CANTIDADPRODUCTO] decimal( 12) NOT NULL , [PRECIOCOMPRAPRODUCTO] money NOT NULL , [PRECIOVENTAPRODUCTO] money NOT NULL , [IDESTADOPRODUCTO] decimal( 12) NOT NULL , [IDCATEGORIAPRODUCTO] decimal( 12) NOT NULL , [IDMARCAPRODUCTO] decimal( 12) NOT NULL , PRIMARY KEY([IDPRODUCTO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVENTARIO2] ON [Inventario] ([IDESTADOPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINVENTARIO2] ON [Inventario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVENTARIO2] ON [Inventario] ([IDESTADOPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVENTARIO1] ON [Inventario] ([IDCATEGORIAPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINVENTARIO1] ON [Inventario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVENTARIO1] ON [Inventario] ([IDCATEGORIAPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVENTARIO3] ON [Inventario] ([IDMARCAPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINVENTARIO3] ON [Inventario] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVENTARIO3] ON [Inventario] ([IDMARCAPRODUCTO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateClientes( )
      {
         string cmdBuffer = "";
         /* Indices for table Clientes */
         try
         {
            cmdBuffer=" CREATE TABLE [Clientes] ([IDCLIENTE] decimal( 12) NOT NULL IDENTITY(1,1), [NOMBRECOMPLETOCLIENTE] nvarchar(255) NOT NULL , [USUARIOCLIENTE] nvarchar(255) NOT NULL , [CONTRASENACLIENTE] nvarchar(255) NOT NULL , [TELEFONOCLIENTE] nchar(20) NOT NULL , [CORREOCLIENTE] nvarchar(100) NOT NULL , [FECHANACIMIENTOCLIENTE] datetime NOT NULL , [DIRECCIONCLIENTE] nvarchar(255) NOT NULL , [FECHAREGISTROCLIENTE] datetime NOT NULL , [FOTOCLIENTE] VARBINARY(MAX) NOT NULL , [FOTOCLIENTE_GXI] varchar(2048) NULL , PRIMARY KEY([IDCLIENTE]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Clientes]") ;
               cmdBuffer=" DROP TABLE [Clientes] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Clientes]") ;
                  cmdBuffer=" DROP VIEW [Clientes] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Clientes]") ;
                     cmdBuffer=" DROP FUNCTION [Clientes] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Clientes] ([IDCLIENTE] decimal( 12) NOT NULL IDENTITY(1,1), [NOMBRECOMPLETOCLIENTE] nvarchar(255) NOT NULL , [USUARIOCLIENTE] nvarchar(255) NOT NULL , [CONTRASENACLIENTE] nvarchar(255) NOT NULL , [TELEFONOCLIENTE] nchar(20) NOT NULL , [CORREOCLIENTE] nvarchar(100) NOT NULL , [FECHANACIMIENTOCLIENTE] datetime NOT NULL , [DIRECCIONCLIENTE] nvarchar(255) NOT NULL , [FECHAREGISTROCLIENTE] datetime NOT NULL , [FOTOCLIENTE] VARBINARY(MAX) NOT NULL , [FOTOCLIENTE_GXI] varchar(2048) NULL , PRIMARY KEY([IDCLIENTE]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEstado_empleado( )
      {
         string cmdBuffer = "";
         /* Indices for table Estado_empleado */
         try
         {
            cmdBuffer=" CREATE TABLE [Estado_empleado] ([IDESTADOEMPLEADO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONESTADOEMPLEADO] nvarchar(255) NOT NULL , PRIMARY KEY([IDESTADOEMPLEADO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Estado_empleado]") ;
               cmdBuffer=" DROP TABLE [Estado_empleado] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Estado_empleado]") ;
                  cmdBuffer=" DROP VIEW [Estado_empleado] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Estado_empleado]") ;
                     cmdBuffer=" DROP FUNCTION [Estado_empleado] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Estado_empleado] ([IDESTADOEMPLEADO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONESTADOEMPLEADO] nvarchar(255) NOT NULL , PRIMARY KEY([IDESTADOEMPLEADO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipo_empleado( )
      {
         string cmdBuffer = "";
         /* Indices for table Tipo_empleado */
         try
         {
            cmdBuffer=" CREATE TABLE [Tipo_empleado] ([IDTIPOEMPLEADO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONTIPOEMPLEADO] nvarchar(255) NOT NULL , PRIMARY KEY([IDTIPOEMPLEADO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Tipo_empleado]") ;
               cmdBuffer=" DROP TABLE [Tipo_empleado] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Tipo_empleado]") ;
                  cmdBuffer=" DROP VIEW [Tipo_empleado] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Tipo_empleado]") ;
                     cmdBuffer=" DROP FUNCTION [Tipo_empleado] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Tipo_empleado] ([IDTIPOEMPLEADO] decimal( 12) NOT NULL IDENTITY(1,1), [DESCRIPCIONTIPOEMPLEADO] nvarchar(255) NOT NULL , PRIMARY KEY([IDTIPOEMPLEADO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEmpleados( )
      {
         string cmdBuffer = "";
         /* Indices for table Empleados */
         try
         {
            cmdBuffer=" CREATE TABLE [Empleados] ([IDEMPLEADO] decimal( 12) NOT NULL IDENTITY(1,1), [NOMBRECOMPLETOEMPLEADO] nvarchar(255) NOT NULL , [USUARIOEMPLEADO] nvarchar(255) NOT NULL , [CONTRASENAEMPLEADO] nvarchar(255) NOT NULL , [TELEFONOEMPLEADO] nchar(20) NOT NULL , [FECHACONTRATACIONEMPLEADO] datetime NOT NULL , [CORREOEMPLEADO] nvarchar(100) NOT NULL , [DIRECCIONEMPLEADO] nvarchar(255) NOT NULL , [FOTOEMPLEADO] VARBINARY(MAX) NOT NULL , [FOTOEMPLEADO_GXI] varchar(2048) NULL , [IDTIPOEMPLEADO] decimal( 12) NOT NULL , [IDESTADOEMPLEADO] decimal( 12) NOT NULL , PRIMARY KEY([IDEMPLEADO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Empleados]") ;
               cmdBuffer=" DROP TABLE [Empleados] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Empleados]") ;
                  cmdBuffer=" DROP VIEW [Empleados] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Empleados]") ;
                     cmdBuffer=" DROP FUNCTION [Empleados] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Empleados] ([IDEMPLEADO] decimal( 12) NOT NULL IDENTITY(1,1), [NOMBRECOMPLETOEMPLEADO] nvarchar(255) NOT NULL , [USUARIOEMPLEADO] nvarchar(255) NOT NULL , [CONTRASENAEMPLEADO] nvarchar(255) NOT NULL , [TELEFONOEMPLEADO] nchar(20) NOT NULL , [FECHACONTRATACIONEMPLEADO] datetime NOT NULL , [CORREOEMPLEADO] nvarchar(100) NOT NULL , [DIRECCIONEMPLEADO] nvarchar(255) NOT NULL , [FOTOEMPLEADO] VARBINARY(MAX) NOT NULL , [FOTOEMPLEADO_GXI] varchar(2048) NULL , [IDTIPOEMPLEADO] decimal( 12) NOT NULL , [IDESTADOEMPLEADO] decimal( 12) NOT NULL , PRIMARY KEY([IDEMPLEADO]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IEMPLEADOS1] ON [Empleados] ([IDTIPOEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IEMPLEADOS1] ON [Empleados] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IEMPLEADOS1] ON [Empleados] ([IDTIPOEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IEMPLEADOS2] ON [Empleados] ([IDESTADOEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IEMPLEADOS2] ON [Empleados] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IEMPLEADOS2] ON [Empleados] ([IDESTADOEMPLEADO] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmpleadosTipo_empleado( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Empleados] ADD CONSTRAINT [IEMPLEADOS1] FOREIGN KEY ([IDTIPOEMPLEADO]) REFERENCES [Tipo_empleado] ([IDTIPOEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Empleados] DROP CONSTRAINT [IEMPLEADOS1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Empleados] ADD CONSTRAINT [IEMPLEADOS1] FOREIGN KEY ([IDTIPOEMPLEADO]) REFERENCES [Tipo_empleado] ([IDTIPOEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEmpleadosEstado_empleado( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Empleados] ADD CONSTRAINT [IEMPLEADOS2] FOREIGN KEY ([IDESTADOEMPLEADO]) REFERENCES [Estado_empleado] ([IDESTADOEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Empleados] DROP CONSTRAINT [IEMPLEADOS2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Empleados] ADD CONSTRAINT [IEMPLEADOS2] FOREIGN KEY ([IDESTADOEMPLEADO]) REFERENCES [Estado_empleado] ([IDESTADOEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInventarioEstado_producto( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Inventario] ADD CONSTRAINT [IINVENTARIO2] FOREIGN KEY ([IDESTADOPRODUCTO]) REFERENCES [Estado_producto] ([IDESTADOPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Inventario] DROP CONSTRAINT [IINVENTARIO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Inventario] ADD CONSTRAINT [IINVENTARIO2] FOREIGN KEY ([IDESTADOPRODUCTO]) REFERENCES [Estado_producto] ([IDESTADOPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInventarioCategoria_producto( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Inventario] ADD CONSTRAINT [IINVENTARIO1] FOREIGN KEY ([IDCATEGORIAPRODUCTO]) REFERENCES [Categoria_producto] ([IDCATEGORIAPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Inventario] DROP CONSTRAINT [IINVENTARIO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Inventario] ADD CONSTRAINT [IINVENTARIO1] FOREIGN KEY ([IDCATEGORIAPRODUCTO]) REFERENCES [Categoria_producto] ([IDCATEGORIAPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInventarioMarca_producto( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Inventario] ADD CONSTRAINT [IINVENTARIO3] FOREIGN KEY ([IDMARCAPRODUCTO]) REFERENCES [Marca_producto] ([IDMARCAPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Inventario] DROP CONSTRAINT [IINVENTARIO3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Inventario] ADD CONSTRAINT [IINVENTARIO3] FOREIGN KEY ([IDMARCAPRODUCTO]) REFERENCES [Marca_producto] ([IDMARCAPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProveedoresTipo_proveedorProveedores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [ProveedoresTipo_proveedor] ADD CONSTRAINT [IPROVEEDORESTIPO_PROVEEDOR2] FOREIGN KEY ([IDPROVEEDOR]) REFERENCES [Proveedores] ([IDPROVEEDOR]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [ProveedoresTipo_proveedor] DROP CONSTRAINT [IPROVEEDORESTIPO_PROVEEDOR2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [ProveedoresTipo_proveedor] ADD CONSTRAINT [IPROVEEDORESTIPO_PROVEEDOR2] FOREIGN KEY ([IDPROVEEDOR]) REFERENCES [Proveedores] ([IDPROVEEDOR]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProveedoresTipo_proveedorTipo_proveedor( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [ProveedoresTipo_proveedor] ADD CONSTRAINT [IPROVEEDORESTIPO_PROVEEDOR1] FOREIGN KEY ([IDTIPOPROVEEDOR]) REFERENCES [Tipo_proveedor] ([IDTIPOPROVEEDOR]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [ProveedoresTipo_proveedor] DROP CONSTRAINT [IPROVEEDORESTIPO_PROVEEDOR1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [ProveedoresTipo_proveedor] ADD CONSTRAINT [IPROVEEDORESTIPO_PROVEEDOR1] FOREIGN KEY ([IDTIPOPROVEEDOR]) REFERENCES [Tipo_proveedor] ([IDTIPOPROVEEDOR]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICompra_inventarioProveedores( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Compra_inventario] ADD CONSTRAINT [ICOMPRA_INVENTARIO1] FOREIGN KEY ([IDPROVEEDOR]) REFERENCES [Proveedores] ([IDPROVEEDOR]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Compra_inventario] DROP CONSTRAINT [ICOMPRA_INVENTARIO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Compra_inventario] ADD CONSTRAINT [ICOMPRA_INVENTARIO1] FOREIGN KEY ([IDPROVEEDOR]) REFERENCES [Proveedores] ([IDPROVEEDOR]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICompra_inventarioEmpleados( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Compra_inventario] ADD CONSTRAINT [ICOMPRA_INVENTARIO2] FOREIGN KEY ([IDEMPLEADO]) REFERENCES [Empleados] ([IDEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Compra_inventario] DROP CONSTRAINT [ICOMPRA_INVENTARIO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Compra_inventario] ADD CONSTRAINT [ICOMPRA_INVENTARIO2] FOREIGN KEY ([IDEMPLEADO]) REFERENCES [Empleados] ([IDEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICompra_inventarioDetalle_comprCompra_inventario( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Compra_inventarioDetalle_compr] ADD CONSTRAINT [ICOMPRA_INVENTARIODETALLE_COM2] FOREIGN KEY ([IDCOMPRA]) REFERENCES [Compra_inventario] ([IDCOMPRA]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Compra_inventarioDetalle_compr] DROP CONSTRAINT [ICOMPRA_INVENTARIODETALLE_COM2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Compra_inventarioDetalle_compr] ADD CONSTRAINT [ICOMPRA_INVENTARIODETALLE_COM2] FOREIGN KEY ([IDCOMPRA]) REFERENCES [Compra_inventario] ([IDCOMPRA]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICompra_inventarioDetalle_comprInventario( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Compra_inventarioDetalle_compr] ADD CONSTRAINT [ICOMPRA_INVENTARIODETALLE_COM1] FOREIGN KEY ([IDPRODUCTO]) REFERENCES [Inventario] ([IDPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Compra_inventarioDetalle_compr] DROP CONSTRAINT [ICOMPRA_INVENTARIODETALLE_COM1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Compra_inventarioDetalle_compr] ADD CONSTRAINT [ICOMPRA_INVENTARIODETALLE_COM1] FOREIGN KEY ([IDPRODUCTO]) REFERENCES [Inventario] ([IDPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVentas_inventarioEmpleados( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ventas_inventario] ADD CONSTRAINT [IVENTAS_INVENTARIO2] FOREIGN KEY ([IDEMPLEADO]) REFERENCES [Empleados] ([IDEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ventas_inventario] DROP CONSTRAINT [IVENTAS_INVENTARIO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ventas_inventario] ADD CONSTRAINT [IVENTAS_INVENTARIO2] FOREIGN KEY ([IDEMPLEADO]) REFERENCES [Empleados] ([IDEMPLEADO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVentas_inventarioClientes( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ventas_inventario] ADD CONSTRAINT [IVENTAS_INVENTARIO1] FOREIGN KEY ([IDCLIENTE]) REFERENCES [Clientes] ([IDCLIENTE]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ventas_inventario] DROP CONSTRAINT [IVENTAS_INVENTARIO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ventas_inventario] ADD CONSTRAINT [IVENTAS_INVENTARIO1] FOREIGN KEY ([IDCLIENTE]) REFERENCES [Clientes] ([IDCLIENTE]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVentas_inventarioDetalle_ventaVentas_inventario( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ventas_inventarioDetalle_venta] ADD CONSTRAINT [IVENTAS_INVENTARIODETALLE_VEN2] FOREIGN KEY ([IDVENTA]) REFERENCES [Ventas_inventario] ([IDVENTA]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ventas_inventarioDetalle_venta] DROP CONSTRAINT [IVENTAS_INVENTARIODETALLE_VEN2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ventas_inventarioDetalle_venta] ADD CONSTRAINT [IVENTAS_INVENTARIODETALLE_VEN2] FOREIGN KEY ([IDVENTA]) REFERENCES [Ventas_inventario] ([IDVENTA]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVentas_inventarioDetalle_ventaInventario( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Ventas_inventarioDetalle_venta] ADD CONSTRAINT [IVENTAS_INVENTARIODETALLE_VEN1] FOREIGN KEY ([IDPRODUCTO]) REFERENCES [Inventario] ([IDPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Ventas_inventarioDetalle_venta] DROP CONSTRAINT [IVENTAS_INVENTARIODETALLE_VEN1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Ventas_inventarioDetalle_venta] ADD CONSTRAINT [IVENTAS_INVENTARIODETALLE_VEN1] FOREIGN KEY ([IDPRODUCTO]) REFERENCES [Inventario] ([IDPRODUCTO]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
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
            /* Using cursor P00012 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               sSchemaVar = P00012_AsSchemaVar[0];
               nsSchemaVar = P00012_nsSchemaVar[0];
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               sSchemaVar = P00023_AsSchemaVar[0];
               nsSchemaVar = P00023_nsSchemaVar[0];
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( tableexist("Ventas_inventarioDetalle_venta",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Ventas_inventarioDetalle_venta"}) ) ;
            return false ;
         }
         if ( tableexist("Ventas_inventario",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Ventas_inventario"}) ) ;
            return false ;
         }
         if ( tableexist("Compra_inventarioDetalle_compr",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Compra_inventarioDetalle_compr"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            tablename = P00034_Atablename[0];
            ntablename = P00034_ntablename[0];
            schemaname = P00034_Aschemaname[0];
            nschemaname = P00034_nschemaname[0];
            result = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateVentas_inventarioDetalle_venta" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateVentas_inventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateCompra_inventarioDetalle_compr" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateCompra_inventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateTipo_proveedor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateProveedoresTipo_proveedor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateProveedores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateMarca_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateCategoria_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateEstado_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreateInventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "CreateClientes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "CreateEstado_empleado" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "CreateTipo_empleado" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "CreateEmpleados" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "RIEmpleadosTipo_empleado" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "RIEmpleadosEstado_empleado" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "RIInventarioEstado_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "RIInventarioCategoria_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "RIInventarioMarca_producto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "RIProveedoresTipo_proveedorProveedores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "RIProveedoresTipo_proveedorTipo_proveedor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "RICompra_inventarioProveedores" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "RICompra_inventarioEmpleados" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 25 ,  "RICompra_inventarioDetalle_comprCompra_inventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 26 ,  "RICompra_inventarioDetalle_comprInventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 27 ,  "RIVentas_inventarioEmpleados" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 28 ,  "RIVentas_inventarioClientes" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 29 ,  "RIVentas_inventarioDetalle_ventaVentas_inventario" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 30 ,  "RIVentas_inventarioDetalle_ventaInventario" , new Object[]{ });
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
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Ventas_inventarioDetalle_venta", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateVentas_inventarioDetalle_venta" ,  "CreateVentas_inventario" );
         ReorgExecute.RegisterPrecedence( "CreateVentas_inventarioDetalle_venta" ,  "CreateInventario" );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Ventas_inventario", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateVentas_inventario" ,  "CreateEmpleados" );
         ReorgExecute.RegisterPrecedence( "CreateVentas_inventario" ,  "CreateClientes" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Compra_inventarioDetalle_compr", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCompra_inventarioDetalle_compr" ,  "CreateCompra_inventario" );
         ReorgExecute.RegisterPrecedence( "CreateCompra_inventarioDetalle_compr" ,  "CreateInventario" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Compra_inventario", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCompra_inventario" ,  "CreateProveedores" );
         ReorgExecute.RegisterPrecedence( "CreateCompra_inventario" ,  "CreateEmpleados" );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Tipo_proveedor", ""}) );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"ProveedoresTipo_proveedor", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateProveedoresTipo_proveedor" ,  "CreateProveedores" );
         ReorgExecute.RegisterPrecedence( "CreateProveedoresTipo_proveedor" ,  "CreateTipo_proveedor" );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Proveedores", ""}) );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Marca_producto", ""}) );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Categoria_producto", ""}) );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Estado_producto", ""}) );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Inventario", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateInventario" ,  "CreateEstado_producto" );
         ReorgExecute.RegisterPrecedence( "CreateInventario" ,  "CreateCategoria_producto" );
         ReorgExecute.RegisterPrecedence( "CreateInventario" ,  "CreateMarca_producto" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Clientes", ""}) );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Estado_empleado", ""}) );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Tipo_empleado", ""}) );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Empleados", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEmpleados" ,  "CreateTipo_empleado" );
         ReorgExecute.RegisterPrecedence( "CreateEmpleados" ,  "CreateEstado_empleado" );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IEMPLEADOS1]"}) );
         ReorgExecute.RegisterPrecedence( "RIEmpleadosTipo_empleado" ,  "CreateEmpleados" );
         ReorgExecute.RegisterPrecedence( "RIEmpleadosTipo_empleado" ,  "CreateTipo_empleado" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IEMPLEADOS2]"}) );
         ReorgExecute.RegisterPrecedence( "RIEmpleadosEstado_empleado" ,  "CreateEmpleados" );
         ReorgExecute.RegisterPrecedence( "RIEmpleadosEstado_empleado" ,  "CreateEstado_empleado" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVENTARIO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIInventarioEstado_producto" ,  "CreateInventario" );
         ReorgExecute.RegisterPrecedence( "RIInventarioEstado_producto" ,  "CreateEstado_producto" );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVENTARIO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIInventarioCategoria_producto" ,  "CreateInventario" );
         ReorgExecute.RegisterPrecedence( "RIInventarioCategoria_producto" ,  "CreateCategoria_producto" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVENTARIO3]"}) );
         ReorgExecute.RegisterPrecedence( "RIInventarioMarca_producto" ,  "CreateInventario" );
         ReorgExecute.RegisterPrecedence( "RIInventarioMarca_producto" ,  "CreateMarca_producto" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPROVEEDORESTIPO_PROVEEDOR2]"}) );
         ReorgExecute.RegisterPrecedence( "RIProveedoresTipo_proveedorProveedores" ,  "CreateProveedoresTipo_proveedor" );
         ReorgExecute.RegisterPrecedence( "RIProveedoresTipo_proveedorProveedores" ,  "CreateProveedores" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPROVEEDORESTIPO_PROVEEDOR1]"}) );
         ReorgExecute.RegisterPrecedence( "RIProveedoresTipo_proveedorTipo_proveedor" ,  "CreateProveedoresTipo_proveedor" );
         ReorgExecute.RegisterPrecedence( "RIProveedoresTipo_proveedorTipo_proveedor" ,  "CreateTipo_proveedor" );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOMPRA_INVENTARIO1]"}) );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioProveedores" ,  "CreateCompra_inventario" );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioProveedores" ,  "CreateProveedores" );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOMPRA_INVENTARIO2]"}) );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioEmpleados" ,  "CreateCompra_inventario" );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioEmpleados" ,  "CreateEmpleados" );
         GXReorganization.SetMsg( 25 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOMPRA_INVENTARIODETALLE_COM2]"}) );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioDetalle_comprCompra_inventario" ,  "CreateCompra_inventarioDetalle_compr" );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioDetalle_comprCompra_inventario" ,  "CreateCompra_inventario" );
         GXReorganization.SetMsg( 26 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICOMPRA_INVENTARIODETALLE_COM1]"}) );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioDetalle_comprInventario" ,  "CreateCompra_inventarioDetalle_compr" );
         ReorgExecute.RegisterPrecedence( "RICompra_inventarioDetalle_comprInventario" ,  "CreateInventario" );
         GXReorganization.SetMsg( 27 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVENTAS_INVENTARIO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioEmpleados" ,  "CreateVentas_inventario" );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioEmpleados" ,  "CreateEmpleados" );
         GXReorganization.SetMsg( 28 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVENTAS_INVENTARIO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioClientes" ,  "CreateVentas_inventario" );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioClientes" ,  "CreateClientes" );
         GXReorganization.SetMsg( 29 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVENTAS_INVENTARIODETALLE_VEN2]"}) );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioDetalle_ventaVentas_inventario" ,  "CreateVentas_inventarioDetalle_venta" );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioDetalle_ventaVentas_inventario" ,  "CreateVentas_inventario" );
         GXReorganization.SetMsg( 30 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVENTAS_INVENTARIODETALLE_VEN1]"}) );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioDetalle_ventaInventario" ,  "CreateVentas_inventarioDetalle_venta" );
         ReorgExecute.RegisterPrecedence( "RIVentas_inventarioDetalle_ventaInventario" ,  "CreateInventario" );
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

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public void DropTableConstraints( string sTableName )
      {
         string cmdBuffer;
         /* Using cursor P00045 */
         pr_default.execute(3, new Object[] {sTableName});
         while ( (pr_default.getStatus(3) != 101) )
         {
            constid = P00045_Aconstid[0];
            nconstid = P00045_nconstid[0];
            fkeyid = P00045_Afkeyid[0];
            nfkeyid = P00045_nfkeyid[0];
            rkeyid = P00045_Arkeyid[0];
            nrkeyid = P00045_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(3);
         }
         pr_default.close(3);
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
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         defaultUsers = new GeneXus.Utils.GxStringCollection();
         defaultUser = "";
         sSchemaVar = "";
         nsSchemaVar = false;
         scmdbuf = "";
         P00012_AsSchemaVar = new string[] {""} ;
         P00012_nsSchemaVar = new bool[] {false} ;
         P00023_AsSchemaVar = new string[] {""} ;
         P00023_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00034_Atablename = new string[] {""} ;
         P00034_ntablename = new bool[] {false} ;
         P00034_Aschemaname = new string[] {""} ;
         P00034_nschemaname = new bool[] {false} ;
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00045_Aconstid = new string[] {""} ;
         P00045_nconstid = new bool[] {false} ;
         P00045_Afkeyid = new string[] {""} ;
         P00045_nfkeyid = new bool[] {false} ;
         P00045_Arkeyid = new int[1] ;
         P00045_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_AsSchemaVar
               }
               , new Object[] {
               P00023_AsSchemaVar
               }
               , new Object[] {
               P00034_Atablename, P00034_Aschemaname
               }
               , new Object[] {
               P00045_Aconstid, P00045_Afkeyid, P00045_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected short setupDB ;
      protected int rkeyid ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string defaultUser ;
      protected string sSchemaVar ;
      protected string scmdbuf ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected bool nsSchemaVar ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected string tablename ;
      protected string schemaname ;
      protected string constid ;
      protected string fkeyid ;
      protected GeneXus.Utils.GxStringCollection defaultUsers ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_AsSchemaVar ;
      protected bool[] P00012_nsSchemaVar ;
      protected string[] P00023_AsSchemaVar ;
      protected bool[] P00023_nsSchemaVar ;
      protected string[] P00034_Atablename ;
      protected bool[] P00034_ntablename ;
      protected string[] P00034_Aschemaname ;
      protected bool[] P00034_nschemaname ;
      protected string[] P00045_Aconstid ;
      protected bool[] P00045_nconstid ;
      protected string[] P00045_Afkeyid ;
      protected bool[] P00045_nfkeyid ;
      protected int[] P00045_Arkeyid ;
      protected bool[] P00045_nrkeyid ;
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
          new ParDef("@sTableName",GXType.Char,255,0) ,
          new ParDef("@sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT TABLE_NAME, TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_NAME = @sTableName) AND (TABLE_SCHEMA = @sMySchemaName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), referenced_object_id FROM sys.foreign_keys WHERE referenced_object_id = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
