// Decompiled with JetBrains decompiler
// Type: CodeEditor.Form1
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CodeEditor
{
  public class Form1 : Form
  {
    public MidiCom m_Midi;
    private ButtonControl[] m_AllKnobs;
    private OnOffButton[] m_OnOffButtons;
    private ImageSelector[] m_ImageSelectors;
    private TextSelector[] m_TextSelectors;
    private BitmapButton[] m_BitmapButtons;
    public int m_DraggingKnobIndex;
    public int m_PushingButton;
    public LcdEdit m_NameLCD;
    public LcdEdit m_PatchNumLCD;
    public static Patch m_CurrentPatch;
    public static Form1 CurrentForm1;
    private static bool MidiEnabled;
    private ToolTip tooltip;
    private IContainer components;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;

    public Form1()
    {
      Logger.CreateLogSpace();
      Logger.Log("Starting Code Editor");
      Form1.CurrentForm1 = this;
      this.InitializeComponent();
      this.tooltip = new ToolTip();
      this.ClientSize = new Size(1264, 728);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.m_DraggingKnobIndex = -1;
      this.m_PushingButton = -1;
      Form1.MidiEnabled = false;
      this.AllowDrop = true;
      this.DragEnter += new DragEventHandler(this.Form1_DragEnter);
      this.DragDrop += new DragEventHandler(this.Form1_DragDrop);
      this.Text = "CODE Patch Editor";
      this.DoubleBuffered = true;
      this.Paint += new PaintEventHandler(this.Form1_Paint);
      Form1.m_CurrentPatch = new Patch();
      this.openFileDialog1.Title = "Browse MCE Files";
      this.openFileDialog1.DefaultExt = "mce";
      this.openFileDialog1.CheckFileExists = true;
      this.openFileDialog1.CheckPathExists = true;
      this.openFileDialog1.Filter = "MCE files (*.mce)|*.mce|All files (*.*)|*.*";
      this.saveFileDialog1.Title = "Save MCE File";
      this.saveFileDialog1.DefaultExt = "mce";
      this.saveFileDialog1.Filter = "MCE files (*.mce)|*.mce|All files (*.*)|*.*";
      this.m_OnOffButtons = new OnOffButton[7];
      for (int index = 0; index < 7; ++index)
        this.m_OnOffButtons[index] = new OnOffButton();
      this.m_AllKnobs = new ButtonControl[23];
      for (int index = 0; index < 23; ++index)
        this.m_AllKnobs[index] = new ButtonControl();
      this.m_BitmapButtons = new BitmapButton[13];
      for (int index = 0; index < 13; ++index)
        this.m_BitmapButtons[index] = new BitmapButton();
      this.m_TextSelectors = new TextSelector[11];
      for (int index = 0; index < 11; ++index)
        this.m_TextSelectors[index] = new TextSelector();
      this.m_ImageSelectors = new ImageSelector[3];
      for (int index = 0; index < 3; ++index)
        this.m_ImageSelectors[index] = new ImageSelector();
      this.m_OnOffButtons[0].Initialize(new Ref<bool>((Func<bool>) (() => Form1.m_CurrentPatch.m_OnOffValues[0]), (Action<bool>) (v => Form1.m_CurrentPatch.m_OnOffValues[0] = v)), 443, 143);
      this.m_OnOffButtons[1].Initialize(new Ref<bool>((Func<bool>) (() => Form1.m_CurrentPatch.m_OnOffValues[1]), (Action<bool>) (v => Form1.m_CurrentPatch.m_OnOffValues[1] = v)), 64, 321);
      this.m_OnOffButtons[2].Initialize(new Ref<bool>((Func<bool>) (() => Form1.m_CurrentPatch.m_OnOffValues[2]), (Action<bool>) (v => Form1.m_CurrentPatch.m_OnOffValues[2] = v)), 65, 502);
      this.m_OnOffButtons[3].Initialize(new Ref<bool>((Func<bool>) (() => Form1.m_CurrentPatch.m_OnOffValues[3]), (Action<bool>) (v => Form1.m_CurrentPatch.m_OnOffValues[3] = v)), 844, 144);
      this.m_OnOffButtons[4].Initialize(new Ref<bool>((Func<bool>) (() => Form1.m_CurrentPatch.m_OnOffValues[4]), (Action<bool>) (v => Form1.m_CurrentPatch.m_OnOffValues[4] = v)), 844, 324);
      this.m_OnOffButtons[5].Initialize(new Ref<bool>((Func<bool>) (() => Form1.m_CurrentPatch.m_OnOffValues[5]), (Action<bool>) (v => Form1.m_CurrentPatch.m_OnOffValues[5] = v)), 840, 517);
      this.m_OnOffButtons[6].Initialize(new Ref<bool>((Func<bool>) (() => Form1.m_CurrentPatch.m_OnOffValues[6]), (Action<bool>) (v => Form1.m_CurrentPatch.m_OnOffValues[6] = v)), 556, 505);
      Ref<bool> ref1 = Form1.m_CurrentPatch.GetRef(Form1.OnOff.PREAMP);
      Ref<bool> ref2 = Form1.m_CurrentPatch.GetRef(Form1.OnOff.PREFX);
      Ref<bool> ref3 = Form1.m_CurrentPatch.GetRef(Form1.OnOff.MOD);
      Ref<bool> ref4 = Form1.m_CurrentPatch.GetRef(Form1.OnOff.DELAY);
      Ref<bool> ref5 = Form1.m_CurrentPatch.GetRef(Form1.OnOff.REV);
      Ref<bool> ref6 = Form1.m_CurrentPatch.GetRef(Form1.OnOff.POWER);
      Ref<bool> _OnOffButton = Form1.m_CurrentPatch.GetRef(Form1.OnOff.CAB);
      this.m_AllKnobs[0].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREAMP_GAIN), 378, 358, "GAIN", ref1);
      this.m_AllKnobs[1].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREAMP_VOLUME), 450, 358, "VOLUME", ref1);
      this.m_AllKnobs[2].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREAMP_THRESHOLD), 540, 358, "THRESHOLD", ref1);
      this.m_AllKnobs[3].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREAMP_BASS), 628, 358, "BASS", ref1);
      this.m_AllKnobs[4].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREAMP_MIDDLE), 700, 358, "MIDDLE", ref1);
      this.m_AllKnobs[5].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREAMP_TREBLE), 772, 358, "TREBLE", ref1);
      this.m_AllKnobs[6].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREFX_PARAM1), 577, 177, "MODE", ref2);
      this.m_AllKnobs[7].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREFX_PARAM2), 644, 177, "DRIVE", ref2);
      this.m_AllKnobs[8].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREFX_PARAM3), 711, 177, "TONE", ref2);
      this.m_AllKnobs[9].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.PREFX_PARAM4), 777, 177, "LEVEL", ref2);
      this.m_AllKnobs[10].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.MOD_SPEED), 1045, 177, "SPEED", ref3);
      this.m_AllKnobs[11].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.MOD_DEPTH), 1112, 177, "DEPTH", ref3);
      this.m_AllKnobs[12].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.MOD_TONE), 1178, 177, "TONE", ref3);
      this.m_AllKnobs[13].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.DEL_TIME), 978, 366, "TIME", ref4);
      this.m_AllKnobs[14].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.DEL_FEEDBACK), 1045, 366, "FEEDBACK", ref4);
      this.m_AllKnobs[15].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.DEL_AGE), 1112, 366, "AGE", ref4);
      this.m_AllKnobs[16].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.DEL_LEVEL), 1178, 366, "LEVEL", ref4);
      this.m_AllKnobs[17].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.REV_DECAY), 977, 558, "DECAY", ref5);
      this.m_AllKnobs[18].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.REV_PREDELAY), 1044, 558, "PRE-DELAY", ref5);
      this.m_AllKnobs[19].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.REV_TONE), 1111, 558, "TONE", ref5);
      this.m_AllKnobs[20].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.REV_LEVEL), 1177, 558, "LEVEL", ref5);
      this.m_AllKnobs[21].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.POWER_PRESENCE), 373, 546, "PRESENCE", ref6);
      this.m_AllKnobs[22].Initialize(Form1.m_CurrentPatch.GetRef(Form1.Knobs.POWER_RESONANCE), 455, 546, "RESONANCE", ref6);
      this.m_AllKnobs[6].EraseIfNotActive = true;
      this.m_AllKnobs[6].EraseRect = new Rectangle(545, 143, 66, 133);
      this.m_AllKnobs[13].m_bFloat = false;
      this.m_AllKnobs[13].m_RangeMul = 1f;
      this.m_AllKnobs[13].MaxValue = 4000f;
      this.m_AllKnobs[13].m_FontSize = 15;
      this.m_AllKnobs[13].m_TextOffset = 3;
      this.m_AllKnobs[15].EraseIfNotActive = true;
      this.m_AllKnobs[15].EraseRect = new Rectangle(1112, 366, 66, 133);
      this.m_AllKnobs[15].EraseIfNotActive = true;
      this.m_AllKnobs[15].EraseRect = new Rectangle(1081, 332, 66, 133);
      this.m_BitmapButtons[0].Initialize(140, 210, 76, 65, BitmapList.Import);
      this.m_BitmapButtons[1].Initialize(217, 210, 76, 65, BitmapList.Export);
      this.m_BitmapButtons[2].Initialize(188, (int) sbyte.MaxValue, 30, 30, BitmapList.Prev);
      this.m_BitmapButtons[3].Initialize(228, (int) sbyte.MaxValue, 30, 30, BitmapList.Next);
      this.m_BitmapButtons[4].Initialize(369, 143, 44, 34, BitmapList.ButtonOff);
      this.m_BitmapButtons[5].Initialize(369, 203, 44, 34, BitmapList.ButtonOff);
      this.m_BitmapButtons[6].Initialize(1180, 30, 25, 25, BitmapList.Help);
      this.m_BitmapButtons[6].m_EraseBack = false;
      this.m_BitmapButtons[7].Initialize(899, 124, 13, 19, BitmapList.ImportSmall);
      this.m_BitmapButtons[8].Initialize(498, 123, 13, 19, BitmapList.ImportSmall);
      this.m_BitmapButtons[9].Initialize(895, 507, 13, 19, BitmapList.ImportSmall);
      this.m_BitmapButtons[10].Initialize(74, 371, 13, 19, BitmapList.ImportSmall);
      this.m_BitmapButtons[11].Initialize(899, 314, 13, 19, BitmapList.ImportSmall);
      this.m_BitmapButtons[12].Initialize(75, 552, 13, 19, BitmapList.ImportSmall);
      this.m_BitmapButtons[0].m_TooltipText = "Imports patch from amplifier from selected patch number";
      this.m_BitmapButtons[1].m_TooltipText = "Exports patch to amplifier to selected patch number";
      this.m_BitmapButtons[2].m_TooltipText = "Previous patch";
      this.m_BitmapButtons[3].m_TooltipText = "Next patch";
      this.m_BitmapButtons[7].m_TooltipText = "Imports MOD settings from saved file";
      this.m_BitmapButtons[8].m_TooltipText = "Imports Pre-FX settings from saved file";
      this.m_BitmapButtons[9].m_TooltipText = "Imports Reverb settings from saved file";
      this.m_BitmapButtons[10].m_TooltipText = "Imports Preamp settings from saved file";
      this.m_BitmapButtons[11].m_TooltipText = "Imports Delay settings from saved file";
      this.m_BitmapButtons[12].m_TooltipText = "Imports Power Amp settings from saved file";
      Bitmap[] BitmapArray1 = new Bitmap[15]
      {
        BitmapList.jtm45,
        BitmapList.dsl,
        BitmapList.american,
        BitmapList.jvm,
        BitmapList.acoustic,
        BitmapList.bluesbreaker,
        BitmapList.plexi,
        BitmapList.american,
        BitmapList.jcm800,
        BitmapList.english,
        BitmapList.jvm,
        BitmapList.dsl,
        BitmapList.american,
        BitmapList.jubilee,
        BitmapList.natural
      };
      string[] NameArray1 = new string[15]
      {
        "Clean JTM45",
        "Clean DSL",
        "Clean American",
        "Clean JVM",
        "Acoustic Simulator",
        "Bluesbreaker",
        "Plexi",
        "Crunch American",
        "JCM800",
        "'50s British",
        "OD JVM",
        "OD DSL",
        "OD American",
        "OD Silver Jubilee",
        "Natural (No FX)"
      };
      this.m_ImageSelectors[0].Initialize(ref BitmapArray1, ref NameArray1, new Rectangle((int) sbyte.MaxValue, 312, 200, 150), Form1.m_CurrentPatch.GetRef(Form1.ImgSelectorList.Preamp), ref1);
      Bitmap[] BitmapArray2 = new Bitmap[8]
      {
        BitmapList.cab_1960,
        BitmapList.cab_1960,
        BitmapList.cab_1960,
        BitmapList.cab_1960,
        BitmapList.cab_1936,
        BitmapList.cab_1936,
        BitmapList.cab_1912,
        BitmapList.cab_1974
      };
      string[] NameArray2 = new string[8]
      {
        "1960",
        "1960V",
        "1960AX",
        "1960HW",
        "1936",
        "1936V",
        "1912",
        "1974CX"
      };
      this.m_ImageSelectors[1].Initialize(ref BitmapArray2, ref NameArray2, new Rectangle(620, 488, 170, 170), Form1.m_CurrentPatch.GetRef(Form1.ImgSelectorList.Cab), _OnOffButton);
      this.m_ImageSelectors[1].m_TextOffset = 60;
      this.m_ImageSelectors[1].m_FontSize = 24;
      Bitmap[] BitmapArray3 = new Bitmap[4]
      {
        BitmapList.pow_jcm,
        BitmapList.pow_30w,
        BitmapList.pow_english,
        BitmapList.pow_american
      };
      string[] NameArray3 = new string[4]
      {
        "Classic 100w",
        "Vintage 30 watts",
        "British Class A",
        "American Class A/B"
      };
      this.m_ImageSelectors[2].Initialize(ref BitmapArray3, ref NameArray3, new Rectangle(121, 498, 175, 140), Form1.m_CurrentPatch.GetRef(Form1.ImgSelectorList.Power), ref6);
      this.m_ImageSelectors[2].m_TextOffset = 30;
      this.m_ImageSelectors[2].m_FontSize = 14;
      string[] NameArray4 = new string[4]
      {
        "Compressor",
        "Distortion",
        "Auto Wah",
        "Pitch Shifter"
      };
      this.m_TextSelectors[0].Initialize(ref NameArray4, new Rectangle(440, 190, 86, 86), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.PreFX), ref2);
      string[] NameArray5 = new string[4]
      {
        "Chorus",
        "Flanger",
        "Phaser",
        "Tremolo"
      };
      this.m_TextSelectors[3].Initialize(ref NameArray5, new Rectangle(840, 190, 86, 86), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.Mod), ref3);
      string[] NameArray6 = new string[4]
      {
        "Studio",
        "Vintage",
        "Multi",
        "Reverse"
      };
      this.m_TextSelectors[8].Initialize(ref NameArray6, new Rectangle(840, 375, 86, 86), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.DelayType), ref4);
      string[] NameArray7 = new string[4]
      {
        "Room",
        "Hall",
        "Spring",
        "Stadium"
      };
      this.m_TextSelectors[9].Initialize(ref NameArray7, new Rectangle(840, 566, 86, 86), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.ReverbType), ref5);
      string[] NameArray8 = new string[4]
      {
        "1 tap",
        "2 taps",
        "3 taps",
        "4 taps"
      };
      this.m_TextSelectors[10].Initialize(ref NameArray8, new Rectangle(1089, 340, 50, 88), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.MultitapType), ref4);
      this.m_TextSelectors[10].Active = false;
      string[] NameArray9 = new string[3]
      {
        "GUV",
        "ODR",
        "DIST"
      };
      this.m_TextSelectors[1].Initialize(ref NameArray9, new Rectangle(545, 180, 60, 66), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.DistortionType), ref2);
      this.m_TextSelectors[1].Active = false;
      string[] NameArray10 = new string[2]{ "ENV", "LFO" };
      this.m_TextSelectors[2].Initialize(ref NameArray10, new Rectangle(545, 180, 60, 66), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.WahType), ref2);
      this.m_TextSelectors[2].Active = false;
      this.m_TextSelectors[2].m_TextOffset = 10;
      string[] NameArray11 = new string[2]{ "CLS", "VIB" };
      this.m_TextSelectors[4].Initialize(ref NameArray11, new Rectangle(945, 180, 60, 66), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.ChorusType), ref3);
      this.m_TextSelectors[4].Active = false;
      this.m_TextSelectors[4].m_TextOffset = 10;
      string[] NameArray12 = new string[2]{ "JET", "MET" };
      this.m_TextSelectors[5].Initialize(ref NameArray12, new Rectangle(945, 180, 60, 66), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.FlangerType), ref3);
      this.m_TextSelectors[5].Active = false;
      this.m_TextSelectors[5].m_TextOffset = 10;
      string[] NameArray13 = new string[2]{ "CLS", "VBE" };
      this.m_TextSelectors[6].Initialize(ref NameArray13, new Rectangle(945, 180, 60, 66), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.PhaserType), ref3);
      this.m_TextSelectors[6].Active = false;
      this.m_TextSelectors[6].m_TextOffset = 10;
      string[] NameArray14 = new string[2]{ "VLV", "SQR" };
      this.m_TextSelectors[7].Initialize(ref NameArray14, new Rectangle(945, 180, 60, 66), Form1.m_CurrentPatch.GetRef(Form1.TextSelectorList.TremoloType), ref3);
      this.m_TextSelectors[7].Active = false;
      this.m_TextSelectors[7].m_TextOffset = 10;
      Form1.m_CurrentPatch.m_PatchNumber = 0;
      Form1.m_CurrentPatch.m_PatchName = "-- no name --";
      for (int i = 0; i < 11; ++i)
        this.UpdateSelectorLists(i);
      this.m_NameLCD = new LcdEdit(18, (Action<Rectangle>) (v => this.Invalidate(v)), (Action<string>) (v =>
      {
        Form1.m_CurrentPatch.m_PatchName = v;
        Form1.m_CurrentPatch.SaveCurrent();
      }), "-- no name --", (Func<char, bool>) (v => v >= ' ' && v <= '~'), ' ', (Func<string, int, char, string>) ((str, siz, p) => str.PadRight(siz, p)));
      this.m_NameLCD.SetText(Form1.m_CurrentPatch.m_PatchName);
      Form1.m_CurrentPatch.m_PatchName = this.m_NameLCD.GetText();
      this.m_NameLCD.Initialize((int) sbyte.MaxValue, 171, 201, 20);
      this.m_PatchNumLCD = new LcdEdit(2, (Action<Rectangle>) (v => this.Invalidate(v)), (Action<string>) (v =>
      {
        int num = int.Parse(v);
        Form1.m_CurrentPatch.m_PatchNumber = num;
        Form1.m_CurrentPatch.SaveCurrent();
      }), "00", (Func<char, bool>) (v => v >= '0' && v <= '9'), '0', (Func<string, int, char, string>) ((str, siz, p) => str.PadLeft(siz, p)));
      this.m_PatchNumLCD.InsertionMode = false;
      this.m_PatchNumLCD.SetText(Form1.m_CurrentPatch.m_PatchNumber.ToString());
      this.m_PatchNumLCD.Initialize(137, 134, 27, 20);
      this.KeyPreview = true;
      this.KeyPress += new KeyPressEventHandler(this.Form1_KeyPress);
      this.m_Midi = new MidiCom();
      this.m_Midi.Connect();
      Form1.m_CurrentPatch.FillPatchFromEdit();
      byte[] msg = new byte[75]
      {
        (byte) 240,
        (byte) 0,
        (byte) 33,
        (byte) 21,
        (byte) 48,
        (byte) 16,
        (byte) 0,
        (byte) 114,
        (byte) 3,
        (byte) 0,
        (byte) 80,
        (byte) 108,
        (byte) 101,
        (byte) 120,
        (byte) 105,
        (byte) 32,
        (byte) 82,
        (byte) 111,
        (byte) 99,
        (byte) 107,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 0,
        (byte) 70,
        (byte) 40,
        (byte) 50,
        (byte) 70,
        (byte) 50,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 6,
        (byte) 30,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 3,
        (byte) 66,
        (byte) 10,
        (byte) 10,
        (byte) 40,
        (byte) 1,
        (byte) 0,
        (byte) 20,
        (byte) 20,
        (byte) 50,
        (byte) 50,
        (byte) 1,
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 50,
        (byte) 40,
        (byte) 12,
        (byte) 13,
        (byte) 26,
        (byte) 27,
        (byte) 28,
        (byte) 29,
        (byte) 247
      };
      Form1.m_CurrentPatch.m_GETRequestWaiting = true;
      Form1.m_CurrentPatch.DecodeSysexData(ref msg);
      Form1.m_CurrentPatch.LoadCurrent();
      this.m_PatchNumLCD.SetText(Form1.m_CurrentPatch.m_PatchNumber.ToString());
      if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\CodePatchEditor") != null)
        return;
      Registry.CurrentUser.CreateSubKey("SOFTWARE\\CodePatchEditor");
      this.About();
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 33554432;
        return createParams;
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);
      Logger.Log("Form1.OnKeyDown " + e.KeyCode.ToString());
      switch (e.KeyCode)
      {
        case Keys.Left:
        case Keys.Right:
        case Keys.Delete:
          if (this.m_NameLCD.HasFocus)
          {
            Logger.Log("Sent on m_NameLCD");
            this.m_NameLCD.OnKeyDown(e.KeyCode);
          }
          if (!this.m_PatchNumLCD.HasFocus)
            break;
          this.m_PatchNumLCD.OnKeyDown(e.KeyCode);
          break;
      }
    }

    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
      Logger.Log(string.Format("Form1_KeyPress {0} : ", (object) e.KeyChar) + e.KeyChar.ToString());
      if ((e.KeyChar < ' ' || e.KeyChar > '~') && (e.KeyChar != '\b' && e.KeyChar != '\r'))
        return;
      if (this.m_NameLCD.HasFocus)
      {
        Logger.Log("-> sent on m_NameLCD");
        this.m_NameLCD.OnKeyDown(e.KeyChar);
      }
      if (this.m_PatchNumLCD.HasFocus)
        this.m_PatchNumLCD.OnKeyDown(e.KeyChar);
      e.Handled = true;
    }

    public void UpdateSelectorLists(int i)
    {
      switch ((Form1.TextSelectorList) i)
      {
        case Form1.TextSelectorList.PreFX:
          this.m_AllKnobs[6].Active = true;
          this.m_AllKnobs[6].m_RangeMul = 0.1f;
          this.m_AllKnobs[6].m_RangeOffset = 0.0f;
          this.m_AllKnobs[6].MaxValue = 100f;
          this.m_AllKnobs[6].m_bFloat = true;
          this.m_AllKnobs[7].Active = true;
          this.m_AllKnobs[7].m_RangeMul = 0.1f;
          this.m_AllKnobs[7].MaxValue = 100f;
          this.m_AllKnobs[7].m_RangeOffset = 0.0f;
          this.m_AllKnobs[7].m_bFloat = true;
          this.m_TextSelectors[1].Active = false;
          this.m_TextSelectors[2].Active = false;
          switch (Form1.m_CurrentPatch.m_TextSelectorValues[0])
          {
            case 0:
              this.m_AllKnobs[6].m_Name = "TONE";
              this.m_AllKnobs[7].m_Name = "RATIO";
              this.m_AllKnobs[8].m_Name = "COMP";
              this.m_AllKnobs[9].m_Name = "LEVEL";
              return;
            case 1:
              this.m_AllKnobs[6].Active = false;
              this.m_AllKnobs[7].m_Name = "DRIVE";
              this.m_AllKnobs[8].m_Name = "TONE";
              this.m_AllKnobs[9].m_Name = "LEVEL";
              this.m_TextSelectors[1].Active = true;
              return;
            case 2:
              this.m_TextSelectors[2].Active = true;
              this.m_AllKnobs[6].Active = false;
              this.m_AllKnobs[7].m_Name = "FREQ";
              this.m_AllKnobs[8].m_Name = "SENSIT.";
              this.m_AllKnobs[9].m_Name = "RES";
              return;
            case 3:
              this.m_AllKnobs[6].m_Name = "SEMITONE";
              this.m_AllKnobs[7].m_Name = "FINE";
              this.m_AllKnobs[8].m_Name = "REGEN";
              this.m_AllKnobs[9].m_Name = "MIX";
              this.m_AllKnobs[6].MaxValue = 24f;
              this.m_AllKnobs[6].m_RangeMul = 1f;
              this.m_AllKnobs[6].m_RangeOffset = -12f;
              this.m_AllKnobs[6].m_bFloat = false;
              this.m_AllKnobs[7].m_RangeMul = 1f;
              this.m_AllKnobs[7].MaxValue = 100f;
              this.m_AllKnobs[7].m_RangeOffset = -50f;
              this.m_AllKnobs[7].m_bFloat = false;
              return;
            default:
              return;
          }
        case Form1.TextSelectorList.Mod:
          this.m_TextSelectors[4].Active = false;
          this.m_TextSelectors[5].Active = false;
          this.m_TextSelectors[6].Active = false;
          this.m_TextSelectors[7].Active = false;
          switch (Form1.m_CurrentPatch.m_TextSelectorValues[3])
          {
            case 0:
              this.m_TextSelectors[4].Active = true;
              this.m_AllKnobs[10].m_Name = "SPEED";
              this.m_AllKnobs[11].m_Name = "DEPTH";
              this.m_AllKnobs[12].m_Name = "TONE";
              return;
            case 1:
              this.m_TextSelectors[5].Active = true;
              this.m_AllKnobs[10].m_Name = "SPEED";
              this.m_AllKnobs[11].m_Name = "DEPTH";
              this.m_AllKnobs[12].m_Name = "REGEN";
              return;
            case 2:
              this.m_TextSelectors[6].Active = true;
              this.m_AllKnobs[10].m_Name = "SPEED";
              this.m_AllKnobs[11].m_Name = "DEPTH";
              this.m_AllKnobs[12].m_Name = "REGEN";
              return;
            case 3:
              this.m_TextSelectors[7].Active = true;
              this.m_AllKnobs[10].m_Name = "SPEED";
              this.m_AllKnobs[11].m_Name = "DEPTH";
              this.m_AllKnobs[12].m_Name = "SKEW";
              return;
            default:
              return;
          }
        case Form1.TextSelectorList.DelayType:
          this.m_AllKnobs[15].Active = true;
          this.m_TextSelectors[10].Active = false;
          switch (Form1.m_CurrentPatch.m_TextSelectorValues[8])
          {
            case 0:
              this.m_AllKnobs[13].m_Name = "TIME";
              this.m_AllKnobs[14].m_Name = "FEEDBACK";
              this.m_AllKnobs[15].m_Name = "FREQ";
              this.m_AllKnobs[16].m_Name = "LEVEL";
              return;
            case 1:
              this.m_AllKnobs[13].m_Name = "TIME";
              this.m_AllKnobs[14].m_Name = "FEEDBACK";
              this.m_AllKnobs[15].m_Name = "AGE";
              this.m_AllKnobs[16].m_Name = "LEVEL";
              return;
            case 2:
              this.m_AllKnobs[13].m_Name = "TIME";
              this.m_AllKnobs[14].m_Name = "FEEDBACK";
              this.m_AllKnobs[15].Active = false;
              this.m_TextSelectors[10].Active = true;
              this.m_AllKnobs[16].m_Name = "LEVEL";
              return;
            case 3:
              this.m_AllKnobs[13].m_Name = "TIME";
              this.m_AllKnobs[14].m_Name = "FEEDBACK";
              this.m_AllKnobs[15].m_Name = "FREQ";
              this.m_AllKnobs[16].m_Name = "LEVEL";
              return;
            default:
              return;
          }
      }
    }

    private void print(Bitmap BM, PaintEventArgs e)
    {
      this.SetMIDIState(this.m_Midi.Connected());
      Rectangle rect = new Rectangle(0, 0, 1264, 728);
      e.Graphics.DrawImage((Image) BM, rect);
      this.m_NameLCD.print(e);
      this.m_PatchNumLCD.print(e);
      for (int index = 0; index < 23; ++index)
        this.m_AllKnobs[index].print(e);
      for (int index = 0; index < 7; ++index)
        this.m_OnOffButtons[index].print(e, BitmapList.ButtonOff, BitmapList.ButtonOn);
      for (int index = 0; index < 3; ++index)
        this.m_ImageSelectors[index].print(e);
      for (int index = 0; index < 11; ++index)
        this.m_TextSelectors[index].print(e);
      for (int index = 0; index < 13; ++index)
        this.m_BitmapButtons[index].print(e);
      e.Graphics.DrawImage(Form1.MidiEnabled ? (Image) BitmapList.MidiOn : (Image) BitmapList.MidiOff, 305, 132);
      this.tooltip.print(e);
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      Rectangle bounds = Screen.PrimaryScreen.Bounds;
      int bitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
      this.print(BitmapList.Panel, e);
    }

    public void SetMIDIState(bool bOnOff)
    {
      Form1.MidiEnabled = bOnOff;
      this.m_BitmapButtons[1].m_Enabled = Form1.MidiEnabled;
      this.m_BitmapButtons[0].m_Enabled = Form1.MidiEnabled;
    }

    protected override void OnClosed(EventArgs e)
    {
      this.m_Midi.Close();
      base.OnClosed(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      this.tooltip.Active = false;
      base.OnMouseDown(e);
      if (e.Button != MouseButtons.Left)
        return;
      if (!this.m_NameLCD.OnMouseDown(e) && this.m_NameLCD.HasFocus)
        this.m_NameLCD.SetFocus(false);
      if (!this.m_PatchNumLCD.OnMouseDown(e) && this.m_PatchNumLCD.HasFocus)
        this.m_PatchNumLCD.SetFocus(false);
      for (int index = 0; index < 13; ++index)
      {
        if (this.m_BitmapButtons[index].OnMouseDown(e))
        {
          this.m_BitmapButtons[index].m_Pushed = true;
          this.m_PushingButton = index;
          this.Capture = true;
          this.Refresh();
        }
      }
      for (int i = 0; i < 11; ++i)
      {
        if (this.m_TextSelectors[i].OnMouseDown(e))
        {
          this.UpdateSelectorLists(i);
          this.Refresh();
        }
      }
      for (int index = 0; index < 23; ++index)
      {
        if (this.m_AllKnobs[index].OnMouseDown(e))
        {
          this.m_DraggingKnobIndex = index;
          this.Capture = true;
        }
      }
      for (int index = 0; index < 7; ++index)
      {
        if (this.m_OnOffButtons[index].OnMouseDown(e))
        {
          this.Capture = true;
          this.Refresh();
        }
      }
      for (int index = 0; index < 3; ++index)
      {
        if (this.m_ImageSelectors[index].OnMouseDown(e))
          this.Refresh();
      }
      Form1.m_CurrentPatch.UpdateAmp();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      this.tooltip.Active = false;
      base.OnMouseUp(e);
      this.m_DraggingKnobIndex = -1;
      if (this.m_PushingButton != -1)
      {
        this.m_BitmapButtons[this.m_PushingButton].m_Pushed = false;
        if (this.m_BitmapButtons[this.m_PushingButton].OnMouseDown(e))
          this.ButtonPushed(this.m_PushingButton);
        this.Refresh();
        this.m_PushingButton = -1;
      }
      else
      {
        for (int index = 0; index < 7; ++index)
        {
          if (this.m_OnOffButtons[index].m_BeingPushed)
          {
            this.m_OnOffButtons[index].m_Pushed = false;
            this.m_OnOffButtons[index].m_BeingPushed = false;
          }
        }
        this.Refresh();
      }
      this.Capture = false;
      Form1.m_CurrentPatch.UpdateAmp();
    }

    protected void ImportSectionFromPreset(Form1.BitmapButtonList _type)
    {
      this.openFileDialog1.FileName = "";
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      Form1.m_CurrentPatch.LoadFileInSection(_type, this.openFileDialog1.FileName, this);
      this.Refresh();
    }

    protected void ButtonPushed(int _index)
    {
      switch (_index)
      {
        case 0:
          Form1.m_CurrentPatch.SendGetCurrentPatchData();
          break;
        case 1:
          Form1.m_CurrentPatch.SendCurrentPatchToAmp();
          break;
        case 2:
          --Form1.m_CurrentPatch.m_PatchNumber;
          if (Form1.m_CurrentPatch.m_PatchNumber < 0)
            Form1.m_CurrentPatch.m_PatchNumber = 99;
          this.m_PatchNumLCD.SetText(Form1.m_CurrentPatch.m_PatchNumber.ToString());
          Form1.m_CurrentPatch.SaveCurrent();
          break;
        case 3:
          ++Form1.m_CurrentPatch.m_PatchNumber;
          if (Form1.m_CurrentPatch.m_PatchNumber > 99)
            Form1.m_CurrentPatch.m_PatchNumber = 0;
          this.m_PatchNumLCD.SetText(Form1.m_CurrentPatch.m_PatchNumber.ToString());
          Form1.m_CurrentPatch.SaveCurrent();
          break;
        case 4:
          this.LoadFile();
          break;
        case 5:
          this.SaveFile();
          break;
        case 6:
          this.About();
          break;
        case 7:
        case 8:
        case 9:
        case 10:
        case 11:
        case 12:
          this.ImportSectionFromPreset((Form1.BitmapButtonList) _index);
          break;
      }
      this.Refresh();
    }

    protected void About()
    {
      int num = (int) MessageBox.Show("Code Editor\n\rCopyright (c) 2016 James Clent\n\r\n\rThis software is a free open source software done by\n\rvolunteers and is distributed under the MIT license.\n\r    (Please read the included License.txt file)\n\r\n\r          This project is not affiliated with \n\r                   Marshall Amplification. \n\r\n\rThis project uses the Sanford.Multimedia.Midi package\n\rCopyright (c) 2005 Leslie Sanford\n\r\n\rMarshall® and Marshall® CODE™ are registered\n\rtrademarks of Marshall Amplification Plc", "Code Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      bool flag1 = false;
      base.OnMouseMove(e);
      bool flag2 = false;
      if (this.m_DraggingKnobIndex != -1)
      {
        flag2 = true;
        if (this.m_AllKnobs[this.m_DraggingKnobIndex].OnMouseMove(e))
        {
          this.Invalidate(this.m_AllKnobs[this.m_DraggingKnobIndex].m_Position);
          this.Invalidate(this.m_AllKnobs[this.m_DraggingKnobIndex].m_LCD);
        }
      }
      else if (this.m_PushingButton != -1)
      {
        flag2 = true;
        this.m_BitmapButtons[this.m_PushingButton].m_Pushed = false;
        if (this.m_BitmapButtons[this.m_PushingButton].OnMouseDown(e))
        {
          this.m_BitmapButtons[this.m_PushingButton].m_Pushed = true;
          this.Refresh();
        }
        this.Refresh();
      }
      else
      {
        for (int index = 0; index < 7; ++index)
        {
          if (this.m_OnOffButtons[index].m_BeingPushed)
          {
            flag2 = true;
            this.m_OnOffButtons[index].m_Pushed = this.m_OnOffButtons[index].OnMouseMove(e);
            this.Refresh();
          }
        }
        for (int index = 0; index < 3; ++index)
        {
          if (this.m_ImageSelectors[index].OnMouseMove(e))
            this.Invalidate(this.m_ImageSelectors[index].m_Position);
        }
        for (int index = 0; index < 11; ++index)
        {
          if (this.m_TextSelectors[index].OnMouseMove(e))
            this.Invalidate(this.m_TextSelectors[index].m_Position);
        }
      }
      if (!flag2)
      {
        Rectangle pos = new Rectangle(0, 0, 0, 0);
        string text = (string) null;
        for (int index = 0; index < 13; ++index)
        {
          if (this.m_BitmapButtons[index].m_Position.Contains(e.Location) && this.m_BitmapButtons[index].m_TooltipText != null)
          {
            pos = this.m_BitmapButtons[index].m_Position;
            flag1 = true;
            text = this.m_BitmapButtons[index].m_TooltipText;
          }
        }
        if (flag1)
          this.tooltip.Activate(pos, text);
      }
      if (!flag1)
        this.tooltip.Active = false;
      this.Invalidate();
      Form1.m_CurrentPatch.UpdateAmp();
    }

    public void LoadFile()
    {
      this.openFileDialog1.FileName = "";
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      Form1.m_CurrentPatch.LoadFile(this.openFileDialog1.FileName, this, false);
      this.Refresh();
    }

    public void SaveFile()
    {
      if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      Form1.m_CurrentPatch.SaveFile(this.saveFileDialog1.FileName);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      e.Effect = DragDropEffects.Copy;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      string[] data = (string[]) e.Data.GetData(DataFormats.FileDrop);
      Form1.m_CurrentPatch.LoadFile(data[0], this, false);
      this.Refresh();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.openFileDialog1 = new OpenFileDialog();
      this.saveFileDialog1 = new SaveFileDialog();
      this.SuspendLayout();
      this.openFileDialog1.FileName = "openFileDialog1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(749, 456);
      this.Margin = new Padding(2, 2, 2, 2);
      this.Name = nameof (Form1);
      this.Text = nameof (Form1);
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
    }

    public enum Knobs
    {
      PREAMP_GAIN,
      PREAMP_VOLUME,
      PREAMP_THRESHOLD,
      PREAMP_BASS,
      PREAMP_MIDDLE,
      PREAMP_TREBLE,
      PREFX_PARAM1,
      PREFX_PARAM2,
      PREFX_PARAM3,
      PREFX_PARAM4,
      MOD_SPEED,
      MOD_DEPTH,
      MOD_TONE,
      DEL_TIME,
      DEL_FEEDBACK,
      DEL_AGE,
      DEL_LEVEL,
      REV_DECAY,
      REV_PREDELAY,
      REV_TONE,
      REV_LEVEL,
      POWER_PRESENCE,
      POWER_RESONANCE,
      TotalNumber,
    }

    public enum OnOff
    {
      PREFX,
      PREAMP,
      POWER,
      MOD,
      DELAY,
      REV,
      CAB,
      TotalNumber,
    }

    public enum ImgSelectorList
    {
      Preamp,
      Cab,
      Power,
      TotalNumber,
    }

    public enum BitmapButtonList
    {
      IMPORT_FROM_AMP,
      EXPORT_TO_AMP,
      PREV_PATCH,
      NEXT_PATCH,
      LOAD,
      SAVE,
      HELP,
      IMPORT_MOD,
      IMPORT_PRE,
      IMPORT_REV,
      IMPORT_AMP,
      IMPORT_DEL,
      IMPORT_POW,
      TotalNumber,
    }

    public enum TextSelectorList
    {
      PreFX,
      DistortionType,
      WahType,
      Mod,
      ChorusType,
      FlangerType,
      PhaserType,
      TremoloType,
      DelayType,
      ReverbType,
      MultitapType,
      TotalNumber,
    }
  }
}
