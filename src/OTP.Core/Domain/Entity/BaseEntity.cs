using OTP.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Entity
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
