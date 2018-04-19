using System;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Convex.Event;
using Convex.Plugin.Event;

namespace Convex.Plugin.Node_Network {
    public class LanguageReader : IPlugin {
        #region MEMBERS

        public string Name => "LanguageReader";
        public string Author => "Antonio DiNostri";
        public Version Version => new AssemblyName(GetType().GetTypeInfo().Assembly.FullName).Version;
        public string Id => Guid.NewGuid().ToString();
        public PluginStatus Status { get; } = PluginStatus.Stopped;

        #endregion

        #region INTERFACE IMPLEMENTATION

        public async Task Start() {
            throw new NotImplementedException();
        }

        public async Task Stop() {
            if (Status.Equals(PluginStatus.Running) || Status.Equals(PluginStatus.Processing)) {
                await Log($"Stop called but process is still running from: {Name}");
            } else {
                await Log($"Plugin stopped: {Name}");
            }
        }

        public async Task Call_Die() {
            throw new NotImplementedException();
        }

        public event AsyncEventHandler<PluginActionEventArgs> Callback;

        #endregion

        #region METHODS

        private async Task Log(params string[] args) {
            await DoCallback(this, new PluginActionEventArgs(PluginActionType.Log, string.Join(" ", args), Name));
        }

        private async Task DoCallback(object sender, PluginActionEventArgs args) {
            if (Callback == null)
                return;

            args.PluginName = Name;

            await Callback.Invoke(sender, args);
        }

        #endregion
    }
}
