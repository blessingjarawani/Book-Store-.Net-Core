using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
