// Decompiled with JetBrains decompiler
// Type: CodeEditor.OnOffButton
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System.Drawing;
using System.Windows.Forms;

namespace CodeEditor
{
  internal class OnOffButton
  {
    public Rectangle m_Position;
    public bool m_Pushed;
    public bool m_BeingPushed;
    private Ref<bool> m_Value;

    public void Initialize(Ref<bool> Value, int X, int Y)
    {
      this.m_Value = Value;
      this.m_Position = new Rectangle(X, Y, 44, 34);
    }

    public void print(PaintEventArgs e, Bitmap ButtonOff, Bitmap ButtonOn)
    {
      bool flag = this.m_Value.Value;
      Rectangle position = this.m_Position;
      position.Inflate(-1, -1);
      if (this.m_Pushed)
      {
        e.Graphics.DrawImage((Image) BitmapList.Grayer, this.m_Position);
        e.Graphics.DrawImage(flag ? (Image) ButtonOn : (Image) ButtonOff, position);
      }
      else
        e.Graphics.DrawImage(flag ? (Image) ButtonOn : (Image) ButtonOff, this.m_Position);
    }

    public bool OnMouseDown(MouseEventArgs e)
    {
      if (!this.m_Position.Contains(e.Location))
        return false;
      this.m_Value.Value = !this.m_Value.Value;
      this.m_Pushed = true;
      this.m_BeingPushed = true;
      return true;
    }

    public bool OnMouseMove(MouseEventArgs e)
    {
      return this.m_Position.Contains(e.Location);
    }
  }
}
