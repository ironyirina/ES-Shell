using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Оболочка_ЭС
{
    class ListViewItemComparer : IComparer
    {
        private readonly int _col;
        private readonly SortOrder _order;

        public ListViewItemComparer()
        {
            _col = 0;
            _order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            _col = column;
            _order = order;
        }

        public int Compare(object x, object y)
        {
            var returnVal = String.CompareOrdinal(((ListViewItem) x).SubItems[_col].Text,
                                                  ((ListViewItem) y).SubItems[_col].Text);
            // Определение того, является ли порядок сортировки порядком "по убыванию".
            if (_order == SortOrder.Descending)
                // Изменение значения, возвращенного String.Compare, на противоположное.
                returnVal *= -1;
            return returnVal;
        }
    }
}
