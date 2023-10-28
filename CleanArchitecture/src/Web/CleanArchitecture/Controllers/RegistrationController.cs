using CleanArchitecture.Application.Features.UserFeatures.CreateUser;
using CleanArchitecture.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    /// <summary>
    /// Create user account
    /// </summary>
    [ApiController]
    [Route("register")]
    public class RegistrationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly CleanArchitectureDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="context"></param>
        public RegistrationController(IMediator mediator, CleanArchitectureDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        /// <summary>
        /// Create user account
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse? response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
