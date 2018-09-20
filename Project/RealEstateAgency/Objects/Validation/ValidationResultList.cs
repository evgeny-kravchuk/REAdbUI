using System.Collections.Generic;

namespace Objects.Validation
{
    public class ValidationResult<T>
    {
        public T ResultObject { get; set; }

        public bool IsValid { get; set; }

        public List<string> Errors { get; set; }
    }
}
