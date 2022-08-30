using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 레시피
    {
        public int ID { get; set; }
        public int 요리ID { get; set; }
        public int 순서 { get; set; }
        public string 내용 { get; set; } = null!;
        public string 구분 { get; set; } = null!;

        public virtual 요리 요리 { get; set; } = null!;
    }
}
