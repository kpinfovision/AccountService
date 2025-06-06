using Newtonsoft.Json;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class BaseMessage
    {
        public string Description { get; set; }

        public string Code { get; set; }

        [JsonIgnore]
        public object[] Arguments { get; set; }

        public BaseMessage(string description, string code, object[] args = null)
        {
            Code = code;
            Description = description;
            Arguments = args;
        }
    }
}
