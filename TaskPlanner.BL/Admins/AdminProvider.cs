using AutoMapper;
using TaskPlanner.BL.Admins.Entities;
using TaskPlanner.BL.Exceptions;
using TaskPlanner.DataAccess.Entities;
using TaskPlanner.Repository;

namespace TaskPlanner.BL.Admins
{
    public class AdminProvider : IAdminProvider
    {
        private readonly IRepository<Admin> _repository;

        private readonly IMapper _mapper;

        public AdminProvider(IRepository<Admin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AdminModel GetAdminInfo(Guid id)
        {
            var admin = _repository.GetById(id);
            if (admin is null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<AdminModel>(admin);
        }

        public IEnumerable<AdminModel> GetAdmins(AdminModelFilter filter = null)
        {
            var name = filter?.Name;
            var email = filter?.Email;


            var admins = _repository.GetAll(x =>
                (name == null || x.Name == name) &&
                (email == null || x.Email == email));

            return _mapper.Map<IEnumerable<AdminModel>>(admins);
        }
    }
}
