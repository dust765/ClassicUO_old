#region license

// Copyright (c) 2021, andreakarasho
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 1. Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 3. All advertising materials mentioning features or use of this software
//    must display the following acknowledgement:
//    This product includes software developed by andreakarasho - https://github.com/andreakarasho
// 4. Neither the name of the copyright holder nor the
//    names of its contributors may be used to endorse or promote products
//    derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS ''AS IS'' AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Resources;
// ## BEGIN - END ## // NAMEOVERHEAD
using ClassicUO.Configuration;
// ## BEGIN - END ## // NAMEOVERHEAD

namespace ClassicUO.Game.UI.Gumps
{
    internal class NameOverHeadHandlerGump : Gump
    {
        private static int _lastX = 100, _lastY = 100;

        public NameOverHeadHandlerGump() : base(0, 0)
        {
            CanMove = true;
            AcceptMouseInput = true;
            CanCloseWithRightClick = true;
            X = _lastX;
            Y = _lastY;
            WantUpdateSize = false;

            LayerOrder = UILayer.Over;

            // ## BEGIN - END ## // NAMEOVERHEAD
            //RadioButton all, mobiles, items, mobilesCorpses;
            // ## BEGIN - END ## // NAMEOVERHEAD
            RadioButton all, mobiles, items, mobilesCorpses, custom;
            Checkbox cbcorpses, cbitems, cbmobiles, cbhumanMobilesOnly;
            Checkbox cbnotoall, cbnotoblue, cbnotored, cbnotoorange, cbnotocriminal, cbnotoally;
            // ## BEGIN - END ## // NAMEOVERHEAD

            AlphaBlendControl alpha;

            Add
            (
                alpha = new AlphaBlendControl(0.2f)
                {
                    Hue = 34
                }
            );


            Add
            (
                all = new RadioButton
                (
                    0,
                    0x00D0,
                    0x00D1,
                    ResGumps.All,
                    color: 0xFFFF
                )
                {
                    IsChecked = NameOverHeadManager.TypeAllowed == NameOverheadTypeAllowed.All
                }
            );

            Add
            (
                mobiles = new RadioButton
                (
                    0,
                    0x00D0,
                    0x00D1,
                    ResGumps.MobilesOnly,
                    color: 0xFFFF
                )
                {
                    Y = all.Y + all.Height,
                    IsChecked = NameOverHeadManager.TypeAllowed == NameOverheadTypeAllowed.Mobiles
                }
            );

            Add
            (
                items = new RadioButton
                (
                    0,
                    0x00D0,
                    0x00D1,
                    ResGumps.ItemsOnly,
                    color: 0xFFFF
                )
                {
                    Y = mobiles.Y + mobiles.Height,
                    IsChecked = NameOverHeadManager.TypeAllowed == NameOverheadTypeAllowed.Items
                }
            );

            Add
            (
                mobilesCorpses = new RadioButton
                (
                    0,
                    0x00D0,
                    0x00D1,
                    ResGumps.MobilesAndCorpsesOnly,
                    color: 0xFFFF
                )
                {
                    Y = items.Y + items.Height,
                    IsChecked = NameOverHeadManager.TypeAllowed == NameOverheadTypeAllowed.MobilesCorpses
                }
            );

            // ## BEGIN - END ## // NAMEOVERHEAD
            Add
            (
                custom = new RadioButton
                (
                    0,
                    0x00D0,
                    0x00D1,
                    "Custom",
                    color: 0xFFFF
                )
                {
                    Y = mobilesCorpses.Y + mobilesCorpses.Height,
                    IsChecked = NameOverHeadManager.TypeAllowed == NameOverheadTypeAllowed.Custom
                }
            );
            //
            Add
            (
                cbitems = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Show Items",
                color: 0xFFFF
                )
                {
                    Y = custom.Y + custom.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbitems
                }
            );
            Add
            (
                cbcorpses = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Show Corpses",
                color: 0xFFFF
                )
                {
                    Y = cbitems.Y + cbitems.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbcorpses
                }
            );
            Add
            (
                cbmobiles = new Checkbox
                (
                0x00D2,
                0x00D3,
                "All Mobiles",
                color: 0xFFFF
                )
                {
                    Y = cbcorpses.Y + cbcorpses.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbmobiles
                }
            );
            Add
            (
                cbhumanMobilesOnly = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Human Mobiles Only",
                color: 0xFFFF
                )
                {
                    Y = cbmobiles.Y + cbmobiles.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbhumanMobilesOnly
                }
            );
            //
            Add
            (
                cbnotoall = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Noto: All",
                color: 0xFFFF
                )
                {
                    Y = cbhumanMobilesOnly.Y + cbhumanMobilesOnly.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbnotoall
                }
            );
            Add
            (
                cbnotoblue = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Noto: Blue",
                color: 0xFFFF
                )
                {
                    Y = cbnotoall.Y + cbnotoall.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbnotoblue
                }
            );
            Add
            (
                cbnotored = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Noto: Red",
                color: 0xFFFF
                )
                {
                    Y = cbnotoblue.Y + cbnotoblue.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbnotored
                }
            );
            Add
            (
                cbnotoorange = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Noto: Orange",
                color: 0xFFFF
                )
                {
                    Y = cbnotored.Y + cbnotored.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbnotoorange
                }
            );
            Add
            (
                cbnotocriminal = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Noto: Criminal & Gray",
                color: 0xFFFF
                )
                {
                    Y = cbnotoorange.Y + cbnotoorange.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbnotocriminal
                }
            );
            Add
            (
                cbnotoally = new Checkbox
                (
                0x00D2,
                0x00D3,
                "Noto: Ally",
                color: 0xFFFF
                )
                {
                    Y = cbnotocriminal.Y + cbnotocriminal.Height,
                    IsChecked = ProfileManager.CurrentProfile.NOH_cbnotoally
                }
            );
            // ## BEGIN - END ## // NAMEOVERHEAD

            alpha.Width = Math.Max(mobilesCorpses.Width, Math.Max(items.Width, Math.Max(all.Width, mobiles.Width)));
            // ## BEGIN - END ## // NAMEOVERHEAD
            //alpha.Height = all.Height + mobiles.Height + items.Height + mobilesCorpses.Height;
            // ## BEGIN - END ## // NAMEOVERHEAD
            alpha.Height = all.Height + mobiles.Height + items.Height + mobilesCorpses.Height
                + custom.Height +
                cbitems.Height + cbcorpses.Height + cbmobiles.Height + cbhumanMobilesOnly.Height +
                cbnotoall.Height + cbnotoblue.Height + cbnotored.Height + cbnotoorange.Height + cbnotocriminal.Height + cbnotoally.Height;
            // ## BEGIN - END ## // NAMEOVERHEAD

            Width = alpha.Width;
            Height = alpha.Height;

            all.ValueChanged += (sender, e) =>
            {
                if (all.IsChecked)
                {
                    NameOverHeadManager.TypeAllowed = NameOverheadTypeAllowed.All;
                }
            };

            mobiles.ValueChanged += (sender, e) =>
            {
                if (mobiles.IsChecked)
                {
                    NameOverHeadManager.TypeAllowed = NameOverheadTypeAllowed.Mobiles;
                }
            };

            items.ValueChanged += (sender, e) =>
            {
                if (items.IsChecked)
                {
                    NameOverHeadManager.TypeAllowed = NameOverheadTypeAllowed.Items;
                }
            };

            mobilesCorpses.ValueChanged += (sender, e) =>
            {
                if (mobilesCorpses.IsChecked)
                {
                    NameOverHeadManager.TypeAllowed = NameOverheadTypeAllowed.MobilesCorpses;
                }
            };

            // ## BEGIN - END ## // NAMEOVERHEAD
            custom.ValueChanged += (sender, e) =>
            {
                if (custom.IsChecked)
                {
                    NameOverHeadManager.TypeAllowed = NameOverheadTypeAllowed.Custom;
                }
            };
            //
            cbitems.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbitems = cbitems.IsChecked;
            };
            cbcorpses.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbcorpses = cbcorpses.IsChecked;
            };
            cbmobiles.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbmobiles = cbmobiles.IsChecked;
            };
            cbhumanMobilesOnly.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbhumanMobilesOnly = cbhumanMobilesOnly.IsChecked;
            };
            //
            cbnotoall.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbnotoall = cbnotoall.IsChecked;
            };
            cbnotoblue.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbnotoblue = cbnotoblue.IsChecked;
            };
            cbnotored.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbnotored = cbnotored.IsChecked;
            };
            cbnotoorange.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbnotoorange = cbnotoorange.IsChecked;
            };
            cbnotocriminal.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbnotocriminal = cbnotocriminal.IsChecked;
            };
            cbnotoally.ValueChanged += (sender, e) =>
            {
                ProfileManager.CurrentProfile.NOH_cbnotoally = cbnotoally.IsChecked;
            };
            // ## BEGIN - END ## // NAMEOVERHEAD
        }


        protected override void OnDragEnd(int x, int y)
        {
            _lastX = ScreenCoordinateX;
            _lastY = ScreenCoordinateY;
            SetInScreen();

            base.OnDragEnd(x, y);
        }
    }
}