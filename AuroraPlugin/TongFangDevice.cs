using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aurora;
using Aurora.Devices;
using Aurora.Settings;
using Aurora.Utils;
using TongFang;

namespace TongFangAuroraPlugin
{
    public class TongFangDevice : DefaultDevice
    {
        public override string DeviceName => "TongFang";

        public override bool IsInitialized => Keyboard.IsConnected;

        public override bool Initialize()
        {
            var layout = Global.Configuration.VarRegistry.GetVariable<Layout>($"{DeviceName}_layout");
            var brightness = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_brightness");

            return Keyboard.Initialize(brightness, layout);
        }

        public override void Shutdown()
        {
            Keyboard.SetColorFull(Global.Configuration.VarRegistry.GetVariable<Color>($"{DeviceName}_restore_color"));
            Keyboard.Update();
            Keyboard.Disconnect();
        }

        public override bool UpdateDevice(Dictionary<DeviceKeys, System.Drawing.Color> keyColors, DoWorkEventArgs e, bool forced = false)
        {
            double rRatio = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_scalar_r") / 255.0;
            double gRatio = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_scalar_g") / 255.0;
            double bRatio = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_scalar_b") / 255.0;

            foreach (var kc in keyColors)
            {
                if (TongFangKeyMap.KeyMap.TryGetValue(kc.Key, out var key))
                {
                    var clr = Color.FromArgb((int)(rRatio * kc.Value.R), (int)(gRatio * kc.Value.G), (int)(bRatio * kc.Value.B));

                    Keyboard.SetKeyColor(key, ColorUtils.CorrectWithAlpha(clr));
                }
            }

            var delay = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_delay");
            if (delay > 0)
                Thread.Sleep(delay);

            return Keyboard.Update();
        }

        protected override void RegisterVariables(VariableRegistry variableRegistry)
        {
            variableRegistry.Register($"{DeviceName}_restore_color", new RealColor(Color.FromArgb(255, 0, 0, 255)), "Restore Color");
            variableRegistry.Register($"{DeviceName}_brightness", 50, "Brightness", 100, 1, "In percent");
            variableRegistry.Register($"{DeviceName}_layout", Layout.ANSI, "Layout", remark: "All options require a restart of the device integration.");
            variableRegistry.Register($"{DeviceName}_scalar_r", 255, "Red Scalar", 255, 0);
            variableRegistry.Register($"{DeviceName}_scalar_g", 255, "Green Scalar", 255, 0);
            variableRegistry.Register($"{DeviceName}_scalar_b", 255, "Blue Scalar", 255, 0);
            variableRegistry.Register($"{DeviceName}_sleep", 0, "Delay", 100, 0);
        }
    }
}
