using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Position : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


        public string _PositionName;

        public string PositionName
        {
            get { return _PositionName; }
            set { _PositionName = value; OnpropertyChanged(); }
        }

        public Position()
        {

        }

        public Position(string positionname)
        {
            PositionName = positionname;
        }
    }
}
