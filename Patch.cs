// Decompiled with JetBrains decompiler
// Type: CodeEditor.Patch
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CodeEditor
{
  public class Patch
  {
    public string m_PatchName = "-- no name --";
    public const int CODE_GAIN = 70;
    public const int CODE_BASS = 71;
    public const int CODE_MIDDLE = 72;
    public const int CODE_TREBLE = 73;
    public const int CODE_VOLUME = 74;
    public const int CODE_GATE_THRESHOLD = 83;
    public const int CODE_PREFX_ONOFF = 75;
    public const int CODE_PREAMP_ONOFF = 81;
    public const int CODE_MOD_ONOFF = 85;
    public const int CODE_DELAY_ONOFF = 103;
    public const int CODE_REVERB_ONOFF = 108;
    public const int CODE_POWERAMP_ONOFF = 114;
    public const int CODE_CAB_ONOFF = 116;
    public const int CODE_CAB_TYPE = 117;
    public const int CODE_CAB_1960 = 0;
    public const int CODE_CAB_1960V = 1;
    public const int CODE_CAB_1960AX = 2;
    public const int CODE_CAB_1960HW = 3;
    public const int CODE_CAB_1936 = 4;
    public const int CODE_CAB_1936V = 5;
    public const int CODE_CAB_1912 = 6;
    public const int CODE_CAB_1974CX = 7;
    public const int CODE_POWERAMP_TYPE = 115;
    public const int CODE_POWERAMP_CM100 = 0;
    public const int CODE_POWERAMP_VM30 = 1;
    public const int CODE_POWERAMP_BCLA = 2;
    public const int CODE_POWERAMP_ACAB = 3;
    public const int CODE_POWERAMP_PRES = 118;
    public const int CODE_POWERAMP_RES = 119;
    public const int CODE_REVERB_TYPE = 109;
    public const int CODE_REVERB_ROOM = 0;
    public const int CODE_REVERB_HALL = 1;
    public const int CODE_REVERB_SPRING = 2;
    public const int CODE_REVERB_STADIUM = 3;
    public const int CODE_REVERB_DECAY = 110;
    public const int CODE_REVERB_PREDELAY = 111;
    public const int CODE_REVERB_TONE = 112;
    public const int CODE_REVERB_LEVEL = 113;
    public const int CODE_DELAY_TYPE = 104;
    public const int CODE_DELAY_STUDIO = 0;
    public const int CODE_DELAY_VINTAGE = 1;
    public const int CODE_DELAY_MULTI = 2;
    public const int CODE_DELAY_REVERSE = 3;
    public const int CODE_DELAY_TIME_MSB = 31;
    public const int CODE_DELAY_TIME_LSB = 63;
    public const int CODE_DELAY_TIME_MAX = 4000;
    public const int CODE_DELAY_FEEDBACK = 105;
    public const int CODE_DELAY_FREQUENCY = 106;
    public const int CODE_DELAY_AGE = 106;
    public const int CODE_DELAY_PATTERN = 106;
    public const int CODE_DELAY_LEVEL = 107;
    public const int CODE_MOD_TYPE = 86;
    public const int CODE_MOD_CHORUS = 0;
    public const int CODE_MOD_FLANGER = 1;
    public const int CODE_MOD_PHASER = 2;
    public const int CODE_MOD_TREMOLO = 3;
    public const int CODE_MOD_MODE = 90;
    public const int CODE_MOD_MODE_CLS = 0;
    public const int CODE_MOD_MODE_VIB = 1;
    public const int CODE_MOD_MODE_JET = 0;
    public const int CODE_MOD_MODE_MET = 1;
    public const int CODE_MOD_MODE_VLV = 0;
    public const int CODE_MOD_MODE_SQR = 1;
    public const int CODE_MOD_SPEED = 87;
    public const int CODE_MOD_DEPTH = 89;
    public const int CODE_MOD_TONE = 102;
    public const int CODE_MOD_REGEN = 102;
    public const int CODE_MOD_SKEW = 102;
    public const int CODE_PREAMP_TYPE = 82;
    public const int CODE_PRE_CLN_JTM45 = 0;
    public const int CODE_PRE_CLN_DSL = 1;
    public const int CODE_PRE_CLN_USA = 2;
    public const int CODE_PRE_CLN_JVM = 3;
    public const int CODE_PRE_CLN_ACCOUST = 4;
    public const int CODE_PRE_CRN_BLUESB = 5;
    public const int CODE_PRE_CRN_PLEXI = 6;
    public const int CODE_PRE_CRN_USA = 7;
    public const int CODE_PRE_CRN_JCM800 = 8;
    public const int CODE_PRE_CRN_50UK = 9;
    public const int CODE_PRE_OD_JVM = 10;
    public const int CODE_PRE_OD_DSL = 11;
    public const int CODE_PRE_OD_USA = 12;
    public const int CODE_PRE_OD_JUBILEE = 13;
    public const int CODE_PRE_NATURAL = 14;
    public const int CODE_PFX_TYPE = 76;
    public const int CODE_PFX_COMPRESSOR = 0;
    public const int CODE_PFX_DISTORTION = 1;
    public const int CODE_PFX_AUTOWAH = 2;
    public const int CODE_PFX_PITCHSHIFT = 3;
    public const int CODE_PFX_COM_TONE = 77;
    public const int CODE_PFX_COM_RATIO = 78;
    public const int CODE_PFX_COM_COMP = 79;
    public const int CODE_PFX_COM_LEVEL = 80;
    public const int CODE_PFX_DIS_MODE = 77;
    public const int CODE_PFX_DIS_DRIVE = 78;
    public const int CODE_PFX_DIS_TONE = 79;
    public const int CODE_PFX_DIS_LEVEL = 80;
    public const int CODE_PFX_WAH_MODE = 77;
    public const int CODE_PFX_WAH_FREQ = 78;
    public const int CODE_PFX_WAH_SENS = 79;
    public const int CODE_PFX_WAH_RES = 80;
    public const int CODE_PFX_PSH_SEMI = 77;
    public const int CODE_PFX_PSH_FINE = 78;
    public const int CODE_PFX_PSH_REGEN = 79;
    public const int CODE_PFX_PSH_MIX = 80;
    public int m_PatchNumber;
    public float[] m_KnobsValues;
    public bool[] m_OnOffValues;
    public int[] m_ImageSelectorValues;
    public int[] m_TextSelectorValues;
    public static int[] s_PatchCCOrder;
    public int[] m_PatchFinalValues;
    public int[] m_PatchSentValues;
    public bool m_GETRequestWaiting;

    public Ref<bool> GetRef(Form1.OnOff _index)
    {
      return new Ref<bool>((Func<bool>) (() => this.m_OnOffValues[(int) _index]), (Action<bool>) (v => this.m_OnOffValues[(int) _index] = v));
    }

    public Ref<int> GetRef(Form1.ImgSelectorList _index)
    {
      return new Ref<int>((Func<int>) (() => this.m_ImageSelectorValues[(int) _index]), (Action<int>) (v => this.m_ImageSelectorValues[(int) _index] = v));
    }

    public Ref<int> GetRef(Form1.TextSelectorList _index)
    {
      return new Ref<int>((Func<int>) (() => this.m_TextSelectorValues[(int) _index]), (Action<int>) (v => this.m_TextSelectorValues[(int) _index] = v));
    }

    public Ref<float> GetRef(Form1.Knobs _index)
    {
      return new Ref<float>((Func<float>) (() => this.m_KnobsValues[(int) _index]), (Action<float>) (v => this.m_KnobsValues[(int) _index] = v));
    }

    public Patch()
    {
      this.m_PatchFinalValues = new int[40];
      this.m_PatchSentValues = new int[40];
      for (int index = 0; index < 40; ++index)
      {
        this.m_PatchFinalValues[index] = 0;
        this.m_PatchSentValues[index] = -1;
      }
      this.m_KnobsValues = new float[23];
      for (int index = 0; index < 23; ++index)
        this.m_KnobsValues[index] = 0.0f;
      this.m_OnOffValues = new bool[7];
      for (int index = 0; index < 7; ++index)
        this.m_OnOffValues[index] = true;
      this.m_ImageSelectorValues = new int[3];
      for (int index = 0; index < 3; ++index)
        this.m_ImageSelectorValues[index] = 0;
      this.m_TextSelectorValues = new int[11];
      for (int index = 0; index < 11; ++index)
        this.m_TextSelectorValues[index] = 0;
      Patch.s_PatchCCOrder = new int[120];
      Patch.s_PatchCCOrder[0] = 31;
      Patch.s_PatchCCOrder[1] = 63;
      Patch.s_PatchCCOrder[2] = 70;
      Patch.s_PatchCCOrder[3] = 71;
      Patch.s_PatchCCOrder[4] = 72;
      Patch.s_PatchCCOrder[5] = 73;
      Patch.s_PatchCCOrder[6] = 74;
      Patch.s_PatchCCOrder[7] = 75;
      Patch.s_PatchCCOrder[8] = 76;
      Patch.s_PatchCCOrder[9] = 77;
      Patch.s_PatchCCOrder[10] = 78;
      Patch.s_PatchCCOrder[11] = 79;
      Patch.s_PatchCCOrder[12] = 80;
      Patch.s_PatchCCOrder[13] = 81;
      Patch.s_PatchCCOrder[14] = 82;
      Patch.s_PatchCCOrder[15] = 83;
      Patch.s_PatchCCOrder[16] = 85;
      Patch.s_PatchCCOrder[17] = 86;
      Patch.s_PatchCCOrder[18] = 87;
      Patch.s_PatchCCOrder[19] = 89;
      Patch.s_PatchCCOrder[20] = 90;
      Patch.s_PatchCCOrder[21] = 102;
      Patch.s_PatchCCOrder[22] = 103;
      Patch.s_PatchCCOrder[23] = 104;
      Patch.s_PatchCCOrder[24] = 105;
      Patch.s_PatchCCOrder[25] = 106;
      Patch.s_PatchCCOrder[26] = 107;
      Patch.s_PatchCCOrder[27] = 108;
      Patch.s_PatchCCOrder[28] = 109;
      Patch.s_PatchCCOrder[29] = 109;
      Patch.s_PatchCCOrder[30] = 110;
      Patch.s_PatchCCOrder[31] = 111;
      Patch.s_PatchCCOrder[32] = 112;
      Patch.s_PatchCCOrder[33] = 113;
      Patch.s_PatchCCOrder[34] = 114;
      Patch.s_PatchCCOrder[35] = 115;
      Patch.s_PatchCCOrder[36] = 116;
      Patch.s_PatchCCOrder[37] = 117;
      Patch.s_PatchCCOrder[38] = 118;
      Patch.s_PatchCCOrder[39] = 119;
    }

    public byte[] CreateSysEx(ref int sysexsize, bool GET, int PatchNumber)
    {
      byte[] numArray = new byte[256];
      sysexsize = 0;
      numArray[sysexsize++] = (byte) 240;
      numArray[sysexsize++] = (byte) 0;
      numArray[sysexsize++] = (byte) 33;
      numArray[sysexsize++] = (byte) 21;
      numArray[sysexsize++] = (byte) 127;
      numArray[sysexsize++] = (byte) 127;
      numArray[sysexsize++] = (byte) 127;
      numArray[sysexsize++] = PatchNumber != -1 ? (byte) 114 : (byte) 115;
      numArray[sysexsize++] = GET ? (byte) 1 : (byte) 2;
      numArray[sysexsize++] = (byte) PatchNumber;
      return numArray;
    }

    public byte[] FinalizeSysEx(ref byte[] msg, ref int sysexsize)
    {
      msg[sysexsize++] = (byte) 247;
      byte[] numArray = new byte[sysexsize];
      for (int index = 0; index < sysexsize; ++index)
        numArray[index] = msg[index];
      return numArray;
    }

    public void SendGetCurrentPatchData()
    {
      int sysexsize = 0;
      byte[] sysEx = this.CreateSysEx(ref sysexsize, true, this.m_PatchNumber);
      byte[] msg = this.FinalizeSysEx(ref sysEx, ref sysexsize);
      Form1.CurrentForm1.m_Midi.SendSysEx(ref msg);
      if (!Form1.CurrentForm1.m_Midi.Connected())
        return;
      this.m_GETRequestWaiting = true;
    }

    public void SendCurrentPatchToAmp()
    {
      this.FillPatchFromEdit();
      this.ResetUpdateAmp();
      int num = 0;
      byte[] sysEx = this.CreateSysEx(ref num, false, this.m_PatchNumber);
      this.FillPatchSysExWithCurrentData(ref sysEx, ref num);
      byte[] msg = this.FinalizeSysEx(ref sysEx, ref num);
      string str1 = "byte[] SysEx = { 0x";
      for (int index = 0; index < 75; ++index)
      {
        string str2 = str1 + msg[index].ToString("X2");
        str1 = index != 74 ? str2 + ", 0x" : str2 + " };";
      }
      Form1.CurrentForm1.m_Midi.SendSysEx(ref msg);
      Form1.CurrentForm1.m_Midi.SendPC(this.m_PatchNumber);
    }

    private Patch.SysExError DecodeInternalSysEx(ref byte[] msg)
    {
      int num1 = 0;
      byte[] numArray1 = msg;
      int index1 = num1;
      int num2 = index1 + 1;
      if (numArray1[index1] != (byte) 240)
        return Patch.SysExError.Error_Bad_SysEx_Header;
      byte[] numArray2 = msg;
      int index2 = num2;
      int num3 = index2 + 1;
      if (numArray2[index2] != (byte) 0)
        return Patch.SysExError.Error_Bad_Manufacturer_ID;
      byte[] numArray3 = msg;
      int index3 = num3;
      int num4 = index3 + 1;
      if (numArray3[index3] != (byte) 33)
        return Patch.SysExError.Error_Bad_Manufacturer_ID;
      byte[] numArray4 = msg;
      int index4 = num4;
      int num5 = index4 + 1;
      if (numArray4[index4] != (byte) 21)
        return Patch.SysExError.Error_Bad_Manufacturer_ID;
      byte[] numArray5 = msg;
      int index5 = num5;
      int num6 = index5 + 1;
      if (numArray5[index5] != (byte) 48)
        return Patch.SysExError.Error_Bad_Family_ID;
      byte[] numArray6 = msg;
      int index6 = num6;
      int num7 = index6 + 1;
      if (numArray6[index6] != (byte) 16)
        return Patch.SysExError.Error_Bad_Model_ID;
      byte[] numArray7 = msg;
      int index7 = num7;
      int num8 = index7 + 1;
      if (numArray7[index7] != (byte) 0)
        return Patch.SysExError.Error_Bad_Device_ID;
      byte[] numArray8 = msg;
      int index8 = num8;
      int num9 = index8 + 1;
      byte num10 = numArray8[index8];
      byte[] numArray9 = msg;
      int index9 = num9;
      int num11 = index9 + 1;
      switch (numArray9[index9])
      {
        case 3:
          Logger.Log("-> RECEIVING PATCH by sysex !");
          int sysind;
          if (num10 == (byte) 114)
          {
            sysind = num11 + 1;
          }
          else
          {
            byte[] numArray10 = msg;
            int index10 = num11;
            sysind = index10 + 1;
            this.m_PatchNumber = (int) numArray10[index10];
          }
          if (this.m_GETRequestWaiting)
          {
            this.m_GETRequestWaiting = false;
            return this.DecodePatchFromSysExData(ref msg, ref sysind);
          }
          Logger.Log("IGNORING PATCH SYSEX ! WASN'T REQUESTED !");
          break;
        case 4:
          Logger.Log("-> REPLY OK sysex !");
          break;
        case 5:
          Logger.Log("*** Received a REPLY_ERROR sysex !");
          break;
        default:
          Logger.Log("*** RECEIVED UNKNOWN sysex !!!!");
          return Patch.SysExError.Error_Unrecognized_Command_Byte_2;
      }
      return Patch.SysExError.NoError;
    }

    public void DecodeSysexData(ref byte[] msg)
    {
      Patch.SysExError sysExError = this.DecodeInternalSysEx(ref msg);
      if (sysExError != Patch.SysExError.NoError)
      {
        Logger.Log("Error while decoding sysex : " + sysExError.ToString());
        int num = (int) MessageBox.Show("Error while decoding sysex : " + sysExError.ToString(), "Code Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        Logger.Log("Sysex \"" + this.m_PatchName + "\" Decoded OK :-)");
      Form1.CurrentForm1.Invalidate();
    }

    public void TestSysEx()
    {
      byte[] msg = new byte[75]
      {
        (byte) 240,
        (byte) 0,
        (byte) 33,
        (byte) 21,
        (byte) 48,
        (byte) 16,
        (byte) 0,
        (byte) 115,
        (byte) 3,
        (byte) 0,
        (byte) 69,
        (byte) 70,
        (byte) 71,
        (byte) 72,
        (byte) 73,
        (byte) 74,
        (byte) 75,
        (byte) 76,
        (byte) 77,
        (byte) 78,
        (byte) 79,
        (byte) 80,
        (byte) 81,
        (byte) 82,
        (byte) 83,
        (byte) 84,
        (byte) 85,
        (byte) 86,
        (byte) 0,
        (byte) 58,
        (byte) 1,
        (byte) 58,
        (byte) 62,
        (byte) 45,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 62,
        (byte) 50,
        (byte) 50,
        (byte) 1,
        (byte) 7,
        (byte) 25,
        (byte) 0,
        (byte) 3,
        (byte) 94,
        (byte) 76,
        (byte) 1,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 2,
        (byte) 108,
        (byte) 16,
        (byte) 69,
        (byte) 24,
        (byte) 0,
        (byte) 1,
        (byte) 19,
        (byte) 34,
        (byte) 36,
        (byte) 39,
        (byte) 1,
        (byte) 2,
        (byte) 1,
        (byte) 7,
        (byte) 54,
        (byte) 11,
        (byte) 12,
        (byte) 13,
        (byte) 26,
        (byte) 27,
        (byte) 28,
        (byte) 29,
        (byte) 247
      };
      this.DecodeSysexData(ref msg);
    }

    public void FillPatchSysExWithCurrentData(ref byte[] msg, ref int sysind)
    {
      this.FillPatchFromEdit();
      char[] array = this.m_PatchName.ToArray<char>();
      for (int index = 0; index < 18; ++index)
        msg[sysind++] = (byte) array[index];
      msg[sysind++] = (byte) 0;
      msg[sysind++] = (byte) this.m_PatchFinalValues[2];
      msg[sysind++] = (byte) this.m_PatchFinalValues[3];
      msg[sysind++] = (byte) this.m_PatchFinalValues[4];
      msg[sysind++] = (byte) this.m_PatchFinalValues[5];
      msg[sysind++] = (byte) this.m_PatchFinalValues[6];
      msg[sysind++] = (byte) this.m_PatchFinalValues[7];
      msg[sysind++] = (byte) this.m_PatchFinalValues[8];
      msg[sysind++] = (byte) this.m_PatchFinalValues[9];
      msg[sysind++] = (byte) this.m_PatchFinalValues[10];
      msg[sysind++] = (byte) this.m_PatchFinalValues[11];
      msg[sysind++] = (byte) this.m_PatchFinalValues[12];
      msg[sysind++] = (byte) this.m_PatchFinalValues[13];
      msg[sysind++] = (byte) this.m_PatchFinalValues[14];
      msg[sysind++] = (byte) this.m_PatchFinalValues[15];
      msg[sysind++] = (byte) this.m_PatchFinalValues[16];
      msg[sysind++] = (byte) this.m_PatchFinalValues[17];
      msg[sysind++] = (byte) this.m_PatchFinalValues[18];
      msg[sysind++] = (byte) this.m_PatchFinalValues[19];
      msg[sysind++] = (byte) this.m_PatchFinalValues[20];
      msg[sysind++] = (byte) this.m_PatchFinalValues[21];
      msg[sysind++] = (byte) this.m_PatchFinalValues[22];
      msg[sysind++] = (byte) this.m_PatchFinalValues[23];
      msg[sysind++] = (byte) this.m_PatchFinalValues[0];
      msg[sysind++] = (byte) this.m_PatchFinalValues[1];
      msg[sysind++] = (byte) this.m_PatchFinalValues[24];
      msg[sysind++] = (byte) this.m_PatchFinalValues[25];
      msg[sysind++] = (byte) this.m_PatchFinalValues[26];
      msg[sysind++] = (byte) this.m_PatchFinalValues[27];
      msg[sysind++] = (byte) this.m_PatchFinalValues[29];
      msg[sysind++] = (byte) this.m_PatchFinalValues[30];
      msg[sysind++] = (byte) this.m_PatchFinalValues[31];
      msg[sysind++] = (byte) this.m_PatchFinalValues[32];
      msg[sysind++] = (byte) this.m_PatchFinalValues[33];
      msg[sysind++] = (byte) this.m_PatchFinalValues[34];
      msg[sysind++] = (byte) this.m_PatchFinalValues[35];
      msg[sysind++] = (byte) this.m_PatchFinalValues[36];
      msg[sysind++] = (byte) this.m_PatchFinalValues[37];
      msg[sysind++] = (byte) this.m_PatchFinalValues[38];
      msg[sysind++] = (byte) this.m_PatchFinalValues[39];
      msg[sysind++] = (byte) 12;
      msg[sysind++] = (byte) 13;
      msg[sysind++] = (byte) 26;
      msg[sysind++] = (byte) 27;
      msg[sysind++] = (byte) 28;
      msg[sysind++] = (byte) 29;
      if (sysind == 74)
        return;
      Logger.Log("Error in sysex creation");
    }

    public Patch.SysExError DecodePatchFromSysExData(ref byte[] msg, ref int sysind)
    {
      char[] chArray = new char[18];
      for (int index = 0; index < 18; ++index)
        chArray[index] = (char) msg[sysind++];
      string str = new string(chArray);
      if (msg[sysind++] != (byte) 0)
        return Patch.SysExError.Error_Bad_Patch_Name_Size;
      if (msg.Length - sysind < 39)
      {
        Logger.Log(string.Format("### Error ! sysex too short ! {0}", (object) (msg.Length - sysind)));
        return Patch.SysExError.Error_Bad_SysEx_Size;
      }
      this.m_PatchFinalValues[2] = (int) msg[sysind++];
      this.m_PatchFinalValues[3] = (int) msg[sysind++];
      this.m_PatchFinalValues[4] = (int) msg[sysind++];
      this.m_PatchFinalValues[5] = (int) msg[sysind++];
      this.m_PatchFinalValues[6] = (int) msg[sysind++];
      this.m_PatchFinalValues[7] = (int) msg[sysind++];
      this.m_PatchFinalValues[8] = (int) msg[sysind++];
      this.m_PatchFinalValues[9] = (int) msg[sysind++];
      this.m_PatchFinalValues[10] = (int) msg[sysind++];
      this.m_PatchFinalValues[11] = (int) msg[sysind++];
      this.m_PatchFinalValues[12] = (int) msg[sysind++];
      this.m_PatchFinalValues[13] = (int) msg[sysind++];
      this.m_PatchFinalValues[14] = (int) msg[sysind++];
      this.m_PatchFinalValues[15] = (int) msg[sysind++];
      this.m_PatchFinalValues[16] = (int) msg[sysind++];
      this.m_PatchFinalValues[17] = (int) msg[sysind++];
      this.m_PatchFinalValues[18] = (int) msg[sysind++];
      this.m_PatchFinalValues[19] = (int) msg[sysind++];
      this.m_PatchFinalValues[20] = (int) msg[sysind++];
      this.m_PatchFinalValues[21] = (int) msg[sysind++];
      this.m_PatchFinalValues[22] = (int) msg[sysind++];
      this.m_PatchFinalValues[23] = (int) msg[sysind++];
      this.m_PatchFinalValues[0] = (int) msg[sysind++];
      this.m_PatchFinalValues[1] = (int) msg[sysind++];
      this.m_PatchFinalValues[24] = (int) msg[sysind++];
      this.m_PatchFinalValues[25] = (int) msg[sysind++];
      this.m_PatchFinalValues[26] = (int) msg[sysind++];
      this.m_PatchFinalValues[27] = (int) msg[sysind++];
      this.m_PatchFinalValues[28] = (int) msg[sysind];
      this.m_PatchFinalValues[29] = (int) msg[sysind++];
      this.m_PatchFinalValues[30] = (int) msg[sysind++];
      this.m_PatchFinalValues[31] = (int) msg[sysind++];
      this.m_PatchFinalValues[32] = (int) msg[sysind++];
      this.m_PatchFinalValues[33] = (int) msg[sysind++];
      this.m_PatchFinalValues[34] = (int) msg[sysind++];
      this.m_PatchFinalValues[35] = (int) msg[sysind++];
      this.m_PatchFinalValues[36] = (int) msg[sysind++];
      this.m_PatchFinalValues[37] = (int) msg[sysind++];
      this.m_PatchFinalValues[38] = (int) msg[sysind++];
      this.m_PatchFinalValues[39] = (int) msg[sysind++];
      this.m_PatchName = str;
      this.FillEditFromPatch(Form1.CurrentForm1);
      return Patch.SysExError.NoError;
    }

    public void RecieveCC(int Num, int Value)
    {
      for (int index = 0; index < 40; ++index)
      {
        if (Patch.s_PatchCCOrder[index] == Num)
        {
          this.m_PatchFinalValues[index] = Value;
          this.FillEditFromPatch(Form1.CurrentForm1);
          Form1.CurrentForm1.Refresh();
        }
      }
    }

    public void ReceivePC(int Num)
    {
      for (int index = 0; index < 40; ++index)
      {
        this.m_PatchSentValues[index] = -1;
        Form1.CurrentForm1.Refresh();
      }
    }

    public void SendCC(int Num, int Value)
    {
      Form1.CurrentForm1.m_Midi.SendCC(Num, Value);
    }

    public void ResetUpdateAmp()
    {
      for (int index = 0; index < 40; ++index)
      {
        if (this.m_PatchSentValues[index] != this.m_PatchFinalValues[index])
          this.m_PatchSentValues[index] = this.m_PatchFinalValues[index];
      }
      this.SaveCurrent();
    }

    public void UpdateAmp()
    {
      bool flag = false;
      this.FillPatchFromEdit();
      for (int index = 0; index < 40; ++index)
      {
        if (this.m_PatchSentValues[index] != this.m_PatchFinalValues[index])
        {
          this.SendCC(Patch.s_PatchCCOrder[index], this.m_PatchFinalValues[index]);
          this.m_PatchSentValues[index] = this.m_PatchFinalValues[index];
          flag = true;
        }
      }
      if (!flag)
        return;
      this.SaveCurrent();
    }

    public int GetKnobRaw(Form1.Knobs _i)
    {
      return (int) Math.Round((Decimal) this.m_KnobsValues[(int) _i], 0);
    }

    public int GetTextSelector(Form1.TextSelectorList _i)
    {
      return this.m_TextSelectorValues[(int) _i];
    }

    public int GetImageSelector(Form1.ImgSelectorList _i)
    {
      return this.m_ImageSelectorValues[(int) _i];
    }

    public int GetOnOff(Form1.OnOff _i)
    {
      return !this.m_OnOffValues[(int) _i] ? 0 : 1;
    }

    public void SetKnobRaw(Form1.Knobs _i, int _val)
    {
      this.m_KnobsValues[(int) _i] = (float) _val;
    }

    public void SetTextSelector(Form1.TextSelectorList _i, int _val)
    {
      this.m_TextSelectorValues[(int) _i] = _val;
    }

    public void SetImageSelector(Form1.ImgSelectorList _i, int _val)
    {
      this.m_ImageSelectorValues[(int) _i] = _val;
    }

    public void SetOnOff(Form1.OnOff _i, int _val)
    {
      this.m_OnOffValues[(int) _i] = _val == 1;
    }

    public void FillPatchFromEdit()
    {
      int knobRaw = this.GetKnobRaw(Form1.Knobs.DEL_TIME);
      int num1 = knobRaw / 128;
      int num2 = knobRaw - num1 * 128;
      int num3 = this.GetKnobRaw(Form1.Knobs.PREFX_PARAM1);
      switch (this.m_TextSelectorValues[0])
      {
        case 1:
          num3 = this.GetTextSelector(Form1.TextSelectorList.DistortionType);
          break;
        case 2:
          num3 = this.GetTextSelector(Form1.TextSelectorList.WahType);
          break;
      }
      int num4 = 0;
      switch (this.m_TextSelectorValues[3])
      {
        case 0:
          num4 = this.GetTextSelector(Form1.TextSelectorList.ChorusType);
          break;
        case 1:
          num4 = this.GetTextSelector(Form1.TextSelectorList.FlangerType);
          break;
        case 2:
          num4 = this.GetTextSelector(Form1.TextSelectorList.PhaserType);
          break;
        case 3:
          num4 = this.GetTextSelector(Form1.TextSelectorList.TremoloType);
          break;
      }
      int num5 = this.GetKnobRaw(Form1.Knobs.DEL_AGE);
      if (this.m_TextSelectorValues[8] == 2)
        num5 = this.GetTextSelector(Form1.TextSelectorList.MultitapType);
      this.m_PatchFinalValues[0] = num1;
      this.m_PatchFinalValues[1] = num2;
      this.m_PatchFinalValues[2] = this.GetKnobRaw(Form1.Knobs.PREAMP_GAIN);
      this.m_PatchFinalValues[3] = this.GetKnobRaw(Form1.Knobs.PREAMP_BASS);
      this.m_PatchFinalValues[4] = this.GetKnobRaw(Form1.Knobs.PREAMP_MIDDLE);
      this.m_PatchFinalValues[5] = this.GetKnobRaw(Form1.Knobs.PREAMP_TREBLE);
      this.m_PatchFinalValues[6] = this.GetKnobRaw(Form1.Knobs.PREAMP_VOLUME);
      this.m_PatchFinalValues[7] = this.GetOnOff(Form1.OnOff.PREFX);
      this.m_PatchFinalValues[8] = this.GetTextSelector(Form1.TextSelectorList.PreFX);
      this.m_PatchFinalValues[9] = num3;
      this.m_PatchFinalValues[10] = this.GetKnobRaw(Form1.Knobs.PREFX_PARAM2);
      this.m_PatchFinalValues[11] = this.GetKnobRaw(Form1.Knobs.PREFX_PARAM3);
      this.m_PatchFinalValues[12] = this.GetKnobRaw(Form1.Knobs.PREFX_PARAM4);
      this.m_PatchFinalValues[13] = this.GetOnOff(Form1.OnOff.PREAMP);
      this.m_PatchFinalValues[14] = this.GetImageSelector(Form1.ImgSelectorList.Preamp);
      this.m_PatchFinalValues[15] = this.GetKnobRaw(Form1.Knobs.PREAMP_THRESHOLD);
      this.m_PatchFinalValues[16] = this.GetOnOff(Form1.OnOff.MOD);
      this.m_PatchFinalValues[17] = this.GetTextSelector(Form1.TextSelectorList.Mod);
      this.m_PatchFinalValues[18] = this.GetKnobRaw(Form1.Knobs.MOD_SPEED);
      this.m_PatchFinalValues[19] = this.GetKnobRaw(Form1.Knobs.MOD_DEPTH);
      this.m_PatchFinalValues[20] = num4;
      this.m_PatchFinalValues[21] = this.GetKnobRaw(Form1.Knobs.MOD_TONE);
      this.m_PatchFinalValues[22] = this.GetOnOff(Form1.OnOff.DELAY);
      this.m_PatchFinalValues[23] = this.GetTextSelector(Form1.TextSelectorList.DelayType);
      this.m_PatchFinalValues[24] = this.GetKnobRaw(Form1.Knobs.DEL_FEEDBACK);
      this.m_PatchFinalValues[25] = num5;
      this.m_PatchFinalValues[26] = this.GetKnobRaw(Form1.Knobs.DEL_LEVEL);
      this.m_PatchFinalValues[27] = this.GetOnOff(Form1.OnOff.REV);
      this.m_PatchFinalValues[28] = this.GetTextSelector(Form1.TextSelectorList.ReverbType);
      this.m_PatchFinalValues[29] = this.GetTextSelector(Form1.TextSelectorList.ReverbType);
      this.m_PatchFinalValues[30] = this.GetKnobRaw(Form1.Knobs.REV_DECAY);
      this.m_PatchFinalValues[31] = this.GetKnobRaw(Form1.Knobs.REV_PREDELAY);
      this.m_PatchFinalValues[32] = this.GetKnobRaw(Form1.Knobs.REV_TONE);
      this.m_PatchFinalValues[33] = this.GetKnobRaw(Form1.Knobs.REV_LEVEL);
      this.m_PatchFinalValues[34] = this.GetOnOff(Form1.OnOff.POWER);
      this.m_PatchFinalValues[35] = this.GetImageSelector(Form1.ImgSelectorList.Power);
      this.m_PatchFinalValues[36] = this.GetOnOff(Form1.OnOff.CAB);
      this.m_PatchFinalValues[37] = this.GetImageSelector(Form1.ImgSelectorList.Cab);
      this.m_PatchFinalValues[38] = this.GetKnobRaw(Form1.Knobs.POWER_PRESENCE);
      this.m_PatchFinalValues[39] = this.GetKnobRaw(Form1.Knobs.POWER_RESONANCE);
    }

    public void FillEditFromPatch(Form1 form)
    {
      if (!form.m_NameLCD.HasFocus)
        form.m_NameLCD.SetText(this.m_PatchName);
      if (!form.m_PatchNumLCD.HasFocus)
        form.m_PatchNumLCD.SetText(this.m_PatchNumber.ToString());
      int patchFinalValue1 = this.m_PatchFinalValues[0];
      int patchFinalValue2 = this.m_PatchFinalValues[1];
      this.SetKnobRaw(Form1.Knobs.PREAMP_GAIN, this.m_PatchFinalValues[2]);
      this.SetKnobRaw(Form1.Knobs.PREAMP_BASS, this.m_PatchFinalValues[3]);
      this.SetKnobRaw(Form1.Knobs.PREAMP_MIDDLE, this.m_PatchFinalValues[4]);
      this.SetKnobRaw(Form1.Knobs.PREAMP_TREBLE, this.m_PatchFinalValues[5]);
      this.SetKnobRaw(Form1.Knobs.PREAMP_VOLUME, this.m_PatchFinalValues[6]);
      this.SetOnOff(Form1.OnOff.PREFX, this.m_PatchFinalValues[7]);
      this.SetTextSelector(Form1.TextSelectorList.PreFX, this.m_PatchFinalValues[8]);
      int patchFinalValue3 = this.m_PatchFinalValues[9];
      this.SetKnobRaw(Form1.Knobs.PREFX_PARAM2, this.m_PatchFinalValues[10]);
      this.SetKnobRaw(Form1.Knobs.PREFX_PARAM3, this.m_PatchFinalValues[11]);
      this.SetKnobRaw(Form1.Knobs.PREFX_PARAM4, this.m_PatchFinalValues[12]);
      this.SetOnOff(Form1.OnOff.PREAMP, this.m_PatchFinalValues[13]);
      this.SetImageSelector(Form1.ImgSelectorList.Preamp, this.m_PatchFinalValues[14]);
      this.SetKnobRaw(Form1.Knobs.PREAMP_THRESHOLD, this.m_PatchFinalValues[15]);
      this.SetOnOff(Form1.OnOff.MOD, this.m_PatchFinalValues[16]);
      this.SetTextSelector(Form1.TextSelectorList.Mod, this.m_PatchFinalValues[17]);
      this.SetKnobRaw(Form1.Knobs.MOD_SPEED, this.m_PatchFinalValues[18]);
      this.SetKnobRaw(Form1.Knobs.MOD_DEPTH, this.m_PatchFinalValues[19]);
      int patchFinalValue4 = this.m_PatchFinalValues[20];
      this.SetKnobRaw(Form1.Knobs.MOD_TONE, this.m_PatchFinalValues[21]);
      this.SetOnOff(Form1.OnOff.DELAY, this.m_PatchFinalValues[22]);
      this.SetTextSelector(Form1.TextSelectorList.DelayType, this.m_PatchFinalValues[23]);
      this.SetKnobRaw(Form1.Knobs.DEL_FEEDBACK, this.m_PatchFinalValues[24]);
      int patchFinalValue5 = this.m_PatchFinalValues[25];
      this.SetKnobRaw(Form1.Knobs.DEL_LEVEL, this.m_PatchFinalValues[26]);
      this.SetOnOff(Form1.OnOff.REV, this.m_PatchFinalValues[27]);
      this.SetTextSelector(Form1.TextSelectorList.ReverbType, this.m_PatchFinalValues[28]);
      this.SetTextSelector(Form1.TextSelectorList.ReverbType, this.m_PatchFinalValues[29]);
      this.SetKnobRaw(Form1.Knobs.REV_DECAY, this.m_PatchFinalValues[30]);
      this.SetKnobRaw(Form1.Knobs.REV_PREDELAY, this.m_PatchFinalValues[31]);
      this.SetKnobRaw(Form1.Knobs.REV_TONE, this.m_PatchFinalValues[32]);
      this.SetKnobRaw(Form1.Knobs.REV_LEVEL, this.m_PatchFinalValues[33]);
      this.SetOnOff(Form1.OnOff.POWER, this.m_PatchFinalValues[34]);
      this.SetImageSelector(Form1.ImgSelectorList.Power, this.m_PatchFinalValues[35]);
      this.SetOnOff(Form1.OnOff.CAB, this.m_PatchFinalValues[36]);
      this.SetImageSelector(Form1.ImgSelectorList.Cab, this.m_PatchFinalValues[37]);
      this.SetKnobRaw(Form1.Knobs.POWER_PRESENCE, this.m_PatchFinalValues[38]);
      this.SetKnobRaw(Form1.Knobs.POWER_RESONANCE, this.m_PatchFinalValues[39]);
      for (int i = 0; i < 11; ++i)
        form.UpdateSelectorLists(i);
      this.SetKnobRaw(Form1.Knobs.DEL_TIME, patchFinalValue1 * 128 + patchFinalValue2);
      switch (this.m_TextSelectorValues[0])
      {
        case 1:
          this.SetTextSelector(Form1.TextSelectorList.DistortionType, patchFinalValue3);
          break;
        case 2:
          this.SetTextSelector(Form1.TextSelectorList.WahType, patchFinalValue3);
          break;
        default:
          this.SetKnobRaw(Form1.Knobs.PREFX_PARAM1, patchFinalValue3);
          break;
      }
      switch (this.m_TextSelectorValues[3])
      {
        case 0:
          this.SetTextSelector(Form1.TextSelectorList.ChorusType, patchFinalValue4);
          break;
        case 1:
          this.SetTextSelector(Form1.TextSelectorList.FlangerType, patchFinalValue4);
          break;
        case 2:
          this.SetTextSelector(Form1.TextSelectorList.PhaserType, patchFinalValue4);
          break;
        case 3:
          this.SetTextSelector(Form1.TextSelectorList.TremoloType, patchFinalValue4);
          break;
      }
      if (this.m_TextSelectorValues[8] == 2)
        this.SetTextSelector(Form1.TextSelectorList.MultitapType, patchFinalValue5);
      else
        this.SetKnobRaw(Form1.Knobs.DEL_AGE, patchFinalValue5);
    }

    private int[] LoadFileInternal(string FileName, ref string _patchname, bool bSetPatchNumber = false)
    {
      int[] numArray = new int[40];
      int num1;
      string str1;
      try
      {
        string str2 = File.ReadAllText(FileName);
        int index1 = 0;
        int startIndex1 = 0;
        int num2 = str2.IndexOf('|', startIndex1);
        if (num2 == -1)
          throw new Exception();
        num1 = int.Parse(str2.Substring(startIndex1, num2 - startIndex1));
        int startIndex2 = num2 + 1;
        int num3 = str2.IndexOf('|', startIndex2);
        if (num3 == -1)
          throw new Exception();
        str1 = str2.Substring(startIndex2, num3 - startIndex2);
        int startIndex3 = num3 + 1;
        for (int index2 = str2.IndexOf('|', startIndex3); index2 != -1; index2 = str2.IndexOf('|', startIndex3))
        {
          string s = str2.Substring(startIndex3, index2 - startIndex3);
          startIndex3 = index2 + 1;
          numArray[index1] = int.Parse(s);
          ++index1;
        }
        string s1 = str2.Substring(startIndex3);
        numArray[index1] = int.Parse(s1);
        if (index1 + 1 != 40)
          throw new Exception();
      }
      catch (Exception ex)
      {
        Logger.Log("Error while loading file : " + ex.ToString());
        if (!bSetPatchNumber)
        {
          int num2 = (int) MessageBox.Show("Error while loading file : " + ex.ToString(), "Code Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        return (int[]) null;
      }
      _patchname = str1;
      if (bSetPatchNumber)
        this.m_PatchNumber = num1;
      return numArray;
    }

    public void LoadFile(string FileName, Form1 form, bool bSetPatchNumber = false)
    {
      string _patchname = "";
      int[] numArray = this.LoadFileInternal(FileName, ref _patchname, bSetPatchNumber);
      if (numArray == null)
        return;
      numArray.CopyTo((Array) this.m_PatchFinalValues, 0);
      this.m_PatchName = _patchname;
      this.FillEditFromPatch(form);
    }

    public void LoadFileInSection(Form1.BitmapButtonList _type, string FileName, Form1 form)
    {
      string _patchname = "";
      int[] numArray = this.LoadFileInternal(FileName, ref _patchname, false);
      if (numArray == null)
        return;
      switch (_type)
      {
        case Form1.BitmapButtonList.IMPORT_MOD:
          this.m_PatchFinalValues[16] = numArray[16];
          this.m_PatchFinalValues[17] = numArray[17];
          this.m_PatchFinalValues[18] = numArray[18];
          this.m_PatchFinalValues[19] = numArray[19];
          this.m_PatchFinalValues[20] = numArray[20];
          this.m_PatchFinalValues[21] = numArray[21];
          break;
        case Form1.BitmapButtonList.IMPORT_PRE:
          this.m_PatchFinalValues[7] = numArray[7];
          this.m_PatchFinalValues[8] = numArray[8];
          this.m_PatchFinalValues[9] = numArray[9];
          this.m_PatchFinalValues[10] = numArray[10];
          this.m_PatchFinalValues[11] = numArray[11];
          this.m_PatchFinalValues[12] = numArray[12];
          break;
        case Form1.BitmapButtonList.IMPORT_REV:
          this.m_PatchFinalValues[27] = numArray[27];
          this.m_PatchFinalValues[28] = numArray[28];
          this.m_PatchFinalValues[29] = numArray[29];
          this.m_PatchFinalValues[30] = numArray[30];
          this.m_PatchFinalValues[31] = numArray[31];
          this.m_PatchFinalValues[32] = numArray[32];
          this.m_PatchFinalValues[33] = numArray[33];
          break;
        case Form1.BitmapButtonList.IMPORT_AMP:
          this.m_PatchFinalValues[2] = numArray[2];
          this.m_PatchFinalValues[3] = numArray[3];
          this.m_PatchFinalValues[4] = numArray[4];
          this.m_PatchFinalValues[5] = numArray[5];
          this.m_PatchFinalValues[6] = numArray[6];
          this.m_PatchFinalValues[13] = numArray[13];
          this.m_PatchFinalValues[14] = numArray[14];
          this.m_PatchFinalValues[15] = numArray[15];
          break;
        case Form1.BitmapButtonList.IMPORT_DEL:
          this.m_PatchFinalValues[0] = numArray[0];
          this.m_PatchFinalValues[1] = numArray[1];
          this.m_PatchFinalValues[22] = numArray[22];
          this.m_PatchFinalValues[23] = numArray[23];
          this.m_PatchFinalValues[24] = numArray[24];
          this.m_PatchFinalValues[25] = numArray[25];
          this.m_PatchFinalValues[26] = numArray[26];
          break;
        case Form1.BitmapButtonList.IMPORT_POW:
          this.m_PatchFinalValues[34] = numArray[34];
          this.m_PatchFinalValues[35] = numArray[35];
          this.m_PatchFinalValues[38] = numArray[38];
          this.m_PatchFinalValues[39] = numArray[39];
          break;
      }
      this.FillEditFromPatch(form);
    }

    public void SaveCurrent()
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CodePatchEditor");
      if (!Directory.Exists(path))
        return;
      this.SaveFile(path + "\\currpatch.mce");
    }

    public void LoadCurrent()
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CodePatchEditor");
      if (!Directory.Exists(path))
        return;
      this.LoadFile(path + "\\currpatch.mce", Form1.CurrentForm1, true);
    }

    public void SaveFile(string FileName)
    {
      this.FillPatchFromEdit();
      try
      {
        string contents = this.m_PatchNumber.ToString() + (object) '|' + this.m_PatchName.PadRight(18, ' ').Substring(0, 18) + (object) '|';
        for (int index = 0; index < 40; ++index)
        {
          contents += this.m_PatchFinalValues[index].ToString();
          if (index < 39)
            contents += (string) (object) '|';
        }
        File.WriteAllText(FileName, contents);
      }
      catch (Exception ex)
      {
        Logger.Log("Error while saving file : " + ex.ToString());
        int num = (int) MessageBox.Show("Error while saving file : " + ex.ToString(), "Code Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    public enum SysExError
    {
      NoError,
      Error_Bad_SysEx_Header,
      Error_Bad_Manufacturer_ID,
      Error_Bad_Family_ID,
      Error_Bad_Model_ID,
      Error_Bad_Device_ID,
      Error_Unrecognized_Command_Byte_1,
      Error_Unrecognized_Command_Byte_2,
      Error_Bad_Patch_Name_Size,
      Error_Bad_SysEx_Size,
    }
  }
}
