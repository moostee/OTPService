using OTP.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OTP.Core.Domain.Form
{
    public class BaseForm<T>
    {
        public T Id { get; set; }
        [JsonIgnore]
        public RecordStatus RecordStatus { get; set; }
    }
}
