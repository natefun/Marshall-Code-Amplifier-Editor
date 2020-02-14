// Decompiled with JetBrains decompiler
// Type: CodeEditor.Ref`1
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System;

namespace CodeEditor
{
  public sealed class Ref<T>
  {
    private Func<T> getter;
    private Action<T> setter;

    public Ref(Func<T> getter, Action<T> setter)
    {
      this.getter = getter;
      this.setter = setter;
    }

    public T Value
    {
      get
      {
        return this.getter();
      }
      set
      {
        this.setter(value);
      }
    }
  }
}
