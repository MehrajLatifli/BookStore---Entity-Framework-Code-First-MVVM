using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Additional_Classes
{
    public class ObservableCollectionHelper
    {
        public static ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> list)
        {

            return new ObservableCollection<T>(list);
        }
    }
}
