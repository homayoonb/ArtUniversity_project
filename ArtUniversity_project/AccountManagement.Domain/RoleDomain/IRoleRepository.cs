using _0_Framework.Domain;
using AccountManagement.Application.Contract.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleDomain
{
    public interface IRoleRepository : IRepository<long,Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
