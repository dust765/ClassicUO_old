using ClassicUO.Game.Data;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace ClassicUO.Game.UI.Gumps
{
    internal class JournaFiltersGump : Gump
    {
        int WIDTH = 230;
        int HEIGHT = 270;
        JournalBuilderControl Parent;
        Checkbox[] _checkboxes;
        public JournaFiltersGump(JournalBuilderControl parent, int x, int y) : base(0, 0)
        {
            CanCloseWithRightClick = true;
            CanMove = true;
            AcceptMouseInput = true;
            X = x;
            Y = y;
            Parent = parent;

            Add
            (
                new AlphaBlendControl(0.95f)
                {
                    X = 1,
                    Y = 1,
                    Width = WIDTH - 2,
                    Height = HEIGHT - 2,
                    Hue = 999
                }
            );

            int startx = 20;
            int starty = 0;
            int offx = 0;
            int offy = 0;
            int stepx = 110;
            int stepy = 30;

            MessageType[] messageTypes = Enum.GetValues(typeof(MessageType)) as MessageType[];
            _checkboxes = new Checkbox[messageTypes.Length];
            if (Parent.Filter == null)
            {
                Parent.Filter = Enumerable.Repeat(true, messageTypes.Length).ToArray();
            }

            for (int i = 0; i < messageTypes.Length; i++)
            {
                if (i >= messageTypes.Length / 2 && offx == 0)
                {
                    offx = stepx;
                    offy = 0;
                }

                offy += stepy;

                Add(_checkboxes[i] = new Checkbox(0x00D2, 0x00D3, TypeString(messageTypes[i].ToString()), 1, 0xFFFF, true) { X = startx + offx, Y = starty + offy, IsChecked = Parent.Filter[i] });
                _checkboxes[i].ValueChanged += checkbox_Checked;
            }

            offy += stepy;

            Add
            (
                new Button(0, 0x00F9, 0x00F8, 0x00F7)
                {
                    X = startx + offx / 2, Y = starty + offy, ButtonAction = ButtonAction.Activate
                }
            );

            Add(new Line(0, 0, WIDTH, 1, Color.Gray.PackedValue));
            Add(new Line(0, 0, 1, HEIGHT, Color.Gray.PackedValue));
            Add(new Line(0, HEIGHT, WIDTH, 1, Color.Gray.PackedValue));
            Add(new Line(WIDTH, 0, 1, HEIGHT, Color.Gray.PackedValue));
        }

        private string TypeString(string type) => new System.Resources.ResourceManager(typeof(Resources.ResGumps)).GetString($"MessageType_{type}");

        private void checkbox_Checked(object sender, EventArgs e)
        {
            Parent.Filter = _checkboxes.Select(x => x.IsChecked).ToArray();
        }

        public override void OnButtonClick(int buttonID)
        {
            Dispose();
        }
    }
}