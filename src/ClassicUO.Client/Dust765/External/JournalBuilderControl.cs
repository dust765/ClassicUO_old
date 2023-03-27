using ClassicUO.Game.Managers;
using ClassicUO.Assets;
using ClassicUO.Resources;

namespace ClassicUO.Game.UI.Controls
{
    internal class JournalBuilderControl : Control
    {
        private readonly StbTextBox infoLabel;
        private readonly ClickableColorBox labelColor;

        public JournalBuilderControl(JournalItem item)
        {
            infoLabel = new StbTextBox(0xFF, 30, 200) { X = 5, Y = 0, Width = 200, Height = 20 };
            infoLabel.SetText(item.label);
            LocalSerial = item.serial;
            Filter = item.filter;

            labelColor = new ClickableColorBox
            (
                220,
                0,
                13,
                14,
                item.hue
            );

            NiceButton filterButton = new NiceButton
            (
                250,
                0,
                60,
                25,
                ButtonAction.Activate,
                ResGumps.Filter
            )
            { ButtonParameter = 999, IsSelectable = false };

            filterButton.MouseUp += (sender, e) =>
            {
                var gump = UIManager.GetGump<Gumps.JournaFiltersGump>();
                if (gump != null)
                    gump.InvokeMouseCloseGumpWithRClick();

                UIManager.Add(new Gumps.JournaFiltersGump(this, 500, 500));
            };

            NiceButton openButton = new NiceButton
            (
                325,
                0,
                60,
                25,
                ButtonAction.Activate,
                ResGumps.Open
            )
            { ButtonParameter = 999, IsSelectable = false };

            openButton.MouseUp += (sender, e) =>
            {
                if (UIManager.GetGump<Gumps.JournalGump>(LocalSerial) == null)
                {
                    UIManager.Add(new Gumps.JournalGump(LocalSerial, LabelText, Hue) { X = 64, Y = 64 });
                }
            };

            NiceButton deleteButton = new NiceButton
            (
                390,
                0,
                60,
                25,
                ButtonAction.Activate,
                ResGumps.Delete
            )
            { ButtonParameter = 999 };

            deleteButton.MouseUp += (sender, e) =>
            {
                Dispose();
                ((DataBox) Parent)?.ReArrangeChildren();

                Gumps.JournalGump gump = UIManager.GetGump<Gumps.JournalGump>(LocalSerial);
                if (gump != null)
                {
                    gump.InvokeMouseCloseGumpWithRClick();
                }
            };

            Add(new ResizePic(0x0BB8) { X = infoLabel.X - 5, Y = 0, Width = infoLabel.Width + 10, Height = infoLabel.Height });

            Add(infoLabel);
            Add(labelColor);
            Add(filterButton);
            if (LocalSerial != 0)
                Add(openButton);
            if (LocalSerial != 0)
                Add(deleteButton);

            Width = infoLabel.Width + 10;
            Height = infoLabel.Height;
        }

        public string LabelText => infoLabel.Text;
        public ushort Hue => labelColor.Hue;

        private bool[] _filter;
        public bool[] Filter
        {
            get => _filter; set
            {
                _filter = value;
                var gump = UIManager.GetGump<Gumps.JournalGump>(LocalSerial);
                if (gump != null)
                    gump.Filter = value;
            }
        }
    }
}