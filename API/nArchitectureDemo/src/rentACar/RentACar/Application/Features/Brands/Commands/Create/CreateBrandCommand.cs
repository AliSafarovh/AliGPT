﻿using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreatedBrandResponse> //IRequest Mediatr ile isleyeceni gosterir. 
        //ve emr icra olunduqdan sonra CreatedBrandResponse tipinde netice qaytaracaq.
    {
        public string Name { get; set; } //Yeni brand yaradarken Name-i ozunde saxla
    }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)//Handler sinfi, MediatR vasitəsilə gələn əmrləri (command) qarşılayır
        {
            await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);  //3cu-eger ad eyni olarsa

            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();

            await _brandRepository.AddAsync(brand);//BrandRepository vasitəsilə məlumatları əlavə etmək

            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);//Mapper ilə Command obyektindən Brand obyektinə çevirmə etmək
            return createdBrandResponse; //Yaradılan Brand obyekti əsasında cavab(response) formalaşdırmaq.
        }
    }

}
