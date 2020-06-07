using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Responses
{
    public class Response<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
