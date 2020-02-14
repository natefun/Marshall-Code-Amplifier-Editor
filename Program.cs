// Decompiled with JetBrains decompiler
// Type: CodeEditor.Program
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System;
using System.Windows.Forms;

namespace CodeEditor
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
