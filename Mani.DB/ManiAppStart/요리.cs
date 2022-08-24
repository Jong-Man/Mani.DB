using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 요리
    {
        public int Id { get; set; }
        public string 요리명 { get; set; } = null!;
        public string 요리방법 { get; set; } = null!;
    }
}
