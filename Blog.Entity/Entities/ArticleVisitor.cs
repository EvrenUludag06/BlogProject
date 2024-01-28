using Blog.Core.Entities;

namespace Blog.Entity.Entities
{
    public class ArticleVisitor : IBaseEntity
    {
        public ArticleVisitor() { }

        public ArticleVisitor(Guid articleId,int visitorId)
        {
            ArticleId = articleId;
            VisitorId = visitorId;
        }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public int VisitorId { get; set; }
        public Visitors Visitor { get; set; }
    }
}
