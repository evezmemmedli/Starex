using Starex.Application.Interfaces.Repositories.Logging;
using Starex.Domain.Entities.Logging;
using Starex.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Persistence.Repositories.Log
{
    public class ErrorLogWriteRepository : WriteRepository<ErrorLog>, IErrorLogWriteRepository
    {
        public ErrorLogWriteRepository(StarexDbContext contex) : base(contex)
        {

        }
    }
}
