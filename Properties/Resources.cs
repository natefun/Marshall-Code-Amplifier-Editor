// Decompiled with JetBrains decompiler
// Type: CodeEditor.Properties.Resources
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CodeEditor.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) CodeEditor.Properties.Resources.resourceMan, (object) null))
          CodeEditor.Properties.Resources.resourceMan = new ResourceManager("CodeEditor.Properties.Resources", typeof (CodeEditor.Properties.Resources).Assembly);
        return CodeEditor.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return CodeEditor.Properties.Resources.resourceCulture;
      }
      set
      {
        CodeEditor.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
