using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DAL
{
    //T referente a um objeto dinamico podendo receber qualquer objeto
    public interface IRepository<T> 
    {
        bool Cadastrar(T objct);
        List<T> Listar();
        T BuscarPorId(int? id);
    }
}
