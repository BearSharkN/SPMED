using SpMedicalGroup.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.webAPI.Interfaces
{
    interface IConsultaRepository
    {
        
        List<Consulta> ListarConsultas();  

        Consulta BuscarConsultaPorId(int id);

        void CadastrarConsulta(Consulta novaConsulta);

        void AtualizarUrlConsulta(int id, Consulta consultaAtualizada);

        void DeletarConsulta(int id);

        void AlterarSituacaoConsulta(int id, int situacao);

        List<Consulta> ListarConsultasMedico(int id);

        List<Consulta> ListarConsultasPaciente(int id);


    
    }
}
