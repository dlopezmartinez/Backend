using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Metaenlace.DTOs;
using Metaenlace.Models;
using Metaenlace.Services;

namespace Metaenlace.Mapper
{
    public class MapperProfile : Profile
    {
        public IMedicoService medService;
        public IPacienteService pacService;
        public IDiagnosticoService diaService;

        public MapperProfile()
        {
 

            
            CreateMap<Paciente, PacienteDTO>().ForMember(dto => dto.Medicos, o => o.MapFrom(pac => pac.Medicos.Select(m => m.ID).ToList()));
            CreateMap<PacienteDTO, Paciente>().ForMember(pac => pac.Medicos, o => o.MapFrom(dto => pacService.FindList(dto.Medicos)));

            CreateMap<Medico, MedicoDTO>().ForMember(dto => dto.Pacientes, o => o.MapFrom(med => med.Pacientes.Select(m => m.ID).ToList()));
            CreateMap<MedicoDTO, Medico>().ForMember(med => med.Pacientes, o => o.MapFrom(dto => medService.FindList(dto.Pacientes)));
            
            CreateMap<Cita, CitaDTO>().ForMember(dto => dto.medicoID, o => o.MapFrom(s => s.medico.ID))
                .ForMember(dto => dto.pacienteID, o => o.MapFrom(s => s.paciente.ID))
                .ForMember(dto => dto.diagnosticoID, o => o.MapFrom(s => s.diagnostico.ID));
            
            CreateMap<CitaDTO, Cita>().ForMember(c => c.medico, o => o.MapFrom( dto => medService.FindById(dto.medicoID)))
                .ForMember(c => c.paciente, o => o.MapFrom(dto => pacService.FindById(dto.pacienteID)))
                .ForMember(c => c.diagnostico, o => o.MapFrom(dto => diaService.FindById(dto.diagnosticoID)));
            
            CreateMap<Diagnostico, DiagnosticoDTO>().ForMember(dto => dto.citaID, o => o.MapFrom(d => d.cita.ID));
            CreateMap<DiagnosticoDTO, Diagnostico>().ForMember(d => d.cita, o => o.MapFrom(dto => diaService.FindById(dto.citaID)));

        }



    }
}
