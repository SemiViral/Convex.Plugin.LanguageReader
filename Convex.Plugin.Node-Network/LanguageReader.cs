using System;
using System.Reflection;
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

        public Task Start() {
            throw new NotImplementedException();
        }

        public Task Stop() {
            throw new NotImplementedException();
        }

        public Task Call_Die() {
            throw new NotImplementedException();
        }

        public event AsyncEventHandler<PluginActionEventArgs> Callback;

        #endregion
    }
}
