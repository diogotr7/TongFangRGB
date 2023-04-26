using Aurora;
using Aurora.Devices;
using Aurora.Settings;
using Aurora.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using TongFang;

namespace TongFangAuroraPlugin
{
    public class TongFangDevice : DefaultDevice
    {
        public override string DeviceName => "TongFang";

        public override bool IsInitialized { get; protected set; }

        private ITongFangKeyboard _keyboard;
        private Layout _layout;

        protected override Task<bool> DoInitialize()
        {
            _layout = Global.Configuration.VarRegistry.GetVariable<Layout>($"{DeviceName}_layout");

            return Task.FromResult(IsInitialized = TongFindFinder.TryFind(out _keyboard));
        }

        public override Task Shutdown()
        {
            _keyboard.SetColor(0, 0, 0);
            _keyboard.Update();
            _keyboard.Dispose();
            IsInitialized = false;
            return Task.CompletedTask;
        }

        protected override Task<bool> UpdateDevice(Dictionary<DeviceKeys, Color> keyColors, DoWorkEventArgs e, bool forced = false)
        {
            double rRatio = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_scalar_r") / 255.0;
            double gRatio = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_scalar_g") / 255.0;
            double bRatio = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_scalar_b") / 255.0;

            foreach (var kc in keyColors)
            {
                if (TongFangKeyMap.Coords[_layout].TryGetValue(kc.Key, out var key))
                {
                    var clr = Color.FromArgb((int)(rRatio * kc.Value.R), (int)(gRatio * kc.Value.G), (int)(bRatio * kc.Value.B));
                    var corrected = ColorUtils.CorrectWithAlpha(clr);

                    _keyboard.SetCoordColor(key.Row, key.Column, corrected.R, corrected.G, corrected.B);
                }
            }

            var delay = Global.Configuration.VarRegistry.GetVariable<int>($"{DeviceName}_delay");
            if (delay > 0)
                Thread.Sleep(delay);

            _keyboard.Update();

            return Task.FromResult(true);
        }

        protected override void RegisterVariables(VariableRegistry variableRegistry)
        {
            variableRegistry.Register($"{DeviceName}_restore_color", new RealColor(Color.FromArgb(255, 0, 0, 255)), "Restore Color");
            variableRegistry.Register($"{DeviceName}_layout", Layout.ANSI, "Layout", remark: "All options require a restart of the device integration.");
            variableRegistry.Register($"{DeviceName}_scalar_r", 255, "Red Scalar", 255, 0);
            variableRegistry.Register($"{DeviceName}_scalar_g", 255, "Green Scalar", 255, 0);
            variableRegistry.Register($"{DeviceName}_scalar_b", 255, "Blue Scalar", 255, 0);
            variableRegistry.Register($"{DeviceName}_sleep", 0, "Delay", 100, 0);
        }
    }
}
