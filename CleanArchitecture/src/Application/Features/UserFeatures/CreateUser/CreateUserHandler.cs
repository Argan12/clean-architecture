using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.CreateUser
{
    /// <summary>
    /// Create user
    /// </summary>
    public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly ICleanArchitectureDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="passowrdService"></param>
        /// <param name="repository"></param>
        public CreateUserHandler(ICleanArchitectureDbContext context, IMapper mapper, IPasswordService passowrdService, IUserRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _passwordService = passowrdService;
            _userRepository = repository;
        }

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>HTTP Response</returns>
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            request.Password = _passwordService.HashPassword(request.Password);

            User? user = _mapper.Map<User>(request);

            _userRepository.Create(user);

            await _userRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
