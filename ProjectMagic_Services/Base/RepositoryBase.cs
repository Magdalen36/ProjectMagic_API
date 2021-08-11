using ConnectionTool;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Base
{
    public abstract class RepositoryBase
    {

        internal Connection _connection;

        IConfiguration _config;

        public RepositoryBase(IConfiguration config)
        {
            _config = config;
            _connection = new Connection(_config.GetConnectionString("default"));
        }
    }
}


