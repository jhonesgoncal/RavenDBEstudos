using Model;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioGenerico<T> where T:  ElementoBase, new()
    {
        public DocumentStore store { get; set; }
        public RepositorioGenerico()
        {
            store = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "RavenDBEstudos"
            };

            store.Initialize();
        }

        public virtual string Cadastrar(T item)
        {
            item.Id = null;
            return Salvar(item);
        }

        public virtual T Consulte(string idDoItem)
        {
            using (IDocumentSession session = store.OpenSession())
            {

                return session.Load<T>(idDoItem);
            }
            
        }

        public virtual List<T> Liste()
        {
            using (IDocumentSession session = store.OpenSession())
            {

                return session.Query<T>().ToList();
            }

        }

        public virtual string Salvar(T item)
        {
            using (IDocumentSession session = store.OpenSession())
            {

                session.Store(item);
                session.SaveChanges();
            }

            return item.Id;
        }

        public virtual void Remover(string idDoItemSalvo)
        {
            using (IDocumentSession session = store.OpenSession())
            {

                session.Delete(idDoItemSalvo);
                session.SaveChanges();
            }

        }

        public virtual string Atualizar(T item)
        {

            return Salvar(item);
        }
    }
}
