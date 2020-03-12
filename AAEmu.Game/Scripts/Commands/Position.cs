﻿using AAEmu.Game.Core.Managers;
using AAEmu.Game.Models.Game;
using AAEmu.Game.Models.Game.Char;

namespace AAEmu.Game.Scripts.Commands
{
    public class Position : ICommand
    {
        public void OnLoad()
        {
            string[] names = { "position", "pos" };
            CommandManager.Instance.Register(names, this);
        }

        public string GetCommandLineHelp()
        {
            return "[rot]";
        }

        public string GetCommandHelpText()
        {
            return "Displays information about your and the position of your target if selected.\n" +
                "If a argument is set, your rotation information will also be displayed.";
        }

        public void Execute(Character character, string[] args)
        {
            var position = character.CurrentTarget?.Position ?? character.Position;
            character.SendMessage("[Position] X: {0}, Y: {1}, Z: {2}, ZoneId: {3}", position.X, position.Y, position.Z,
                position.ZoneId);

            if (args.Length > 0)
                character.SendMessage("[Position] RotX: {0}, RotY: {1}, RotZ: {2}", position.RotationX,
                    position.RotationY,
                    position.RotationZ);

            if (character.CurrentTarget != null)
            {
                var rx = character.Position.X - character.CurrentTarget.Position.X;
                var ry = character.Position.Y - character.CurrentTarget.Position.Y;
                character.SendMessage("[Position][Relative] X: {0}, Y: {1}", rx, ry);
            }
        }
    }
}
