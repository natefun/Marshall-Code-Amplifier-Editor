// Decompiled with JetBrains decompiler
// Type: CodeEditor.ButtonControl
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CodeEditor
{
  internal class ButtonControl
  {
    public string m_Name = "";
    public float m_RangeMul = 0.1f;
    public bool m_bFloat = true;
    public int m_FontSize = 20;
    public bool Active = true;
    public float MaxValue = 100f;
    public Rectangle m_Position;
    public Rectangle m_LCD;
    public float m_RangeOffset;
    public int m_TextOffset;
    public static Point m_ClickPos;
    public static float m_DragValueStart;
    public bool EraseIfNotActive;
    public Rectangle EraseRect;
    public float MinValue;
    private Ref<bool> m_SectionOnOff;
    private Ref<float> m_EditedValue;

    public float GetDisplayValue()
    {
      return this.m_EditedValue.Value * this.m_RangeMul + this.m_RangeOffset;
    }

    public void Initialize(
      Ref<float> valuetoedit,
      int X,
      int Y,
      string name,
      Ref<bool> _SectionOnOff)
    {
      this.m_EditedValue = valuetoedit;
      this.m_Name = name;
      this.m_SectionOnOff = _SectionOnOff;
      this.m_LCD = new Rectangle(X - 26, Y + 67, 54, 25);
      this.m_Position = new Rectangle(X - 23, Y - 22, 47, 47);
    }

    public bool OnMouseDown(MouseEventArgs e)
    {
      if (!this.Active || !this.m_SectionOnOff.Value || !this.m_Position.Contains(e.Location))
        return false;
      ButtonControl.m_ClickPos = e.Location;
      ButtonControl.m_DragValueStart = this.m_EditedValue.Value;
      return true;
    }

    public bool OnMouseMove(MouseEventArgs e)
    {
      if (!this.Active || !this.m_SectionOnOff.Value)
        return false;
      float num1 = this.m_EditedValue.Value;
      float num2 = this.MaxValue - this.MinValue;
      float num3 = (float) ((double) (e.X - ButtonControl.m_ClickPos.X) * 0.200000002980232 * (double) num2 * 0.00999999977648258);
      float num4 = (float) ((double) (ButtonControl.m_ClickPos.Y - e.Y) * 0.0299999993294477 * (double) num2 * 0.00999999977648258);
      float num5 = ButtonControl.m_DragValueStart + num3 + num4;
      if ((double) num5 > (double) this.MaxValue)
        num5 = this.MaxValue;
      if ((double) num5 < (double) this.MinValue)
        num5 = this.MinValue;
      this.m_EditedValue.Value = num5;
      return (double) num1 != (double) this.m_EditedValue.Value;
    }

    public void print(PaintEventArgs e)
    {
      if (!this.Active)
      {
        if (!this.EraseIfNotActive)
          return;
        e.Graphics.DrawImage((Image) BitmapList.Eraser, this.EraseRect);
      }
      else
      {
        bool flag = true;
        if (this.m_SectionOnOff != null)
          flag = this.m_SectionOnOff.Value;
        double num1 = (double) this.m_EditedValue.Value;
        Point point = new Point((this.m_Position.Left + this.m_Position.Right) / 2, (this.m_Position.Top + this.m_Position.Bottom) / 2);
        float num2 = (float) (this.m_Position.Right - point.X);
        float num3 = (float) (5.75 - 5.30000019073486 * (((double) this.m_EditedValue.Value - (double) this.MinValue) / ((double) this.MaxValue - (double) this.MinValue)));
        float num4 = num2 * (float) Math.Sin((double) num3);
        float num5 = num2 * (float) Math.Cos((double) num3);
        Point pt1 = new Point((int) ((double) point.X + 0.349999994039536 * (double) num4), (int) ((double) point.Y + 0.349999994039536 * (double) num5));
        Point pt2 = new Point((int) ((double) point.X + (double) num4), (int) ((double) point.Y + (double) num5));
        if (!flag)
          e.Graphics.DrawImage((Image) BitmapList.GrayKnob, new Rectangle(this.m_Position.X - 12, this.m_Position.Y - 13, 70, 74));
        Pen pen = new Pen(Color.FromArgb(flag ? (int) byte.MaxValue : 100, 82, 59, 41), 3f);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.DrawLine(pen, pt1, pt2);
        e.Graphics.SmoothingMode = SmoothingMode.Default;
        Font font1 = new Font(new FontFamily("Arial black"), (float) this.m_FontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        SolidBrush solidBrush1 = new SolidBrush(Color.FromArgb(flag ? (int) byte.MaxValue : 100, 47, 52, 48));
        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        float displayValue = this.GetDisplayValue();
        StringFormat format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        float x = 0.5f * (float) (this.m_LCD.Left + this.m_LCD.Right);
        e.Graphics.DrawString(this.m_bFloat ? displayValue.ToString("0.0") : displayValue.ToString("0"), font1, (Brush) solidBrush1, new PointF(x, (float) this.m_LCD.Top - 1f + (float) this.m_TextOffset), format);
        Font font2 = new Font(new FontFamily("Cooper Black"), 12f, FontStyle.Regular, GraphicsUnit.Pixel);
        SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(flag ? 155 : 55, 0, 0, 0));
        e.Graphics.DrawString(this.m_Name, font2, (Brush) solidBrush2, new PointF(x, (float) this.m_LCD.Top - 27f), format);
      }
    }
  }
}
