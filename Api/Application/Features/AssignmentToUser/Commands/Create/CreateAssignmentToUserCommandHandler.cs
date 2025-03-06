using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using Api.Application.Hubs;
using Api.Data.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Api.Application.Features.AssignmentToUser.Commands.Create;

public class CreateAssignmentToUserCommandHandler : IRequestHandler<CreateAssignmentToUserCommand, Unit>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<Data.Models.User> _userManager;
    private readonly IAssignmentToUserStatusRepository _assignmentToUserStatusRepository;
    private readonly IHubContext<NotificationHub> _hubContext;

    public CreateAssignmentToUserCommandHandler(IAssignmentToUserRepository assignmentToUserRepository, 
        IAssignmentRepository assignmentRepository, IMapper mapper, UserManager<Data.Models.User> userManager, 
        IAssignmentToUserStatusRepository assignmentToUserStatusRepository,
        IHubContext<NotificationHub> hubContext)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
        _userManager = userManager;
        _assignmentToUserStatusRepository = assignmentToUserStatusRepository;
        _hubContext = hubContext;
    }
    
    public async Task<Unit> Handle(CreateAssignmentToUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateAssignmentToUserCommandValidator(_userManager, _assignmentRepository, _assignmentToUserRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        var assignmentToUser = _mapper.Map<Domain.AssignmentToUser>(request);
        var notAcceptedStatus =
            await _assignmentToUserStatusRepository.GetSingleByPredicateAsync(atus => atus.Name == "Not Accepted");
        if (notAcceptedStatus is null)
            throw new Exception("Something with statuses");

        assignmentToUser.AssignmentToUserStatusId = notAcceptedStatus.Id;
        await _assignmentToUserRepository.CreateAsync(assignmentToUser);
        
        await _hubContext.Clients.Group(request.UserId.ToString()).SendAsync("ReceiveNotification", new {assignmentToUser.Id, assignmentToUser.StartTime, assignmentToUser.EndTime});
        
        return Unit.Value;
    }
}