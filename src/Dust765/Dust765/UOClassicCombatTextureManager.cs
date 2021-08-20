using System.IO;

using ClassicUO.Configuration;
using ClassicUO.Game;
using ClassicUO.Game.Data;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Renderer;
using ClassicUO.IO.Resources;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClassicUO.Dust765.Dust765
{
    internal class TextureManager
    {
        public bool IsEnabled => ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.TextureManagerEnabled;
        public bool IsArrowEnabled => ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.TextureManagerArrows;
        public bool IsHalosEnabled => ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.TextureManagerHalos;


        private static BlendState _blend = new BlendState
        {
            ColorSourceBlend = Blend.SourceAlpha,
            ColorDestinationBlend = Blend.InverseSourceAlpha
        };

        private static Vector3 _hueVector = Vector3.Zero;

        //TEXTURES ARROW
        private int ARROW_WIDTH_HALF = 14;
        private int ARROW_HEIGHT_HALF = 14;

        private static UOTexture _arrowGreen;
        public static UOTexture ArrowGreen
        {
            get
            {
                if (_arrowGreen == null || _arrowGreen.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.arrow_green.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels);

                    _arrowGreen = new UOTexture(w, h);
                    _arrowGreen.SetData(pixels);
                }

                return _arrowGreen;
            }
        }

        private static UOTexture _arrowPurple;
        public static UOTexture ArrowPurple
        {
            get
            {
                if (_arrowPurple == null || _arrowPurple.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.arrow_purple.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels);

                    _arrowPurple = new UOTexture(w, h);
                    _arrowPurple.SetData(pixels);
                }

                return _arrowPurple;
            }
        }

        private static UOTexture _arrowRed;
        public static UOTexture ArrowRed
        {
            get
            {
                if (_arrowRed == null || _arrowRed.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.arrow_red.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels);

                    _arrowRed = new UOTexture(w, h);
                    _arrowRed.SetData(pixels);
                }

                return _arrowRed;
            }
        }

        private static UOTexture _arrowYellow;
        public static UOTexture ArrowYellow
        {
            get
            {
                if (_arrowYellow == null || _arrowYellow.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.arrow_yellow.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels);

                    _arrowYellow = new UOTexture(w, h);
                    _arrowYellow.SetData(pixels);
                }

                return _arrowYellow;
            }
        }

        private static UOTexture _arrowOrange;
        public static UOTexture ArrowOrange
        {
            get
            {
                if (_arrowOrange == null || _arrowOrange.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.arrow_orange.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels);

                    _arrowOrange = new UOTexture(w, h);
                    _arrowOrange.SetData(pixels);
                }

                return _arrowOrange;
            }
        }

        private static UOTexture _arrowBlue;
        public static UOTexture ArrowBlue
        {
            get
            {
                if (_arrowBlue == null || _arrowBlue.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.arrow_blue2.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels);

                    _arrowBlue = new UOTexture(w, h);
                    _arrowBlue.SetData(pixels);
                }

                return _arrowBlue;
            }
        }
        //TEXTURES HALO
        private int HALO_WIDTH_HALF = 25;

        private static UOTexture _haloGreen;
        private static UOTexture HaloGreen
        {
            get
            {
                if (_haloGreen == null || _haloGreen.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.halo_green.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels, 50, 27);

                    _haloGreen = new UOTexture(w, h);
                    _haloGreen.SetData(pixels);
                }

                return _haloGreen;
            }
        }

        private static UOTexture _haloPurple;
        private static UOTexture HaloPurple
        {
            get
            {
                if (_haloPurple == null || _haloPurple.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.halo_purple.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels, 50, 27);

                    _haloPurple = new UOTexture(w, h);
                    _haloPurple.SetData(pixels);
                }

                return _haloPurple;
            }
        }

        private static UOTexture _haloRed;
        private static UOTexture HaloRed
        {
            get
            {
                if (_haloRed == null || _haloRed.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.halo_red.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels, 50, 27);

                    _haloRed = new UOTexture(w, h);
                    _haloRed.SetData(pixels);
                }

                return _haloRed;
            }
        }

        private static UOTexture _haloWhite;
        private static UOTexture HaloWhite
        {
            get
            {
                if (_haloWhite == null || _haloWhite.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.halo_white.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels, 50, 27);

                    _haloWhite = new UOTexture(w, h);
                    _haloWhite.SetData(pixels);
                }

                return _haloWhite;
            }
        }

        private static UOTexture _haloYellow;
        private static UOTexture HaloYellow
        {
            get
            {
                if (_haloYellow == null || _haloYellow.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.halo_yellow.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels, 50, 27);

                    _haloYellow = new UOTexture(w, h);
                    _haloYellow.SetData(pixels);
                }

                return _haloYellow;
            }
        }

        private static UOTexture _haloOrange;
        private static UOTexture HaloOrange
        {
            get
            {
                if (_haloOrange == null || _haloOrange.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.halo_orange.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels, 50, 27);

                    _haloOrange = new UOTexture(w, h);
                    _haloOrange.SetData(pixels);
                }

                return _haloOrange;
            }
        }

        private static UOTexture _haloBlue;
        private static UOTexture HaloBlue
        {
            get
            {
                if (_haloBlue == null || _haloBlue.IsDisposed)
                {
                    Stream stream = typeof(CUOEnviroment).Assembly.GetManifestResourceStream("ClassicUO.halo_blue2.png");
                    Texture2D.TextureDataFromStreamEXT(stream, out int w, out int h, out byte[] pixels, 50, 27);

                    _haloBlue = new UOTexture(w, h);
                    _haloBlue.SetData(pixels);
                }

                return _haloBlue;
            }
        }
        //TEXTURES END
        public void Draw(UltimaBatcher2D batcher)
        {
            if (!IsEnabled)
                return;

            if (World.Player == null)
                return;

            foreach (Mobile mobile in World.Mobiles.Values)
            {
                //SKIP FOR PLAYER
                if (mobile == World.Player)
                    continue;

                _hueVector.Z = 0f;

                if (IsHalosEnabled && (HaloOrange != null || HaloGreen != null || HaloPurple != null || HaloRed != null || HaloBlue != null))
                {
                    //CALC WHERE MOBILE IS
                    Point pm = CombatCollection.CalcUnderChar(mobile);
                    //Move from center by half texture width
                    pm.X -= HALO_WIDTH_HALF;

                    _hueVector.Y = ShaderHueTranslator.SHADER_LIGHTS;
                    batcher.SetBlendState(_blend);

                    //HUMANS ONLY
                    if (ProfileManager.CurrentProfile.TextureManagerHumansOnly && !mobile.IsHuman)
                    {

                    }
                    else
                    {
                        //PURPLE HALO FOR: LAST ATTACK, LASTTARGET
                        if ((TargetManager.LastAttack == mobile.Serial & TargetManager.LastAttack != 0 & ProfileManager.CurrentProfile.TextureManagerPurple) || (TargetManager.LastTargetInfo.Serial == mobile.Serial & TargetManager.LastTargetInfo.Serial != 0 & ProfileManager.CurrentProfile.TextureManagerPurple))
                            batcher.Draw2D(HaloPurple, pm.X, pm.Y - 15, HaloPurple.Width, HaloPurple.Height, ref _hueVector);
                        //GREEN HALO FOR: ALLYS AND PARTY
                        else if (mobile.NotorietyFlag == NotorietyFlag.Ally & ProfileManager.CurrentProfile.TextureManagerGreen || World.Party.Contains(mobile.Serial) & ProfileManager.CurrentProfile.TextureManagerGreen)
                            batcher.Draw2D(HaloGreen, pm.X, pm.Y - 15, HaloGreen.Width, HaloGreen.Height, ref _hueVector);
                        //RED HALO FOR: CRIMINALS, GRAY, MURDERER
                        else if (mobile.NotorietyFlag == NotorietyFlag.Criminal || mobile.NotorietyFlag == NotorietyFlag.Gray || mobile.NotorietyFlag == NotorietyFlag.Murderer)
                        {
                            if (ProfileManager.CurrentProfile.TextureManagerRed)
                            {
                                batcher.Draw2D(HaloRed, pm.X, pm.Y - 15, HaloRed.Width, HaloRed.Height, ref _hueVector);
                            }
                        }
                        //ORANGE HALO FOR: ENEMY
                        else if (mobile.NotorietyFlag == NotorietyFlag.Enemy & ProfileManager.CurrentProfile.TextureManagerOrange)
                            batcher.Draw2D(HaloOrange, pm.X, pm.Y - 15, HaloOrange.Width, HaloOrange.Height, ref _hueVector);
                        //BLUE HALO FOR: INNOCENT
                        else if (mobile.NotorietyFlag == NotorietyFlag.Innocent & ProfileManager.CurrentProfile.TextureManagerBlue)
                            batcher.Draw2D(HaloBlue, pm.X, pm.Y - 15, HaloBlue.Width, HaloBlue.Height, ref _hueVector);
                    }

                    batcher.SetBlendState(null);
                }
                //HALO TEXTURE

                //ARROW TEXTURE
                if (IsArrowEnabled && (ArrowGreen != null || ArrowRed != null || ArrowPurple != null || ArrowOrange != null || ArrowBlue != null))
                {
                    //CALC MOBILE HEIGHT FROM ANIMATION
                    Point p1 = CombatCollection.CalcOverChar(mobile);
                    //Move from center by half texture width
                    p1.X -= ARROW_WIDTH_HALF;
                    p1.Y -= ARROW_HEIGHT_HALF;

                    /* MAYBE USE THIS INCASE IT SHOWS OUTSIDE OF GAMESCREEN?
                    if (!(p1.X < 0 || p1.X > screenW - mobile.HitsTexture.Width || p1.Y < 0 || p1.Y > screenH))
                                {
                                    mobile.HitsTexture.Draw(batcher, p1.X, p1.Y);
                                }
                    */

                    _hueVector.Y = ShaderHueTranslator.SHADER_LIGHTS;
                    batcher.SetBlendState(_blend);

                    //HUMANS ONLY
                    if (ProfileManager.CurrentProfile.TextureManagerHumansOnlyArrows && !mobile.IsHuman)
                    {
                        batcher.SetBlendState(null);
                        continue;
                    }

                    //PURPLE ARROW FOR: LAST ATTACK, LASTTARGET
                    if ((TargetManager.LastAttack == mobile.Serial & TargetManager.LastAttack != 0 & ProfileManager.CurrentProfile.TextureManagerPurpleArrows) || (TargetManager.LastTargetInfo.Serial == mobile.Serial & TargetManager.LastTargetInfo.Serial != 0 & ProfileManager.CurrentProfile.TextureManagerPurpleArrows))
                        batcher.Draw2D(ArrowPurple, p1.X, p1.Y, ArrowPurple.Width, ArrowPurple.Height, ref _hueVector);
                    //GREEN ARROW FOR: ALLYS AND PARTY
                    else if ((mobile.NotorietyFlag == NotorietyFlag.Ally & ProfileManager.CurrentProfile.TextureManagerGreenArrows || World.Party.Contains(mobile.Serial)) && mobile != World.Player & ProfileManager.CurrentProfile.TextureManagerGreenArrows)
                        batcher.Draw2D(ArrowGreen, p1.X, p1.Y, ArrowGreen.Width, ArrowGreen.Height, ref _hueVector);
                    //RED ARROW FOR: CRIMINALS, GRAY, MURDERER
                    else if (mobile.NotorietyFlag == NotorietyFlag.Criminal || mobile.NotorietyFlag == NotorietyFlag.Gray || mobile.NotorietyFlag == NotorietyFlag.Murderer)
                    {
                        if (ProfileManager.CurrentProfile.TextureManagerRedArrows)
                            batcher.Draw2D(ArrowRed, p1.X, p1.Y, ArrowRed.Width, ArrowRed.Height, ref _hueVector);
                    }
                    //ORANGE ARROW FOR: ENEMY
                    else if (mobile.NotorietyFlag == NotorietyFlag.Enemy & ProfileManager.CurrentProfile.TextureManagerOrangeArrows)
                        batcher.Draw2D(ArrowOrange, p1.X, p1.Y, ArrowOrange.Width, ArrowOrange.Height, ref _hueVector);
                    //BLUE ARROW FOR: INNOCENT
                    else if (mobile.NotorietyFlag == NotorietyFlag.Innocent & ProfileManager.CurrentProfile.TextureManagerBlueArrows)
                        batcher.Draw2D(ArrowBlue, p1.X, p1.Y, ArrowBlue.Width, ArrowBlue.Height, ref _hueVector);

                    batcher.SetBlendState(null);
                }
                //ARROW TEXTURE
            }
        }
    }
}