using CoderCarrer.Domain;
using CoderCarrer.Models;

namespace CoderCarrer.DAL
{
    public class VagasFake : IExtratorVaga
    {
        public List<Vaga> getVagas()
        {
            List<Vaga> vagas = new List<Vaga>();
            List<Vaga> _listafake;
            _listafake = new List<Vaga>();

            Vaga vaga1 = new Vaga();
            vaga1.titulo = "Programador Junior";
            vaga1.empresa = "HWUAI";
            vaga1.descricao_vaga = "Produção";
            _listafake.Add(vaga1);

            Vaga vaga2 = new Vaga();
            vaga2.titulo = "Psicologa";
            vaga2.empresa = "CAPS";
            vaga2.descricao_vaga = "Preferência louca";
            _listafake.Add(vaga2);

            Vaga vaga3 = new Vaga();
            vaga3.titulo = "Jogador de LOL";
            vaga3.empresa = "Casa de Maia";
            vaga3.descricao_vaga = "Jogador de lol main sup";
            _listafake.Add(vaga3);

            Vaga vaga4 = new Vaga();
            vaga4.titulo = "Professor";
            vaga4.empresa = "Senai";
            vaga4.descricao_vaga = "Professor dessa porra";
            _listafake.Add(vaga4);

            

            return _listafake;
        }
    }
}
