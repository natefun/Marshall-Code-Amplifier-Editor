// Decompiled with JetBrains decompiler
// Type: CodeEditor.Logger
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System;
using System.IO;

namespace CodeEditor
{
  internal class Logger
  {
    public static string LogFileName;

    public static void CreateLogSpace()
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CodePatchEditor");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      Logger.LogFileName = path + "\\CodeEditor.log";
      File.CreateText(Logger.LogFileName).Close();
    }

    public static void Log(string logMessage)
    {
      StreamWriter streamWriter = File.AppendText(Logger.LogFileName);
      streamWriter.Write(logMessage);
      streamWriter.WriteLine("");
      streamWriter.Close();
    }

    public static void Log(byte[] msg)
    {
      StreamWriter streamWriter = File.AppendText(Logger.LogFileName);
      foreach (byte num in msg)
      {
        streamWriter.Write(num.ToString("X2"));
        streamWriter.Write(" ");
      }
      streamWriter.WriteLine("");
      streamWriter.Close();
    }
  }
}
