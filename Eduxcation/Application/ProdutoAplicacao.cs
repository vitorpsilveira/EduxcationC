using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduxcation.Models;

namespace Eduxcation.Aplicacao
{
    public class ProdutoAplicacao
    {
        private EduxcationContext _contexto;

        public ProdutoAplicacao(EduxcationContext contexto)
        {
            _contexto = contexto;
        }

        public string InserirProduto(Produto prod)
        {
            try
            {
                if (prod != null)
                {
                    var produtoExiste = GetProdByID(prod.Id);

                    if (produtoExiste == null)
                    {
                        _contexto.Add(prod);
                        _contexto.SaveChanges();

                        return "Produto cadastrado com sucesso!";
                    }
                    else
                    {
                        return "produto já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string AtualizarProduto(Produto prod)
        {
            try
            {
                if (prod != null)
                {
                    _contexto.Update(prod);
                    _contexto.SaveChanges();

                    return "Produto alterado com sucesso!";
                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Produto GetProdByID(int codProd)
        {
            Produto primeiroProduto = new Produto();

            try
            {
                if (codProd == 0)
                {
                    return null;
                }

                var prd = _contexto.Produtos.Where(x => x.Id == codProd).ToList();
                primeiroProduto = prd.FirstOrDefault();

                if (primeiroProduto != null)
                {
                    return primeiroProduto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Produto> GetAllProducts()
        {
            List<Produto> listaDProdutos = new List<Produto>();
            try
            {

                listaDProdutos = _contexto.Produtos.ToList(); //_contexto.Produtos.Select(x => x).ToList();

                if (listaDProdutos != null)
                {
                    return listaDProdutos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DeleteProductByCod(int codProd)
        {
            try
            {
                if (codProd == 0)
                {
                    return "Produto inválido! Por favor tente novamente.";
                }
                else
                {
                    var prd = GetProdByID(codProd);

                    if (prd != null)
                    {
                        _contexto.Produtos.Remove(prd);
                        _contexto.SaveChanges();

                        return "Produto " + prd.Descricao + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Produto não cadastrado!";
                    }
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

    }
}

