﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using Anolis.Packages.Utility;

using Microsoft.Win32;

using P = System.IO.Path;

namespace Anolis.Packages.Operations {
	
	public class ScreensaverExtraOperation : ExtraOperation {
		
		public ScreensaverExtraOperation(Group parent, XmlElement element) :  base(ExtraType.Screensaver, parent, element) {
		}
		
		public ScreensaverExtraOperation(Group parent, String path) :  base(ExtraType.Screensaver, parent, path) {
		}
		
		public override void Execute() {
			
			if( Files.Count == 0 ) return;
			
			// copy all the screensaver files to the system directory; I can't see any other directories the Display panel searches
			
			String destDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System);
			Boolean reg = Package.ExecutionInfo.ExecutionMode == PackageExecutionMode.Regular;
			
			List<String> installedSavers = new List<String>();
			
			String lastSaver    = null;
			String lastSelected = null;
			
			foreach(ExtraFile file in Files) {
				
				String dest;
				
				if( reg ) {
					
					InstallRegular( destDir, file.FileName, out dest );
					
					installedSavers.Add( dest );
					lastSaver = dest;
					if( file.IsSelected ) lastSelected = dest;
					
				} else {
					
					InstallCDImage( file.FileName );
				}
				
				
			}
			
			Backup( Package.ExecutionInfo.BackupGroup, installedSavers );
			
			if( reg ) {
				
				if( lastSelected != null ) {
					
					SetScreensaver( lastSelected );
					
				} else if( lastSaver != null ) {
					
					SetScreensaver( lastSaver );
				}
			}
			
		}
		
		public void Backup(Group backupGroup, List<String> installedSavers) {
			
			if( backupGroup == null ) return;
			
			String keyPath = @"HKEY_CURRENT_USER\Control Panel\Desktop";
			
			MakeRegOp(backupGroup, keyPath, "SCRNSAVE.EXE");
			MakeRegOp(backupGroup, keyPath, "ScreenSaveActive");
			
			if( Package.ExecutionInfo.ApplyToDefault ) {
				
				keyPath = @"HKEY_USERS\.DEFAULT\Control Panel\Desktop";
				
				MakeRegOp(backupGroup, keyPath, "SCRNSAVE.EXE");
				MakeRegOp(backupGroup, keyPath, "ScreenSaveActive");
			}
			
			foreach(String installedSaver in installedSavers) {
				
				FileOperation op = new FileOperation( backupGroup, installedSaver );
				backupGroup.Operations.Add( op );
			}
			
		}
		
		private void InstallRegular(String destDir, String fileName, out String destFilename) {
			
			destFilename = P.Combine( destDir, P.GetFileName( fileName ) );
			
			String moved = PackageUtility.ReplaceFile( destFilename );
			if(moved != null) Package.Log.Add( LogSeverity.Warning, "File renamed: " + destFilename + " -> " + moved );
			
			File.Copy( fileName, destFilename );
		}
		
		private void InstallCDImage(String fileName) {
			
			DirectoryInfo windir = Package.ExecutionInfo.CDImage.OemWindows;
			DirectoryInfo system32 = windir.GetDirectory("system32");
			if( !system32.Exists ) system32.Create();
			
			File.Copy( fileName, P.Combine( system32.FullName, P.GetFileName( fileName ) ) );
			
		}
		
		private void SetScreensaver(String screensaverFilename) {
			
			// if the saver is located under system32 you don't need the full path, but I'll include it anyway
			
			String eightThreeFileName = PackageUtility.GetShortPath( screensaverFilename );
			
			RegistryKey cu = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
			cu.SetValue("ScreenSaveActive", "1"               , RegistryValueKind.String);
			cu.SetValue("SCRNSAVE.EXE"    , eightThreeFileName, RegistryValueKind.String);
			cu.Close();
			
			if( Package.ExecutionInfo.ApplyToDefault ) {
				
				RegistryKey du = Registry.Users.OpenSubKey(".DEFAULT").OpenSubKey(@"Control Panel\Desktop", true);
				du.SetValue("ScreenSaveActive", "1"               , RegistryValueKind.String);
				du.SetValue("SCRNSAVE.EXE"    , eightThreeFileName, RegistryValueKind.String);
				du.Close();
			}
			
		}
		
	}
}
