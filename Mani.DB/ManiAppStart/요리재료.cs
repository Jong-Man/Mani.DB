using System;
using System.Collections.Generic;

namespace Mani.DB.maniAppStart
{
    public partial class 요리재료
    {
        public int 요리id { get; set; }
        public int 재료id { get; set; }
        public double 수량 { get; set; }
        public string 계량수 { get; set; } = null!;
        public string 메모 { get; set; } = null!;
        public bool 필수 { get; set; }

        public virtual 요리 요리 { get; set; } = null!;
        public virtual 재료목록 재료 { get; set; } = null!;
    }
}
