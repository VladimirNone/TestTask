﻿using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.IManagers
{
    public interface IBlogManager : IDomainService, IManager<Blog>
    {
        /// <summary>
        /// Get all blogs without loading related entities
        /// </summary>
        IEnumerable<Blog> GetAllBlogs();
        /// <summary>
        /// Get all blogs with loaded Posts and sorted by the count of the Posts in each Blog
        /// </summary>
        IEnumerable<Blog> GetAllBlogsSortedByPopularity();
    }
}
