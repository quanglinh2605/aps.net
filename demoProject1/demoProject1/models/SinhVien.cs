using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoProject1.models
{
    class SinhVien
    {
        private int MaSV;
        public int Masv { get => MaSV; set => MaSV = value; }
        private string TenSV;

        public string tensv
        {
            get { return TenSV; }
            set { TenSV = value; }
        }
        public string sdt { get; set; }

    }
}
