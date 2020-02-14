// Decompiled with JetBrains decompiler
// Type: CodeEditor.BitmapButton
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System.Drawing;
using System.Windows.Forms;

namespace CodeEditor
{
  public class BitmapButton
  {
    public bool m_Enabled = true;
    public Rectangle m_Position;
    public bool m_Pushed;
    public Bitmap m_Bitmap;
    public bool m_EraseBack;
    public string m_TooltipText;

    public void Initialize(int X, int Y, int W, int H, Bitmap BM)
    {
      this.m_Bitmap = BM;
      this.m_Position = new Rectangle(X, Y, W, H);
      this.m_Pushed = false;
    }

    public void print(PaintEventArgs e)
    {
      this.m_Position.Inflate(2, 2);
      Rectangle position = this.m_Position;
      position.Inflate(-1, -1);
      if (!this.m_Enabled)
      {
        e.Graphics.DrawImage((Image) this.m_Bitmap, this.m_Position);
        e.Graphics.DrawImage((Image) BitmapList.Grayer, this.m_Position);
      }
      else if (this.m_Pushed)
        e.Graphics.DrawImage((Image) this.m_Bitmap, position);
      else
        e.Graphics.DrawImage((Image) this.m_Bitmap, this.m_Position);
    }

    public bool OnMouseDown(MouseEventArgs e)
    {
      return this.m_Enabled && this.m_Position.Contains(e.Location);
    }
  }
}
