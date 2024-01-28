using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class Visitors : IBaseEntity
    {
        public Visitors() { }

        public Visitors(string ipAddress, string userAgent)
        {
            IpAdress = ipAddress;
            UserAgent = userAgent;
        }

        public int Id { get; set; }
        public object IpAdress { get; set; }
        public string UserAgent { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }

    }
}
