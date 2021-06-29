#region license

// Copyright (C) 2020 project dust765
// 
// This project is an alternative client for the game Ultima Online.
// The goal of this is to develop a lightweight client considering
// new technologies.
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using System;
using ClassicUO.Game.Managers;
using ClassicUO.IO.Resources;
using System.Text.RegularExpressions; //REGEX

namespace ClassicUO.Dust765.Dust765
{
    internal class ClilocTriggers
    {
        private static int[] _startBandiesAtClilocs = new int[]
        {
            500956,
            500957,
            500958,
            500959,
            500960
        };
        private static int[] _stopBandiesAtClilocs = new int[]
        {
            500955,
            500962,
            500963,
            500964,
            500965,
            500966,
            500967,
            500968,
            500969,
            503252,
            503253,
            503254,
            503255,
            503256,
            503257,
            503258,
            503259,
            503260,
            503261,
            1010058,
            1010648,
            1010650,
            1060088,
            1060167
        };
        private static int[] _disarmedAtClilocs = new int[]
        {
            501708, //I have been disarmed.
            1004007 //You have been disarmed!
        };
        public void OnMessage(string text, ushort hue, string name, bool isunicode = true)
        {
            UOClassicCombatBuffbar UOClassicCombatBuffbar = UIManager.GetGump<UOClassicCombatBuffbar>();

            //SYS MESSAGES ONLY
            if (name != "System" && text.Length <= 0)
                return;

            //GOT DISARMED
            for (int i = 0; i < _disarmedAtClilocs.Length; i++)
            {
                if (ClilocLoader.Instance.GetString(_disarmedAtClilocs[i]) == null)
                    continue;

                if (text.StartsWith(ClilocLoader.Instance.GetString(_disarmedAtClilocs[i])))
                {
                    UOClassicCombatBuffbar?.ClilocTriggerGotDisarmed();

                    return;
                }
            }
            if (text.StartsWith("Their attack disarms you!"))
            {
                UOClassicCombatBuffbar?.ClilocTriggerGotDisarmed();
                return;
            }

            //DISARM
            if (text.StartsWith("You will now attempt to disarm your opponents."))
            {
                UOClassicCombatBuffbar?.ClilocTriggerDisarmON();
                return;
            }
            if (text.StartsWith("You refrain from making disarm attempts."))
            {
                UOClassicCombatBuffbar?.ClilocTriggerDisarmOFF();
                return;
            }
            //SUCCESSFUL DISARM MSGES
            if (text.StartsWith("You disarm their weapon!"))
            {
                UOClassicCombatBuffbar?.ClilocTriggerDisarmStriked();
                return;
            }
            if (text.StartsWith("Your strike disarms your target!"))
            {
                UOClassicCombatBuffbar?.ClilocTriggerDisarmStriked();
                return;
            }
            if (text.StartsWith("You successfully disarm your opponent!"))
            {
                UOClassicCombatBuffbar?.ClilocTriggerDisarmStriked();
                return;
            }
            //FAILED DISARM MSGES
            if (text.StartsWith("You fail to disarm your opponent."))
            {
                UOClassicCombatBuffbar?.ClilocTriggerDisarmFailed();
                return;
            }
            if (text.StartsWith("You failed in your attempt do disarm."))
            {
                UOClassicCombatBuffbar?.ClilocTriggerDisarmFailed();
                return;
            }
        }
        public void OnCliloc(uint cliloc)
        {
            UOClassicCombatBuffbar UOClassicCombatBuffbar = UIManager.GetGump<UOClassicCombatBuffbar>();

            //GOT DISARMED
            for (int i = 0; i < _disarmedAtClilocs.Length; i++)
            {
                if (_disarmedAtClilocs[i] == cliloc)
                {
                    UOClassicCombatBuffbar?.ClilocTriggerGotDisarmed();
                    return;
                }
            }
        }
    }
}