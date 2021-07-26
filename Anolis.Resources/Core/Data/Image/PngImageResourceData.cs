﻿using System;
using System.Drawing;

namespace Anolis.Core.Data {
	
	public class PngImageResourceDataFactory : ResourceDataFactory {
		
		public override Compatibility HandlesType(ResourceTypeIdentifier typeId) {
			
			if(typeId.KnownType == Win32ResourceType.Unknown) return Compatibility.Maybe;
			if(typeId.KnownType == Win32ResourceType.Html)    return Compatibility.Maybe;
			if(typeId.KnownType != Win32ResourceType.Custom)  return Compatibility.No;
			
			if( typeId.StringId.IndexOf("PNG", StringComparison.OrdinalIgnoreCase) > -1 ) return Compatibility.Yes;
			
			return Compatibility.Maybe;
		}
		
		public override Compatibility HandlesExtension(string fileNameExtension) {
			if( IsExtension( fileNameExtension, "PNG" ) ) return Compatibility.Yes;
			return Compatibility.No;
		}
		
		public override String OpenFileFilter {
			get { return CreateFileFilter("PngImage", "PNG"); }
		}
		
		public override ResourceData FromResource(ResourceLang lang, byte[] data) {
			
			PngImageResourceData rd;
			if( PngImageResourceData.TryCreate(lang, data, out rd) ) return rd;
			
			return null;
			
		}
		
		public override ResourceData FromFileToAdd(System.IO.Stream stream, String extension, UInt16 langId, ResourceSource currentSource) {
			return FromFile(stream, extension);
		}
		
		public override ResourceData FromFileToUpdate(System.IO.Stream stream, string extension, ResourceLang currentLang) {
			return FromFile(stream, extension);
		}
		
		public override string Name {
			get { return "PNG Image"; }
		}
		
		private ResourceData FromFile(System.IO.Stream stream, String extension) {
			Byte[] data = GetAllBytesFromStream(stream);
			return FromResource(null, data);
		}
	}
	
	public sealed class PngImageResourceData : ImageResourceData {
		
		private PngImageResourceData(Image image, ResourceLang lang, Byte[] rawData) : base(lang, rawData) {
			
			_image = image;
		}
		
		public static Boolean TryCreate(ResourceLang lang, Byte[] data, out PngImageResourceData typed) {
			
			typed = null;
			
			if(!HasPngSignature(data)) return false;
			
			Image image;
			
			if(!TryCreateImage(data, out image)) return false;
			
			typed = new PngImageResourceData(image, lang, data);
			
			return true;
			
		}
		
		public static Boolean HasPngSignature(Byte[] data) {
			
			if(data.Length < 8) return false;
			
			// PNG Signature:
			// 89 50 4E 47 0D 0A 1A 0A
			
			return
				data[0] == 0x89 && // 1000 1001
				data[1] == 0x50 && // 'P'
				data[2] == 0x4E && // 'N'
				data[3] == 0x47 && // 'G'
				data[4] == 0x0D && // \CR
				data[5] == 0x0A && // \LF
				data[6] == 0x1A && // \EOF
				data[7] == 0x0A;   // \LF
			
		}
		
		protected override void SaveAs(System.IO.Stream stream, String extension) {
			
			if(extension == "png") {
				
				stream.Write( this.RawData, 0, RawData.Length );
				
			} else {
				
				base.ConvertAndSaveImageAs(stream, extension);
				
			}
			
		}
		
		protected override String[] SupportedFilters {
			get { return new String[] {
				"PNG Image (*.png)|*.png",
				"Convert to Bitmap (*.bmp)|*.bmp",
			}; }
		}
		
		protected override ResourceTypeIdentifier GetRecommendedTypeId() {
			return new ResourceTypeIdentifier("PNG");
		}
		
		private Image _image;
		
		public override Image Image {
			get { return _image; }
		}
		
	}
}