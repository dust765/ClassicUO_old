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
using System.IO;
using System.Linq;
using System.Xml;
using ClassicUO.Configuration;
using ClassicUO.Game.Data;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Input;
using ClassicUO.IO.Resources;
using ClassicUO.Renderer;
using ClassicUO.Resources;
using ClassicUO.Utility.Collections;

namespace ClassicUO.Game.UI.Gumps
{
    internal class JournalGump : Gump
    {
        private const int _diffY = 22;
        private readonly ExpandableScroll _background;
        private readonly GumpPic _gumpPic;
        private readonly HitBox _hitBox;
        private bool _isMinimized;
        private readonly RenderedTextList _journalEntries;
        private readonly ScrollFlag _scrollBar;
        private Label _titleLabel;
        private static MessageType[] types = Enum.GetValues(typeof(MessageType)) as MessageType[];

        public JournalGump(uint serial = 0, string title = null, ushort hue = 0, bool[] filter = null) : base(0, 0)
        {
            Height = 300;
            CanMove = true;
            CanCloseWithRightClick = true;
            Add(_gumpPic = new GumpPic(160, 0, 0x82D, 0));

            Add
            (
                _background = new ExpandableScroll(0, _diffY, Height - _diffY, 0x1F40)
            );

            Hue = hue;

            if (!string.IsNullOrEmpty(title))
            {
                LocalSerial = serial;
                Add(_titleLabel = new Label(title, true, 0) { X = 160 - title.Length * 2, Y = 33 });
            }
            else
            {
                _background.TitleGumpID = 0x82A;
            }

            _scrollBar = new ScrollFlag(-25, _diffY + 36, Height - _diffY, true);

            Add
            (
                _journalEntries = new RenderedTextList
                (
                    25,
                    _diffY + 36,
                    _background.Width - (_scrollBar.Width >> 1) - 5,
                    200,
                    _scrollBar
                )
            );
            Add(_scrollBar);

            if (filter == null)
            {
                Filter = Enumerable.Repeat(true, types.Length).ToArray();
            }
            else
            {
                Filter = filter;
            }

            Add(_hitBox = new HitBox(160, 0, 23, 24));
            _hitBox.MouseUp += _hitBox_MouseUp;
            _gumpPic.MouseDoubleClick += _gumpPic_MouseDoubleClick;

            InitializeJournalEntries();
            World.Journal.EntryAdded += AddJournalEntry;
        }

        public override GumpType GumpType => GumpType.Journal;

        public ushort Hue
        {
            get => _background.Hue;
            set => _background.Hue = value;
        }

        public string Title
        {
            get => _titleLabel != null ? _titleLabel.Text : string.Empty;
            set
            {
                if (value != string.Empty)
                {
                    _background.TitleGumpID = 0;
                    if (_titleLabel != null)
                    {
                        _titleLabel.Text = value;
                        _titleLabel.X = 160 - value.Length * 2;
                    }
                    else
                    {
                        Add(_titleLabel = new Label(value, true, 0) { X = 160 - value.Length * 2, Y = 33 });
                    }
                }
                else
                {
                    _background.TitleGumpID = 0x82A;
                    if (_titleLabel != null)
                    {
                        Remove(_titleLabel);
                        _titleLabel = null;
                    }
                }
            }
        }

        public bool[] Filter { get => _journalEntries._filter; set => _journalEntries._filter = value; }

        public bool IsMinimized
        {
            get => _isMinimized;
            set
            {
                if (_isMinimized != value)
                {
                    _isMinimized = value;

                    _gumpPic.Graphic = value ? (ushort)0x830 : (ushort)0x82D;

                    if (value)
                    {
                        _gumpPic.X = 0;
                    }
                    else
                    {
                        _gumpPic.X = 160;
                    }

                    foreach (Control c in Children)
                    {
                        c.IsVisible = !value;
                    }

                    _gumpPic.IsVisible = true;
                    WantUpdateSize = true;
                }
            }
        }

        protected override void OnMouseWheel(MouseEventType delta)
        {
            _scrollBar.InvokeMouseWheel(delta);
        }


        public override void Dispose()
        {
            World.Journal.EntryAdded -= AddJournalEntry;
            base.Dispose();
        }

        public override void Update()
        {
            base.Update();

            WantUpdateSize = true;
            _journalEntries.Height = Height - (98 + _diffY);
        }

        private void AddJournalEntry(object sender, JournalEntry entry)
        {
            var usrSend = entry.Name != string.Empty ? $"{entry.Name}" : string.Empty;

            // Check if ignored person
            if (!string.IsNullOrEmpty(usrSend) && IgnoreManager.IgnoredCharsList.Contains(usrSend))
                return;

            string text = $"{usrSend}: {entry.Text}";

            _journalEntries.AddEntry
            (
                text,
                entry.Font,
                entry.Hue,
                entry.IsUnicode,
                entry.Time,
                entry.TextType
            );
        }

        public override void Save(XmlTextWriter writer)
        {
            base.Save(writer);
            writer.WriteAttributeString("height", _background.SpecialHeight.ToString());
            writer.WriteAttributeString("isminimized", IsMinimized.ToString());
        }

        public override void Restore(XmlElement xml)
        {
            base.Restore(xml);

            _background.Height = _background.SpecialHeight = int.Parse(xml.GetAttribute("height"));
            IsMinimized = bool.Parse(xml.GetAttribute("isminimized"));
        }

        private void InitializeJournalEntries()
        {
            foreach (JournalEntry t in JournalManager.Entries)
            {
                AddJournalEntry(null, t);
            }

            _scrollBar.MinValue = 0;
        }

        private void _gumpPic_MouseDoubleClick(object sender, MouseDoubleClickEventArgs e)
        {
            if (e.Button == MouseButtonType.Left && IsMinimized)
            {
                IsMinimized = false;
                e.Result = true;
            }
        }

        private void _hitBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtonType.Left && !IsMinimized)
            {
                IsMinimized = true;
            }
        }


        private class RenderedTextList : Control
        {
            private readonly Deque<RenderedText> _entries, _hours;
            private readonly ScrollBarBase _scrollBar;
            private readonly Deque<MessageType> _text_types;
            internal bool[] _filter;

            public RenderedTextList(int x, int y, int width, int height, ScrollBarBase scrollBarControl)
            {
                _scrollBar = scrollBarControl;
                _scrollBar.IsVisible = false;
                AcceptMouseInput = true;
                CanMove = true;
                X = x;
                Y = y;
                Width = width;
                Height = height;

                _entries = new Deque<RenderedText>();
                _hours = new Deque<RenderedText>();
                _text_types = new Deque<MessageType>();

                WantUpdateSize = false;
            }

            public override bool Draw(UltimaBatcher2D batcher, int x, int y)
            {
                base.Draw(batcher, x, y);

                int mx = x;
                int my = y;

                int height = 0;
                int maxheight = _scrollBar.Value + _scrollBar.Height;

                for (int i = 0; i < _entries.Count; i++)
                {
                    RenderedText t = _entries[i];
                    RenderedText hour = _hours[i];
                    MessageType type = _text_types[i];


                    if (!CanBeDrawn(type))
                    {
                        continue;
                    }


                    if (height + t.Height <= _scrollBar.Value)
                    {
                        // this entry is above the renderable area.
                        height += t.Height;
                    }
                    else if (height + t.Height <= maxheight)
                    {
                        int yy = height - _scrollBar.Value;

                        if (yy < 0)
                        {
                            // this entry starts above the renderable area, but exists partially within it.
                            hour.Draw
                            (
                                batcher,
                                hour.Width,
                                hour.Height,
                                mx,
                                y,
                                t.Width,
                                t.Height + yy,
                                0,
                                -yy
                            );

                            t.Draw
                            (
                                batcher,
                                t.Width,
                                t.Height,
                                mx + hour.Width,
                                y,
                                t.Width,
                                t.Height + yy,
                                0,
                                -yy
                            );

                            my += t.Height + yy;
                        }
                        else
                        {
                            // this entry is completely within the renderable area.
                            hour.Draw(batcher, mx, my);
                            t.Draw(batcher, mx + hour.Width, my);
                            my += t.Height;
                        }

                        height += t.Height;
                    }
                    else
                    {
                        int yyy = maxheight - height;

                        hour.Draw
                        (
                            batcher,
                            hour.Width,
                            hour.Height,
                            mx,
                            y + _scrollBar.Height - yyy,
                            t.Width,
                            yyy,
                            0,
                            0
                        );

                        t.Draw
                        (
                            batcher,
                            t.Width,
                            t.Height,
                            mx + hour.Width,
                            y + _scrollBar.Height - yyy,
                            t.Width,
                            yyy,
                            0,
                            0
                        );

                        // can't fit any more entries - so we break!
                        break;
                    }
                }

                return true;
            }

            public override void Update()
            {
                base.Update();

                if (!IsVisible)
                {
                    return;
                }

                _scrollBar.X = X + Width - (_scrollBar.Width >> 1) + 5;
                _scrollBar.Height = Height;
                CalculateScrollBarMaxValue();
                _scrollBar.IsVisible = _scrollBar.MaxValue > _scrollBar.MinValue;
            }

            private void CalculateScrollBarMaxValue()
            {
                bool maxValue = _scrollBar.Value == _scrollBar.MaxValue;
                int height = 0;

                for (int i = 0; i < _entries.Count; i++)
                {
                    if (i < _text_types.Count && CanBeDrawn(_text_types[i]))
                    {
                        height += _entries[i].Height;
                    }
                }

                height -= _scrollBar.Height;

                if (height > 0)
                {
                    _scrollBar.MaxValue = height;

                    if (maxValue)
                    {
                        _scrollBar.Value = _scrollBar.MaxValue;
                    }
                }
                else
                {
                    _scrollBar.MaxValue = 0;
                    _scrollBar.Value = 0;
                }
            }

            public void AddEntry
            (
                string text,
                int font,
                ushort hue,
                bool isUnicode,
                DateTime time,
                MessageType text_type
            )
            {
                bool maxScroll = _scrollBar.Value == _scrollBar.MaxValue;

                while (_entries.Count > 199)
                {
                    _entries.RemoveFromFront().Destroy();

                    _hours.RemoveFromFront().Destroy();

                    _text_types.RemoveFromFront();
                }

                RenderedText h = RenderedText.Create
                (
                    $"{time:t} ",
                    1150,
                    1,
                    true,
                    FontStyle.BlackBorder
                );

                _hours.AddToBack(h);

                RenderedText rtext = RenderedText.Create
                (
                    text,
                    hue,
                    (byte)font,
                    isUnicode,
                    FontStyle.Indention | FontStyle.BlackBorder,
                    maxWidth: Width - (18 + h.Width)
                );

                _entries.AddToBack(rtext);

                _text_types.AddToBack(text_type);

                _scrollBar.MaxValue += rtext.Height;

                if (maxScroll)
                {
                    _scrollBar.Value = _scrollBar.MaxValue;
                }
            }

            bool CanBeDrawn(MessageType type)
            {
                var ind = Array.IndexOf(types, type);
                return ind == -1 ? false : _filter[ind];
            }

            public override void Dispose()
            {
                for (int i = 0; i < _entries.Count; i++)
                {
                    _entries[i].Destroy();

                    _hours[i].Destroy();
                }

                _entries.Clear();
                _hours.Clear();
                _text_types.Clear();

                base.Dispose();
            }
        }
    }
}