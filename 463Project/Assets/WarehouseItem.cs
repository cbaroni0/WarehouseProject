using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSimulator
{
    public class WarehouseItem
    {
        private int _Vol;
        public WarehouseItem(int dim1, int dim2, int dim3, int quantity)
        {
            this._Dim1 = dim1;
            this._Dim2 = dim2;
            this._Dim3 = dim3;
            this._Vol = dim1 * dim2 * dim3;
            this._Qty = quantity;
            this._IsPacked = false;
        }
        public int _Dim1 { get; set; }
        public int _Dim2 { get; set; }
        public int _Dim3 { get; set; }
        public int Volume
        {
            get
            {
                return _Vol;
            }
        }
        public int _Qty { get; set; }
        public int _CoordX { get; set; }
        public int _CoordY { get; set; }
        public int _CoordZ { get; set; }
        public bool _IsPacked { get; set; }
    }
}
