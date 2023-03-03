using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TeleportPlugin
{
    public class TeleportCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "pl_teleport";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string> { "pl_tp" };

        public List<string> Permissions => new List<string> { "plugin.teleport" };

        public void Execute(IRocketPlayer caller, string[] command)
        {

            UnturnedPlayer player = (UnturnedPlayer) caller;

            switch (command.Length) 
            {

                // Если игрок вводит только команду /tp
                case 0:
                    
                    TeleportPoint random_teleport_position = TeleportPlugin
                        .Instance
                        .Configuration
                        .Instance
                        .teleports
                        .GetRandomTeleportPoint();
                    
                    string pos = random_teleport_position.position.ToString();
                    UnturnedChat.Say(player, pos);

                    player.Teleport(new Vector3(random_teleport_position.position.Item1, random_teleport_position.position.Item2, random_teleport_position.position.Item3), player.Rotation);
                    break;

                // Если игрок вводит команду с аргументом 'set' /tp set
                case 1:

                    if (command[0] != "set")
                    {
                        UnturnedChat.Say(player, "Неверное кол-во аргументов");
                    }

                    Vector3 teleport_point_position = player.Position;

                    string pos_tweo = teleport_point_position.ToString();
                    UnturnedChat.Say(player, pos_tweo);

                    TeleportPlugin
                        .Instance
                        .Configuration
                        .Instance
                        .teleports
                        .AppendTeleportPoint(teleport_point_position, player.DisplayName);
                    
                    TeleportPlugin
                        .Instance
                        .Configuration
                        .Save();

                    break;

                // Если игрок вводит неверную комманду
                default:
                    
                    UnturnedChat.Say(player, "Неверное кол-во аргументов");
                    break;

            }

            if (command.Length > 1)
            {

            } 

        }
    }
}
