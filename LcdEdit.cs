// Decompiled with JetBrains decompiler
// Type: CodeEditor.LcdEdit
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Timers;
using System.Windows.Forms;

namespace CodeEditor
{
  public class LcdEdit
  {
    public bool InsertionMode = true;
    private string m_DefaultText = " ";
    private char m_PadingChar = ' ';
    private int m_TextFixedSize = 18;
    protected string m_Text;
    public bool HasFocus;
    public int CaretPos;
    private bool m_ShowCaret;
    private System.Timers.Timer m_Timer;
    public Rectangle m_Position;
    private Action<Rectangle> InvalidateFunc;
    private Action<string> TextUpdated;
    private Func<char, bool> ValidateFunc;
    private Func<string, int, char, string> PadString;

    public LcdEdit(
      int TextSize,
      Action<Rectangle> _InvalidateFunc,
      Action<string> _TextUpdated,
      string _defaulttext,
      Func<char, bool> ValidateCharFunc,
      char padding,
      Func<string, int, char, string> _PadString)
    {
      this.PadString = _PadString;
      this.m_PadingChar = padding;
      this.m_TextFixedSize = TextSize;
      this.m_Text = this.PadString(this.m_PadingChar.ToString(), this.m_TextFixedSize, this.m_PadingChar);
      this.m_DefaultText = this.PadString(_defaulttext, this.m_TextFixedSize, this.m_PadingChar);
      this.ValidateFunc = ValidateCharFunc;
      this.InvalidateFunc = _InvalidateFunc;
      this.TextUpdated = _TextUpdated;
    }

    public void SetText(string st)
    {
      this.m_Text = this.PadString(st, this.m_TextFixedSize, this.m_PadingChar).Substring(0, this.m_TextFixedSize);
    }

    public string GetText()
    {
      return this.m_Text;
    }

    public void SetCaretPos(int i)
    {
      int num = i;
      if (num < 0)
        num = 0;
      if (num > this.m_TextFixedSize - 1)
        num = this.m_TextFixedSize - 1;
      this.CaretPos = num;
      this.m_ShowCaret = true;
      this.InvalidateFunc(this.m_Position);
    }

    public void OnKeyDown(Keys k)
    {
      switch (k)
      {
        case Keys.Left:
          this.SetCaretPos(this.CaretPos - 1);
          break;
        case Keys.Right:
          this.SetCaretPos(this.CaretPos + 1);
          break;
        case Keys.Delete:
          string str = "";
          if (this.CaretPos > 0)
            str = this.m_Text.Substring(0, this.CaretPos);
          if (this.CaretPos < this.m_TextFixedSize - 1)
            str += this.m_Text.Substring(this.CaretPos + 1);
          this.m_Text = this.PadString(str, this.m_TextFixedSize, this.m_PadingChar);
          this.SetCaretPos(this.CaretPos);
          break;
      }
    }

    public void OnKeyDown(char c)
    {
      switch (c)
      {
        case '\b':
          if (this.CaretPos <= 0)
            break;
          string str1 = "";
          if (this.CaretPos > 1)
            str1 = this.m_Text.Substring(0, this.CaretPos - 1);
          this.m_Text = this.PadString(str1 + this.m_Text.Substring(this.CaretPos), this.m_TextFixedSize, this.m_PadingChar);
          this.SetCaretPos(this.CaretPos - 1);
          break;
        case '\r':
          this.SetFocus(false);
          break;
        default:
          if (!this.ValidateFunc(c))
            break;
          string str2 = "";
          if (this.CaretPos > 0)
            str2 = this.m_Text.Substring(0, this.CaretPos);
          string str3 = str2 + c.ToString();
          if (this.CaretPos < this.m_TextFixedSize - 1)
            str3 += this.m_Text.Substring(this.CaretPos + (this.InsertionMode ? 0 : 1));
          this.m_Text = this.PadString(str3, this.m_TextFixedSize, this.m_PadingChar).Substring(0, this.m_TextFixedSize);
          this.SetCaretPos(this.CaretPos + 1);
          break;
      }
    }

    public void Initialize(int X, int Y, int W, int H)
    {
      this.m_Position = new Rectangle(X, Y, W, H);
      this.m_Timer = new System.Timers.Timer(250.0);
      this.m_Timer.Elapsed += (ElapsedEventHandler) ((sender, e) => LcdEdit.MyElapsedMethod(sender, e, this));
    }

    public void SetFocus(bool bOnOff)
    {
      this.m_Timer.Enabled = bOnOff;
      this.HasFocus = bOnOff;
      this.m_ShowCaret = false;
      this.InvalidateFunc(this.m_Position);
      if (this.m_Text.Equals("".PadRight(this.m_TextFixedSize, this.m_PadingChar)))
        this.m_Text = this.m_DefaultText;
      this.TextUpdated(this.m_Text);
    }

    private static void MyElapsedMethod(object sender, ElapsedEventArgs e, LcdEdit Reference)
    {
      if (!Reference.m_Timer.Enabled)
        return;
      Reference.InvalidateFunc(Reference.m_Position);
      if (Reference.HasFocus)
        Reference.m_ShowCaret = !Reference.m_ShowCaret;
      else
        Reference.m_Timer.Enabled = false;
    }

    public void print(PaintEventArgs e)
    {
      e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      Font font = new Font(new FontFamily("Consolas"), 18f, FontStyle.Bold, GraphicsUnit.Pixel);
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(250, 47, 52, 48));
      if (this.HasFocus)
        solidBrush = new SolidBrush(Color.FromArgb((int) byte.MaxValue, 0, 0, 0));
      float x1 = (float) this.m_Position.X;
      float y = (float) this.m_Position.Y;
      for (int index = 0; index < this.m_TextFixedSize; ++index)
      {
        e.Graphics.DrawImage((Image) BitmapList.LCD_Back, x1 + 3f, y + 5f);
        x1 += 11f;
      }
      float x2 = (float) this.m_Position.X;
      for (int startIndex = 0; startIndex < this.m_Text.Length; ++startIndex)
      {
        string s1 = this.m_Text.Substring(startIndex, 1);
        if (this.HasFocus && startIndex == this.CaretPos && this.m_ShowCaret)
        {
          string s2 = "_";
          e.Graphics.DrawString(s2, font, (Brush) solidBrush, new PointF(x2, y - 3f));
        }
        else
          e.Graphics.DrawString(s1, font, (Brush) solidBrush, new PointF(x2, y));
        x2 += 11f;
      }
    }

    public bool OnMouseDown(MouseEventArgs e)
    {
      if (!this.m_Position.Contains(e.Location))
        return false;
      int num1 = (e.X - this.m_Position.X) / 11;
      int num2 = num1 > this.m_TextFixedSize - 1 ? this.m_TextFixedSize - 1 : num1;
      this.SetCaretPos(num2 < 0 ? 0 : num2);
      this.SetFocus(true);
      return true;
    }
  }
}
