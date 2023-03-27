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
using ClassicUO.Configuration;
using ClassicUO.Game.Data;
// ## BEGIN - END ## // MULTIJOURNAL
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
// ## BEGIN - END ## // MULTIJOURNAL
using ClassicUO.Utility;
using ClassicUO.Utility.Collections;
using ClassicUO.Utility.Logging;

namespace ClassicUO.Game.Managers
{
    internal class JournalManager
    {
        private StreamWriter _fileWriter;
        private bool _writerHasException;

        public static Deque<JournalEntry> Entries { get; } = new Deque<JournalEntry>(Constants.MAX_JOURNAL_HISTORY_COUNT);

        public event EventHandler<JournalEntry> EntryAdded;

        // ## BEGIN - END ## // MULTIJOURNAL
        private readonly List<JournalItem> journals;

        public JournalManager()
        {
            journals = new List<JournalItem>();
        }
        // ## BEGIN - END ## // MULTIJOURNAL

        // ## BEGIN - END ## // MULTIJOURNAL
        //public void Add(string text, ushort hue, string name, TextType type, bool isunicode = true)
        // ## BEGIN - END ## // MULTIJOURNAL
        public void Add(string text, ushort hue, string name, MessageType type, bool isunicode = true)
        // ## BEGIN - END ## // MULTIJOURNAL
        {
            JournalEntry entry = Entries.Count >= Constants.MAX_JOURNAL_HISTORY_COUNT ? Entries.RemoveFromFront() : new JournalEntry();

            byte font = (byte) (isunicode ? 0 : 9);

            if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.OverrideAllFonts)
            {
                font = ProfileManager.CurrentProfile.ChatFont;
                isunicode = ProfileManager.CurrentProfile.OverrideAllFontsIsUnicode;
            }

            DateTime timeNow = DateTime.Now;

            entry.Text = text;
            entry.Font = font;
            entry.Hue = hue;
            entry.Name = name;
            entry.IsUnicode = isunicode;
            entry.Time = timeNow;
            entry.TextType = type;

            if (ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.ForceUnicodeJournal)
            {
                entry.Font = 0;
                entry.IsUnicode = true;
            }

            Entries.AddToBack(entry);
            EntryAdded.Raise(entry);

            if (_fileWriter == null && !_writerHasException)
            {
                CreateWriter();
            }

            _fileWriter?.WriteLine($"[{timeNow:G}]  {name}: {text}");
        }

        private void CreateWriter()
        {
            if (_fileWriter == null && ProfileManager.CurrentProfile != null && ProfileManager.CurrentProfile.SaveJournalToFile)
            {
                try
                {
                    string path = FileSystemHelper.CreateFolderIfNotExists(Path.Combine(CUOEnviroment.ExecutablePath, "Data"), "Client", "JournalLogs");

                    _fileWriter = new StreamWriter(File.Open(Path.Combine(path, $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss}_journal.txt"), FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        AutoFlush = true
                    };

                    try
                    {
                        string[] files = Directory.GetFiles(path, "*_journal.txt");
                        Array.Sort(files);

                        for (int i = files.Length - 1; i >= 100; --i)
                        {
                            File.Delete(files[i]);
                        }
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                    // we don't want to wast time.
                    _writerHasException = true;
                }
            }
        }

        public void CloseWriter()
        {
            _fileWriter?.Flush();
            _fileWriter?.Dispose();
            _fileWriter = null;
        }

        public void Clear()
        {
            //Entries.Clear();
            CloseWriter();
        }

        // ## BEGIN - END ## // MULTIJOURNAL
        public void Empty()
        {
            journals.Clear();
        }

        public List<JournalItem> GetJournals()
        {
            return journals;
        }

        public void AddJournal(JournalItem ibi)
        {
            journals.Add(ibi);
        }

        public void RemoveJournal(JournalItem item)
        {
            journals.Remove(item);
        }

        public void Save()
        {
            string path = Path.Combine(ProfileManager.ProfilePath, "journals.xml");

            using (XmlTextWriter xml = new XmlTextWriter(path, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                IndentChar = '\t',
                Indentation = 1
            })
            {
                xml.WriteStartDocument(true);
                xml.WriteStartElement("journals");

                foreach (JournalItem info in journals)
                {
                    info.Save(xml);
                }

                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
        }

        public void Load()
        {
            string path = Path.Combine(ProfileManager.ProfilePath, "journals.xml");

            if (!File.Exists(path))
            {
                CreateDefault();
                Save();
                return;
            }

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(path);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());

                return;
            }

            journals.Clear();

            XmlElement root = doc["journals"];

            if (root != null)
            {
                foreach (XmlElement xml in root.GetElementsByTagName("journal"))
                {
                    JournalItem item = new JournalItem(xml);
                    journals.Add(item);
                    var gump = UIManager.GetGump<UI.Gumps.JournalGump>(item.serial);
                    if (gump != null)
                    {
                        gump.Hue = item.hue;
                        gump.Title = item.label;
                        gump.Filter = item.filter;
                    }
                }
            }
        }

        public void CreateDefault()
        {
            journals.Clear();

            journals.Add(new JournalItem(string.Empty, 0, Enumerable.Repeat(true, Enum.GetValues(typeof(MessageType)).Length).ToArray(), 0));
        }
        // ## BEGIN - END ## // MULTIJOURNAL
    }

    internal class JournalEntry
    {
        public byte Font;
        public ushort Hue;

        public bool IsUnicode;
        public string Name;
        public string Text;

        // ## BEGIN - END ## // MULTIJOURNAL
        //public TextType TextType;
        // ## BEGIN - END ## // MULTIJOURNAL
        public MessageType TextType;
        // ## BEGIN - END ## // MULTIJOURNAL
        public DateTime Time;
    }
    // ## BEGIN - END ## // MULTIJOURNAL
    internal class JournalItem
    {
        public JournalItem(string label, ushort labelColor, bool[] filter, uint serial)
        {
            this.label = label;
            this.serial = serial;
            this.filter = filter;
            hue = labelColor;
        }


        public JournalItem(XmlElement xml)
        {
            if (xml == null)
            {
                return;
            }

            label = xml.GetAttribute("text");
            hue = ushort.Parse(xml.GetAttribute("hue"));
            filter = xml.GetAttribute("filter").Split(sep).Select(x => bool.Parse(x)).ToArray();
            serial = uint.Parse(xml.GetAttribute("serial"));
        }

        public ushort hue;

        public string label;

        public uint serial;

        public bool[] filter;

        private const char sep = ',';

        public void Save(XmlTextWriter writer)
        {
            writer.WriteStartElement("journal");
            writer.WriteAttributeString("text", label);
            writer.WriteAttributeString("hue", hue.ToString());
            writer.WriteAttributeString("serial", serial.ToString());
            writer.WriteAttributeString("filter", string.Join(sep.ToString(), filter));
            writer.WriteEndElement();
        }
    }
    // ## BEGIN - END ## // MULTIJOURNAL
}