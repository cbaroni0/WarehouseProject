// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSimulator
{
    public class Warehouse
    {
        private int _Vol;
        public List<WarehouseItem> items;
        public Warehouse (int id, int width, int height, int length)
        {
            this._ID = id;
            this._Length = length;
            this._Width = width;
            this._Height = height;
            this._Vol = length * width * height;
            items = new List<WarehouseItem>();
        }
        public int _ID { get; set; }
        public int _Length { get; set; }
        public int _Width { get; set; }
        public int _Height { get; set; }
        public int Volume
        {
            get
            {
                return this._Vol;
            }
            set
            {
                this._Vol = value;
            }
        }
    }
}
