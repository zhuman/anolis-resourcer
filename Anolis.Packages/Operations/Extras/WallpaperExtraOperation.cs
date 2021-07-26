﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;

using Anolis.Packages.Native;
using Anolis.Packages.Utility;
using Microsoft.Win32;

using P = System.IO.Path;

namespace Anolis.Packages.Operations {
	
	public class WallpaperExtraOperation : ExtraOperation {
		
		public WallpaperExtraOperation(Group parent, XmlElement element) : base(ExtraType.Wallpaper, parent, element) {
		}
		
		private static readonly String _wallpaperDir = PackageUtility.ResolvePath(@"%windir%\Web\Wallpaper");
		
		public override Boolean SupportsCDImage {
			get { return true; }
		}
		
		public override void Execute() {
			
			if( Files.Count == 0 ) return;
			
			// copy (don't move) the files to C:\Windows\web\Wallpaper
			// if they already exist append a digit methinks
			
			// don't move because you might be installing from a HDD-based package. The files will be deleted when the package completes anyway
			
			String lastWallpaper = null;
			String lastSelectedWp = null;
			
			List<String> installedWallpapers = new List<String>();
			
			Boolean reg = Package.ExecutionInfo.ExecutionMode == PackageExecutionMode.Regular;
			
			foreach(ExtraFile file in Files) {
				
				if( reg ) {
					
					String dest = InstallWallpaperRegular( file.FileName );
					
					installedWallpapers.Add( dest );
					lastWallpaper = dest;
					if( file.IsSelected ) lastSelectedWp = file.FileName;
					
				} else {
					
					InstallWallpaperCDImage( file.FileName );
				}
			}
			
			Backup( Package.ExecutionInfo.BackupGroup, installedWallpapers );
			
			// set the bottommost as the current wallpaper
			// call SystemParametersInfo to set the current wallpaper apparently
			// and then call RedrawWindow to repaint the desktop
			
			if( reg ) {
				
				if( lastSelectedWp != null ) {
					
					SetWallpaper(ref lastSelectedWp);
					
				} else if( lastWallpaper != null ) {
					
					SetWallpaper(ref lastWallpaper);
					
				}
				
			}
			
		}
		
		private void Backup(Group backupGroup, List<String> installedWallpapers) {
			
			if( backupGroup == null ) return;
			
			String keyPath = @"HKEY_CURRENT_USER\Control Panel\Desktop";
			
			MakeRegOp(backupGroup, keyPath, "Wallpaper");
			MakeRegOp(backupGroup, keyPath, "WallpaperStyle");
			
			if( Package.ExecutionInfo.ApplyToDefault ) {
				
				keyPath = @"HKEY_USERS\.DEFAULT\Control Panel\Desktop";
				
				MakeRegOp(backupGroup, keyPath, "Wallpaper");
				MakeRegOp(backupGroup, keyPath, "WallpaperStyle");
				
			}
			
			foreach(String installedWallaper in installedWallpapers) {
				
				FileOperation op = new FileOperation( backupGroup, installedWallaper);
				backupGroup.Operations.Add( op );
			}
			
		}
		
		private String InstallWallpaperRegular(String wallpaperPackageFileName) {
			
			String dest = P.Combine( _wallpaperDir, P.GetFileName( wallpaperPackageFileName ) );
			
			String moved = PackageUtility.ReplaceFile( dest );
			if(moved != null) Package.Log.Add( LogSeverity.Warning, "File renamed: " + dest + " -> " + moved );
			
			File.Copy( wallpaperPackageFileName, dest );
			
			return dest;
		}
		
		private void InstallWallpaperCDImage(String wallpaperPackageFileName) {
			
			DirectoryInfo wallpaperDir = Package.ExecutionInfo.CDImage.OemWindows.GetDirectory(@"Web\Wallpaper");
			if( !wallpaperDir.Exists ) wallpaperDir.Create();
			
			String dest = P.Combine( wallpaperDir.FullName, P.GetFileName( wallpaperPackageFileName ) ); 
			
			String moved = PackageUtility.ReplaceFile( dest );
			if(moved != null) Package.Log.Add( LogSeverity.Warning, "File renamed: " + dest + " -> " + moved );
			
			File.Copy( wallpaperPackageFileName, dest );
			
		}
		
		private void SetWallpaper(ref String wallpaperFilename) {
			
			// it needs to be a bitmap image on Windows XP and earlier
			// but on Vista it can also be a JPEG
			
			using(Bitmap bitmap = Image.FromFile( wallpaperFilename ) as Bitmap) {
				
				if( bitmap == null ) return;
				
				Boolean isBmp = bitmap.RawFormat.Guid == ImageFormat.Bmp.Guid;
				Boolean isJpg = bitmap.RawFormat.Guid == ImageFormat.Jpeg.Guid;
				Boolean isVis = System.Environment.OSVersion.Version.Major >= 6;
				
				if( (!isBmp && !isVis) || (!isBmp && !isJpg && isVis) ) {
					// so it needs to be a bitmap
					
					String name = P.GetFileName( wallpaperFilename );
					while( File.Exists( name + ".bmp" ) ) {
						name += "_";
					}
					
					wallpaperFilename = P.Combine( _wallpaperDir, name + ".bmp" );
					
					bitmap.Save( wallpaperFilename, ImageFormat.Bmp );
					
				}
				
			}
			
			// set the wallpaper
			NativeMethods.SystemParametersInfo( (uint)SpiAction.SetDesktopWallpaper, 0, wallpaperFilename, SpiUpdate.SendWinIniChange | SpiUpdate.UpdateIniFile);
			
			if( Package.ExecutionInfo.ApplyToDefault ) {
				
				// set the .DEFAULT wallpaper for good measure
				RegistryKey logonKey = Registry.Users.OpenSubKey(".DEFAULT").OpenSubKey(@"Control Panel\Desktop", true);
				logonKey.SetValue("Wallpaper"     , wallpaperFilename, RegistryValueKind.String);
				logonKey.SetValue("WallpaperStyle",               "2", RegistryValueKind.String); // 2 = stretch
				logonKey.Close();
			}
			
			// refresh the desktop
			RedrawFlags flags = RedrawFlags.Invalidate | RedrawFlags.Erase | RedrawFlags.AllChildren | RedrawFlags.UpdateNow;
			NativeMethods.RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, flags );
			
		}
		
	}
	
}
