﻿using System;
using System.IO;
using System.Xml;

using Anolis.Packages.Utility;

using P = System.IO.Path;

namespace Anolis.Packages.Operations {
	
	public class FileOperation : PathOperation {
		
		public FileOperation(Group group, XmlElement element) : base(group, element) {
			
			String opType = element.GetAttribute("operation").ToUpperInvariant();
			switch(opType) {
				case "COPY":
					Operation = FileOperationType.Copy; break;
				case "DELETE":
					Operation = FileOperationType.Delete; break;
				case "REPLACE":
					Operation = FileOperationType.Replace; break;
				default:
					Operation = FileOperationType.None; break;
			}
			
			SpecifiedPath = element.GetAttribute("path");
			ConditionHash = element.GetAttribute("conditionHash");
			SourceFile    = PackageUtility.ResolvePath( element.GetAttribute("src"), Package.RootDirectory.FullName );
		}
		
		public FileOperation(Group parent, String sourcePath, String destPath, FileOperationType operation) : base(parent, destPath) {
			
			SourceFile = sourcePath;
			// Path is set by destPath
			
			Operation = operation;
		}
		
		public FileOperation(Group parent, String pathOfFileToDelete) : base(parent, pathOfFileToDelete) {
			
			Operation = FileOperationType.Delete;
		}
		
		public String SourceFile    { get; set; }
		public String SpecifiedPath { get; set; }
		public String ConditionHash { get; set; }
		
		public FileOperationType Operation { get; private set; }
		
		public override EvaluationResult Evaluate() {
			
			EvaluationResult bse = base.Evaluate();
			if( bse != EvaluationResult.True ) return bse;
			
			if( !String.IsNullOrEmpty( ConditionHash ) && File.Exists( Path ) ) {
				
				String hash = PackageUtility.GetMD5Hash( Path );
				if( !String.Equals( hash, ConditionHash, StringComparison.OrdinalIgnoreCase ) ) {
					
					Package.Log.Add( LogSeverity.Info, "Hash didn't match: " + Path );
					return EvaluationResult.False;
				}
				
			}
			
			return EvaluationResult.True;
		}
		
		public override void Execute() {
			
			if( Package.ExecutionInfo.ExecutionMode == PackageExecutionMode.Regular ) {
				
				ExecuteRegular();
				
			} else {
				
				ExecuteCDImage();
			}
			
		}
		
		private void ExecuteRegular() {
			
			Backup( Package.ExecutionInfo.BackupGroup );
			
			// remember, the Package.Execute method sets AllowProtectedRenames already
			
			switch(Operation) {
				
				case FileOperationType.Delete:
					
					PackageUtility.AddPfroEntry( Path, null );
					
					Package.ExecutionInfo.RequiresRestart = true;
					
					break;
				
				case FileOperationType.Copy:
				case FileOperationType.Replace:
					
					if( Operation == FileOperationType.Replace ) {
					
						if( !File.Exists( Path ) ) return;
					}
					
					String pendingFileName = Path + ".anofp";
					pendingFileName = PackageUtility.GetUnusedFileName( pendingFileName );
					File.Copy( SourceFile, pendingFileName, true );
					
					PackageUtility.AddPfroEntry( pendingFileName, Path ); // overwrite the file, this deletes the original methinks
					
					Package.ExecutionInfo.RequiresRestart = true;
					
					break;
					
				case FileOperationType.None:
				default:
					return;
			}
			
		}
		
		private void ExecuteCDImage() {
			
			FileInfo[] files;
			
			switch(Operation) {
				case FileOperationType.Replace:
					
					files = Package.ExecutionInfo.CDImage.GetFiles( Path ); // this only returns files that exist
					foreach(FileInfo file in files) File.Copy( SourceFile, file.FullName, true );
					
					break;
				
				case FileOperationType.Copy:
					
					files = Package.ExecutionInfo.CDImage.GetFiles( Path, true ); // this may include files that don't exist
					foreach(FileInfo file in files) File.Copy( SourceFile, file.FullName, true );
					
					break;
				case FileOperationType.Delete:
					
					files = Package.ExecutionInfo.CDImage.GetFiles( Path );
					foreach(FileInfo file in files) file.Delete();
					
					break;
				
			}
			
		}
		
		private void Backup(Group backupGroup) {
			
			if( backupGroup == null ) return;
			
			// if there exists a file at the destination RIGHT NOW, then back it up
				// and the restore operation will be to copy it from its backed-up location to the current location
			
			// otherwise, during restoration it should delete any file that is currently there (because that file would be the file installed by this operation originally)
			
			if( File.Exists( Path ) ) {
				
				// backup the file
				String backupDir = P.Combine( backupGroup.Package.RootDirectory.FullName, "Files" );
				
				if( !Directory.Exists( backupDir ) ) Directory.CreateDirectory( backupDir );
				
				String backupFn  = P.Combine( backupDir, P.GetFileName( Path ) );
				
				backupFn = PackageUtility.GetUnusedFileName( backupFn );
				
				File.Copy( Path, backupFn );
				
				// make an operation for it
				
				FileOperation op = new FileOperation(backupGroup, backupFn, SpecifiedPath, FileOperationType.Copy);
				
				backupGroup.Operations.Add( op );
				
			} else {
				
				FileOperation del = new FileOperation(backupGroup, SpecifiedPath);
				
				backupGroup.Operations.Add( del );
				
			}
			
		}
		
		public override void Write(XmlElement parent) {
			
			XmlElement element = CreateElement(parent, "file",
				"operation", Operation.ToString(),
				"src"      , SourceFile,
				"path"     , Path,
				"conditionHash", ConditionHash
			);
			
		}
		
		public override String OperationName {
			get { return "File"; }
		}
		
		public override Boolean Merge(Operation operation) {
			
			// TODO check if the Path and Condition is the same
			return false;
		}
	}
	
	public enum FileOperationType {
		None,
		Copy,
		Delete,
		Replace
	}
}
