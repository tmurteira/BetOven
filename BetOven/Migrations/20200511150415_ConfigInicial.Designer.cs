﻿// <auto-generated />
using System;
using BetOven.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BetOven.Migrations
{
    [DbContext(typeof(BetOvenDB))]
    [Migration("20200511150415_ConfigInicial")]
    partial class ConfigInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BetOven.Models.Apostas", b =>
                {
                    b.Property<int>("nAposta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("quantia")
                        .HasColumnType("float");

                    b.HasKey("nAposta");

                    b.HasIndex("UserFK");

                    b.ToTable("Apostas");
                });

            modelBuilder.Entity("BetOven.Models.Apostas_Jogos", b =>
                {
                    b.Property<int>("ApostaFK")
                        .HasColumnType("int");

                    b.Property<int>("JogoFK")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("multiplicador")
                        .HasColumnType("float");

                    b.HasKey("ApostaFK");

                    b.HasIndex("JogoFK");

                    b.ToTable("Apostas_Jogos");
                });

            modelBuilder.Entity("BetOven.Models.Depositos", b =>
                {
                    b.Property<int>("nDeposito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<string>("formato_pagamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("montante")
                        .HasColumnType("float");

                    b.Property<string>("origem_deposito")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nDeposito");

                    b.HasIndex("UserFK");

                    b.ToTable("Depositos");
                });

            modelBuilder.Entity("BetOven.Models.Jogos", b =>
                {
                    b.Property<int>("njogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Resultado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datainiciojogo")
                        .HasColumnType("datetime2");

                    b.Property<string>("equipaA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("equipaB")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("njogo");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("BetOven.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datanasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nacionalidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BetOven.Models.Apostas", b =>
                {
                    b.HasOne("BetOven.Models.Users", "User")
                        .WithMany("ListaApostas")
                        .HasForeignKey("UserFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BetOven.Models.Apostas_Jogos", b =>
                {
                    b.HasOne("BetOven.Models.Apostas", "Aposta")
                        .WithMany()
                        .HasForeignKey("ApostaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BetOven.Models.Jogos", "Jogo")
                        .WithMany()
                        .HasForeignKey("JogoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BetOven.Models.Depositos", b =>
                {
                    b.HasOne("BetOven.Models.Users", "User")
                        .WithMany("ListaDepositos")
                        .HasForeignKey("UserFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
