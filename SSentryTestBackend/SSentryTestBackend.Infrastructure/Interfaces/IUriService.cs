using SSentryTestBackend.Core.QueryFilters;
using System;

namespace SSentryTestBackend.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}
