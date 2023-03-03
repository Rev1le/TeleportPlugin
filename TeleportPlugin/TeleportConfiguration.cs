using Rocket.API;
using Rocket.Unturned.Player;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

namespace TeleportPlugin
{
    public class TeleportConfiguration : IRocketPluginConfiguration
    {

        public TeleportPlayer teleports;

        public void LoadDefaults()
        {
            teleports = new TeleportPlayer();
        }

    }

    public class TeleportPlayer
    {

        private List<TeleportPoint> TeleportPoints = new List<TeleportPoint>();

        public void AppendTeleportPoint(Vector3 positon, string player_name)
        {
            TeleportPoint teleport_point = new TeleportPoint();
            teleport_point.position = (positon.x, positon.y, positon.z);
            teleport_point.player_name = player_name;

            TeleportPoints.Add(teleport_point);

            StreamWriter sw = new StreamWriter("F:\\teleport_points.json");

            sw.Write(JsonConvert.SerializeObject(TeleportPoints));

            sw.Close();

        }

        public TeleportPoint GetRandomTeleportPoint()
        {

            int rand_point_index = UnityEngine.Random.Range(0, TeleportPoints.Count);

            return TeleportPoints[rand_point_index];
        }
    }

    public class TeleportPoint
    {
        public (float, float, float) position;
        public string player_name;

    }
}
