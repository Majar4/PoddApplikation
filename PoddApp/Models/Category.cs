using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Category : INotifyPropertyChanged
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonElement("_id")]
        public string CategoryID { get; set; }

        private string _name;
        public string Name {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public Category(string name)
        {
            Name = name;
        }

        public Category()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
