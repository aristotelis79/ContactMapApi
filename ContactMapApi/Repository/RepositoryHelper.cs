using System;
using System.Collections.Generic;
using ContactMapApi.Data.Entities;

namespace ContactMapApi.Helpers
{
    public static class RepositoryHelper
    {
        public static void CheckForNull<T>(this T entity) where T : BaseEntity
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
        }

        public static void CheckForNull<T>(this IEnumerable<T> entities) where T : BaseEntity
        {
            if(entities == null) throw new ArgumentNullException(nameof(entities));
        }
    }
}