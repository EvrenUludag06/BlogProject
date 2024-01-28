using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.WebUI.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleVisitorFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            List<Visitors> visitors = unitOfWork.GetRepository<Visitors>().GetAllAsync().Result;

            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

            Visitors visitor = new(getIp, getUserAgent);

            if (visitors.Any(x => x.IpAdress == visitor.IpAdress))
                return next();
            else
            {
                unitOfWork.GetRepository<Visitors>().AddAsync(visitors);
                unitOfWork.Save();
            }
            return next();
        }
    }
}