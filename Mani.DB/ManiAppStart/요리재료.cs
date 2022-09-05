using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 요리재료
    {
        public int 요리ID { get; set; }
        public int 재료ID { get; set; }
        public double 수량 { get; set; }
        public string 계량수 { get; set; } = null!;
        public string 메모 { get; set; } = null!;
        public bool 필수 { get; set; }

        public virtual 요리 요리 { get; set; } = null!;
        public virtual 재료 재료 { get; set; } = null!;
    }
}
