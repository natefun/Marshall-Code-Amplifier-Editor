// Decompiled with JetBrains decompiler
// Type: CodeEditor.TextSelector
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System.Drawing;
using System.Windows.Forms;

namespace CodeEditor
{
  internal class TextSelector
  {
    public int m_Hover = -1;
    public int m_TextOffset = 4;
    public int m_FontSize = 11;
    public bool Active = true;
    public string[] m_Names;
    public Rectangle m_Position;
    public Color BackColor;
    public Color FrontColor;
    private Ref<bool> m_SectionOnOff;
    private Ref<int> m_EditedValue;

    public TextSelector()
    {
      this.FrontColor = Color.FromArgb((int) byte.MaxValue, 227, 190, 140);
      this.BackColor = Color.FromArgb((int) byte.MaxValue, 80, 53, 32);
    }

    public void Initialize(
      ref string[] NameArray,
      Rectangle _Position,
      Ref<int> _DestValue,
      Ref<bool> _OnOff)
    {
      this.m_Names = NameArray;
      this.m_Position = _Position;
      this.m_SectionOnOff = _OnOff;
      this.m_EditedValue = _DestValue;
      int length = this.m_Names.Length;
      int num = this.m_Position.Height / length;
      this.m_Position.Size = new Size(this.m_Position.Width, length * num);
    }

    public Rectangle GetOptionRectangle(int i)
    {
      int height = this.m_Position.Height / this.m_Names.Length;
      return new Rectangle(this.m_Position.Left, this.m_Position.Top + i * height, this.m_Position.Width, height);
    }

    public void print(PaintEventArgs e)
    {
      if (!this.Active)
        return;
      bool flag = true;
      if (this.m_SectionOnOff != null)
        flag = this.m_SectionOnOff.Value;
      int num1 = this.m_EditedValue.Value;
      e.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), this.m_Position);
      int length = this.m_Names.Length;
      int num2 = this.m_Position.Height / length;
      float x = 0.5f * (float) (this.m_Position.Left + this.m_Position.Right);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      Font font = new Font(new FontFamily("Consolas"), (float) this.m_FontSize, FontStyle.Bold, GraphicsUnit.Pixel);
      for (int i = 0; i < length; ++i)
      {
        if (i != 0)
          e.Graphics.DrawLine(new Pen(this.FrontColor), this.m_Position.Left, this.m_Position.Top + i * num2, this.m_Position.Right, this.m_Position.Top + i * num2);
        if (i == num1)
        {
          e.Graphics.FillRectangle((Brush) new SolidBrush(this.FrontColor), this.GetOptionRectangle(i));
          e.Graphics.DrawString(this.m_Names[i], font, (Brush) new SolidBrush(this.BackColor), new PointF(x, (float) this.m_Position.Top + (float) (i * num2) + (float) this.m_TextOffset), format);
        }
        else
          e.Graphics.DrawString(this.m_Names[i], font, (Brush) new SolidBrush(this.FrontColor), new PointF(x, (float) this.m_Position.Top + (float) (i * num2) + (float) this.m_TextOffset), format);
      }
      if (this.m_Hover != -1)
        e.Graphics.FillRectangle((Brush) new SolidBrush(Color.FromArgb(75, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)), this.GetOptionRectangle(this.m_Hover));
      if (flag)
        return;
      Rectangle rect = new Rectangle(this.m_Position.X, this.m_Position.Y, this.m_Position.Width + 1, this.m_Position.Height + 1);
      e.Graphics.DrawImage((Image) BitmapList.Grayer, rect);
    }

    public bool OnMouseMove(MouseEventArgs e)
    {
      if (!this.Active || !this.m_SectionOnOff.Value)
        return false;
      int length = this.m_Names.Length;
      int hover = this.m_Hover;
      this.m_Hover = -1;
      for (int i = 0; i < length; ++i)
      {
        if (this.GetOptionRectangle(i).Contains(e.Location))
          this.m_Hover = i;
      }
      return this.m_Hover != hover;
    }

    public bool OnMouseDown(MouseEventArgs e)
    {
      if (!this.Active || !this.m_SectionOnOff.Value)
        return false;
      int length = this.m_Names.Length;
      int num = this.m_EditedValue.Value;
      if (this.m_Position.Contains(e.Location))
      {
        for (int i = 0; i < length; ++i)
        {
          if (this.GetOptionRectangle(i).Contains(e.Location))
            this.m_EditedValue.Value = i;
        }
        if (num != this.m_EditedValue.Value)
          return true;
      }
      return false;
    }
  }
}
