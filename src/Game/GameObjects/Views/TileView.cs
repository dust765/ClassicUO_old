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
// ## BEGIN - END ## // VISUAL HELPERS
// ## BEGIN - END ## // MISC2
using ClassicUO.Dust765.Dust765;
// ## BEGIN - END ## // MISC2
// ## BEGIN - END ## // VISUAL HELPERS
using ClassicUO.Renderer;
using Microsoft.Xna.Framework;

namespace ClassicUO.Game.GameObjects
{
    internal sealed partial class Land
    {
        public override bool Draw(UltimaBatcher2D batcher, int posX, int posY, ref Vector3 hueVec)
        {
            if (!AllowedToDraw || IsDestroyed)
            {
                return false;
            }

            //Engine.DebugInfo.LandsRendered++;

            hueVec = Vector3.Zero;

            ushort hue = Hue;

            if (ProfileManager.CurrentProfile.HighlightGameObjects && SelectedObject.LastObject == this)
            {
                hue = Constants.HIGHLIGHT_CURRENT_OBJECT_HUE;
            }
            else if (ProfileManager.CurrentProfile.NoColorObjectsOutOfRange && Distance > World.ClientViewRange)
            {
                hue = Constants.OUT_RANGE_COLOR;
            }
            else if (World.Player.IsDead && ProfileManager.CurrentProfile.EnableBlackWhiteEffect)
            {
                hue = Constants.DEAD_RANGE_COLOR;
            }


            if (hue != 0)
            {
                hueVec.X = hue - 1;
                hueVec.Y = IsStretched ? ShaderHueTranslator.SHADER_LAND_HUED : ShaderHueTranslator.SHADER_HUED;
            }
            else
            {
                hueVec.Y = IsStretched ? ShaderHueTranslator.SHADER_LAND : ShaderHueTranslator.SHADER_NONE;
            }

            // ## BEGIN - END ## // VISUAL HELPERS
            if (ProfileManager.CurrentProfile.HighlightTileAtRange && Distance == ProfileManager.CurrentProfile.HighlightTileAtRangeRange)
            {
                hueVec.X = ProfileManager.CurrentProfile.HighlightTileRangeHue;
                hueVec.Y = 1;
            }
            if (ProfileManager.CurrentProfile.HighlightTileAtRangeSpell)
            {
                if (GameCursor._spellTime >= 1 && Distance == ProfileManager.CurrentProfile.HighlightTileAtRangeRangeSpell)
                {
                    hueVec.X = ProfileManager.CurrentProfile.HighlightTileRangeHueSpell;
                    hueVec.Y = 1;
                }
            }
            if (ProfileManager.CurrentProfile.PreviewFields)
            {
                if (CombatCollection.LandFieldPreview(this))
                {
                    hueVec.X = 0x0040;
                    hueVec.Y = 1;
                }
                if (SelectedObject.LastObject == this)
                {
                    hueVec.X = 0x0023;
                    hueVec.Y = 1;
                }
            }
            // ## BEGIN - END ## // VISUAL HELPERS
            // ## BEGIN - END ## // MISC2
            if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.HueImpassableView)
            {
                if (this.TileData.IsImpassable)
                {
                    hueVec.X = ProfileManager.CurrentProfile.HueImpassableViewHue;
                    hueVec.Y = 1;
                }
            }
            // ## BEGIN - END ## // MISC2

            if (IsStretched)
            {
                posY += Z << 2;

                // ## BEGIN - END ## // MISC2
                /*
                DrawLand
                (
                    batcher,
                    Graphic,
                    posX,
                    posY,
                    ref YOffsets,
                    ref NormalTop,
                    ref NormalRight,
                    ref NormalLeft,
                    ref NormalBottom,
                    ref hueVec
                );
                */
                // ## BEGIN - END ## // MISC2
                if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.WireFrameView)
                {
                    DrawLandWF
                    (
                        batcher, Graphic, posX, posY, ref YOffsets, ref NormalTop, ref NormalRight, ref NormalLeft, ref NormalBottom,
                        ref hueVec, this.TileData.IsImpassable
                    );
                }
                else
                {
                    DrawLand
                    (
                        batcher,
                        Graphic,
                        posX,
                        posY,
                        ref YOffsets,
                        ref NormalTop,
                        ref NormalRight,
                        ref NormalLeft,
                        ref NormalBottom,
                        ref hueVec
                    );
                }
                // ## BEGIN - END ## // MISC2

                if (SelectedObject.IsPointInStretchedLand(ref YOffsets, posX, posY))
                {
                    SelectedObject.Object = this;
                }
            }
            else
            {
                // ## BEGIN - END ## // MISC2
                /*
                DrawLand
                (
                    batcher,
                    Graphic,
                    posX,
                    posY,
                    ref hueVec
                );
                */
                // ## BEGIN - END ## // MISC2
                if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.WireFrameView)
                {
                    DrawLandWF(batcher, Graphic, posX, posY, ref hueVec, this.TileData.IsImpassable);
                }
                else
                {
                    DrawLand
                    (
                        batcher,
                        Graphic,
                        posX,
                        posY,
                        ref hueVec
                    );
                }
                // ## BEGIN - END ## // MISC2

                if (SelectedObject.IsPointInLand(posX, posY))
                {
                    SelectedObject.Object = this;
                }
            }

            return true;
        }
    }
}