using System.Threading.Tasks;

namespace CoreWebApi.Core.Dto.Responses
{
    public class BaseResponse<T>
    {
        public string Success { get; set; }
        public T Data { get; set; }
    }
}