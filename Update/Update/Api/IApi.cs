using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update.Api
{
    public interface IApi
    {
        List<String> GroupsList(String id);
    }
}
