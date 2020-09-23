using System.Collections.Generic;

namespace MiaoMiaoTest.Models.Dto
{
    public class HuanYaMovie
    {
        public string Code { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public DataInfo Data { get; set; }

        public class DataInfo
        {
            public List<Detail> List { get; set; }
            public string Total { get; set; }
        }

        public class Detail
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Pic { get; set; }
            public string Time { get; set; }
            public int Hits { get; set; }
            public string Content { get; set; }
        }
    }
}