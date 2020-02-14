// Decompiled with JetBrains decompiler
// Type: CodeEditor.ToolTip
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System.Drawing;
using System.Windows.Forms;

namespace CodeEditor
{
  public class ToolTip
  {
    private Rectangle ToolTipControlRect;
    private string Tip;
    public bool Active;
    private float Alpha;
    private int ApparitionDelay;

    public void Activate(Rectangle pos, string text)
    {
      if (this.Active && this.ToolTipControlRect.Equals((object) pos))
        return;
      this.Tip = text;
      this.ToolTipControlRect = pos;
      this.Active = true;
      this.Alpha = 0.01f;
      this.ApparitionDelay = 50;
    }

    public void print(PaintEventArgs e)
    {
      if (!this.Active && (double) this.Alpha <= 0.0)
        return;
      if (this.ApparitionDelay > 0)
      {
        --this.ApparitionDelay;
        Form1.CurrentForm1.Invalidate();
      }
      else
      {
        if (!this.Active)
        {
          this.Alpha -= 0.03f;
          if ((double) this.Alpha < 0.0)
            this.Alpha = 0.0f;
        }
        else
        {
          this.Alpha += 0.05f;
          if ((double) this.Alpha > 1.0)
            this.Alpha = 1f;
        }
        Font font = new Font(new FontFamily("Arial"), 12f, FontStyle.Regular, GraphicsUnit.Pixel);
        SizeF sizeF = e.Graphics.MeasureString(this.Tip, font);
        SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb((int) (250.0 * (double) this.Alpha), 0, 0, 0));
        SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb((int) (250.0 * (double) this.Alpha), 217, 206, 189));
        int width = (int) sizeF.Width + 10;
        int height = (int) sizeF.Height + 4;
        Rectangle rect = new Rectangle(this.ToolTipControlRect.Right + 5, this.ToolTipControlRect.Top + (this.ToolTipControlRect.Height - height) / 2, width, height);
        e.Graphics.FillRectangle((Brush) solidBrush2, rect);
        e.Graphics.DrawRectangle(new Pen(Color.FromArgb((int) (200.0 * (double) this.Alpha), 0, 0, 0)), rect);
        e.Graphics.DrawString(this.Tip, font, (Brush) solidBrush1, (float) (rect.X + 5), (float) (rect.Y + 3));
        if ((double) this.Alpha == 1.0)
          return;
        Form1.CurrentForm1.Invalidate();
      }
    }
  }
}
