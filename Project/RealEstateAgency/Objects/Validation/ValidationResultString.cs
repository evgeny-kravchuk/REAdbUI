using System.Collections.Generic;

namespace Objects.Validation
{
    public class ValidationResultString
    {
        public bool IsValid { get; set; }

        public List<string> Errors { get; set; }
    }
}
