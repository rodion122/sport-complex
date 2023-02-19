using MediatR;
using sport_complex_api.Infastructure.Database.Contexts;
using sport_complex_api.Features.Competitons.Models;

namespace sport_complex_api.Features.Competitons.Commands.CreateCopmetition
{
    public class CreateCopmetitionHanlder : IRequestHandler<CreateCopmetitionCommand, string>
    {
        private CommonContext _context;

        public CreateCopmetitionHanlder(CommonContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string> Handle(CreateCopmetitionCommand request, CancellationToken cancellationToken)
        {
            request.Competiton.Id = Guid.NewGuid().ToString();

            await _context.Set<CompetitonDto>().AddAsync(request.Competiton, cancellationToken);

            await _context.SaveChangesAsync();

            return request.Competiton.Id;
        }
    }
}
