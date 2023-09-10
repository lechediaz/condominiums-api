using System.ComponentModel.DataAnnotations;
using MediatR;

namespace NamiSic.Application.Residents.Commands.CreateResident;

/// <summary>
/// Information needed to create a resident.
/// </summary>
public class CreateResidentCommand : IRequest<int>
{
    private string? _documentType;
    private string? _residentType;

    /// <summary>
    /// The resident's name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// The resident's document type.
    /// </summary>
    public string? DocumentType { get => _documentType; set => _documentType = value?.ToLower(); }

    /// <summary>
    /// The resident's document number.
    /// </summary>
    public string? DocumentNumber { get; set; }

    /// <summary>
    /// The resident's e-mail.
    /// </summary>
    [EmailAddress]
    public string? Email { get; set; }

    /// <summary>
    /// The resident's cellphone.
    /// </summary>
    [Phone]
    public string? Cellphone { get; set; }

    /// <summary>
    /// The resident type. Could be "owner", "tenant" or "resident".
    /// </summary>
    public string? ResidentType { get => _residentType; set => _residentType = value?.ToLower(); }

    /// <summary>
    /// House or apartment number where the resident lives.
    /// </summary>
    [Required]
    public string ApartmentNumber { get; set; }
}

public class CreateResidentCommandHandler : IRequestHandler<CreateResidentCommand, int>
{
    public Task<int> Handle(CreateResidentCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
