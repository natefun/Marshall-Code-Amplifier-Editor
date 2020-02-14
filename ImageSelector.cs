// Decompiled with JetBrains decompiler
// Type: CodeEditor.ImageSelector
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System.Drawing;
using System.Windows.Forms;

namespace CodeEditor
{
  internal class ImageSelector
  {
    public int m_TextOffset = 27;
    public int m_FontSize = 18;
    public Bitmap[] m_BitmapArray;
    public string[] m_Names;
    public Rectangle m_Position;
    public int m_Hover;
    private Ref<bool> m_SectionOnOff;
    private Ref<int> m_EditedValue;

    public void Initialize(
      ref Bitmap[] BitmapArray,
      ref string[] NameArray,
      Rectangle _Position,
      Ref<int> _DestValue,
      Ref<bool> _OnOffButton)
    {
      this.m_BitmapArray = BitmapArray;
      this.m_Names = NameArray;
      this.m_EditedValue = _DestValue;
      this.m_Position = _Position;
      this.m_SectionOnOff = _OnOffButton;
    }

    public void print(PaintEventArgs e)
    {
      bool flag = true;
      if (this.m_SectionOnOff != null)
        flag = this.m_SectionOnOff.Value;
      int index = this.m_EditedValue.Value;
      e.Graphics.DrawImage((Image) this.m_BitmapArray[index], this.m_Position);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      Font font = new Font(new FontFamily("Arial"), (float) this.m_FontSize, FontStyle.Bold, GraphicsUnit.Pixel);
      SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(flag ? (int) byte.MaxValue : 155, 0, 0, 0));
      e.Graphics.DrawString(this.m_Names[index], font, (Brush) solidBrush1, new PointF(0.5f * (float) (this.m_Position.Left + this.m_Position.Right), (float) this.m_Position.Bottom - (float) this.m_TextOffset), format);
      SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(flag ? (int) byte.MaxValue : 155, 235, (int) byte.MaxValue, 200));
      e.Graphics.DrawString(this.m_Names[index], font, (Brush) solidBrush2, new PointF((float) (0.5 * (double) (this.m_Position.Left + this.m_Position.Right) - 2.0), (float) ((double) this.m_Position.Bottom - (double) this.m_TextOffset - 2.0)), format);
      if (this.m_Hover != 0)
      {
        Rectangle rect1 = new Rectangle(this.m_Position.X, this.m_Position.Y, this.m_Position.Width / 2, this.m_Position.Height);
        Rectangle rect2 = new Rectangle(this.m_Position.X + this.m_Position.Width / 2, this.m_Position.Y, this.m_Position.Width / 2, this.m_Position.Height);
        if (this.m_Hover == 1)
          e.Graphics.DrawImage((Image) BitmapList.Left_arrow, rect1);
        else
          e.Graphics.DrawImage((Image) BitmapList.Right_arrow, rect2);
      }
      if (flag)
        return;
      e.Graphics.DrawImage((Image) BitmapList.Grayer, this.m_Position);
    }

    public bool OnMouseMove(MouseEventArgs e)
    {
      if (!this.m_SectionOnOff.Value)
        return false;
      int hover = this.m_Hover;
      this.m_Hover = 0;
      if (this.m_Position.Contains(e.Location))
      {
        Rectangle rectangle1 = new Rectangle(this.m_Position.X, this.m_Position.Y, this.m_Position.Width / 2, this.m_Position.Height);
        Rectangle rectangle2 = new Rectangle(this.m_Position.X + this.m_Position.Width / 2, this.m_Position.Y, this.m_Position.Width / 2, this.m_Position.Height);
        this.m_Hover = !rectangle1.Contains(e.Location) ? 2 : 1;
      }
      return this.m_Hover != hover;
    }

    public bool OnMouseDown(MouseEventArgs e)
    {
      if (!this.m_SectionOnOff.Value || !this.m_Position.Contains(e.Location))
        return false;
      Rectangle rectangle = new Rectangle(this.m_Position.X, this.m_Position.Y, this.m_Position.Width / 2, this.m_Position.Height);
      int num1 = this.m_EditedValue.Value;
      int num2;
      if (rectangle.Contains(e.Location))
      {
        num2 = num1 - 1;
        if (num2 < 0)
          num2 = this.m_Names.Length - 1;
      }
      else
      {
        num2 = num1 + 1;
        if (num2 >= this.m_Names.Length)
          num2 = 0;
      }
      this.m_EditedValue.Value = num2;
      return true;
    }
  }
}
