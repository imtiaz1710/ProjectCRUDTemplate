﻿namespace ProjectCRUDTemplate.API.Models.ProjectCommands;

public class CreateProjectCommand : IRequest<CommonAPIResponse>
{
    public required string ProjectTitle { get; set; }

    public required string Country { get; set; }

    public int Cost { get; set; }
}
