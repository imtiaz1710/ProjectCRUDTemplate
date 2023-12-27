using MediatR;
using ProjectCRUDTemplate.Application.Common;
using ProjectCRUDTemplate.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUDTemplate.Application.ProjectQueries
{
    public class GetAllQueryHandler(IProjectRepository projectRepository) : IRequestHandler<GetAllProjectQuery, CommonAPIResponse>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        public async Task<CommonAPIResponse> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var data =  await _projectRepository.GetAllAsync();
            return new CommonAPIResponse("Data Retrive Successfully!", data);
        }
    }
}
