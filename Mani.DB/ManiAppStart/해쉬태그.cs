using System;
using System.Collections.Generic;

namespace Mani.DB.ManiAppStart
{
    public partial class 해쉬태그
    {
        public int ID { get; set; }
        public int HTMLID { get; set; }
        public string 태그내용 { get; set; } = null!;

        public virtual 추가HTML내용 HTML { get; set; } = null!;
    }
}
