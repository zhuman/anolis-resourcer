﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Anolis.Core.Data;

using Cult = System.Globalization.CultureInfo;

namespace Anolis.Core {
	
	public sealed partial class ResourceLang {
		
		public UInt16 LanguageId { get; private set; }
		
		public ResourceName Name { get; private set; }
		
		private ResourceData _data;
		private ResourceData _dataOld;
		
		////////////////////////////////
		
		/// <summary>Constructs a ResourceLang with the ResourceData already loaded. Used when adding resources to a ResourceSource rather than loading them from a ResourceSource to begin with</summary>
		internal ResourceLang(UInt16 languageId, ResourceName name, ResourceData data) {
			
			LanguageId = languageId;
			Name       = name;
			_data      = data;
			
			if(data != null) data.Lang = this;
		}
		
		internal ResourceLang(UInt16 languageId, ResourceName name) : this(languageId, name, null) {
		}
		
		public override String ToString() {
			return LanguageId.ToString(Cult.InvariantCulture);
		}
		
#region ResourceData Operations
		
		/// <summary>Lazy-loads the ResourceData associated with this ResourceLang from the ResourceSource if the resource data is not already loaded.</summary>
		public ResourceData Data {
			get {
				
				if(_data == null) {
					
					_data = _dataOld = this.Name.Type.Source.GetResourceData(this);
					
				}
				
				return _data;
			}
		}
		
		/// <summary>Indicates if .Data has been loaded (or rather, is not null) already. Useful for consumer optimisation.</summary>
		public Boolean DataIsLoaded { get { return _data != null; } }
		
		public void SwapData(ResourceData data) {
			
			if(data == null) throw new ArgumentNullException("data");
			
			Action = ResourceDataAction.Update;
			
			data.Lang = this;
			
			// it might be an idea to dispose of _data before it's reassigned, but there's no way of finding its reference count
			
			_data = data;
			
		}
		
		public void CastData(ResourceDataFactory factory) {
			
			if(factory == null) throw new ArgumentNullException("factory");
			
			ResourceData d = factory.FromResource(this, Data.RawData);
			
			if( d == null ) throw new ResourceDataException("Could not cast ResourceData to " + factory.Name);
			
			_data = d;
		}
		
		public ResourceDataAction Action { get; internal set; }
		
		internal void Rollback() {
			
			_data = _dataOld;
		}
		
		private String _resourcePath;
		
		public String ResourcePath {
			get {
				if( _resourcePath == null ) {
					
					_resourcePath = String.Empty;
					
					if(this.Name.Type.Identifier.KnownType == Win32ResourceType.Custom) {
						
						_resourcePath += this.Name.Type.Identifier.StringId;
						
					} else {
						
						_resourcePath += this.Name.Type.Identifier.IntegerId.Value.ToString(Cult.InvariantCulture);
					}
					
					_resourcePath += '\\' + this.Name.Identifier.FriendlyName;
					
					_resourcePath += '\\' + this.LanguageId.ToString(Cult.InvariantCulture);
					
				}
				return _resourcePath;
			}
		}
		
#endregion
		
	}
	
	public class ResourceLangCollection : ReadOnlyCollection<ResourceLang> {
		internal ResourceLangCollection(List<ResourceLang> list) : base(list) {}
	}
	
}
