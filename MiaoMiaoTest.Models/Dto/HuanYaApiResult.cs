using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Models.Dto
{
    public class HuanYaApiResult
    {
        public string Code { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }

        public DataInfo Data { get; set; }
    }

    public class DataInfo
    {
        public VideoDetailInfo VideoDetail { get; set; }
        public List<GuesslikeInfo> Guesslike { get; set; }
    }

    public class VideoDetailInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Cid { get; set; }
        public string Pic { get; set; }
        public string Carname { get; set; }
        public int Hits { get; set; }
        public string Actor { get; set; }
        public string Up { get; set; }
        public string Vurl { get; set; }
        public string Summary { get; set; }
        public string Addtime { get; set; }
        public string Shop { get; set; }
        public string Area { get; set; }
        public string Iframeurl { get; set; }
        public string Catename { get; set; }
    }

    public class GuesslikeInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Addtime { get; set; }
        public string Pic { get; set; }
        public int Hits { get; set; }
        public string Up { get; set; }
    }

}
