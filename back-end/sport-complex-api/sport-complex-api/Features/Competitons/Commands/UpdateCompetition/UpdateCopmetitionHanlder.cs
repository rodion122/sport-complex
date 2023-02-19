using MediatR;
using Microsoft.EntityFrameworkCore;
using sport_complex_api.Features.Competitons.Models;
using sport_complex_api.Infastructure.Database.Contexts;

namespace sport_complex_api.Features.Competitons.Commands.UpdateCompetition
{
    public class UpdateCopmetitionHanlder : AsyncRequestHandler<UpdateCopmetitionCommand>
    {
        private CommonContext _context;

        public UpdateCopmetitionHanlder(CommonContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(UpdateCopmetitionCommand request, CancellationToken cancellationToken)
        {
            var entry = await _context.Set<CompetitonDto>()
                .FirstOrDefaultAsync(e => e.Id == request.Competiton.Id, cancellationToken);

            _context.Entry(entry).CurrentValues.SetValues(request.Competiton);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
