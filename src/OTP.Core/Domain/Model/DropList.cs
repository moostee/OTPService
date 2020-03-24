using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.Core.Domain.Model
{
    public class DropList<T>
    {

        public DropList(T id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public T Id { get; set; }
        public string Name { get; set; }
    }
}
