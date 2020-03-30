using AutoMapper;
using BettingGame.Core.Models.Domain;
using BettingGame.Core.Models.ViewModel;

namespace BettingGame.Api.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, AuthenticatedUser>()
                .ForMember(vm => vm.Token, config =>
                {
                    config.MapFrom((src, dest, member, context) => context.Items["Token"]);
                });
        }
    }
}
