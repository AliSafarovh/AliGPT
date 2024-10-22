using Core.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries;

public class GetListBrandQuery
{
    public PageRequest PageRequest { get; set; }
}
