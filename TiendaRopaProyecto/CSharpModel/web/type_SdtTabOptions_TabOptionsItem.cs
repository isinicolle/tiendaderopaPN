/*
				   File: type_SdtTabOptions_TabOptionsItem
			Description: TabOptions
				 Author: Nemo 🐠 for C# version 17.0.5.152925
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="TabOptionsItem")]
	[XmlType(TypeName="TabOptionsItem" , Namespace="TiendaRopaProyecto" )]
	[Serializable]
	public class SdtTabOptions_TabOptionsItem : GxUserType
	{
		public SdtTabOptions_TabOptionsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtTabOptions_TabOptionsItem_Code = "";

			gxTv_SdtTabOptions_TabOptionsItem_Description = "";

			gxTv_SdtTabOptions_TabOptionsItem_Link = "";

			gxTv_SdtTabOptions_TabOptionsItem_Webcomponent = "";

		}

		public SdtTabOptions_TabOptionsItem(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Link", gxTpr_Link, false);


			AddObjectProperty("WebComponent", gxTpr_Webcomponent, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public string gxTpr_Code
		{
			get { 
				return gxTv_SdtTabOptions_TabOptionsItem_Code; 
			}
			set { 
				gxTv_SdtTabOptions_TabOptionsItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public string gxTpr_Description
		{
			get { 
				return gxTv_SdtTabOptions_TabOptionsItem_Description; 
			}
			set { 
				gxTv_SdtTabOptions_TabOptionsItem_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public string gxTpr_Link
		{
			get { 
				return gxTv_SdtTabOptions_TabOptionsItem_Link; 
			}
			set { 
				gxTv_SdtTabOptions_TabOptionsItem_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="WebComponent")]
		[XmlElement(ElementName="WebComponent")]
		public string gxTpr_Webcomponent
		{
			get { 
				return gxTv_SdtTabOptions_TabOptionsItem_Webcomponent; 
			}
			set { 
				gxTv_SdtTabOptions_TabOptionsItem_Webcomponent = value;
				SetDirty("Webcomponent");
			}
		}




		public override bool ShouldSerializeSdtJson()
		{
		 
		  return true; 
		}

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtTabOptions_TabOptionsItem_Code = "";
			gxTv_SdtTabOptions_TabOptionsItem_Description = "";
			gxTv_SdtTabOptions_TabOptionsItem_Link = "";
			gxTv_SdtTabOptions_TabOptionsItem_Webcomponent = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtTabOptions_TabOptionsItem_Code;
		 

		protected string gxTv_SdtTabOptions_TabOptionsItem_Description;
		 

		protected string gxTv_SdtTabOptions_TabOptionsItem_Link;
		 

		protected string gxTv_SdtTabOptions_TabOptionsItem_Webcomponent;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"TabOptionsItem", Namespace="TiendaRopaProyecto")]
	public class SdtTabOptions_TabOptionsItem_RESTInterface : GxGenericCollectionItem<SdtTabOptions_TabOptionsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtTabOptions_TabOptionsItem_RESTInterface( ) : base()
		{	
		}

		public SdtTabOptions_TabOptionsItem_RESTInterface( SdtTabOptions_TabOptionsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Code", Order=0)]
		public  string gxTpr_Code
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Code);

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  string gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="Link", Order=2)]
		public  string gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="WebComponent", Order=3)]
		public  string gxTpr_Webcomponent
		{
			get { 
				return sdt.gxTpr_Webcomponent;

			}
			set { 
				 sdt.gxTpr_Webcomponent = value;
			}
		}


		#endregion

		public SdtTabOptions_TabOptionsItem sdt
		{
			get { 
				return (SdtTabOptions_TabOptionsItem)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtTabOptions_TabOptionsItem() ;
			}
		}
	}
	#endregion
}