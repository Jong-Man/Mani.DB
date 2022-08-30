using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 관련내용
    {
        public int ID { get; set; }
        public int 요리ID { get; set; }
        public string 분류 { get; set; } = null!;
        public string 내용 { get; set; } = null!;

        public virtual 요리 요리 { get; set; } = null!;
    }
}
