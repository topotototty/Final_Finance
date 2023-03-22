using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance
{
    internal class Note
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Money { get; set; }
        public bool isIncrease { get; set; }
        public DateTime date { get; set; }
        public Note(string name, string type, double money, DateTime date, bool isIncrease )
        {
            Name = name;
            Type = type;
            Money = money;
            this.date = date;
            this.isIncrease = isIncrease;
        }
        public static void Serialize(BindingList<Note> notes)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText("C://Users//futbo//OneDrive//Рабочий стол//Dairy//About_Notes.json", json);
        }

        public static BindingList<Note> Deserialize()
        {
            string About_Notes = File.ReadAllText("C://Users//futbo//OneDrive//Рабочий стол//Dairy//About_Notes.json");
            BindingList<Note> notes = JsonConvert.DeserializeObject<BindingList<Note>>(About_Notes);
            return notes;
        }
    }
}
