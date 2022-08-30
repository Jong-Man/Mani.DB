using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 추가HTML내용
    {
        public 추가HTML내용()
        {
            해쉬태그S = new HashSet<해쉬태그>();
        }

        public int ID { get; set; }
        public string 제목 { get; set; } = null!;
        public string 분류 { get; set; } = null!;
        public string 내용 { get; set; } = null!;

        public virtual ICollection<해쉬태그> 해쉬태그S { get; set; }
    }
}
