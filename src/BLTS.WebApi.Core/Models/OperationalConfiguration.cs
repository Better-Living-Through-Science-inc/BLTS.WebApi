﻿using System;

namespace BLTS.WebApi.Models
{
    public partial class OperationalConfiguration : Entity<long>
    {
        public OperationalConfiguration()
        {
            IsConnectionString = false;
            IsEnabled = true;
        }

        public long ApplicationId { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public bool? BoolValue { get; set; }
        public DateTime? DateValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public Guid? GuidValue { get; set; }
        public int? IntegerValue { get; set; }
        public long? LongValue { get; set; }
        public string StringValue { get; set; }
        public bool IsConnectionString { get; set; }
        public bool IsEnabled { get; set; }

        public virtual Application Application { get; set; }
    }
}
