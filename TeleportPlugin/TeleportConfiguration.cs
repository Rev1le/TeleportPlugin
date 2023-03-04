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
            TeleportPoint teleport_point = new TeleportPoint(positon, player_name);

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

    public struct Position
    {
        public float x;
        public float y;
        public float z;
    }

    public class TeleportPoint
    {

        public Position position;
        
        public string player_name;


        public TeleportPoint(Vector3 pos, string player_name)
        {
            this.position.x = pos.x;
            this.position.y = pos.y;
            this.position.z = pos.z;

            this.player_name = player_name;

        }

    }
}
