// Decompiled with JetBrains decompiler
// Type: CodeEditor.MidiCom
// Assembly: CodeEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A3DD43E-5EEA-4321-8BB2-B177FCA0FAE4
// Assembly location: C:\Program Files (x86)\CodeEditor\CodeEditor.exe

using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System;
using System.Threading;
using System.Timers;

namespace CodeEditor
{
  public class MidiCom
  {
    private static readonly object lock_obj = new object();
    private InputDevice inDevice;
    private OutputDevice outDevice;
    private SynchronizationContext context;
    private ChannelMessageBuilder builder;
    private System.Timers.Timer m_Timer;
    private bool m_Closing;

    public MidiCom()
    {
      this.context = SynchronizationContext.Current;
      this.builder = new ChannelMessageBuilder();
      this.m_Timer = new System.Timers.Timer(1000.0);
      this.m_Timer.Elapsed += (ElapsedEventHandler) ((sender, e) => MidiCom.MyElapsedMethod(sender, e, this));
      this.m_Timer.Enabled = true;
    }

    public bool Connect()
    {
      lock (MidiCom.lock_obj)
      {
        if (this.m_Closing || InputDevice.DeviceCount == 0)
          return false;
        if (!this.Connected())
        {
          try
          {
            int deviceID1 = -1;
            for (int deviceID2 = 0; deviceID2 < InputDevice.DeviceCount; ++deviceID2)
            {
              if (InputDevice.GetDeviceCapabilities(deviceID2).name.Contains("CODE"))
                deviceID1 = deviceID2;
            }
            if (deviceID1 == -1)
            {
              this.Disconnect();
              return false;
            }
            Logger.Log(string.Format("MIDI-in : CODE found on device #{0}", (object) deviceID1));
            this.inDevice = new InputDevice(deviceID1);
            this.inDevice.ChannelMessageReceived += new EventHandler<ChannelMessageEventArgs>(this.HandleChannelMessageReceived);
            this.inDevice.SysExMessageReceived += new EventHandler<SysExMessageEventArgs>(this.HandleSysExMessageReceived);
            this.inDevice.Error += new EventHandler<ErrorEventArgs>(this.inDevice_Error);
            this.inDevice.StartRecording();
            int deviceID3 = -1;
            for (int deviceID2 = 0; deviceID2 < OutputDeviceBase.DeviceCount; ++deviceID2)
            {
              if (OutputDeviceBase.GetDeviceCapabilities(deviceID2).name.Contains("CODE"))
                deviceID3 = deviceID2;
            }
            if (deviceID3 == -1)
            {
              this.Disconnect();
              return false;
            }
            Logger.Log(string.Format("MIDI-out : CODE found on device #{0}", (object) deviceID3));
            this.outDevice = new OutputDevice(deviceID3);
            this.outDevice.Error += new EventHandler<ErrorEventArgs>(this.inDevice_Error);
            this.outDevice.RunningStatusEnabled = false;
            Logger.Log("MIDI connected alright !");
          }
          catch (Exception ex)
          {
            Logger.Log("Exception while creating devices");
            this.Disconnect();
            return false;
          }
        }
        return true;
      }
    }

    private static void MyElapsedMethod(object sender, ElapsedEventArgs e, MidiCom Reference)
    {
      Reference.context.Post((SendOrPostCallback) (dummy => Reference.TimerTick()), (object) null);
    }

    public void SendNoteOff()
    {
      lock (MidiCom.lock_obj)
      {
        if (this.outDevice == null)
          return;
        try
        {
          this.builder.Command = ChannelCommand.NoteOff;
          this.builder.MidiChannel = 0;
          this.builder.Data1 = 0;
          this.builder.Data2 = 0;
          this.builder.Build();
          this.outDevice.Send(this.builder.Result);
        }
        catch
        {
          Logger.Log("MIDI Error while sending Note OFF");
          this.inDevice_Error((object) this, new ErrorEventArgs(new Exception()));
        }
      }
    }

    public void TimerTick()
    {
      lock (MidiCom.lock_obj)
      {
        if (this.m_Closing)
          return;
        if (this.Connected())
        {
          this.SendNoteOff();
        }
        else
        {
          this.Disconnect();
          this.Connect();
          if (!this.Connected())
            return;
          Form1.CurrentForm1.Invalidate();
        }
      }
    }

    public bool Connected()
    {
      lock (MidiCom.lock_obj)
        return this.inDevice != null && this.outDevice != null;
    }

    public void Close()
    {
      this.m_Closing = true;
      this.m_Timer.Enabled = false;
      this.m_Timer.Dispose();
      this.m_Timer = (System.Timers.Timer) null;
      this.Disconnect();
    }

    public void Disconnect()
    {
      lock (MidiCom.lock_obj)
      {
        InputDevice inDevice = this.inDevice;
        OutputDevice outDevice = this.outDevice;
        this.inDevice = (InputDevice) null;
        this.outDevice = (OutputDevice) null;
        if (inDevice != null)
        {
          Logger.Log("Disconnecting MIDI-in Device");
          try
          {
            inDevice.StopRecording();
          }
          catch (Exception ex)
          {
          }
          try
          {
            inDevice.Close();
          }
          catch (Exception ex)
          {
          }
          try
          {
            inDevice.Dispose();
          }
          catch (Exception ex)
          {
          }
        }
        if (outDevice != null)
        {
          Logger.Log("Disconnecting MIDI-out Device");
          try
          {
            outDevice.Close();
          }
          catch (Exception ex)
          {
          }
          try
          {
            outDevice.Dispose();
          }
          catch (Exception ex)
          {
          }
        }
        Form1.m_CurrentPatch.m_GETRequestWaiting = false;
      }
    }

    private void inDevice_Error(object sender, ErrorEventArgs e)
    {
      this.context.Post((SendOrPostCallback) (dummy =>
      {
        lock (MidiCom.lock_obj)
        {
          Logger.Log("MIDI Error !");
          this.Disconnect();
          Form1.CurrentForm1.Invalidate();
        }
      }), (object) null);
    }

    private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
    {
      this.context.Post((SendOrPostCallback) (dummy =>
      {
        if (e.Message.Command == ChannelCommand.Controller)
        {
          int data1 = e.Message.Data1;
          int data2 = e.Message.Data2;
          Form1.m_CurrentPatch.RecieveCC(data1, data2);
        }
        else
        {
          if (e.Message.Command != ChannelCommand.ProgramChange)
            return;
          Logger.Log(string.Format("Receiving PC {0}", (object) e.Message.Data1));
          Form1.m_CurrentPatch.ReceivePC(e.Message.Data1);
        }
      }), (object) null);
    }

    public void SendCC(int Num, int Value)
    {
      lock (MidiCom.lock_obj)
      {
        if (this.outDevice == null)
          return;
        try
        {
          this.builder.Command = ChannelCommand.Controller;
          this.builder.MidiChannel = 0;
          this.builder.Data1 = Num;
          this.builder.Data2 = Value;
          this.builder.Build();
          this.outDevice.Send(this.builder.Result);
        }
        catch
        {
          Logger.Log(string.Format("MIDI Error while sending CC {0} {1}", (object) Num, (object) Value));
          this.inDevice_Error((object) this, new ErrorEventArgs(new Exception()));
        }
      }
    }

    public void SendPC(int Num)
    {
      lock (MidiCom.lock_obj)
      {
        if (this.outDevice == null)
          return;
        try
        {
          Logger.Log(string.Format("Sending Program Change {0}", (object) Num));
          this.builder.Command = ChannelCommand.ProgramChange;
          this.builder.MidiChannel = 0;
          this.builder.Data1 = Num;
          this.builder.Data2 = 0;
          this.builder.Build();
          this.outDevice.Send(this.builder.Result);
        }
        catch
        {
          Logger.Log(string.Format("MIDI Error while sending PC {0}", (object) Num));
          this.inDevice_Error((object) this, new ErrorEventArgs(new Exception()));
        }
      }
    }

    public void SendSysEx(ref byte[] msg)
    {
      lock (MidiCom.lock_obj)
      {
        Logger.Log(string.Format("Sending SysEx of size {0}", (object) msg.Length));
        Logger.Log(msg);
        if (this.outDevice == null)
        {
          Logger.Log("FAILED : outDevice is NULL");
        }
        else
        {
          try
          {
            this.outDevice.Send(new SysExMessage(msg));
          }
          catch
          {
            Logger.Log("MIDI Error while sending SysEx");
            this.inDevice_Error((object) this, new ErrorEventArgs(new Exception()));
          }
        }
      }
    }

    private void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
    {
      this.context.Post((SendOrPostCallback) (dummy =>
      {
        byte[] bytes = e.Message.GetBytes();
        Logger.Log(string.Format("Receiving SysEx of size {0}", (object) bytes.Length));
        Logger.Log(bytes);
        Form1.m_CurrentPatch.DecodeSysexData(ref bytes);
      }), (object) null);
    }
  }
}
