using System;
using Tweetbook.Contracts.V1.Requests.Queries;

namespace Tweetbook.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);
        Uri GetFiverrServiceUri(string serviceId);

        Uri GetAllPostsUri(PaginationQuery pagination = null);
    }
}
