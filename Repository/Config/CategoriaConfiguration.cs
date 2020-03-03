﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Config
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            throw new NotImplementedException();
        }
    }
}

/*
    Essas são as classes de mapeamento, que irá definir os tipos
    de propriedades das entidades exe: tamanho, maximo de caractere
    tipo da coluna no banco. Configurações gerais das tabelas do
    banco de dados.
    Herdam da classe IEntityTypeConfiguration do EntityFrameworkCore,
    e são tipadas da entidade corespondente.
    Devem ser colocadas na classe de contexto.
    
*/
