using System.Collections.Generic;
using UnityEngine;

namespace CandyCoded
{

    public abstract class ObservableListReference<T> : ListReference<T>
    {

        [SerializeField]
        private ObservableList<T> _items = new ObservableList<T>();
        public new ObservableList<T> Items
        {
            get { return _items; }
            set { _items = value; }
        }

    }

}
