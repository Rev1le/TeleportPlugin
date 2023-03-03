using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleportPlugin
{
    public class TeleportPlugin : RocketPlugin<TeleportConfiguration>
    {
        public static TeleportPlugin Instance;


        protected override void Load()
        {
            TeleportPlugin.Instance = this;
        }

        protected override void Unload()
        {

        }
    }
}
