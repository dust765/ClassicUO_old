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

using ClassicUO.Configuration;
// ## BEGIN - END ## //
using ClassicUO.Game.InteropServices.Runtime.UOClassicCombat;
// ## BEGIN - END ## //
using ClassicUO.Game.Data;
using ClassicUO.Game.Scenes;
using ClassicUO.IO;
using ClassicUO.IO.Resources;
using ClassicUO.Renderer;

namespace ClassicUO.Game.GameObjects
{
    internal sealed partial class Static
    {
        private int _canBeTransparent;

        public override bool TransparentTest(int z)
        {
            bool r = true;

            if (Z <= z - ItemData.Height)
            {
                r = false;
            }
            else if (z < Z && (_canBeTransparent & 0xFF) == 0)
            {
                r = false;
            }

            return r;
        }

        public override bool Draw(UltimaBatcher2D batcher, int posX, int posY)
        {
            if (!AllowedToDraw || IsDestroyed)
            {
                return false;
            }

            ushort graphic = Graphic;
            ushort hue = Hue;
            bool partial = ItemData.IsPartialHue;

            ResetHueVector();

            if (ProfileManager.CurrentProfile.HighlightGameObjects && SelectedObject.LastObject == this)
            {
                hue = Constants.HIGHLIGHT_CURRENT_OBJECT_HUE;
                partial = false;
            }
            else if (ProfileManager.CurrentProfile.NoColorObjectsOutOfRange && Distance > World.ClientViewRange)
            {
                hue = Constants.OUT_RANGE_COLOR;
                partial = false;
            }
            else if (World.Player.IsDead && ProfileManager.CurrentProfile.EnableBlackWhiteEffect)
            {
                hue = Constants.DEAD_RANGE_COLOR;
                partial = false;
            }

            ShaderHueTranslator.GetHueVector(ref HueVector, hue, partial, 0);

            // ## BEGIN - END ## //
            if (ProfileManager.CurrentProfile.HighlightTileAtRange && Distance == ProfileManager.CurrentProfile.HighlightTileAtRangeRange)
            {
                HueVector.X = ProfileManager.CurrentProfile.HighlightTileRangeHue;
                HueVector.Y = 1;
            }
            if (ProfileManager.CurrentProfile.HighlightTileAtRangeSpell)
            {
                if (GameCursor._spellTime >= 1 && Distance == ProfileManager.CurrentProfile.HighlightTileAtRangeRangeSpell)
                {
                    HueVector.X = ProfileManager.CurrentProfile.HighlightTileRangeHueSpell;
                    HueVector.Y = 1;
                }
            }
            if (ProfileManager.CurrentProfile.PreviewFields)
            {
                if (UOClassicCombatCollection.StaticFieldPreview(this))
                {
                    HueVector.X = 0x0040;
                    HueVector.Y = 1;
                }
                if (SelectedObject.LastObject == this)
                {
                    HueVector.X = 0x0023;
                    HueVector.Y = 1;
                }
            }
            // ## BEGIN - END ## //
            // ## BEGIN - END ## // ORIG
            /*
            bool isTree = StaticFilters.IsTree(graphic, out _);

            if (isTree && ProfileManager.CurrentProfile.TreeToStumps)
            {
                graphic = Constants.TREE_REPLACE_GRAPHIC;
            }
            */
            // ## BEGIN - END ## // ORIG
            graphic = UOClassicCombatCollection.ArtloaderFilters(graphic);

            bool isTree = StaticFilters.IsTree(graphic, out _);
            // ## BEGIN - END ## //

            if (AlphaHue != 255)
            {
                HueVector.Z = 1f - AlphaHue / 255f;
            }

            DrawStaticAnimated
            (
                batcher,
                graphic,
                posX,
                posY,
                ref HueVector,
                ref DrawTransparent,
                ProfileManager.CurrentProfile.ShadowsEnabled && ProfileManager.CurrentProfile.ShadowsStatics && (isTree || ItemData.IsFoliage || StaticFilters.IsRock(graphic))
            );

            if (ItemData.IsLight)
            {
                Client.Game.GetScene<GameScene>().AddLight(this, this, posX + 22, posY + 22);
            }

            if (!(SelectedObject.Object == this || FoliageIndex != -1 && Client.Game.GetScene<GameScene>().FoliageIndex == FoliageIndex))
            {
                if (DrawTransparent)
                {
                    return true;
                }

                ref UOFileIndex index = ref ArtLoader.Instance.GetValidRefEntry(graphic + 0x4000);

                posX -= index.Width;
                posY -= index.Height;

                if (SelectedObject.IsPointInStatic(ArtLoader.Instance.GetTexture(graphic), posX, posY))
                {
                    SelectedObject.Object = this;
                }
            }

            return true;
        }
    }
}