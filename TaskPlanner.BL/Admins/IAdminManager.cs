using TaskPlanner.BL.Admins.Entities;

namespace TaskPlanner.BL.Admins
{
    public interface IAdminManager
    {
        AdminModel CreateAdmin(CreateAdminModel model);
        void DeleteAdmin(Guid id);
        AdminModel UpdateAdmin(Guid id, UpdateAdminModel model);
    }
}
