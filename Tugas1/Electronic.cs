using System;
using System.Collections.Generic;
using System.Text;

namespace Tugas1
{
    class Electronic : Barang
    {

        public new string jenisBarang { get; set; }
        public Electronic()
        {
            this.jenisBarang = "Electronic";
        }
        public override string Tampil()
        {
            return "Tersedia";
        }

    }
}
