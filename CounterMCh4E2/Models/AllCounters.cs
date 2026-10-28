using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CounterMCh4E2.Models
{
    public class AllCounters
    {
        public ObservableCollection<Counter> Counters { get; set; } = new();

        public AllCounters()
        {
            try
            {
                LoadCounters();
            }
            catch
            {

            }
        }

        public void AddCounter(string name, int initialValue, string color)
        {
            Counters.Add(new Counter(this, name, initialValue, initialValue, color));
            SaveCounters();
        }

        public void AddCounter(string name, int initialValue, int value, string color)
        {
            Counters.Add(new Counter(this, name, initialValue, value, color));
            SaveCounters();
        }

        public void RemoveCounter(Counter counter)
        {
            Counters.Remove(counter);
            SaveCounters();
        }

        public void LoadCounters()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "counters.xml");
            if (!File.Exists(path))
                return;

            XDocument srcTree = XDocument.Load(path);
            Counters = new ObservableCollection<Counter>();
            IEnumerable<XElement> redElements = srcTree.Root.Elements("Counter");

            foreach (XElement element in redElements)
            {
                AddCounter(element.Element("Name").Value, int.Parse(element.Element("InitialValue").Value), int.Parse(element.Element("Value").Value), element.Element("Color").Value);
            }
        }
        public void SaveCounters()
        {
            XDocument srcTree = new XDocument(
                new XElement("Root", 
                    Counters.Select(counter =>
                        new XElement("Counter",
                            new XElement("Name", counter.Name),
                            new XElement("Value", counter.Value),
                            new XElement("InitialValue", counter.InitialValue),
                            new XElement("Color", counter.Color)
                ))));

            string path = Path.Combine(FileSystem.AppDataDirectory, "counters.xml");
            srcTree.Save(path);
        }
    }
}
