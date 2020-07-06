using System;

namespace model.Filters
{
    public class BaseFilter
    {
        public int? Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}