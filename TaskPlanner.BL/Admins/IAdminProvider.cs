using TaskPlanner.BL.Admins.Entities;

namespace TaskPlanner.BL.Admins
{
    public interface IAdminProvider
    {
        IEnumerable<AdminModel> GetAdmins(AdminModelFilter filter = null);
        AdminModel GetAdminInfo(Guid id);
    }
}
